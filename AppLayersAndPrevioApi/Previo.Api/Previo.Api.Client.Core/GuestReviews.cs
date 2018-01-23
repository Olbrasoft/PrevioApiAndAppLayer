using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce hodnocení, které zadali hosté, kteří byly v hotelu ubytováni.
    /// </summary>
   [XmlType("guestReviews")]
    public class GuestReviews : List<GuestReview>
   {
       
   }
}
