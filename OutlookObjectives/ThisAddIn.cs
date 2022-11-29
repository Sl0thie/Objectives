namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CommonObjectives;
    using Serilog;
    using Microsoft.Win32;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Microsoft Outlook VSTO AddIn to track Objectives.
    /// </summary>
    public partial class ThisAddIn
    {
        /// <summary>
        /// Gets the Dictionary to hold the wrappers for Appointment objects..
        /// </summary>
        public Dictionary<Outlook.Inspector, IAppointment> IAppointments
        {
            get
            {
                return iAppointments;
            }
        }

        private static Outlook.AppointmentItem currentAppointment;
        private readonly Dictionary<Outlook.Inspector, IAppointment> iAppointments = new Dictionary<Outlook.Inspector, IAppointment>();
        private Outlook.Inspectors inspectors;

        /// <summary>
        /// Primary entry for the AddIn.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Setup logging for the application.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("OutlookObjectives - .txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Add-in Startup");

            // Check for the required items.
            CheckSystemRequirements();

            // Enqueue the starting Tasks.
            InTouch.TaskManager.EnqueueImportDataTask();

            // InTouch.TaskManager.EnqueueDayReportTask();
            // InTouch.TaskManager.EnqueueWeekReportTask();
            // InTouch.TaskManager.EnqueueMonthReportTask();
            // InTouch.TaskManager.EnqueueConvertVersionTask();
            // InTouch.TaskManager.EnqueueWebSyncTask();

            // Setup the main timer.
            System.Timers.Timer mainTimer = new System.Timers.Timer(50000)
            {
                AutoReset = true,
            };
            mainTimer.Elapsed += OnMainTimerEvent;
            mainTimer.Enabled = true;

            // Manage inspector events.
            inspectors = Application.Inspectors;
            inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            foreach (Outlook.Inspector inspector in inspectors)
            {
                Inspectors_NewInspector(inspector);
            }
        }

        /// <summary>
        /// Event when new inspectors are opened.
        /// </summary>
        /// <param name="inspector">The inspector to manage.</param>
        private void Inspectors_NewInspector(Outlook.Inspector inspector)
        {
            if (inspector.CurrentItem is Outlook.AppointmentItem)
            {
                currentAppointment = null;
                object itemAppointment = inspector.CurrentItem;
                if (itemAppointment == null)
                {
                    return;
                }

                if (!(itemAppointment is Outlook.AppointmentItem))
                {
                    return;
                }

                currentAppointment = inspector.CurrentItem as Outlook.AppointmentItem;

                Outlook.MAPIFolder parentFolder = currentAppointment.Parent as Outlook.MAPIFolder;
                string folderLocation = parentFolder.FolderPath.Substring(2);
                folderLocation = folderLocation.Substring(folderLocation.IndexOf("\\") + 1);

                switch (folderLocation)
                {
                    case "Calendar\\Objectives":
                        switch (currentAppointment.Categories)
                        {
                            case "Objectives - Day Report":
                                iAppointments.Add(inspector, new IWAppointmentObjectivesDayReport(inspector, folderLocation, AppointmentType.ObjectivesDayReport));
                                break;

                            case "Objectives - Week Report":
                                iAppointments.Add(inspector, new IWAppointment(inspector, folderLocation, AppointmentType.ObjectivesWeekReport));
                                break;

                            case "Objectives - Month Report":
                                iAppointments.Add(inspector, new IWAppointment(inspector, folderLocation, AppointmentType.ObjectivesMonthReport));
                                break;

                            default:
                                iAppointments.Add(inspector, new IWAppointment(inspector, folderLocation, AppointmentType.Standard));
                                break;
                        }

                        break;

                    default:
                        Log.Information("Unknown Folder Path " + folderLocation);
                        iAppointments.Add(inspector, new IWAppointment(inspector, folderLocation, AppointmentType.Standard));

                        break;
                }
            }
        }

        /// <summary>
        ///  Primary timer event.
        /// </summary>
        /// <param name="source">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void OnMainTimerEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Log.Information("Timer Tick");

            try
            {
                if ((DateTime.Now.Minute == 5) || (DateTime.Now.Minute == 35))
                {
                    InTouch.TaskManager.EnqueueImportDataTask();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Checks the system requirements.
        /// Required: registry settings.
        /// Required: Root Folder.
        /// Required: Storage folder.
        /// Required: Objectives Calendar.
        /// Required: System Calendar.
        /// </summary>
        private void CheckSystemRequirements()
        {
            // Overhaul.
            RegistryKey objectiveKey;
            RegistryKey workTypesKey;
            RegistryKey subKey;

            // Check if the registry keys exist.
            try
            {
                workTypesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes");
                if (workTypesKey == null)
                {
                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes", true);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\0", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\0", true);
                    subKey.SetValue("Name", "None", RegistryValueKind.String);
                    subKey.SetValue("Description", "Unknown or work type of no value.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "0", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\1", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\1", true);
                    subKey.SetValue("Name", "Management", RegistryValueKind.String);
                    subKey.SetValue("Description", "Cost of management.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "100.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "0", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\2", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\2", true);
                    subKey.SetValue("Name", "Consultation", RegistryValueKind.String);
                    subKey.SetValue("Description", "Cost of consultation.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "110.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "0", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\3", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\3", true);
                    subKey.SetValue("Name", "Administration", RegistryValueKind.String);
                    subKey.SetValue("Description", "Administration Duties.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "25.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "0", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\4", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\4", true);
                    subKey.SetValue("Name", "Software Development", RegistryValueKind.String);
                    subKey.SetValue("Description", "Developing Visual Studio solution.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "2", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\5", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\5", true);
                    subKey.SetValue("Name", "Code review", RegistryValueKind.String);
                    subKey.SetValue("Description", "Reviewing Visual Studio solution.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "3", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\10", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\10", true);
                    subKey.SetValue("Name", "Documentation", RegistryValueKind.String);
                    subKey.SetValue("Description", "Producing Word document.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "25.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "8", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\11", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\11", true);
                    subKey.SetValue("Name", "Documentation review", RegistryValueKind.String);
                    subKey.SetValue("Description", "Reviewing Word document.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "9", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\13", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\13", true);
                    subKey.SetValue("Name", "Excel", RegistryValueKind.String);
                    subKey.SetValue("Description", "Producing Excel Workbook.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "25.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "11", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\14", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\14", true);
                    subKey.SetValue("Name", "Excel - Review", RegistryValueKind.String);
                    subKey.SetValue("Description", "Reviewing Excel Workbook.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "12", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\16", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\16", true);
                    subKey.SetValue("Name", "AutoCAD", RegistryValueKind.String);
                    subKey.SetValue("Description", "Producing AutoCAD drawing.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "25.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "14", RegistryValueKind.String);

                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\17", true);
                    subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\17", true);
                    subKey.SetValue("Name", "AutoCAD - Review", RegistryValueKind.String);
                    subKey.SetValue("Description", "Reviewing AutoCAD drawing.", RegistryValueKind.String);
                    subKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    subKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    subKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    subKey.SetValue("Application", "15", RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            // Load the work types from the registry.
            try
            {
                workTypesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes");
                if (workTypesKey is object)
                {
                    string[] subkeys = workTypesKey.GetSubKeyNames();

                    foreach (string subkey in subkeys)
                    {
                        WorkType nextType = new WorkType();
                        subKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\" + subkey);
                        nextType.Index = Convert.ToInt32(subkey);

                        foreach (string valueName in subKey.GetValueNames())
                        {
                            object val = subKey.GetValue(valueName);
                            switch (valueName)
                            {
                                case "Name":
                                    nextType.Name = Convert.ToString(val);
                                    break;

                                case "Description":
                                    nextType.Description = Convert.ToString(val);
                                    break;

                                case "CostPerHour":
                                    nextType.CostPerHour = Convert.ToDecimal(val);
                                    break;

                                case "MiniumNoOfMinutes":
                                    nextType.MinimumNoOfMinutes = Convert.ToInt32(val);
                                    break;

                                case "MaximNoOfMinutes":
                                    nextType.MaximNoOfMinutes = Convert.ToInt32(val);
                                    break;

                                case "Application":
                                    nextType.Application = (ApplicationType)Convert.ToInt32(val);
                                    break;
                            }
                        }

                        InTouch.WorkTypes.Add(nextType.Index, nextType);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            // Check if the Objectives registry key exist.
            try
            {
                objectiveKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives");
                if (objectiveKey == null)
                {
                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives");
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives path value exist.
            try
            {
                InTouch.ObjectivesRootFolder = (string)objectiveKey.GetValue("RootFolder");
                if (InTouch.ObjectivesRootFolder is null)
                {
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ShowSettings();
                return;
            }

            // Check if the Objectives Path exists.
            try
            {
                if (!Directory.Exists(InTouch.ObjectivesRootFolder))
                {
                    ShowSettings();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives archives path value exist.
            try
            {
                InTouch.ObjectivesArchiveFolder = (string)objectiveKey.GetValue("ArchiveFolder");

                if (InTouch.ObjectivesArchiveFolder is null)
                {
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives archives path value exist.
            try
            {
                InTouch.ObjectivesStorageFolder = (string)objectiveKey.GetValue("StorageFolder");

                if (InTouch.ObjectivesStorageFolder is null)
                {
                    ShowSettings();
                    return;
                }

                Log.Information("Stat.ObjectivesStorageFolder " + InTouch.ObjectivesStorageFolder);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ShowSettings();
                return;
            }

            // TODO Check if the Objectives archive path exists.
            // TODO Check if the Objectives Calendar folder exists in Outlook.
            // TODO Check if the System Calendar folder exists in Outlook.
        }

        /// <summary>
        /// Shows the Settings Form.
        /// </summary>
        private void ShowSettings()
        {
            FormSettings newForm = new FormSettings();
            _ = newForm.ShowDialog();
            CheckSystemRequirements();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += new System.EventHandler(ThisAddIn_Startup);
        }

        #endregion
    }
}
