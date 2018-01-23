using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///  Procedura k pobytovým balíčkům
    /// </summary>
     [XmlType("procedure")]
    public struct Procedure
    {
        /// <summary>
        ///Identifikátor procedury
        /// </summary>
         [XmlElement("sycId")]
        public int SycId { get; set; }

        /// <summary>
        ///Název procedury
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///Hlavička popisu procedury
        /// </summary>
        [XmlElement("excerpt")]
        public string Excerpt { get; set; }

        /// <summary>
        ///Detailní popis procedury
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }  
	
    }
}
