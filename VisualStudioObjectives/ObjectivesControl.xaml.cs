namespace VisualStudioObjectives
{
    using System.Windows;
    using System.Windows.Controls;
    using EnvDTE;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using CommonObjectives;
    using LogNET;
    using System.Text;

    /// <summary>
    /// Interaction logic for ObjectivesControl.
    /// </summary>
    public partial class ObjectivesControl : UserControl
    {
        private DTE dte;
        private SolutionEvents solutionEvents;
        private BuildEvents buildEvents;
        private readonly System.Windows.Threading.DispatcherTimer MainTimer = new System.Windows.Threading.DispatcherTimer();
        private string RootFolder;
        private string StorageFolder;
        private WorkItem workItem;
        private int BuildCount = 0;
        private long StartFileCountTotal = 0;
        private long StartFileSizeTotal = 0;
        private long FinishFileCountTotal = 0;
        private long FinishFileSizeTotal = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectivesControl"/> class.
        /// </summary>
        public ObjectivesControl()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            this.InitializeComponent();
            GetRegistrySettings();
            AddEventHandlers();
            MainTimer.Tick += TimerUpdate_Tick;
            MainTimer.Interval = new TimeSpan(0, 0, 0, 50);
            workItem = new WorkItem();

            if (dte.Solution is object)
            {
                Log.Info("Solution on startup = true");
                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            else
            {
                Log.Info("Solution on startup = false");
            }
        }

        /// <summary>
        /// Get the settings from the registry.
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
        /// Adds the event handlers needed.
        /// </summary>
        private void AddEventHandlers()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                dte = (DTE)Package.GetGlobalService(typeof(DTE));
                if (!(dte is null))
                {
                    // Solution Events.
                    solutionEvents = dte.Events.SolutionEvents;
                    solutionEvents.BeforeClosing += SolutionEvents_BeforeClosing;
                    solutionEvents.Opened += SolutionEvents_Opened;
                    solutionEvents.Renamed += SolutionEvents_Renamed;
                    solutionEvents.ProjectAdded += SolutionEvents_ProjectAdded;
                    solutionEvents.ProjectRemoved += SolutionEvents_ProjectRemoved;
                    solutionEvents.ProjectRenamed += SolutionEvents_ProjectRenamed;

                    //Build Events.
                    buildEvents = dte.Events.BuildEvents;
                    buildEvents.OnBuildDone += BuildEvents_OnBuildDone;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void MyToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainTimer.Start();
        }

        #region Solution Events

        private void SolutionEvents_ProjectRenamed(Project Project, string OldName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                GetCurrentValues();
                SaveData();

                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SolutionEvents_ProjectRemoved(Project Project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                GetCurrentValues();
                SaveData();

                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SolutionEvents_ProjectAdded(Project Project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                GetCurrentValues();
                SaveData();

                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SolutionEvents_Renamed(string OldName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                GetCurrentValues();
                SaveData();

                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SolutionEvents_BeforeClosing()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                GetCurrentValues();
                SaveData();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SolutionEvents_Opened()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                GetStartValues();
                GetCurrentValues();
                UpdateWindow();
                MainTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        #endregion

        #region Build Events

        private void BuildEvents_OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
        {
            try
            {
                BuildCount++;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        #endregion

        private void GetStartValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                BuildCount = 0;
                StartFileCountTotal = 0;
                StartFileSizeTotal = 0;

                workItem = new WorkItem(dte.Solution.FileName.Substring(dte.Solution.FileName.LastIndexOf('\\') + 1));
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

                DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

                foreach (FileInfo NextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    switch (NextFileInfo.Extension.ToLower())
                    {
                        case ".editorconfig": // Solution
                        case ".gitattributes":
                        case ".gitignore":
                        case ".sln":
                        case ".suo":
                        case ".vbg":
                            StartFileCountTotal++;
                            StartFileSizeTotal += NextFileInfo.Length;

                            break;

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
                            StartFileCountTotal++;
                            StartFileSizeTotal += NextFileInfo.Length;
                            break;

                        default:
                            break;
                    }
                }

                valueTimeStart.Text = workItem.Start.ToString(@"h\:mm");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void GetCurrentValues()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                if (File.Exists(dte.Solution.FullName))
                {
                    if (!dte.Solution.Saved)
                    {
                        dte.Solution.SaveAs(dte.Solution.FullName);
                    }
                }

                FinishFileCountTotal = 0;
                FinishFileSizeTotal = 0;

                DirectoryInfo basePath = new DirectoryInfo(workItem.FilePath.Substring(0, workItem.FilePath.LastIndexOf('\\')));

                foreach (FileInfo NextFileInfo in basePath.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    switch (NextFileInfo.Extension.ToLower())
                    {
                        case ".editorconfig": // Solution
                        case ".gitattributes":
                        case ".gitignore":
                        case ".sln":
                        case ".suo":
                        case ".vbg":
                            FinishFileCountTotal++;
                            FinishFileSizeTotal += NextFileInfo.Length;
                            break;

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
                            FinishFileCountTotal++;
                            FinishFileSizeTotal += NextFileInfo.Length;
                            break;

                        default:
                            break;
                    }
                }

                if((StartFileCountTotal != FinishFileCountTotal) || (StartFileSizeTotal != FinishFileSizeTotal))
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

        private void UpdateWindow()
        {
            try
            {
                valueObjective.Text = workItem.ObjectiveName;

                valueTimeNow.Text = workItem.Finish.ToString(@"h\:mm");
                valueTimeDiff.Text = workItem.Finish.Subtract(workItem.Start).ToString(@"h\:mm");

                valueFilesStart.Text = StartFileCountTotal.ToString();
                valueFilesNow.Text = FinishFileCountTotal.ToString();
                valueFilesDiff.Text = (FinishFileCountTotal - StartFileCountTotal).ToString();

                valueSizeStart.Text = StartFileSizeTotal.ToString();
                valueSizeNow.Text = FinishFileSizeTotal.ToString();
                valueSizeDiff.Text = (FinishFileSizeTotal - StartFileSizeTotal).ToString();

                valueBuildsStart.Text = "0";
                valueBuildsNow.Text = BuildCount.ToString();
                valueBuildsDiff.Text = BuildCount.ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                MainTimer.Stop();
                MainTimer.Start();

                if (workItem is object)
                {
                    if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 30))
                    {
                        GetCurrentValues();
                        SaveData();
                        GetStartValues();
                        GetCurrentValues();
                        UpdateWindow();
                    }

                    GetCurrentValues();
                    UpdateWindow();
                }
                else
                {
                    if (dte.Solution is object)
                    {
                        GetStartValues();
                        GetCurrentValues();
                        UpdateWindow();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

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

        private void SaveData()
        {
            try
            {
                if (workItem.Start != workItem.Finish)
                {
                    GetHEADItems();
                    string json = JsonConvert.SerializeObject(workItem, Formatting.Indented);
                    File.WriteAllText(StorageFolder + @"\" + (int)workItem.Application + "-" + workItem.Id.ToString() + ".json", json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void MyToolWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Shutdown();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}