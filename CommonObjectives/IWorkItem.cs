namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IWorkItem
    {
        Guid Id { get; set; }

        int Version { get; set; }

        string ObjectiveName { get; set; }

        DateTime Start { get; set; }

        DateTime Finish { get; set; }





    }
}
