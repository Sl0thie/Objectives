namespace CommonObjectives
{
    /// <summary>
    /// Enumeration of applications and their state of use.
    /// Write denotes the application was used to produce.
    /// Read denotes the application was used to review.
    /// </summary>
    public enum ApplicationType
    {
        None = 0,
        VisualStudio = 1,
        VisualStudioWrite = 2,
        VisualStudioRead = 3,
        Ssms = 4,
        SsmsWrite = 5,
        SsmsRead = 6,
        Word = 7,
        WordWrite = 8,
        WordRead = 9,
        Excel = 10,
        ExcelWrite = 11,
        ExcelRead = 12,
        Autocad = 13,
        AutocadWrite = 14,
        AutocadRead = 15,
        Project = 16,
        ProjectWrite = 17,
        ProjectRead = 18,
        Visio = 19,
        VisioWrite = 20,
        VisioRead = 21,
    }

    /// <summary>
    /// Enumeration of System event types.
    /// </summary>
    public enum SystemType
    {
        None = 0,
        Uptime = 101,
        Idle = 102,
        Sleep = 103,
    }

    /// <summary>
    /// Enumeration of Outlook Appointment types.
    /// </summary>
    public enum AppointmentType
    {
        None = 0,
        Standard = 1,
        ObjectivesDayReport = 2,
        ObjectivesWeekReport = 3,
        ObjectivesMonthReport = 4,
        ObjectivesQuarterReport = 5,
    }
}