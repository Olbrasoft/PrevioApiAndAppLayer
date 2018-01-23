using System.Text;
using Moon.Net;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    ///     Configurace objektu Request kterým se ptáme na data  z prévia
    ///     Ptáme se pomocí POST , Content requestu (post data) jsou ve formatu application/xml a Encoding post dat je UTF8
    /// </summary>
    public class PreviApiRequestConfiguration : RequestConfig, IPrevioApiRequestConfiguration
    {
        public PreviApiRequestConfiguration(): base("POST", "application/xml", Encoding.UTF8)
        {
        }
    }
}