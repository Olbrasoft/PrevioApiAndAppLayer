using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Popis a překlad
    /// </summary>
   [XmlType("message")]
   public class Message
    {
       /// <summary>
       ///Id řetězce (např. název pokoje, popis hotelu)
       /// http://api.previo.cz/Hotel.getMessages#sect.messageId
       /// [1]
       /// </summary>
       [XmlElement("messageId")]
       public int MessageId { get; set; }
       
       /// <summary>
       /// Typ popisu překladu
       /// </summary>
       public MessageType MessageType
       {
            get { return (MessageType) MessageId; }
       }
       

       /// <summary>
       ///Id enitity (např. id pokoje, id hotelu)
       /// [1]
       /// </summary>
       [XmlElement("entityId")]
       public int EntityId { get; set; }
       
       ///<summary>
       ///jayzyk
       /// [1]
       /// </summary>
       [XmlElement("language")]
       public Language Language { get; set; }

       /// <summary>
       ///Řetězec (překlad, popisek)
       /// [1]
       /// </summary>
       [XmlElement("text")]
       public string Text { get; set; }

       /// <summary>
       ///Řetězec byl přeložen automaticky (Google Translate). 
       /// Hodnoty true nebo false.
       /// [1]
       /// </summary>
       [XmlElement("autoTranslated")]
       public bool AutoTranslated { get; set; }
	
    }
}
