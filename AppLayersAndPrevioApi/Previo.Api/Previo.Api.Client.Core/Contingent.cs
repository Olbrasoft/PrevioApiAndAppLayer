using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kontingent
    /// </summary>
    [XmlType("contingent")]
   public struct Contingent
   {
       /// <summary>
       ///Celkový počet pokojů od daného druhu v kontingentu
       /// </summary>
       [XmlElement("total")]
       public int Total { get; set; }

        /// <summary>
       /// Neobsazené kapacity vracíte expiration dní od aktuálního dne.
        /// </summary>
       [XmlElement("expiration")]
       public int Expiration { get; set; }
        

       /// <summary>
       /// Id pokoje v kontingetu. Počet těchto id = hodnota total.
       /// Může se to stát, že hodnota bude null, pokud hotel nemá pro daný typ pokoje
       /// nastaven žádný konkrétní pokoj a tím pádem ani ceny. 
       /// Pokud má hotel zatrženo "BookOnline" ve funkci IHotelService.Get nemusí se kontingenty vůbec řešit. 
       /// </summary>
       [XmlElement("objId")]
       public int?[] ObjIds{ get; set; } 


   }
}
