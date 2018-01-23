using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce popisů
    /// http://api.previo.cz/Hotel.getMessages
    /// </summary>
    [XmlRoot("messages")]
    public class Messages: List<Message> 
    {
       
    }
}
