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

        public Page2()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);

            testPAYEVNTEMP = new ATO_STP_System.Helpers.PAYEVNTEMP();

            //THE MINIMUM FIELDS TO PASS THE VALIDATOR FOR EMPLOYEES
            //testPAYEVNTEMP.Payee.AddressDetails.CountryC = "wow";
            testPAYEVNTEMP.Payee.AddressDetails.Line1T = "wowstreet";
            testPAYEVNTEMP.Payee.AddressDetails.Line2T = "wwo";
            testPAYEVNTEMP.Payee.AddressDetails.LocalityNameT = "fmak";
            testPAYEVNTEMP.Payee.AddressDetails.PostcodeT = "0200";
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
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthDm = 10;
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthM = 10;
            testPAYEVNTEMP.Payee.PersonDemographicDetails.BirthY = 1993;
            testPAYEVNTEMP.Payee.PersonNameDetails.FamilyNameT = "hea";
            testPAYEVNTEMP.Payee.PersonNameDetails.GivenNameT = "wow";
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.ProxyDateStartD = new DateTime(2013, 10, 10).Date;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.ProxyDateEndD = new DateTime(2013, 10, 11).Date; ;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.PayrollPeriod.PayrollEventFinalI = false;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.IndividualNonBusiness.GrossA = 12345;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.IndividualNonBusiness.TaxWithheldA = 1234;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.DeductionCollection = new ATO_STP_System.Helpers.DeductionCollection();
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.SuperannuationContribution.EmployerContributionsSuperannuationGuaranteeA = 980;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.UnusedAnnualOrLongServiceLeavePayment = null;
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

           


            XmlSerializationHelper.outputFileName = "ATOPAYLOAD.xml";
            var xml = XmlSerializationHelper.GetXml(testPAYEVNTEMP, NameSpaces.XmlSerializerNamespaces);
            Console.WriteLine(xml);

            Validate();

            /*
             *
             * Name="FromDateLbl", Name="ToDateLbl", Name="PaymentDateLbl", Name="StatusLbl", Name="DescriptionLbl", Name="PaymentHeaderLbl, Name="PaymentForLbl", Name="PaymentDateField"
             * Name="FromDateField", Name="TaxCodeField", Name="RateField", Name="AccountField", Name="DescriptionField", Name="StatusField", Name="ToDateField", Name="AmountField"
             * Name="EarningsLbl", Name="AccountLbl", Name="AmountLbl", Name="AmountLbl_Copy", Name="AmountLbl_Copy1", Name="AmountLbl_Copy2", Name="quantityField", Name="EarningsLbl_CopyH"
             * Name="AmountLbl_Copy3", Name="AmountLbl_Copy4", Name="AmountLbl_Copy5", Name="taxQuantityField", Name="FrequencyField", Name="HecsField", Name="EarningsLbl_Copyo1"
             * Name="AmountLbl_Copy6", Name="PaygAmountField", Name="AmountLbl_Copy7", Name="TaxcodeField"
             * */




        }

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

    }
}
