using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Kořenový element - packages
   /// </summary>
   [XmlRoot("packages")]
   public class Packages:List<Package>
   {}
}
