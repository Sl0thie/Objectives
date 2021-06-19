namespace ExcelObjectives
{
    using System;
    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Threading;
    using System.IO;
    using Newtonsoft.Json;
    using CommonObjectives;
    using LogNET;

    /// <summary>
    /// Excel VSTO AddIn to track document times.
    /// </summary>
    public partial class ThisAddIn
    {
        // TODO Handle workbooks being renamed.

        // Dictionary to hold the document data collected.
        private readonly Dictionary<string, WorkItem> WorkItems = new Dictionary<string, WorkItem>();

        // Path to the root folder of where the Objectives are stored.
        private static string RootFolder;

        // Path to where the output files should be stored.
        private static string StorageFolder;

        // Fields to manage the main timer.
        private TimerCallback timerDelegate;
        private TimeSpan refreshIntervalTime;
        private Timer refreshTimer;

        /// <summary>
        /// The startup event for the AddIn.
        /// WARNING: This may not start before documents are opened.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            Globals.ThisAddIn.Application.WorkbookDeactivate += Application_WorkbookDeactivate;
            Globals.ThisAddIn.Application.WorkbookActivate += Application_WorkbookActivate;
            Globals.ThisAddIn.Application.WorkbookOpen += Application_WorkbookOpen;
            Globals.ThisAddIn.Application.WorkbookBeforeClose += Application_WorkbookBeforeClose;

            timerDelegate = new TimerCallback(RefreshTimer_Tick);
            refreshIntervalTime = new TimeSpan(0, 0, 0, 50, 1000);
            refreshTimer = new Timer(timerDelegate, null, TimeSpan.Zero, refreshIntervalTime);

            // Get and check the ObjectiveRootFolder.
            RootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", "");
            StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");

            // This add-in starts after the first document is loaded so check for loaded documents.
            CheckWorkbooks();
        }

        /// <summary>
        /// Event handler for when the workbook is deactivated.
        /// Not currently implemented.
        /// </summary>
        /// <param name="workbook"></param>
        private void Application_WorkbookDeactivate(Excel.Workbook workbook)
        {
            Log.Info(workbook.FullName);
        }

        /// <summary>
        /// Event handler for when the workbook is activated.
        /// Not currently implemented.
        /// </summary>
        /// <param name="workbook"></param>
        private void Application_WorkbookActivate(Excel.Workbook workbook)
        {
            Log.Info(workbook.FullName);
        }

        /// <summary>
        /// Event handler for when the workbook is closed.
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="Cancel"></param>
        private void Application_WorkbookBeforeClose(Excel.Workbook workbook, ref bool Cancel)
        {
            Log.Info(workbook.FullName);
            RemoveWorkbook(workbook.FullName);
        }

        /// <summary>
        /// Event handler for when the workbook is opened.
        /// </summary>
        /// <param name="workbook"></param>
        private void Application_WorkbookOpen(Excel.Workbook workbook)
        {
            Log.Info(workbook.FullName);
            AddWorkbook(workbook);
        }

        /// <summary>
        /// Check the workbooks against the WorkItems.
        /// </summary>
        /// <remarks>
        /// Testing the events seems to exposed some faults. 
        /// To accommodate this the method first checks all workbooks against the work items.
        /// Then it checks all the work items against the workbooks.
        /// A secondary function is that it checks if the workbooks have been active.
        /// </remarks>
        private void CheckWorkbooks()
        {
            // Check if workbooks have work items.
            foreach (Excel.Workbook workbook in Application.Workbooks)
            {
                bool found = false;
                foreach (WorkItem workItem in WorkItems.Values)
                {
                    if (workItem.FilePath == workbook.FullName)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    AddWorkbook(workbook);
                }
            }

            // All workbooks have a work item. Now check if all work items have a workbook.
            foreach (WorkItem workItem in WorkItems.Values)
            {
                bool found = false;
                foreach (Excel.Workbook workbook in Application.Workbooks)
                {
                    if (workItem.FilePath == workbook.FullName)
                    {
                        found = true;
                        // Also check if the workbook is saved.
                        if (!workbook.Saved)
                        {
                            workItem.IsActive = true;
                        }
                        break;
                    }
                }

                if (!found)
                {
                    RemoveWorkbook(workItem.FilePath);
                }
            }
        }

        private void RefreshTimer_Tick(Object stateInfo)
        {
            CheckWorkbooks();

            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                foreach (WorkItem workItem in WorkItems.Values)
                {
                    SaveData(workItem);
                }
            }
        }

        /// <summary>
        /// Adds a workbook to the dictionary.
        /// </summary>
        /// <param name="workbook"></param>
        private void AddWorkbook(Excel.Workbook workbook)
        {
            Log.Info("AddWorkbook " + workbook.FullName);

            if (WorkItems.ContainsKey(workbook.FullName))
            {
                Log.Info("Workbooks already contains key " + workbook.FullName);
            }
            else
            {
                WorkItem workItem = new WorkItem
                {
                    Id = Guid.NewGuid(),
                    FilePath = workbook.FullName,
                    Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"))
                };

                if (workItem.FilePath.LastIndexOf("\\") > 0)
                {
                    workItem.Name = workItem.FilePath.Substring(workItem.FilePath.LastIndexOf("\\") + 1);

                    if (workItem.Name.LastIndexOf(".") > 0)
                    {
                        workItem.Name = workItem.Name.Substring(0, (workItem.Name.LastIndexOf(".")));
                    }
                }
                else
                {
                    workItem.Name = workbook.FullName;
                }

                if (workItem.FilePath.Length > RootFolder.Length)
                {
                    if (workItem.FilePath.Substring(0, RootFolder.Length) == RootFolder)
                    {
                        workItem.ObjectiveName = workItem.FilePath.Substring(RootFolder.Length + 1);
                        workItem.ObjectiveName = workItem.ObjectiveName.Substring(0, workItem.ObjectiveName.IndexOf(@"\"));
                    }
                    else
                    {
                        workItem.ObjectiveName = "None";
                    }
                }
                else
                {
                    workItem.ObjectiveName = "None";
                }

                if (File.Exists(workItem.FilePath))
                {
                    FileInfo drawingFile = new FileInfo(workItem.FilePath);
                    workItem.StartSize = drawingFile.Length;
                }

                WorkItems.Add(workItem.FilePath, workItem);
                Log.Info("Added workbook " + workbook.FullName);
            }
        }

        
        //private void RemoveWorkbook(Excel.Workbook workbook)
        //{
        //    Log.Info("RemoveWorkbook " + workbook.FullName);

        //    if (WorkItems.ContainsKey(workbook.FullName))
        //    {
        //        SaveData(WorkItems[workbook.FullName]);
        //        WorkItems.Remove(workbook.FullName);
        //        Log.Info("Removed workbook " + workbook.FullName);
        //    }
        //    else
        //    {
        //        Log.Info("Workbooks does not contains key " + workbook.FullName);
        //    }
        //}

        /// <summary>
        /// Removes a workbook from the dictionary.
        /// </summary>
        /// <param name="path">The path to the workbook.</param>
        private void RemoveWorkbook(string path)
        { 
            Log.Info("RemoveWorkbook " + path);

            if (WorkItems.ContainsKey(path))
            {
                SaveData(WorkItems[path]);
                WorkItems.Remove(path);
                Log.Info("Removed workbook " + path);
            }
            else
            {
                Log.Info("Workbooks does not contains key " + path);
            }
        }

        /// <summary>
        /// Save the data to the storage folder.
        /// </summary>
        /// <param name="workItem"></param>
        private void SaveData(WorkItem workItem)
        {
            workItem.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (File.Exists(workItem.FilePath))
            {
                FileInfo wordFile = new FileInfo(workItem.FilePath);
                workItem.FinishSize = wordFile.Length;
            }

            try
            {
                if (workItem.Start != workItem.Finish)
                {
                    foreach (Excel.Workbook workbook in Application.Workbooks)
                    {
                        if (workItem.FilePath == workbook.FullName)
                        {
                            if (!workbook.Saved)
                            {
                                workbook.Save();
                            }
                            break;
                        }
                    }

                    if ((workItem.IsActive)||(workItem.StartSize != workItem.FinishSize))
                    {
                        workItem.Application = ApplicationType.ExcelWrite;
                    }
                    else
                    {
                        workItem.Application = ApplicationType.ExcelRead;
                    }

                    string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                    File.WriteAllText(StorageFolder + @"\" + (int)workItem.Application + "-" + workItem.Id.ToString() + ".json", json);
                    workItem.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                    workItem.IsActive = false;
                    workItem.StartSize = workItem.FinishSize;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #endregion
    }
}