# CommonObjectives #

## Type ActiveApplication

 ActiveApplication holds data for the application that is focused. 



---
#### Property ActiveApplication.Time

 The time is was measured. 



---
#### Property ActiveApplication.Title

 The title of the focused application. 



---
#### Property ActiveApplication.Application

 The application name that is focused. 



---
#### Property DayReport.Day

 The Date value of the report. 



---
#### Property DayReport.TotalUptime

 An int value returning the total number of minutes the system was up that day. 



---
#### Property DayReport.TotalIdle

 An int value returning the total number of minutes the system was idle during up time. 



---
#### Property DayReport.TotalWork

 An int value returning how many minutes of work time was determined. 



---
#### Property DayReport.WorkItems

 A dictionary for the Objective's Totals. 



---
#### Property DayReport.UniqueApplications

 A dictionary of the unique applications from the system monitor. 



---
#### Property DayReport.Minutes

 An array of the minute objects for the day. 



---
#### Property DayReport.HTML

 A string containing the HTML for the report. 



---
#### Method DayReport.#ctor

 Empty constructor for serialization. 



---
#### Property Minute.Index

 Index is the minute of the day. (hour * 60 + minute) 



---
#### Property Minute.ActiveApplication

 The active application from the system monitor. 



---
#### Property Minute.ActiveApplicationTitle

 The title from the application from the system monitor. 



---
#### Property Minute.Up

 True is the system is on. 



---
#### Property Minute.Billable

 True if the minute contains any Objective work. 



---
#### Method Minute.#ctor

 Empty constructor for serialization. 



---
#### Method Minute.#ctor(System.Int32)

 Constructor to assign the minute on creation. 

|Name | Description |
|-----|------|
|index: |The minute to use as an index.|


---
#### Property MonthReport.HTML

 A string containing the HTML for the report. 



---
#### Property WeekReport.HTML

 A string containing the HTML for the report. 



---
#### Property WorkItem.Cost

 The calculated cost of the work item. 



---
#### Property WorkItem.Invoiced

 A value indicating whether the item has been invoiced. 



---
#### Method WorkItem.#ctor

 An empty constructor for serialization. 



---
#### Method WorkItem.#ctor(System.String)

 Constructor for the WorkItem. 

|Name | Description |
|-----|------|
|name: |The name of the work item.|


---
## Type WorkType

 WorkType holds data for work types. 



---
#### Property WorkType.Index

 The index number for the work type. 



---
#### Property WorkType.Name

 The name of the work type. 



---
#### Property WorkType.Description

 The description of the work type. 



---
#### Property WorkType.CostPerHour

 The cost per hour for the work type. 



---
#### Property WorkType.MinimumNoOfMinutes

 The minimum number of minutes for the day. 



---
#### Property WorkType.MaximNoOfMinutes

 The maxim number of minutes for the day. 



---
#### Property WorkType.Application

 The application that is associated with this work type. 



---


