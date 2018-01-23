using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce procedur pro pobytové balíčky
    /// </summary>
    [XmlRoot("stayProcedures")]
   public class StayProcedures:List<Procedure>
   {}
}
