using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce typu pobytu k pobytovým balíčkům
    /// </summary>
    [XmlRoot("stayPrograms")]
    public class StayPrograms:List<Program>
    {}
}
