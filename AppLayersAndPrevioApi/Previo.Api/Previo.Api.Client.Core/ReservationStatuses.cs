using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///Kolekce stavů rezervace.
    /// Používá se při vrácení číselníku jakých stavů může rezervace nabývat. 
    /// (odbydleno, zrušeno, zaplaceno ...)
    /// </summary>
    [XmlRoot("reservationStatuses")]
   public class ReservationStatuses :List<ReservationStatus>
   {

   }
}
