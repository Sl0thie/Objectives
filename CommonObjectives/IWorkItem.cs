namespace CommonObjectives
{
    using System;

    interface IWorkItem
    {
        Guid Id { get; set; }

        string ObjectiveName { get; set; }

        DateTime Start { get; set; }

        DateTime Finish { get; set; }

    }
}