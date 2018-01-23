using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///  Pobytový balíček, napriklad romanticky vikend pro dva na horach.
    ///  Tyto balicky maji v rezervacnim formulari samostatnou zalozku: 
    /// </summary>
    [XmlType("stayPackage")]
   public class StayPackage :BasePackage
    {
        /// <summary>
        ///Identifikátor balíčku
        /// [1]
        /// </summary>
        [XmlElement("styId")]
        public int StyId { get; set; }

        /// <summary>
        ///Počet nocí
        /// [1]
        /// </summary>
        [XmlElement("nights")]
        public int Nights { get; set; }

        /// <summary>
        ///Poznámka
        /// [1]
        /// </summary>
        [XmlElement("note")]
        public string Note { get; set; }

        
        /// <summary>
        ///Textový popis, co zahrnuje balíček
        /// [1]
        /// </summary>
        [XmlElement("includes")]
        public string Includes { get; set; }

        /// <summary>
        ///Identifikátor zahrnuté stravy
        /// [1]
        /// </summary>
        [XmlElement("meaId")]
        public int MeaId { get; set; }


        /// <summary>
        ///Identifikátor zahrnuté stravy
        ///  1 - Cena je účtována za pobyt všech osob na daném pokoji.
        ///  2 - Cena je účtována za pobyt jedné osoby na daném pokoji.
        /// [1]
        /// </summary>
        [XmlElement("unitId")]
        public int UnitId { get; set; }


        /// <summary>
        /// Den možného nájezdu jako string 
        /// zkratka en nazvu dnu sun, mon, tue, wed ...
        /// </summary>
        [XmlArray("arrivals")]//[1]
        [XmlArrayItem("arrival")]//[0...*]
        public string[] Arrivals { get; set; }

    }
}
