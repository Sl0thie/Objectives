namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Monthly Report class.
    /// </summary>
    public class MonthReport
    {
        private DateTime day;
        private Dictionary<string, WorkItem> workItems = new Dictionary<string, WorkItem>();
        private string hTML;

        /// <summary>
        /// The Day the report start on.
        /// </summary>
        public DateTime Day { get => day; set => day = value; }

        /// <summary>
        /// The WorkItems within the month of the report.
        /// </summary>
        public Dictionary<string, WorkItem> WorkItems
        {
            get { return workItems; }
            set { workItems = value; }
        }

        /// <summary>
        /// A string containing the HTML for the report.
        /// </summary>
        public string HTML
        {
            get { return hTML; }
            set { hTML = value; }
        }
    }
}