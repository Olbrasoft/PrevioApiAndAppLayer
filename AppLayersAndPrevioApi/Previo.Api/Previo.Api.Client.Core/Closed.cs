using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///  	Zavřené pokoje
    /// </summary>
    [XmlType("closed")]
    public struct Closed
    {
       /// <summary>
       /// Celkový počet zavřených pokojů od daného druhu
       /// </summary>
       [XmlElement("total")]
       public int Total { get; set; }
        
        /// <summary>
       /// Id zavřených pokojů.
       ///  Počet těchto id = hodnota total.
       /// </summary>
       [XmlElement("objId")]
       public int[] ObjIds { get; set; }  	
 	

    }
}
