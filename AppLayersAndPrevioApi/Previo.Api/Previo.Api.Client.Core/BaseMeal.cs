using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Bázová třída určuje že se jedná o objekt s identifikátorem
    /// MeaId
    /// </summary>
   public abstract class BaseMeal
   {
        /// <summary>
        /// Id stravy
        /// </summary>
       [XmlElement("meaId")]
       public int MeaId { get; set; }
   }
}
