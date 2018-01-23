using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Nejake prostory v hotelu 
    /// Zpravidla pokoj ale take treba Tenisova hala
    /// </summary>
    public class Room : BaseRoom
    {
     
        
         /// <summary>
        ///Název pokoje/jiných prostor
        ///[1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
