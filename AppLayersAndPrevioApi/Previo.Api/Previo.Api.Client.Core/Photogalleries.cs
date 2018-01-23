using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
   /// <summary>
   /// Kolekce fotogalerií .
   /// Hotel může mít x fotogalerií
   /// </summary>
   [XmlRoot("photogalleries")]
   public class Photogalleries :List<Gallery>
   {
        
   }
}
