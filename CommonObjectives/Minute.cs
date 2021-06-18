namespace CommonObjectives
{
    using System;

    public class Minute
    {
        /// <summary>
        /// Index is the minute of the day. (hour * 60 + minute)
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The active application from the system monitor.
        /// </summary>
        public string ActiveApplication { get; set; }

        /// <summary>
        /// The title from the application from the system monitor.
        /// </summary>
        public string ActiveApplicationTitle { get; set; }

        /// <summary>
        /// True is the system is on.
        /// </summary>
        public bool Up { get; set; } = false;

        /// <summary>
        /// True if the system in an idle state.</br>
        /// True is the screen save would be on if enabled.
        /// WARNING: The value is false when the system is off-line.
        /// </summary>
        public bool Idle { get; set; } = false;

        /// <summary>
        /// True if the minute contains any Objective work.
        /// </summary>
        public bool Billable { get; set; }


        public WorkItem PrimaryWorkItem { get; set; }

        /// <summary>
        /// The Objective name that has been deemed the primary.</br>
        /// If two or more are active at the same time, one must be chosen for billing.
        /// TODO: The User should have more control over this.
        /// </summary>
        [Obsolete]
        public string PrimaryObjective { get; set; }

        /// <summary>
        /// The Name of the Project that was deemed the primary.
        /// </summary>
        [Obsolete]
        public string PrimaryName { get; set; }

        /// <summary>
        /// The path to the primary.
        /// </summary>
        [Obsolete]
        public string PrimaryPath { get; set; }

        /// <summary>
        /// The Application type of the primary.
        /// </summary>
        [Obsolete]
        public ApplicationType PrimaryApplicationType { get; set; }

        /// <summary>
        /// The primary work type index for the minute.
        /// </summary>
        [Obsolete]
        public int PrimaryWorkTypeIndex { get; set; }

        /// <summary>
        /// Empty constructor for serialization.
        /// </summary>
        public Minute()
        {

        }

        /// <summary>
        /// Constructor to assign the minute on creation.
        /// </summary>
        /// <param name="index">The minute to use as an index.</param>
        public Minute(int index)
        {
            this.Index = index;
        }
    }
}