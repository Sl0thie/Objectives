﻿namespace OutlookObjectives
{
    using System;
    using System.Linq;
    using System.Threading;
    using CommonObjectives;
    using Serilog;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Task to process weekly totals.
    /// </summary>
    public class TaskWeekReport
    {
        private readonly Action callBack;
        private readonly WeekReport weekReport = new WeekReport();
        private readonly DateTime firstDay = new DateTime(2021, 5, 25);

        // Get references to the Outlook Calendars.
        private readonly Outlook.Folder calendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
        private readonly DayReport[] dayReports = new DayReport[7];
        private DateTime day;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskWeekReport"/> class.
        /// </summary>
        /// <param name="callBack">The action to call when finished.</param>
        public TaskWeekReport(Action callBack)
        {
            this.callBack = callBack;
        }

        /// <summary>
        /// Method to start the process.
        /// </summary>
        public void RunTask()
        {
            Thread backgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskWeekReport",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
            };
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();
        }

        /// <summary>
        /// Method to start in the background.
        /// </summary>
        private void BackgroundProcess()
        {
            day = FindDay();
            if (day != DateTime.MinValue)
            {
                day = day.AddDays(1);
                if (GetDays())
                {
                    Log.Information("Processing Week :" + day.ToString());

                    GetWorkItemFromDays();
                    CreateHTML();
                    CreateAppointment();
                }
                else
                {
                    Log.Information("Cannot find Full Week.");
                }
            }
            else
            {
                Log.Information("No Week found to process.");
            }

            callBack?.Invoke();
        }

        /// <summary>
        /// Find the day that is suitable to create the report for.
        /// </summary>
        /// <returns>The date that is found.</returns>
        private DateTime FindDay()
        {
            DateTime returnValue = DateTime.Parse(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString(@"yyyy-MM-dd 00:00"));
            bool keepLooking = true;

            while (keepLooking)
            {
                if (returnValue.DayOfWeek == DayOfWeek.Sunday)
                {
                    keepLooking = false;
                    Outlook.Items billingItems = GetAppointmentsInRange(calendar, returnValue, returnValue.AddDays(1));
                    foreach (Outlook.AppointmentItem nextItem in billingItems)
                    {
                        if (nextItem.Categories == "Objectives - Week Report")
                        {
                            keepLooking = true;
                            break;
                        }
                    }
                }

                if (returnValue < firstDay)
                {
                    return DateTime.MinValue;
                }

                returnValue = returnValue.AddDays(-1);
            }

            return returnValue;
        }

        /// <summary>
        /// Get the DayReports for the week.
        /// </summary>
        /// <returns>A value indicating success.</returns>
        private bool GetDays()
        {
            bool rv = true;

            for (int i = 0; i < 7; i++)
            {
                Outlook.Items billingItems = GetAppointmentsInRange(calendar, day.AddDays(0 - i), day.AddDays(1 - i));
                foreach (Outlook.AppointmentItem nextItem in billingItems)
                {
                    if (nextItem.Categories == "Objectives - Day Report")
                    {
                        dayReports[i] = JsonConvert.DeserializeObject<DayReport>(nextItem.Body);
                        Log.Information("Day " + i.ToString() + " " + dayReports[i].Day.ToString());
                        break;
                    }
                }
            }

            for (int i = 0; i < 7; i++)
            {
                if (dayReports[i] is null)
                {
                    rv = false;
                }
            }

            return rv;
        }

        /// <summary>
        /// Get all the work items from the days.
        /// </summary>
        private void GetWorkItemFromDays()
        {
            for (int i = 0; i < 7; i++)
            {
                // Loop though the work items.
                foreach (System.Collections.Generic.KeyValuePair<string, WorkItem> next in dayReports[i].WorkItems.OrderBy(x => x.Value.ObjectiveName).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkType.Index))
                {
                    weekReport.WorkItems.Add(dayReports[i].Day.ToString("yyyy-MM-dd") + next.Value.ObjectiveName + next.Value.Name + next.Value.WorkType.Index, next.Value);
                }
            }
        }

        /// <summary>
        /// Creates the HTML for the report.
        /// </summary>
        private void CreateHTML()
        {
            string rv = "<!DOCTYPE HTML>" + "\n";
            rv += "<html>" + "\n";
            rv += "<head>" + "\n";
            rv += "<title>Week Report</title>" + "\n";
            rv += "<link rel=\"stylesheet\" href=\"[[[TEMPDIRECTORY]]]page.css\" />" + "\n";
            rv += "</head>" + "\n";
            rv += "<body>" + "\n";
            rv += "<div class=\"divWholePage\">" + "\n";
            rv += "<h1>Week Report for " + dayReports[6].Day.ToString("dddd d/MM/yyyy") + " " + dayReports[0].Day.ToString("dddd d/MM/yyyy") + "</h1>" + "\n";

            rv += "<h2>Objectives Totals</h2>" + "\n";
            rv += "<table width=\"100%\">" + "\n";

            foreach (System.Collections.Generic.KeyValuePair<string, WorkItem> next in weekReport.WorkItems.OrderBy(x => x.Value.ObjectiveName).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkType.Index))
            {
                rv += "<tr>" + "\n";
                rv += "<td style=\"max-height:18px;\">" + next.Value.ObjectiveName + "</td>\n";
                rv += "<td style=\"max-height:18px;\">" + next.Value.Name + "</td>\n";
                rv += "<td style=\"max-height:18px;text-align:right;\">" + InTouch.GetTimeStringFromMinutes(next.Value.Minutes) + "</td>\n";
                rv += "<td style=\"max-height:18px;text-align:right;\">$" + next.Value.Cost.ToString("0.00") + "</td>\n";
                rv += "</tr>" + "\n";
            }

            rv += "</table>" + "\n";

            rv += "</div>" + "\n";
            rv += "</body>" + "\n";
            rv += "</html>" + "\n";

            weekReport.HTML = rv;
        }

        private void CreateAppointment()
        {
            // Create the DayReport appointment and add the images as attachments.
            Outlook.AppointmentItem newAppointmentItem = (Outlook.AppointmentItem)calendar.Items.Add(Outlook.OlItemType.olAppointmentItem);
            newAppointmentItem.Subject = "Week Report";
            newAppointmentItem.Categories = "Objectives - Week Report";
            newAppointmentItem.Start = day;
            newAppointmentItem.AllDayEvent = true;
            newAppointmentItem.ReminderSet = false;
            newAppointmentItem.Body = JsonConvert.SerializeObject(weekReport, Formatting.Indented);
            newAppointmentItem.Save();
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