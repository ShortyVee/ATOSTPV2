using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ATO_STP_System.Helpers
{
    public static class NameSpaces
{
    static readonly XmlSerializerNamespaces namespaces;

    static NameSpaces()
    {
        namespaces = new XmlSerializerNamespaces();
        namespaces.Add("xsi", NameSpaces.Xsi);
        namespaces.Add("tns", NameSpaces.Tns);
        namespaces.Add("tns", NameSpaces.TnsEmp);
        }

    public static XmlSerializerNamespaces XmlSerializerNamespaces
    {
        get
        {
            return namespaces;
        }
    }

 
    public const string Xsi = "http://www.w3.org/2001/XMLSchema-instance";
    public const string SchemaLocation = "http://www.sbr.gov.au/ato/payevnt ato.payevnt.0003.2018.01.00.xsd";
        public const string Tns = "http://www.sbr.gov.au/ato/payevnt";
        public const string TnsEmp = "http://www.sbr.gov.au/ato/payevntemp";
        public const string SchemaLocationEmp = "http://www.sbr.gov.au/ato/payevntemp ato.payevntemp.0003.2018.01.00.xsd";
    }

    //public class TestXml
    //{
    //    [XmlElement("Author", Namespace = NameSpaces.Tns)]
    //    public string Author { get; set; }
    //    public int CommunityId { get; set; }
    //    [XmlElement("Name", Namespace = NameSpaces.Tns)]
    //    public string Name { get; set; }
    //    [XmlArray]
    //    [XmlArrayItem(typeof(RegisteredAddress))]
    //    [XmlArrayItem(typeof(TradingAddress))]
    //    public List<Address> Addresses { get; set; }
    //}

    //public class Address
    //{
    //    private string _postCode;

    //    public string AddressLine1 { get; set; }
    //    public string AddressLine2 { get; set; }
    //    public string AddressLine3 { get; set; }
    //    public string City { get; set; }
    //    public string Country { get; set; }

    //    public string PostCode
    //    {
    //        get { return _postCode; }
    //        set
    //        {
    //            // validate post code e.g. with RegEx
    //            _postCode = value;
    //        }
    //    }
    //}

    //public class RegisteredAddress : Address { }
    //public class TradingAddress : Address { }

    


        public static class XmlSerializationHelper
    {
        public static string outputFileName = "defaultxml";

        public static string GetXml<T>(this T obj)
        {
            return GetXml(obj, false);
        }

        public static string GetXml<T>(this T obj, bool omitNamespace)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), omitNamespace);
        }

        public static string GetXml<T>(this T obj, XmlSerializer serializer)
        {
            return GetXml(obj, serializer, false);
        }

        public static string GetXml<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            XmlSerializerNamespaces ns = null;
            if (omitStandardNamespaces)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            }
            return GetXml(obj, serializer, ns);
        }

        public static string GetXml<T>(T obj, XmlSerializerNamespaces ns)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), ns);
        }

        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {


            var fname = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputFileName);
            var appendMode = false;
            var encoding = Encoding.UTF8;

            using (var streamWriter = new StreamWriter(fname, appendMode , encoding))
            {

                //streamWriter.Write("<Record_Delimiter DocumentID=\"1.2\" DocumentType=\"CHILD\" DocumentName=\"PAYEVNTEMP\" RelatedDocumentID=\"1.1\"/>");

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.OmitXmlDeclaration = true;


                



                using (var xmlWriter = XmlWriter.Create(streamWriter, settings))
                {

                    if(appendMode == false)
                    {
                        streamWriter.Write("<?xml version=\"1.0\" encoding=\"utf - 8\"?>");
                    }
                   
                    if(obj.GetType() == typeof(PAYEVNTEMP))
                    {
                        streamWriter.Write("<Record_Delimiter DocumentID=\"1.2\" DocumentType=\"CHILD\" DocumentName=\"PAYEVNTEMP\" RelatedDocumentID=\"1.1\"/>\r");
                    }
                    else if(obj.GetType() == typeof(PAYEVNT))
                    {
                        streamWriter.Write("<Record_Delimiter DocumentID=\"1.1\" DocumentType=\"PARENT\" DocumentName=\"PAYEVNT\" RelatedDocumentID=\"\"/>\r");
                    }
                    if (ns != null)
                    {
                        serializer.Serialize(xmlWriter, obj, ns);

                    }

                    else
                    {
                        serializer.Serialize(xmlWriter, obj);

                    }
                        
                }
                

            }
            

            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.

                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (ns != null)
                        serializer.Serialize(xmlWriter, obj, ns);
                    else
                        serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();

            }
        }
    }

}
