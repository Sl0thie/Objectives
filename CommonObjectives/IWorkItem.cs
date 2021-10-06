namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Interface to handle multiple work item types.
    /// Currently not implemented.
    /// </summary>
    internal interface IWorkItem
    {
        /// <summary>
        /// Gets or sets the Index for the item.
        /// GUID is used to make the item database friendly.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Objective Name related to the work item.
        /// </summary>
        string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the start of the work item.
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the finish of the work item.
        /// </summary>
        DateTime Finish { get; set; }
    }
}