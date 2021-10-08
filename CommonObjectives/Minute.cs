namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Minute holds data related to the minute of the day.
    /// </summary>
    public class Minute
    {
        /// <summary>
        /// Gets or sets the Index is the minute of the day. (hour * 60 + minute).
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the active application from the system monitor.
        /// </summary>
        public string ActiveApplication { get; set; }

        /// <summary>
        /// Gets or sets the title from the application from the system monitor.
        /// </summary>
        public string ActiveApplicationTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the system is on.
        /// </summary>
        public bool Up { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the system in an idle state.
        /// True is the screen save would be on if enabled.
        /// WARNING: The value is false when the system is off-line.
        /// </summary>
        public bool Idle { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the minute contains any Objective work.
        /// </summary>
        public bool Billable { get; set; }

        /// <summary>
        /// Gets or sets the WorkItem that was deemed as the primary work item for that minute.
        /// This is currently decided by the lowest workType index.
        /// </summary>
        public WorkItem PrimaryWorkItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Minute"/> class.
        /// </summary>
        public Minute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Minute"/> class.
        /// </summary>
        /// <param name="index">The minute to use as an index.</param>
        public Minute(int index)
        {
            Index = index;
        }
    }
}