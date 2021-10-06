namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DayReport class manages data for the daily report.
    /// </summary>
    public class DayReport
    {
        private Dictionary<string, WorkItem> workItems = new Dictionary<string, WorkItem>();
        private Dictionary<string, int> uniqueApplications = new Dictionary<string, int>();
        private DateTime day;
        private int totalUptime;
        private int totalIdle;
        private int totalWork;
        private Minute[] minutes = new Minute[1440];
        private string hTML;

        /// <summary>
        /// Gets or sets the Date value of the report.
        /// </summary>
        public DateTime Day { get => day; set => day = value; }

        /// <summary>
        /// Gets or sets the int value returning the total number of minutes the system was up that day.
        /// </summary>
        public int TotalUptime { get => totalUptime; set => totalUptime = value; }

        /// <summary>
        /// Gets or sets the int value returning the total number of minutes the system was idle during up time.
        /// </summary>
        public int TotalIdle { get => totalIdle; set => totalIdle = value; }

        /// <summary>
        /// Gets or sets the int value returning how many minutes of work time was determined.
        /// </summary>
        public int TotalWork { get => totalWork; set => totalWork = value; }

        /// <summary>
        /// Gets or sets a dictionary for the Objective's Totals.
        /// </summary>
        public Dictionary<string, WorkItem> WorkItems
        {
            get { return workItems; }
            set { workItems = value; }
        }

        /// <summary>
        /// Gets or sets a dictionary of the unique applications from the system monitor.
        /// </summary>
        public Dictionary<string, int> UniqueApplications
        {
            get { return uniqueApplications; }
            set { uniqueApplications = value; }
        }

        /// <summary>
        /// Gets or sets an array of the minute objects for the day.
        /// </summary>
        public Minute[] Minutes { get => minutes; set => minutes = value; }

        /// <summary>
        /// Gets or sets a string containing the HTML for the report.
        /// </summary>
        public string HTML
        {
            get { return hTML; }
            set { hTML = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DayReport"/> class.
        /// </summary>
        /// <remarks>
        /// Empty constructor for serialization.
        /// </remarks>
        public DayReport()
        {
        }
    }
}