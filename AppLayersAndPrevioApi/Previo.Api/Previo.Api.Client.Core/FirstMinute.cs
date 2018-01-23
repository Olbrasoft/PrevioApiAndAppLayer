using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Sleva na ubytování při rezervaci dopředu.
   /// </summary>
   public class FirstMinute :BaseDiscountRate
    {
       /// <summary>
       ///Identifikátor slevy
       /// </summary>
       [XmlElement("pfmId")]
       public int PfmId { get; set; }

        /// <summary>
       ///Minimální počet dní před vytvořením rezervace pro uplatnění slevy
       /// </summary>
       [XmlElement("minNumOfDaysBeforeArrival")]
       public int MinNumOfDaysBeforeArrival { get; set; }

  
    }
}
