using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Turistická lokalita
    /// http://api.previo.cz/System.getLocalities
    /// </summary>
    [XmlType("locality")]
    public class Locality
    {
        /// <summary>
        /// Turistická lokalita
        /// [1]
        /// </summary>
        [XmlElement("lctId")]
        public int LctId { get; set; }

        /// <summary>
        /// Turistická lokalita
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
