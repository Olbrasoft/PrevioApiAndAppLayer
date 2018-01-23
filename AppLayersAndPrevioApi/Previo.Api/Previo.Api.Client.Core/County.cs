using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Okres
    /// </summary>
    [XmlType("county")]
    public struct County
    {
        /// <summary>
        ///Identifikátor okresu
        /// </summary>
        [XmlElement("cotId")]
        public int CotId { get; set; }
        
        /// <summary>
        ///Název okresu
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///Obce
        /// </summary>
        [XmlElement("town")]
        public Town Towns { get; set; }
     
    }
}
