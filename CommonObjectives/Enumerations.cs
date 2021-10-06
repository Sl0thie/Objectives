namespace CommonObjectives
{
    /// <summary>
    /// Enumeration of applications and their state of use.
    /// Write denotes the application was used to produce.
    /// Read denotes the application was used to review.
    /// </summary>
    public enum ApplicationType
    {
        /// <summary>
        /// No application.
        /// </summary>
        None = 0,

        /// <summary>
        /// Visual Studio.
        /// </summary>
        VisualStudio = 1,

        /// <summary>
        /// Writing with Visual Studio.
        /// </summary>
        VisualStudioWrite = 2,

        /// <summary>
        /// Reviewing with Visual Studio.
        /// </summary>
        VisualStudioRead = 3,

        /// <summary>
        /// SQL Server Management Studio.
        /// </summary>
        Ssms = 4,

        /// <summary>
        /// Writing with SQL Server Management Studio.
        /// </summary>
        SsmsWrite = 5,

        /// <summary>
        /// Reviewing with SQL Server Management Studio.
        /// </summary>
        SsmsRead = 6,

        /// <summary>
        /// Microsoft Word.
        /// </summary>
        Word = 7,

        /// <summary>
        /// Writing with Microsoft Word.
        /// </summary>
        WordWrite = 8,

        /// <summary>
        /// Reviewing with Microsoft Word.
        /// </summary>
        WordRead = 9,

        /// <summary>
        /// Microsoft Excel.
        /// </summary>
        Excel = 10,

        /// <summary>
        /// Writing with Microsoft Excel.
        /// </summary>
        ExcelWrite = 11,

        /// <summary>
        /// Reviewing with Microsoft Excel.
        /// </summary>
        ExcelRead = 12,

        /// <summary>
        /// Autodesk AutoCAD.
        /// </summary>
        Autocad = 13,

        /// <summary>
        /// Writing with AutoCAD.
        /// </summary>
        AutocadWrite = 14,

        /// <summary>
        /// Reviewing with AutoCAD.
        /// </summary>
        AutocadRead = 15,

        /// <summary>
        /// Microsoft Project.
        /// </summary>
        Project = 16,

        /// <summary>
        /// Writing with Microsoft Project.
        /// </summary>
        ProjectWrite = 17,

        /// <summary>
        /// Reviewing with Microsoft Project.
        /// </summary>
        ProjectRead = 18,

        /// <summary>
        /// Microsoft Visio.
        /// </summary>
        Visio = 19,

        /// <summary>
        /// Writing with Microsoft Visio.
        /// </summary>
        VisioWrite = 20,

        /// <summary>
        /// Reviewing with Microsoft Visio.
        /// </summary>
        VisioRead = 21,
    }

    /// <summary>
    /// Enumeration of System event types.
    /// </summary>
    public enum SystemType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Uptime event.
        /// </summary>
        Uptime = 101,

        /// <summary>
        /// Idle event.
        /// </summary>
        Idle = 102,

        /// <summary>
        /// Sleep event.
        /// </summary>
        Sleep = 103,
    }

    /// <summary>
    /// Enumeration of Outlook Appointment types.
    /// </summary>
    public enum AppointmentType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Generic Appointment.
        /// </summary>
        Standard = 1,

        /// <summary>
        /// Daily Report Appointment.
        /// </summary>
        ObjectivesDayReport = 2,

        /// <summary>
        /// Weekly Report Appointment.
        /// </summary>
        ObjectivesWeekReport = 3,

        /// <summary>
        /// Monthly Report Appointment.
        /// </summary>
        ObjectivesMonthReport = 4,

        /// <summary>
        /// Quarterly Report Appointment.
        /// </summary>
        ObjectivesQuarterReport = 5,
    }
}