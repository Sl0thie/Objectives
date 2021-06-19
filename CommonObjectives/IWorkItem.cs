namespace CommonObjectives
{
    using System;

    /// <summary>
    /// Interface to handle multiple work item types.</br>
    /// Currently not implemented.
    /// </summary>
    interface IWorkItem
    {
        /// <summary>
        /// Index for the item.</br>
        /// GUID is used to make the item database friendly.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Objective Name related to the work item.</br>
        /// </summary>
        string ObjectiveName { get; set; }

        /// <summary>
        /// The start of the work item.</br>
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        /// The finish of the work item.</br>
        /// </summary>
        DateTime Finish { get; set; }
    }
}