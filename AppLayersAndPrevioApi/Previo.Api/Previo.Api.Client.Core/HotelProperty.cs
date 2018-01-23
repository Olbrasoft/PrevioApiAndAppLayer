using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Vybavení. Každý hotel si vybírá podmnožinu z globálního číselníku vybavení. 
    /// Jestli jde u vybavení zadat vzdálenost (elementy onSite a distance), 
    /// zjistíte z globálního číselníku (element priceGet). Analogicky je to i u dalších možností (cena, kapacita).
    /// http://api.previo.cz/System.getHotelProperties
    /// [0..*]
    /// </summary>
    [XmlType("property")]
    public class HotelProperty
    {

        /// <summary>
        ///Id vybavení
        /// [1]
        /// </summary>
        [XmlElement("hopId")]
        public int HopId { get; set; }

        /// <summary>
        ///Vybavení se nachází přímo v hotelu (true|false)
        /// [0..1]
        /// </summary>
        [XmlElement("onSite")]
        public bool OnSite { get; set; }

        /// <summary>
        ///Vybavení se nachází X metrů od hotelu (onSite = false)
        /// [0..1]
        /// </summary>
        [XmlElement("distance")]
        public string Distance { get; set; }

        /// <summary>
        ///Vybavení je poskytováno zdarma (true|false)
        /// [0..1]
        /// </summary>
        [XmlElement("free")]
        public bool Free { get; set; }
        
        /// <summary>
        ///Vybavení je poskytováno za částku X (free = false)
        /// [0..1]
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }
        
        /// <summary>
        ///Vybavení je hlídané (true|false)
        /// [0..1]
        /// </summary>
        [XmlElement("supervised")]
        public bool Supervised { get; set; }

        /// <summary>
        ///Vybavení je na hotelu (false) nebo na pokoji (true)
        /// [0..1]
        /// </summary>
        [XmlElement("hotelOrRoom")]
        public bool HotelOrRoom { get; set; }
        
        /// <summary>
        ///Vybavení má kapacitu X (osob)
        /// [0..1]
        /// </summary>
        [XmlElement("capacity")]
        public int Capacity { get; set; }
      
    }
}
