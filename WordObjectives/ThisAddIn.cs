namespace WordObjectives
{
    using CommonObjectives;
    using LogNET;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Word = Microsoft.Office.Interop.Word;

    /// <summary>
    /// Microsoft Word VSTO AddIn to track Objectives.
    /// </summary>
    public partial class ThisAddIn
    {
        // Dictionary to hold the document data collected.
        private Dictionary<string, WorkItem> Documents = new Dictionary<string, WorkItem>();

        // Path to the root folder of where the Objectives are stored.
        private static string RootFolder;

        // Path to where the output files should be stored.
        private static string StorageFolder;

        // Fields to manage the main timer.
        TimerCallback timerDelegate;
        TimeSpan refreshIntervalTime;
        Timer refreshTimer;

        //long StartSize = 0;
        //long FinishSize = 0;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            // Add events to monitor the documents as they are opened/closed/created/renamed.
            Globals.ThisAddIn.Application.DocumentOpen += Application_DocumentOpen;
            Globals.ThisAddIn.Application.DocumentChange += Application_DocumentChange;
            Globals.ThisAddIn.Application.DocumentBeforeClose += Application_DocumentBeforeClose;

            // Setup the main timer.
            timerDelegate = new TimerCallback(RefreshTimer_Tick);
            refreshIntervalTime = new TimeSpan(0, 0, 0, 50, 1000);
            refreshTimer = new Timer(timerDelegate, null, TimeSpan.Zero, refreshIntervalTime);

            // Get and check the ObjectiveRootFolder.
            RootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", "");
            StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");

            // This add-in starts after the first document is loaded so check for loaded documents.
            CheckDocuments();
        }

        /// <summary>
        /// Event handler to manage when documents are closed.</br>
        /// Occurs immediately before any open document closes.
        /// </summary>
        /// <seealso cref="https://docs.microsoft.com/en-us/office/vba/api/word.application.documentbeforeclose"/>
        /// <param name="Doc">The document that is closing.</param>
        /// <param name="Cancel">Bool value to cancel the closing of the document.</param>
        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            RemoveDocument(Doc.FullName);
        }

        /// <summary>
        /// Event handler for when documents change.</br>
        /// Occurs when a new document is created, when an existing document is opened, or when another document is made the active document.
        /// </summary>
        /// <seealso cref="https://docs.microsoft.com/en-us/office/vba/api/word.application.documentchange"/>
        private void Application_DocumentChange()
        {
            // Event does not fire when existing file is saved as a new file.
            CheckDocuments();
        }

        /// <summary>
        /// Event handler for when a document is opened.</br>
        /// <seealso cref="https://docs.microsoft.com/en-us/office/vba/api/word.application.documentopen"/>
        /// </summary>
        /// <param name="Doc">The document that was opened.</param>
        private void Application_DocumentOpen(Word.Document Doc)
        {
            AddDocument(Doc);
        }

        /// <summary>
        /// Check to see if documents are in the dictionary.</br>
        /// First add all documents to the dictionary.
        /// Then remove all key-pairs that are not in the document collection.
        /// </summary>
        private void CheckDocuments()
        {
            try
            {
                if (Application.Documents.Count > 0)
                {
                    // Check if documents are in dictionary. Add if not. 
                    foreach (Word.Document next in Application.Documents)
                    {
                        if (!Documents.ContainsKey(next.FullName))
                        {
                            Log.Info("Adding " + next.FullName);
                            AddDocument(next);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            try
            {
                foreach (string path in Documents.Keys.ToList())
                {
                    bool found = false;
                    foreach (Word.Document doc in Application.Documents)
                    {
                        if (doc.FullName == path)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Log.Info("Removing " + path);
                        RemoveDocument(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// The main timer event.</br>
        /// </summary>
        /// <param name="stateInfo"></param>
        private void RefreshTimer_Tick(Object stateInfo)
        {
            // Documents renamed do not seem to have an event. Check every minute.
            CheckDocuments();

            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                if (Application.Documents.Count > 0)
                {
                    // Check if documents are in dictionary. Add if not. 
                    foreach (Word.Document next in Application.Documents)
                    {
                        if (File.Exists(next.FullName))
                        {
                            next.Save();
                        }
                    }
                }

                foreach (WorkItem wordSession in Documents.Values)
                {
                    SaveData(wordSession);
                }
            }
        }

        /// <summary>
        /// Method to manage the addition of documents.</br>
        /// Documents are checked to see if they already exist. The reason for this is some office events fire more than once.
        /// The document's detail are then collected and added to the dictionary of document details.
        /// </summary>
        /// <param name="doc">The document to add to the dictionary.</param>
        private void AddDocument(Word.Document doc)
        {
            Log.Info(doc.FullName);

            if (Documents.ContainsKey(doc.FullName))
            {
                Log.Info("Documents already contains key " + doc.FullName);
            }
            else
            {
                WorkItem workItem = new WorkItem();
                workItem.FilePath = doc.FullName;
                workItem.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                //FileInfo fileInfo = new FileInfo(doc.FullName);
                //workItem.StartSize = fileInfo.Length;

                if (workItem.FilePath.LastIndexOf("\\") > 0)
                {
                    workItem.Name = workItem.FilePath.Substring(workItem.FilePath.LastIndexOf("\\") + 1);

                    if (workItem.Name.LastIndexOf(".") > 0)
                    {
                        workItem.Name = workItem.Name.Substring(0, (workItem.Name.LastIndexOf(".")));
                    }
                }

                if (workItem.FilePath.Substring(0, RootFolder.Length) == RootFolder)
                {
                    workItem.ObjectiveName = workItem.FilePath.Substring(RootFolder.Length + 1);
                    workItem.ObjectiveName = workItem.ObjectiveName.Substring(0, workItem.ObjectiveName.IndexOf(@"\"));
                }
                else
                {
                    workItem.ObjectiveName = "None";
                }

                if (File.Exists(workItem.FilePath))
                {
                    FileInfo fileInf = new FileInfo(workItem.FilePath);
                    workItem.StartSize = fileInf.Length;
                }

                Documents.Add(workItem.FilePath, workItem);
                Log.Info("Added document " + doc.FullName);
            }
        }

        /// <summary>
        /// Method to remove documents from the collection.</br>
        /// </summary>
        /// <param name="doc">The document to remove from the dictionary.</param>
        private void RemoveDocumentOld(Word.Document doc)
        {
            Log.Info(doc.FullName);

            if (Documents.ContainsKey(doc.FullName))
            {


                SaveData(Documents[doc.FullName]);
                Documents.Remove(doc.FullName);
                Log.Info("Removed document " + doc.FullName);
            }
            else
            {
                Log.Info("Documents does not contains key " + doc.FullName);
            }
        }

        /// <summary>
        /// Method to remove documents from the collection.</br>
        /// </summary>
        /// <param name="doc">The document to remove from the dictionary.</param>
        private void RemoveDocument(string path)
        {
            Log.Info(path);

            if (Documents.ContainsKey(path))
            {
                SaveData(Documents[path]);
                Documents.Remove(path);
                Log.Info("Removed document " + path);
            }
            else
            {
                Log.Info("Documents does not contains key " + path);
            }
        }

        /// <summary>
        /// Method to save the data to a json file in the storage folder.</br>
        /// </summary>
        /// <param name="workItem">A WordSession object to save to file.</param>
        private void SaveData(WorkItem workItem)
        {
            workItem.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));

            if (File.Exists(workItem.FilePath))
            {
                FileInfo wordFile = new FileInfo(workItem.FilePath);
                workItem.FinishSize = wordFile.Length;
            }

            Log.Info("SaveData has fired. Path = " + workItem.FilePath + " " + workItem.Start + " " + workItem.Finish);

            try
            {
                if (workItem.Start != workItem.Finish)
                {
                    if (workItem.StartSize != workItem.FinishSize)
                    {
                        workItem.Application = ApplicationType.WordWrite;
                    }
                    else
                    {
                        workItem.Application = ApplicationType.WordRead;
                    }

                    string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                    File.WriteAllText(StorageFolder + @"\" + (int)ApplicationType.Word + "-" + Guid.NewGuid().ToString() + ".json", json);
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
        }

        #endregion
    }
}