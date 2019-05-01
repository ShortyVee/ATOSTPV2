using ATO_STP_System.Helpers;
using SQLite;
using STPFileValidation;
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
        ATO_STP_System.Helpers.PAYEVNTEMP testPAYEVNTEMP;

        Uri _page1 = new Uri("Pages/Page1.xaml", UriKind.Relative);
        Uri _page2 = new Uri("Pages/Page2.xaml", UriKind.Relative);
        Uri _page3 = new Uri("Pages/Page3.xaml", UriKind.Relative);
        Uri _page4 = new Uri("Pages/Page4.xaml", UriKind.Relative);


        public Page2()
        {
            InitializeComponent();
            /*this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);*/

           // testPAYEVNTEMP = new ATO_STP_System.Helpers.PAYEVNTEMP();


            firstName.Text = "";
            lastName.Text = "";
            DOBday.Text = "";
            DOBmonth.Text = "";
            DOByear.Text = "";
            address.Text = "";
            postcode.Text = "";
            grossAmount.Text = "";
            taxWithheld.Text = "";
            superContributions.Text = "";

        }


        private void Next_Button(object sender, RoutedEventArgs e)
        {

            bool payFromOkay = false;
            bool payToOkay = false;

            decimal grossNum;
            decimal taxNum;
            decimal superNum;

            bool grossCheck = false;
            bool taxCheck = false;
            bool superCheck = false;

            if (payStart.SelectedDate != null)
            {
                payFromOkay = true;
            }
            if (payEnd.SelectedDate != null)
            {
                payToOkay = true;
            }

            if(decimal.TryParse(grossAmount.Text, out grossNum))
            {
                grossCheck = true;
            }
            if (decimal.TryParse(taxWithheld.Text, out taxNum))
            {
                taxCheck = true;
            }
            if (decimal.TryParse(superContributions.Text, out superNum))
            {
                superCheck = true;
            }


            if (
                firstName.Text != "" &&
                lastName.Text != "" &&
                DOBday.Text != "" &&
                DOBmonth.Text != "" &&
                DOByear.Text != "" &&
                payToOkay &&
                payFromOkay &&
                address.Text != "" &&
                postcode.Text != "" &&
                grossCheck &&
                taxCheck &&
                superCheck
                )
            {
                Employee employee = new Employee()
                {
                    firstName =  firstName.Text,
                    lastName = lastName.Text,
                    dobDay = int.Parse(DOBday.Text),
                    dobMonth = int.Parse(DOBmonth.Text),
                    dobYear = int.Parse(DOByear.Text),
                    address = address.Text,
                    postcode = postcode.Text,
                    payFrom = payStart.SelectedDate.Value.Date,
                    payTo = payEnd.SelectedDate.Value.Date,
                    grossAmount = decimal.Parse(grossAmount.Text),
                    taxWithheld = decimal.Parse(taxWithheld.Text),
                    superContribution = decimal.Parse(superContributions.Text),
                };

                using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.employeeDB))
                {
                    connection.CreateTable<Employee>();
                    connection.Insert(employee);
                }

                navigatePages();

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please fill all fields in before continuing", "error");
            }

            /* Employee employee = new Employee()
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
             */

            /*
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            {
                connection.CreateTable<Employee>();
                connection.Insert(employee);
            }

           
            */
            /*
            testPAYEVNTEMP.Payee.AddressDetails.Line1T = address.Text;
            testPAYEVNTEMP.Payee.AddressDetails.Line2T = "wwo";
            testPAYEVNTEMP.Payee.AddressDetails.LocalityNameT = "fmak";
            testPAYEVNTEMP.Payee.AddressDetails.PostcodeT = postcode.Text;
            testPAYEVNTEMP.Payee.AddressDetails.StateOrTerritoryC = "VIC";
            testPAYEVNTEMP.Payee.ElectronicContact.ElectronicMailAddressT = "yea@gmail.com";
            testPAYEVNTEMP.Payee.ElectronicContact.TelephoneMinimalN = "10101";
            testPAYEVNTEMP.Payee.EmployerConditions.ProxyDateEmploymentEndD = new DateTime(1999, 10, 10);
            testPAYEVNTEMP.Payee.EmployerConditions.ProxyDateEmploymentStartD = new DateTime(1999, 10, 11);
            testPAYEVNTEMP.Payee.Identifiers.AustralianBusinessNumberId = "67094544519";
            testPAYEVNTEMP.Payee.Identifiers.EmploymentPayrollNumberId = "yea";
            testPAYEVNTEMP.Payee.Identifiers.TaxFileNumberId = "151994243";
            testPAYEVNTEMP.Payee.Onboarding.Declaration.SignatoryIdentifierT = "fawoiafwoiafw";
            testPAYEVNTEMP.Payee.Onboarding.Declaration.ProxyDateSignatureD = new DateTime(1999, 10, 10);
            testPAYEVNTEMP.Payee.Onboarding.Declaration.StatementAcceptedI = true;
            testPAYEVNTEMP.Payee.Onboarding = null;
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthDm = int.Parse(DOBday.Text);
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthM = int.Parse(DOBmonth.Text);
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthY = int.Parse(DOByear.Text);
            testPAYEVNTEMP.Payee.PersonNameDetails.FamilyNameT = lastName.Text;
            testPAYEVNTEMP.Payee.PersonNameDetails.GivenNameT = firstName.Text;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.ProxyDateStartD = payStart.SelectedDate.Value.Date;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.ProxyDateEndD = payEnd.SelectedDate.Value.Date;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.PayrollEventFinalI = false;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.IndividualNonBusiness.GrossA = decimal.Parse(grossAmount.Text);
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.IndividualNonBusiness.TaxWithheldA = decimal.Parse(taxWithheld.Text);
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.DeductionCollection = new ATO_STP_System.Helpers.DeductionCollection();
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.SuperannuationContribution.EmployerContributionsSuperannuationGuaranteeA = decimal.Parse(superContributions.Text);
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.UnusedAnnualOrLongServiceLeavePayment = null;

            XmlSerializationHelper.outputFileName = "ATOPAYLOAD.xml";
            var xml = XmlSerializationHelper.GetXml(testPAYEVNTEMP, NameSpaces.XmlSerializerNamespaces);
            Console.WriteLine(xml);
            */
            //Validate();

        }

        public void navigatePages()
        {
            Uri currentUri = ((MainWindow)Application.Current.MainWindow)._NavigationFrame.NavigationService.Source;

            Uri newUri = _page1;

            if (currentUri != null)
            {
                string uriString = currentUri.ToString();

                switch (uriString)
                {
                    case "Pages/Page1.xaml":
                        newUri = _page2;
                        break;
                    case "Pages/Page2.xaml":
                        newUri = _page3;
                        break;
                    case "Pages/Page3.xaml":
                        newUri = _page4;
                        break;
                    default:
                        newUri = _page1;
                        break;
                }
            }
            else
            {
                newUri = _page2;
            }
           ((MainWindow)Application.Current.MainWindow)._NavigationFrame.NavigationService.Navigate(newUri);
        }
    }
    /*
    public void Validate()
    {
        STPFileValidator _STPFileValidator = new STPFileValidator();


        errorBlock.Text = "";

        _STPFileValidator.Validate("ATOPAYLOAD.xml");
        foreach (var error in _STPFileValidator.Errors)
        {
            errorBlock.Text = errorBlock.Text + (error.Description) + (error.LongDescription) + "\r\n";

        }



        if (errorBlock.Text.Length < 5)
        {
            errorBlock.Text = "SUCCESS! VALID DETAILS";
        }
    }
    */

}
