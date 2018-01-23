using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Typ ubytovacího zařízení hotel, penzion ...
    /// </summary>
    [XmlType("type")]
    public class HotelType
    {    	
        /// <summary>
        ///Id typu zařízení
        /// [1]
        /// </summary>
        [XmlElement("hoyId")]
        public int HoyId { get; set; }

         /// <summary>
        ///Název typu zařízení
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name{ get; set; }

    }
}
