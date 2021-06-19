using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Newtonsoft.Json;
using System.Timers;
using System.IO;
using CommonObjectives;
using LogNET;

[assembly: ExtensionApplication(typeof(AutoCADObjectives.ExtApp))]
[assembly: CommandClass(null)]
namespace AutoCADObjectives
{
    /// <summary>
    /// AutoCAD extension to track time spent on drawings.
    /// </summary>
    /// <remarks>
    /// Output project directly to AutoCAD's Support directory.
    /// <example>
    /// C:\Program Files\Autodesk\AutoCAD 2018\Support
    /// </example>
    /// This directory is considered secure by AutoCAD so there is no need to add the normal project output directory to AutoCAD's security.
    /// Use the command <c>NETLOAD</c> to load the DLL into AutoCAD manually.
    /// Or copy the file acad.lsp to the support directory to load the DLL automatically on startup.
    /// </remarks>
    public class ExtApp : IExtensionApplication
    {
        // TODO Check that the file path is saving the correct path.
        private string RootFolder;
        private string StorageFolder;
        private readonly Dictionary<string, WorkItem> WorkItems = new Dictionary<string, WorkItem>();
        private readonly Timer timerUpdate = new Timer(50000);

        /// <summary>
        /// Constructor.
        /// </summary>
        public ExtApp()
        {

        }

        /// <summary>
        /// Terminate method.
        /// </summary>
        /// <remarks>
        /// Not 100% sure this is called by AutoCAD yet.
        /// </remarks>
        public void Terminate()
        {

        }

        /// <summary>
        /// Main entry point from AutoCAD.
        /// </summary>
        public void Initialize()
        {
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            try
            {
                // Get folder locations from the registry.
                RootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", "");
                StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");

                // Setup the timer.
                timerUpdate.Elapsed += TimerUpdate_Elapsed;
                timerUpdate.Enabled = true;

                // Hook the events needed from the DocumentManager.
                DocumentCollection m_docMan = Application.DocumentManager;
                m_docMan.DocumentCreated += new DocumentCollectionEventHandler(Callback_DocumentCreated);
                m_docMan.DocumentToBeDestroyed += new DocumentCollectionEventHandler(Callback_DocumentToBeDestroyed);
                m_docMan.DocumentToBeActivated += new DocumentCollectionEventHandler(Callback_DocumentToBeActivated);
                m_docMan.DocumentActivated += new DocumentCollectionEventHandler(Callback_DocumentActivated);
                m_docMan.DocumentToBeDeactivated += new DocumentCollectionEventHandler(Callback_DocumentToBeDeactivated);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Event for the main timer tick.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is unused.</param>
        private void TimerUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
            {
                foreach (var next in WorkItems)
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
        /// <param name="e">parameter is unused.</param>
        private void Callback_DocumentCreated(Object sender, DocumentCollectionEventArgs e)
        {
            if(e.Document is object)
            {
                if(e.Document.Name is object)
                {
                    Log.Info(e.Document.Name);
                }
                else
                {
                    Log.Info("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Info("e.Document is null.");
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
                        Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"))
                    };

                    if (newDrawing.FilePath.LastIndexOf("\\") > 0)
                    {
                        newDrawing.Name = newDrawing.FilePath.Substring(newDrawing.FilePath.LastIndexOf("\\") + 1);
                        newDrawing.Name = newDrawing.Name.Substring(0,newDrawing.Name.Length - 4);
                    }

                    if(newDrawing.FilePath.Substring(0,RootFolder.Length) == RootFolder)
                    {
                        newDrawing.ObjectiveName = newDrawing.FilePath.Substring(RootFolder.Length + 1);
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

                    WorkItems.Add(newDrawing.FilePath, newDrawing);
                }              
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Event for when documents are destroyed.
        /// WARNING: When AutoCAD starts this event is fired for "Drawing1.dwg" as the very first event.
        /// even though there is not drawing of that name. There is also no previous create event either.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is unused.</param>
        private void Callback_DocumentToBeDestroyed(Object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Info(e.Document.Name);
                }
                else
                {
                    Log.Info("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Info("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;
                if (doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        WorkItem drawing = (WorkItem)WorkItems[doc.Name];
                        //
                        SaveData(drawing);
                        WorkItems.Remove(drawing.FilePath);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Event for activated documents.
        /// WARNING: When AutoCAD starts this event fires but the document is null.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is unused.</param>
        private void Callback_DocumentActivated(Object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Info(e.Document.Name);
                }
                else
                {
                    Log.Info("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Info("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;
                if(doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        WorkItem drawing = (WorkItem)WorkItems[doc.Name];
                    }
                    else
                    {
                        Log.Info("Doc Name : " + doc.Name);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Event for when a document is activated.
        /// Currently not used as this level of detail is not implemented yet.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is unused.</param>
        private void Callback_DocumentToBeActivated(Object sender, DocumentCollectionEventArgs e)
        {

        }

        /// <summary>
        /// Event for when a document is deactivated.
        /// As with Callback_DocumentToBeActivated this is not implemented yet.
        /// </summary>
        /// <param name="sender">parameter is unused.</param>
        /// <param name="e">parameter is unused.</param>
        private void Callback_DocumentToBeDeactivated(Object sender, DocumentCollectionEventArgs e)
        {
            if (e.Document is object)
            {
                if (e.Document.Name is object)
                {
                    Log.Info(e.Document.Name);
                }
                else
                {
                    Log.Info("e.Document.Name is null.");
                }
            }
            else
            {
                Log.Info("e.Document is null.");
            }

            try
            {
                Document doc = e.Document;

                if (doc is object)
                {
                    if (doc.IsNamedDrawing)
                    {
                        WorkItem drawing = (WorkItem)WorkItems[doc.Name];
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Saves the Data to the storage folder.
        /// </summary>
        /// <param name="drawing">parameter is unused.</param>
        private void SaveData(WorkItem drawing)
        {
            if(drawing is object)
            {
                if (drawing.FilePath is object)
                {
                    Log.Info(drawing.FilePath);
                }
                else
                {
                    Log.Info("drawing.FilePath is null");
                }
            }
            else
            {
                Log.Info("drawing is null");
            }

            try
            {
                if (drawing.Start != drawing.Finish)
                {
                    // TODO Manually save the document before checking. Currently this is relying on auto-save within AutoCAD.
                    // Otherwise the file may not count as work done. Testing first to see the real need for this to be implemented.
                    FileInfo drawingFile = new FileInfo(drawing.FilePath);
                    drawing.FinishSize = drawingFile.Length;

                    if (drawing.FinishSize != drawing.StartSize)
                    {
                        drawing.Application = ApplicationType.AutocadWrite;
                    }
                    else
                    {
                        drawing.Application = ApplicationType.AutocadRead;
                    }

                    drawing.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                    string json = JsonConvert.SerializeObject(drawing, Formatting.Indented);
                    File.WriteAllText(StorageFolder + @"\" + (int)drawing.Application + "-" + drawing.Id.ToString() + ".json", json);
                    drawing.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}