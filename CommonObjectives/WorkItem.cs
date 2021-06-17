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
        private readonly Collection<Note> notes = new Collection<Note>();

        /// <summary>
        /// GUID Index.
        /// </summary>
        public Guid Id { get; set; }

        public int Version { get; set; } = 5;

        /// <summary>
        /// Objective name.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// The start time of the work item.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The finish time of the work item.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// File path to the project item's location.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// General description of the work item.
        /// </summary>
        public string Description { get; set; }

        public Collection<Note> Notes
        {
            get { return notes; }
        }

        [Obsolete("Use WorkType instead.")]
        public int WorkTypeIndex { get; set; }

        public WorkType WorkType { get; set; }


        public ApplicationType Application { get; set; }

        public int Minutes { get; set; }

        public decimal Cost { get; set; }

        public bool Invoiced { get; set; }


        public WorkItem()
        {
        }

        public WorkItem(string name)
        {
            Id = Guid.NewGuid();
            Start = DateTime.Parse(DateTime.Now.ToString(@"yyyy-MM-dd HH:mm"));
            Name = name;
        }
    }
}