namespace CommonObjectives.Serial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Objective class.
    /// </summary>
    public class Objective
    {
        /// <summary>
        /// Gets or sets the name of the Objective.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Objective is currently archived.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the time the Objective is created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
