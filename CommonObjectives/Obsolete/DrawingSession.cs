namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///
    /// </summary>
    [Obsolete("Replace with WorkItem.")]
    public class DrawingSession
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ObjectiveName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        ///
        /// </summary>
        public ApplicationType Application { get; set; } = ApplicationType.Autocad;
        /// <summary>
        ///
        /// </summary>
        public int Version { get; set; } = 4;
        /// <summary>
        ///
        /// </summary>
        public bool Processed { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime LastActive { get; set; }
        /// <summary>
        ///
        /// </summary>
        public TimeSpan ActiveTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///
        /// </summary>
        public long StartSize { get; set; }
        /// <summary>
        ///
        /// </summary>
        public long FinishSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DrawingSession()
        {
        }
    }
}