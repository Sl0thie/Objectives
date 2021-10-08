namespace OutlookObjectives
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Day Report Task to generate Objectives Day Reports.
    /// </summary>
    public class TaskConvertVersion
    {
        private readonly Action callBack;
        private readonly DayReport dayReport = new DayReport();
        private readonly DateTime finishDay = new DateTime(2021, 3, 15);
        private readonly DateTime startDay = new DateTime(2021, 6, 17);

        // Get references to the Outlook Calendars.
        private readonly Outlook.Folder calendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
        private readonly Outlook.Folder system = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;

        private DateTime day;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskConvertVersion"/> class.
        /// </summary>
        /// <param name="callBack">The callback to return.</param>
        public TaskConvertVersion(Action callBack)
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
            bool keepLooking = true;
            day = startDay;

            while (keepLooking)
            {
                Log.Info("Processing Day: " + day.ToString());
                ProcessAppointments();

                if (day <= finishDay)
                {
                    keepLooking = false;
                }

                day = day.AddDays(-1);
                Thread.Sleep(10000);
            }

            callBack?.Invoke();
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

            // Find all the appointment items within the start and finish times from the Objectives Calendar.
            Outlook.Items appointments = GetAppointmentsWithinRange(calendar, start, finsh);

            foreach (object appointment in appointments)
            {
                Outlook.AppointmentItem next = (Outlook.AppointmentItem)appointment;

                switch (next.Categories)
                {
                    case "Visual Studio":

                        Outlook.UserProperty customProperty = next.UserProperties.Find("WorkItemVersion");
                        if (customProperty is null)
                        {
                            Log.Info("No WorkItemVersion - Processing " + next.Subject + " " + next.Start.ToString());
                            ProcessVisualStudio(next);
                        }
                        else
                        {
                            if (customProperty.Value == 5)
                            {
                                Log.Info("Found WorkItemVersion - Skipping " + next.Subject + " " + next.Start.ToString());
                            }
                            else
                            {
                                Log.Info("Wrong WorkItemVersion - Error " + next.Subject + " " + next.Start.ToString());
                            }
                        }

                        if (customProperty != null)
                        {
                            _ = Marshal.ReleaseComObject(customProperty);
                        }

                        break;

                    case "Visual Studio - Read Only":
                        ProcessVisualStudio(next);
                        break;

                    case "Visual Studio - Review":
                        Outlook.UserProperty customProperty2 = next.UserProperties.Find("WorkItemVersion");
                        if (customProperty2 is null)
                        {
                            Log.Info("No WorkItemVersion - Error " + next.Subject + " " + next.Start.ToString());
                            ProcessVisualStudio(next);
                        }
                        else
                        {
                            if (customProperty2.Value == 5)
                            {
                                Log.Info("Found WorkItemVersion - Ok " + next.Subject + " " + next.Start.ToString());
                            }
                            else
                            {
                                Log.Info("Wrong WorkItemVersion - Error " + customProperty2.Value + " " + next.Subject + " " + next.Start.ToString());
                            }
                        }

                        if (customProperty2 != null)
                        {
                            _ = Marshal.ReleaseComObject(customProperty2);
                        }

                        break;

                    default:
                        Log.Info("Unmanaged Category : " + next.Categories);
                        break;
                }
            }
        }

        private void ProcessVisualStudio(Outlook.AppointmentItem appointment)
        {
            SolutionSession item = null;

            try
            {
                item = JsonConvert.DeserializeObject<SolutionSession>(appointment.Body);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            if (item is object)
            {
                Log.Info(item.Name);

                WorkItem workItem = new WorkItem(item.Name)
                {
                    ObjectiveName = item.ObjectiveName,
                    Start = item.Start,
                    Finish = item.Finish,
                    FilePath = item.SolutionFileName,
                };

                if ((item.StartFileCountTotal != item.FinishFileCountTotal) || (item.StartFileSizeTotal != item.FinishFileSizeTotal))
                {
                    workItem.Application = ApplicationType.VisualStudioWrite;
                }
                else
                {
                    workItem.Application = ApplicationType.VisualStudioRead;
                }

                Objective obj = InTouch.GetObjective(InTouch.ObjectivesRootFolder + "\\" + workItem.ObjectiveName);

                foreach (var next in obj.WorkTypes)
                {
                    if (next.Value.Application == workItem.Application)
                    {
                        workItem.WorkType = next.Value;
                        break;
                    }
                }

                if (workItem.WorkType is null)
                {
                    foreach (var next in InTouch.WorkTypes)
                    {
                        if (next.Value.Application == workItem.Application)
                        {
                            workItem.WorkType = next.Value;
                            break;
                        }
                    }
                }

                appointment.Start = workItem.Start;
                appointment.End = workItem.Finish;
                appointment.Subject = workItem.Name;
                appointment.Body = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                appointment.AllDayEvent = false;
                appointment.ReminderSet = false;
                _ = appointment.UserProperties.Add("Application", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["Application"].Value = (int)workItem.Application;
                _ = appointment.UserProperties.Add("WorkTypeIndex", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["WorkTypeIndex"].Value = (int)workItem.WorkType.Index;
                _ = appointment.UserProperties.Add("WorkItemVersion", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["WorkItemVersion"].Value = InTouch.WorkItemVersion;
                appointment.Categories = workItem.WorkType.Name;

                appointment.Save();
            }
        }

        /// <summary>
        /// Get the appointments within the timespan.
        /// </summary>
        /// <param name="folder">The folder of the appointment.</param>
        /// <param name="startTime">The start time of the appointment.</param>
        /// <param name="endTime">The finish time of the appointment.</param>
        /// <returns>A collection of outlook items that fit the filter.</returns>
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