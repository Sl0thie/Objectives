namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// SystemUptime class hold data related to the system's uptime.
    /// </summary>
    public class SystemUptime
    {
        private readonly Collection<ActiveApplication> activeApplications = new Collection<ActiveApplication>();

        /// <summary>
        /// Gets or sets the network name of the computer.
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

        /// <summary>
        /// Gets a collection of ActiveApplication objects.
        /// </summary>
        /// <remarks>
        /// This is data of the focused applications during the event.
        /// </remarks>
        public Collection<ActiveApplication> ActiveApplications
        {
            get { return activeApplications; }
        }
    }
}
