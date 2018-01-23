using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kraj
    /// </summary>
    [XmlType("region")]
    public struct Region
    {
       /// <summary>
       ///Identifikátor kraje
       /// </summary>
       [XmlElement("regId")]
       public int RegId{ get; set; }

       /// <summary>
       ///Název kraje
       /// </summary>
       [XmlElement("name")]
       public string Name{ get; set; }

       /// <summary>
       ///Okresy
       /// </summary>
       [XmlElement("county")]
       public County[] Counties { get; set; }
 	
    }
}
