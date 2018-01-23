using System.Collections.Generic;
using System.Xml.Serialization;
using Moon.Xml.Serialization;

namespace Previo.Api.Client
{
   [XmlRoot("changes")]
   public class ChangesOld:List<Change>
   {
        
   }
}
