using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Typ reditní karty
   /// </summary>
    [XmlType("creditCardType")]
    public class CreditCardType
    {
        /// <summary>
        ///Id typu kreditní karty
        /// [1]	
        /// </summary>
        [XmlElement("crtId")]
        public int CrtId { get; set; }
        

        /// <summary>
        ///Název typu kreditní karty
        /// [1]	
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

    }
}
