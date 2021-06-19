namespace OutlookObjectives
{
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Day Report Task to generate Objectives Day Reports.
    /// </summary>
    public class TaskConvertVersion
    {
        private readonly Action CallBack;
        private readonly DayReport dayReport = new DayReport();
        private readonly DateTime finishDay = new DateTime(2021, 3, 15);
        private readonly DateTime startDay = new DateTime(2021, 6, 17);
        private DateTime day;

        // Get references to the Outlook Calendars. 
        readonly Outlook.Folder calendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
        readonly Outlook.Folder system = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;


        /// <summary>
        /// Returns control back to the TaskManager.
        /// </summary>
        /// <param name="callBack"></param>
        public TaskConvertVersion(Action callBack)
        {
            CallBack = callBack;
        }

        /// <summary>
        /// Creates a thread to run the Task.
        /// </summary>
        public void RunTask()
        {
            Thread BackgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskDayReport",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
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

            CallBack?.Invoke();
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


            foreach (var appointment in appointments)
            {
                Outlook.AppointmentItem next = (Outlook.AppointmentItem)appointment;

                switch (next.Categories)
                {
                    case "Visual Studio":

                        Outlook.UserProperty CustomProperty = next.UserProperties.Find("WorkItemVersion");
                        if (CustomProperty is null)
                        {
                            Log.Info("No WorkItemVersion - Processing " + next.Subject + " " + next.Start.ToString());
                            ProcessVisualStudio(next);
                        }
                        else
                        {
                            if (CustomProperty.Value == 5)
                            {
                                Log.Info("Found WorkItemVersion - Skipping " + next.Subject + " " + next.Start.ToString());
                            }
                            else
                            {
                                Log.Info("Wrong WorkItemVersion - Error " + next.Subject + " " + next.Start.ToString());
                                //ProcessVisualStudio(next);
                            }
                        }

                        if (CustomProperty != null) Marshal.ReleaseComObject(CustomProperty);

                        break;

                    case "Visual Studio - Read Only":
                        ProcessVisualStudio(next);
                        break;

                    case "Visual Studio - Review":
                        Outlook.UserProperty CustomProperty2 = next.UserProperties.Find("WorkItemVersion");
                        if (CustomProperty2 is null)
                        {
                            Log.Info("No WorkItemVersion - Error " + next.Subject + " " + next.Start.ToString());
                            ProcessVisualStudio(next);

                        }
                        else
                        {
                            if (CustomProperty2.Value == 5)
                            {
                                Log.Info("Found WorkItemVersion - Ok " + next.Subject + " " + next.Start.ToString());
                            }
                            else
                            {
                                Log.Info("Wrong WorkItemVersion - Error " + CustomProperty2.Value + " " + next.Subject + " " + next.Start.ToString());
                            }
                        }

                        if (CustomProperty2 != null) Marshal.ReleaseComObject(CustomProperty2);
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
                    FilePath = item.SolutionFileName
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
                appointment.UserProperties.Add("Application", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["Application"].Value = (int)workItem.Application;
                appointment.UserProperties.Add("WorkTypeIndex", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["WorkTypeIndex"].Value = (int)workItem.WorkType.Index;
                appointment.UserProperties.Add("WorkItemVersion", Outlook.OlUserPropertyType.olInteger);
                appointment.UserProperties["WorkItemVersion"].Value = InTouch.WorkItemVersion;
                appointment.Categories = workItem.WorkType.Name;

                appointment.Save();
            }
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