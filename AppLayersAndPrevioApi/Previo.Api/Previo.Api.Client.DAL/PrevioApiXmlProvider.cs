using Moon.Api;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    /// Umí vytvořit request poslat Post Data a přijaté data vrátit jako string
    /// </summary>
    public class PrevioApiXmlProvider : ApiStringProvider, IPrevioApiXmlProvider
    {
        public PrevioApiXmlProvider(IPrevioApiRequestConfiguration config)
            : base(config)
        {
        }
    }
}