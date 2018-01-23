using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// [0..1]	
    /// Ubytovací poplatek
    /// </summary>
    [XmlType("accommodationTax")]
    public class Tax
    {
        /// <summary>
        /// Výše poplatku (ve výchozí měně hotelu)
        /// [1]
        /// </summary>
        [XmlElement("price")]
        public float Price { get; set; }

        /// <summary>
        /// true poplatek je součástí ceny ubytování
        ///false poplatek se přičítá k ceně ubytování
        /// [1]
        /// </summary>
        [XmlElement("inAccommodationPrice")]
        public bool InAccommodationPrice { get; set; }

    }
}
