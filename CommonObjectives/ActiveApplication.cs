namespace CommonObjectives
{
    using System;

    /// <summary>
    /// ActiveApplication class contains related to the application that was in focus at the time..
    /// </summary>
    public class ActiveApplication
    {
        /// <summary>
        /// Gets or sets the time is was measured.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the title of the focused application.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the application name that is focused.
        /// </summary>
        public string Application { get; set; }
    }
}