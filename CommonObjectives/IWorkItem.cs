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
        /// Index for the item.
        /// GUID is used to make the item database friendly.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Objective Name related to the work item.
        /// </summary>
        string ObjectiveName { get; set; }

        /// <summary>
        /// The start of the work item.
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        /// The finish of the work item.
        /// </summary>
        DateTime Finish { get; set; }
    }
}