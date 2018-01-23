using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Cena balíčku
    /// </summary>
   public class Price
    {
       	 /// <summary>
        /// Druh pokoje, pokud je cena balíčku různá pro různe druhy pokojů.
        /// [0..1]
        /// </summary>
        [XmlElement("objectKind")]
        public ObjectKind ObjectKind { get; set; } 

       /// <summary>
        /// Cena balíčku. Pokud je v požadavku zadáno více druhů měn,
        ///  element se ve výstupu nachází víckrát.
        /// [1..*]
        /// </summary>
        [XmlElement("rate")]
        public Rate[] Rates { get; set; } 
       
    }
}
