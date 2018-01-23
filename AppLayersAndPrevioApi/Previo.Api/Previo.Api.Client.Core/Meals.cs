using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    [XmlRoot("meals")]
    public class Meals :List<Meal>
    {
    }
}
