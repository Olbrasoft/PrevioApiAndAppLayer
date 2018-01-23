using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Typ pobytu k pobytovým balíčkům
    /// </summary>
     [XmlType("program")]
    public struct Program
    {
        /// <summary>
        ///Identifikátor typu pobytu
        /// </summary>
        [XmlElement("syrId")]
        public int SyrId { get; set; }
         
        /// <summary>
        ///Název typu pobytu
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

    }
}
