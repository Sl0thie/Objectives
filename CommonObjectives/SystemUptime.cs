namespace CommonObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SystemUptime
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }



        private readonly Collection<ActiveApplication> activeApplications = new Collection<ActiveApplication>();
        public Collection<ActiveApplication> ActiveApplications
        {
            get { return activeApplications; }
        }
    }
}
