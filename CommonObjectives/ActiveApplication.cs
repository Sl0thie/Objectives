namespace CommonObjectives
{
    using System;

    /// <summary>
    /// ActiveApplication class contains related to the application that was in focus at the time..
    /// </summary>
    /// <
    public class ActiveApplication
    {
        /// <summary>
        /// The time is was measured.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The title of the focused application.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The application name that is focused.
        /// </summary>
        public string Application { get; set; }
    }
}