using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Turistické lokality
   /// [0..*]
   /// </summary>
   [XmlRoot("localities")]
   public class Localities :List<Locality>
   {
        
   }
}
