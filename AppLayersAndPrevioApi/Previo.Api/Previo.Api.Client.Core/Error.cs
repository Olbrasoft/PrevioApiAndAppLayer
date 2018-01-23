using System.Xml.Serialization;

namespace Previo.Api.Client
{
   [XmlType("error")]
   public class Error
    {
        [XmlAttribute("code")]
        public int Code;
    }
}
