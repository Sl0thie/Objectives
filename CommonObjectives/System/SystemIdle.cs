namespace CommonObjectives
{
    using System;

    /// <summary>
    /// SystemIdle class to hold idle event data.
    /// </summary>
    public class SystemIdle
    {
        /// <summary>
        /// The network name of the computer.
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// The logged in user of the computer.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The time the event started.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The time the event finished.
        /// </summary>
        public DateTime Finish { get; set; }
    }
}