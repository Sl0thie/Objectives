namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    public class Minute
    {
        //private readonly Collection<Tuple<int, string, string, string>> projects = new Collection<Tuple<int, string, string, string>>();

        //private readonly Collection<WorkItem> workItems = new Collection<WorkItem>();

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


        //public Collection<WorkItem> WorkItems
        //{
        //    get { return workItems; }
        //}

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
        /// A collection of information to help in deciding the primary items.</br>
        /// This is not of fixed design yet. Still in process.
        /// Item1: WorkType.
        /// Item2: Path.
        /// Item3: Objective Name.
        /// Item4: Name.
        /// Item5: IsWork.
        /// </summary>
        //public Collection<Tuple<int, string, string, string>> Projects
        //{
        //    get { return projects; }
        //}

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