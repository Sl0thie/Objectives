namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// DrawingSession class.
    /// </summary>
    [Obsolete("Replace with WorkItem.")]
    public class DrawingSession
    {
        /// <summary>
        /// Gets or sets the Name of the drawing session.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ObjectiveName.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the path of the drawing session.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the application type.
        /// </summary>
        public ApplicationType Application { get; set; } = ApplicationType.Autocad;

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        public int Version { get; set; } = 4;

        /// <summary>
        /// Gets or sets a value indicating whether this object has been processed.
        /// </summary>
        public bool Processed { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the finish time.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Gets or sets the last active time.
        /// </summary>
        public DateTime LastActive { get; set; }

        /// <summary>
        /// Gets or sets the active time.
        /// </summary>
        public TimeSpan ActiveTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the object is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the start size.
        /// </summary>
        public long StartSize { get; set; }

        /// <summary>
        /// Gets or sets the finish time.
        /// </summary>
        public long FinishSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingSession"/> class.
        /// </summary>
        public DrawingSession()
        {
        }
    }
}