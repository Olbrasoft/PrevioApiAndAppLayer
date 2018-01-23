using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    [XmlRoot("objectKinds")]
    public class ObjectKinds :List<ObjectKind>
    {
    }
}
