namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms.DataVisualization.Charting;
    using CommonObjectives;
    using Serilog;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Day Report Task to generate Objectives Day Reports.
    /// </summary>
    public class TaskDayReport
    {
        // Get references to the Outlook Calendars.
        private readonly Outlook.Folder calendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
        private readonly Outlook.Folder system = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;

        // Standardize the colors.
        private readonly Color colorUptime = Color.FromArgb(32, 32, 32);
        private readonly Color colorBillable = Color.FromArgb(64, 64, 255);
        private readonly Color colorIdle = Color.FromArgb(255, 64, 64);
        private readonly Color colorOther = Color.FromArgb(255, 128, 64);

        private readonly Action callBack;
        private readonly DayReport dayReport = new DayReport();
        private readonly DateTime firstDay = new DateTime(2021, 5, 25);
        private DateTime day;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDayReport"/> class.
        /// Returns control back to the TaskManager.
        /// </summary>
        /// <param name="callBack">Callback for when the task has finished.</param>
        public TaskDayReport(Action callBack)
        {
            this.callBack = callBack;
        }

        /// <summary>
        /// Creates a thread to run the Task.
        /// </summary>
        public void RunTask()
        {
            Thread backgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskDayReport",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
            };
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();
        }

        /// <summary>
        /// The starting point for the new process.
        /// </summary>
        private void BackgroundProcess()
        {
            day = FindDay();
            if (day != DateTime.MinValue)
            {
                Log.Information("Processing Day :" + day.ToString());

                // Initialize the array of minutes within the DayReport object.
                for (int i = 0; i < 1440; i++)
                {
                    dayReport.Minutes[i] = new Minute(i);
                }

                ProcessAppointments();
                CalculateMinutes();
                CalculateBillableItems();
                DrawSystemTimeImage();
                DrawObjectiveImage();
                DrawApplicationsImage();
                DrawDayBarImage();
                CreateHTML();
                CreateAppointment();
            }
            else
            {
                Log.Information("No day found to process.");
            }

            callBack?.Invoke();
        }

        /// <summary>
        /// Find the day that is suitable to create the report for.
        /// </summary>
        /// <returns>A date time of the day found.</returns>
        private DateTime FindDay()
        {
            DateTime returnValue = DateTime.Parse(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString(@"yyyy-MM-dd 00:00"));

            bool keepLooking = true;
            int totalDays = 0;

            while (keepLooking)
            {
                keepLooking = false;
                Outlook.Items billingItems = GetAppointmentsInRange(calendar, returnValue, returnValue.AddDays(1));
                foreach (Outlook.AppointmentItem nextItem in billingItems)
                {
                    if (nextItem.Categories == "Objectives - Day Report")
                    {
                        returnValue = returnValue.AddDays(-1);
                        keepLooking = true;
                        break;
                    }
                }

                totalDays++;

                if (returnValue < firstDay)
                {
                    return DateTime.MinValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Primary process to create a DayReport.
        /// </summary>
        private void ProcessAppointments()
        {
            // DateTimes for start and finish of the day.
            DateTime start = day;
            DateTime finsh = day.AddHours(24);
            dayReport.Day = day;

            // Find all the appointment items within the start and finish times from the System Calendar.
            Outlook.Items appointments = GetAppointmentsWithinRange(system, start, finsh);

            // Process all the system appointments.
            foreach (object appointment in appointments)
            {
                Outlook.AppointmentItem next = (Outlook.AppointmentItem)appointment;
                switch (next.Categories)
                {
                    case "System - Uptime":
                        ProcessSystemUptime(next.Body);
                        break;

                    case "System - Idle":
                        ProcessSystemIdle(next.Body);
                        break;

                    default:
                        Log.Information("Category : " + next.Categories);
                        break;
                }
            }

            // Find all the appointment items within the start and finish times from the Objectives Calendar.
            appointments = GetAppointmentsWithinRange(calendar, start, finsh);

            // Process the appointments based on the application type.
            foreach (object appointment in appointments)
            {
                Outlook.AppointmentItem next = (Outlook.AppointmentItem)appointment;
                Outlook.UserProperty customProperty = next.UserProperties.Find("Application");
                if (customProperty is null)
                {
                    Log.Information("No Application Type " + next.Subject + " " + next.Start.ToString());
                }
                else
                {
                    switch ((ApplicationType)customProperty.Value)
                    {
                        case ApplicationType.None:

                            // TODO Process based on work type? Or replace this whole switch with work type in the future?
                            break;

                        case ApplicationType.VisualStudioWrite:
                            ProcessWorkItem(next.Body);
                            break;

                        case ApplicationType.VisualStudioRead:
                            if (CheckNotIdle(next.Body))
                            {
                                ProcessWorkItem(next.Body);
                            }

                            break;

                        case ApplicationType.WordWrite:
                            ProcessWorkItem(next.Body);
                            break;

                        case ApplicationType.WordRead:
                            if (CheckNotIdle(next.Body))
                            {
                                ProcessWorkItem(next.Body);
                            }

                            break;

                        case ApplicationType.ExcelWrite:
                            ProcessWorkItem(next.Body);
                            break;

                        case ApplicationType.ExcelRead:
                            if (CheckNotIdle(next.Body))
                            {
                                ProcessWorkItem(next.Body);
                            }

                            break;

                        case ApplicationType.AutocadWrite:
                            ProcessWorkItem(next.Body);
                            break;

                        case ApplicationType.AutocadRead:
                            if (CheckNotIdle(next.Body))
                            {
                                ProcessWorkItem(next.Body);
                            }

                            break;

                        default:
                            Log.Information("Unmanaged Application Type: " + (ApplicationType)customProperty.Value);
                            break;
                    }
                }

                if (customProperty != null)
                {
                    _ = Marshal.ReleaseComObject(customProperty);
                }
            }
        }

        private void CalculateMinutes()
        {
            for (int i = 0; i < 1440; i++)
            {
                // Count the number of minutes that are work related.
                if (dayReport.Minutes[i].Billable == true)
                {
                    dayReport.TotalWork++;
                }

                // Count the number of minutes that the system is on-line.
                if (dayReport.Minutes[i].Up == true)
                {
                    dayReport.TotalUptime++;
                    if (dayReport.Minutes[i].Idle == true)
                    {
                        dayReport.TotalIdle++;
                    }
                }

                // Count the number of minutes each application is in the foreground.
                if (dayReport.Minutes[i].ActiveApplication is object)
                {
                    if (dayReport.UniqueApplications.ContainsKey(dayReport.Minutes[i].ActiveApplication))
                    {
                        dayReport.UniqueApplications[dayReport.Minutes[i].ActiveApplication]++;
                    }
                    else
                    {
                        dayReport.UniqueApplications.Add(dayReport.Minutes[i].ActiveApplication, 1);
                    }
                }

                if (dayReport.Minutes[i].PrimaryWorkItem is object)
                {
                    string key = dayReport.Minutes[i].PrimaryWorkItem.ObjectiveName + "-" + dayReport.Minutes[i].PrimaryWorkItem.Name + "-" + dayReport.Minutes[i].PrimaryWorkItem.WorkType.Index;
                    if (!dayReport.WorkItems.ContainsKey(key))
                    {
                        dayReport.Minutes[i].PrimaryWorkItem.Minutes = 1;
                        dayReport.WorkItems.Add(key, dayReport.Minutes[i].PrimaryWorkItem);
                    }
                    else
                    {
                        dayReport.WorkItems[key].Minutes++;
                    }
                }
            }
        }

        private void CalculateBillableItems()
        {
            // Loop though the work items.
            foreach (KeyValuePair<string, WorkItem> next in dayReport.WorkItems)
            {
                // Calculate the cost of the total minutes for the day.
                next.Value.Cost = next.Value.WorkType.CostPerHour / 60 * next.Value.Minutes;

                // Parse to truncate the precision to suit dollars and cents.
                next.Value.Cost = decimal.Parse(next.Value.Cost.ToString("0.00"));
            }
        }

        private void CreateAppointment()
        {
            // Create the DayReport appointment and add the images as attachments.
            Outlook.AppointmentItem newAppointmentItem = (Outlook.AppointmentItem)calendar.Items.Add(Outlook.OlItemType.olAppointmentItem);
            newAppointmentItem.Subject = "Day Report [" + InTouch.GetTimeStringFromMinutes(dayReport.TotalWork) + "]";
            newAppointmentItem.Categories = "Objectives - Day Report";
            newAppointmentItem.Start = day;
            newAppointmentItem.AllDayEvent = true;
            newAppointmentItem.ReminderSet = false;
            newAppointmentItem.Body = JsonConvert.SerializeObject(dayReport, Formatting.Indented);
            _ = newAppointmentItem.Attachments.Add(System.IO.Path.GetTempPath() + "ObjectivesChart.png", Outlook.OlAttachmentType.olByValue, 1, "ObjectivesChart");
            _ = newAppointmentItem.Attachments.Add(System.IO.Path.GetTempPath() + "SystemTime.png", Outlook.OlAttachmentType.olByValue, 2, "SystemTimeChart");
            _ = newAppointmentItem.Attachments.Add(System.IO.Path.GetTempPath() + "Applications.png", Outlook.OlAttachmentType.olByValue, 3, "ApplicationsChart");
            _ = newAppointmentItem.Attachments.Add(System.IO.Path.GetTempPath() + "DayBar.png", Outlook.OlAttachmentType.olByValue, 4, "DayBar");
            newAppointmentItem.Save();
        }

        /// <summary>
        /// Creates the HTML for the report.
        /// </summary>
        private void CreateHTML()
        {
            string rv = "<!DOCTYPE HTML>" + "\n";
            rv += "<html>" + "\n";
            rv += "<head>" + "\n";
            rv += "<title>Day Report</title>" + "\n";
            rv += "<link rel=\"stylesheet\" href=\"[[[TEMPDIRECTORY]]]page.css\" />" + "\n";
            rv += "</head>" + "\n";
            rv += "<body>" + "\n";

            rv += "<div class=\"divWholePage\">" + "\n";
            rv += "<h1>Day Report for " + dayReport.Day.ToString("dddd d/MM/yyyy") + "</h1>" + "\n";

            rv += "<h2>Billable Items</h2>" + "\n";
            rv += "<table width=\"100%\">" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td class=\"tdHeader\">Objective</td>\n";
            rv += "<td class=\"tdHeader\">Project</td>\n";
            rv += "<td class=\"tdHeader\">Task</td>\n";
            rv += "<td class=\"tdHeader\" style=\"text-align:right;\">Time</td>\n";
            rv += "<td class=\"tdHeader\" style=\"text-align:right;\">Cost</td>\n";
            rv += "</tr>" + "\n";

            int totaltime = 0;
            decimal totalcost = 0;

            foreach (KeyValuePair<string, WorkItem> next in dayReport.WorkItems.OrderBy(x => x.Value.ObjectiveName).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkType.Index))
            {
                if (next.Value.Cost > 0)
                {
                    rv += "<tr>" + "\n";
                    rv += "<td style=\"max-height:18px;\">" + next.Value.ObjectiveName + "</td>\n";
                    rv += "<td style=\"max-height:18px;\">" + next.Value.Name + "</td>\n";
                    rv += "<td style=\"max-height:18px;\">" + next.Value.WorkType.Name + "</td>\n";
                    rv += "<td style=\"max-height:18px;text-align:right;\">" + InTouch.GetTimeStringFromMinutes(next.Value.Minutes) + "</td>\n";
                    rv += "<td style=\"max-height:18px;text-align:right;\">$" + next.Value.Cost.ToString("0.00") + "</td>\n";
                    rv += "</tr>" + "\n";

                    totaltime += next.Value.Minutes;
                    totalcost += next.Value.Cost;
                }
            }

            rv += "<tr>" + "\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td></td>\n";
            rv += "<td></td>\n";
            rv += "<td style=\"text-align:right;\"><b>" + InTouch.GetTimeStringFromMinutes(totaltime) + "</b></td>\n";
            rv += "<td style=\"text-align:right;\"><b>$" + totalcost.ToString("0.00") + "</b></td>\n";
            rv += "</tr>" + "\n";

            rv += "</table>" + "\n";

            rv += "<h2>Objectives</h2>" + "\n";
            rv += "<table width=\"100%\">" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td class=\"tdHeader\">Objective</td>\n";
            rv += "<td class=\"tdHeader\">Project</td>\n";
            rv += "<td class=\"tdHeader\">Task</td>\n";
            rv += "<td class=\"tdHeader\" style=\"text-align:right;\">Time</td>\n";
            rv += "<td rowspan=\"14\" style=\"text-align:right;\"><img src=\"[[[TEMPDIRECTORY]]]ObjectivesChart.png\" alt=\"Objectives Chart\"></td>\n";
            rv += "</tr>" + "\n";

            int i = 0;
            string lastObjectiveName = string.Empty;
            int objectiveTime = 0;
            int totalTime = 0;

            foreach (KeyValuePair<string, WorkItem> next in dayReport.WorkItems.OrderBy(x => x.Value.ObjectiveName).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkType.Index))
            {
                if (lastObjectiveName == string.Empty)
                {
                    lastObjectiveName = next.Value.ObjectiveName;
                }
                else if (lastObjectiveName != next.Value.ObjectiveName)
                {
                    rv += "<tr>" + "\n";
                    rv += "<td>&nbsp;</td>\n";
                    rv += "<td>&nbsp;</td>\n";
                    rv += "<td>&nbsp;</td>\n";
                    rv += "<td style=\"text-align:right;\"><b>" + InTouch.GetTimeStringFromMinutes(objectiveTime) + "</b></td>\n";
                    rv += "</tr>" + "\n";
                    i++;

                    lastObjectiveName = next.Value.ObjectiveName;
                    objectiveTime = 0;
                }

                rv += "<tr>" + "\n";
                rv += "<td>" + next.Value.ObjectiveName + "</td>\n";
                rv += "<td>" + next.Value.Name + "</td>\n";
                rv += "<td>" + next.Value.WorkType.Name + "</td>\n";
                rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(next.Value.Minutes) + "</td>\n";
                rv += "</tr>" + "\n";

                objectiveTime += next.Value.Minutes;
                totalTime += next.Value.Minutes;
                i++;
            }

            if (dayReport.WorkItems.Count > 0)
            {
                rv += "<tr>" + "\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td style=\"text-align:right;\"><b>" + InTouch.GetTimeStringFromMinutes(objectiveTime) + "</b></td>\n";
                rv += "</tr>" + "\n";
                i++;
            }

            rv += "<tr>" + "\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td style=\"text-align:right;\"><b>" + InTouch.GetTimeStringFromMinutes(totalTime) + "</b></td>\n";
            rv += "</tr>" + "\n";
            i++;

            while (i < 14)
            {
                rv += "<tr>" + "\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "<td>&nbsp;</td>\n";
                rv += "</tr>" + "\n";
                i++;
            }

            rv += "</table>" + "\n";

            rv += "<h2>Day Outline</h2>" + "\n";
            rv += "<img src =\"[[[TEMPDIRECTORY]]]DayBar.png\" alt=\"Day Bar\">\n";

            rv += "<h2>Time Spans</h2>" + "\n";
            rv += "<table width=\"100%\">" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td class=\"tdHeader\" >Activity</td>\n";
            rv += "<td class=\"tdHeader\" style=\"text-align:right;\">Total</td>\n";
            rv += "<td class=\"tdHeader\" style=\"text-align:right;\">Percentage of the day</td>\n";
            rv += "<td class=\"tdHeader\" rowspan=\"8\" style=\"text-align:right;\"><img class=\"imageRight\" src=\"[[[TEMPDIRECTORY]]]SystemTime.png\" alt=\"System Time Chart\"></td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Up Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(dayReport.TotalUptime) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + (((double)dayReport.TotalUptime) / 1440 * 100).ToString("0.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Billable Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(dayReport.TotalWork) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + (((double)dayReport.TotalWork) / 1440 * 100).ToString("#.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Other Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(dayReport.TotalUptime - dayReport.TotalWork - dayReport.TotalIdle) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + (((double)(dayReport.TotalUptime - dayReport.TotalWork - dayReport.TotalIdle)) / 1440 * 100).ToString("#.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Active Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(dayReport.TotalUptime - dayReport.TotalIdle) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + (((double)(dayReport.TotalUptime - dayReport.TotalIdle)) / 1440 * 100).ToString("#.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Idle Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(dayReport.TotalIdle) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + (((double)dayReport.TotalIdle) / 1440 * 100).ToString("#.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr>" + "\n";
            rv += "<td>Down Time" + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + InTouch.GetTimeStringFromMinutes(1440 - dayReport.TotalUptime) + "</td>\n";
            rv += "<td style=\"text-align:right;\">" + ((1440 - ((double)dayReport.TotalUptime)) / 1440 * 100).ToString("#.00") + "%</td>\n";
            rv += "</tr>" + "\n";

            rv += "<tr style=\"height:100px;\">" + "\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "<td>&nbsp;</td>\n";
            rv += "</tr>" + "\n";

            rv += "</table>" + "\n";

            rv += "<h2>Applications</h2>" + "\n";
            rv += "<img src =\"[[[TEMPDIRECTORY]]]Applications.png\" alt=\"Applications Chart\">\n";

            rv += "</div>" + "\n";
            rv += "</body>" + "\n";
            rv += "</html>" + "\n";

            dayReport.HTML = rv;
        }

        /// <summary>
        /// Draws the Day Bar image.
        /// </summary>
        private void DrawDayBarImage()
        {
            // Art supplies.
            Pen penUptime = new Pen(colorUptime, 1);
            Pen penWork = new Pen(colorBillable, 1);
            Pen penIdle = new Pen(colorIdle, 1);
            Pen penLabel = new Pen(Color.Gray, 1);
            Font fontLabel = new Font("Arial", 8);
            Brush brushLabel = Brushes.Gray;

            Brush brushBackground = new SolidBrush(Color.FromArgb(40, 40, 40));

            Bitmap bm = new Bitmap(800, 120);

            // Draw Day Bar.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(40, 0, 720, 100);
                gr.FillRectangle(brushBackground, rect);

                // Draw time labels and lines on lowest layer.
                for (int i = 0; i < 25; i++)
                {
                    int x = (i * 30) + 40;
                    gr.DrawLine(penLabel, x, 0, x, 100);

                    if (i == 0)
                    {
                        gr.DrawString("12AM", fontLabel, brushLabel, x - 20, 105);
                    }
                    else if (i == 24)
                    {
                        gr.DrawString("12AM", fontLabel, brushLabel, x - 20, 105);
                    }
                    else if (i == 12)
                    {
                        gr.DrawString("12PM", fontLabel, brushLabel, x - 20, 105);
                    }
                    else if (i < 12)
                    {
                        gr.DrawString(i.ToString() + "AM", fontLabel, brushLabel, x - 20, 105);
                    }
                    else
                    {
                        gr.DrawString((i - 12).ToString() + "PM", fontLabel, brushLabel, x - 20, 105);
                    }
                }

                gr.DrawLine(penLabel, 40, 0, 760, 0);
                gr.DrawLine(penLabel, 40, 100, 760, 100);

                // Draw lines for each minute.
                for (int i = 0; i < 1440; i++)
                {
                    // Draw up time.
                    if (dayReport.Minutes[i].Up)
                    {
                        int x = (i / 2) + 40;

                        gr.DrawLine(penUptime, x, 10, x, 90);
                    }

                    // Draw billable time.
                    if (dayReport.Minutes[i].Billable)
                    {
                        int x = (i / 2) + 40;

                        gr.DrawLine(penWork, x, 20, x, 80);
                    }

                    // Draw idle time.
                    if (dayReport.Minutes[i].Idle)
                    {
                        int x = (i / 2) + 40;

                        gr.DrawLine(penIdle, x, 30, x, 70);
                    }
                }
            }

            // Finally save to file.
            bm.Save(System.IO.Path.GetTempPath() + "DayBar.png");
        }

        /// <summary>
        /// Draw the applications graph.
        /// </summary>
        private void DrawApplicationsImage()
        {
            string series1 = "Series1";

            float chartWidth = 800;
            float chartHeight = dayReport.UniqueApplications.Count * 44;

            Chart chart = new Chart
            {
                Width = (int)chartWidth,
                Height = (int)chartHeight,
                BackColor = Color.Transparent,
            };

            _ = chart.ChartAreas.Add(series1);
            _ = chart.Series.Add(series1);
            chart.Series[series1].ChartArea = series1;
            chart.Series[series1].ChartType = SeriesChartType.Bar;

            chart.ChartAreas[series1].BackColor = Color.Transparent;
            chart.ChartAreas[series1].Position.X = 0;
            chart.ChartAreas[series1].Position.Y = 0;
            chart.ChartAreas[series1].Position.Width = 100;
            chart.ChartAreas[series1].Position.Height = 100;
            chart.ChartAreas[series1].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            chart.ChartAreas[series1].AxisX.LabelStyle.Font = new Font("Verdana", 10F, FontStyle.Regular);
            chart.ChartAreas[series1].AxisX.LabelStyle.ForeColor = Color.FromArgb(180, 180, 180);
            chart.ChartAreas[series1].AxisX.Interval = 1;
            chart.ChartAreas[series1].AxisX.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisX.MajorGrid.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisX.MinorGrid.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisX.MajorTickMark.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisX.MinorTickMark.LineColor = Color.FromArgb(0, 0, 0, 0);

            chart.ChartAreas[series1].AxisY.Enabled = AxisEnabled.False;
            chart.ChartAreas[series1].AxisY.LabelStyle.Font = new Font("Calibri", 11F, FontStyle.Regular);
            chart.ChartAreas[series1].AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[series1].AxisY.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisY.MajorGrid.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisY.MinorGrid.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisY.MajorTickMark.LineColor = Color.FromArgb(0, 0, 0, 0);
            chart.ChartAreas[series1].AxisY.MinorTickMark.LineColor = Color.FromArgb(0, 0, 0, 0);

            chart.ChartAreas[series1].Name = "Applications";

            foreach (KeyValuePair<string, int> next in dayReport.UniqueApplications)
            {
                int rv = chart.Series[series1].Points.AddXY(next.Key, next.Value);
                chart.Series[series1].Points[rv].Label = "  " + InTouch.GetTimeStringFromMinutes(next.Value);
                chart.Series[series1].Points[rv].LabelForeColor = Color.White;
            }

            chart.SaveImage(System.IO.Path.GetTempPath() + "Applications.png", ChartImageFormat.Png);
        }

        /// <summary>
        /// Draw the system time graph.
        /// </summary>
        private void DrawSystemTimeImage()
        {
            float chartWidth = 300;
            float chartHeight = 300;
            Chart chart = new Chart
            {
                Width = (int)chartWidth,
                Height = (int)chartHeight,
                BackColor = Color.Transparent,
            };

            // Setup the first (outer) series.
            string series1 = "Series1";
            _ = chart.ChartAreas.Add(series1);
            _ = chart.Series.Add(series1);
            chart.Series[series1].ChartArea = series1;
            chart.Series[series1].ChartType = SeriesChartType.Doughnut;
            chart.Series[series1]["PieStartAngle"] = "270";
            chart.Series[series1]["DoughnutRadius"] = "60";
            chart.ChartAreas[series1].BackColor = Color.Transparent;
            chart.ChartAreas[series1].Position.X = 0;
            chart.ChartAreas[series1].Position.Y = 0;
            chart.ChartAreas[series1].Position.Width = 100;
            chart.ChartAreas[series1].Position.Height = 100;
            chart.ChartAreas[series1].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            // Setup the second (internal) series.
            string series2 = "Series2";
            _ = chart.ChartAreas.Add(series2);
            _ = chart.Series.Add(series2);
            chart.Series[series2].ChartArea = series2;
            chart.Series[series2].ChartType = SeriesChartType.Doughnut;
            chart.Series[series2]["PieStartAngle"] = "270";
            chart.Series[series2]["DoughnutRadius"] = "80";
            chart.ChartAreas[series2].BackColor = Color.Transparent;
            chart.ChartAreas[series2].Position.X = 25F;
            chart.ChartAreas[series2].Position.Y = 25F;
            chart.ChartAreas[series2].Position.Width = 50F;
            chart.ChartAreas[series2].Position.Height = 50F;
            chart.ChartAreas[series2].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            // Draw the uptime segment.
            int rv1 = chart.Series[series2].Points.AddXY("Up Time", dayReport.TotalUptime);
            chart.Series[series2].Points[rv1].Color = colorUptime;
            chart.Series[series2].Points[rv1].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Draw the uptime segment.
            int rv2 = chart.Series[series2].Points.AddY(1440 - dayReport.TotalUptime);
            chart.Series[series2].Points[rv2].Color = Color.FromArgb(0, 0, 0, 0);
            chart.Series[series2].Points[rv2].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Draw the billable segment.
            int rv3 = chart.Series[series1].Points.AddXY("Billable Time", dayReport.TotalWork);
            chart.Series[series1].Points[rv3].Color = colorBillable;
            chart.Series[series1].Points[rv3].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Draw the other time segment.
            int rv4 = chart.Series[series1].Points.AddXY("Other Time", dayReport.TotalUptime - dayReport.TotalIdle - dayReport.TotalWork);
            chart.Series[series1].Points[rv4].Color = colorOther;
            chart.Series[series1].Points[rv4].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Draw the idle time segment.
            int rv5 = chart.Series[series1].Points.AddXY("Idle Time", dayReport.TotalIdle);
            chart.Series[series1].Points[rv5].Color = colorIdle;
            chart.Series[series1].Points[rv5].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Draw the downtime segment as transparent.
            int rv6 = chart.Series[series1].Points.AddY(1440 - dayReport.TotalUptime);
            chart.Series[series1].Points[rv6].Color = Color.FromArgb(0, 0, 0, 0);
            chart.Series[series1].Points[rv6].LabelForeColor = Color.FromArgb(255, 255, 255);

            // Save the image to file.
            chart.SaveImage(System.IO.Path.GetTempPath() + "SystemTime.png", ChartImageFormat.Png);
        }

        /// <summary>
        /// Draw the objectives graph.
        /// </summary>
        private void DrawObjectiveImage()
        {
            float chartWidth = 360;
            float chartHeight = 360;
            Chart chart = new Chart
            {
                Width = (int)chartWidth,
                Height = (int)chartHeight,
                BackColor = Color.Transparent,
            };

            // Setup the first series.
            string series1 = "Series1";
            _ = chart.ChartAreas.Add(series1);
            _ = chart.Series.Add(series1);
            chart.Series[series1].ChartArea = series1;
            chart.Series[series1].ChartType = SeriesChartType.Doughnut;
            chart.ChartAreas[series1].BackColor = Color.Transparent;
            chart.ChartAreas[series1].Position.X = 0;
            chart.ChartAreas[series1].Position.Y = 0;
            chart.ChartAreas[series1].Position.Width = 100;
            chart.ChartAreas[series1].Position.Height = 100;
            chart.ChartAreas[series1].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            // Setup the second series.
            string series2 = "Series2";
            _ = chart.ChartAreas.Add(series2);
            _ = chart.Series.Add(series2);
            chart.Series[series2].ChartArea = series2;
            chart.Series[series2].ChartType = SeriesChartType.Doughnut;
            chart.ChartAreas[series2].BackColor = Color.Transparent;
            chart.ChartAreas[series2].Position.X = 12.5F;
            chart.ChartAreas[series2].Position.Y = 12.5F;
            chart.ChartAreas[series2].Position.Width = 75F;
            chart.ChartAreas[series2].Position.Height = 75F;
            chart.ChartAreas[series2].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            HashSet<string> objectiveNames = new HashSet<string>();

            foreach (KeyValuePair<string, WorkItem> next in dayReport.WorkItems.OrderBy(x => x.Value.ObjectiveName).OrderBy(x => x.Value.Name))
            {
                _ = objectiveNames.Add(next.Value.ObjectiveName);
            }

            foreach (string outer in objectiveNames)
            {
                int totalminutes = 0;

                foreach (KeyValuePair<string, WorkItem> inner in dayReport.WorkItems.OrderBy(x => x.Value.ObjectiveName).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.Application))
                {
                    if (inner.Value.ObjectiveName == outer)
                    {
                        totalminutes += inner.Value.Minutes;

                        switch (inner.Value.Application)
                        {
                            case ApplicationType.VisualStudioWrite:
                                int rv = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv].Color = Color.FromArgb(156, 64, 156);
                                break;

                            case ApplicationType.VisualStudioRead:
                                int rv2 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv2].Color = Color.FromArgb(72, 72, 72);
                                break;

                            case ApplicationType.WordWrite:
                                int rv3 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv3].Color = Color.FromArgb(128, 128, 255);
                                break;

                            case ApplicationType.WordRead:
                                int rv4 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv4].Color = Color.FromArgb(72, 72, 72);
                                break;

                            case ApplicationType.ExcelWrite:
                                int rv5 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv5].Color = Color.FromArgb(128, 255, 128);
                                break;

                            case ApplicationType.ExcelRead:
                                int rv6 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv6].Color = Color.FromArgb(72, 72, 72);
                                break;

                            case ApplicationType.AutocadWrite:
                                int rv7 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv7].Color = Color.FromArgb(255, 64, 64);
                                break;

                            case ApplicationType.AutocadRead:
                                int rv8 = chart.Series[series1].Points.AddY(inner.Value.Minutes);
                                chart.Series[series1].Points[rv8].Color = Color.FromArgb(72, 72, 72);
                                break;
                        }
                    }
                }

                int rvt = chart.Series[series2].Points.AddXY(outer, totalminutes);
                chart.Series[series2].Points[rvt].LabelForeColor = Color.FromArgb(255, 255, 255);
            }

            // Save the image to file.
            chart.SaveImage(System.IO.Path.GetTempPath() + "ObjectivesChart.png", ChartImageFormat.Png);
        }

        /// <summary>
        /// Process the system time data.
        /// </summary>
        /// <param name="json">JSON to be parsed.</param>
        private void ProcessSystemUptime(string json)
        {
            // Create an object from the JSON data.
            SystemUptime item = JsonConvert.DeserializeObject<SystemUptime>(json);

            // Get the start and finish times for the data.
            int start = (item.Start.Hour * 60) + item.Start.Minute;
            int finish = (item.Finish.Hour * 60) + item.Finish.Minute;

            // Mark the DayReport Minutes as on-line if up.
            for (int i = start; i < finish; i++)
            {
                dayReport.Minutes[i].Up = true;
            }

            // Process the active applications.
            foreach (ActiveApplication next in item.ActiveApplications)
            {
                // Get the index for the minute.
                int minute = (next.Time.Hour * 60) + next.Time.Minute;

                // Trim the application data.
                if (next.Application is object)
                {
                    if (next.Application == "Unknown")
                    {
                        dayReport.Minutes[minute].ActiveApplication = "Unknown";
                    }
                    else
                    {
                        if ((next.Application.Length >= 34) && (next.Application.Substring(0, 34) == "System.Diagnostics.ProcessModule ("))
                        {
                            dayReport.Minutes[minute].ActiveApplication = next.Application.Substring(34);
                            dayReport.Minutes[minute].ActiveApplication = dayReport.Minutes[minute].ActiveApplication.Substring(0, dayReport.Minutes[minute].ActiveApplication.Length - 1);
                        }
                        else
                        {
                            dayReport.Minutes[minute].ActiveApplication = next.Application;
                        }
                    }
                }

                // Rename the more common programs and add to the minute.
                switch (dayReport.Minutes[minute].ActiveApplication.ToLower())
                {
                    case "cmd.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Command Prompt";
                        break;

                    case "devenv.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Visual Studio";
                        break;

                    case "explorer.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Explorer";
                        break;

                    case "msedge.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Edge Browser";
                        break;

                    case "outlook.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Outlook";
                        break;

                    case "winword.exe":
                        dayReport.Minutes[minute].ActiveApplication = "Word";
                        break;

                    default:

                        if (dayReport.Minutes[minute].ActiveApplication.Substring(dayReport.Minutes[minute].ActiveApplication.Length - 4).ToLower() == ".exe")
                        {
                            dayReport.Minutes[minute].ActiveApplication = dayReport.Minutes[minute].ActiveApplication.Substring(0, dayReport.Minutes[minute].ActiveApplication.Length - 4);
                        }

                        break;
                }

                // Add the title to the minute.
                dayReport.Minutes[minute].ActiveApplicationTitle = next.Title;
            }
        }

        /// <summary>
        /// Process the system idle data.
        /// </summary>
        /// <param name="json">JSON to be parsed.</param>
        private void ProcessSystemIdle(string json)
        {
            // Get object from the JSON data.
            SystemIdle item = JsonConvert.DeserializeObject<SystemIdle>(json);

            // Get the start and finish times.
            int start = (item.Start.Hour * 60) + item.Start.Minute;
            int finish = (item.Finish.Hour * 60) + item.Finish.Minute;

            // Fill in the minutes between the start and finish times.
            for (int i = start; i < finish; i++)
            {
                dayReport.Minutes[i].Idle = true;
            }
        }

        private bool CheckNotIdle(string json)
        {
            WorkItem workItem = JsonConvert.DeserializeObject<WorkItem>(json);
            int start = (workItem.Start.Hour * 60) + workItem.Start.Minute;
            int finish = (workItem.Finish.Hour * 60) + workItem.Finish.Minute;

            // Check if item is all idle.
            for (int i = start; i < finish; i++)
            {
                if (dayReport.Minutes[i].Idle == false)
                {
                    return true;
                }
            }

            Log.Information("Found All Idle: " + workItem.Start);
            return false;
        }

        /// <summary>
        /// Process the Work Item data.
        /// </summary>
        /// <param name="json">JSON to be parsed.</param>
        private void ProcessWorkItem(string json)
        {
            WorkItem workItem = JsonConvert.DeserializeObject<WorkItem>(json);
            int start = (workItem.Start.Hour * 60) + workItem.Start.Minute;
            int finish = (workItem.Finish.Hour * 60) + workItem.Finish.Minute;

            for (int i = start; i < finish; i++)
            {
                switch (workItem.Application)
                {
                    case ApplicationType.VisualStudioRead:
                        dayReport.Minutes[i].Billable = false;
                        break;

                    case ApplicationType.VisualStudioWrite:
                        dayReport.Minutes[i].Billable = true;
                        break;

                    case ApplicationType.WordWrite:
                        dayReport.Minutes[i].Billable = true;
                        break;

                    case ApplicationType.WordRead:
                        dayReport.Minutes[i].Billable = false;
                        break;

                    case ApplicationType.ExcelWrite:
                        dayReport.Minutes[i].Billable = true;
                        break;

                    case ApplicationType.ExcelRead:
                        dayReport.Minutes[i].Billable = false;
                        break;

                    case ApplicationType.AutocadWrite:
                        dayReport.Minutes[i].Billable = true;
                        break;

                    case ApplicationType.AutocadRead:
                        dayReport.Minutes[i].Billable = true;
                        break;
                }

                if (dayReport.Minutes[i].PrimaryWorkItem is object)
                {
                    if (workItem.WorkType.Index != 0)
                    {
                        if (workItem.WorkType.Index <= dayReport.Minutes[i].PrimaryWorkItem.WorkType.Index)
                        {
                            dayReport.Minutes[i].PrimaryWorkItem = workItem;
                        }
                    }
                }
                else
                {
                    dayReport.Minutes[i].PrimaryWorkItem = workItem;
                }
            }
        }

        /// <summary>
        /// Process the Visual Studio data.
        /// </summary>
        /// <param name="json">JSON to be parsed.</param>
        private void ProcessVisualStudio(string json)
        {
            WorkItem workItem = JsonConvert.DeserializeObject<WorkItem>(json);

            int start = (workItem.Start.Hour * 60) + workItem.Start.Minute;
            int finish = (workItem.Finish.Hour * 60) + workItem.Finish.Minute;

            for (int i = start; i < finish; i++)
            {
                if (workItem.Application == ApplicationType.VisualStudioWrite)
                {
                    dayReport.Minutes[i].Billable = true;
                }

                if (dayReport.Minutes[i].PrimaryWorkItem is object)
                {
                    if (workItem.WorkType.Index != 0)
                    {
                        if (workItem.WorkType.Index <= dayReport.Minutes[i].PrimaryWorkItem.WorkType.Index)
                        {
                            dayReport.Minutes[i].PrimaryWorkItem = workItem;
                        }
                    }
                }
                else
                {
                    dayReport.Minutes[i].PrimaryWorkItem = workItem;
                }
            }
        }

        /// <summary>
        /// Get the appointments within the timespan.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The finish time.</param>
        /// <returns>A collection of outlook items that match the filter.</returns>
        private Outlook.Items GetAppointmentsWithinRange(Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] >= '"
                + startTime.ToString("g")
                + "' AND [End] <= '"
                + endTime.ToString("g") + "'";

            try
            {
                Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get the appointments that fall in the range of the timespan.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The finish time.</param>
        /// <returns>A collection of outlook items that match the filter.</returns>
        private Outlook.Items GetAppointmentsInRange(Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] <= '"
                + startTime.ToString("g")
                + "' AND [End] >= '"
                + endTime.ToString("g") + "'";

            try
            {
                Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}