namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// WorkItem holds data related to work items.</br>
    /// </summary>
    public class WorkItem : IWorkItem
    {
        private readonly Collection<Note> notes = new Collection<Note>();

        /// <summary>
        /// GUID Index.</br>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The version of the WorkItem.</br>
        /// </summary>
        public int Version { get; set; } = 5;

        /// <summary>
        /// Objective name.</br>
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// The start time of the work item.</br>
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The finish time of the work item.</br>
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// File path to the project item's location.</br>
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Project name.</br>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// General description of the work item.</br>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of notes related to the work item.</br>
        /// </summary>
        public Collection<Note> Notes
        {
            get { return notes; }
        }

        /// <summary>
        /// The WorkType related to the work item.</br>
        /// This is stored here at the time of creation of the object as the WorkType can be changed.
        /// </summary>
        public WorkType WorkType { get; set; }

        /// <summary>
        /// The application type of the work item.</br>
        /// Some work items are not computer related so have no Application type.
        /// </summary>
        public ApplicationType Application { get; set; }

        /// <summary>
        /// The calculated number of minutes for the work item.</br>
        /// Some items have minimum and maximum values for this set contractually so may not be the number of minutes between the start and finish DateTimes.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// The calculated cost of the work item.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// A value indicating whether the item has been invoiced.
        /// </summary>
        public bool Invoiced { get; set; }

        /// <summary>
        /// A value of the size of the work item at the start.</br>
        /// This is irreverent for non commuter based items.
        /// </summary>
        public long StartSize { get; set; }

        /// <summary>
        /// A value of the size of the work item at the finish.</br>
        /// This is irreverent for non commuter based items.
        /// </summary>
        public long FinishSize { get; set; }


        /// <summary>
        /// An empty constructor for serialization.
        /// </summary>
        public WorkItem()
        {
        }

        /// <summary>
        /// Constructor for the WorkItem.
        /// </summary>
        /// <param name="name">The name of the work item.</param>
        public WorkItem(string name)
        {
            Id = Guid.NewGuid();
            Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            Name = name;
        }
    }
}