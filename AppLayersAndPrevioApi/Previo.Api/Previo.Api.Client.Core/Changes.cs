using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    [XmlRoot("changes2")]
    public class Changes : List<Change>
    {
    }
}