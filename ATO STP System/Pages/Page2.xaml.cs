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
                FromDate = FromDateField.Text,
                ToDate = ToDateLbl.Text,
                PaymentDate = PaymentDateLbl.Text,
                Status = StatusLbl.Text,
                Description = DescriptionLbl.Text,
                EarningAmount = EarningAmountField.Text,
                EarningAccount = EarningAccountField.Text,// Dont forget to change this to a date
                EarningQuantity = EarningsQuantityField.Text, //comment
                EarningsRate = RateField.Text,
                TaxCode = TaxCodeField.Text,
                TaxQuantity = TaxQuantityField.Text,
                TaxFrequency = TaxFrequencyField.Text,
                TaxHECS = HecsField.Text,

            };


            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            {
                connection.CreateTable<Employee>();
                connection.Insert(employee);
            }

            /*
             * 
             * Name="FromDateLbl", Name="ToDateLbl", Name="PaymentDateLbl", Name="StatusLbl", Name="DescriptionLbl", Name="PaymentHeaderLbl, Name="PaymentForLbl", Name="PaymentDateField"
             * Name="FromDateField", Name="TaxCodeField", Name="RateField", Name="AccountField", Name="DescriptionField", Name="StatusField", Name="ToDateField", Name="AmountField"
             * Name="EarningsLbl", Name="AccountLbl", Name="AmountLbl", Name="AmountLbl_Copy", Name="AmountLbl_Copy1", Name="AmountLbl_Copy2", Name="quantityField", Name="EarningsLbl_CopyH"
             * Name="AmountLbl_Copy3", Name="AmountLbl_Copy4", Name="AmountLbl_Copy5", Name="taxQuantityField", Name="FrequencyField", Name="HecsField", Name="EarningsLbl_Copyo1"
             * Name="AmountLbl_Copy6", Name="PaygAmountField", Name="AmountLbl_Copy7", Name="TaxcodeField" 
             * */                         


        }

    }
}
