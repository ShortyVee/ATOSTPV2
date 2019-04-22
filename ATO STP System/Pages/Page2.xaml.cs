using ATO_STP_System.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATO_STP_System
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);
        }

 
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee()
            {
                employeeName = nameField.Text,
                employeeLastName = lNameField.Text,
                abnNumber = abnField.Text,
                description = businessField.Text,
                emailAddress = emailField.Text,
                startYear = startField.Text,
                endYear = endField.Text,// Dont forget to change this to a date
                address = addressField.Text //comment
            };


            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            {
                connection.CreateTable<Employee>();
                connection.Insert(employee);
            }

        }
       
    }
}
