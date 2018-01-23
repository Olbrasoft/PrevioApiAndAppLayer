using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kategorie hostů
    /// [1..*]
    /// </summary>
    [XmlType("category")]
   public class GuestCategory
   {
        /// <summary>
        /// Id kategorie hostů
        /// [1]
        /// </summary>
        [XmlElement("guaId")]
        public int GuaId { get; set; }


        /// <summary>
        /// Název kategorie hostů
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }


        /// <summary>
        /// Sleva na ubytovací služby v procentech
        /// [1]
        /// </summary>
        [XmlElement("discountRate")]
        public double DiscountRate { get; set; }


         /// <summary>
        /// Zda daná kategorie platí rekreační poplatky
        /// [1]
        /// </summary>
        [XmlElement("localVisitorTax")]
        public bool LocalVisitorTax { get; set; }
        
   }
}
