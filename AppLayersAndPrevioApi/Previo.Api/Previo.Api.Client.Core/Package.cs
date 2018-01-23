using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///  Balicek hotelu typu: sampanske na pokoji, bowling, masaz. 
    /// Tyto balicky si uzivatel objednava az ve druhem kroku rezervace.
    /// Tyto balíčky lze nastavit v menu Nastavení - Balíčky. 
    /// </summary>
    [XmlType("package")]
    public class Package :BasePackage
    {
        /// <summary>
        ///Id balíčku.
        /// [1]
        /// </summary>
        [XmlElement("pckId")]
        public int PckId { get; set; }

        /// <summary>
        ///hotId
        /// [1]
        /// </summary>
        [XmlElement("hotId")]
        public int HotId { get; set; }

        /// <summary>
        /// Sazba DPH v %.
        /// [1]
        /// </summary>
        [XmlElement("tax")]
        public double Tax { get; set; }
        

        /// <summary>
        /// Skupina balíčku.
        ///  Jeden nebo více balíčků můžou patřit do jedné skupiny
        /// [0..1]	
        /// </summary>
        [XmlElement("group")]
        public string Group { get; set; }

        /// <summary>
        ///  Balíček lze objednat pouze při pobytu o délce x nocí.
        /// [0..1]	
        /// </summary>
        [XmlElement("nights")]
        public string Nights { get; set; }

     
        /// <summary>
        ///  Způsob výběru balíčku.
        /// [1]
        /// text jako počet (text)
        ///checkbox jako zatržítko (checkbox)
        /// http://api.previo.cz/Hotel.getPackages#sect.selection
        /// </summary>
        [XmlElement("selection")]
        public string Selection { get; set; } 
   
        /// <summary>
        ///  	Způsob účtování balíčku. Má význam POUZE u online rezervací.
        ///  Na Plachtě rezervací se na tyto jednotky nebere ohled a cena se určuje dle počtu balíčků.
        /// [1]
        /// </summary>
        [XmlElement("unit")]
        public Unit Unit { get; set; }

      
        

    }
}
