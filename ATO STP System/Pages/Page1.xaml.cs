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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Employer employer = new Employer()
            {
                name = text1.Text,
                legalName = "Some Company",
                abnNumber = "1234554676",
                businessDescription = "Goods and Services",
                contactEmail = "company@example.com",
                startYear = new DateTime(2019, 07, 28),
                endYear = new DateTime(2020, 07, 28),
                address = "1234 example place"
            };


            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            {
                connection.CreateTable<Employer>();
                connection.Insert(employer);
            }

        }

    }
}
