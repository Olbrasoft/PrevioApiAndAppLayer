using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// http://api.previo.cz/Hotel.get#sect.license
    /// </summary>
    public class License
    {
        /// <summary>
        /// Id licence
        /// [1]
        /// </summary>
        [XmlElement("licId")]
        public int LicId { get; set; }

        /// <summary>
        /// Název licence
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name;
    }
}
