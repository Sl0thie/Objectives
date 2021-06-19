<a name='assembly'></a>
# CommonObjectives

## Contents

- [ActiveApplication](#T-CommonObjectives-ActiveApplication 'CommonObjectives.ActiveApplication')
  - [Application](#P-CommonObjectives-ActiveApplication-Application 'CommonObjectives.ActiveApplication.Application')
  - [Time](#P-CommonObjectives-ActiveApplication-Time 'CommonObjectives.ActiveApplication.Time')
  - [Title](#P-CommonObjectives-ActiveApplication-Title 'CommonObjectives.ActiveApplication.Title')
- [ApplicationType](#T-CommonObjectives-ApplicationType 'CommonObjectives.ApplicationType')
- [AppointmentType](#T-CommonObjectives-AppointmentType 'CommonObjectives.AppointmentType')
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
  - [HTML](#P-CommonObjectives-MonthReport-HTML 'CommonObjectives.MonthReport.HTML')
- [Note](#T-CommonObjectives-Note 'CommonObjectives.Note')
  - [#ctor()](#M-CommonObjectives-Note-#ctor 'CommonObjectives.Note.#ctor')
  - [#ctor(title,content)](#M-CommonObjectives-Note-#ctor-System-String,System-String- 'CommonObjectives.Note.#ctor(System.String,System.String)')
  - [Content](#P-CommonObjectives-Note-Content 'CommonObjectives.Note.Content')
  - [Created](#P-CommonObjectives-Note-Created 'CommonObjectives.Note.Created')
  - [Id](#P-CommonObjectives-Note-Id 'CommonObjectives.Note.Id')
  - [Modified](#P-CommonObjectives-Note-Modified 'CommonObjectives.Note.Modified')
  - [Title](#P-CommonObjectives-Note-Title 'CommonObjectives.Note.Title')
- [Objective](#T-CommonObjectives-Objective 'CommonObjectives.Objective')
  - [workTypes](#F-CommonObjectives-Objective-workTypes 'CommonObjectives.Objective.workTypes')
  - [Archived](#P-CommonObjectives-Objective-Archived 'CommonObjectives.Objective.Archived')
  - [Created](#P-CommonObjectives-Objective-Created 'CommonObjectives.Objective.Created')
  - [ObjectiveName](#P-CommonObjectives-Objective-ObjectiveName 'CommonObjectives.Objective.ObjectiveName')
  - [Path](#P-CommonObjectives-Objective-Path 'CommonObjectives.Objective.Path')
- [SystemType](#T-CommonObjectives-SystemType 'CommonObjectives.SystemType')
- [WeekReport](#T-CommonObjectives-WeekReport 'CommonObjectives.WeekReport')
  - [HTML](#P-CommonObjectives-WeekReport-HTML 'CommonObjectives.WeekReport.HTML')
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

<a name='T-CommonObjectives-AppointmentType'></a>
## AppointmentType `type`

##### Namespace

CommonObjectives

##### Summary

Enumeration of Outlook Appointment types.

<a name='T-CommonObjectives-DayReport'></a>
## DayReport `type`

##### Namespace

CommonObjectives

<a name='M-CommonObjectives-DayReport-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty constructor for serialization.

##### Parameters

This constructor has no parameters.

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

<a name='P-CommonObjectives-MonthReport-HTML'></a>
### HTML `property`

##### Summary

A string containing the HTML for the report.

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

<a name='F-CommonObjectives-Objective-workTypes'></a>
### workTypes `constants`

##### Summary

The current WorkType values for the Objective.
If they are not found here then the default values are used.

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

<a name='T-CommonObjectives-SystemType'></a>
## SystemType `type`

##### Namespace

CommonObjectives

##### Summary

Enumeration of System event types.

<a name='T-CommonObjectives-WeekReport'></a>
## WeekReport `type`

##### Namespace

CommonObjectives

<a name='P-CommonObjectives-WeekReport-HTML'></a>
### HTML `property`

##### Summary

A string containing the HTML for the report.

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
