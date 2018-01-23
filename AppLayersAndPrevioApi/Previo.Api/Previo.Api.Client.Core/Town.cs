using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///  	Obec
    /// </summary>
    [XmlType("town")]
    public struct Town
    {
       /// <summary>
       ///Identifikátor obce
       /// </summary>
       [XmlElement("towId")]
       public int TowId { get; set; }

        /// <summary>
       ///Název obce
       /// </summary>
       [XmlElement("name")]
       public string Name { get; set; }

       /// <summary>
       ///PSČ
       /// </summary>
       [XmlElement("zip")]
       public Zip[] Zips { get; set; }
    }
}
