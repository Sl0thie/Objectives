<a name='assembly'></a>
# CommonObjectives

## Contents

- [ActiveApplication](#T-CommonObjectives-ActiveApplication 'CommonObjectives.ActiveApplication')
  - [Application](#P-CommonObjectives-ActiveApplication-Application 'CommonObjectives.ActiveApplication.Application')
  - [Time](#P-CommonObjectives-ActiveApplication-Time 'CommonObjectives.ActiveApplication.Time')
  - [Title](#P-CommonObjectives-ActiveApplication-Title 'CommonObjectives.ActiveApplication.Title')
- [ApplicationType](#T-CommonObjectives-ApplicationType 'CommonObjectives.ApplicationType')
  - [Autocad](#F-CommonObjectives-ApplicationType-Autocad 'CommonObjectives.ApplicationType.Autocad')
  - [AutocadRead](#F-CommonObjectives-ApplicationType-AutocadRead 'CommonObjectives.ApplicationType.AutocadRead')
  - [AutocadWrite](#F-CommonObjectives-ApplicationType-AutocadWrite 'CommonObjectives.ApplicationType.AutocadWrite')
  - [Excel](#F-CommonObjectives-ApplicationType-Excel 'CommonObjectives.ApplicationType.Excel')
  - [ExcelRead](#F-CommonObjectives-ApplicationType-ExcelRead 'CommonObjectives.ApplicationType.ExcelRead')
  - [ExcelWrite](#F-CommonObjectives-ApplicationType-ExcelWrite 'CommonObjectives.ApplicationType.ExcelWrite')
  - [None](#F-CommonObjectives-ApplicationType-None 'CommonObjectives.ApplicationType.None')
  - [Project](#F-CommonObjectives-ApplicationType-Project 'CommonObjectives.ApplicationType.Project')
  - [ProjectRead](#F-CommonObjectives-ApplicationType-ProjectRead 'CommonObjectives.ApplicationType.ProjectRead')
  - [ProjectWrite](#F-CommonObjectives-ApplicationType-ProjectWrite 'CommonObjectives.ApplicationType.ProjectWrite')
  - [Ssms](#F-CommonObjectives-ApplicationType-Ssms 'CommonObjectives.ApplicationType.Ssms')
  - [SsmsRead](#F-CommonObjectives-ApplicationType-SsmsRead 'CommonObjectives.ApplicationType.SsmsRead')
  - [SsmsWrite](#F-CommonObjectives-ApplicationType-SsmsWrite 'CommonObjectives.ApplicationType.SsmsWrite')
  - [Visio](#F-CommonObjectives-ApplicationType-Visio 'CommonObjectives.ApplicationType.Visio')
  - [VisioRead](#F-CommonObjectives-ApplicationType-VisioRead 'CommonObjectives.ApplicationType.VisioRead')
  - [VisioWrite](#F-CommonObjectives-ApplicationType-VisioWrite 'CommonObjectives.ApplicationType.VisioWrite')
  - [VisualStudio](#F-CommonObjectives-ApplicationType-VisualStudio 'CommonObjectives.ApplicationType.VisualStudio')
  - [VisualStudioRead](#F-CommonObjectives-ApplicationType-VisualStudioRead 'CommonObjectives.ApplicationType.VisualStudioRead')
  - [VisualStudioWrite](#F-CommonObjectives-ApplicationType-VisualStudioWrite 'CommonObjectives.ApplicationType.VisualStudioWrite')
  - [Word](#F-CommonObjectives-ApplicationType-Word 'CommonObjectives.ApplicationType.Word')
  - [WordRead](#F-CommonObjectives-ApplicationType-WordRead 'CommonObjectives.ApplicationType.WordRead')
  - [WordWrite](#F-CommonObjectives-ApplicationType-WordWrite 'CommonObjectives.ApplicationType.WordWrite')
- [AppointmentType](#T-CommonObjectives-AppointmentType 'CommonObjectives.AppointmentType')
  - [None](#F-CommonObjectives-AppointmentType-None 'CommonObjectives.AppointmentType.None')
  - [ObjectivesDayReport](#F-CommonObjectives-AppointmentType-ObjectivesDayReport 'CommonObjectives.AppointmentType.ObjectivesDayReport')
  - [ObjectivesMonthReport](#F-CommonObjectives-AppointmentType-ObjectivesMonthReport 'CommonObjectives.AppointmentType.ObjectivesMonthReport')
  - [ObjectivesQuarterReport](#F-CommonObjectives-AppointmentType-ObjectivesQuarterReport 'CommonObjectives.AppointmentType.ObjectivesQuarterReport')
  - [ObjectivesWeekReport](#F-CommonObjectives-AppointmentType-ObjectivesWeekReport 'CommonObjectives.AppointmentType.ObjectivesWeekReport')
  - [Standard](#F-CommonObjectives-AppointmentType-Standard 'CommonObjectives.AppointmentType.Standard')
- [DayReport](#T-CommonObjectives-DayReport 'CommonObjectives.DayReport')
  - [#ctor()](#M-CommonObjectives-DayReport-#ctor 'CommonObjectives.DayReport.#ctor')
  - [Day](#P-CommonObjectives-DayReport-Day 'CommonObjectives.DayReport.Day')
  - [HTML](#P-CommonObjectives-DayReport-HTML 'CommonObjectives.DayReport.HTML')
  - [Minutes](#P-CommonObjectives-DayReport-Minutes 'CommonObjectives.DayReport.Minutes')
  - [TotalIdle](#P-CommonObjectives-DayReport-TotalIdle 'CommonObjectives.DayReport.TotalIdle')
  - [TotalUptime](#P-CommonObjectives-DayReport-TotalUptime 'CommonObjectives.DayReport.TotalUptime')
  - [TotalWork](#P-CommonObjectives-DayReport-TotalWork 'CommonObjectives.DayReport.TotalWork')
  - [UniqueApplications](#P-CommonObjectives-DayReport-UniqueApplications 'CommonObjectives.DayReport.UniqueApplications')
  - [WorkItems](#P-CommonObjectives-DayReport-WorkItems 'CommonObjectives.DayReport.WorkItems')
- [DrawingSession](#T-CommonObjectives-DrawingSession 'CommonObjectives.DrawingSession')
  - [#ctor()](#M-CommonObjectives-DrawingSession-#ctor 'CommonObjectives.DrawingSession.#ctor')
  - [Active](#P-CommonObjectives-DrawingSession-Active 'CommonObjectives.DrawingSession.Active')
  - [ActiveTime](#P-CommonObjectives-DrawingSession-ActiveTime 'CommonObjectives.DrawingSession.ActiveTime')
  - [Application](#P-CommonObjectives-DrawingSession-Application 'CommonObjectives.DrawingSession.Application')
  - [Finish](#P-CommonObjectives-DrawingSession-Finish 'CommonObjectives.DrawingSession.Finish')
  - [FinishSize](#P-CommonObjectives-DrawingSession-FinishSize 'CommonObjectives.DrawingSession.FinishSize')
  - [LastActive](#P-CommonObjectives-DrawingSession-LastActive 'CommonObjectives.DrawingSession.LastActive')
  - [Name](#P-CommonObjectives-DrawingSession-Name 'CommonObjectives.DrawingSession.Name')
  - [ObjectiveName](#P-CommonObjectives-DrawingSession-ObjectiveName 'CommonObjectives.DrawingSession.ObjectiveName')
  - [Path](#P-CommonObjectives-DrawingSession-Path 'CommonObjectives.DrawingSession.Path')
  - [Processed](#P-CommonObjectives-DrawingSession-Processed 'CommonObjectives.DrawingSession.Processed')
  - [Start](#P-CommonObjectives-DrawingSession-Start 'CommonObjectives.DrawingSession.Start')
  - [StartSize](#P-CommonObjectives-DrawingSession-StartSize 'CommonObjectives.DrawingSession.StartSize')
  - [Version](#P-CommonObjectives-DrawingSession-Version 'CommonObjectives.DrawingSession.Version')
- [IWorkItem](#T-CommonObjectives-IWorkItem 'CommonObjectives.IWorkItem')
  - [Finish](#P-CommonObjectives-IWorkItem-Finish 'CommonObjectives.IWorkItem.Finish')
  - [Id](#P-CommonObjectives-IWorkItem-Id 'CommonObjectives.IWorkItem.Id')
  - [ObjectiveName](#P-CommonObjectives-IWorkItem-ObjectiveName 'CommonObjectives.IWorkItem.ObjectiveName')
  - [Start](#P-CommonObjectives-IWorkItem-Start 'CommonObjectives.IWorkItem.Start')
- [Minute](#T-CommonObjectives-Minute 'CommonObjectives.Minute')
  - [#ctor()](#M-CommonObjectives-Minute-#ctor 'CommonObjectives.Minute.#ctor')
  - [#ctor(index)](#M-CommonObjectives-Minute-#ctor-System-Int32- 'CommonObjectives.Minute.#ctor(System.Int32)')
  - [ActiveApplication](#P-CommonObjectives-Minute-ActiveApplication 'CommonObjectives.Minute.ActiveApplication')
  - [ActiveApplicationTitle](#P-CommonObjectives-Minute-ActiveApplicationTitle 'CommonObjectives.Minute.ActiveApplicationTitle')
  - [Billable](#P-CommonObjectives-Minute-Billable 'CommonObjectives.Minute.Billable')
  - [Idle](#P-CommonObjectives-Minute-Idle 'CommonObjectives.Minute.Idle')
  - [Index](#P-CommonObjectives-Minute-Index 'CommonObjectives.Minute.Index')
  - [PrimaryWorkItem](#P-CommonObjectives-Minute-PrimaryWorkItem 'CommonObjectives.Minute.PrimaryWorkItem')
  - [Up](#P-CommonObjectives-Minute-Up 'CommonObjectives.Minute.Up')
- [MonthReport](#T-CommonObjectives-MonthReport 'CommonObjectives.MonthReport')
  - [Day](#P-CommonObjectives-MonthReport-Day 'CommonObjectives.MonthReport.Day')
  - [HTML](#P-CommonObjectives-MonthReport-HTML 'CommonObjectives.MonthReport.HTML')
  - [WorkItems](#P-CommonObjectives-MonthReport-WorkItems 'CommonObjectives.MonthReport.WorkItems')
- [Note](#T-CommonObjectives-Note 'CommonObjectives.Note')
  - [#ctor()](#M-CommonObjectives-Note-#ctor 'CommonObjectives.Note.#ctor')
  - [#ctor(title,content)](#M-CommonObjectives-Note-#ctor-System-String,System-String- 'CommonObjectives.Note.#ctor(System.String,System.String)')
  - [Content](#P-CommonObjectives-Note-Content 'CommonObjectives.Note.Content')
  - [Created](#P-CommonObjectives-Note-Created 'CommonObjectives.Note.Created')
  - [Id](#P-CommonObjectives-Note-Id 'CommonObjectives.Note.Id')
  - [Modified](#P-CommonObjectives-Note-Modified 'CommonObjectives.Note.Modified')
  - [Title](#P-CommonObjectives-Note-Title 'CommonObjectives.Note.Title')
- [Objective](#T-CommonObjectives-Objective 'CommonObjectives.Objective')
  - [#ctor()](#M-CommonObjectives-Objective-#ctor 'CommonObjectives.Objective.#ctor')
  - [Archived](#P-CommonObjectives-Objective-Archived 'CommonObjectives.Objective.Archived')
  - [Created](#P-CommonObjectives-Objective-Created 'CommonObjectives.Objective.Created')
  - [ObjectiveName](#P-CommonObjectives-Objective-ObjectiveName 'CommonObjectives.Objective.ObjectiveName')
  - [Path](#P-CommonObjectives-Objective-Path 'CommonObjectives.Objective.Path')
  - [WorkTypes](#P-CommonObjectives-Objective-WorkTypes 'CommonObjectives.Objective.WorkTypes')
- [SolutionProject](#T-CommonObjectives-SolutionProject 'CommonObjectives.SolutionProject')
  - [FileName](#P-CommonObjectives-SolutionProject-FileName 'CommonObjectives.SolutionProject.FileName')
  - [FullName](#P-CommonObjectives-SolutionProject-FullName 'CommonObjectives.SolutionProject.FullName')
  - [Name](#P-CommonObjectives-SolutionProject-Name 'CommonObjectives.SolutionProject.Name')
  - [UniqueName](#P-CommonObjectives-SolutionProject-UniqueName 'CommonObjectives.SolutionProject.UniqueName')
- [SolutionProperty](#T-CommonObjectives-SolutionProperty 'CommonObjectives.SolutionProperty')
  - [Name](#P-CommonObjectives-SolutionProperty-Name 'CommonObjectives.SolutionProperty.Name')
  - [Value](#P-CommonObjectives-SolutionProperty-Value 'CommonObjectives.SolutionProperty.Value')
- [SolutionSession](#T-CommonObjectives-SolutionSession 'CommonObjectives.SolutionSession')
  - [#ctor()](#M-CommonObjectives-SolutionSession-#ctor 'CommonObjectives.SolutionSession.#ctor')
  - [Application](#P-CommonObjectives-SolutionSession-Application 'CommonObjectives.SolutionSession.Application')
  - [BuildCount](#P-CommonObjectives-SolutionSession-BuildCount 'CommonObjectives.SolutionSession.BuildCount')
  - [Finish](#P-CommonObjectives-SolutionSession-Finish 'CommonObjectives.SolutionSession.Finish')
  - [FinishFileCountCompiling](#P-CommonObjectives-SolutionSession-FinishFileCountCompiling 'CommonObjectives.SolutionSession.FinishFileCountCompiling')
  - [FinishFileCountLinking](#P-CommonObjectives-SolutionSession-FinishFileCountLinking 'CommonObjectives.SolutionSession.FinishFileCountLinking')
  - [FinishFileCountProject](#P-CommonObjectives-SolutionSession-FinishFileCountProject 'CommonObjectives.SolutionSession.FinishFileCountProject')
  - [FinishFileCountResource](#P-CommonObjectives-SolutionSession-FinishFileCountResource 'CommonObjectives.SolutionSession.FinishFileCountResource')
  - [FinishFileCountSolution](#P-CommonObjectives-SolutionSession-FinishFileCountSolution 'CommonObjectives.SolutionSession.FinishFileCountSolution')
  - [FinishFileCountSource](#P-CommonObjectives-SolutionSession-FinishFileCountSource 'CommonObjectives.SolutionSession.FinishFileCountSource')
  - [FinishFileCountTotal](#P-CommonObjectives-SolutionSession-FinishFileCountTotal 'CommonObjectives.SolutionSession.FinishFileCountTotal')
  - [FinishFileSizeCompiling](#P-CommonObjectives-SolutionSession-FinishFileSizeCompiling 'CommonObjectives.SolutionSession.FinishFileSizeCompiling')
  - [FinishFileSizeLinking](#P-CommonObjectives-SolutionSession-FinishFileSizeLinking 'CommonObjectives.SolutionSession.FinishFileSizeLinking')
  - [FinishFileSizeProject](#P-CommonObjectives-SolutionSession-FinishFileSizeProject 'CommonObjectives.SolutionSession.FinishFileSizeProject')
  - [FinishFileSizeResource](#P-CommonObjectives-SolutionSession-FinishFileSizeResource 'CommonObjectives.SolutionSession.FinishFileSizeResource')
  - [FinishFileSizeSolution](#P-CommonObjectives-SolutionSession-FinishFileSizeSolution 'CommonObjectives.SolutionSession.FinishFileSizeSolution')
  - [FinishFileSizeSource](#P-CommonObjectives-SolutionSession-FinishFileSizeSource 'CommonObjectives.SolutionSession.FinishFileSizeSource')
  - [FinishFileSizeTotal](#P-CommonObjectives-SolutionSession-FinishFileSizeTotal 'CommonObjectives.SolutionSession.FinishFileSizeTotal')
  - [HeadItems](#P-CommonObjectives-SolutionSession-HeadItems 'CommonObjectives.SolutionSession.HeadItems')
  - [Name](#P-CommonObjectives-SolutionSession-Name 'CommonObjectives.SolutionSession.Name')
  - [ObjectiveName](#P-CommonObjectives-SolutionSession-ObjectiveName 'CommonObjectives.SolutionSession.ObjectiveName')
  - [Path](#P-CommonObjectives-SolutionSession-Path 'CommonObjectives.SolutionSession.Path')
  - [Processed](#P-CommonObjectives-SolutionSession-Processed 'CommonObjectives.SolutionSession.Processed')
  - [SolutionCount](#P-CommonObjectives-SolutionSession-SolutionCount 'CommonObjectives.SolutionSession.SolutionCount')
  - [SolutionFileName](#P-CommonObjectives-SolutionSession-SolutionFileName 'CommonObjectives.SolutionSession.SolutionFileName')
  - [SolutionFullName](#P-CommonObjectives-SolutionSession-SolutionFullName 'CommonObjectives.SolutionSession.SolutionFullName')
  - [SolutionProjects](#P-CommonObjectives-SolutionSession-SolutionProjects 'CommonObjectives.SolutionSession.SolutionProjects')
  - [SolutionProperties](#P-CommonObjectives-SolutionSession-SolutionProperties 'CommonObjectives.SolutionSession.SolutionProperties')
  - [Start](#P-CommonObjectives-SolutionSession-Start 'CommonObjectives.SolutionSession.Start')
  - [StartFileCountCompiling](#P-CommonObjectives-SolutionSession-StartFileCountCompiling 'CommonObjectives.SolutionSession.StartFileCountCompiling')
  - [StartFileCountLinking](#P-CommonObjectives-SolutionSession-StartFileCountLinking 'CommonObjectives.SolutionSession.StartFileCountLinking')
  - [StartFileCountProject](#P-CommonObjectives-SolutionSession-StartFileCountProject 'CommonObjectives.SolutionSession.StartFileCountProject')
  - [StartFileCountResource](#P-CommonObjectives-SolutionSession-StartFileCountResource 'CommonObjectives.SolutionSession.StartFileCountResource')
  - [StartFileCountSolution](#P-CommonObjectives-SolutionSession-StartFileCountSolution 'CommonObjectives.SolutionSession.StartFileCountSolution')
  - [StartFileCountSource](#P-CommonObjectives-SolutionSession-StartFileCountSource 'CommonObjectives.SolutionSession.StartFileCountSource')
  - [StartFileCountTotal](#P-CommonObjectives-SolutionSession-StartFileCountTotal 'CommonObjectives.SolutionSession.StartFileCountTotal')
  - [StartFileSizeCompiling](#P-CommonObjectives-SolutionSession-StartFileSizeCompiling 'CommonObjectives.SolutionSession.StartFileSizeCompiling')
  - [StartFileSizeLinking](#P-CommonObjectives-SolutionSession-StartFileSizeLinking 'CommonObjectives.SolutionSession.StartFileSizeLinking')
  - [StartFileSizeProject](#P-CommonObjectives-SolutionSession-StartFileSizeProject 'CommonObjectives.SolutionSession.StartFileSizeProject')
  - [StartFileSizeResource](#P-CommonObjectives-SolutionSession-StartFileSizeResource 'CommonObjectives.SolutionSession.StartFileSizeResource')
  - [StartFileSizeSolution](#P-CommonObjectives-SolutionSession-StartFileSizeSolution 'CommonObjectives.SolutionSession.StartFileSizeSolution')
  - [StartFileSizeSource](#P-CommonObjectives-SolutionSession-StartFileSizeSource 'CommonObjectives.SolutionSession.StartFileSizeSource')
  - [StartFileSizeTotal](#P-CommonObjectives-SolutionSession-StartFileSizeTotal 'CommonObjectives.SolutionSession.StartFileSizeTotal')
  - [Version](#P-CommonObjectives-SolutionSession-Version 'CommonObjectives.SolutionSession.Version')
- [SystemIdle](#T-CommonObjectives-SystemIdle 'CommonObjectives.SystemIdle')
  - [ComputerName](#P-CommonObjectives-SystemIdle-ComputerName 'CommonObjectives.SystemIdle.ComputerName')
  - [Finish](#P-CommonObjectives-SystemIdle-Finish 'CommonObjectives.SystemIdle.Finish')
  - [Start](#P-CommonObjectives-SystemIdle-Start 'CommonObjectives.SystemIdle.Start')
  - [UserName](#P-CommonObjectives-SystemIdle-UserName 'CommonObjectives.SystemIdle.UserName')
- [SystemSleep](#T-CommonObjectives-SystemSleep 'CommonObjectives.SystemSleep')
  - [ComputerName](#P-CommonObjectives-SystemSleep-ComputerName 'CommonObjectives.SystemSleep.ComputerName')
  - [Finish](#P-CommonObjectives-SystemSleep-Finish 'CommonObjectives.SystemSleep.Finish')
  - [Start](#P-CommonObjectives-SystemSleep-Start 'CommonObjectives.SystemSleep.Start')
  - [UserName](#P-CommonObjectives-SystemSleep-UserName 'CommonObjectives.SystemSleep.UserName')
- [SystemType](#T-CommonObjectives-SystemType 'CommonObjectives.SystemType')
  - [Idle](#F-CommonObjectives-SystemType-Idle 'CommonObjectives.SystemType.Idle')
  - [None](#F-CommonObjectives-SystemType-None 'CommonObjectives.SystemType.None')
  - [Sleep](#F-CommonObjectives-SystemType-Sleep 'CommonObjectives.SystemType.Sleep')
  - [Uptime](#F-CommonObjectives-SystemType-Uptime 'CommonObjectives.SystemType.Uptime')
- [SystemUptime](#T-CommonObjectives-SystemUptime 'CommonObjectives.SystemUptime')
  - [ActiveApplications](#P-CommonObjectives-SystemUptime-ActiveApplications 'CommonObjectives.SystemUptime.ActiveApplications')
  - [ComputerName](#P-CommonObjectives-SystemUptime-ComputerName 'CommonObjectives.SystemUptime.ComputerName')
  - [Finish](#P-CommonObjectives-SystemUptime-Finish 'CommonObjectives.SystemUptime.Finish')
  - [Start](#P-CommonObjectives-SystemUptime-Start 'CommonObjectives.SystemUptime.Start')
  - [UserName](#P-CommonObjectives-SystemUptime-UserName 'CommonObjectives.SystemUptime.UserName')
- [WeekReport](#T-CommonObjectives-WeekReport 'CommonObjectives.WeekReport')
  - [Day](#P-CommonObjectives-WeekReport-Day 'CommonObjectives.WeekReport.Day')
  - [HTML](#P-CommonObjectives-WeekReport-HTML 'CommonObjectives.WeekReport.HTML')
  - [WorkItems](#P-CommonObjectives-WeekReport-WorkItems 'CommonObjectives.WeekReport.WorkItems')
- [WorkItem](#T-CommonObjectives-WorkItem 'CommonObjectives.WorkItem')
  - [#ctor()](#M-CommonObjectives-WorkItem-#ctor 'CommonObjectives.WorkItem.#ctor')
  - [#ctor(name)](#M-CommonObjectives-WorkItem-#ctor-System-String- 'CommonObjectives.WorkItem.#ctor(System.String)')
  - [Application](#P-CommonObjectives-WorkItem-Application 'CommonObjectives.WorkItem.Application')
  - [Cost](#P-CommonObjectives-WorkItem-Cost 'CommonObjectives.WorkItem.Cost')
  - [Description](#P-CommonObjectives-WorkItem-Description 'CommonObjectives.WorkItem.Description')
  - [FilePath](#P-CommonObjectives-WorkItem-FilePath 'CommonObjectives.WorkItem.FilePath')
  - [Finish](#P-CommonObjectives-WorkItem-Finish 'CommonObjectives.WorkItem.Finish')
  - [FinishSize](#P-CommonObjectives-WorkItem-FinishSize 'CommonObjectives.WorkItem.FinishSize')
  - [Id](#P-CommonObjectives-WorkItem-Id 'CommonObjectives.WorkItem.Id')
  - [Invoiced](#P-CommonObjectives-WorkItem-Invoiced 'CommonObjectives.WorkItem.Invoiced')
  - [IsActive](#P-CommonObjectives-WorkItem-IsActive 'CommonObjectives.WorkItem.IsActive')
  - [Minutes](#P-CommonObjectives-WorkItem-Minutes 'CommonObjectives.WorkItem.Minutes')
  - [Name](#P-CommonObjectives-WorkItem-Name 'CommonObjectives.WorkItem.Name')
  - [Notes](#P-CommonObjectives-WorkItem-Notes 'CommonObjectives.WorkItem.Notes')
  - [ObjectiveName](#P-CommonObjectives-WorkItem-ObjectiveName 'CommonObjectives.WorkItem.ObjectiveName')
  - [Start](#P-CommonObjectives-WorkItem-Start 'CommonObjectives.WorkItem.Start')
  - [StartSize](#P-CommonObjectives-WorkItem-StartSize 'CommonObjectives.WorkItem.StartSize')
  - [Version](#P-CommonObjectives-WorkItem-Version 'CommonObjectives.WorkItem.Version')
  - [WorkType](#P-CommonObjectives-WorkItem-WorkType 'CommonObjectives.WorkItem.WorkType')
- [WorkType](#T-CommonObjectives-WorkType 'CommonObjectives.WorkType')
  - [Application](#P-CommonObjectives-WorkType-Application 'CommonObjectives.WorkType.Application')
  - [CostPerHour](#P-CommonObjectives-WorkType-CostPerHour 'CommonObjectives.WorkType.CostPerHour')
  - [Description](#P-CommonObjectives-WorkType-Description 'CommonObjectives.WorkType.Description')
  - [Index](#P-CommonObjectives-WorkType-Index 'CommonObjectives.WorkType.Index')
  - [MaximNoOfMinutes](#P-CommonObjectives-WorkType-MaximNoOfMinutes 'CommonObjectives.WorkType.MaximNoOfMinutes')
  - [MinimumNoOfMinutes](#P-CommonObjectives-WorkType-MinimumNoOfMinutes 'CommonObjectives.WorkType.MinimumNoOfMinutes')
  - [Name](#P-CommonObjectives-WorkType-Name 'CommonObjectives.WorkType.Name')

<a name='T-CommonObjectives-ActiveApplication'></a>
## ActiveApplication `type`

##### Namespace

CommonObjectives

##### Summary

ActiveApplication class contains related to the application that was in focus at the time..

<a name='P-CommonObjectives-ActiveApplication-Application'></a>
### Application `property`

##### Summary

The application name that is focused.

<a name='P-CommonObjectives-ActiveApplication-Time'></a>
### Time `property`

##### Summary

The time is was measured.

<a name='P-CommonObjectives-ActiveApplication-Title'></a>
### Title `property`

##### Summary

The title of the focused application.

<a name='T-CommonObjectives-ApplicationType'></a>
## ApplicationType `type`

##### Namespace

CommonObjectives

##### Summary

Enumeration of applications and their state of use.
Write denotes the application was used to produce.
Read denotes the application was used to review.

<a name='F-CommonObjectives-ApplicationType-Autocad'></a>
### Autocad `constants`

##### Summary

Autodesk AutoCAD.

<a name='F-CommonObjectives-ApplicationType-AutocadRead'></a>
### AutocadRead `constants`

##### Summary

Reviewing with AutoCAD.

<a name='F-CommonObjectives-ApplicationType-AutocadWrite'></a>
### AutocadWrite `constants`

##### Summary

Writing with AutoCAD.

<a name='F-CommonObjectives-ApplicationType-Excel'></a>
### Excel `constants`

##### Summary

Microsoft Excel.

<a name='F-CommonObjectives-ApplicationType-ExcelRead'></a>
### ExcelRead `constants`

##### Summary

Reviewing with Microsoft Excel.

<a name='F-CommonObjectives-ApplicationType-ExcelWrite'></a>
### ExcelWrite `constants`

##### Summary

Writing with Microsoft Excel.

<a name='F-CommonObjectives-ApplicationType-None'></a>
### None `constants`

##### Summary

No application.

<a name='F-CommonObjectives-ApplicationType-Project'></a>
### Project `constants`

##### Summary

Microsoft Project.

<a name='F-CommonObjectives-ApplicationType-ProjectRead'></a>
### ProjectRead `constants`

##### Summary

Reviewing with Microsoft Project.

<a name='F-CommonObjectives-ApplicationType-ProjectWrite'></a>
### ProjectWrite `constants`

##### Summary

Writing with Microsoft Project.

<a name='F-CommonObjectives-ApplicationType-Ssms'></a>
### Ssms `constants`

##### Summary

SQL Server Management Studio.

<a name='F-CommonObjectives-ApplicationType-SsmsRead'></a>
### SsmsRead `constants`

##### Summary

Reviewing with SQL Server Management Studio.

<a name='F-CommonObjectives-ApplicationType-SsmsWrite'></a>
### SsmsWrite `constants`

##### Summary

Writing with SQL Server Management Studio.

<a name='F-CommonObjectives-ApplicationType-Visio'></a>
### Visio `constants`

##### Summary

Microsoft Visio.

<a name='F-CommonObjectives-ApplicationType-VisioRead'></a>
### VisioRead `constants`

##### Summary

Reviewing with Microsoft Visio.

<a name='F-CommonObjectives-ApplicationType-VisioWrite'></a>
### VisioWrite `constants`

##### Summary

Writing with Microsoft Visio.

<a name='F-CommonObjectives-ApplicationType-VisualStudio'></a>
### VisualStudio `constants`

##### Summary

Visual Studio.

<a name='F-CommonObjectives-ApplicationType-VisualStudioRead'></a>
### VisualStudioRead `constants`

##### Summary

Reviewing with Visual Studio.

<a name='F-CommonObjectives-ApplicationType-VisualStudioWrite'></a>
### VisualStudioWrite `constants`

##### Summary

Writing with Visual Studio.

<a name='F-CommonObjectives-ApplicationType-Word'></a>
### Word `constants`

##### Summary

Microsoft Word.

<a name='F-CommonObjectives-ApplicationType-WordRead'></a>
### WordRead `constants`

##### Summary

Reviewing with Microsoft Word.

<a name='F-CommonObjectives-ApplicationType-WordWrite'></a>
### WordWrite `constants`

##### Summary

Writing with Microsoft Word.

<a name='T-CommonObjectives-AppointmentType'></a>
## AppointmentType `type`

##### Namespace

CommonObjectives

##### Summary

Enumeration of Outlook Appointment types.

<a name='F-CommonObjectives-AppointmentType-None'></a>
### None `constants`

##### Summary

None.

<a name='F-CommonObjectives-AppointmentType-ObjectivesDayReport'></a>
### ObjectivesDayReport `constants`

##### Summary

Daily Report Appointment.

<a name='F-CommonObjectives-AppointmentType-ObjectivesMonthReport'></a>
### ObjectivesMonthReport `constants`

##### Summary

Monthly Report Appointment.

<a name='F-CommonObjectives-AppointmentType-ObjectivesQuarterReport'></a>
### ObjectivesQuarterReport `constants`

##### Summary

Quarterly Report Appointment.

<a name='F-CommonObjectives-AppointmentType-ObjectivesWeekReport'></a>
### ObjectivesWeekReport `constants`

##### Summary

Weekly Report Appointment.

<a name='F-CommonObjectives-AppointmentType-Standard'></a>
### Standard `constants`

##### Summary

Generic Appointment.

<a name='T-CommonObjectives-DayReport'></a>
## DayReport `type`

##### Namespace

CommonObjectives

##### Summary

DayReport class manages data for the daily report.

<a name='M-CommonObjectives-DayReport-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [DayReport](#T-CommonObjectives-DayReport 'CommonObjectives.DayReport') class.

##### Parameters

This constructor has no parameters.

##### Remarks

Empty constructor for serialization.

<a name='P-CommonObjectives-DayReport-Day'></a>
### Day `property`

##### Summary

The Date value of the report.

<a name='P-CommonObjectives-DayReport-HTML'></a>
### HTML `property`

##### Summary

A string containing the HTML for the report.

<a name='P-CommonObjectives-DayReport-Minutes'></a>
### Minutes `property`

##### Summary

An array of the minute objects for the day.

<a name='P-CommonObjectives-DayReport-TotalIdle'></a>
### TotalIdle `property`

##### Summary

An int value returning the total number of minutes the system was idle during up time.

<a name='P-CommonObjectives-DayReport-TotalUptime'></a>
### TotalUptime `property`

##### Summary

An int value returning the total number of minutes the system was up that day.

<a name='P-CommonObjectives-DayReport-TotalWork'></a>
### TotalWork `property`

##### Summary

An int value returning how many minutes of work time was determined.

<a name='P-CommonObjectives-DayReport-UniqueApplications'></a>
### UniqueApplications `property`

##### Summary

A dictionary of the unique applications from the system monitor.

<a name='P-CommonObjectives-DayReport-WorkItems'></a>
### WorkItems `property`

##### Summary

A dictionary for the Objective's Totals.

<a name='T-CommonObjectives-DrawingSession'></a>
## DrawingSession `type`

##### Namespace

CommonObjectives

##### Summary



<a name='M-CommonObjectives-DrawingSession-#ctor'></a>
### #ctor() `constructor`

##### Summary



##### Parameters

This constructor has no parameters.

<a name='P-CommonObjectives-DrawingSession-Active'></a>
### Active `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-ActiveTime'></a>
### ActiveTime `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Application'></a>
### Application `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Finish'></a>
### Finish `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-FinishSize'></a>
### FinishSize `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-LastActive'></a>
### LastActive `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Name'></a>
### Name `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-ObjectiveName'></a>
### ObjectiveName `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Path'></a>
### Path `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Processed'></a>
### Processed `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Start'></a>
### Start `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-StartSize'></a>
### StartSize `property`

##### Summary



<a name='P-CommonObjectives-DrawingSession-Version'></a>
### Version `property`

##### Summary



<a name='T-CommonObjectives-IWorkItem'></a>
## IWorkItem `type`

##### Namespace

CommonObjectives

##### Summary

Interface to handle multiple work item types.
Currently not implemented.

<a name='P-CommonObjectives-IWorkItem-Finish'></a>
### Finish `property`

##### Summary

The finish of the work item.

<a name='P-CommonObjectives-IWorkItem-Id'></a>
### Id `property`

##### Summary

Index for the item.
GUID is used to make the item database friendly.

<a name='P-CommonObjectives-IWorkItem-ObjectiveName'></a>
### ObjectiveName `property`

##### Summary

Objective Name related to the work item.

<a name='P-CommonObjectives-IWorkItem-Start'></a>
### Start `property`

##### Summary

The start of the work item.

<a name='T-CommonObjectives-Minute'></a>
## Minute `type`

##### Namespace

CommonObjectives

##### Summary

Minute holds data related to the minute of the day.

<a name='M-CommonObjectives-Minute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty constructor for serialization.

##### Parameters

This constructor has no parameters.

<a name='M-CommonObjectives-Minute-#ctor-System-Int32-'></a>
### #ctor(index) `constructor`

##### Summary

Constructor to assign the minute on creation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The minute to use as an index. |

<a name='P-CommonObjectives-Minute-ActiveApplication'></a>
### ActiveApplication `property`

##### Summary

The active application from the system monitor.

<a name='P-CommonObjectives-Minute-ActiveApplicationTitle'></a>
### ActiveApplicationTitle `property`

##### Summary

The title from the application from the system monitor.

<a name='P-CommonObjectives-Minute-Billable'></a>
### Billable `property`

##### Summary

True if the minute contains any Objective work.

<a name='P-CommonObjectives-Minute-Idle'></a>
### Idle `property`

##### Summary

True if the system in an idle state.
True is the screen save would be on if enabled.
WARNING: The value is false when the system is off-line.

<a name='P-CommonObjectives-Minute-Index'></a>
### Index `property`

##### Summary

Index is the minute of the day. (hour * 60 + minute)

<a name='P-CommonObjectives-Minute-PrimaryWorkItem'></a>
### PrimaryWorkItem `property`

##### Summary

WorkItem that was deemed as the primary work item for that minute.
This is currently decided by the lowest workType index.

<a name='P-CommonObjectives-Minute-Up'></a>
### Up `property`

##### Summary

True is the system is on.

<a name='T-CommonObjectives-MonthReport'></a>
## MonthReport `type`

##### Namespace

CommonObjectives

##### Summary

Monthly Report class.

<a name='P-CommonObjectives-MonthReport-Day'></a>
### Day `property`

##### Summary

The Day the report start on.

<a name='P-CommonObjectives-MonthReport-HTML'></a>
### HTML `property`

##### Summary

A string containing the HTML for the report.

<a name='P-CommonObjectives-MonthReport-WorkItems'></a>
### WorkItems `property`

##### Summary

The WorkItems within the month of the report.

<a name='T-CommonObjectives-Note'></a>
## Note `type`

##### Namespace

CommonObjectives

##### Summary

Note holds data for notes created for other objects.

<a name='M-CommonObjectives-Note-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty constructor for serialization.

##### Parameters

This constructor has no parameters.

<a name='M-CommonObjectives-Note-#ctor-System-String,System-String-'></a>
### #ctor(title,content) `constructor`

##### Summary

Constructor to fill data on creation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-CommonObjectives-Note-Content'></a>
### Content `property`

##### Summary

The content of the note.

<a name='P-CommonObjectives-Note-Created'></a>
### Created `property`

##### Summary

The time the note is first created.

<a name='P-CommonObjectives-Note-Id'></a>
### Id `property`

##### Summary

Id for the note.

<a name='P-CommonObjectives-Note-Modified'></a>
### Modified `property`

##### Summary

The time the note is modified.

<a name='P-CommonObjectives-Note-Title'></a>
### Title `property`

##### Summary

The title for the note.

<a name='T-CommonObjectives-Objective'></a>
## Objective `type`

##### Namespace

CommonObjectives

##### Summary

Objective holds data related to an Objective.

<a name='M-CommonObjectives-Objective-#ctor'></a>
### #ctor() `constructor`

##### Summary

Implements a new Objective object.

##### Parameters

This constructor has no parameters.

<a name='P-CommonObjectives-Objective-Archived'></a>
### Archived `property`

##### Summary

Value indicates whether the Objective is currently archived.

<a name='P-CommonObjectives-Objective-Created'></a>
### Created `property`

##### Summary

The time the Objective is created.

<a name='P-CommonObjectives-Objective-ObjectiveName'></a>
### ObjectiveName `property`

##### Summary

The name of the Objective.

<a name='P-CommonObjectives-Objective-Path'></a>
### Path `property`

##### Summary

The path to the folder that holds the Objective.

<a name='P-CommonObjectives-Objective-WorkTypes'></a>
### WorkTypes `property`

##### Summary

The current WorkType values for the Objective.

##### Remarks

If they are not found here then the default values are used.

<a name='T-CommonObjectives-SolutionProject'></a>
## SolutionProject `type`

##### Namespace

CommonObjectives

##### Summary



<a name='P-CommonObjectives-SolutionProject-FileName'></a>
### FileName `property`

##### Summary



<a name='P-CommonObjectives-SolutionProject-FullName'></a>
### FullName `property`

##### Summary



<a name='P-CommonObjectives-SolutionProject-Name'></a>
### Name `property`

##### Summary



<a name='P-CommonObjectives-SolutionProject-UniqueName'></a>
### UniqueName `property`

##### Summary



<a name='T-CommonObjectives-SolutionProperty'></a>
## SolutionProperty `type`

##### Namespace

CommonObjectives

##### Summary



<a name='P-CommonObjectives-SolutionProperty-Name'></a>
### Name `property`

##### Summary



<a name='P-CommonObjectives-SolutionProperty-Value'></a>
### Value `property`

##### Summary



<a name='T-CommonObjectives-SolutionSession'></a>
## SolutionSession `type`

##### Namespace

CommonObjectives

##### Summary



<a name='M-CommonObjectives-SolutionSession-#ctor'></a>
### #ctor() `constructor`

##### Summary



##### Parameters

This constructor has no parameters.

<a name='P-CommonObjectives-SolutionSession-Application'></a>
### Application `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-BuildCount'></a>
### BuildCount `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Finish'></a>
### Finish `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountCompiling'></a>
### FinishFileCountCompiling `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountLinking'></a>
### FinishFileCountLinking `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountProject'></a>
### FinishFileCountProject `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountResource'></a>
### FinishFileCountResource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountSolution'></a>
### FinishFileCountSolution `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountSource'></a>
### FinishFileCountSource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileCountTotal'></a>
### FinishFileCountTotal `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeCompiling'></a>
### FinishFileSizeCompiling `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeLinking'></a>
### FinishFileSizeLinking `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeProject'></a>
### FinishFileSizeProject `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeResource'></a>
### FinishFileSizeResource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeSolution'></a>
### FinishFileSizeSolution `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeSource'></a>
### FinishFileSizeSource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-FinishFileSizeTotal'></a>
### FinishFileSizeTotal `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-HeadItems'></a>
### HeadItems `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Name'></a>
### Name `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-ObjectiveName'></a>
### ObjectiveName `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Path'></a>
### Path `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Processed'></a>
### Processed `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-SolutionCount'></a>
### SolutionCount `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-SolutionFileName'></a>
### SolutionFileName `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-SolutionFullName'></a>
### SolutionFullName `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-SolutionProjects'></a>
### SolutionProjects `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-SolutionProperties'></a>
### SolutionProperties `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Start'></a>
### Start `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountCompiling'></a>
### StartFileCountCompiling `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountLinking'></a>
### StartFileCountLinking `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountProject'></a>
### StartFileCountProject `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountResource'></a>
### StartFileCountResource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountSolution'></a>
### StartFileCountSolution `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountSource'></a>
### StartFileCountSource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileCountTotal'></a>
### StartFileCountTotal `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeCompiling'></a>
### StartFileSizeCompiling `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeLinking'></a>
### StartFileSizeLinking `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeProject'></a>
### StartFileSizeProject `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeResource'></a>
### StartFileSizeResource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeSolution'></a>
### StartFileSizeSolution `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeSource'></a>
### StartFileSizeSource `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-StartFileSizeTotal'></a>
### StartFileSizeTotal `property`

##### Summary



<a name='P-CommonObjectives-SolutionSession-Version'></a>
### Version `property`

##### Summary



<a name='T-CommonObjectives-SystemIdle'></a>
## SystemIdle `type`

##### Namespace

CommonObjectives

##### Summary

SystemIdle class to hold idle event data.

<a name='P-CommonObjectives-SystemIdle-ComputerName'></a>
### ComputerName `property`

##### Summary

The network name of the computer.

<a name='P-CommonObjectives-SystemIdle-Finish'></a>
### Finish `property`

##### Summary

The time the event finished.

<a name='P-CommonObjectives-SystemIdle-Start'></a>
### Start `property`

##### Summary

The time the event started.

<a name='P-CommonObjectives-SystemIdle-UserName'></a>
### UserName `property`

##### Summary

The logged in user of the computer.

<a name='T-CommonObjectives-SystemSleep'></a>
## SystemSleep `type`

##### Namespace

CommonObjectives

##### Summary

SystemSleep class to hold data for system sleep events.

<a name='P-CommonObjectives-SystemSleep-ComputerName'></a>
### ComputerName `property`

##### Summary

The network name of the computer the event is from.

<a name='P-CommonObjectives-SystemSleep-Finish'></a>
### Finish `property`

##### Summary

The time the event finished.

<a name='P-CommonObjectives-SystemSleep-Start'></a>
### Start `property`

##### Summary

The time the event started.

<a name='P-CommonObjectives-SystemSleep-UserName'></a>
### UserName `property`

##### Summary

The logged on user of the computer.

<a name='T-CommonObjectives-SystemType'></a>
## SystemType `type`

##### Namespace

CommonObjectives

##### Summary

Enumeration of System event types.

<a name='F-CommonObjectives-SystemType-Idle'></a>
### Idle `constants`

##### Summary

Idle event.

<a name='F-CommonObjectives-SystemType-None'></a>
### None `constants`

##### Summary

None.

<a name='F-CommonObjectives-SystemType-Sleep'></a>
### Sleep `constants`

##### Summary

Sleep event.

<a name='F-CommonObjectives-SystemType-Uptime'></a>
### Uptime `constants`

##### Summary

Uptime event.

<a name='T-CommonObjectives-SystemUptime'></a>
## SystemUptime `type`

##### Namespace

CommonObjectives

##### Summary

SystemUptime class hold data related to the system's uptime.

<a name='P-CommonObjectives-SystemUptime-ActiveApplications'></a>
### ActiveApplications `property`

##### Summary

A collection of ActiveApplication objects.

##### Remarks

This is data of the focused applications during the event.

<a name='P-CommonObjectives-SystemUptime-ComputerName'></a>
### ComputerName `property`

##### Summary

The network name of the computer.

<a name='P-CommonObjectives-SystemUptime-Finish'></a>
### Finish `property`

##### Summary

The time the event finished.

<a name='P-CommonObjectives-SystemUptime-Start'></a>
### Start `property`

##### Summary

The time the event started.

<a name='P-CommonObjectives-SystemUptime-UserName'></a>
### UserName `property`

##### Summary

The logged on user of the computer.

<a name='T-CommonObjectives-WeekReport'></a>
## WeekReport `type`

##### Namespace

CommonObjectives

##### Summary

WeekReport class to manage the weekly report data.

<a name='P-CommonObjectives-WeekReport-Day'></a>
### Day `property`

##### Summary

The day of the beginning of the report period.

<a name='P-CommonObjectives-WeekReport-HTML'></a>
### HTML `property`

##### Summary

A string containing the HTML for the report.

<a name='P-CommonObjectives-WeekReport-WorkItems'></a>
### WorkItems `property`

##### Summary

A dictionary of WorkItems from the report period.

<a name='T-CommonObjectives-WorkItem'></a>
## WorkItem `type`

##### Namespace

CommonObjectives

##### Summary

WorkItem holds data related to work items.

<a name='M-CommonObjectives-WorkItem-#ctor'></a>
### #ctor() `constructor`

##### Summary

An empty constructor for serialization.

##### Parameters

This constructor has no parameters.

<a name='M-CommonObjectives-WorkItem-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Constructor for the WorkItem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the work item. |

<a name='P-CommonObjectives-WorkItem-Application'></a>
### Application `property`

##### Summary

The application type of the work item.
Some work items are not computer related so have no Application type.

<a name='P-CommonObjectives-WorkItem-Cost'></a>
### Cost `property`

##### Summary

The calculated cost of the work item.

<a name='P-CommonObjectives-WorkItem-Description'></a>
### Description `property`

##### Summary

General description of the work item.

<a name='P-CommonObjectives-WorkItem-FilePath'></a>
### FilePath `property`

##### Summary

File path to the project item's location.

<a name='P-CommonObjectives-WorkItem-Finish'></a>
### Finish `property`

##### Summary

The finish time of the work item.

<a name='P-CommonObjectives-WorkItem-FinishSize'></a>
### FinishSize `property`

##### Summary

A value of the size of the work item at the finish.
This is irreverent for non commuter based items.

<a name='P-CommonObjectives-WorkItem-Id'></a>
### Id `property`

##### Summary

GUID Index.

<a name='P-CommonObjectives-WorkItem-Invoiced'></a>
### Invoiced `property`

##### Summary

A value indicating whether the item has been invoiced.

<a name='P-CommonObjectives-WorkItem-IsActive'></a>
### IsActive `property`

##### Summary

True if the work item was active.

<a name='P-CommonObjectives-WorkItem-Minutes'></a>
### Minutes `property`

##### Summary

The calculated number of minutes for the work item.
Some items have minimum and maximum values for this set contractually so may not be the number of minutes between the start and finish DateTimes.

<a name='P-CommonObjectives-WorkItem-Name'></a>
### Name `property`

##### Summary

Project name.

<a name='P-CommonObjectives-WorkItem-Notes'></a>
### Notes `property`

##### Summary

Collection of notes related to the work item.

<a name='P-CommonObjectives-WorkItem-ObjectiveName'></a>
### ObjectiveName `property`

##### Summary

Objective name.

<a name='P-CommonObjectives-WorkItem-Start'></a>
### Start `property`

##### Summary

The start time of the work item.

<a name='P-CommonObjectives-WorkItem-StartSize'></a>
### StartSize `property`

##### Summary

A value of the size of the work item at the start.
This is irreverent for non commuter based items.

<a name='P-CommonObjectives-WorkItem-Version'></a>
### Version `property`

##### Summary

The version of the WorkItem.

<a name='P-CommonObjectives-WorkItem-WorkType'></a>
### WorkType `property`

##### Summary

The WorkType related to the work item.
This is stored here at the time of creation of the object as the WorkType can be changed.

<a name='T-CommonObjectives-WorkType'></a>
## WorkType `type`

##### Namespace

CommonObjectives

##### Summary

WorkType holds data for work types.

<a name='P-CommonObjectives-WorkType-Application'></a>
### Application `property`

##### Summary

The application that is associated with this work type.

<a name='P-CommonObjectives-WorkType-CostPerHour'></a>
### CostPerHour `property`

##### Summary

The cost per hour for the work type.

<a name='P-CommonObjectives-WorkType-Description'></a>
### Description `property`

##### Summary

The description of the work type.

<a name='P-CommonObjectives-WorkType-Index'></a>
### Index `property`

##### Summary

The index number for the work type.

<a name='P-CommonObjectives-WorkType-MaximNoOfMinutes'></a>
### MaximNoOfMinutes `property`

##### Summary

The maxim number of minutes for the day.

<a name='P-CommonObjectives-WorkType-MinimumNoOfMinutes'></a>
### MinimumNoOfMinutes `property`

##### Summary

The minimum number of minutes for the day.

<a name='P-CommonObjectives-WorkType-Name'></a>
### Name `property`

##### Summary

The name of the work type.
