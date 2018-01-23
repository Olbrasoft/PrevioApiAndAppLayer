using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Pokud se cena balíčku pro různé termíny liší, element season s elementy from a to se ve výstupu nacházejí víckrát. 
    /// V případě, že je season element ve výstupu jen jedenkrát a bez elementů from a to, je cena po celý rok stejná.
    /// Jak pobytové  http://api.previo.cz/Hotel.getStayPackages tak klasické balíčky http://api.previo.cz/Hotel.getPackages
    ///  lze uložit bez ceny.  Není to chyba (cenu mohou doplnit kdykoliv potom). 
    /// V obou případech, pokud není vyplněna cena pro daný termín balíček v rezervačním formuláři nezobrazujeme.
    /// </summary>
    public class Season :BaseFromTo
    {
        
        /// <summary>
        ///Zobrazovat tento balíček na webu a v rezervačním formuláři. 
        /// Hodnoty true nebo false
        /// [1]
        /// </summary>
        [XmlElement("display")]
        public bool Display { get; set; }

        /// <summary>
        ///Tento balíček je pro on-line rezervaci povinný.
        ///  Hodnoty true nebo false
        /// [1]
        /// </summary>
        [XmlElement("required")]
        public bool Required { get; set; }

        /// <summary>
        ///  Cena balíčku. Pokud se cena pro různe druhy pokojů liší, 
        /// element se ve výstupu nachází víckrát.
        /// [1..*]
        /// </summary>
        [XmlElement("price")]
        public Price[] Prices { get; set; }
        

    }
}
