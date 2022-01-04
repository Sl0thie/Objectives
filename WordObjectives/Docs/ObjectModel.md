<a name='assembly'></a>
# WordObjectives

## Contents

- [Globals](#T-WordObjectives-Globals 'WordObjectives.Globals')
  - [#ctor()](#M-WordObjectives-Globals-#ctor 'WordObjectives.Globals.#ctor')
- [Resources](#T-WordObjectives-Properties-Resources 'WordObjectives.Properties.Resources')
  - [Culture](#P-WordObjectives-Properties-Resources-Culture 'WordObjectives.Properties.Resources.Culture')
  - [ResourceManager](#P-WordObjectives-Properties-Resources-ResourceManager 'WordObjectives.Properties.Resources.ResourceManager')
- [ThisAddIn](#T-WordObjectives-ThisAddIn 'WordObjectives.ThisAddIn')
  - [#ctor()](#M-WordObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Word-ApplicationFactory,System-IServiceProvider- 'WordObjectives.ThisAddIn.#ctor(Microsoft.Office.Tools.Word.ApplicationFactory,System.IServiceProvider)')
  - [AddDocument(doc)](#M-WordObjectives-ThisAddIn-AddDocument-Microsoft-Office-Interop-Word-Document- 'WordObjectives.ThisAddIn.AddDocument(Microsoft.Office.Interop.Word.Document)')
  - [Application_DocumentBeforeClose(doc,cancel)](#M-WordObjectives-ThisAddIn-Application_DocumentBeforeClose-Microsoft-Office-Interop-Word-Document,System-Boolean@- 'WordObjectives.ThisAddIn.Application_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document,System.Boolean@)')
  - [Application_DocumentChange()](#M-WordObjectives-ThisAddIn-Application_DocumentChange 'WordObjectives.ThisAddIn.Application_DocumentChange')
  - [Application_DocumentOpen(doc)](#M-WordObjectives-ThisAddIn-Application_DocumentOpen-Microsoft-Office-Interop-Word-Document- 'WordObjectives.ThisAddIn.Application_DocumentOpen(Microsoft.Office.Interop.Word.Document)')
  - [BeginInitialization()](#M-WordObjectives-ThisAddIn-BeginInitialization 'WordObjectives.ThisAddIn.BeginInitialization')
  - [BindToData()](#M-WordObjectives-ThisAddIn-BindToData 'WordObjectives.ThisAddIn.BindToData')
  - [CheckDocuments()](#M-WordObjectives-ThisAddIn-CheckDocuments 'WordObjectives.ThisAddIn.CheckDocuments')
  - [EndInitialization()](#M-WordObjectives-ThisAddIn-EndInitialization 'WordObjectives.ThisAddIn.EndInitialization')
  - [FinishInitialization()](#M-WordObjectives-ThisAddIn-FinishInitialization 'WordObjectives.ThisAddIn.FinishInitialization')
  - [Initialize()](#M-WordObjectives-ThisAddIn-Initialize 'WordObjectives.ThisAddIn.Initialize')
  - [InitializeCachedData()](#M-WordObjectives-ThisAddIn-InitializeCachedData 'WordObjectives.ThisAddIn.InitializeCachedData')
  - [InitializeComponents()](#M-WordObjectives-ThisAddIn-InitializeComponents 'WordObjectives.ThisAddIn.InitializeComponents')
  - [InitializeControls()](#M-WordObjectives-ThisAddIn-InitializeControls 'WordObjectives.ThisAddIn.InitializeControls')
  - [InitializeData()](#M-WordObjectives-ThisAddIn-InitializeData 'WordObjectives.ThisAddIn.InitializeData')
  - [InitializeDataBindings()](#M-WordObjectives-ThisAddIn-InitializeDataBindings 'WordObjectives.ThisAddIn.InitializeDataBindings')
  - [InternalStartup()](#M-WordObjectives-ThisAddIn-InternalStartup 'WordObjectives.ThisAddIn.InternalStartup')
  - [IsCached()](#M-WordObjectives-ThisAddIn-IsCached-System-String- 'WordObjectives.ThisAddIn.IsCached(System.String)')
  - [NeedsFill()](#M-WordObjectives-ThisAddIn-NeedsFill-System-String- 'WordObjectives.ThisAddIn.NeedsFill(System.String)')
  - [OnShutdown()](#M-WordObjectives-ThisAddIn-OnShutdown 'WordObjectives.ThisAddIn.OnShutdown')
  - [RefreshTimer_Tick(stateInfo)](#M-WordObjectives-ThisAddIn-RefreshTimer_Tick-System-Object- 'WordObjectives.ThisAddIn.RefreshTimer_Tick(System.Object)')
  - [RemoveDocument(path)](#M-WordObjectives-ThisAddIn-RemoveDocument-System-String- 'WordObjectives.ThisAddIn.RemoveDocument(System.String)')
  - [SaveData(workItem)](#M-WordObjectives-ThisAddIn-SaveData-CommonObjectives-WorkItem- 'WordObjectives.ThisAddIn.SaveData(CommonObjectives.WorkItem)')
  - [StartCaching()](#M-WordObjectives-ThisAddIn-StartCaching-System-String- 'WordObjectives.ThisAddIn.StartCaching(System.String)')
  - [StopCaching()](#M-WordObjectives-ThisAddIn-StopCaching-System-String- 'WordObjectives.ThisAddIn.StopCaching(System.String)')
  - [ThisAddIn_Startup(sender,e)](#M-WordObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs- 'WordObjectives.ThisAddIn.ThisAddIn_Startup(System.Object,System.EventArgs)')
- [ThisRibbonCollection](#T-WordObjectives-ThisRibbonCollection 'WordObjectives.ThisRibbonCollection')
  - [#ctor()](#M-WordObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory- 'WordObjectives.ThisRibbonCollection.#ctor(Microsoft.Office.Tools.Ribbon.RibbonFactory)')

<a name='T-WordObjectives-Globals'></a>
## Globals `type`

##### Namespace

WordObjectives

<a name='M-WordObjectives-Globals-#ctor'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='T-WordObjectives-Properties-Resources'></a>
## Resources `type`

##### Namespace

WordObjectives.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-WordObjectives-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-WordObjectives-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-WordObjectives-ThisAddIn'></a>
## ThisAddIn `type`

##### Namespace

WordObjectives

##### Summary

Microsoft Word VSTO AddIn to track Objectives.

<a name='M-WordObjectives-ThisAddIn-#ctor-Microsoft-Office-Tools-Word-ApplicationFactory,System-IServiceProvider-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.

<a name='M-WordObjectives-ThisAddIn-AddDocument-Microsoft-Office-Interop-Word-Document-'></a>
### AddDocument(doc) `method`

##### Summary

Method to manage the addition of documents.
Documents are checked to see if they already exist. The reason for this is some office events fire more than once.
The document's detail are then collected and added to the dictionary of document details.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| doc | [Microsoft.Office.Interop.Word.Document](#T-Microsoft-Office-Interop-Word-Document 'Microsoft.Office.Interop.Word.Document') | The document to add to the dictionary. |

<a name='M-WordObjectives-ThisAddIn-Application_DocumentBeforeClose-Microsoft-Office-Interop-Word-Document,System-Boolean@-'></a>
### Application_DocumentBeforeClose(doc,cancel) `method`

##### Summary

Event handler to manage when documents are closed.
Occurs immediately before any open document closes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| doc | [Microsoft.Office.Interop.Word.Document](#T-Microsoft-Office-Interop-Word-Document 'Microsoft.Office.Interop.Word.Document') | The document that is closing. |
| cancel | [System.Boolean@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean@ 'System.Boolean@') | Bool value to cancel the closing of the document. |

##### Remarks

[Application.DocumentBeforeClose Event (Word)](Https://docs.microsoft.com/en-us/office/vba/api/word.application.documentbeforeclose).

<a name='M-WordObjectives-ThisAddIn-Application_DocumentChange'></a>
### Application_DocumentChange() `method`

##### Summary

Event handler for when documents change.
Occurs when a new document is created, when an existing document is opened, or when another document is made the active document.

##### Parameters

This method has no parameters.

##### Remarks



<a name='M-WordObjectives-ThisAddIn-Application_DocumentOpen-Microsoft-Office-Interop-Word-Document-'></a>
### Application_DocumentOpen(doc) `method`

##### Summary

Event handler for when a document is opened.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| doc | [Microsoft.Office.Interop.Word.Document](#T-Microsoft-Office-Interop-Word-Document 'Microsoft.Office.Interop.Word.Document') | The document that was opened. |

<a name='M-WordObjectives-ThisAddIn-BeginInitialization'></a>
### BeginInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-BindToData'></a>
### BindToData() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-CheckDocuments'></a>
### CheckDocuments() `method`

##### Summary

Check to see if documents are in the dictionary.

##### Parameters

This method has no parameters.

##### Remarks

First add all documents to the dictionary.
Then remove all key-pairs that are not in the document collection.

<a name='M-WordObjectives-ThisAddIn-EndInitialization'></a>
### EndInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-FinishInitialization'></a>
### FinishInitialization() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-Initialize'></a>
### Initialize() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InitializeCachedData'></a>
### InitializeCachedData() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InitializeComponents'></a>
### InitializeComponents() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InitializeControls'></a>
### InitializeControls() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InitializeData'></a>
### InitializeData() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InitializeDataBindings'></a>
### InitializeDataBindings() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-InternalStartup'></a>
### InternalStartup() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-IsCached-System-String-'></a>
### IsCached() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-NeedsFill-System-String-'></a>
### NeedsFill() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-OnShutdown'></a>
### OnShutdown() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-RefreshTimer_Tick-System-Object-'></a>
### RefreshTimer_Tick(stateInfo) `method`

##### Summary

The main timer event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stateInfo | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |

<a name='M-WordObjectives-ThisAddIn-RemoveDocument-System-String-'></a>
### RemoveDocument(path) `method`

##### Summary

Method to remove documents from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path to the document to remove from the dictionary. |

<a name='M-WordObjectives-ThisAddIn-SaveData-CommonObjectives-WorkItem-'></a>
### SaveData(workItem) `method`

##### Summary

Method to save the data to a json file in the storage folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workItem | [CommonObjectives.WorkItem](#T-CommonObjectives-WorkItem 'CommonObjectives.WorkItem') | A WordSession object to save to file. |

<a name='M-WordObjectives-ThisAddIn-StartCaching-System-String-'></a>
### StartCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-StopCaching-System-String-'></a>
### StopCaching() `method`

##### Parameters

This method has no parameters.

<a name='M-WordObjectives-ThisAddIn-ThisAddIn_Startup-System-Object,System-EventArgs-'></a>
### ThisAddIn_Startup(sender,e) `method`

##### Summary

ThisAddIn_Startup manages startup of the class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Also unused. |

<a name='T-WordObjectives-ThisRibbonCollection'></a>
## ThisRibbonCollection `type`

##### Namespace

WordObjectives

<a name='M-WordObjectives-ThisRibbonCollection-#ctor-Microsoft-Office-Tools-Ribbon-RibbonFactory-'></a>
### #ctor() `constructor`

##### Parameters

This constructor has no parameters.
