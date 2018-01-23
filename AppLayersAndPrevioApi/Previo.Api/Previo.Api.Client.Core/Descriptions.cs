using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Popisy k hotelu.
    /// </summary>
    public class Descriptions
    {
        /// <summary>
        ///Krátký popis hotelu
        ///  [0..1]
        /// </summary>
        [XmlElement("shortDescription")]
        public string ShortDescription { get; set; }

        /// <summary>
        ///Detailní popis hotelu
        ///  [0..1]
        /// </summary>
        [XmlElement("longDescription")]
        public string LongDescription { get; set; }


        /// <summary>
        ///Popis pokojů
        ///  [0..1]
        /// </summary>
        [XmlElement("roomsDescription")]
        public string RoomsDescription { get; set; }


        /// <summary>
        ///Otevírací doba recepce
        ///  [0..1]
        /// </summary>
        [XmlElement("openingHours")]
        public string OpeningHours { get; set; }


        /// <summary>
        ///Gastronomie
        ///  [0..1]
        /// </summary>
        [XmlElement("gastronomy")]
        public string Gastronomy { get; set; }


        /// <summary>
        ///Popis okolí
        ///  [0..1]
        /// </summary>
        [XmlElement("surroundings")]
        public string Surroundings { get; set; }

     

        /// <summary>
        ///Dopravní dostupnost
        ///  [0..1]
        /// </summary>
        [XmlElement("transportAccessibility")]
        public string TransportAccessibility { get; set; }


        /// <summary>
        ///Další informace
        ///  [0..1]
        /// </summary>
        [XmlElement("additionalInfo")]
        public string AdditionalInfo { get; set; }


         /// <summary>
        ///Speciální akce a nabídky
        ///  [0..1]
        /// </summary>
        [XmlElement("events")]
        public string Events { get; set; }


    }
}
