namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// WeekReport class to manage the weekly report data.
    /// </summary>
    public class WeekReport
    {
        private DateTime day;
        private Dictionary<string, WorkItem> workItems = new Dictionary<string, WorkItem>();
        private string hTML;

        /// <summary>
        /// Gets or sets the day of the beginning of the report period.
        /// </summary>
        public DateTime Day { get => day; set => day = value; }

        /// <summary>
        /// Gets or sets a dictionary of WorkItems from the report period.
        /// </summary>
        public Dictionary<string, WorkItem> WorkItems
        {
            get { return workItems; }
            set { workItems = value; }
        }

        /// <summary>
        /// Gets or sets a string containing the HTML for the report.
        /// </summary>
        public string HTML
        {
            get { return hTML; }
            set { hTML = value; }
        }
    }
}