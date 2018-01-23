using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   ///Pobytové balíčky
   /// </summary>
   [XmlRoot("stayPackages")]
   public class StayPackages :List<StayPackage>
   {

   }
}
