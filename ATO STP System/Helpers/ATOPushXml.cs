using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATO_STP_System.Helpers
{
    [Serializable]

    public class ATOPushXml
    {


        [XmlElement("Record_Delimiter", Namespace = null)]
        public Record_Delimiter Attributes = new Record_Delimiter();



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

        public Record_Delimiter()
        {
            DocumentID = "1.2";
            DocumentType = "CHILD";
            DocumentName = "PAYEVNTEMP";
            RelatedDocumentID = "1.1";
        }


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
