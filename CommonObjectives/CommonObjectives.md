<a name='assembly'></a>
# CommonObjectives

## Contents

- [ActiveApplication](#T-CommonObjectives-ActiveApplication 'CommonObjectives.ActiveApplication')
  - [Application](#P-CommonObjectives-ActiveApplication-Application 'CommonObjectives.ActiveApplication.Application')
  - [Time](#P-CommonObjectives-ActiveApplication-Time 'CommonObjectives.ActiveApplication.Time')
  - [Title](#P-CommonObjectives-ActiveApplication-Title 'CommonObjectives.ActiveApplication.Title')
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
- [Minute](#T-CommonObjectives-Minute 'CommonObjectives.Minute')
  - [#ctor()](#M-CommonObjectives-Minute-#ctor 'CommonObjectives.Minute.#ctor')
  - [#ctor(index)](#M-CommonObjectives-Minute-#ctor-System-Int32- 'CommonObjectives.Minute.#ctor(System.Int32)')
  - [ActiveApplication](#P-CommonObjectives-Minute-ActiveApplication 'CommonObjectives.Minute.ActiveApplication')
  - [ActiveApplicationTitle](#P-CommonObjectives-Minute-ActiveApplicationTitle 'CommonObjectives.Minute.ActiveApplicationTitle')
  - [Billable](#P-CommonObjectives-Minute-Billable 'CommonObjectives.Minute.Billable')
  - [Index](#P-CommonObjectives-Minute-Index 'CommonObjectives.Minute.Index')
  - [Up](#P-CommonObjectives-Minute-Up 'CommonObjectives.Minute.Up')
- [MonthReport](#T-CommonObjectives-MonthReport 'CommonObjectives.MonthReport')
  - [HTML](#P-CommonObjectives-MonthReport-HTML 'CommonObjectives.MonthReport.HTML')
- [WeekReport](#T-CommonObjectives-WeekReport 'CommonObjectives.WeekReport')
  - [HTML](#P-CommonObjectives-WeekReport-HTML 'CommonObjectives.WeekReport.HTML')
- [WorkItem](#T-CommonObjectives-WorkItem 'CommonObjectives.WorkItem')
  - [#ctor()](#M-CommonObjectives-WorkItem-#ctor 'CommonObjectives.WorkItem.#ctor')
  - [#ctor(name)](#M-CommonObjectives-WorkItem-#ctor-System-String- 'CommonObjectives.WorkItem.#ctor(System.String)')
  - [Cost](#P-CommonObjectives-WorkItem-Cost 'CommonObjectives.WorkItem.Cost')
  - [Invoiced](#P-CommonObjectives-WorkItem-Invoiced 'CommonObjectives.WorkItem.Invoiced')
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

<a name='T-CommonObjectives-Minute'></a>
## Minute `type`

##### Namespace

CommonObjectives

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

<a name='P-CommonObjectives-Minute-Index'></a>
### Index `property`

##### Summary

Index is the minute of the day. (hour * 60 + minute)

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

<a name='P-CommonObjectives-WorkItem-Cost'></a>
### Cost `property`

##### Summary

The calculated cost of the work item.

<a name='P-CommonObjectives-WorkItem-Invoiced'></a>
### Invoiced `property`

##### Summary

A value indicating whether the item has been invoiced.

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
