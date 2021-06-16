namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkType
    {
        /// <summary>
        /// The index number for the work type.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The name of the work type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the work type.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// The cost per hour for the work type.
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// The minimum number of minutes for the day.
        /// </summary>
        public int MinimumNoOfMinutes { get; set; }

        /// <summary>
        /// The maxim number of minutes for the day.
        /// </summary>
        public int MaximNoOfMinutes { get; set; }

        /// <summary>
        /// The application that is associated with this work type.
        /// </summary>
        public ApplicationType Application { get; set; }


        public bool ApplicationActive { get; set; }

        /// <summary>
        /// If the work type is active. Some applications are just viewing.
        /// </summary>
        public bool Active { get; set; }


    }
}
