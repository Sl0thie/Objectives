namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkItem : IWorkItem
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ObjectiveName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Start { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Finish { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        private readonly Collection<string> notes = new Collection<string>();

        /// <summary>
        /// File path to the project item's location.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Objective name.
        /// </summary>
        public string Objective { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// General description of the work item.
        /// </summary>
        public string Description { get; set; }

        public Collection<string> Notes
        {
            get { return notes; }
        }

        public int WorkTypeIndex { get; set; }

        public int Minutes { get; set; }

        public decimal Cost { get; set; }

        public bool Invoiced { get; set; }
        
    }
}
