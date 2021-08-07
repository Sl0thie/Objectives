namespace CommonObjectives.Serial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class Objective
    {

        /// <summary>
        /// The name of the Objective.
        /// </summary>
        public string ObjectiveName { get; set; }

        /// <summary>
        /// Value indicates whether the Objective is currently archived.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// The time the Objective is created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
