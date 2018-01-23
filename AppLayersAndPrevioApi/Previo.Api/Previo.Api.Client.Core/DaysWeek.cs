using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Dny v týdnu
    /// </summary>
   public enum DaysWeek
   {
       /// <summary>
       /// Pondělí
       /// </summary>
       [XmlEnum("mon")]
       Monday,
       /// <summary>
       /// Úterý
       /// </summary>
       [XmlEnum("tue")]
       Tuesday,
       /// <summary>
       /// Středa
       /// </summary>
       [XmlEnum("wed")]
       Wednesday,
       /// <summary>
       /// Čtvrtek
       /// </summary>
       [XmlEnum("thu")]
       Thursday,
       /// <summary>
       /// Pátek
       /// </summary>
       [XmlEnum("fri")]
       Friday,
       /// <summary>
       /// Sobota
       /// </summary>
        [XmlEnum("sat")]
       Saturday,
       /// <summary>
       /// Neděle
       /// </summary>
       [XmlEnum("sun")]
       Sunday

   }
}
