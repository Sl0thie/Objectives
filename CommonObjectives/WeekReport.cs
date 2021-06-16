namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WeekReport
    {
        private DateTime day;
        private Dictionary<string, WorkItem> workItems = new Dictionary<string, WorkItem>();
        private string hTML;

        public DateTime Day { get => day; set => day = value; }

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