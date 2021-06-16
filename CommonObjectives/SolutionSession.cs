namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    public class SolutionSession
    {
        public string Name { get; set; }
        public string ObjectiveName { get; set; }
        public ApplicationType Application { get; set; } = ApplicationType.VisualStudioWrite;
        public int Version { get; set; } = 4;
        public bool Processed { get; set; }
        public string Path { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }


        public int SolutionCount { get; set; }
        public string SolutionFileName { get; set; }
        public string SolutionFullName { get; set; }
        public Collection<SolutionProject> SolutionProjects { get; set; } = new Collection<SolutionProject>();
        public Collection<SolutionProperty> SolutionProperties { get; set; } = new Collection<SolutionProperty>();
        public int BuildCount { get; set; }
        public int StartFileCountTotal { get; set; }
        public int StartFileCountCompiling { get; set; }
        public int StartFileCountLinking { get; set; }
        public int StartFileCountProject { get; set; }
        public int StartFileCountResource { get; set; }
        public int StartFileCountSource { get; set; }
        public int StartFileCountSolution { get; set; }

        public long StartFileSizeTotal { get; set; }
        public long StartFileSizeCompiling { get; set; }
        public long StartFileSizeLinking { get; set; }
        public long StartFileSizeProject { get; set; }
        public long StartFileSizeResource { get; set; }
        public long StartFileSizeSource { get; set; }
        public long StartFileSizeSolution { get; set; }

        public int FinishFileCountTotal { get; set; }
        public int FinishFileCountCompiling { get; set; }
        public int FinishFileCountLinking { get; set; }
        public int FinishFileCountProject { get; set; }
        public int FinishFileCountResource { get; set; }
        public int FinishFileCountSource { get; set; }
        public int FinishFileCountSolution { get; set; }

        public long FinishFileSizeTotal { get; set; }
        public long FinishFileSizeCompiling { get; set; }
        public long FinishFileSizeLinking { get; set; }
        public long FinishFileSizeProject { get; set; }
        public long FinishFileSizeResource { get; set; }
        public long FinishFileSizeSource { get; set; }
        public long FinishFileSizeSolution { get; set; }

        public Collection<string> HeadItems { get; set; } = new Collection<string>();

        public SolutionSession()
        {

        }
    }

    public class SolutionProject
    {
        public string FileName { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string UniqueName { get; set; }
    }

    public class SolutionProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
