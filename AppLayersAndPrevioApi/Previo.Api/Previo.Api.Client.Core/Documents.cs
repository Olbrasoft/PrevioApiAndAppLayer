using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Pokud element chybí nebyl vyplněn
    /// Kořenový element - documents
    /// [0..1]
    /// </summary>
    [XmlType("documents")]
    public class Documents :List<Document>
    { }
}
