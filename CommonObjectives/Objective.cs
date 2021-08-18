namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Objective holds data related to an Objective.
    /// </summary>
    public class Objective
    {
        private Dictionary<int, WorkType> workTypes = new Dictionary<int, WorkType>();

        /// <summary>
        /// The name of the Objective.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// The path to the folder that holds the Objective.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Value indicates whether the Objective is currently archived.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// The time the Objective is created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The current WorkType values for the Objective.
        /// </summary>
        /// <remarks>
        /// If they are not found here then the default values are used.
        /// </remarks>
        public Dictionary<int, WorkType> WorkTypes
        {
            get { return workTypes; }
            set { workTypes = value; }
        }

        /// <summary>
        /// Gets or sets the ClientEntryID.
        /// This is the Outlook EntryID for the contact that has been designated as the client.
        /// </summary>
        public string ClientEntryID { get; set; }

        /// <summary>
        /// Gets or sets the ClientStoreID.
        /// This is the outlook StoreID of the contacts folder the client's entry is stored in.
        /// </summary>
        public string ClientStoreID { get; set; }

        /// <summary>
        /// Implements a new Objective object.
        /// </summary>
        public Objective()
        {
        }
    }
}