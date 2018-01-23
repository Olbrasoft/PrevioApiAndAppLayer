using System.Xml.Serialization;

namespace Previo.Api.Client
{   
    /// <summary>
    /// Pokoj nebo jiné prostory v hotelu (Kongresový sál , tenisová hala ...)
    /// </summary>
    [XmlType("objectKind")]
    public class ObjectKind : BaseObjectKind
    {
       
        /// <summary>
        /// Typ prostor v hotelu.
        ///  1 = pokoje, 
        /// 2 = ostatní prostory.
        /// [1]
        /// </summary>
        [XmlElement("obtId")]
        public int ObtId { get; set; }
        
        /// <summary>
        /// Název druhu prostor / pokojů
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
         
        /// <summary>
        /// Popis. Může obsahovat HTML.
        /// [1]
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Počet hlavních lůžek. 
        /// Pouze u pokojů (obtId = 1).
        /// [0..1]	
        /// </summary>
        [XmlElement("numOfBeds")]
        public int NumOfBeds { get; set; }

        /// <summary>
        ///Počet přistýlek. Pouze u pokojů (obtId = 1).
        /// [0..1]	
        /// </summary>
        [XmlElement("numOfExtraBeds")]
        public int NumOfExtraBeds { get; set; }
        
         /// <summary>
        ///Nabízet i jako jednolůžkový pokoj
        /// Pouze u pokojů (obtId = 1).
        /// [0..1]	
        /// </summary>
        [XmlElement("singleUse")]
        public bool SingleUse { get; set; }

        /// <summary>
        /// Vybavení pokojů
        /// Pokoj nabízí vybavení s vypsanými id
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("proId")]
        public int[] ProId { get; set; }

    }
}
