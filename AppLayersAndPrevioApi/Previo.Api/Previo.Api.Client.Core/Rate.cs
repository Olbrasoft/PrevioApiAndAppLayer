using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Cena balíčku. Pokud je v požadavku zadáno více druhů měn,
    ///  element se ve výstupu nachází víckrát.
    /// </summary>
   public class Rate
   {
        /// <summary>
        /// Cena (částka v dané měně)
       /// </summary>
       [XmlElement("price")]
       public float Price { get; set; }

        /// <summary>
       /// Měna
       /// </summary>
       [XmlElement("currency")]
       public Currency Currency { get; set; }
       
   }
}
