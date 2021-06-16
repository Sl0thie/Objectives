namespace OutlookObjectives
{
    using System;
    using System.Threading;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using CommonObjectives;
    using Newtonsoft.Json;
    using LogNET;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Linq;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// Task to process weekly totals.
    /// </summary>
    public class TaskWeekReport
    {
        private Action CallBack;
        private readonly WeekReport weekReport = new WeekReport();
        private readonly DateTime firstDay = new DateTime(2021, 5, 25);
        private DateTime day;

        // Get references to the Outlook Calendars. 
        Outlook.Folder calendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
        Outlook.Folder system = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;

        private DayReport[] dayReports = new DayReport[7];

        public TaskWeekReport(Action callBack)
        {
            CallBack = callBack;
        }

        public void RunTask()
        {
            Thread BackgroundThread = new Thread(new ThreadStart(BackgroundProcess));
            BackgroundThread.Name = "Objectives.TaskWeekReport";
            BackgroundThread.IsBackground = true;
            BackgroundThread.Priority = ThreadPriority.Normal;
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
        }

        private void BackgroundProcess()
        {
            day = FindDay();
            if (day != DateTime.MinValue)
            {
                day = day.AddDays(1);
                if (GetDays())
                {
                    Log.Info("Processing Week :" + day.ToString());

                    GetWorkItemFromDays();
                    CreateHTML();
                    CreateAppointment();
                }
                else
                {
                    Log.Info("Cannot find Full Week.");
                }
            }
            else
            {
                Log.Info("No Week found to process.");
            }

            CallBack?.Invoke();
        }

        /// <summary>
        /// Find the day that is suitable to create the report for.
        /// </summary>
        /// <returns></returns>
        private DateTime FindDay()
        {
            DateTime returnValue = DateTime.Parse(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString(@"yyyy-MM-dd 00:00"));
            bool keepLooking = true;

            while (keepLooking)
            {
                if(returnValue.DayOfWeek == DayOfWeek.Sunday)
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
        /// <returns></returns>
        private bool GetDays()
        {
            bool rv = true;

            for (int i = 0;i < 7;i++)
            {
                Outlook.Items billingItems = GetAppointmentsInRange(calendar, day.AddDays(0 - i), day.AddDays(1 - i));
                foreach (Outlook.AppointmentItem nextItem in billingItems)
                {
                    if (nextItem.Categories == "Objectives - Day Report")
                    {
                        dayReports[i] = JsonConvert.DeserializeObject<DayReport>(nextItem.Body);
                        Log.Info("Day " + i.ToString() + " " + dayReports[i].Day.ToString());
                        break;
                    }
                }
            }

            for (int i = 0; i < 7; i++)
            {
                if(dayReports[i] is null)
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
                foreach (var next in dayReports[i].WorkItems.OrderBy(x => x.Value.Objective).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkTypeIndex))
                {
                    weekReport.WorkItems.Add(dayReports[i].Day.ToString("yyyy-MM-dd") + next.Value.Objective + next.Value.Name + next.Value.WorkTypeIndex, next.Value); ;
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

            foreach (var next in weekReport.WorkItems.OrderBy(x => x.Value.Objective).ThenBy(x => x.Value.Name).ThenBy(x => x.Value.WorkTypeIndex))
            {
                rv += "<tr>" + "\n";
                rv += "<td style=\"max-height:18px;\">" + next.Value.Objective + "</td>\n";
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
            Outlook.AppointmentItem NewAppointmentItem = (Outlook.AppointmentItem)calendar.Items.Add(Outlook.OlItemType.olAppointmentItem);
            NewAppointmentItem.Subject = "Week Report";
            NewAppointmentItem.Categories = "Objectives - Week Report";
            NewAppointmentItem.Start = day;
            NewAppointmentItem.AllDayEvent = true;
            NewAppointmentItem.ReminderSet = false;
            NewAppointmentItem.Body = JsonConvert.SerializeObject(weekReport, Formatting.Indented);
            NewAppointmentItem.Save();
        }

        /// <summary>
        /// Get the appointments within the timespan.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
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
            catch { return null; }
        }

        /// <summary>
        /// Get the appointments that fall in the range of the timespan.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
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
            catch { return null; }
        }
    }
}