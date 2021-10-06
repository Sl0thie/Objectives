namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// WorkItem holds data related to work items.
    /// </summary>
    public class WorkItem : IWorkItem
    {
        private readonly Collection<Note> notes = new Collection<Note>();

        /// <summary>
        /// Gets or sets the GUID Index.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the version of the WorkItem.
        /// </summary>
        public int Version { get; set; } = 5;

        /// <summary>
        /// Gets or sets the Objective name.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the start time of the work item.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the finish time of the work item.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Gets or sets the File path to the project item's location.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the General description of the work item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a collection of notes related to the work item.
        /// </summary>
        public Collection<Note> Notes
        {
            get { return notes; }
        }

        /// <summary>
        /// Gets or sets the WorkType related to the work item.
        /// This is stored here at the time of creation of the object as the WorkType can be changed.
        /// </summary>
        public WorkType WorkType { get; set; }

        /// <summary>
        /// Gets or sets the application type of the work item.
        /// Some work items are not computer related so have no Application type.
        /// </summary>
        public ApplicationType Application { get; set; }

        /// <summary>
        /// Gets or sets the calculated number of minutes for the work item.
        /// Some items have minimum and maximum values for this set contractually so may not be the number of minutes between the start and finish DateTimes.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Gets or sets the calculated cost of the work item.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has been invoiced.
        /// </summary>
        public bool Invoiced { get; set; }

        /// <summary>
        /// Gets or sets a value of the size of the work item at the start.
        /// This is irreverent for non commuter based items.
        /// </summary>
        public long StartSize { get; set; }

        /// <summary>
        /// Gets or sets the a value of the size of the work item at the finish.
        /// This is irreverent for non commuter based items.
        /// </summary>
        public long FinishSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the work item is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItem"/> class.
        /// </summary>
        public WorkItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItem"/> class.
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