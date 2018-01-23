using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce Krajů (Středočeský, Jihočeský ... )
    /// Kraje mají vlastost okresy , okresy mají vlastnost obce atd ...
    /// Plně naplněná kolekce obsahuje celý číselník krajů, okresů, obcí a PSČ
    /// </summary>
    [XmlRoot("zips")]
    public class Regions:List<Region>
    {
    }
}
