using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Bázová třída pro třídy které mají jako identifikátor ObjId
    /// </summary>
    public abstract class BaseRoom
    {
        /// <summary>
        ///     Id pokoje/jiných prostor
        ///     [1]
        /// </summary>
        [XmlElement("objId")]
        public int ObjId { get; set; }
    }
}