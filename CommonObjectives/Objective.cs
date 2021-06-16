namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    public class Objective
    {
        public string ObjectiveName { get; set; }
        public string Path { get; set; }
        public bool Archived { get; set; }
        public DateTime Created { get; set; }

        private Dictionary<int, WorkType> workTypes = new Dictionary<int, WorkType>();
        public Dictionary<int, WorkType> WorkTypes
        {
            get { return workTypes; }
            set { workTypes = value; }
        }

        [Obsolete]
        public decimal TotalMoney { get; set; }
        [Obsolete]
        public TimeSpan TotalTime { get; set; }
        [Obsolete]
        public decimal RateConsultation { get; set; }
        [Obsolete]
        public decimal RateAdministration { get; set; }
        [Obsolete]
        public decimal RateVisualStudio { get; set; }
        [Obsolete]
        public decimal RateVisualStudioRead { get; set; }
        [Obsolete]
        public decimal RateSSMS { get; set; }
        [Obsolete]
        public decimal RateSSMSRead { get; set; }
        [Obsolete]
        public decimal RateWord { get; set; }
        [Obsolete]
        public decimal RateWordRead { get; set; }
        [Obsolete]
        public decimal RateExcel { get; set; }
        [Obsolete]
        public decimal RateExcelRead { get; set; }
        [Obsolete]
        public decimal RateAutoCAD { get; set; }
        [Obsolete]
        public decimal RateAutoCADRead { get; set; }

        public Objective()
        {

        }
    }
}