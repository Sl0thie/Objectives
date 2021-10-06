namespace CommonObjectives
{
    using System;

    /// <summary>
    /// SystemSleep class to hold data for system sleep events.
    /// </summary>
    public class SystemSleep
    {
        /// <summary>
        /// Gets or sets the network name of the computer the event is from.
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the logged on user of the computer.
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
