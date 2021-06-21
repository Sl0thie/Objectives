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
using EnvDTE80;
using System.Text;
using Newtonsoft.Json;


using System.ComponentModel.Design;



namespace SQLServerManagementStudioObjectives
{

    
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#ProductName", "#ProductDescription", "1.6.16")]  //Package Medatada, references to VSPackage.resx resource keys
    [Guid(SQLServerManagementStudioObjectivesPackage.PackageGuidString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.NotBuildingAndNotDebugging_string, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class SQLServerManagementStudioObjectivesPackage : AsyncPackage
    {
        //private GenericVSHelper _SSMSHelper;

        private DTE dte;
        private string RootFolder;
        private string StorageFolder;
        private WorkItem workItem;

        /// <summary>
        /// SQLServerManagementStudioObjectivesPackage class.
        /// </summary>
        /// <remarks>
        /// 
        /// [How to Create an Extension for SSMS 2019 (v18)](https://stackoverflow.com/questions/55661806/how-to-create-an-extension-for-ssms-2019-v18)
        /// [How to Create SQL Server Management Studio 18 (SSMS) Extension](https://www.codeproject.com/Articles/1377559/How-to-Create-SQL-Server-Management-Studio-18-SSMS)
        /// 
        /// 1. To debug set "Start External Program" as the start action.
        /// Default SSMS Location: C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Ssms.exe
        /// 
        /// 2. Set Deploy VSIX to SSMS.
        /// 
        /// The "Extensions" subdirectory should be in the same directory as SSMS. Also, add an extra folder with your project name like this:
        /// 
        /// C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Extensions\SQLServerManagementStudioObjectives
        /// 
        /// Select all three checkboxes.
        /// 
        /// 3. Give the user all security permissions for this folder.
        /// </remarks>
        public const string ProjectDetails = "SQLServerManagementStudioObjectivesPackage";

        /// <summary>
        /// SQLServerManagementStudioObjectivesPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "2757b617-cd56-4cd3-883c-bf8681c76d1f";

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
            await base.InitializeAsync(cancellationToken, progress);

            //_SSMSHelper = new GenericVSHelper(true, null, null, null);

            //Switch to UI thread, so that we're allowed to get services
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            dte = (DTE)Package.GetGlobalService(typeof(DTE));
            GetRegistrySettings();

            // Setup the main timer.
            System.Timers.Timer mainTimer = new System.Timers.Timer(50000)
            {
                AutoReset = true
            };
            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Enabled = true;

            //bool isSolutionLoaded = await IsSolutionLoadedAsync();

            //if (isSolutionLoaded)
            //{
            //    SolutionEvents_OnAfterBackgroundSolutionLoadComplete(null, null);
            //}

            // Listen for subsequent solution events
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnAfterBackgroundSolutionLoadComplete += SolutionEvents_OnAfterBackgroundSolutionLoadComplete;
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnBeforeCloseSolution += SolutionEvents_OnBeforeCloseSolution;

            Log.Info("Startup");
        }

        #endregion

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void SolutionEvents_OnAfterBackgroundSolutionLoadComplete(object sender, EventArgs e)
        {
            try
            {
                Log.Info("Solution Loaded");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void SolutionEvents_OnBeforeCloseSolution(object sender, EventArgs e)
        {
            try
            {
                Log.Info("Solution Unloaded");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

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
        /// Handles the MainTimer event.  
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private async void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                if(dte.Solution is object)
                {
                    if(dte.Solution.FullName is object)
                    {
                        Log.Info("DTE: " + dte.Solution.FileName);
                    }
                    else
                    {
                        Log.Info("DTE: Solution with no name");
                    }
                }
                else
                {
                    Log.Info("DTE: No solution");
                }

                
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
