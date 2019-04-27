using ATO_STP_System.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using System.Xml.Serialization;

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

            textName.Text = "yea";
            textLegalName.Text = "yea";
            textABN.Text = "yea";
            textBusinessDescription.Text = "yea";
            textEmail.Text = "yea";
            textAddress.Text = "yea";


            // TestXml community = new TestXml
            // {
            //     Author = "xxx xxx",
            //     CommunityId = 0,
            //     Name = "name of community",
            //     Addresses = new List<Address> {
            //  new RegisteredAddress {
            // AddressLine1 = "xxx",
            // AddressLine2 = "xxx",
            // AddressLine3 = "xxx",
            // City = "xx",
            // Country = "xxxx",
            // PostCode = "0000-00"
            //},
            //new TradingAddress {
            //     AddressLine1 = "zz",
            //     AddressLine2 = "xxx"
            //        }
            //     }
            // };


            // var objeee = community;
            PAYEVNT testPAYEVNT = new PAYEVNT();

            PAYEVNTEMP testPAYEVNTEMP = new PAYEVNTEMP();

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
            testPAYEVNTEMP.Payee.Onboarding.Declaration.SignatureD = new DateTime(1999, 10, 10).Date;
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
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.DeductionCollection = new DeductionCollection();
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.SuperannuationContribution.EmployerContributionsSuperannuationGuaranteeA = 980;
            testPAYEVNTEMP.Payee.RemunerationIncomeTaxPayAsYouGoWithholding.UnusedAnnualOrLongServiceLeavePayment = null;




            Record_Delimiter ehh = new Record_Delimiter();
            ehh.DocumentID = "1.2";
            ehh.DocumentName = "PAYEVNTEMP";
                ehh.DocumentType = "CHILD";
            ehh.RelatedDocumentID = "1.1";

            ATOPushXml atotest = new ATOPushXml();

            //Writes the xml to a file with filename. by default should appear in bin / Debug or bin/ Release folder.
            //USE THE EXTENSION.
            XmlSerializationHelper.outputFileName = "TEST.xml";
            var xml = XmlSerializationHelper.GetXml(testPAYEVNTEMP, NameSpaces.XmlSerializerNamespaces);
            Console.WriteLine(xml);



            //XmlSerializer serializer = new XmlSerializer(typeof(TestXml));
            //serializer.Serialize(File.Create("file.xml"), community, NameSpaces.XmlSerializerNamespaces, );
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {



            Employer employer = new Employer()
            {
                name = textName.Text,
                legalName = textLegalName.Text,
                abnNumber = textABN.Text,
                businessDescription = textBusinessDescription.Text,
                contactEmail = textEmail.Text,
                startYear = dateStartYear.SelectedDate.Value.Date,
                endYear = dateEndYear.SelectedDate.Value.Date,
                address = textAddress.Text,
            };


            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            {
                connection.CreateTable<Employer>();
                connection.Insert(employer);
            }





        }



    }


}
