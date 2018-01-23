using System.Xml.Serialization;

namespace Previo.Api.Client
{   
    /// <summary>
    /// PSČ
    /// </summary>
    [XmlType("zip")]
    public struct Zip
    {
        /// <summary>
       ///Identifikátor PSČ
       /// </summary>
       [XmlElement("zipId")]
       public int ZipId { get; set; }

       /// <summary>
       ///PSČ (samotné číslo)
       /// </summary>
       [XmlElement("code")]
       public string Code { get; set; }	

       /// <summary>
       ///Část obce, čtvrť
       /// </summary>
       [XmlElement("district")]
       public string District { get; set; }	
    }
}
