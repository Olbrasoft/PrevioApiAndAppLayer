using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Fotka
   /// </summary>
   [XmlType("photo")]
   public struct Photo
   {
       [XmlElement("label")]
       public string Label { get; set; }
       
       [XmlElement("url")]
       public string Url { get; set; }
       
       [XmlElement("order")]
       public int Order { get; set; }
   }
}
