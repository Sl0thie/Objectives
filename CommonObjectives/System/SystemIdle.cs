namespace CommonObjectives
{
    using System;

    /// <summary>
    /// SystemIdle class to hold idle event data.
    /// </summary>
    public class SystemIdle
    {
        /// <summary>
        /// Gets or sets the network name of the computer.
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the logged in user of the computer.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the time the event started.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the time the event finished.
        /// </summary>
        public DateTime Finish { get; set; }
    }
}