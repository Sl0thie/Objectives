# OutlookObjectives #

#### Field UCObjectives.components

 Required designer variable. 



---
#### Method UCObjectives.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method UCObjectives.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Field FormChangeWorkType.components

 Required designer variable. 



---
#### Method FormChangeWorkType.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method FormChangeWorkType.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Field FormCreateObjective.components

 Required designer variable. 



---
#### Method FormCreateObjective.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method FormCreateObjective.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
## Type FormObjectiveRates

 Form to manage the Objectives Rates and Costs. 



---
#### Property FormObjectiveRates.Objective

 The objective to manage. 



---
#### Method FormObjectiveRates.SetupControl

 Setup the form to suit the supplied objective. 



---
#### Method FormObjectiveRates.ListWorkTypes_DoubleClick(System.Object,System.EventArgs)

 Show the Change WorkType form when an item is double clicked. 

|Name | Description |
|-----|------|
|sender: |Unused.|
|e: |Unused.|


---
#### Method FormObjectiveRates.FormObjectiveRates_FormClosing(System.Object,System.Windows.Forms.FormClosingEventArgs)

 Save the objective when the form closes. 

|Name | Description |
|-----|------|
|sender: |Unused.|
|e: |Unused.|


---
#### Field FormObjectiveRates.components

 Required designer variable. 



---
#### Method FormObjectiveRates.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method FormObjectiveRates.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Field FormSettings.components

 Required designer variable. 



---
#### Method FormSettings.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method FormSettings.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
## Type Properties.Resources

 A strongly-typed resource class, for looking up localized strings, etc. 



---
#### Property Properties.Resources.ResourceManager

 Returns the cached ResourceManager instance used by this class. 



---
#### Property Properties.Resources.Culture

 Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class. 



---
#### Method FRObjectivesDayReport.FRObjectivesDayReport_FormRegionShowing(System.Object,System.EventArgs)



|Name | Description |
|-----|------|
|sender: |Unused.|
|e: |Unused.|


---
#### Field FRObjectivesDayReport.components

 Required designer variable. 



---
#### Method FRObjectivesDayReport.Dispose(System.Boolean)

 Clean up any resources being used. 



---
#### Method FRObjectivesDayReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Method FRObjectivesDayReport.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
## Type WindowFormRegionCollection



---
#### Method WindowFormRegionCollection.#ctor(System.Collections.Generic.IList{Microsoft.Office.Tools.Outlook.IFormRegion})



---
#### Field FRObjectivesMonthReport.components

 Required designer variable. 



---
#### Method FRObjectivesMonthReport.Dispose(System.Boolean)

 Clean up any resources being used. 



---
#### Method FRObjectivesMonthReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Method FRObjectivesMonthReport.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Field FRObjectivesWeekReport.components

 Required designer variable. 



---
#### Method FRObjectivesWeekReport.Dispose(System.Boolean)

 Clean up any resources being used. 



---
#### Method FRObjectivesWeekReport.InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest,Microsoft.Office.Tools.Outlook.Factory)

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Method FRObjectivesWeekReport.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Field RibAppointment.components

 Required designer variable. 



---
#### Method RibAppointment.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method RibAppointment.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
## Type ThisRibbonCollection



---
#### Method ThisRibbonCollection.#ctor(Microsoft.Office.Tools.Ribbon.RibbonFactory)



---
#### Field RibExplorer.components

 Required designer variable. 



---
#### Method RibExplorer.Dispose(System.Boolean)

 Clean up any resources being used. 

|Name | Description |
|-----|------|
|disposing: |true if managed resources should be disposed; otherwise, false.|


---
#### Method RibExplorer.InitializeComponent

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Method TaskDayReport.CreateHTML

 Creates the HTML for the report. 

**Returns**: 



---
## Type ThisAddIn

 Microsoft Outlook VSTO AddIn to track Objectives. 



---
#### Method ThisAddIn.ThisAddIn_Startup(System.Object,System.EventArgs)

 Primary entry for the AddIn. 

|Name | Description |
|-----|------|
|sender: ||
|e: ||


---
#### Method ThisAddIn.Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector)

 Event when new inspectors are opened. 

|Name | Description |
|-----|------|
|inspector: |The inspector to manage.|


---
#### Method ThisAddIn.OnMainTimerEvent(System.Object,System.Timers.ElapsedEventArgs)

 Primary timer event. 

|Name | Description |
|-----|------|
|source: |Unused.|
|e: |Unused.|


---
#### Method ThisAddIn.ShowSettings

 Shows the Settings Form. 



---
#### Method ThisAddIn.InternalStartup

 Required method for Designer support - do not modify the contents of this method with the code editor. 



---
#### Method ThisAddIn.#ctor(Microsoft.Office.Tools.Outlook.Factory,System.IServiceProvider)



---
#### Method ThisAddIn.Initialize



---
#### Method ThisAddIn.FinishInitialization



---
#### Method ThisAddIn.InitializeDataBindings



---
#### Method ThisAddIn.InitializeCachedData



---
#### Method ThisAddIn.InitializeData



---
#### Method ThisAddIn.BindToData



---
#### Method ThisAddIn.StartCaching(System.String)



---
#### Method ThisAddIn.StopCaching(System.String)



---
#### Method ThisAddIn.IsCached(System.String)



---
#### Method ThisAddIn.BeginInitialization



---
#### Method ThisAddIn.EndInitialization



---
#### Method ThisAddIn.InitializeControls



---
#### Method ThisAddIn.InitializeComponents



---
#### Method ThisAddIn.NeedsFill(System.String)



---
#### Method ThisAddIn.OnShutdown



---
## Type Globals



---
#### Method Globals.#ctor



---
## Type ThisFormRegionCollection



---
#### Method ThisFormRegionCollection.#ctor(System.Collections.Generic.IList{Microsoft.Office.Tools.Outlook.IFormRegion})



---


