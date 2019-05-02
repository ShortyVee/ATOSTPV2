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

        public string PrintDetails()
        {
            string returnString = "";

            returnString += "First Name: " + firstName + "\r\n";
            returnString += "Last Name: " + lastName + "\r\n";
            returnString += "DOB Day : " + dobDay + "\r\n";
            returnString += "DOB Month: " + dobMonth + "\r\n";
            returnString += "DOB Year: " + dobYear + "\r\n";
            returnString += "Address: " + address + "\r\n";
            returnString += "PostCode: " + postcode + "\r\n";
            returnString += "payFrom: " + payFrom + "\r\n";
            returnString += "payTo: " + payTo + "\r\n";
            returnString += "Gross: " + grossAmount + "\r\n";
            returnString += "Tax Withheld: " + taxWithheld + "\r\n";
            returnString += "Super Contribution: " + superContribution + "\r\n";

            return returnString;
        }
    }
}
