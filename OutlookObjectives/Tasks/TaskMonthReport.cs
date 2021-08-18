﻿namespace OutlookObjectives
{
    using System;
    using System.Threading;
    using CommonObjectives;
    using LogNET;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Task to process Monthly totals.
    /// </summary>
    public class TaskMonthReport
    {
        private readonly Action CallBack;
        private readonly MonthReport monthReport = new MonthReport();
        private readonly DateTime firstDay = new DateTime(2021, 5, 25);
        private DateTime day;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskMonthReport"/> class.
        /// </summary>
        /// <param name="callBack">The action to call when finished.</param>
        public TaskMonthReport(Action callBack)
        {
            CallBack = callBack;
        }

        /// <summary>
        /// Method to start the task.
        /// </summary>
        public void RunTask()
        {
            Thread BackgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskMonthReport",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
            };
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
        }

        /// <summary>
        /// Method to perform in the background.
        /// </summary>
        private void BackgroundProcess()
        {
            day = FindDay();
            if (day != DateTime.MinValue)
            {
                day = day.AddDays(-1);
                Log.Info("Processing Month :" + day.ToString());
            }
            else
            {
                Log.Info("No Month found to process.");
            }

            CallBack?.Invoke();
        }

        /// <summary>
        /// Find the day that is suitable to create the report for.
        /// </summary>
        /// <returns></returns>
        private DateTime FindDay()
        {
            Outlook.Folder ObjectivesCalendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
            DateTime returnValue = DateTime.Parse(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString(@"yyyy-MM-dd 00:00"));
            bool keepLooking = true;

            while (keepLooking)
            {
                Log.Info("Keep Looking: " + returnValue.ToString());
                if (returnValue.Day == 1)
                {
                    Log.Info("Checking Day: " + returnValue.ToString());
                    keepLooking = false;

                    Outlook.Items billingItems = GetAppointmentsInRange(ObjectivesCalendar, returnValue, returnValue.AddDays(1));
                    foreach (Outlook.AppointmentItem nextItem in billingItems)
                    {
                        if (nextItem.Categories == "Objectives - Month Report")
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
            catch
            {
                return null;
            }
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
            catch
            {
                return null;
            }
        }
    }
}
