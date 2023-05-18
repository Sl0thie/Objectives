using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Timers;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using CommonObjectives;
using Newtonsoft.Json;

using Serilog;

[assembly: ExtensionApplication(typeof(AutoCADObjectives.ExtApp))]
[assembly: CommandClass(null)]

namespace AutoCADObjectives
{
    /// <summary>
    /// AutoCAD extension to track time spent on drawings.
    /// </summary>
    /// <remarks>
    /// Output project directly to AutoCAD's Support directory.
    /// <code>
    /// C:\Program Files\Autodesk\AutoCAD 2018\Support
    /// </code>
    /// This directory is considered secure by AutoCAD so there is no need to add the normal project output directory to AutoCAD's security.
    /// Use the command <c>NETLOAD</c> to load the DLL into AutoCAD manually.
    /// Or copy the file acad.lsp to the support directory to load the DLL automatically on startup.
    /// </remarks>
    public class ExtApp : IExtensionApplication
    {
        private readonly Dictionary<string, WorkItem> workItems = new Dictionary<string, WorkItem>();
        private readonly Timer timerUpdate = new Timer(50000);

        // TODO Check that the file path is saving the correct path.
        private string rootFolder;
        private string storageFolder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtApp"/> class.
        /// </summary>
        public ExtApp()
        {
        }

        /// <summary>
        /// Method AutoCAD calls to terminate the extension.
        /// </summary>
        /// <remarks>
        /// Not 100% sure this is called by AutoCAD yet.
        /// </remarks>
        public void Terminate()
        {
        }

        /// <summary>
        /// Method AutoCAD calls to initialize the extension.
        /// </summary>
        public void Initialize()
        {
            // Start logging for the Add-in.
            string logpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Logs");
            if (!Directory.Exists(logpath))
            {
                _ = Directory.CreateDirectory(logpath);
            }

            logpath = logpath + "\\" + MethodBase.GetCurrentMethod().DeclaringType.Namespace + " - .txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logpath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Logging Started.");

            try
            {
                // Get folder locations from the registry.
                rootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", string.Empty);
                storageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", string.Empty);

                // Setup the timer.
                timerUpdate.Elapsed += TimerUpdate_Elapsed;
                timerUpdate.Enabled = true;

                // Hook the events needed from the DocumentManager.
                DocumentCollection m_docMan = Application.DocumentManager;

                m_docMan.DocumentBecameCurrent += new DocumentCollectionEventHandler(Callback_DocumentBecameCurrent);
                m_docMan.DocumentCreated += new DocumentCollectionEventHandler(Callback_DocumentCreated);
                m_docMan.DocumentCreateStarted += new DocumentCollectionEventHandler(Callback_DocumentCreateStarted);
                m_docMan.DocumentCreationCanceled += new DocumentCollectionEventHandler(Callback_DocumentCreationCanceled);

                m_docMan.DocumentToBeDestroyed += new DocumentCollectionEventHandler(Callback_DocumentToBeDestroyed);
                m_docMan.DocumentDestroyed += new DocumentDestroyedEventHandler(Callback_DocumentDestroyed);
                m_docMan.DocumentToBeActivated += new DocumentCollectionEventHandler(Callback_DocumentToBeActivated);
                m_docMan.DocumentActivated += new DocumentCollectionEventHandler(Callback_DocumentActivated);
                m_docMan.DocumentToBeDeactivated += new DocumentCollectionEventHandler(Callback_DocumentToBeDeactivated);
                m_docMan.DocumentLockModeChanged += new DocumentLockModeChangedEventHandler(Callback_DocumentLockModeChanged);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        private void Callback_DocumentCreationCanceled(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                Log.Information(e.Document.Name);
            }
            else
            {
                Log.Information("e.FileName is null.");
            }
        }

        private void Callback_DocumentCreateStarted(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                Log.Information(e.Document.Name);
            }
            else
            {
                Log.Information("e.FileName is null.");
            }
        }

        private void Callback_DocumentDestroyed(object sender, DocumentDestroyedEventArgs e)
        {
            if (e.FileName is object)
            {
                Log.Information(e.FileName);
            }
            else
            {
                Log.Information("e.FileName is null.");
            }
        }

        private void Callback_DocumentBecameCurrent(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }
        }

        private void Callback_DocumentLockModeChanged(object sender, DocumentLockModeChangedEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }

            Log.Information($" {e.CurrentMode} {e.GlobalCommandName}");
        }

        /// <summary>
        /// Handles the main timer tick event.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is also unused.</param>
        private void TimerUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                foreach (KeyValuePair<string, WorkItem> next in workItems)
                {
                    WorkItem drawing = (WorkItem)next.Value;
                    SaveData(drawing);
                }
            }
        }

        /// <summary>
        /// Event for when documents are created.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is also unused.</param>
        private void Callback_DocumentCreated(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;

                if (doc.IsNamedDrawing)
                {
                    WorkItem newDrawing = new WorkItem
                    {
                        Id = Guid.NewGuid(),
                        FilePath = doc.Name,
                        Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm")),
                    };

                    if (newDrawing.FilePath.LastIndexOf("\\") > 0)
                    {
                        newDrawing.Name = newDrawing.FilePath.Substring(newDrawing.FilePath.LastIndexOf("\\") + 1);
                        newDrawing.Name = newDrawing.Name.Substring(0, newDrawing.Name.Length - 4);
                    }

                    if (newDrawing.FilePath.Substring(0, rootFolder.Length) == rootFolder)
                    {
                        newDrawing.ObjectiveName = newDrawing.FilePath.Substring(rootFolder.Length + 1);
                        newDrawing.ObjectiveName = newDrawing.ObjectiveName.Substring(0, newDrawing.ObjectiveName.IndexOf(@"\"));
                    }
                    else
                    {
                        newDrawing.ObjectiveName = "None";
                    }

                    if (File.Exists(newDrawing.FilePath))
                    {
                        FileInfo drawingFile = new FileInfo(newDrawing.FilePath);
                        newDrawing.StartSize = drawingFile.Length;
                    }

                    workItems.Add(newDrawing.FilePath, newDrawing);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Event for when documents are destroyed.
        /// </summary>
        /// <remarks>
        /// WARNING: When AutoCAD starts this event is fired for "Drawing1.dwg" as the very first event.
        /// even though there is no drawing of that name. There is also no previous matching create event either.
        /// </remarks>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is also unused.</param>
        private void Callback_DocumentToBeDestroyed(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;
                if (doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        if (workItems.ContainsKey(doc.Name))
                        {
                            WorkItem drawing = (WorkItem)workItems[doc.Name];
                            SaveData(drawing);
                            _ = workItems.Remove(drawing.FilePath);
                        }
                        else
                        {
                            Log.Information($"Drawing not found in work items. [{doc.Name}]");
                        }
                    }
                    else
                    {
                        Log.Information($"Drawing is not named drawing. [{doc.Name}]");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Event for activated documents.
        /// </summary>
        /// <remarks>
        /// WARNING: When AutoCAD starts this event fires but the document is null.
        /// </remarks>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter also unused.</param>
        private void Callback_DocumentActivated(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;
                if (doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        WorkItem drawing = (WorkItem)workItems[doc.Name];
                    }
                    else
                    {
                        Log.Information("Doc Name : " + doc.Name);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Event for when a document is activated.
        /// Currently not used as this level of detail is not implemented yet.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter also is unused.</param>
        private void Callback_DocumentToBeActivated(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }
        }

        /// <summary>
        /// Event for when a document is deactivated.
        /// As with Callback_DocumentToBeActivated this is not implemented yet.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is also unused.</param>
        private void Callback_DocumentToBeDeactivated(object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Information(e.Document.Name);
                }
                else
                {
                    Log.Information("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Information("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;

                if (doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        WorkItem drawing = (WorkItem)workItems[doc.Name];
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Saves the Data to the storage folder.
        /// </summary>
        /// <param name="workItem">The WorkItem object to save to file.</param>
        private void SaveData(WorkItem workItem)
        {
            if (workItem is object)
            {
                if (workItem.FilePath is object)
                {
                    Log.Information(workItem.FilePath);
                }
                else
                {
                    Log.Information("drawing.FilePath is null");
                }
            }
            else
            {
                Log.Information("drawing is null");
            }

            try
            {
                if (workItem.Start != workItem.Finish)
                {
                    // TODO Manually save the document before checking. Currently this is relying on auto-save within AutoCAD.
                    // Otherwise the file may not count as work done. Testing first to see the real need for this to be implemented.
                    FileInfo drawingFile = new FileInfo(workItem.FilePath);
                    workItem.FinishSize = drawingFile.Length;

                    if (workItem.FinishSize != workItem.StartSize)
                    {
                        workItem.Application = ApplicationType.AutocadWrite;
                    }
                    else
                    {
                        workItem.Application = ApplicationType.AutocadRead;
                    }

                    workItem.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                    string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                    File.WriteAllText(storageFolder + @"\" + (int)workItem.Application + "-" + workItem.Id.ToString() + ".json", json);
                    workItem.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }
    }
}