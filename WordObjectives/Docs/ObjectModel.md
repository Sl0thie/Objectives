<a name='assembly'></a>
# AutoCADObjectives

## Contents

- [ExtApp](#T-AutoCADObjectives-ExtApp 'AutoCADObjectives.ExtApp')
  - [#ctor()](#M-AutoCADObjectives-ExtApp-#ctor 'AutoCADObjectives.ExtApp.#ctor')
  - [Callback_DocumentActivated(sender,e)](#M-AutoCADObjectives-ExtApp-Callback_DocumentActivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs- 'AutoCADObjectives.ExtApp.Callback_DocumentActivated(System.Object,Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs)')
  - [Callback_DocumentCreated(sender,e)](#M-AutoCADObjectives-ExtApp-Callback_DocumentCreated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs- 'AutoCADObjectives.ExtApp.Callback_DocumentCreated(System.Object,Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs)')
  - [Callback_DocumentToBeActivated(sender,e)](#M-AutoCADObjectives-ExtApp-Callback_DocumentToBeActivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs- 'AutoCADObjectives.ExtApp.Callback_DocumentToBeActivated(System.Object,Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs)')
  - [Callback_DocumentToBeDeactivated(sender,e)](#M-AutoCADObjectives-ExtApp-Callback_DocumentToBeDeactivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs- 'AutoCADObjectives.ExtApp.Callback_DocumentToBeDeactivated(System.Object,Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs)')
  - [Callback_DocumentToBeDestroyed(sender,e)](#M-AutoCADObjectives-ExtApp-Callback_DocumentToBeDestroyed-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs- 'AutoCADObjectives.ExtApp.Callback_DocumentToBeDestroyed(System.Object,Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs)')
  - [Initialize()](#M-AutoCADObjectives-ExtApp-Initialize 'AutoCADObjectives.ExtApp.Initialize')
  - [SaveData(drawing)](#M-AutoCADObjectives-ExtApp-SaveData-CommonObjectives-WorkItem- 'AutoCADObjectives.ExtApp.SaveData(CommonObjectives.WorkItem)')
  - [Terminate()](#M-AutoCADObjectives-ExtApp-Terminate 'AutoCADObjectives.ExtApp.Terminate')
  - [TimerUpdate_Elapsed(sender,e)](#M-AutoCADObjectives-ExtApp-TimerUpdate_Elapsed-System-Object,System-Timers-ElapsedEventArgs- 'AutoCADObjectives.ExtApp.TimerUpdate_Elapsed(System.Object,System.Timers.ElapsedEventArgs)')

<a name='T-AutoCADObjectives-ExtApp'></a>
## ExtApp `type`

##### Namespace

AutoCADObjectives

##### Summary

AutoCAD extension to track time spent on drawings.

##### Remarks

Output project directly to AutoCAD's Support directory.

C:\Program Files\Autodesk\AutoCAD 2018\Support

This directory is considered secure by AutoCAD so there is no need to add the normal project output directory to AutoCAD's security.
Use the command `NETLOAD` to load the DLL into AutoCAD manually.
Or copy the file acad.lsp to the support directory to load the DLL automatically on startup.

<a name='M-AutoCADObjectives-ExtApp-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ExtApp](#T-AutoCADObjectives-ExtApp 'AutoCADObjectives.ExtApp') class.

##### Parameters

This constructor has no parameters.

<a name='M-AutoCADObjectives-ExtApp-Callback_DocumentActivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs-'></a>
### Callback_DocumentActivated(sender,e) `method`

##### Summary

Event for activated documents.
WARNING: When AutoCAD starts this event fires but the document is null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs](#T-Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs 'Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Callback_DocumentCreated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs-'></a>
### Callback_DocumentCreated(sender,e) `method`

##### Summary

Event for when documents are created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs](#T-Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs 'Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Callback_DocumentToBeActivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs-'></a>
### Callback_DocumentToBeActivated(sender,e) `method`

##### Summary

Event for when a document is activated.
Currently not used as this level of detail is not implemented yet.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs](#T-Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs 'Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Callback_DocumentToBeDeactivated-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs-'></a>
### Callback_DocumentToBeDeactivated(sender,e) `method`

##### Summary

Event for when a document is deactivated.
As with Callback_DocumentToBeActivated this is not implemented yet.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs](#T-Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs 'Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Callback_DocumentToBeDestroyed-System-Object,Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs-'></a>
### Callback_DocumentToBeDestroyed(sender,e) `method`

##### Summary

Event for when documents are destroyed.
WARNING: When AutoCAD starts this event is fired for "Drawing1.dwg" as the very first event.
even though there is not drawing of that name. There is also no previous create event either.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs](#T-Autodesk-AutoCAD-ApplicationServices-DocumentCollectionEventArgs 'Autodesk.AutoCAD.ApplicationServices.DocumentCollectionEventArgs') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Initialize'></a>
### Initialize() `method`

##### Summary

Main entry point from AutoCAD.

##### Parameters

This method has no parameters.

<a name='M-AutoCADObjectives-ExtApp-SaveData-CommonObjectives-WorkItem-'></a>
### SaveData(drawing) `method`

##### Summary

Saves the Data to the storage folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| drawing | [CommonObjectives.WorkItem](#T-CommonObjectives-WorkItem 'CommonObjectives.WorkItem') | parameter is unused. |

<a name='M-AutoCADObjectives-ExtApp-Terminate'></a>
### Terminate() `method`

##### Summary

Terminate method.

##### Parameters

This method has no parameters.

##### Remarks

Not 100% sure this is called by AutoCAD yet.

<a name='M-AutoCADObjectives-ExtApp-TimerUpdate_Elapsed-System-Object,System-Timers-ElapsedEventArgs-'></a>
### TimerUpdate_Elapsed(sender,e) `method`

##### Summary

Event for the main timer tick.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter is unused. |
| e | [System.Timers.ElapsedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Timers.ElapsedEventArgs 'System.Timers.ElapsedEventArgs') | parameter is unused. |
