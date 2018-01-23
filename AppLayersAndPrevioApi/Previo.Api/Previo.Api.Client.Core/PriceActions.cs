using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Cenové akce (slevy při objednání dopředu, objednávka na více dní ...)
    /// </summary>
   [XmlRoot("priceActions")]
   public class PriceActions
    {
      
       /// <summary>
       /// Kolekce slev při rezervaci dostatečně dopředu
       /// </summary>
       [XmlArray("firstMinutes")]
       [XmlArrayItem("firstMinute")]
       public FirstMinute[] FirstMinutes { get; set; }

       /// <summary>
       /// Kolekce slev při objednávce na poslední chvíli.
       /// (hotel nastaví například pokud mu zrušily rezervaci a chce narychlo obsadit uvolněný termýn .. ) 
       /// </summary>
       [XmlArray("lastMinutes")]
       [XmlArrayItem("lastMinute")]
       public LastMinute[] LastMinutes { get; set; }

       /// <summary>
       /// Kolekce slev při rezervaci na více dní ...
       /// </summary>
       [XmlArray("longTerms")]
       [XmlArrayItem("longTerm")]
       public LongTerm[] LongTerms { get; set; }
       
    }
}
