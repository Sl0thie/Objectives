namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Win32;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using CommonObjectives;
    using LogNET;

    public partial class ThisAddIn
    {
        private Outlook.Inspectors inspectors;
        private static Outlook.AppointmentItem CurrentAppointment;
        private readonly Dictionary<Outlook.Inspector, IAppointment> iAppointments = new Dictionary<Outlook.Inspector, IAppointment>();

        // Dictionary to hold the wrappers for Appointments.
        public Dictionary<Outlook.Inspector, IAppointment> IAppointments
        {
            get
            {
                return iAppointments;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Start the logging.
            Log.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2019\\Logs", true, true, false);

            // Check for the required items.
            CheckSystemRequirements();

            // Enqueue the starting Tasks.
            InTouch.TaskManager.EnqueueImportDataTask();
            InTouch.TaskManager.EnqueueDayReportTask();
            InTouch.TaskManager.EnqueueWeekReportTask();
            InTouch.TaskManager.EnqueueMonthReportTask();

            // Setup the main timer.
            System.Timers.Timer mainTimer = new System.Timers.Timer(50000);
            mainTimer.AutoReset = true;
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
        void Inspectors_NewInspector(Outlook.Inspector inspector)
        {
            Log.MethodEntry();

            if (inspector.CurrentItem is Outlook.AppointmentItem)
            {
                CurrentAppointment = null;
                object itemAppointment = inspector.CurrentItem;
                if (itemAppointment == null)
                    return;
                if (!(itemAppointment is Outlook.AppointmentItem))
                    return;
                CurrentAppointment = inspector.CurrentItem as Outlook.AppointmentItem;

                Outlook.MAPIFolder parentFolder = CurrentAppointment.Parent as Outlook.MAPIFolder;
                string FolderLocation = parentFolder.FolderPath.Substring(2);
                FolderLocation = FolderLocation.Substring(FolderLocation.IndexOf("\\") + 1);

                switch (FolderLocation)
                {
                    case "Calendar\\Objectives":
                        switch (CurrentAppointment.Categories)
                        {
                            case "Objectives - Day Report":
                                iAppointments.Add(inspector, new IWAppointmentObjectivesDayReport(inspector, FolderLocation, AppointmentType.ObjectivesDayReport));
                                break;

                            case "Objectives - Week Report":
                                iAppointments.Add(inspector, new IWAppointment(inspector, FolderLocation, AppointmentType.ObjectivesWeekReport));
                                break;

                            case "Objectives - Month Report":
                                iAppointments.Add(inspector, new IWAppointment(inspector, FolderLocation, AppointmentType.ObjectivesMonthReport));
                                break;

                            default:
                                iAppointments.Add(inspector, new IWAppointment(inspector, FolderLocation, AppointmentType.Standard));
                                break;
                        }

                        break;

                    default:
                        Log.Info("Unknown Folder Path " + FolderLocation);
                        iAppointments.Add(inspector, new IWAppointment(inspector, FolderLocation, AppointmentType.Standard));

                        break;
                }
            }

            Log.MethodExit();
        }

        /// <summary>
        ///  Primary timer event.
        /// </summary>
        /// <param name="source">Unused.</param>
        /// <param name="e">Unused.</param>
        private static void OnMainTimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Log.Info("Timer Tick");

            try
            {
                if ((DateTime.Now.Minute == 5) || (DateTime.Now.Minute == 35))
                {
                    InTouch.TaskManager.EnqueueImportDataTask();
                }
            }
            catch { }
        }

        /// <summary>
        /// Checks the system requirements.</br>
        /// Required: registry settings.
        /// Required: Root Folder.
        /// Required: Storage folder.
        /// Required: Objectives Calendar.
        /// Required: System Calendar.
        /// </summary>
        private void CheckSystemRequirements()
        {
            //TODO Overhaul.
            RegistryKey ObjectiveKey;
            RegistryKey WorkTypesKey;
            RegistryKey SubKey;

            // Check if the registry keys exist.
            try
            {
                WorkTypesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes");
                if (WorkTypesKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes", true);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\0", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\0", true);
                    SubKey.SetValue("Name", "None", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Unknown or work type of no value.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\1", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\1", true);
                    SubKey.SetValue("Name", "Management", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of management.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "100.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\2", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\2", true);
                    SubKey.SetValue("Name", "Consultation", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of consultation.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "110.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\3", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\3", true);
                    SubKey.SetValue("Name", "Administration", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Administration Duties.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "25.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\4", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\4", true);
                    SubKey.SetValue("Name", "Visual Studio", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Visual Studio.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "1", RegistryValueKind.String);
                    SubKey.SetValue("Active", "true", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\5", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\5", true);
                    SubKey.SetValue("Name", "SSMS", RegistryValueKind.String);
                    SubKey.SetValue("Description", "SSMS.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "2", RegistryValueKind.String);
                    SubKey.SetValue("Active", "true", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\6", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\6", true);
                    SubKey.SetValue("Name", "Excel", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Excel.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "4", RegistryValueKind.String);
                    SubKey.SetValue("Active", "true", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\7", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\7", true);
                    SubKey.SetValue("Name", "Word", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Word.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "3", RegistryValueKind.String);
                    SubKey.SetValue("Active", "true", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\8", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\8", true);
                    SubKey.SetValue("Name", "AutoCAD", RegistryValueKind.String);
                    SubKey.SetValue("Description", "AutoCAD.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "5", RegistryValueKind.String);
                    SubKey.SetValue("Active", "true", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\9", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\9", true);
                    SubKey.SetValue("Name", "General Labor", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of general labor.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "35.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\10", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\10", true);
                    SubKey.SetValue("Name", "Training", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of training.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "40.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\11", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\11", true);
                    SubKey.SetValue("Name", "Research", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of research.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "50.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\12", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\12", true);
                    SubKey.SetValue("Name", "Travel", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of traveling.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "10.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "0", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\13", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\13", true);
                    SubKey.SetValue("Name", "Reviewing Visual Studio", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Viewing Visual Studio.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "1", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\14", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\14", true);
                    SubKey.SetValue("Name", "Reviewing SSMS", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of research.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "2", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\15", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\15", true);
                    SubKey.SetValue("Name", "Reviewing Excel", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Viewing Excel.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "4", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\16", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\16", true);
                    SubKey.SetValue("Name", "Reviewing Word", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of research.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "3", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\17", true);
                    SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\17", true);
                    SubKey.SetValue("Name", "Reviewing AutoCAD", RegistryValueKind.String);
                    SubKey.SetValue("Description", "Cost of research.", RegistryValueKind.String);
                    SubKey.SetValue("CostPerHour", "0.00", RegistryValueKind.String);
                    SubKey.SetValue("MiniumNoOfMinutes", "0", RegistryValueKind.String);
                    SubKey.SetValue("MaximNoOfMinutes", "1440", RegistryValueKind.String);
                    SubKey.SetValue("Application", "5", RegistryValueKind.String);
                    SubKey.SetValue("Active", "false", RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            // Load the work types from the registry.
            try
            {
                WorkTypesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes");
                if (WorkTypesKey is object)
                {
                    var subkeys = WorkTypesKey.GetSubKeyNames();

                    foreach (var subkey in subkeys)
                    {
                        WorkType nextType = new WorkType();
                        SubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives\WorkTypes\" + subkey);
                        nextType.Index = Convert.ToInt32(subkey);

                        foreach (var valueName in SubKey.GetValueNames())
                        {
                            var val = SubKey.GetValue(valueName);
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

                                case "Active":
                                    nextType.Active = Convert.ToBoolean(val);
                                    break;
                            }
                        }

                        InTouch.WorkTypes.Add(nextType.Index, nextType);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            // Check if the Objectives registry key exist.
            try
            {
                ObjectiveKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives");
                if (ObjectiveKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives");
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives path value exist.
            try
            {
                InTouch.ObjectivesRootFolder = (string)ObjectiveKey.GetValue("RootFolder");
                if (InTouch.ObjectivesRootFolder is null)
                {
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
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
                Log.Error(ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives archives path value exist.
            try
            {
                InTouch.ObjectivesArchiveFolder = (string)ObjectiveKey.GetValue("ArchiveFolder");

                if (InTouch.ObjectivesArchiveFolder is null)
                {
                    ShowSettings();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ShowSettings();
                return;
            }

            // Check if the registry Objectives archives path value exist.
            try
            {
                InTouch.ObjectivesStorageFolder = (string)ObjectiveKey.GetValue("StorageFolder");

                if (InTouch.ObjectivesStorageFolder is null)
                {
                    ShowSettings();
                    return;
                }

                Log.Info("Stat.ObjectivesStorageFolder " + InTouch.ObjectivesStorageFolder);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ShowSettings();
                return;
            }

            //TODO Check if the Objectives archive path exists.

            //TODO Check if the Objectives Calendar folder exists in Outlook.

            //TODO Check if the System Calendar folder exists in Outlook.
        }

        /// <summary>
        /// Shows the Settings Form.
        /// </summary>
        private void ShowSettings()
        {
            FormSettings newForm = new FormSettings();
            newForm.ShowDialog();
            CheckSystemRequirements();
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
