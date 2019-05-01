using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATO_STP_System.Helpers
{
    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int dobDay { get; set; }
        public int dobMonth { get; set; }
        public int dobYear { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public DateTime payFrom { get; set; }
        public DateTime payTo { get; set; }
        public decimal grossAmount { get; set; }
        public decimal taxWithheld { get; set; }
        public decimal superContribution { get; set; }
    }
}
