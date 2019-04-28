using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATO_STP_System.Helpers
{

    [XmlRoot("PAYEVNT", Namespace = NameSpaces.Tns)]
    public class PAYEVNT
    {
        public Rp Rp { get; set; }
        public Int Int { get; set; }

        public PAYEVNT()
        {
            Rp = new Rp();
            //Int = new Int();
        }

        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string XSDSchemaLocation
        {
            get
            {
                return NameSpaces.SchemaLocation;
            }
            set
            {
                // Do nothing - fake property.
            }
        }
    }

    public class OrganisationName
    {

        public string DetailsOrganisationalNameT { get; set; }
        public string PersonUnstructuredNameFullNameT { get; set; }

        public OrganisationName()
        {
            DetailsOrganisationalNameT = "WOW";
            PersonUnstructuredNameFullNameT = string.Empty;
        }
    }

    public class ElectronicContact
    {

        public string ElectronicMailAddressT { get; set; }
        public string TelephoneMinimalN { get; set; }
    }

    public class AddressDetailsPostal
    {
        public string Line1T { get; set; }
        public string Line2T { get; set; }
        public string LocalityNameT { get; set; }
        public string StateOrTerritoryC { get; set; }
        public string PostcodeT { get; set; }
        public string CountryC { get; set; }
    }

    public class IncomeTaxAndRemuneration
    {

        public decimal PayAsYouGoWithholdingTaxWithheldA { get; set; }
        public decimal TotalGrossPaymentsWithholdingA { get; set; }
    }

    public class Payroll
    {
        [XmlIgnore]
        public DateTime ProxyPaymentRecordTransactionD { get; set; }

        [XmlElement]
        public String PaymentRecordTransactionD
        {
            get { return ProxyPaymentRecordTransactionD.ToString("yyyy-MM-dd"); }
            set { ProxyPaymentRecordTransactionD = DateTime.Parse(value); }
        }

        public decimal InteractionRecordCt { get; set; }
        public DateTime MessageTimestampGenerationDt { get; set; }
        public string InteractionTransactionId { get; set; }
        public bool AmendmentI { get; set; }
        public IncomeTaxAndRemuneration IncomeTaxAndRemuneration { get; set; }

        public Payroll()
        {
            IncomeTaxAndRemuneration = new IncomeTaxAndRemuneration();
            
        }
    }

    public class Declaration
    {

        public string SignatoryIdentifierT { get; set; }
        [XmlIgnore]
        public DateTime ProxyDateSignatureD { get; set; }

        [XmlElement]
        public String SignatureD
        {
            get { return ProxyDateSignatureD.ToString("yyyy-MM-dd"); }
            set { ProxyDateSignatureD = DateTime.Parse(value); }
        }
        public bool StatementAcceptedI { get; set; }
    }

    /// <summary>
    /// Reporting party
    /// </summary>
    public class Rp
    {
        public string SoftwareInformationBusinessManagementSystemId { get; set; }
        public string AustralianBusinessNumberId { get; set; }
        public string WithholdingPayerNumberId { get; set; }
        public string OrganisationDetailsOrganisationBranchC { get; set; }
        public OrganisationName OrganisationName { get; set; }
        public ElectronicContact ElectronicContact { get; set; }
        public AddressDetailsPostal AddressDetailsPostal { get; set; }
        public Payroll Payroll { get; set; }
        public Declaration Declaration { get; set; }

        public Rp()
        {
            OrganisationName = new OrganisationName();
            ElectronicContact = new ElectronicContact();
            AddressDetailsPostal = new AddressDetailsPostal();
            Payroll = new Payroll();
            Declaration = new Declaration();
        }
    }

    /// <summary>
    /// Intermediary
    /// </summary>
    public class Int
    {
        public string AustralianBusinessNumberId { get; set; }
        public string TaxAgentNumberId { get; set; }
        public string PersonUnstructuredNameFullNameT { get; set; }
        public ElectronicContact ElectronicContact { get; set; }
        public Declaration Declaration { get; set; }

        public Int()
        {
            ElectronicContact = new ElectronicContact();
            Declaration = new Declaration();
        }
    }
}
