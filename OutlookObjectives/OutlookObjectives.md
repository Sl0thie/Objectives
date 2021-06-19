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
  - [components](#F-OutlookObjectives-FormChangeWorkType-components 'OutlookObjectives.FormChangeWorkType.components')
  - [Dispose(disposing)](#M-OutlookObjectives-FormChangeWorkType-Dispose-System-Boolean- 'OutlookObjectives.FormChangeWorkType.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FormChangeWorkType-InitializeComponent 'OutlookObjectives.FormChangeWorkType.InitializeComponent')
- [FormCreateObjective](#T-OutlookObjectives-FormCreateObjective 'OutlookObjectives.FormCreateObjective')
  - [components](#F-OutlookObjectives-FormCreateObjective-components 'OutlookObjectives.FormCreateObjective.components')
  - [Dispose(disposing)](#M-OutlookObjectives-FormCreateObjective-Dispose-System-Boolean- 'OutlookObjectives.FormCreateObjective.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FormCreateObjective-InitializeComponent 'OutlookObjectives.FormCreateObjective.InitializeComponent')
- [FormObjectiveRates](#T-OutlookObjectives-FormObjectiveRates 'OutlookObjectives.FormObjectiveRates')
  - [components](#F-OutlookObjectives-FormObjectiveRates-components 'OutlookObjectives.FormObjectiveRates.components')
  - [Objective](#P-OutlookObjectives-FormObjectiveRates-Objective 'OutlookObjectives.FormObjectiveRates.Objective')
  - [Dispose(disposing)](#M-OutlookObjectives-FormObjectiveRates-Dispose-System-Boolean- 'OutlookObjectives.FormObjectiveRates.Dispose(System.Boolean)')
  - [FormObjectiveRates_FormClosing(sender,e)](#M-OutlookObjectives-FormObjectiveRates-FormObjectiveRates_FormClosing-System-Object,System-Windows-Forms-FormClosingEventArgs- 'OutlookObjectives.FormObjectiveRates.FormObjectiveRates_FormClosing(System.Object,System.Windows.Forms.FormClosingEventArgs)')
  - [InitializeComponent()](#M-OutlookObjectives-FormObjectiveRates-InitializeComponent 'OutlookObjectives.FormObjectiveRates.InitializeComponent')
  - [ListWorkTypes_DoubleClick(sender,e)](#M-OutlookObjectives-FormObjectiveRates-ListWorkTypes_DoubleClick-System-Object,System-EventArgs- 'OutlookObjectives.FormObjectiveRates.ListWorkTypes_DoubleClick(System.Object,System.EventArgs)')
  - [SetupControl()](#M-OutlookObjectives-FormObjectiveRates-SetupControl 'OutlookObjectives.FormObjectiveRates.SetupControl')
- [FormSettings](#T-OutlookObjectives-FormSettings 'OutlookObjectives.FormSettings')
  - [components](#F-OutlookObjectives-FormSettings-components 'OutlookObjectives.FormSettings.components')
  - [Dispose(disposing)](#M-OutlookObjectives-FormSettings-Dispose-System-Boolean- 'OutlookObjectives.FormSettings.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-FormSettings-InitializeComponent 'OutlookObjectives.FormSettings.InitializeComponent')
- [Globals](#T-OutlookObjectives-Globals 'OutlookObjectives.Globals')
  - [#ctor()](#M-OutlookObjectives-Globals-#ctor 'OutlookObjectives.Globals.#ctor')
- [Resources](#T-OutlookObjectives-Properties-Resources 'OutlookObjectives.Properties.Resources')
  - [Culture](#P-OutlookObjectives-Properties-Resources-Culture 'OutlookObjectives.Properties.Resources.Culture')
  - [ResourceManager](#P-OutlookObjectives-Properties-Resources-ResourceManager 'OutlookObjectives.Properties.Resources.ResourceManager')
- [RibAppointment](#T-OutlookObjectives-RibAppointment 'OutlookObjectives.RibAppointment')
  - [components](#F-OutlookObjectives-RibAppointment-components 'OutlookObjectives.RibAppointment.components')
  - [Dispose(disposing)](#M-OutlookObjectives-RibAppointment-Dispose-System-Boolean- 'OutlookObjectives.RibAppointment.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-RibAppointment-InitializeComponent 'OutlookObjectives.RibAppointment.InitializeComponent')
- [RibExplorer](#T-OutlookObjectives-RibExplorer 'OutlookObjectives.RibExplorer')
  - [components](#F-OutlookObjectives-RibExplorer-components 'OutlookObjectives.RibExplorer.components')
  - [Dispose(disposing)](#M-OutlookObjectives-RibExplorer-Dispose-System-Boolean- 'OutlookObjectives.RibExplorer.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-RibExplorer-InitializeComponent 'OutlookObjectives.RibExplorer.InitializeComponent')
- [TaskDayReport](#T-OutlookObjectives-TaskDayReport 'OutlookObjectives.TaskDayReport')
  - [CreateHTML()](#M-OutlookObjectives-TaskDayReport-CreateHTML 'OutlookObjectives.TaskDayReport.CreateHTML')
- [ThisAddIn](#T-OutlookObjectives-ThisAddIn 'OutlookObjectives.ThisAddIn')
  - [#ctor()](#M-OutlookObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Outlook-Factory,System-IServiceProvider- 'OutlookObjectives.ThisAddIn.#ctor(Microsoft.Office.Tools.Outlook.Factory,System.IServiceProvider)')
  - [BeginInitialization()](#M-OutlookObjectives-ThisAddIn-BeginInitialization 'OutlookObjectives.ThisAddIn.BeginInitialization')
  - [BindToData()](#M-OutlookObjectives-ThisAddIn-BindToData 'OutlookObjectives.ThisAddIn.BindToData')
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
  - [components](#F-OutlookObjectives-UCObjectives-components 'OutlookObjectives.UCObjectives.components')
  - [Dispose(disposing)](#M-OutlookObjectives-UCObjectives-Dispose-System-Boolean- 'OutlookObjectives.UCObjectives.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-OutlookObjectives-UCObjectives-InitializeComponent 'OutlookObjectives.UCObjectives.InitializeComponent')
  - [UCObjectives_Load(sender,e)](#M-OutlookObjectives-UCObjectives-UCObjectives_Load-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.UCObjectives_Load(System.Object,System.EventArgs)')
  - [UCObjectives_Resize(sender,e)](#M-OutlookObjectives-UCObjectives-UCObjectives_Resize-System-Object,System-EventArgs- 'OutlookObjectives.UCObjectives.UCObjectives_Resize(System.Object,System.EventArgs)')
- [WindowFormRegionCollection](#T-OutlookObjectives-WindowFormRegionCollection 'OutlookObjectives.WindowFormRegionCollection')
  - [#ctor()](#M-OutlookObjectives-WindowFormRegionCollection-#ctor-System-Collections-Generic-IList{Microsoft-Office-Tools-Outlook-IFormRegion}- 'OutlookObjectives.WindowFormRegionCollection.#ctor(System.Collections.Generic.IList{Microsoft.Office.Tools.Outlook.IFormRegion})')

<a name='T-OutlookObjectives-FRObjectivesDayReport'></a>
## FRObjectivesDayReport `type`

##### Namespace

OutlookObjectives

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

<a name='F-OutlookObjectives-FormChangeWorkType-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-FormChangeWorkType-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-FormChangeWorkType-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-FormCreateObjective'></a>
## FormCreateObjective `type`

##### Namespace

OutlookObjectives

<a name='F-OutlookObjectives-FormCreateObjective-components'></a>
### components `constants`

##### Summary

Required designer variable.

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

<a name='M-OutlookObjectives-FormSettings-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-Globals'></a>
## Globals `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-Globals-#ctor'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

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

<a name='T-OutlookObjectives-RibExplorer'></a>
## RibExplorer `type`

##### Namespace

OutlookObjectives

<a name='F-OutlookObjectives-RibExplorer-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-OutlookObjectives-RibExplorer-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-OutlookObjectives-RibExplorer-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-OutlookObjectives-TaskDayReport'></a>
## TaskDayReport `type`

##### Namespace

OutlookObjectives

<a name='M-OutlookObjectives-TaskDayReport-CreateHTML'></a>
### CreateHTML() `method`

##### Summary

Creates the HTML for the report.

##### Returns



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

<a name='M-OutlookObjectives-ThisAddIn-BeginInitialization'></a>
### BeginInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-OutlookObjectives-ThisAddIn-BindToData'></a>
### BindToData() `method`

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
