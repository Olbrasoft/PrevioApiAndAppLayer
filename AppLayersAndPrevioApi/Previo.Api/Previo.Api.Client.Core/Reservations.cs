using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Koleckce rezervací
    /// </summary>
    [XmlRoot("reservations")]
    public class Reservations :List<Reservation> 
    {

    }
}
