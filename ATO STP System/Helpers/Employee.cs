using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATO_STP_System.Helpers
{
    public class Employee
    {
        public string employeeName { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string paymentDate { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string earningAmount { get; set; }
        public string earningAccount { get; set; }
        public string earningQuantity { get; set; }
        public string earningRate { get; set; }
        public string taxCode { get; set; }
        public string taxQuantity { get; set; }
        public string taxFrequency { get; set; }
        public string taxHECS { get; set; }
        public string paygAmount { get; set; }
        public string paygTaxCode { get; set; }
    }
}
