<a name='assembly'></a>
# SQLServerManagementStudioObjectives

## Contents

- [SQLServerManagementStudioObjectivesPackage](#T-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage')
  - [PackageGuidString](#F-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-PackageGuidString 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.PackageGuidString')
  - [ProjectDetails](#F-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-ProjectDetails 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.ProjectDetails')
  - [InitializeAsync(cancellationToken,progress)](#M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-InitializeAsync-System-Threading-CancellationToken,System-IProgress{Microsoft-VisualStudio-Shell-ServiceProgressData}- 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.InitializeAsync(System.Threading.CancellationToken,System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData})')
  - [IsSolutionLoadedAsync()](#M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-IsSolutionLoadedAsync 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.IsSolutionLoadedAsync')
  - [MainTimer_Elapsed(sender,e)](#M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-MainTimer_Elapsed-System-Object,System-Timers-ElapsedEventArgs- 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.MainTimer_Elapsed(System.Object,System.Timers.ElapsedEventArgs)')
  - [SolutionEvents_OnAfterBackgroundSolutionLoadComplete(sender,e)](#M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-SolutionEvents_OnAfterBackgroundSolutionLoadComplete-System-Object,System-EventArgs- 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.SolutionEvents_OnAfterBackgroundSolutionLoadComplete(System.Object,System.EventArgs)')
  - [SolutionEvents_OnBeforeCloseSolution(sender,e)](#M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-SolutionEvents_OnBeforeCloseSolution-System-Object,System-EventArgs- 'SQLServerManagementStudioObjectives.SQLServerManagementStudioObjectivesPackage.SolutionEvents_OnBeforeCloseSolution(System.Object,System.EventArgs)')

<a name='T-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage'></a>
## SQLServerManagementStudioObjectivesPackage `type`

##### Namespace

SQLServerManagementStudioObjectives

<a name='F-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-PackageGuidString'></a>
### PackageGuidString `constants`

##### Summary

SQLServerManagementStudioObjectivesPackage GUID string.

<a name='F-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-ProjectDetails'></a>
### ProjectDetails `constants`

##### Summary

SQLServerManagementStudioObjectivesPackage class.

##### Remarks

[How to Create an Extension for SSMS 2019 (v18)](https://stackoverflow.com/questions/55661806/how-to-create-an-extension-for-ssms-2019-v18)
[How to Create SQL Server Management Studio 18 (SSMS) Extension](https://www.codeproject.com/Articles/1377559/How-to-Create-SQL-Server-Management-Studio-18-SSMS)

1. To debug set "Start External Program" as the start action.
Default SSMS Location: C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Ssms.exe

2. Set Deploy VSIX to SSMS.

The "Extensions" subdirectory should be in the same directory as SSMS. Also, add an extra folder with your project name like this:

C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Extensions\SQLServerManagementStudioObjectives

Select all three checkboxes.

3. Give the user all security permissions for this folder.

<a name='M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-InitializeAsync-System-Threading-CancellationToken,System-IProgress{Microsoft-VisualStudio-Shell-ServiceProgressData}-'></a>
### InitializeAsync(cancellationToken,progress) `method`

##### Summary

Initialization of the package; this method is called right after the package is sited, so this is the place
where you can put all the initialization code that rely on services provided by VisualStudio.

##### Returns

A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down. |
| progress | [System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IProgress 'System.IProgress{Microsoft.VisualStudio.Shell.ServiceProgressData}') | A provider for progress updates. |

<a name='M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-IsSolutionLoadedAsync'></a>
### IsSolutionLoadedAsync() `method`

##### Summary



##### Returns

True if the solution is loaded.

##### Parameters

This method has no parameters.

<a name='M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-MainTimer_Elapsed-System-Object,System-Timers-ElapsedEventArgs-'></a>
### MainTimer_Elapsed(sender,e) `method`

##### Summary

Handles the MainTimer event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.Timers.ElapsedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Timers.ElapsedEventArgs 'System.Timers.ElapsedEventArgs') | This parameter is unused. |

<a name='M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-SolutionEvents_OnAfterBackgroundSolutionLoadComplete-System-Object,System-EventArgs-'></a>
### SolutionEvents_OnAfterBackgroundSolutionLoadComplete(sender,e) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |

<a name='M-SQLServerManagementStudioObjectives-SQLServerManagementStudioObjectivesPackage-SolutionEvents_OnBeforeCloseSolution-System-Object,System-EventArgs-'></a>
### SolutionEvents_OnBeforeCloseSolution(sender,e) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | This parameter is unused. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | This parameter is unused. |
