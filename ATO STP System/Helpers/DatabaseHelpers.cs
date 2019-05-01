using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQLite;

namespace ATO_STP_System.Helpers
{
    public partial class DatabaseHelpers : Application
    {
        static string employeeDBName = "Employee.db";
        static string employerDBName = "Employer.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string employeeDB = System.IO.Path.Combine(folderPath, employeeDBName);
        public static string employerDB = System.IO.Path.Combine(folderPath, employerDBName);

    }
}
