using Ato.EN.IntegrationServices.CodeGenerationPAYEVNTEMP;
using ATO_STP_System.Helpers;
using SQLite;
using STPFileValidation;
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

        PAYEVNT testPAYEVNT;
        
        public Page1()
        {
            InitializeComponent();
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.75);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.60);

            errorBlock.Text = "";


            textName.Text = "";
            textLegalName.Text = "";
            textABN.Text = "";
            textBusinessDescription.Text = "";
            textEmail.Text = "";
            textAddress.Text = "";


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
            //Necessary PAYEVNT fields.
            testPAYEVNT = new PAYEVNT();
            testPAYEVNT.Rp.SoftwareInformationBusinessManagementSystemId = "08136164-0685-4c6c-8697-6b9003b5b57a";
            testPAYEVNT.Rp.AustralianBusinessNumberId = "67094544519";
            testPAYEVNT.Rp.OrganisationDetailsOrganisationBranchC = "100";
            testPAYEVNT.Rp.OrganisationName.DetailsOrganisationalNameT = "organisation namee";
            testPAYEVNT.Rp.OrganisationName.PersonUnstructuredNameFullNameT = "name";
            testPAYEVNT.Rp.ElectronicContact.ElectronicMailAddressT = "haha@gmail.com";
            testPAYEVNT.Rp.ElectronicContact.TelephoneMinimalN = "12 34567890";
            testPAYEVNT.Rp.AddressDetailsPostal.Line1T = "12 collins st";
            testPAYEVNT.Rp.AddressDetailsPostal.LocalityNameT = "Melbourne";
            testPAYEVNT.Rp.AddressDetailsPostal.StateOrTerritoryC = "VIC";
            testPAYEVNT.Rp.AddressDetailsPostal.PostcodeT = "3000";
            testPAYEVNT.Rp.AddressDetailsPostal.CountryC = "au";
            testPAYEVNT.Rp.Payroll.ProxyPaymentRecordTransactionD = new DateTime(2000, 5, 5);
            testPAYEVNT.Rp.Payroll.InteractionRecordCt = 10;
            testPAYEVNT.Rp.Payroll.MessageTimestampGenerationDt = new DateTime(2000, 5, 5);
            testPAYEVNT.Rp.Payroll.InteractionTransactionId = "BULK008";
            testPAYEVNT.Rp.Payroll.AmendmentI = false;
            //the M changes it to a decimal type
            testPAYEVNT.Rp.Payroll.IncomeTaxAndRemuneration.PayAsYouGoWithholdingTaxWithheldA = 324188.31M;
            testPAYEVNT.Rp.Payroll.IncomeTaxAndRemuneration.TotalGrossPaymentsWithholdingA = 17821.87M;
            testPAYEVNT.Rp.Declaration.SignatoryIdentifierT = "jassmith";
            testPAYEVNT.Rp.Declaration.ProxyDateSignatureD = new DateTime(2000, 5, 5);
            testPAYEVNT.Rp.Declaration.StatementAcceptedI = true;



           

            





            //Writes the xml to a file with filename. by default should appear in bin / Debug or bin/ Release folder.
            //USE THE EXTENSION.
            //XmlSerializationHelper.outputFileName = "TEST.xml";
            //var xml = XmlSerializationHelper.GetXml(testPAYEVNTEMP, NameSpaces.XmlSerializerNamespaces);
            //Console.WriteLine(xml);

           





            //XmlSerializer serializer = new XmlSerializer(typeof(TestXml));
            //serializer.Serialize(File.Create("file.xml"), community, NameSpaces.XmlSerializerNamespaces, );
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {



            //Employer employer = new Employer()
            //{
            //    name = textName.Text,
            //    legalName = textLegalName.Text,
            //    abnNumber = textABN.Text,
            //    businessDescription = textBusinessDescription.Text,
            //    contactEmail = textEmail.Text,
            //    startYear = dateStartYear.SelectedDate.Value.Date,
            //    endYear = dateEndYear.SelectedDate.Value.Date,
            //    address = textAddress.Text,
            //};


            //using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelpers.databasePath))
            //{
            //    connection.CreateTable<Employer>();
            //    connection.Insert(employer);
            //}
            testPAYEVNT.Rp.OrganisationName.DetailsOrganisationalNameT = textName.Text;
            testPAYEVNT.Rp.OrganisationName.PersonUnstructuredNameFullNameT = textLegalName.Text;
            testPAYEVNT.Rp.AustralianBusinessNumberId = textABN.Text;
            testPAYEVNT.Rp.ElectronicContact.ElectronicMailAddressT = textEmail.Text;
            testPAYEVNT.Rp.AddressDetailsPostal.Line1T = textAddress.Text;
            testPAYEVNT.Rp.AddressDetailsPostal.PostcodeT = textPostCode.Text;

            XmlSerializationHelper.outputFileName = "ATOPAYLOAD.xml";
            var xml = XmlSerializationHelper.GetXml(testPAYEVNT, NameSpaces.XmlSerializerNamespaces);
            Console.WriteLine(xml);

            Validate();





        }

        public void Validate()
        {
            STPFileValidator _STPFileValidator = new STPFileValidator();


            errorBlock.Text = "";

            _STPFileValidator.Validate("ATOPAYLOAD.xml");
            foreach (var error in _STPFileValidator.Errors)
            {
                errorBlock.Text = errorBlock.Text + (error.Description) + (error.LongDescription)+ "\r\n";
               
            }
               
            

            if (errorBlock.Text.Length < 5)
            {
                errorBlock.Text = "SUCCESS! VALID DETAILS";
            }
        }



    }


}
