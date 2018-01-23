using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     kategorie hostů v hotelu
    /// </summary>
    [XmlRoot("guestCategories")]
    public class GuestCategories
    {
        /// <summary>
        ///     Id výchozí kategorie. Typicky dospělý.
        ///     [1]
        /// </summary>
        [XmlElement("default")]
        public int Default { get; set; }

        /// <summary>
        ///     Kategorie hostů
        ///     [1..*]
        /// </summary>
        [XmlElement("category")]
        public GuestCategory[] Categories { get; set; }
    }
}