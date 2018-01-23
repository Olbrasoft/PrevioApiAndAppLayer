using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Bázová třída balíčků
    ///     Pobytové a ostatní balíčky hotelu mají některé shodné vlastnosti,
    ///     které byly přesunuty do této bázové třídy
    /// </summary>
    public abstract class BasePackage
    {
        /// <summary>
        ///     Název balíčku.
        ///     [1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Popisek balíčku..
        ///     [0..1]
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Id galerie balíčku, jelikoz muze byt i null a nejde to
        ///     IHotelService.GetPhotogalleries
        ///     http://api.previo.cz/Hotel.getPhotogalleries
        ///     [0..1]
        /// </summary>
        [XmlElement("galId")]
        public int? GalId { get; set; }


        /// <summary>
        ///     Pokud se cena balíčku pro různé termíny liší, element season s elementy from a to se ve výstupu nacházejí víckrát.
        ///     V případě, že je season element ve výstupu jen jedenkrát a bez elementů from a to, je cena po celý rok stejná
        ///     [1..*]
        /// </summary>
        [XmlElement("season")]
        public Season[] Seasons { get; set; }
    }
}