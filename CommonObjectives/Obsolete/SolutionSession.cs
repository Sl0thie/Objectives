namespace CommonObjectives
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// SolutionSession class.
    /// </summary>
    [Obsolete("Replaced by WorkItem")]
    public class SolutionSession
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the objective name.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the application type.
        /// </summary>
        public ApplicationType Application { get; set; } = ApplicationType.VisualStudioWrite;

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        public int Version { get; set; } = 4;

        /// <summary>
        /// Gets or sets a value indicating whether the object has been processed.
        /// </summary>
        public bool Processed { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the finish time.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Gets or sets the solution count.
        /// </summary>
        public int SolutionCount { get; set; }

        /// <summary>
        /// Gets or sets the solution file name.
        /// </summary>
        public string SolutionFileName { get; set; }

        /// <summary>
        /// Gets or sets the solution's full name.
        /// </summary>
        public string SolutionFullName { get; set; }

        /// <summary>
        /// Gets or sets the solution projects collection.
        /// </summary>
        public Collection<SolutionProject> SolutionProjects { get; set; } = new Collection<SolutionProject>();

        /// <summary>
        /// Gets or sets the solution properties collection.
        /// </summary>
        public Collection<SolutionProperty> SolutionProperties { get; set; } = new Collection<SolutionProperty>();

        /// <summary>
        /// Gets or sets the build count.
        /// </summary>
        public int BuildCount { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountTotal { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountCompiling { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountLinking { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountProject { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountResource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountSource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int StartFileCountSolution { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeTotal { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeCompiling { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeLinking { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeProject { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeResource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeSource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long StartFileSizeSolution { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountTotal { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountCompiling { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountLinking { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountProject { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountResource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountSource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public int FinishFileCountSolution { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeTotal { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeCompiling { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeLinking { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeProject { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeResource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeSource { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public long FinishFileSizeSolution { get; set; }

        /// <summary>
        /// Gets or sets the start file count.
        /// </summary>
        public Collection<string> HeadItems { get; set; } = new Collection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionSession"/> class.
        /// </summary>
        public SolutionSession()
        {
        }
    }

    /// <summary>
    /// SolutionProject class.
    /// </summary>
    public class SolutionProject
    {
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique name.
        /// </summary>
        public string UniqueName { get; set; }
    }

    /// <summary>
    /// SolutionProperty class.
    /// </summary>
    public class SolutionProperty
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}
