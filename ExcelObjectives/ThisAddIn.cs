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
    /// Excel VSTO AddIn to track document times.</br>
    /// </summary>
    public partial class ThisAddIn
    {
        // Dictionary to hold the document data collected.
        private Dictionary<string, WorkItem> WorkItems = new Dictionary<string, WorkItem>();

        // Path to the root folder of where the Objectives are stored.
        private static string RootFolder;

        // Path to where the output files should be stored.
        private static string StorageFolder;

        // Fields to manage the main timer.
        private TimerCallback timerDelegate;
        private TimeSpan refreshIntervalTime;
        private Timer refreshTimer;

        /// <summary>
        /// The startup event for the AddIn.</br>
        /// WARNING: This may not start before documents are opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            Globals.ThisAddIn.Application.WorkbookDeactivate += Application_WorkbookDeactivate;
            Globals.ThisAddIn.Application.WorkbookActivate += Application_WorkbookActivate;
            Globals.ThisAddIn.Application.WorkbookOpen += Application_WorkbookOpen;
            Globals.ThisAddIn.Application.WorkbookBeforeClose += Application_WorkbookBeforeClose;

            timerDelegate = new TimerCallback(refreshTimer_Tick);
            refreshIntervalTime = new TimeSpan(0, 0, 0, 50, 1000);
            refreshTimer = new Timer(timerDelegate, null, TimeSpan.Zero, refreshIntervalTime);

            // Get and check the ObjectiveRootFolder.
            RootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", "");
            StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");

            // This add-in starts after the first document is loaded so check for loaded documents.
            if (this.Application.Workbooks.Count > 0)
            {
                foreach (Excel.Workbook workbook in Application.Workbooks)
                {
                    AddWorkbook(workbook);
                }
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_WorkbookDeactivate(Excel.Workbook workbook)
        {
            Log.Info("Application_WorkbookDeactivate() " + workbook.FullName);
        }

        private void Application_WorkbookActivate(Excel.Workbook workbook)
        {
            Log.Info("Application_WorkbookActivate() " + workbook.FullName);
        }

        private void Application_WorkbookBeforeClose(Excel.Workbook workbook, ref bool Cancel)
        {
            RemoveWorkbook(workbook);
        }

        private void Application_WorkbookOpen(Excel.Workbook workbook)
        {
            AddWorkbook(workbook);
        }

        private void refreshTimer_Tick(Object stateInfo)
        {
            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                foreach (WorkItem wordSession in WorkItems.Values)
                {
                    SaveData(wordSession);
                }
            }
        }

        private void AddWorkbook(Excel.Workbook workbook)
        {
            Log.Info("AddWorkbook " + workbook.FullName);

            if (WorkItems.ContainsKey(workbook.FullName))
            {
                Log.Info("Workbooks already contains key " + workbook.FullName);
            }
            else
            {
                WorkItem workItem = new WorkItem();
                workItem.Id = Guid.NewGuid();
                workItem.FilePath = workbook.FullName;
                workItem.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

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

        private void RemoveWorkbook(Excel.Workbook workbook)
        {
            Log.Info("RemoveWorkbook " + workbook.FullName);

            if (WorkItems.ContainsKey(workbook.FullName))
            {
                SaveData(WorkItems[workbook.FullName]);
                WorkItems.Remove(workbook.FullName);
                Log.Info("Removed workbook " + workbook.FullName);
            }
            else
            {
                Log.Info("Workbooks does not contains key " + workbook.FullName);
            }
        }

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
                    if (workItem.StartSize != workItem.FinishSize)
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

        #endregion
    }
}
