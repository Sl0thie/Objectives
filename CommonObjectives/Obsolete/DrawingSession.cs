namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Obsolete("Replace with WorkItem.")]
    public class DrawingSession
    {
        public string Name { get; set; }
        public string ObjectiveName { get; set; }
        public string Path { get; set; }
        public ApplicationType Application { get; set; } = ApplicationType.Autocad;
        public int Version { get; set; } = 4;
        public bool Processed { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public DateTime LastActive { get; set; }
        public TimeSpan ActiveTime { get; set; }
        public bool Active { get; set; }
        public long StartSize { get; set; }
        public long FinishSize { get; set; }


        public DrawingSession()
        {

        }
    }
}