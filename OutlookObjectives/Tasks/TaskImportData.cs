﻿namespace OutlookObjectives
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using CommonObjectives;
    using LogNET;

    public class TaskImportData
    {
        Action CallBack;

        public TaskImportData(Action callBack)
        {
            CallBack = callBack;
        }

        public void RunTask()
        {
            Log.Info("Starting Import XML Task.");

            Thread BackgroundThread = new Thread(new ThreadStart(BackgroundProcess));
            BackgroundThread.Name = "Objectives.TaskImportData";
            BackgroundThread.IsBackground = true;
            BackgroundThread.Priority = ThreadPriority.Normal;
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
        }

        private void BackgroundProcess()
        {
            try
            {
                Log.Info("Starting Import XML Task.");

                ReadFiles();
            }
            catch (Exception ex) { Log.Error(ex); }
            CallBack?.Invoke();
        }

        private void ReadFiles()
        {
            DirectoryInfo ImportXMLDirectory = new DirectoryInfo(InTouch.ObjectivesStorageFolder);

            foreach (FileInfo nextFile in ImportXMLDirectory.EnumerateFiles())
            {
                string json = File.ReadAllText(nextFile.FullName);
                string filename = nextFile.Name;

                switch (filename.Substring(0,1))
                {
                    case "0":

                        break;

                    case "1":
                        if(ImportVisualStudioData(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "2":
                        if (ImportSSMSData(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "3":
                        if (ImportWordData(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "4":
                        if (ImportExceloData(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "5":
                        if (ImportAutoCADData(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "6":
                        if (ImportSystemSleep(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "7":
                        if (ImportSystemIdle(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;

                    case "8":
                        if (ImportSystemUptime(json))
                        {
                            File.Delete(nextFile.FullName);
                        }
                        break;


                    default:

                        break;
                }
            }
        }

        private bool ImportSystemUptime(string json)
        {
            //try
            //{
            //    SystemUptime systemUptime = JsonConvert.DeserializeObject<SystemUptime>(json);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = systemUptime.Start;
            //    nextAppointment.End = systemUptime.Finish;
            //    nextAppointment.Subject = "System - Uptime";
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;
            //    nextAppointment.Categories = "System - Uptime";

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }

        private bool ImportSystemIdle(string json)
        {
            //try
            //{
            //    SystemIdle systemIdle = JsonConvert.DeserializeObject<SystemIdle>(json);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = systemIdle.Start;
            //    nextAppointment.End = systemIdle.Finish;
            //    nextAppointment.Subject = "System - Idle";
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;
            //    nextAppointment.Categories = "System - Idle";

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }


        private bool ImportSystemSleep(string json)
        {
            //try
            //{
            //    SystemSleep systemSleep = JsonConvert.DeserializeObject<SystemSleep>(json);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["System"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = systemSleep.Start;
            //    nextAppointment.End = systemSleep.Finish;
            //    nextAppointment.Subject = "System - Sleep";
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;
            //    nextAppointment.Categories = "System - Sleep";

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }

        private bool ImportVisualStudioData(string json)
        {
            //try
            //{
            //    SolutionSession solutionSession = JsonConvert.DeserializeObject<SolutionSession>(json);

            //    Log.Info(solutionSession.Name);
            //    Log.Info(solutionSession.ObjectiveName);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = solutionSession.Start;
            //    nextAppointment.End = solutionSession.Finish;
            //    nextAppointment.Subject = solutionSession.Name;
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;

            //    if (solutionSession.StartFileSizeTotal == solutionSession.FinishFileSizeTotal)
            //    {
            //        nextAppointment.Categories = "Visual Studio - Read Only";
            //    }
            //    else
            //    {
            //        nextAppointment.Categories = "Visual Studio";
            //    }

            //    nextAppointment.Save();
            //}
            //catch(Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }

        private bool ImportSSMSData(string json)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }

            return true;
        }

        private bool ImportWordData(string json)
        {
            //try
            //{
            //    WordSession wordSession = JsonConvert.DeserializeObject<WordSession>(json);

            //    Log.Info(wordSession.Name);
            //    Log.Info(wordSession.ObjectiveName);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = wordSession.Start;
            //    nextAppointment.End = wordSession.Finish;
            //    nextAppointment.Subject = wordSession.Name;
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;

            //    if (wordSession.StartSize == wordSession.FinishSize)
            //    {
            //        nextAppointment.Categories = "Word - Read Only";
            //    }
            //    else
            //    {
            //        nextAppointment.Categories = "Word";
            //    }

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }

        private bool ImportExceloData(string json)
        {
            //try
            //{
            //    ExcelSession excelSession = JsonConvert.DeserializeObject<ExcelSession>(json);

            //    Log.Info(excelSession.Name);
            //    Log.Info(excelSession.ObjectiveName);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = excelSession.Start;
            //    nextAppointment.End = excelSession.Finish;
            //    nextAppointment.Subject = excelSession.Name;
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;

            //    if (excelSession.StartSize == excelSession.FinishSize)
            //    {
            //        nextAppointment.Categories = "Excel - Read Only";
            //    }
            //    else
            //    {
            //        nextAppointment.Categories = "Excel";
            //    }

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }

        private bool ImportAutoCADData(string json)
        {
            //try
            //{
            //    DrawingSession drawingSession = JsonConvert.DeserializeObject<DrawingSession>(json);

            //    Log.Info(drawingSession.Name);
            //    Log.Info(drawingSession.ObjectiveName);

            //    Outlook.Folder SolutionsCalendarFolder = Globals.ThisAddIn.Application.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Folders["Objectives"] as Outlook.Folder;
            //    Outlook.AppointmentItem nextAppointment = SolutionsCalendarFolder.Items.Add(Outlook.OlItemType.olAppointmentItem);

            //    nextAppointment.Start = drawingSession.Start;
            //    nextAppointment.End = drawingSession.Finish;
            //    nextAppointment.Subject = drawingSession.Name;
            //    nextAppointment.Body = json;
            //    nextAppointment.AllDayEvent = false;
            //    nextAppointment.ReminderSet = false;

            //    if (drawingSession.StartSize == drawingSession.FinishSize)
            //    {
            //        nextAppointment.Categories = "AutoCAD - Read Only";
            //    }
            //    else
            //    {
            //        nextAppointment.Categories = "AutoCAD";
            //    }

            //    nextAppointment.Save();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //    return false;
            //}

            return true;
        }
    }
}
