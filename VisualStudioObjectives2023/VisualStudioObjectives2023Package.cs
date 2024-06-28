namespace VisualStudioObjectives2023
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using CommonObjectives;

    using EnvDTE;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Events;
    using Microsoft.VisualStudio.Shell.Interop;

    using Newtonsoft.Json;

    using Serilog;

    using static System.Net.WebRequestMethods;

    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VisualStudioObjectives2023Package.PackageGuidString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionOpening_string, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class VisualStudioObjectives2023Package : AsyncPackage
    {
        private DTE dte;
        private string rootFolder;
        private string storageFolder;
        private WorkItem workItem;

        /// <summary>
        /// VisualStudioObjectives2023Package GUID string.
        /// </summary>
        public const string PackageGuidString = "7b604da5-39c8-4a2b-8bf6-b18f40d81e60";

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            // Start logging for the extension.
            string logpath =  "F:\\Logs";
            //string logpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Logs");
            //if (!Directory.Exists(logpath))
            //{
            //    _ = Directory.CreateDirectory(logpath);
            //}
            logpath = logpath + "\\" + MethodBase.GetCurrentMethod().DeclaringType.Namespace + " - .txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logpath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Logging Started.");

            // Get the DTE service.
            dte = (DTE)GetGlobalService(typeof(DTE));

            // Get the settings from the registry.
            GetRegistrySettings();

            // Setup the main timer.
            System.Timers.Timer mainTimer = new System.Timers.Timer(50000)
            {
                AutoReset = true,
            };

            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Enabled = true;

            // Since this package might not be initialized until after a solution has finished loading,
            // we need to check if a solution has already been loaded and then handle it.
            bool isSolutionLoaded = await IsSolutionLoadedAsync();

            if (isSolutionLoaded)
            {
                SolutionEvents_OnAfterBackgroundSolutionLoadComplete(null, null);
            }

            // Subscribe to Listeners for subsequent solution events.
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnAfterBackgroundSolutionLoadComplete += SolutionEvents_OnAfterBackgroundSolutionLoadComplete;
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnBeforeCloseSolution += SolutionEvents_OnBeforeCloseSolution;
        }

        #endregion

        /// <summary>
        /// Handles the MainTimer event.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter also is unused.</param>
        private async void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Access to the solution should only be done on the UI thread.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            if (workItem is object)
            {
                // Check for unsaved items. The project is active if there are unsaved items.
                workItem.IsActive = await IsSolutionUnsavedAsync(dte.Solution, false);

                if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
                {
                    GetCurrentValues();
                    await SaveDataAsync();
                    GetStartValues();
                    GetCurrentValues();
                }

                // GetCurrentValues(); Not sure if this is necessary?
                Log.Information("Tick: " + workItem.IsActive);
            }
            else
            {
                // If there is no work item then check if there is a solution. If so, create a new work item.
                if (dte.Solution is object)
                {
                    GetStartValues();
                    GetCurrentValues();
                }
            }
        }

        /// <summary>
        /// Searches projects and project items for unsaved changes.
        /// </summary>
        /// <remarks>
        /// List of [Project GUID's](https://www.codeproject.com/reference/720512/list-of-visual-studio-project-type-guids").
        /// </remarks>
        /// <param name="solution">The solution to search for unsaved changes.</param>
        /// <param name="save">If true, save the items if they are unsaved.</param>
        /// <returns>True is unsaved changes are found.</returns>
        private async Task<bool> IsSolutionUnsavedAsync(Solution solution, bool save)
        {
            // Switch to main thread to access the DTE.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            bool rv = false;

            try
            {
                // Check if the solution is saved.
                if (!solution.Saved)
                {
                    rv = true;
                    if (save)
                    {
                        solution.SaveAs(solution.FileName);
                    }
                }

                // Check if the projects are saved.
                for (int i = 1; i <= solution.Projects.Count; i++)
                {
                    Project project = solution.Projects.Item(i);
                    switch (project.Kind)
                    {
                        case EnvDTE.Constants.vsProjectKindMisc:
                            break;

                        case EnvDTE.Constants.vsProjectKindSolutionItems:
                            continue;

                        case EnvDTE.Constants.vsProjectKindUnmodeled:
                            break;

                        case "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}": // C#
                            break;

                        default:
                            break;
                    }

                    if (!project.Saved)
                    {
                        if (save)
                        {
                            project.Save();
                        }

                        rv = true;
                    }

                    // Check if the project items are saved as well.
                    for (int j = 1; j <= project.ProjectItems.Count; j++)
                    {
                        ProjectItem item = project.ProjectItems.Item(j);
                        if (await IsProjectItemsUnsavedAsync(item, save))
                        {
                            rv = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Information("IsSolutionUnsavedAsync");
                Log.Error(ex, ex.Message);
            }

            return rv;
        }

        /// <summary>
        /// Searches project items for unsaved changes.
        /// Also checks the sub items. (recursive).
        /// </summary>
        /// <param name="item">The project item to search.  Includes sub items if the item is a folder.</param>
        /// <param name="save">If true, will save the item if unsaved changes are found.</param>
        /// <returns>Returns true is the item is unsaved.</returns>
        private async Task<bool> IsProjectItemsUnsavedAsync(ProjectItem item, bool save)
        {
            // Switch to main thread to access the DTE.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            bool rv = false;

            // Check if item is a folder. If so then check the sub items.
            switch (item.Kind)
            {
                case EnvDTE.Constants.vsProjectItemKindMisc:
                    break;

                case EnvDTE.Constants.vsProjectItemKindPhysicalFile:

                    // If the item is not saved then return true.
                    if (!item.Saved)
                    {
                        if (save)
                        {
                            item.Save();
                            //_ = item.Document.Save();
                        }

                        rv = true;
                    }

                    break;

                case EnvDTE.Constants.vsProjectItemKindPhysicalFolder:
                    for (int j = 1; j <= item.ProjectItems.Count; j++)
                    {
                        ProjectItem subitem = item.ProjectItems.Item(j);

                        if (await IsProjectItemsUnsavedAsync(subitem, save))
                        {
                            rv = true;
                        }
                    }

                    break;

                case EnvDTE.Constants.vsProjectItemKindSolutionItems:
                    break;

                case EnvDTE.Constants.vsProjectItemKindSubProject:
                    break;

                case EnvDTE.Constants.vsProjectItemKindVirtualFolder:
                    break;

                case EnvDTE.Constants.vsProjectItemsKindMisc:
                    break;

                case EnvDTE.Constants.vsProjectItemsKindSolutionItems:
                    break;

                default:

                    Log.Information($"Type of unknown project item {item.GetType()}");

                    break;
            }

            return rv;
        }

        /// <summary>
        /// Gets the settings from the Registry.
        /// </summary>
        private void GetRegistrySettings()
        {
            rootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", string.Empty);
            storageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", string.Empty);
        }

        /// <summary>
        /// Handles the Solution load event.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter also is unused.</param>
        private void SolutionEvents_OnAfterBackgroundSolutionLoadComplete(object sender, EventArgs e)
        {
            // Create a new work item for the loaded solution.
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            GetStartValues();
            GetCurrentValues();
        }

        /// <summary>
        /// Handles the Solution close event.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter also is unused.</param>
        private void SolutionEvents_OnBeforeCloseSolution(object sender, EventArgs e)
        {
            // Get the finished data and save to file.
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            GetCurrentValues();
            _ = SaveDataAsync();
        }

        /// <summary>
        /// Check if the solution is loaded.
        /// </summary>
        /// <returns>True if the solution is loaded.</returns>
        private async Task<bool> IsSolutionLoadedAsync()
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();
            IVsSolution solService = await GetServiceAsync(typeof(SVsSolution)) as IVsSolution;
            _ = ErrorHandler.ThrowOnFailure(solService.GetProperty((int)__VSPROPID.VSPROPID_IsSolutionOpen, out object value));
            return value is bool isSolOpen && isSolOpen;
        }

        /// <summary>
        /// Gets the starting values for the WorkItem.
        /// </summary>
        private void GetStartValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // await JoinableTaskFactory.SwitchToMainThreadAsync();
            workItem = new WorkItem(dte.Solution.FileName.Substring(dte.Solution.FileName.LastIndexOf('\\') + 1));
            workItem.Name = workItem.Name.Substring(0, workItem.Name.Length - 4);
            workItem.FilePath = dte.Solution.FileName;
            if (workItem.FilePath.Substring(0, rootFolder.Length) == rootFolder)
            {
                workItem.ObjectiveName = workItem.FilePath.Substring(rootFolder.Length + 1);
                workItem.ObjectiveName = workItem.ObjectiveName.Substring(0, workItem.ObjectiveName.IndexOf(@"\"));
            }
            else
            {
                workItem.ObjectiveName = "None";
            }

            workItem.StartSize = 0;
            DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

            foreach (FileInfo nextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                switch (nextFileInfo.Extension.ToLower())
                {
                    case ".ascx": // Source
                    case ".asmx":
                    case ".asp":
                    case ".aspx":
                    case ".config":
                    case ".c":
                    case ".cpp":
                    case ".disco":
                    case ".cs":
                    case ".css":
                    case ".cshtml":
                    case ".h":
                    case ".hta":
                    case ".htc":
                    case ".htm":
                    case ".html":
                    case ".js":
                    case ".json":
                    case ".ps1":
                    case ".ps2":
                    case ".resx":
                    case ".vsto":
                    case ".xaml":
                    case ".xml":
                    case ".xsp":
                        workItem.StartSize += nextFileInfo.Length;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the current values for the WorkItem.
        /// </summary>
        private void GetCurrentValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // await JoinableTaskFactory.SwitchToMainThreadAsync();
            if (System.IO.File.Exists(dte.Solution.FullName))
            {
                if (!dte.Solution.Saved)
                {
                    dte.Solution.SaveAs(dte.Solution.FullName);
                }
            }

            workItem.FinishSize = 0;

            DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

            foreach (FileInfo nextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                switch (nextFileInfo.Extension.ToLower())
                {
                    case ".ascx": // Source
                    case ".asmx":
                    case ".asp":
                    case ".aspx":
                    case ".config":
                    case ".c":
                    case ".cpp":
                    case ".disco":
                    case ".cs":
                    case ".css":
                    case ".cshtml":
                    case ".h":
                    case ".hta":
                    case ".htc":
                    case ".htm":
                    case ".html":
                    case ".js":
                    case ".json":
                    case ".ps1":
                    case ".ps2":
                    case ".resx":
                    case ".vsto":
                    case ".xaml":
                    case ".xml":
                    case ".xsp":
                        workItem.FinishSize += nextFileInfo.Length;
                        break;

                    default:
                        break;
                }
            }

            if (workItem.StartSize != workItem.FinishSize)
            {
                workItem.Application = ApplicationType.VisualStudioWrite;
            }
            else
            {
                workItem.Application = ApplicationType.VisualStudioRead;
            }

            workItem.Finish = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
        }

        /// <summary>
        /// Gets the HEAD items from the git logs if they are available.
        /// </summary>
        private void GetHEADItems()
        {
            if (System.IO.File.Exists(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')) + "\\.git\\logs\\HEAD"))
            {
                foreach (string line in System.IO.File.ReadLines(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')) + "\\.git\\logs\\HEAD", Encoding.UTF8))
                {
                    string temp = line.Substring(line.IndexOf('>') + 2);
                    temp = temp.Substring(0, temp.IndexOf(' '));
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToDouble(temp));
                    temp = line.Substring(line.IndexOf('+') + 1, 2);
                    dt = dt.AddHours(Convert.ToInt32(temp));
                    if ((dt >= workItem.Start) && (dt <= workItem.Finish))
                    {
                        workItem.Notes.Add(new Note("GitItem", line));
                    }
                }
            }
        }

        /// <summary>
        /// Saves the WorkItem data to file.
        /// </summary>
        private async Task SaveDataAsync()
        {
            // Switch to the main thread to access the DTE.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            // Check if the start and finish times are not the same. Outlook uses truncated DateTimes, no seconds or milliseconds.
            if (workItem.Start != workItem.Finish)
            {
                GetHEADItems();

                workItem.IsActive = await IsSolutionUnsavedAsync(dte.Solution, true);

                // If the work item is active then mark it as active.
                if (workItem.IsActive || (workItem.StartSize != workItem.FinishSize))
                {
                    workItem.Application = ApplicationType.VisualStudioWrite;
                }
                else
                {
                    workItem.Application = ApplicationType.VisualStudioRead;
                }

                // Save the data to file in the storage folder.
                string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                System.IO.File.WriteAllText(storageFolder + @"\" + (int)workItem.Application + "-" + workItem.Id.ToString() + ".json", json);

                // Reset the work item. This reuses the work item after it is saved every thirty minutes. If the work item is closed then it does not matter if these values have been reset.
                workItem.Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
                workItem.IsActive = false;
                workItem.StartSize = workItem.FinishSize;
            }
        }
    }
}
