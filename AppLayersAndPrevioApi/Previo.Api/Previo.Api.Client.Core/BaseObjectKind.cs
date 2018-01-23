using System.Xml.Serialization;

namespace Previo.Api.Client
{   
    /// <summary>
    /// Bázová třída určuje že se jedná o objekt s identifikátorem
    /// ObkId
    /// </summary>
    public abstract class BaseObjectKind
    {
        /// <summary>
        /// Id druhu prostor / pokojů
        /// </summary>
        [XmlElement("obkId")]
        public int ObkId { get; set; }
    }
}
