using Moon.Xml.Serialization;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    /// Umí deserializovat předanej string xml na požadovaný typ
    /// </summary>
    public class PrevioXmlDeserializer : GenericObjectXmlDeserializer, IPrevioXmlDeserializer
    {
    }
}