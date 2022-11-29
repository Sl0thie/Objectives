namespace OutlookObjectives
{
    using System;
    using System.IO;
    using System.Threading;
    using CommonObjectives;
    using Serilog;
    using Newtonsoft.Json;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Processes data files in the storage folder into appointment items.
    /// </summary>
    public class TaskImportData
    {
        private readonly Action callBack;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskImportData"/> class.
        /// </summary>
        /// <param name="callBack">Callback.</param>
        public TaskImportData(Action callBack)
        {
            this.callBack = callBack;
        }

        /// <summary>
        /// Method to create and start a background thread to perform the task.
        /// </summary>
        public void RunTask()
        {
            Thread backgroundThread = new Thread(new ThreadStart(BackgroundProcess))
            {
                Name = "Objectives.TaskImportData",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
            };

            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();
        }

        /// <summary>
        /// The process to perform the data import.
        /// </summary>
        private void BackgroundProcess()
        {
            try
            {
                Log.Information("Starting import JSON data task.");
                ReadFiles();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            callBack?.Invoke();
        }

        /// <summary>
        /// This method reads all the files and converts them to JSON.
        /// </summary>
        private void ReadFiles()
        {
            DirectoryInfo importDataDirectory = new DirectoryInfo(InTouch.ObjectivesStorageFolder);

            foreach (FileInfo nextFile in importDataDirectory.EnumerateFiles())
            {
                string json = File.ReadAllText(nextFile.FullName);
                string filename = nextFile.Name;
                string id = filename.Substring(0, filename.IndexOf('-'));

                switch (id)
                {
                    case "1": // Visual Studio.
                    case "2":
                    case "3":
                    case "7": // Word.
                    case "8":
                    case "9":
                    case "10": // Excel.
                    case "11":
                    case "12":
                    case "13": // AutoCAD.
                    case "14":
                    case "15":
                        if (ImportWorkItem(json))
                        {
                            File.Delete(nextFile.FullName);
                        }

                        break;

                    case "101":
                        if (ImportSystemUptime(json))
                        {
                            File.Delete(nextFile.FullName);
                        }

                        break;

                    case "102":
                        if (ImportSystemIdle(json))
                        {
                            File.Delete(nextFile.FullName);
                        }

                        break;

                    case "103":
                        if (ImportSystemSleep(json))
                        {
                            File.Delete(nextFile.FullName);
                        }

                        break;

                    default:
                        Log.Information("Unknown Id: " + id);
                        break;
                }
            }
        }

        /// <summary>
        /// Converts the WorkItem and stores it in an appointment item.
        /// </summary>
        /// <param name="json">JSON Data containing a WorkItem.</param>
        /// <returns>A value indicating the success.</returns>
        private bool ImportWorkItem(string json)
        {
            try
            {
                WorkItem workItem = JsonConvert.DeserializeObject<WorkItem>(json);
                Objective obj = InTouch.GetObjective(InTouch.ObjectivesRootFolder + "\\" + workItem.ObjectiveName);

                foreach (System.Collections.Generic.KeyValuePair<int, WorkType> next in obj.WorkTypes)
                {
                    if (next.Value.Application == workItem.Application)
                    {
                        workItem.WorkType = next.Value;
                        break;
                    }
                }

                if (workItem.WorkType is null)
                {
                    foreach (System.Collections.Generic.KeyValuePair<int, WorkType> next in InTouch.WorkTypes)
                    {
                        if (next.Value.Application == workItem.Application)
                        {
                            workItem.WorkType = next.Value;
                            break;
                        }
                    }
                }

                Log.Information(workItem.Name);
                Log.Information(workItem.ObjectiveName);

                Outlook.Folder solutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
                Outlook.AppointmentItem nextAppointment = solutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

                nextAppointment.Start = workItem.Start;
                nextAppointment.End = workItem.Finish;
                nextAppointment.Subject = workItem.Name;
                nextAppointment.Body = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                nextAppointment.AllDayEvent = false;
                nextAppointment.ReminderSet = false;
                _ = nextAppointment.UserProperties.Add("Application", Outlook.OlUserPropertyType.olInteger);
                nextAppointment.UserProperties["Application"].Value = (int)workItem.Application;
                _ = nextAppointment.UserProperties.Add("WorkTypeIndex", Outlook.OlUserPropertyType.olInteger);
                nextAppointment.UserProperties["WorkTypeIndex"].Value = (int)workItem.WorkType.Index;
                _ = nextAppointment.UserProperties.Add("WorkItemVersion", Outlook.OlUserPropertyType.olInteger);
                nextAppointment.UserProperties["WorkItemVersion"].Value = InTouch.WorkItemVersion;

                nextAppointment.Categories = workItem.WorkType.Name;

                nextAppointment.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts the Uptime event and stores it in an appointment item.
        /// </summary>
        /// <param name="json">JSON Data containing a Uptime event.</param>
        /// <returns>A value indicating the success.</returns>
        private bool ImportSystemUptime(string json)
        {
            try
            {
                SystemUptime systemUptime = JsonConvert.DeserializeObject<SystemUptime>(json);

                Outlook.Folder solutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
                Outlook.AppointmentItem nextAppointment = solutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

                nextAppointment.Start = systemUptime.Start;
                nextAppointment.End = systemUptime.Finish;
                nextAppointment.Subject = "System - Uptime";
                nextAppointment.Body = json;
                nextAppointment.AllDayEvent = false;
                nextAppointment.ReminderSet = false;
                nextAppointment.Categories = "System - Uptime";

                nextAppointment.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts the Idle event and stores it in an appointment item.
        /// </summary>
        /// <param name="json">JSON Data containing a idle event.</param>
        /// <returns>A value indicating the success.</returns>
        private bool ImportSystemIdle(string json)
        {
            try
            {
                SystemIdle systemIdle = JsonConvert.DeserializeObject<SystemIdle>(json);

                Outlook.Folder solutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
                Outlook.AppointmentItem nextAppointment = solutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

                nextAppointment.Start = systemIdle.Start;
                nextAppointment.End = systemIdle.Finish;
                nextAppointment.Subject = "System - Idle";
                nextAppointment.Body = json;
                nextAppointment.AllDayEvent = false;
                nextAppointment.ReminderSet = false;
                nextAppointment.Categories = "System - Idle";

                nextAppointment.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts the sleep event and stores it in an appointment item.
        /// </summary>
        /// <param name="json">JSON Data containing a sleep event.</param>
        /// <returns>A value indicating the success.</returns>
        private bool ImportSystemSleep(string json)
        {
            try
            {
                SystemSleep systemSleep = JsonConvert.DeserializeObject<SystemSleep>(json);

                Outlook.Folder solutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
                Outlook.AppointmentItem nextAppointment = solutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

                nextAppointment.Start = systemSleep.Start;
                nextAppointment.End = systemSleep.Finish;
                nextAppointment.Subject = "System - Sleep";
                nextAppointment.Body = json;
                nextAppointment.AllDayEvent = false;
                nextAppointment.ReminderSet = false;
                nextAppointment.Categories = "System - Sleep";

                nextAppointment.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }
    }
}
