<a name='assembly'></a>
# OutlookObjectives

## Contents

- [FRObjectivesDayReport](#T-OutlookObjectives-FRObjectivesDayReport 'OutlookObjectives.FRObjectivesDayReport')
  - [components](#F-OutlookObjectives-FRObjectivesDayReport-components 'OutlookObjectives.FRObjectivesDayReport.components')
  - [Dispose()](#M-OutlookObjectives-FRObjectivesDayReport-Dispose-System-Boolean- 'OutlookObjectives.FRObjectivesDayReport.Dispose(System.Boolean)')
  - [FRObjectivesDayReport_FormRegionShowing(sender,e)](#M-OutlookObjectives-FRObjectivesDayReport-FRObjectivesDayReport_FormRegionShowing-System-Object,System-EventArgs- 'OutlookObjectives.FRObjectivesDayReport.FRObjectivesDayReport_FormRegionShowing(System.Object,System.EventArgs)')
  - [InitializeComponent()](#M-OutlookObjectives-FRObjectivesDayReport-InitializeComponent 'OutlookObjectives.FRObjectivesDayReport.InitializeComponent')
  - [InitializeManifest()](#M-OutlookObjectives-FRObjectivesDayReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory- 'OutlookObjectives.FRObjectivesDayReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)')
- [FRObjectivesMonthReport](#T-OutlookObjectives-FRObjectivesMonthReport 'OutlookObjectives.FRObjectivesMonthReport')
  - [components](#F-OutlookObjectives-FRObjectivesMonthReport-components 'OutlookObjectives.FRObjectivesMonthReport.components')
  - [Dispose()](#M-OutlookObjectives-FRObjectivesMonthReport-Dispose-System-Boolean- 'OutlookObjectives.FRObjectivesMonthReport.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FRObjectivesMonthReport-InitializeComponent 'OutlookObjectives.FRObjectivesMonthReport.InitializeComponent')
  - [InitializeManifest()](#M-OutlookObjectives-FRObjectivesMonthReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory- 'OutlookObjectives.FRObjectivesMonthReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)')
- [FRObjectivesWeekReport](#T-OutlookObjectives-FRObjectivesWeekReport 'OutlookObjectives.FRObjectivesWeekReport')
  - [components](#F-OutlookObjectives-FRObjectivesWeekReport-components 'OutlookObjectives.FRObjectivesWeekReport.components')
  - [Dispose()](#M-OutlookObjectives-FRObjectivesWeekReport-Dispose-System-Boolean- 'OutlookObjectives.FRObjectivesWeekReport.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FRObjectivesWeekReport-InitializeComponent 'OutlookObjectives.FRObjectivesWeekReport.InitializeComponent')
  - [InitializeManifest()](#M-OutlookObjectives-FRObjectivesWeekReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory- 'OutlookObjectives.FRObjectivesWeekReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)')
- [FormChangeWorkType](#T-OutlookObjectives-FormChangeWorkType 'OutlookObjectives.FormChangeWorkType')
  - [#ctor()](#M-OutlookObjectives-FormChangeWorkType-#ctor 'OutlookObjectives.FormChangeWorkType.#ctor')
  - [components](#F-OutlookObjectives-FormChangeWorkType-components 'OutlookObjectives.FormChangeWorkType.components')
  - [WorkType](#P-OutlookObjectives-FormChangeWorkType-WorkType 'OutlookObjectives.FormChangeWorkType.WorkType')
  - [ComboApplication_SelectedIndexChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-ComboApplication_SelectedIndexChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.ComboApplication_SelectedIndexChanged(System.Object,System.EventArgs)')
  - [Dispose(disposing)](#M-OutlookObjectives-FormChangeWorkType-Dispose-System-Boolean- 'OutlookObjectives.FormChangeWorkType.Dispose(System.Boolean)')
  - [FormChangeWorkType_Load(sender,e)](#M-OutlookObjectives-FormChangeWorkType-FormChangeWorkType_Load-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.FormChangeWorkType_Load(System.Object,System.EventArgs)')
  - [InitializeComponent()](#M-OutlookObjectives-FormChangeWorkType-InitializeComponent 'OutlookObjectives.FormChangeWorkType.InitializeComponent')
  - [NumCostPerHour_ValueChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-NumCostPerHour_ValueChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.NumCostPerHour_ValueChanged(System.Object,System.EventArgs)')
  - [NumMaxMinutes_ValueChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-NumMaxMinutes_ValueChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.NumMaxMinutes_ValueChanged(System.Object,System.EventArgs)')
  - [NumMinMinutes_ValueChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-NumMinMinutes_ValueChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.NumMinMinutes_ValueChanged(System.Object,System.EventArgs)')
  - [SetupForm()](#M-OutlookObjectives-FormChangeWorkType-SetupForm 'OutlookObjectives.FormChangeWorkType.SetupForm')
  - [TextDescription_TextChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-TextDescription_TextChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.TextDescription_TextChanged(System.Object,System.EventArgs)')
  - [TextName_TextChanged(sender,e)](#M-OutlookObjectives-FormChangeWorkType-TextName_TextChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormChangeWorkType.TextName_TextChanged(System.Object,System.EventArgs)')
- [FormCreateObjective](#T-OutlookObjectives-FormCreateObjective 'OutlookObjectives.FormCreateObjective')
  - [#ctor()](#M-OutlookObjectives-FormCreateObjective-#ctor 'OutlookObjectives.FormCreateObjective.#ctor')
  - [components](#F-OutlookObjectives-FormCreateObjective-components 'OutlookObjectives.FormCreateObjective.components')
  - [ButtonCreateObjective_Click(sender,e)](#M-OutlookObjectives-FormCreateObjective-ButtonCreateObjective_Click-System-Object,System-EventArgs- 'OutlookObjectives.FormCreateObjective.ButtonCreateObjective_Click(System.Object,System.EventArgs)')
  - [Dispose(disposing)](#M-OutlookObjectives-FormCreateObjective-Dispose-System-Boolean- 'OutlookObjectives.FormCreateObjective.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FormCreateObjective-InitializeComponent 'OutlookObjectives.FormCreateObjective.InitializeComponent')
- [FormObjectiveRates](#T-OutlookObjectives-FormObjectiveRates 'OutlookObjectives.FormObjectiveRates')
  - [#ctor()](#M-OutlookObjectives-FormObjectiveRates-#ctor 'OutlookObjectives.FormObjectiveRates.#ctor')
  - [components](#F-OutlookObjectives-FormObjectiveRates-components 'OutlookObjectives.FormObjectiveRates.components')
  - [Objective](#P-OutlookObjectives-FormObjectiveRates-Objective 'OutlookObjectives.FormObjectiveRates.Objective')
  - [Dispose(disposing)](#M-OutlookObjectives-FormObjectiveRates-Dispose-System-Boolean- 'OutlookObjectives.FormObjectiveRates.Dispose(System.Boolean)')
  - [FormObjectiveRates_FormClosing(sender,e)](#M-OutlookObjectives-FormObjectiveRates-FormObjectiveRates_FormClosing-System-Object,System-Windows-Forms-FormClosingEventArgs- 'OutlookObjectives.FormObjectiveRates.FormObjectiveRates_FormClosing(System.Object,System.Windows.Forms.FormClosingEventArgs)')
  - [InitializeComponent()](#M-OutlookObjectives-FormObjectiveRates-InitializeComponent 'OutlookObjectives.FormObjectiveRates.InitializeComponent')
  - [ListWorkTypes_DoubleClick(sender,e)](#M-OutlookObjectives-FormObjectiveRates-ListWorkTypes_DoubleClick-System-Object,System-EventArgs- 'OutlookObjectives.FormObjectiveRates.ListWorkTypes_DoubleClick(System.Object,System.EventArgs)')
  - [SetupControl()](#M-OutlookObjectives-FormObjectiveRates-SetupControl 'OutlookObjectives.FormObjectiveRates.SetupControl')
- [FormSettings](#T-OutlookObjectives-FormSettings 'OutlookObjectives.FormSettings')
  - [#ctor()](#M-OutlookObjectives-FormSettings-#ctor 'OutlookObjectives.FormSettings.#ctor')
  - [components](#F-OutlookObjectives-FormSettings-components 'OutlookObjectives.FormSettings.components')
  - [Dispose(disposing)](#M-OutlookObjectives-FormSettings-Dispose-System-Boolean- 'OutlookObjectives.FormSettings.Dispose(System.Boolean)')
  - [FormSettings_Load(sender,e)](#M-OutlookObjectives-FormSettings-FormSettings_Load-System-Object,System-EventArgs- 'OutlookObjectives.FormSettings.FormSettings_Load(System.Object,System.EventArgs)')
  - [InitializeComponent()](#M-OutlookObjectives-FormSettings-InitializeComponent 'OutlookObjectives.FormSettings.InitializeComponent')
  - [TextBoxArchiveFolder_TextChanged(sender,e)](#M-OutlookObjectives-FormSettings-TextBoxArchiveFolder_TextChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormSettings.TextBoxArchiveFolder_TextChanged(System.Object,System.EventArgs)')
  - [TextBoxObjectivesRootFolder_TextChanged(sender,e)](#M-OutlookObjectives-FormSettings-TextBoxObjectivesRootFolder_TextChanged-System-Object,System-EventArgs- 'OutlookObjectives.FormSettings.TextBoxObjectivesRootFolder_TextChanged(System.Object,System.EventArgs)')
- [Globals](#T-OutlookObjectives-Globals 'OutlookObjectives.Globals')
  - [#ctor()](#M-OutlookObjectives-Globals-#ctor 'OutlookObjectives.Globals.#ctor')
- [IAppointment](#T-OutlookObjectives-IAppointment 'OutlookObjectives.IAppointment')
  - [AppointmentType](#P-OutlookObjectives-IAppointment-AppointmentType 'OutlookObjectives.IAppointment.AppointmentType')
  - [FolderPath](#P-OutlookObjectives-IAppointment-FolderPath 'OutlookObjectives.IAppointment.FolderPath')
- [IWAppointmentObjectivesDayReport](#T-OutlookObjectives-IWAppointmentObjectivesDayReport 'OutlookObjectives.IWAppointmentObjectivesDayReport')
  - [#ctor(Inspector,folderPath,appointmentType)](#M-OutlookObjectives-IWAppointmentObjectivesDayReport-#ctor-Microsoft-Office-Interop-Outlook-Inspector,System-String,CommonObjectives-AppointmentType- 'OutlookObjectives.IWAppointmentObjectivesDayReport.#ctor(Microsoft.Office.Interop.Outlook.Inspector,System.String,CommonObjectives.AppointmentType)')
  - [Appointment](#P-OutlookObjectives-IWAppointmentObjectivesDayReport-Appointment 'OutlookObjectives.IWAppointmentObjectivesDayReport.Appointment')
  - [AppointmentType](#P-OutlookObjectives-IWAppointmentObjectivesDayReport-AppointmentType 'OutlookObjectives.IWAppointmentObjectivesDayReport.AppointmentType')
  - [FolderPath](#P-OutlookObjectives-IWAppointmentObjectivesDayReport-FolderPath 'OutlookObjectives.IWAppointmentObjectivesDayReport.FolderPath')
  - [Inspector](#P-OutlookObjectives-IWAppointmentObjectivesDayReport-Inspector 'OutlookObjectives.IWAppointmentObjectivesDayReport.Inspector')
  - [Appointment_Close(cancel)](#M-OutlookObjectives-IWAppointmentObjectivesDayReport-Appointment_Close-System-Boolean@- 'OutlookObjectives.IWAppointmentObjectivesDayReport.Appointment_Close(System.Boolean@)')
  - [InspectorWrapper_Close()](#M-OutlookObjectives-IWAppointmentObjectivesDayReport-InspectorWrapper_Close 'OutlookObjectives.IWAppointmentObjectivesDayReport.InspectorWrapper_Close')
- [InTouch](#T-OutlookObjectives-InTouch 'OutlookObjectives.InTouch')
  - [DpiX](#F-OutlookObjectives-InTouch-DpiX 'OutlookObjectives.InTouch.DpiX')
  - [DpiY](#F-OutlookObjectives-InTouch-DpiY 'OutlookObjectives.InTouch.DpiY')
  - [RibbonHeight](#F-OutlookObjectives-InTouch-RibbonHeight 'OutlookObjectives.InTouch.RibbonHeight')
  - [WorkItemVersion](#F-OutlookObjectives-InTouch-WorkItemVersion 'OutlookObjectives.InTouch.WorkItemVersion')
  - [ObjectivesArchiveFolder](#P-OutlookObjectives-InTouch-ObjectivesArchiveFolder 'OutlookObjectives.InTouch.ObjectivesArchiveFolder')
  - [ObjectivesRootFolder](#P-OutlookObjectives-InTouch-ObjectivesRootFolder 'OutlookObjectives.InTouch.ObjectivesRootFolder')
  - [ObjectivesStorageFolder](#P-OutlookObjectives-InTouch-ObjectivesStorageFolder 'OutlookObjectives.InTouch.ObjectivesStorageFolder')
  - [TaskManager](#P-OutlookObjectives-InTouch-TaskManager 'OutlookObjectives.InTouch.TaskManager')
  - [WorkTypes](#P-OutlookObjectives-InTouch-WorkTypes 'OutlookObjectives.InTouch.WorkTypes')
  - [CreateCSS()](#M-OutlookObjectives-InTouch-CreateCSS 'OutlookObjectives.InTouch.CreateCSS')
  - [CreateObjective(objectiveName)](#M-OutlookObjectives-InTouch-CreateObjective-System-String- 'OutlookObjectives.InTouch.CreateObjective(System.String)')
  - [GetObjective(path)](#M-OutlookObjectives-InTouch-GetObjective-System-String- 'OutlookObjectives.InTouch.GetObjective(System.String)')
  - [GetTimeStringFromMinutes(minutes)](#M-OutlookObjectives-InTouch-GetTimeStringFromMinutes-System-Int32- 'OutlookObjectives.InTouch.GetTimeStringFromMinutes(System.Int32)')
  - [SaveObjective(objective)](#M-OutlookObjectives-InTouch-SaveObjective-CommonObjectives-Objective- 'OutlookObjectives.InTouch.SaveObjective(CommonObjectives.Objective)')
- [Resources](#T-OutlookObjectives-Properties-Resources 'OutlookObjectives.Properties.Resources')
  - [Culture](#P-OutlookObjectives-Properties-Resources-Culture 'OutlookObjectives.Properties.Resources.Culture')
  - [ResourceManager](#P-OutlookObjectives-Properties-Resources-ResourceManager 'OutlookObjectives.Properties.Resources.ResourceManager')
- [RibAppointment](#T-OutlookObjectives-RibAppointment 'OutlookObjectives.RibAppointment')
  - [#ctor()](#M-OutlookObjectives-RibAppointment-#ctor 'OutlookObjectives.RibAppointment.#ctor')
  - [components](#F-OutlookObjectives-RibAppointment-components 'OutlookObjectives.RibAppointment.components')
  - [Dispose(disposing)](#M-OutlookObjectives-RibAppointment-Dispose-System-Boolean- 'OutlookObjectives.RibAppointment.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-RibAppointment-InitializeComponent 'OutlookObjectives.RibAppointment.InitializeComponent')
  - [RibAppointment_Load(sender,e)](#M-OutlookObjectives-RibAppointment-RibAppointment_Load-System-Object,Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs- 'OutlookObjectives.RibAppointment.RibAppointment_Load(System.Object,Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs)')
- [RibExplorer](#T-OutlookObjectives-RibExplorer 'OutlookObjectives.RibExplorer')
  - [#ctor()](#M-OutlookObjectives-RibExplorer-#ctor 'OutlookObjectives.RibExplorer.#ctor')
  - [components](#F-OutlookObjectives-RibExplorer-components 'OutlookObjectives.RibExplorer.components')
  - [ButtonNewObjective_Click(sender,e)](#M-OutlookObjectives-RibExplorer-ButtonNewObjective_Click-System-Object,Microsoft-Office-Tools-Ribbon-RibbonControlEventArgs- 'OutlookObjectives.RibExplorer.ButtonNewObjective_Click(System.Object,Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs)')
  - [Dispose(disposing)](#M-OutlookObjectives-RibExplorer-Dispose-System-Boolean- 'OutlookObjectives.RibExplorer.Dispose(System.Boolean)')
  - [Explorer_FolderSwitch()](#M-OutlookObjectives-RibExplorer-Explorer_FolderSwitch 'OutlookObjectives.RibExplorer.Explorer_FolderSwitch')
  - [InitializeComponent()](#M-OutlookObjectives-RibExplorer-InitializeComponent 'OutlookObjectives.RibExplorer.InitializeComponent')
  - [RibExplorer_Load(sender,e)](#M-OutlookObjectives-RibExplorer-RibExplorer_Load-System-Object,Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs- 'OutlookObjectives.RibExplorer.RibExplorer_Load(System.Object,Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs)')
- [TaskConvertVersion](#T-OutlookObjectives-TaskConvertVersion 'OutlookObjectives.TaskConvertVersion')
  - [#ctor(callBack)](#M-OutlookObjectives-TaskConvertVersion-#ctor-System-Action- 'OutlookObjectives.TaskConvertVersion.#ctor(System.Action)')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskConvertVersion-BackgroundProcess 'OutlookObjectives.TaskConvertVersion.BackgroundProcess')
  - [GetAppointmentsInRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskConvertVersion-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskConvertVersion.GetAppointmentsInRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [GetAppointmentsWithinRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskConvertVersion-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskConvertVersion.GetAppointmentsWithinRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [ProcessAppointments()](#M-OutlookObjectives-TaskConvertVersion-ProcessAppointments 'OutlookObjectives.TaskConvertVersion.ProcessAppointments')
  - [RunTask()](#M-OutlookObjectives-TaskConvertVersion-RunTask 'OutlookObjectives.TaskConvertVersion.RunTask')
- [TaskDayReport](#T-OutlookObjectives-TaskDayReport 'OutlookObjectives.TaskDayReport')
  - [#ctor(callBack)](#M-OutlookObjectives-TaskDayReport-#ctor-System-Action- 'OutlookObjectives.TaskDayReport.#ctor(System.Action)')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskDayReport-BackgroundProcess 'OutlookObjectives.TaskDayReport.BackgroundProcess')
  - [CreateHTML()](#M-OutlookObjectives-TaskDayReport-CreateHTML 'OutlookObjectives.TaskDayReport.CreateHTML')
  - [DrawApplicationsImage()](#M-OutlookObjectives-TaskDayReport-DrawApplicationsImage 'OutlookObjectives.TaskDayReport.DrawApplicationsImage')
  - [DrawDayBarImage()](#M-OutlookObjectives-TaskDayReport-DrawDayBarImage 'OutlookObjectives.TaskDayReport.DrawDayBarImage')
  - [DrawObjectiveImage()](#M-OutlookObjectives-TaskDayReport-DrawObjectiveImage 'OutlookObjectives.TaskDayReport.DrawObjectiveImage')
  - [DrawSystemTimeImage()](#M-OutlookObjectives-TaskDayReport-DrawSystemTimeImage 'OutlookObjectives.TaskDayReport.DrawSystemTimeImage')
  - [FindDay()](#M-OutlookObjectives-TaskDayReport-FindDay 'OutlookObjectives.TaskDayReport.FindDay')
  - [GetAppointmentsInRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskDayReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskDayReport.GetAppointmentsInRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [GetAppointmentsWithinRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskDayReport-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskDayReport.GetAppointmentsWithinRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [ProcessAppointments()](#M-OutlookObjectives-TaskDayReport-ProcessAppointments 'OutlookObjectives.TaskDayReport.ProcessAppointments')
  - [ProcessSystemIdle(json)](#M-OutlookObjectives-TaskDayReport-ProcessSystemIdle-System-String- 'OutlookObjectives.TaskDayReport.ProcessSystemIdle(System.String)')
  - [ProcessSystemUptime(json)](#M-OutlookObjectives-TaskDayReport-ProcessSystemUptime-System-String- 'OutlookObjectives.TaskDayReport.ProcessSystemUptime(System.String)')
  - [ProcessVisualStudio(json)](#M-OutlookObjectives-TaskDayReport-ProcessVisualStudio-System-String- 'OutlookObjectives.TaskDayReport.ProcessVisualStudio(System.String)')
  - [RunTask()](#M-OutlookObjectives-TaskDayReport-RunTask 'OutlookObjectives.TaskDayReport.RunTask')
- [TaskImportData](#T-OutlookObjectives-TaskImportData 'OutlookObjectives.TaskImportData')
  - [#ctor(callBack)](#M-OutlookObjectives-TaskImportData-#ctor-System-Action- 'OutlookObjectives.TaskImportData.#ctor(System.Action)')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskImportData-BackgroundProcess 'OutlookObjectives.TaskImportData.BackgroundProcess')
  - [ImportSystemIdle(json)](#M-OutlookObjectives-TaskImportData-ImportSystemIdle-System-String- 'OutlookObjectives.TaskImportData.ImportSystemIdle(System.String)')
  - [ImportSystemSleep(json)](#M-OutlookObjectives-TaskImportData-ImportSystemSleep-System-String- 'OutlookObjectives.TaskImportData.ImportSystemSleep(System.String)')
  - [ImportSystemUptime(json)](#M-OutlookObjectives-TaskImportData-ImportSystemUptime-System-String- 'OutlookObjectives.TaskImportData.ImportSystemUptime(System.String)')
  - [ImportWorkItem(json)](#M-OutlookObjectives-TaskImportData-ImportWorkItem-System-String- 'OutlookObjectives.TaskImportData.ImportWorkItem(System.String)')
  - [ReadFiles()](#M-OutlookObjectives-TaskImportData-ReadFiles 'OutlookObjectives.TaskImportData.ReadFiles')
  - [RunTask()](#M-OutlookObjectives-TaskImportData-RunTask 'OutlookObjectives.TaskImportData.RunTask')
- [TaskManager](#T-OutlookObjectives-TaskManager 'OutlookObjectives.TaskManager')
  - [#ctor()](#M-OutlookObjectives-TaskManager-#ctor 'OutlookObjectives.TaskManager.#ctor')
  - [BackgroundTasks](#P-OutlookObjectives-TaskManager-BackgroundTasks 'OutlookObjectives.TaskManager.BackgroundTasks')
  - [CurrentAction](#P-OutlookObjectives-TaskManager-CurrentAction 'OutlookObjectives.TaskManager.CurrentAction')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskManager-BackgroundProcess 'OutlookObjectives.TaskManager.BackgroundProcess')
  - [EnqueueConvertVersionTask()](#M-OutlookObjectives-TaskManager-EnqueueConvertVersionTask 'OutlookObjectives.TaskManager.EnqueueConvertVersionTask')
  - [EnqueueDayReportTask()](#M-OutlookObjectives-TaskManager-EnqueueDayReportTask 'OutlookObjectives.TaskManager.EnqueueDayReportTask')
  - [EnqueueImportDataTask()](#M-OutlookObjectives-TaskManager-EnqueueImportDataTask 'OutlookObjectives.TaskManager.EnqueueImportDataTask')
  - [EnqueueMonthReportTask()](#M-OutlookObjectives-TaskManager-EnqueueMonthReportTask 'OutlookObjectives.TaskManager.EnqueueMonthReportTask')
  - [EnqueueWeekReportTask()](#M-OutlookObjectives-TaskManager-EnqueueWeekReportTask 'OutlookObjectives.TaskManager.EnqueueWeekReportTask')
  - [TaskFinished()](#M-OutlookObjectives-TaskManager-TaskFinished 'OutlookObjectives.TaskManager.TaskFinished')
- [TaskMonthReport](#T-OutlookObjectives-TaskMonthReport 'OutlookObjectives.TaskMonthReport')
  - [#ctor(callBack)](#M-OutlookObjectives-TaskMonthReport-#ctor-System-Action- 'OutlookObjectives.TaskMonthReport.#ctor(System.Action)')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskMonthReport-BackgroundProcess 'OutlookObjectives.TaskMonthReport.BackgroundProcess')
  - [FindDay()](#M-OutlookObjectives-TaskMonthReport-FindDay 'OutlookObjectives.TaskMonthReport.FindDay')
  - [GetAppointmentsInRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskMonthReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskMonthReport.GetAppointmentsInRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [GetAppointmentsWithinRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskMonthReport-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskMonthReport.GetAppointmentsWithinRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [RunTask()](#M-OutlookObjectives-TaskMonthReport-RunTask 'OutlookObjectives.TaskMonthReport.RunTask')
- [TaskWeekReport](#T-OutlookObjectives-TaskWeekReport 'OutlookObjectives.TaskWeekReport')
  - [#ctor(callBack)](#M-OutlookObjectives-TaskWeekReport-#ctor-System-Action- 'OutlookObjectives.TaskWeekReport.#ctor(System.Action)')
  - [BackgroundProcess()](#M-OutlookObjectives-TaskWeekReport-BackgroundProcess 'OutlookObjectives.TaskWeekReport.BackgroundProcess')
  - [CreateHTML()](#M-OutlookObjectives-TaskWeekReport-CreateHTML 'OutlookObjectives.TaskWeekReport.CreateHTML')
  - [FindDay()](#M-OutlookObjectives-TaskWeekReport-FindDay 'OutlookObjectives.TaskWeekReport.FindDay')
  - [GetAppointmentsInRange(folder,startTime,endTime)](#M-OutlookObjectives-TaskWeekReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime- 'OutlookObjectives.TaskWeekReport.GetAppointmentsInRange(Microsoft.Office.Interop.Outlook.Folder,System.DateTime,System.DateTime)')
  - [GetDays()](#M-OutlookObjectives-TaskWeekReport-GetDays 'OutlookObjectives.TaskWeekReport.GetDays')
  - [GetWorkItemFromDays()](#M-OutlookObjectives-TaskWeekReport-GetWorkItemFromDays 'OutlookObjectives.TaskWeekReport.GetWorkItemFromDays')
  - [RunTask()](#M-OutlookObjectives-TaskWeekReport-RunTask 'OutlookObjectives.TaskWeekReport.RunTask')
- [ThisAddIn](#T-OutlookObjectives-ThisAddIn 'OutlookObjectives.ThisAddIn')
  - [#ctor()](#M-OutlookObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Outlook-Factory,System-IServiceProvider- 'OutlookObjectives.ThisAddIn.#ctor(Microsoft.Office.Tools.Outlook.Factory,System.IServiceProvider)')
  - [IAppointments](#P-OutlookObjectives-ThisAddIn-IAppointments 'OutlookObjectives.ThisAddIn.IAppointments')
  - [BeginInitialization()](#M-OutlookObjectives-ThisAddIn-BeginInitialization 'OutlookObjectives.ThisAddIn.BeginInitialization')
  - [BindToData()](#M-OutlookObjectives-ThisAddIn-BindToData 'OutlookObjectives.ThisAddIn.BindToData')
  - [CheckSystemRequirements()](#M-OutlookObjectives-ThisAddIn-CheckSystemRequirements 'OutlookObjectives.ThisAddIn.CheckSystemRequirements')
  - [EndInitialization()](#M-OutlookObjectives-ThisAddIn-EndInitialization 'OutlookObjectives.ThisAddIn.EndInitialization')
  - [FinishInitialization()](#M-OutlookObjectives-ThisAddIn-FinishInitialization 'OutlookObjectives.ThisAddIn.FinishInitialization')
  - [Initialize()](#M-OutlookObjectives-ThisAddIn-Initialize 'OutlookObjectives.ThisAddIn.Initialize')
  - [InitializeCachedData()](#M-OutlookObjectives-ThisAddIn-InitializeCachedData 'OutlookObjectives.ThisAddIn.InitializeCachedData')
  - [InitializeComponents()](#M-OutlookObjectives-ThisAddIn-InitializeComponents 'OutlookObjectives.ThisAddIn.InitializeComponents')
  - [InitializeControls()](#M-OutlookObjectives-ThisAddIn-InitializeControls 'OutlookObjectives.ThisAddIn.InitializeControls')
  - [InitializeData()](#M-OutlookObjectives-ThisAddIn-InitializeData 'OutlookObjectives.ThisAddIn.InitializeData')
  - [InitializeDataBindings()](#M-OutlookObjectives-ThisAddIn-InitializeDataBindings 'OutlookObjectives.ThisAddIn.InitializeDataBindings')
  - [Inspectors_NewInspector(inspector)](#M-OutlookObjectives-ThisAddIn-Inspectors_NewInspector-Microsoft-Office-Interop-Outlook-Inspector- 'OutlookObjectives.ThisAddIn.Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector)')
  - [InternalStartup()](#M-OutlookObjectives-ThisAddIn-InternalStartup 'OutlookObjectives.ThisAddIn.InternalStartup')
  - [IsCached()](#M-OutlookObjectives-ThisAddIn-IsCached-System-String- 'OutlookObjectives.ThisAddIn.IsCached(System.String)')
  - [NeedsFill()](#M-OutlookObjectives-ThisAddIn-NeedsFill-System-String- 'OutlookObjectives.ThisAddIn.NeedsFill(System.String)')
  - [OnMainTimerEvent(source,e)](#M-OutlookObjectives-ThisAddIn-OnMainTimerEvent-System-Object,System-Timers-ElapsedEventArgs- 'OutlookObjectives.ThisAddIn.OnMainTimerEvent(System.Object,System.Timers.ElapsedEventArgs)')
  - [OnShutdown()](#M-OutlookObjectives-ThisAddIn-OnShutdown 'OutlookObjectives.ThisAddIn.OnShutdown')
  - [ShowSettings()](#M-OutlookObjectives-ThisAddIn-ShowSettings 'OutlookObjectives.ThisAddIn.ShowSettings')
  - [StartCaching()](#M-OutlookObjectives-ThisAddIn-StartCaching-System-String- 'OutlookObjectives.ThisAddIn.StartCaching(System.String)')
  - [StopCaching()](#M-OutlookObjectives-ThisAddIn-StopCaching-System-String- 'OutlookObjectives.ThisAddIn.StopCaching(System.String)')
  - [ThisAddIn_Startup(sender,e)](#M-OutlookObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs- 'OutlookObjectives.ThisAddIn.ThisAddIn_Startup(System.Object,System.EventArgs)')
- [ThisFormRegionCollection](#T-OutlookObjectives-ThisFormRegionCollection 'OutlookObjectives.ThisFormRegionCollection')
  - [#ctor()](#M-OutlookObjectives-ThisFormRegionCollection-#ctor-System-Collections-Generic-IList{Microsoft-Office-Tools-Outlook-IFormRegion}- 'OutlookObjectives.ThisFormRegionCollection.#ctor(System.Collections.Generic.IList{Microsoft.Office.Tools.Outlook.IFormRegion})')
- [ThisRibbonCollection](#T-OutlookObjectives-ThisRibbonCollection 'OutlookObjectives.ThisRibbonCollection')
  - [#ctor()](#M-OutlookObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory- 'OutlookObjectives.ThisRibbonCollection.#ctor(Microsoft.Office.Tools.Ribbon.RibbonFactory)')
- [UCObjectives](#T-OutlookObjectives-UCObjectives 'OutlookObjectives.UCObjectives')
  - [#ctor()](#M-OutlookObjectives-UCObjectives-#ctor 'OutlookObjectives.UCObjectives.#ctor')
  - [components](#F-OutlookObjectives-UCObjectives-components 'OutlookObjectives.UCObjectives.components')
  - [Dispose(disposing)](#M-OutlookObjectives-UCObjectives-Dispose-System-Boolean- 'OutlookObjectives.UCObjectives.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-UCObjectives-InitializeComponent 'OutlookObjectives.UCObjectives.InitializeComponent')
  - [ListObjectives_SelectedIndexChanged(sender,e)](#M-OutlookObjectives-UCObjectives-ListObjectives_SelectedIndexChanged-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.ListObjectives_SelectedIndexChanged(System.Object,System.EventArgs)')
  - [MenuActivate_Click(sender,e)](#M-OutlookObjectives-UCObjectives-MenuActivate_Click-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.MenuActivate_Click(System.Object,System.EventArgs)')
  - [MenuArchive_Click(sender,e)](#M-OutlookObjectives-UCObjectives-MenuArchive_Click-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.MenuArchive_Click(System.Object,System.EventArgs)')
  - [MenuRates_Click(sender,e)](#M-OutlookObjectives-UCObjectives-MenuRates_Click-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.MenuRates_Click(System.Object,System.EventArgs)')
  - [UCObjectives_Load(sender,e)](#M-OutlookObjectives-UCObjectives-UCObjectives_Load-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.UCObjectives_Load(System.Object,System.EventArgs)')
  - [UCObjectives_Resize(sender,e)](#M-OutlookObjectives-UCObjectives-UCObjectives_Resize-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.UCObjectives_Resize(System.Object,System.EventArgs)')
- [WindowFormRegionCollection](#T-OutlookObjectives-WindowFormRegionCollection 'OutlookObjectives.WindowFormRegionCollection')
  - [#ctor()](#M-OutlookObjectives-WindowFormRegionCollection-#ctor-System-Collections-Generic-IList{Microsoft-Office-Tools-Outlook-IFormRegion}- 'OutlookObjectives.WindowFormRegionCollection.#ctor(System.Collections.Generic.IList{Microsoft.Office.Tools.Outlook.IFormRegion})')

<a name='T-OutlookObjectives-FRObjectivesDayReport'></a>
## FRObjectivesDayReport `type`

##### Namespace

OutlookObjectives

##### Summary

A Form Region for the Objectives Day Report.

<a name='F-OutlookObjectives-FRObjectivesDayReport-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FRObjectivesDayReport-Dispose-System-Boolean-'></a>
### Dispose() `method`

##### Summary

Clean up any resources being used.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesDayReport-FRObjectivesDayReport_FormRegionShowing-System-Object,System-EventArgs-'></a>
### FRObjectivesDayReport_FormRegionShowing(sender,e) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Unused. |

<a name='M-OutlookObjectives-FRObjectivesDayReport-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesDayReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory-'></a>
### InitializeManifest() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FRObjectivesMonthReport'></a>
## FRObjectivesMonthReport `type`

##### Namespace

OutlookObjectives

<a name='F-OutlookObjectives-FRObjectivesMonthReport-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FRObjectivesMonthReport-Dispose-System-Boolean-'></a>
### Dispose() `method`

##### Summary

Clean up any resources being used.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesMonthReport-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesMonthReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory-'></a>
### InitializeManifest() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FRObjectivesWeekReport'></a>
## FRObjectivesWeekReport `type`

##### Namespace

OutlookObjectives

<a name='F-OutlookObjectives-FRObjectivesWeekReport-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FRObjectivesWeekReport-Dispose-System-Boolean-'></a>
### Dispose() `method`

##### Summary

Clean up any resources being used.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesWeekReport-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FRObjectivesWeekReport-InitializeManifest-Microsoft-Office-Tools-Outlook-FormRegionManifest,Microsoft-Office-Tools-Outlook-Factory-'></a>
### InitializeManifest() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FormChangeWorkType'></a>
## FormChangeWorkType `type`

##### Namespace

OutlookObjectives

##### Summary

UI to review or make changes to the WorkTypes.

<a name='M-OutlookObjectives-FormChangeWorkType-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [FormChangeWorkType](#T-OutlookObjectives-FormChangeWorkType 'OutlookObjectives.FormChangeWorkType') class.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-FormChangeWorkType-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='P-OutlookObjectives-FormChangeWorkType-WorkType'></a>
### WorkType `property`

##### Summary

The WorkType to be review or modified.

<a name='M-OutlookObjectives-FormChangeWorkType-ComboApplication_SelectedIndexChanged-System-Object,System-EventArgs-'></a>
### ComboApplication_SelectedIndexChanged(sender,e) `method`

##### Summary

Updates the application associated with the WorkType.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-FormChangeWorkType-FormChangeWorkType_Load-System-Object,System-EventArgs-'></a>
### FormChangeWorkType_Load(sender,e) `method`

##### Summary

Setup the UI.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FormChangeWorkType-NumCostPerHour_ValueChanged-System-Object,System-EventArgs-'></a>
### NumCostPerHour_ValueChanged(sender,e) `method`

##### Summary

Updates the WorkType Cost per Hour.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-NumMaxMinutes_ValueChanged-System-Object,System-EventArgs-'></a>
### NumMaxMinutes_ValueChanged(sender,e) `method`

##### Summary

Updates the maximum number of minutes per day.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-NumMinMinutes_ValueChanged-System-Object,System-EventArgs-'></a>
### NumMinMinutes_ValueChanged(sender,e) `method`

##### Summary

Updates the minimum number of minutes per day.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-SetupForm'></a>
### SetupForm() `method`

##### Summary

Load the data from the WorkType to the UI.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FormChangeWorkType-TextDescription_TextChanged-System-Object,System-EventArgs-'></a>
### TextDescription_TextChanged(sender,e) `method`

##### Summary

Updates the WorkType Description.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-OutlookObjectives-FormChangeWorkType-TextName_TextChanged-System-Object,System-EventArgs-'></a>
### TextName_TextChanged(sender,e) `method`

##### Summary

Updates the WorkType Name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='T-OutlookObjectives-FormCreateObjective'></a>
## FormCreateObjective `type`

##### Namespace

OutlookObjectives

##### Summary

UI form to provide an interface for the user to create a new Objective.

<a name='M-OutlookObjectives-FormCreateObjective-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-FormCreateObjective-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FormCreateObjective-ButtonCreateObjective_Click-System-Object,System-EventArgs-'></a>
### ButtonCreateObjective_Click(sender,e) `method`

##### Summary

Checks is the Objective is correct and if so then creates a new Objective.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-FormCreateObjective-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-FormCreateObjective-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FormObjectiveRates'></a>
## FormObjectiveRates `type`

##### Namespace

OutlookObjectives

##### Summary

Form to manage the Objectives Rates and Costs.

<a name='M-OutlookObjectives-FormObjectiveRates-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [FormObjectiveRates](#T-OutlookObjectives-FormObjectiveRates 'OutlookObjectives.FormObjectiveRates') class.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-FormObjectiveRates-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='P-OutlookObjectives-FormObjectiveRates-Objective'></a>
### Objective `property`

##### Summary

The objective to manage.

<a name='M-OutlookObjectives-FormObjectiveRates-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-FormObjectiveRates-FormObjectiveRates_FormClosing-System-Object,System-Windows-Forms-FormClosingEventArgs-'></a>
### FormObjectiveRates_FormClosing(sender,e) `method`

##### Summary

Save the objective when the form closes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.Windows.Forms.FormClosingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.FormClosingEventArgs 'System.Windows.Forms.FormClosingEventArgs') | Unused. |

<a name='M-OutlookObjectives-FormObjectiveRates-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FormObjectiveRates-ListWorkTypes_DoubleClick-System-Object,System-EventArgs-'></a>
### ListWorkTypes_DoubleClick(sender,e) `method`

##### Summary

Show the Change WorkType form when an item is double clicked.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Unused. |

<a name='M-OutlookObjectives-FormObjectiveRates-SetupControl'></a>
### SetupControl() `method`

##### Summary

Setup the form to suit the supplied objective.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FormSettings'></a>
## FormSettings `type`

##### Namespace

OutlookObjectives

##### Summary

Form to manage Objectives Settings.

<a name='M-OutlookObjectives-FormSettings-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [FormSettings](#T-OutlookObjectives-FormSettings 'OutlookObjectives.FormSettings') class.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-FormSettings-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FormSettings-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-FormSettings-FormSettings_Load-System-Object,System-EventArgs-'></a>
### FormSettings_Load(sender,e) `method`

##### Summary

Populate the form with the original details.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Unused. |

<a name='M-OutlookObjectives-FormSettings-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-FormSettings-TextBoxArchiveFolder_TextChanged-System-Object,System-EventArgs-'></a>
### TextBoxArchiveFolder_TextChanged(sender,e) `method`

##### Summary

Update the archive folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Unused. |

<a name='M-OutlookObjectives-FormSettings-TextBoxObjectivesRootFolder_TextChanged-System-Object,System-EventArgs-'></a>
### TextBoxObjectivesRootFolder_TextChanged(sender,e) `method`

##### Summary

Update the root folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Unused. |

<a name='T-OutlookObjectives-Globals'></a>
## Globals `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-Globals-#ctor'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='T-OutlookObjectives-IAppointment'></a>
## IAppointment `type`

##### Namespace

OutlookObjectives

##### Summary

Appointment Interface for the inspector wrapper.

<a name='P-OutlookObjectives-IAppointment-AppointmentType'></a>
### AppointmentType `property`

##### Summary

The type of appointment.

<a name='P-OutlookObjectives-IAppointment-FolderPath'></a>
### FolderPath `property`

##### Summary

The outlook folder path.

<a name='T-OutlookObjectives-IWAppointmentObjectivesDayReport'></a>
## IWAppointmentObjectivesDayReport `type`

##### Namespace

OutlookObjectives

##### Summary

IWAppointmentObjectivesDayReport class.

<a name='M-OutlookObjectives-IWAppointmentObjectivesDayReport-#ctor-Microsoft-Office-Interop-Outlook-Inspector,System-String,CommonObjectives-AppointmentType-'></a>
### #ctor(Inspector,folderPath,appointmentType) `constructor`

##### Summary

Initializes a new instance of the [IWAppointmentObjectivesDayReport](#T-OutlookObjectives-IWAppointmentObjectivesDayReport 'OutlookObjectives.IWAppointmentObjectivesDayReport') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Inspector | [Microsoft.Office.Interop.Outlook.Inspector](#T-Microsoft-Office-Interop-Outlook-Inspector 'Microsoft.Office.Interop.Outlook.Inspector') | Passes the Inspector of the appointment. |
| folderPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The Outlook folder path to the appointment. |
| appointmentType | [CommonObjectives.AppointmentType](#T-CommonObjectives-AppointmentType 'CommonObjectives.AppointmentType') | The type of appointment. |

<a name='P-OutlookObjectives-IWAppointmentObjectivesDayReport-Appointment'></a>
### Appointment `property`

##### Summary

A reference to the appointment object.

<a name='P-OutlookObjectives-IWAppointmentObjectivesDayReport-AppointmentType'></a>
### AppointmentType `property`

##### Summary

The type of appointment.

<a name='P-OutlookObjectives-IWAppointmentObjectivesDayReport-FolderPath'></a>
### FolderPath `property`

##### Summary

The Outlook path to the folder that contains the appointment.

<a name='P-OutlookObjectives-IWAppointmentObjectivesDayReport-Inspector'></a>
### Inspector `property`

##### Summary

A reference to the Inspector displaying the appointment.

<a name='M-OutlookObjectives-IWAppointmentObjectivesDayReport-Appointment_Close-System-Boolean@-'></a>
### Appointment_Close(cancel) `method`

##### Summary

Method to save the appointment when it is closed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancel | [System.Boolean@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean@ 'System.Boolean@') | This parameter is unused. |

<a name='M-OutlookObjectives-IWAppointmentObjectivesDayReport-InspectorWrapper_Close'></a>
### InspectorWrapper_Close() `method`

##### Summary

Method to remove the event handlers and remove this from the collection of inspectors.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-InTouch'></a>
## InTouch `type`

##### Namespace

OutlookObjectives

##### Summary

Class to hold the static objects and helper functions.

<a name='F-OutlookObjectives-InTouch-DpiX'></a>
### DpiX `constants`

##### Summary

Value to multiply the DPI X scale.

<a name='F-OutlookObjectives-InTouch-DpiY'></a>
### DpiY `constants`

##### Summary

Value to multiply the DPI Y scale.

<a name='F-OutlookObjectives-InTouch-RibbonHeight'></a>
### RibbonHeight `constants`

##### Summary

The height of the ribbon in pixels.

<a name='F-OutlookObjectives-InTouch-WorkItemVersion'></a>
### WorkItemVersion `constants`

##### Summary

Version number for the WorkItem.

<a name='P-OutlookObjectives-InTouch-ObjectivesArchiveFolder'></a>
### ObjectivesArchiveFolder `property`

##### Summary

The path to the Objectives archive folder.

<a name='P-OutlookObjectives-InTouch-ObjectivesRootFolder'></a>
### ObjectivesRootFolder `property`

##### Summary

The path to the Objectives root folder.

<a name='P-OutlookObjectives-InTouch-ObjectivesStorageFolder'></a>
### ObjectivesStorageFolder `property`

##### Summary

The path to the Objectives storage folder.

<a name='P-OutlookObjectives-InTouch-TaskManager'></a>
### TaskManager `property`

##### Summary

Initializes a new instance of the [TaskManager](#P-OutlookObjectives-InTouch-TaskManager 'OutlookObjectives.InTouch.TaskManager') class.

<a name='P-OutlookObjectives-InTouch-WorkTypes'></a>
### WorkTypes `property`

##### Summary

Dictionary of WorkTypes.

##### Remarks

These are the default WorkTypes to use if the Objective does not contain a similar WorkType.

<a name='M-OutlookObjectives-InTouch-CreateCSS'></a>
### CreateCSS() `method`

##### Summary

Creates a CSS file for use by the reports.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-InTouch-CreateObjective-System-String-'></a>
### CreateObjective(objectiveName) `method`

##### Summary

Create a new Objective.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| objectiveName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the new Objective. |

<a name='M-OutlookObjectives-InTouch-GetObjective-System-String-'></a>
### GetObjective(path) `method`

##### Summary

Get an Objective object from a path.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path to the objective. |

<a name='M-OutlookObjectives-InTouch-GetTimeStringFromMinutes-System-Int32-'></a>
### GetTimeStringFromMinutes(minutes) `method`

##### Summary

Gets a formatted time string from an int of minutes.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| minutes | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of minutes. |

<a name='M-OutlookObjectives-InTouch-SaveObjective-CommonObjectives-Objective-'></a>
### SaveObjective(objective) `method`

##### Summary

Saves and Objective object to file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| objective | [CommonObjectives.Objective](#T-CommonObjectives-Objective 'CommonObjectives.Objective') |  |

<a name='T-OutlookObjectives-Properties-Resources'></a>
## Resources `type`

##### Namespace

OutlookObjectives.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-OutlookObjectives-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-OutlookObjectives-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-OutlookObjectives-RibAppointment'></a>
## RibAppointment `type`

##### Namespace

OutlookObjectives

##### Summary

RibAppointment class for the Appointment ribbon.

<a name='M-OutlookObjectives-RibAppointment-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [RibAppointment](#T-OutlookObjectives-RibAppointment 'OutlookObjectives.RibAppointment') class.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-RibAppointment-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-RibAppointment-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-RibAppointment-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-RibAppointment-RibAppointment_Load-System-Object,Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs-'></a>
### RibAppointment_Load(sender,e) `method`

##### Summary

Create the Appointment ribbon.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs](#T-Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs 'Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs') | This parameter is unused. |

<a name='T-OutlookObjectives-RibExplorer'></a>
## RibExplorer `type`

##### Namespace

OutlookObjectives

##### Summary

Ribbon for the Explorer.

<a name='M-OutlookObjectives-RibExplorer-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [RibExplorer](#T-OutlookObjectives-RibExplorer 'OutlookObjectives.RibExplorer') class.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-RibExplorer-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-RibExplorer-ButtonNewObjective_Click-System-Object,Microsoft-Office-Tools-Ribbon-RibbonControlEventArgs-'></a>
### ButtonNewObjective_Click(sender,e) `method`

##### Summary

Event for the New Objective button.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs](#T-Microsoft-Office-Tools-Ribbon-RibbonControlEventArgs 'Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs') | Unused. |

<a name='M-OutlookObjectives-RibExplorer-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-RibExplorer-Explorer_FolderSwitch'></a>
### Explorer_FolderSwitch() `method`

##### Summary

Manage the folder switch event.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-RibExplorer-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-RibExplorer-RibExplorer_Load-System-Object,Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs-'></a>
### RibExplorer_Load(sender,e) `method`

##### Summary

Load event for the ribbon.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs](#T-Microsoft-Office-Tools-Ribbon-RibbonUIEventArgs 'Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs') | Unused. |

<a name='T-OutlookObjectives-TaskConvertVersion'></a>
## TaskConvertVersion `type`

##### Namespace

OutlookObjectives

##### Summary

Day Report Task to generate Objectives Day Reports.

<a name='M-OutlookObjectives-TaskConvertVersion-#ctor-System-Action-'></a>
### #ctor(callBack) `constructor`

##### Summary

Returns control back to the TaskManager.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callBack | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

<a name='M-OutlookObjectives-TaskConvertVersion-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

The starting point for the new process.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskConvertVersion-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsInRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments that fall in the range of the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskConvertVersion-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsWithinRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments within the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskConvertVersion-ProcessAppointments'></a>
### ProcessAppointments() `method`

##### Summary

Primary process to create a DayReport.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskConvertVersion-RunTask'></a>
### RunTask() `method`

##### Summary

Creates a thread to run the Task.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskDayReport'></a>
## TaskDayReport `type`

##### Namespace

OutlookObjectives

##### Summary

Day Report Task to generate Objectives Day Reports.

<a name='M-OutlookObjectives-TaskDayReport-#ctor-System-Action-'></a>
### #ctor(callBack) `constructor`

##### Summary

Returns control back to the TaskManager.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callBack | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

<a name='M-OutlookObjectives-TaskDayReport-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

The starting point for the new process.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-CreateHTML'></a>
### CreateHTML() `method`

##### Summary

Creates the HTML for the report.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-DrawApplicationsImage'></a>
### DrawApplicationsImage() `method`

##### Summary

Draw the applications graph.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-DrawDayBarImage'></a>
### DrawDayBarImage() `method`

##### Summary

Draws the Day Bar image.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-DrawObjectiveImage'></a>
### DrawObjectiveImage() `method`

##### Summary

Draw the objectives graph.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-DrawSystemTimeImage'></a>
### DrawSystemTimeImage() `method`

##### Summary

Draw the system time graph.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-FindDay'></a>
### FindDay() `method`

##### Summary

Find the day that is suitable to create the report for.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsInRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments that fall in the range of the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskDayReport-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsWithinRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments within the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskDayReport-ProcessAppointments'></a>
### ProcessAppointments() `method`

##### Summary

Primary process to create a DayReport.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskDayReport-ProcessSystemIdle-System-String-'></a>
### ProcessSystemIdle(json) `method`

##### Summary

Process the system idle data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-OutlookObjectives-TaskDayReport-ProcessSystemUptime-System-String-'></a>
### ProcessSystemUptime(json) `method`

##### Summary

Process the system time data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-OutlookObjectives-TaskDayReport-ProcessVisualStudio-System-String-'></a>
### ProcessVisualStudio(json) `method`

##### Summary

Process the Visual Studio data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-OutlookObjectives-TaskDayReport-RunTask'></a>
### RunTask() `method`

##### Summary

Creates a thread to run the Task.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskImportData'></a>
## TaskImportData `type`

##### Namespace

OutlookObjectives

##### Summary

Processes data files in the storage folder into appointment items.

<a name='M-OutlookObjectives-TaskImportData-#ctor-System-Action-'></a>
### #ctor(callBack) `constructor`

##### Summary

Initializes a new instance of the [TaskImportData](#T-OutlookObjectives-TaskImportData 'OutlookObjectives.TaskImportData') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callBack | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

<a name='M-OutlookObjectives-TaskImportData-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

The process to perform the data import.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskImportData-ImportSystemIdle-System-String-'></a>
### ImportSystemIdle(json) `method`

##### Summary

Converts the Idle event and stores it in an appointment item.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | JSON Data containing a idle event. |

<a name='M-OutlookObjectives-TaskImportData-ImportSystemSleep-System-String-'></a>
### ImportSystemSleep(json) `method`

##### Summary

Converts the sleep event and stores it in an appointment item.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | JSON Data containing a sleep event. |

<a name='M-OutlookObjectives-TaskImportData-ImportSystemUptime-System-String-'></a>
### ImportSystemUptime(json) `method`

##### Summary

Converts the Uptime event and stores it in an appointment item.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | JSON Data containing a Uptime event. |

<a name='M-OutlookObjectives-TaskImportData-ImportWorkItem-System-String-'></a>
### ImportWorkItem(json) `method`

##### Summary

Converts the WorkItem and stores it in an appointment item.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | JSON Data containing a WorkItem. |

<a name='M-OutlookObjectives-TaskImportData-ReadFiles'></a>
### ReadFiles() `method`

##### Summary

This method reads all the files and converts them to JSON.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskImportData-RunTask'></a>
### RunTask() `method`

##### Summary

Method to create and start a background thread to perform the task.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskManager'></a>
## TaskManager `type`

##### Namespace

OutlookObjectives

##### Summary

TaskManager manages the background tasks.

##### Remarks

The TaskManager is used to manage the background tasks that perform 
operations such as moving emails from the Inbox. It provides a queue to store tasks
and executes them one at a time.

<a name='M-OutlookObjectives-TaskManager-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [TaskManager](#T-OutlookObjectives-TaskManager 'OutlookObjectives.TaskManager') class.

##### Parameters

This constructor has no parameters.

<a name='P-OutlookObjectives-TaskManager-BackgroundTasks'></a>
### BackgroundTasks `property`

##### Summary

A queue of Task to be performed.

<a name='P-OutlookObjectives-TaskManager-CurrentAction'></a>
### CurrentAction `property`

##### Summary

The current action to be called when finished.

<a name='M-OutlookObjectives-TaskManager-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

Main loop for managing tasks.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-EnqueueConvertVersionTask'></a>
### EnqueueConvertVersionTask() `method`

##### Summary

Enqueues a Conversion Task.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-EnqueueDayReportTask'></a>
### EnqueueDayReportTask() `method`

##### Summary

Enqueues a Day Report Task.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-EnqueueImportDataTask'></a>
### EnqueueImportDataTask() `method`

##### Summary

Enqueues a Import Data Task.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-EnqueueMonthReportTask'></a>
### EnqueueMonthReportTask() `method`

##### Summary

Enqueues a Month Report Task.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-EnqueueWeekReportTask'></a>
### EnqueueWeekReportTask() `method`

##### Summary

Enqueues a Week Report Task.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskManager-TaskFinished'></a>
### TaskFinished() `method`

##### Summary

Callback for when the current task is finished.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskMonthReport'></a>
## TaskMonthReport `type`

##### Namespace

OutlookObjectives

##### Summary

Task to process Monthly totals.

<a name='M-OutlookObjectives-TaskMonthReport-#ctor-System-Action-'></a>
### #ctor(callBack) `constructor`

##### Summary

Initializes a new instance of the [TaskMonthReport](#T-OutlookObjectives-TaskMonthReport 'OutlookObjectives.TaskMonthReport') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callBack | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | The action to call when finished. |

<a name='M-OutlookObjectives-TaskMonthReport-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

Method to perform in the background.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskMonthReport-FindDay'></a>
### FindDay() `method`

##### Summary

Find the day that is suitable to create the report for.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskMonthReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsInRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments that fall in the range of the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskMonthReport-GetAppointmentsWithinRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsWithinRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments within the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskMonthReport-RunTask'></a>
### RunTask() `method`

##### Summary

Method to start the task.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskWeekReport'></a>
## TaskWeekReport `type`

##### Namespace

OutlookObjectives

##### Summary

Task to process weekly totals.

<a name='M-OutlookObjectives-TaskWeekReport-#ctor-System-Action-'></a>
### #ctor(callBack) `constructor`

##### Summary

Initializes a new instance of the [TaskWeekReport](#T-OutlookObjectives-TaskWeekReport 'OutlookObjectives.TaskWeekReport') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callBack | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | The action to call when finished. |

<a name='M-OutlookObjectives-TaskWeekReport-BackgroundProcess'></a>
### BackgroundProcess() `method`

##### Summary

Method to start in the background.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskWeekReport-CreateHTML'></a>
### CreateHTML() `method`

##### Summary

Creates the HTML for the report.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskWeekReport-FindDay'></a>
### FindDay() `method`

##### Summary

Find the day that is suitable to create the report for.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskWeekReport-GetAppointmentsInRange-Microsoft-Office-Interop-Outlook-Folder,System-DateTime,System-DateTime-'></a>
### GetAppointmentsInRange(folder,startTime,endTime) `method`

##### Summary

Get the appointments that fall in the range of the timespan.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [Microsoft.Office.Interop.Outlook.Folder](#T-Microsoft-Office-Interop-Outlook-Folder 'Microsoft.Office.Interop.Outlook.Folder') |  |
| startTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |
| endTime | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

<a name='M-OutlookObjectives-TaskWeekReport-GetDays'></a>
### GetDays() `method`

##### Summary

Get the DayReports for the week.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskWeekReport-GetWorkItemFromDays'></a>
### GetWorkItemFromDays() `method`

##### Summary

Get all the work items from the days.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-TaskWeekReport-RunTask'></a>
### RunTask() `method`

##### Summary

Method to start the process.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-ThisAddIn'></a>
## ThisAddIn `type`

##### Namespace

OutlookObjectives

##### Summary

Microsoft Outlook VSTO AddIn to track Objectives.

<a name='M-OutlookObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Outlook-Factory,System-IServiceProvider-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='P-OutlookObjectives-ThisAddIn-IAppointments'></a>
### IAppointments `property`

##### Summary

Dictionary to hold the wrappers for Appointments.

<a name='M-OutlookObjectives-ThisAddIn-BeginInitialization'></a>
### BeginInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-BindToData'></a>
### BindToData() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-CheckSystemRequirements'></a>
### CheckSystemRequirements() `method`

##### Summary

Checks the system requirements.
Required: registry settings.
Required: Root Folder.
Required: Storage folder.
Required: Objectives Calendar.
Required: System Calendar.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-EndInitialization'></a>
### EndInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-FinishInitialization'></a>
### FinishInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-Initialize'></a>
### Initialize() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-InitializeCachedData'></a>
### InitializeCachedData() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-InitializeComponents'></a>
### InitializeComponents() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-InitializeControls'></a>
### InitializeControls() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-InitializeData'></a>
### InitializeData() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-InitializeDataBindings'></a>
### InitializeDataBindings() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-Inspectors_NewInspector-Microsoft-Office-Interop-Outlook-Inspector-'></a>
### Inspectors_NewInspector(inspector) `method`

##### Summary

Event when new inspectors are opened.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inspector | [Microsoft.Office.Interop.Outlook.Inspector](#T-Microsoft-Office-Interop-Outlook-Inspector 'Microsoft.Office.Interop.Outlook.Inspector') | The inspector to manage. |

<a name='M-OutlookObjectives-ThisAddIn-InternalStartup'></a>
### InternalStartup() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-IsCached-System-String-'></a>
### IsCached() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-NeedsFill-System-String-'></a>
### NeedsFill() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-OnMainTimerEvent-System-Object,System-Timers-ElapsedEventArgs-'></a>
### OnMainTimerEvent(source,e) `method`

##### Summary

Primary timer event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.Timers.ElapsedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Timers.ElapsedEventArgs 'System.Timers.ElapsedEventArgs') | Unused. |

<a name='M-OutlookObjectives-ThisAddIn-OnShutdown'></a>
### OnShutdown() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-ShowSettings'></a>
### ShowSettings() `method`

##### Summary

Shows the Settings Form.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-StartCaching-System-String-'></a>
### StartCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-StopCaching-System-String-'></a>
### StopCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs-'></a>
### ThisAddIn_Startup(sender,e) `method`

##### Summary

Primary entry for the AddIn.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='T-OutlookObjectives-ThisFormRegionCollection'></a>
## ThisFormRegionCollection `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-ThisFormRegionCollection-#ctor-System-Collections-Generic-IList{Microsoft-Office-Tools-Outlook-IFormRegion}-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='T-OutlookObjectives-ThisRibbonCollection'></a>
## ThisRibbonCollection `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='T-OutlookObjectives-UCObjectives'></a>
## UCObjectives `type`

##### Namespace

OutlookObjectives

##### Summary

A User Control to be used as the UI for the Objectives Pane.

<a name='M-OutlookObjectives-UCObjectives-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='F-OutlookObjectives-UCObjectives-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-UCObjectives-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-UCObjectives-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-UCObjectives-ListObjectives_SelectedIndexChanged-System-Object,System-EventArgs-'></a>
### ListObjectives_SelectedIndexChanged(sender,e) `method`

##### Summary

Mange the change of selection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-UCObjectives-MenuActivate_Click-System-Object,System-EventArgs-'></a>
### MenuActivate_Click(sender,e) `method`

##### Summary

Re-activate the Objective from archive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-UCObjectives-MenuArchive_Click-System-Object,System-EventArgs-'></a>
### MenuArchive_Click(sender,e) `method`

##### Summary

Archive the Objective.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-UCObjectives-MenuRates_Click-System-Object,System-EventArgs-'></a>
### MenuRates_Click(sender,e) `method`

##### Summary

Display the Rates and Costs for the Objective.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-UCObjectives-UCObjectives_Load-System-Object,System-EventArgs-'></a>
### UCObjectives_Load(sender,e) `method`

##### Summary

Fills the UI with Objectives.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-OutlookObjectives-UCObjectives-UCObjectives_Resize-System-Object,System-EventArgs-'></a>
### UCObjectives_Resize(sender,e) `method`

##### Summary

Manage the control being resized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='T-OutlookObjectives-WindowFormRegionCollection'></a>
## WindowFormRegionCollection `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-WindowFormRegionCollection-#ctor-System-Collections-Generic-IList{Microsoft-Office-Tools-Outlook-IFormRegion}-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.
