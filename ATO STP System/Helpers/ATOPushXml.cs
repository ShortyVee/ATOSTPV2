using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATO_STP_System.Helpers
{
    public class ATOPushXml
    {

        public RecordDelimiterXml recordDelimiter { get; set; }


        public ATOPushXml()
        {
            recordDelimiter = new RecordDelimiterXml();

           
        }

    }


    public class Record_Delimiter
    {
        [XmlAttribute]
        public string DocumentID { get; set; }

        [XmlAttribute]
        public string DocumentType { get; set; }

        [XmlAttribute]
        public string DocumentName { get; set; }

        [XmlAttribute]
        public string RelatedDocumentID { get; set; }


    }

    public class RecordDelimiterXml
    {
        [XmlElement("Record_Delimiter")]
        public Record_Delimiter Attributes { get; set; }

        public RecordDelimiterXml()
        {
            Attributes = new Record_Delimiter();
        }
    }
}
