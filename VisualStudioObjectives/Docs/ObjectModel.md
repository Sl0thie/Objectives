<a name='assembly'></a>
# VisualStudioObjectives

## Contents

- [VisualStudioObectivesPackage](#T-VisualStudioObjectives-VisualStudioObectivesPackage 'VisualStudioObjectives.VisualStudioObectivesPackage')
  - [PackageGuidString](#F-VisualStudioObjectives-VisualStudioObectivesPackage-PackageGuidString 'VisualStudioObjectives.VisualStudioObectivesPackage.PackageGuidString')
  - [GetCurrentValues()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-GetCurrentValues 'VisualStudioObjectives.VisualStudioObectivesPackage.GetCurrentValues')
  - [GetHEADItems()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-GetHEADItems 'VisualStudioObjectives.VisualStudioObectivesPackage.GetHEADItems')
  - [GetRegistrySettings()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-GetRegistrySettings 'VisualStudioObjectives.VisualStudioObectivesPackage.GetRegistrySettings')
  - [GetStartValues()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-GetStartValues 'VisualStudioObjectives.VisualStudioObectivesPackage.GetStartValues')
  - [InitializeAsync(cancellationToken,progress)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-InitializeAsync-System-Threading-CancellationToken,System-IProgress{Microsoft-VisualStudio-Shell-ServiceProgressData}- 'VisualStudioObjectives.VisualStudioObectivesPackage.InitializeAsync(System.Threading.CancellationToken,System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData})')
  - [IsProjectItemsUnsavedAsync(item,save)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-IsProjectItemsUnsavedAsync-EnvDTE-ProjectItem,System-Boolean- 'VisualStudioObjectives.VisualStudioObectivesPackage.IsProjectItemsUnsavedAsync(EnvDTE.ProjectItem,System.Boolean)')
  - [IsSolutionLoadedAsync()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-IsSolutionLoadedAsync 'VisualStudioObjectives.VisualStudioObectivesPackage.IsSolutionLoadedAsync')
  - [IsSolutionUnsavedAsync(solution,save)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-IsSolutionUnsavedAsync-EnvDTE-Solution,System-Boolean- 'VisualStudioObjectives.VisualStudioObectivesPackage.IsSolutionUnsavedAsync(EnvDTE.Solution,System.Boolean)')
  - [MainTimer_Elapsed(sender,e)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-MainTimer_Elapsed-System-Object,System-Timers-ElapsedEventArgs- 'VisualStudioObjectives.VisualStudioObectivesPackage.MainTimer_Elapsed(System.Object,System.Timers.ElapsedEventArgs)')
  - [SaveDataAsync()](#M-VisualStudioObjectives-VisualStudioObectivesPackage-SaveDataAsync 'VisualStudioObjectives.VisualStudioObectivesPackage.SaveDataAsync')
  - [SolutionEvents_OnAfterBackgroundSolutionLoadComplete(sender,e)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-SolutionEvents_OnAfterBackgroundSolutionLoadComplete-System-Object,System-EventArgs- 'VisualStudioObjectives.VisualStudioObectivesPackage.SolutionEvents_OnAfterBackgroundSolutionLoadComplete(System.Object,System.EventArgs)')
  - [SolutionEvents_OnBeforeCloseSolution(sender,e)](#M-VisualStudioObjectives-VisualStudioObectivesPackage-SolutionEvents_OnBeforeCloseSolution-System-Object,System-EventArgs- 'VisualStudioObjectives.VisualStudioObectivesPackage.SolutionEvents_OnBeforeCloseSolution(System.Object,System.EventArgs)')

<a name='T-VisualStudioObjectives-VisualStudioObectivesPackage'></a>
## VisualStudioObectivesPackage `type`

##### Namespace

VisualStudioObjectives

##### Summary

VisualStudioObectivesPackage class.

<a name='F-VisualStudioObjectives-VisualStudioObectivesPackage-PackageGuidString'></a>
### PackageGuidString `constants`

##### Summary

GUID for the Package.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-GetCurrentValues'></a>
### GetCurrentValues() `method`

##### Summary

Gets the current values for the WorkItem.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-GetHEADItems'></a>
### GetHEADItems() `method`

##### Summary

Gets the HEAD items from the git logs if available.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-GetRegistrySettings'></a>
### GetRegistrySettings() `method`

##### Summary

Gets the settings from the Registry.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-GetStartValues'></a>
### GetStartValues() `method`

##### Summary

Gets the starting values for the WorkItem.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-InitializeAsync-System-Threading-CancellationToken,System-IProgress{Microsoft-VisualStudio-Shell-ServiceProgressData}-'></a>
### InitializeAsync(cancellationToken,progress) `method`

##### Summary

Initializes the VisualStudioObectivesPackage.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') |  |
| progress | [System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IProgress 'System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData}') |  |

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-IsProjectItemsUnsavedAsync-EnvDTE-ProjectItem,System-Boolean-'></a>
### IsProjectItemsUnsavedAsync(item,save) `method`

##### Summary

Searches project items for unsaved changes.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [EnvDTE.ProjectItem](#T-EnvDTE-ProjectItem 'EnvDTE.ProjectItem') | The project item to search.  Includes sub items if the item is a folder. |
| save | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, will save the item if unsaved changes are found. |

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-IsSolutionLoadedAsync'></a>
### IsSolutionLoadedAsync() `method`

##### Summary



##### Returns

True if the solution is loaded.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-IsSolutionUnsavedAsync-EnvDTE-Solution,System-Boolean-'></a>
### IsSolutionUnsavedAsync(solution,save) `method`

##### Summary

Searches projects and project items for unsaved changes.

##### Returns

True is unsaved changes are found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| solution | [EnvDTE.Solution](#T-EnvDTE-Solution 'EnvDTE.Solution') | The solution to search for unsaved changes. |
| save | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, save the items if they are unsaved. |

##### Remarks

List of [Project GUID's](https://www.codeproject.com/reference/720512/list-of-visual-studio-project-type-guids")

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-MainTimer_Elapsed-System-Object,System-Timers-ElapsedEventArgs-'></a>
### MainTimer_Elapsed(sender,e) `method`

##### Summary

Handles the MainTimer event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.Timers.ElapsedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Timers.ElapsedEventArgs 'System.Timers.ElapsedEventArgs') | This parameter is unused. |

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-SaveDataAsync'></a>
### SaveDataAsync() `method`

##### Summary

Saves the WorkItem data to file.

##### Parameters

This method has no parameters.

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-SolutionEvents_OnAfterBackgroundSolutionLoadComplete-System-Object,System-EventArgs-'></a>
### SolutionEvents_OnAfterBackgroundSolutionLoadComplete(sender,e) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-VisualStudioObjectives-VisualStudioObectivesPackage-SolutionEvents_OnBeforeCloseSolution-System-Object,System-EventArgs-'></a>
### SolutionEvents_OnBeforeCloseSolution(sender,e) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |
