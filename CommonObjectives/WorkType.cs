namespace CommonObjectives
{
    /// <summary>
    /// WorkType holds data for work types.
    /// </summary>
    public class WorkType
    {
        /// <summary>
        /// Gets or sets the index number for the work type.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the name of the work type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the work type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the cost per hour for the work type.
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of minutes for the day.
        /// </summary>
        public int MinimumNoOfMinutes { get; set; }

        /// <summary>
        /// Gets or sets the maxim number of minutes for the day.
        /// </summary>
        public int MaximNoOfMinutes { get; set; }

        /// <summary>
        /// Gets or sets the application that is associated with this work type.
        /// </summary>
        public ApplicationType Application { get; set; }
    }
}