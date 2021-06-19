namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    [Obsolete("Replaced by WorkItem")]
    public class SolutionSession
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectiveName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ApplicationType Application { get; set; } = ApplicationType.VisualStudioWrite;
        /// <summary>
        /// 
        /// </summary>
        public int Version { get; set; } = 4;
        /// <summary>
        /// 
        /// </summary>
        public bool Processed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SolutionCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SolutionFileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SolutionFullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Collection<SolutionProject> SolutionProjects { get; set; } = new Collection<SolutionProject>();
        /// <summary>
        /// 
        /// </summary>
        public Collection<SolutionProperty> SolutionProperties { get; set; } = new Collection<SolutionProperty>();
        /// <summary>
        /// 
        /// </summary>
        public int BuildCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountCompiling { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountLinking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountResource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartFileCountSolution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeCompiling { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeLinking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeResource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StartFileSizeSolution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountCompiling { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountLinking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountResource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FinishFileCountSolution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeCompiling { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeLinking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeProject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeResource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FinishFileSizeSolution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Collection<string> HeadItems { get; set; } = new Collection<string>();

        /// <summary>
        /// 
        /// </summary>
        public SolutionSession()
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SolutionProject
    {
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UniqueName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SolutionProperty
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}
