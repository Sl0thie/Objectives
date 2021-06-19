namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Objective holds data related to an Objective.</br>
    /// </summary>
    public class Objective
    {
        /// <summary>
        /// The name of the Objective.</br>
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// The path to the folder that holds the Objective.</br>
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Value indicates whether the Objective is currently archived.</br>
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// The time the Objective is created.</br>
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The current WorkType values for the Objective.</br>
        /// If they are not found here then the default values are used.
        /// </summary>
        private Dictionary<int, WorkType> workTypes = new Dictionary<int, WorkType>();
        public Dictionary<int, WorkType> WorkTypes
        {
            get { return workTypes; }
            set { workTypes = value; }
        }

        public Objective()
        {

        }
    }
}