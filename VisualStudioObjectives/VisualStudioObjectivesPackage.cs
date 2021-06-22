// TODO Test "New Projects". Missed a few work items. Could be related to this.
namespace VisualStudioObjectives
{
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Task = System.Threading.Tasks.Task;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.Shell.Events;
    using Microsoft.VisualStudio.Shell.Interop;
    using LogNET;
    using CommonObjectives;
    using System.IO;
    using EnvDTE;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// VisualStudioObectivesPackage class.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VisualStudioObectivesPackage.PackageGuidString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionOpening_string, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class VisualStudioObectivesPackage : AsyncPackage
    {
        private DTE dte;
        private string RootFolder;
        private string StorageFolder;
        private WorkItem workItem;

        /// <summary>
        /// GUID for the Package.
        /// </summary>
        public const string PackageGuidString = "b0a6e816-4dcc-40fa-8189-b772f5265fda";

        /// <summary>
        /// Initializes the VisualStudioObectivesPackage.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // Access to the DTE has to be done on the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            // Start logging for the extension.
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            // Get the DTE service.
            dte = (DTE)Package.GetGlobalService(typeof(DTE));

            //Get the settings from the registry.
            GetRegistrySettings();

            // Setup the main timer.
            System.Timers.Timer mainTimer = new System.Timers.Timer(50000)
            {
                AutoReset = true
            };
            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Enabled = true;

            // Since this package might not be initialized until after a solution has finished loading,
            // we need to check if a solution has already been loaded and then handle it.
            bool isSolutionLoaded = await IsSolutionLoadedAsync();

            if (isSolutionLoaded)
            {
                SolutionEvents_OnAfterBackgroundSolutionLoadComplete(null,null);
            }

            // Subscribe to Listeners for subsequent solution events.
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnAfterBackgroundSolutionLoadComplete += SolutionEvents_OnAfterBackgroundSolutionLoadComplete;
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnBeforeCloseSolution += SolutionEvents_OnBeforeCloseSolution;         
        }

        /// <summary>
        /// Handles the MainTimer event.  
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private async void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Access to the solution should only be done on the UI thread.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
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

                    Log.Info("Tick: " + workItem.IsActive);
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
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Searches projects and project items for unsaved changes.
        /// </summary>
        /// <remarks>
        /// List of [Project GUID's](https://www.codeproject.com/reference/720512/list-of-visual-studio-project-type-guids")
        /// </remarks>
        /// <param name="solution">The solution to search for unsaved changes.</param>
        /// <param name="save">If true, save the items if they are unsaved.</param>
        /// <returns>True is unsaved changes are found.</returns>
        private async Task<bool> IsSolutionUnsavedAsync(Solution solution, bool save)
        {
            // Switch to main thread to access the DTE.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            bool rv = false;

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
                var project = solution.Projects.Item(i);
                switch (project.Kind)
                {
                    case EnvDTE.Constants.vsProjectKindMisc:
                        break;

                    case EnvDTE.Constants.vsProjectKindSolutionItems:
                        continue;
                        break;

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
                    var item = project.ProjectItems.Item(j);
                    if (await IsProjectItemsUnsavedAsync(item, save))
                    {
                        rv = true;
                    }
                }
            }

            return rv;
        }

        /// <summary>
        /// Searches project items for unsaved changes.  
        /// Also checks the sub items. (recursive)
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
                    break;

                case EnvDTE.Constants.vsProjectItemKindPhysicalFolder:
                    for (int j = 1; j <= item.ProjectItems.Count; j++)
                    {
                        var subitem = item.ProjectItems.Item(j);

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
                    break;
            }

            // If the item is not saved then return true.
            if (!item.Saved)
            {
                if (save)
                {
                    item.Save();
                }
                rv = true;
            }

            return rv;
        }

        /// <summary>
        /// Gets the settings from the Registry.
        /// </summary>
        private void GetRegistrySettings()
        {
            try
            {
                RootFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "RootFolder", "");
                StorageFolder = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\InTouch\\Objectives", "StorageFolder", "");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Handles the Solution load event.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void SolutionEvents_OnAfterBackgroundSolutionLoadComplete(object sender, EventArgs e)
        {
            try
            {
                // Create a new work item for the loaded solution.
                GetStartValues();
                GetCurrentValues();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Handles the Solution close event.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void SolutionEvents_OnBeforeCloseSolution(object sender, EventArgs e)
        {
            try
            {
                // Get the finished data and save to file.
                GetCurrentValues();
                SaveDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Check if the solution is loaded.
        /// </summary>
        /// <returns>True if the solution is loaded.</returns>
        private async Task<bool> IsSolutionLoadedAsync()
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();
            var solService = await GetServiceAsync(typeof(SVsSolution)) as IVsSolution;
            ErrorHandler.ThrowOnFailure(solService.GetProperty((int)__VSPROPID.VSPROPID_IsSolutionOpen, out object value));
            return value is bool isSolOpen && isSolOpen;
        }

        /// <summary>
        /// Gets the starting values for the WorkItem.
        /// </summary>
        private void GetStartValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            //await JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                workItem = new WorkItem(dte.Solution.FileName.Substring(dte.Solution.FileName.LastIndexOf('\\') + 1));
                workItem.Name = workItem.Name.Substring(0, workItem.Name.Length - 4);
                workItem.FilePath = dte.Solution.FileName;
                if (workItem.FilePath.Substring(0, RootFolder.Length) == RootFolder)
                {
                    workItem.ObjectiveName = workItem.FilePath.Substring(RootFolder.Length + 1);
                    workItem.ObjectiveName = workItem.ObjectiveName.Substring(0, workItem.ObjectiveName.IndexOf(@"\"));
                }
                else
                {
                    workItem.ObjectiveName = "None";
                }


                workItem.StartSize = 0;
                DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

                foreach (FileInfo NextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    switch (NextFileInfo.Extension.ToLower())
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
                            workItem.StartSize += NextFileInfo.Length;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Gets the current values for the WorkItem.
        /// </summary>
        private void GetCurrentValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            //await JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                if (File.Exists(dte.Solution.FullName))
                {
                    if (!dte.Solution.Saved)
                    {
                        dte.Solution.SaveAs(dte.Solution.FullName);
                    }
                }

                workItem.FinishSize = 0;

                DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

                foreach (FileInfo NextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    switch (NextFileInfo.Extension.ToLower())
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
                            workItem.FinishSize += NextFileInfo.Length;
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
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Gets the HEAD items from the git logs if they are available.
        /// </summary>
        private void GetHEADItems()
        {
            try
            {
                if (File.Exists(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')) + "\\.git\\logs\\HEAD"))
                {
                    foreach (string line in File.ReadLines(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')) + "\\.git\\logs\\HEAD", Encoding.UTF8))
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
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Saves the WorkItem data to file.
        /// </summary>
        private async Task SaveDataAsync()
        {
            // Switch to the main thread to access the DTE.
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                // Check if the start and finish times are not the same. Outlook uses truncated DateTimes, no seconds or milliseconds.
                if (workItem.Start != workItem.Finish)
                {
                    GetHEADItems();

                    workItem.IsActive = await IsSolutionUnsavedAsync(dte.Solution, true);

                    // If the work item is active then mark it as active.
                    if ((workItem.IsActive) ||(workItem.StartSize != workItem.FinishSize))
                    {
                        workItem.Application = ApplicationType.VisualStudioWrite;
                    }
                    else
                    {
                        workItem.Application = ApplicationType.VisualStudioRead;
                    }

                    // Save the data to file in the storage folder.
                    string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                    File.WriteAllText(StorageFolder + @"\" + (int)workItem.Application + "-" + workItem.Id.ToString() + ".json", json);

                    // Reset the work item. This reuses the work item after it is saved every thirty minutes. If the work item is closed then it does not matter if these values have been reset.
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
    }
}