using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce pokojů v hotelu.
    /// </summary>
    [XmlRoot("roomKinds")]
    public class RoomKinds:List<ObjectKind>
    {
    }
}
