namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Minute holds data related to the minute of the day.
    /// </summary>
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
        /// True if the system in an idle state.
        /// True is the screen save would be on if enabled.
        /// WARNING: The value is false when the system is off-line.
        /// </summary>
        public bool Idle { get; set; } = false;

        /// <summary>
        /// True if the minute contains any Objective work.
        /// </summary>
        public bool Billable { get; set; }

        /// <summary>
        /// WorkItem that was deemed as the primary work item for that minute.
        /// This is currently decided by the lowest workType index.
        /// </summary>
        public WorkItem PrimaryWorkItem { get; set; }

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