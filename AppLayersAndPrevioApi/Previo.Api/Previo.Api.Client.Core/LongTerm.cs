using System.Xml.Serialization;
using Previo.Api.Client;

namespace Previo.Api.Client
{
    public class LongTerm:BaseDiscountRate
    {
        /// <summary>
        ///Identifikátor slevy
        /// [1]
        /// </summary>
        [XmlElement("palId")]
        public int PalId { get; set; }

        /// <summary>
        ///Minimální počet rezervovaných nocí pro uplatnění slevy
        /// [1]	
        /// </summary>
        [XmlElement("minNumOfNights")]
        public int MinNumOfNights { get; set; }
    }
}
