<a name='assembly'></a>
# ExcelObjectives

## Contents

- [Globals](#T-ExcelObjectives-Globals 'ExcelObjectives.Globals')
  - [#ctor()](#M-ExcelObjectives-Globals-#ctor 'ExcelObjectives.Globals.#ctor')
- [Resources](#T-ExcelObjectives-Properties-Resources 'ExcelObjectives.Properties.Resources')
  - [Culture](#P-ExcelObjectives-Properties-Resources-Culture 'ExcelObjectives.Properties.Resources.Culture')
  - [ResourceManager](#P-ExcelObjectives-Properties-Resources-ResourceManager 'ExcelObjectives.Properties.Resources.ResourceManager')
- [ThisAddIn](#T-ExcelObjectives-ThisAddIn 'ExcelObjectives.ThisAddIn')
  - [#ctor()](#M-ExcelObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Excel-ApplicationFactory,System-IServiceProvider- 'ExcelObjectives.ThisAddIn.#ctor(Microsoft.Office.Tools.Excel.ApplicationFactory,System.IServiceProvider)')
  - [AddWorkbook(workbook)](#M-ExcelObjectives-ThisAddIn-AddWorkbook-Microsoft-Office-Interop-Excel-Workbook- 'ExcelObjectives.ThisAddIn.AddWorkbook(Microsoft.Office.Interop.Excel.Workbook)')
  - [Application_WorkbookActivate(workbook)](#M-ExcelObjectives-ThisAddIn-Application_WorkbookActivate-Microsoft-Office-Interop-Excel-Workbook- 'ExcelObjectives.ThisAddIn.Application_WorkbookActivate(Microsoft.Office.Interop.Excel.Workbook)')
  - [Application_WorkbookBeforeClose(workbook,Cancel)](#M-ExcelObjectives-ThisAddIn-Application_WorkbookBeforeClose-Microsoft-Office-Interop-Excel-Workbook,System-Boolean@- 'ExcelObjectives.ThisAddIn.Application_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook,System.Boolean@)')
  - [Application_WorkbookDeactivate(workbook)](#M-ExcelObjectives-ThisAddIn-Application_WorkbookDeactivate-Microsoft-Office-Interop-Excel-Workbook- 'ExcelObjectives.ThisAddIn.Application_WorkbookDeactivate(Microsoft.Office.Interop.Excel.Workbook)')
  - [Application_WorkbookOpen(workbook)](#M-ExcelObjectives-ThisAddIn-Application_WorkbookOpen-Microsoft-Office-Interop-Excel-Workbook- 'ExcelObjectives.ThisAddIn.Application_WorkbookOpen(Microsoft.Office.Interop.Excel.Workbook)')
  - [BeginInitialization()](#M-ExcelObjectives-ThisAddIn-BeginInitialization 'ExcelObjectives.ThisAddIn.BeginInitialization')
  - [BindToData()](#M-ExcelObjectives-ThisAddIn-BindToData 'ExcelObjectives.ThisAddIn.BindToData')
  - [CheckWorkbooks()](#M-ExcelObjectives-ThisAddIn-CheckWorkbooks 'ExcelObjectives.ThisAddIn.CheckWorkbooks')
  - [EndInitialization()](#M-ExcelObjectives-ThisAddIn-EndInitialization 'ExcelObjectives.ThisAddIn.EndInitialization')
  - [FinishInitialization()](#M-ExcelObjectives-ThisAddIn-FinishInitialization 'ExcelObjectives.ThisAddIn.FinishInitialization')
  - [Initialize()](#M-ExcelObjectives-ThisAddIn-Initialize 'ExcelObjectives.ThisAddIn.Initialize')
  - [InitializeCachedData()](#M-ExcelObjectives-ThisAddIn-InitializeCachedData 'ExcelObjectives.ThisAddIn.InitializeCachedData')
  - [InitializeComponents()](#M-ExcelObjectives-ThisAddIn-InitializeComponents 'ExcelObjectives.ThisAddIn.InitializeComponents')
  - [InitializeControls()](#M-ExcelObjectives-ThisAddIn-InitializeControls 'ExcelObjectives.ThisAddIn.InitializeControls')
  - [InitializeData()](#M-ExcelObjectives-ThisAddIn-InitializeData 'ExcelObjectives.ThisAddIn.InitializeData')
  - [InitializeDataBindings()](#M-ExcelObjectives-ThisAddIn-InitializeDataBindings 'ExcelObjectives.ThisAddIn.InitializeDataBindings')
  - [InternalStartup()](#M-ExcelObjectives-ThisAddIn-InternalStartup 'ExcelObjectives.ThisAddIn.InternalStartup')
  - [IsCached()](#M-ExcelObjectives-ThisAddIn-IsCached-System-String- 'ExcelObjectives.ThisAddIn.IsCached(System.String)')
  - [NeedsFill()](#M-ExcelObjectives-ThisAddIn-NeedsFill-System-String- 'ExcelObjectives.ThisAddIn.NeedsFill(System.String)')
  - [OnShutdown()](#M-ExcelObjectives-ThisAddIn-OnShutdown 'ExcelObjectives.ThisAddIn.OnShutdown')
  - [RemoveWorkbook(path)](#M-ExcelObjectives-ThisAddIn-RemoveWorkbook-System-String- 'ExcelObjectives.ThisAddIn.RemoveWorkbook(System.String)')
  - [SaveData(workItem)](#M-ExcelObjectives-ThisAddIn-SaveData-CommonObjectives-WorkItem- 'ExcelObjectives.ThisAddIn.SaveData(CommonObjectives.WorkItem)')
  - [StartCaching()](#M-ExcelObjectives-ThisAddIn-StartCaching-System-String- 'ExcelObjectives.ThisAddIn.StartCaching(System.String)')
  - [StopCaching()](#M-ExcelObjectives-ThisAddIn-StopCaching-System-String- 'ExcelObjectives.ThisAddIn.StopCaching(System.String)')
  - [ThisAddIn_Startup(sender,e)](#M-ExcelObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs- 'ExcelObjectives.ThisAddIn.ThisAddIn_Startup(System.Object,System.EventArgs)')
- [ThisRibbonCollection](#T-ExcelObjectives-ThisRibbonCollection 'ExcelObjectives.ThisRibbonCollection')
  - [#ctor()](#M-ExcelObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory- 'ExcelObjectives.ThisRibbonCollection.#ctor(Microsoft.Office.Tools.Ribbon.RibbonFactory)')

<a name='T-ExcelObjectives-Globals'></a>
## Globals `type`

##### Namespace

ExcelObjectives

<a name='M-ExcelObjectives-Globals-#ctor'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='T-ExcelObjectives-Properties-Resources'></a>
## Resources `type`

##### Namespace

ExcelObjectives.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-ExcelObjectives-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-ExcelObjectives-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-ExcelObjectives-ThisAddIn'></a>
## ThisAddIn `type`

##### Namespace

ExcelObjectives

##### Summary

Excel VSTO AddIn to track document times.

<a name='M-ExcelObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Excel-ApplicationFactory,System-IServiceProvider-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-AddWorkbook-Microsoft-Office-Interop-Excel-Workbook-'></a>
### AddWorkbook(workbook) `method`

##### Summary

Adds a workbook to the dictionary.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [Microsoft.Office.Interop.Excel.Workbook](#T-Microsoft-Office-Interop-Excel-Workbook 'Microsoft.Office.Interop.Excel.Workbook') |  |

<a name='M-ExcelObjectives-ThisAddIn-Application_WorkbookActivate-Microsoft-Office-Interop-Excel-Workbook-'></a>
### Application_WorkbookActivate(workbook) `method`

##### Summary

Event handler for when the workbook is activated.
Not currently implemented.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [Microsoft.Office.Interop.Excel.Workbook](#T-Microsoft-Office-Interop-Excel-Workbook 'Microsoft.Office.Interop.Excel.Workbook') |  |

<a name='M-ExcelObjectives-ThisAddIn-Application_WorkbookBeforeClose-Microsoft-Office-Interop-Excel-Workbook,System-Boolean@-'></a>
### Application_WorkbookBeforeClose(workbook,Cancel) `method`

##### Summary

Event handler for when the workbook is closed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [Microsoft.Office.Interop.Excel.Workbook](#T-Microsoft-Office-Interop-Excel-Workbook 'Microsoft.Office.Interop.Excel.Workbook') |  |
| Cancel | [System.Boolean@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean@ 'System.Boolean@') |  |

<a name='M-ExcelObjectives-ThisAddIn-Application_WorkbookDeactivate-Microsoft-Office-Interop-Excel-Workbook-'></a>
### Application_WorkbookDeactivate(workbook) `method`

##### Summary

Event handler for when the workbook is deactivated.
Not currently implemented.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [Microsoft.Office.Interop.Excel.Workbook](#T-Microsoft-Office-Interop-Excel-Workbook 'Microsoft.Office.Interop.Excel.Workbook') |  |

<a name='M-ExcelObjectives-ThisAddIn-Application_WorkbookOpen-Microsoft-Office-Interop-Excel-Workbook-'></a>
### Application_WorkbookOpen(workbook) `method`

##### Summary

Event handler for when the workbook is opened.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [Microsoft.Office.Interop.Excel.Workbook](#T-Microsoft-Office-Interop-Excel-Workbook 'Microsoft.Office.Interop.Excel.Workbook') |  |

<a name='M-ExcelObjectives-ThisAddIn-BeginInitialization'></a>
### BeginInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-BindToData'></a>
### BindToData() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-CheckWorkbooks'></a>
### CheckWorkbooks() `method`

##### Summary

Check the workbooks against the WorkItems.

##### Parameters

This method has no parameters.

##### Remarks

Testing the events seems to exposed some faults. 
To accommodate this the method first checks all workbooks against the work items.
Then it checks all the work items against the workbooks.
A secondary function is that it checks if the workbooks have been active.

<a name='M-ExcelObjectives-ThisAddIn-EndInitialization'></a>
### EndInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-FinishInitialization'></a>
### FinishInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-Initialize'></a>
### Initialize() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InitializeCachedData'></a>
### InitializeCachedData() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InitializeComponents'></a>
### InitializeComponents() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InitializeControls'></a>
### InitializeControls() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InitializeData'></a>
### InitializeData() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InitializeDataBindings'></a>
### InitializeDataBindings() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-InternalStartup'></a>
### InternalStartup() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-IsCached-System-String-'></a>
### IsCached() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-NeedsFill-System-String-'></a>
### NeedsFill() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-OnShutdown'></a>
### OnShutdown() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-RemoveWorkbook-System-String-'></a>
### RemoveWorkbook(path) `method`

##### Summary

Removes a workbook from the dictionary.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path to the workbook. |

<a name='M-ExcelObjectives-ThisAddIn-SaveData-CommonObjectives-WorkItem-'></a>
### SaveData(workItem) `method`

##### Summary

Save the data to the storage folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workItem | [CommonObjectives.WorkItem](#T-CommonObjectives-WorkItem 'CommonObjectives.WorkItem') |  |

<a name='M-ExcelObjectives-ThisAddIn-StartCaching-System-String-'></a>
### StartCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-StopCaching-System-String-'></a>
### StopCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-ExcelObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs-'></a>
### ThisAddIn_Startup(sender,e) `method`

##### Summary

The startup event for the AddIn.
WARNING: This may not start before documents are opened.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='T-ExcelObjectives-ThisRibbonCollection'></a>
## ThisRibbonCollection `type`

##### Namespace

ExcelObjectives

<a name='M-ExcelObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.
