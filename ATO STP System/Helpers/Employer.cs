using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATO_STP_System.Helpers
{
    public class Employer
    {
        public string orgName { get; set; }
        public string empName { get; set; }
        public string contactEmail { get; set; }
        public string abnNumber { get; set; }
        public string businessDescription { get; set; }
        public DateTime startYear { get; set; }
        public DateTime endYear { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
    }
}
