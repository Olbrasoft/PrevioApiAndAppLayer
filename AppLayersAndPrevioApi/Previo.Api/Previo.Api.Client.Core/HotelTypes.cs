using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce typů ubytovacích zařízeních.
    /// </summary>
    [XmlRoot("hotelTypes")]
    public class HotelTypes :List<HotelType>
    {
    }
}
