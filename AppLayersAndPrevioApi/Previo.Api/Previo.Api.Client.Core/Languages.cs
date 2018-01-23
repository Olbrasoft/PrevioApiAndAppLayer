using System.Collections.Generic;
using System.Xml.Serialization;
using Moon.Xml.Serialization;

namespace Previo.Api.Client
{   
    [XmlRoot("languages")]
    public class Languages:List<Language> ,IToSnippetXml
    {
    }
}
