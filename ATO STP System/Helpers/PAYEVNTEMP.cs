using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATO_STP_System.Helpers
{

    [XmlRoot("PAYEVNTEMP", Namespace = NameSpaces.TnsEmp)]
    public class PAYEVNTEMP
    {
        public Payee Payee { get; set; }

        public PAYEVNTEMP()
        {
            Payee = new Payee();
        }

        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string XSDSchemaLocation
        {
            get
            {
                return NameSpaces.SchemaLocationEmp;
            }
            set
            {
                // Do nothing - fake property.
            }
        }
    }


    public class Payee
    {
        public Identifiers Identifiers { get; set; }
        public PersonNameDetails PersonNameDetails { get; set; }
        public PersonDemographicDetails PersonDemographicDetails { get; set; }
        public AddressDetails AddressDetails { get; set; }
        public ElectronicContact ElectronicContact { get; set; }
        public EmployerConditions EmployerConditions { get; set; }
        public RemunerationIncomeTaxPayAsYouGoWithholding RemunerationIncomeTaxPayAsYouGoWithholding { get; set; }
        public Onboarding Onboarding { get; set; }

        public Payee()
        {
            Identifiers = new Identifiers();
            PersonNameDetails = new PersonNameDetails();
            PersonDemographicDetails = new PersonDemographicDetails();
            AddressDetails = new AddressDetails();
            ElectronicContact = new ElectronicContact();
            EmployerConditions = new EmployerConditions();
            RemunerationIncomeTaxPayAsYouGoWithholding = new RemunerationIncomeTaxPayAsYouGoWithholding();
            Onboarding = new Onboarding();

        }
    }

    public class Identifiers
    {
        public string TaxFileNumberId { get; set; }
        public string AustralianBusinessNumberId { get; set; }
        public string EmploymentPayrollNumberId { get; set; }
    }


    public class PersonNameDetails
    {
        public string FamilyNameT { get; set; }
        public string GivenNameT { get; set; }
        public string OtherGivenNameT { get; set; }
    }

    public class PersonDemographicDetails
    {
        public int? BirthDm { get; set; }
        public int? BirthM { get; set; }
        public int? BirthY { get; set; }
    }

    public class AddressDetails
    {
        public string Line1T { get; set; }
        public string Line2T { get; set; }
        public string LocalityNameT { get; set; }
        public string StateOrTerritoryC { get; set; }
        public string PostcodeT { get; set; }
        public string CountryC { get; set; }
    }

    public class EmployerConditions
    {
        [XmlIgnore]
        public DateTime ProxyDateEmploymentStartD { get; set; }

        [XmlElement]
        public String EmploymentStartD
        {
            get { return ProxyDateEmploymentStartD.ToString("yyyy-MM-dd"); }
            set { ProxyDateEmploymentStartD = DateTime.Parse(value); }
        }
        [XmlIgnore]
        public DateTime ProxyDateEmploymentEndD { get; set; }

        [XmlElement]
        public String EmploymentEndD
        {
            get { return ProxyDateEmploymentEndD.ToString("yyyy-MM-dd"); }
            set { ProxyDateEmploymentEndD = DateTime.Parse(value); }
        }
    }


    public class RemunerationIncomeTaxPayAsYouGoWithholding
    {
        public PayrollPeriod PayrollPeriod { get; set; }
        public IndividualNonBusiness IndividualNonBusiness { get; set; }
        public VoluntaryAgreement VoluntaryAgreement { get; set; }
        public LabourHireArrangementPayment LabourHireArrangementPayment { get; set; }
        public SpecifiedByRegulationPayment SpecifiedByRegulationPayment { get; set; }
        public JointPetroleumDevelopmentAreaPayment JointPetroleumDevelopmentAreaPayment { get; set; }
        public WorkingHolidayMaker WorkingHolidayMaker { get; set; }
        public PaymentToForeignResident PaymentToForeignResident { get; set; }
        public EmploymentTerminationPaymentCollection EmploymentTerminationPaymentCollection { get; set; }
        public UnusedAnnualOrLongServiceLeavePayment UnusedAnnualOrLongServiceLeavePayment { get; set; }
        public AllowanceCollection AllowanceCollection { get; set; }
        public DeductionCollection DeductionCollection { get; set; }
        public SuperannuationContribution SuperannuationContribution { get; set; }
        public IncomeFringeBenefitsReportable IncomeFringeBenefitsReportable { get; set; }

        public RemunerationIncomeTaxPayAsYouGoWithholding()
        {
            PayrollPeriod = new PayrollPeriod();
            IndividualNonBusiness = new IndividualNonBusiness();
            VoluntaryAgreement = new VoluntaryAgreement();
            LabourHireArrangementPayment = new LabourHireArrangementPayment();
            SpecifiedByRegulationPayment = new SpecifiedByRegulationPayment();
            JointPetroleumDevelopmentAreaPayment = new JointPetroleumDevelopmentAreaPayment();
            WorkingHolidayMaker = new WorkingHolidayMaker();
            PaymentToForeignResident = new PaymentToForeignResident();
            EmploymentTerminationPaymentCollection = new EmploymentTerminationPaymentCollection();
            UnusedAnnualOrLongServiceLeavePayment = new UnusedAnnualOrLongServiceLeavePayment();
            AllowanceCollection = new AllowanceCollection();
            DeductionCollection = new DeductionCollection();
            SuperannuationContribution = new SuperannuationContribution();
            IncomeFringeBenefitsReportable = new IncomeFringeBenefitsReportable();
        }

    }

    public class PayrollPeriod
    {

        [XmlIgnore]
        public DateTime ProxyDateStartD { get; set; }

        [XmlElement]
        public String StartD
        {
            get { return ProxyDateStartD.ToString("yyyy-MM-dd"); }
            set { ProxyDateStartD = DateTime.Parse(value); }
        }
        [XmlIgnore]
        public DateTime ProxyDateEndD { get; set; }

        [XmlElement]
        public String EndD
        {
            get { return ProxyDateEndD.ToString("yyyy-MM-dd"); }
            set { ProxyDateEndD = DateTime.Parse(value); }
        }
        public bool PayrollEventFinalI { get; set; }
    }

    /// <summary>
    /// Individual Non Business Payment Summary
    /// </summary>
    public class IndividualNonBusiness
    {

        /// <summary>
        /// Payee Gross Payments
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee CDEP Payment Amount
        /// </summary>

        public decimal? CommunityDevelopmentEmploymentProjectA { get; set; }

        /// <summary>
        /// Payee Total INB PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }

        /// <summary>
        /// Payee Exempt Foreign Income Amount
        /// </summary>

        public decimal? ExemptForeignEmploymentIncomeA { get; set; }
    }

    /// <summary>
    /// Voluntary Agreement Payment Summary
    /// </summary>
    public class VoluntaryAgreement
    {

        /// <summary>
        /// Payee Voluntary Agreement Gross Payment
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Voluntary Agreement PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Business and Personal Services Income Payment Summary
    /// </summary>
    public class LabourHireArrangementPayment
    {

        /// <summary>
        /// Payee Labour Hire Gross Payment
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Labour Hire PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Other Specified Payment Summary
    /// </summary>
    public class SpecifiedByRegulationPayment
    {

        /// Payee Other Specified Gross Payments
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Other Specified Payments PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Joint Petroleum Development Area Payment Summary
    /// </summary>
    public class JointPetroleumDevelopmentAreaPayment
    {

        /// <summary>
        /// Payee JPDA Foreign Employment Income Gross Amount
        /// </summary>

        public decimal A { get; set; }

        /// <summary>
        /// Payee JPDA Foreign Employment Income Foreign Tax Paid
        /// </summary>

        public decimal ForeignWithholdingA { get; set; }

        /// <summary>
        /// Payee Total FEI JPDA PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Working Holiday Maker Payment Summary
    /// </summary>
    public class WorkingHolidayMaker
    {

        /// <summary>
        /// Payee Working Holiday Maker Gross Payment
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Working Holiday Maker PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Foreign Employment Income Summary
    /// </summary>
    public class PaymentToForeignResident
    {

        /// <summary>
        /// Payee Gross Payments Foreign Employment
        /// </summary>

        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Foreign Employment Income Foreign Tax Paid
        /// </summary>

        public decimal ForeignWithholdingA { get; set; }

        /// <summary>
        /// Payee Total FEI PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Termination Payment Summary
    /// </summary>
    public class EmploymentTerminationPaymentCollection : List<EmploymentTerminationPayment> { }

    /// <summary>
    /// Termination Payment Summary
    /// </summary>
    public class EmploymentTerminationPayment
    {

        /// <summary>
        /// ETP Code
        /// </summary>

        public string TypeC { get; set; }

        /// <summary>
        /// Payee ETP Payment Date
        /// </summary>

        public DateTime PaymentRecordPaymentEffectiveD { get; set; }

        /// <summary>
        /// Payee Termination Payment Tax Free Component
        /// </summary>

        public decimal SuperannuationTaxFreeComponentA { get; set; }

        /// <summary>
        /// Payee Termination Payment Taxable Component
        /// </summary>

        public decimal SuperannuationEmploymentTerminationTaxableComponentTotalA { get; set; }

        /// <summary>
        /// Payee Total ETP PAYGW Amount
        /// </summary>

        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Lump Sum Payment A
    /// </summary>
    public class LumpSumPaymentA
    {

        /// <summary>
        /// Payee Lump Sum Payment A Type
        /// </summary>

        public string LumpSumAC { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment A
        /// </summary>

        public decimal LumpSumAA { get; set; }
    }

    /// <summary>
    /// Lump Sum Payments
    /// </summary>
    public class UnusedAnnualOrLongServiceLeavePayment
    {


        public LumpSumPaymentA LumpSumPaymentA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment B
        /// </summary>

        public decimal? LumpSumBA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment D
        /// </summary>

        public decimal? LumpSumDA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment E
        /// </summary>

        public decimal? LumpSumEA { get; set; }

        public UnusedAnnualOrLongServiceLeavePayment()
        {
            LumpSumPaymentA = new LumpSumPaymentA();
        }
    }

    /// <summary>
    /// Allowance Item
    /// </summary>
    public class AllowanceCollection : List<Allowance> {
    }

    /// <summary>
    /// Allowance Item
    /// </summary>
    public class Allowance
    {

        /// <summary>
        /// Allowance Type
        /// </summary>

        public string TypeC { get; set; }

        /// <summary>
        /// Other Allowance Type
        /// </summary>

        public string OtherAllowanceTypeDe { get; set; }

        /// <summary>
        /// Payee Allowance Amount
        /// </summary>

        public decimal IndividualNonBusinessEmploymentAllowancesA { get; set; }
    }

    /// <summary>
    /// Deduction Item
    /// </summary>
    public class DeductionCollection : List<Deduction> { }

    /// <summary>
    /// Deduction Item
    /// </summary>
    public class Deduction
    {

        /// <summary>
        /// Deduction Type
        /// </summary>

        public string TypeC { get; set; }

        /// <summary>
        /// Payee Deduction Amount
        /// </summary>

        public decimal A { get; set; }
    }

    /// <summary>
    /// Super Entitlement Year To Date
    /// </summary>
    public class SuperannuationContribution
    {

        /// <summary>
        /// Super Liability Amount
        /// </summary>

        public decimal? EmployerContributionsSuperannuationGuaranteeA { get; set; }

        /// <summary>
        /// OTE Amount
        /// </summary>

        public decimal? OrdinaryTimeEarningsA { get; set; }

        /// <summary>
        /// Reportable Employer Super Contribution
        /// </summary>

        public decimal? EmployerReportableA { get; set; }
    }

    /// <summary>
    /// Reportable Fringe Benefits Amount
    /// </summary>
    public class IncomeFringeBenefitsReportable
    {

        /// <summary>
        /// Payee RFB Taxable Amount
        /// </summary>

        public decimal? TaxableIncomeFringeBenefitsReportableA { get; set; }

        /// <summary>
        /// Payee RFB Exempt Amount
        /// </summary>

        public decimal? ExemptIncomeFringeBenefitsReportableA { get; set; }
    }

    /// <summary>
    /// Employment Details
    /// </summary>
    public class TFND
    {

        /// <summary>
        /// Payee Terminated Indicator
        /// </summary>

        public string PaymentArrangementTerminationC { get; set; }

        /// <summary>
        /// Payee Residency Status
        /// </summary>

        public string ResidencyTaxPurposesPersonStatusC { get; set; }

        /// <summary>
        /// Basis of Payment Code
        /// </summary>

        public string PaymentArrangementPaymentBasisC { get; set; }

        /// <summary>
        /// Tax Free Threshold Claimed
        /// </summary>

        public bool? TaxOffsetClaimTaxFreeThresholdI { get; set; }

        /// <summary>
        /// Study and Training Loan Repayment Indicator
        /// </summary>

        public bool? IncomeTaxPayAsYouGoWithholdingStudyAndTrainingLoanRepaymentI { get; set; }

        /// <summary>
        /// Student Financial Supplement Scheme Loan indicator
        /// </summary>
        public bool? StudentLoanStudentFinancialSupplementSchemeI { get; set; }
    }



    /// <summary>
    /// Onboarding
    /// </summary>
    public class Onboarding
    {


        public TFND TFND { get; set; }


        public Declaration Declaration { get; set; }

        public Onboarding()
        {
            TFND = new TFND();
            Declaration = new Declaration();
        }
    }




}
