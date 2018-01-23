using Moon.Net;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    /// Třída implementující rozhraní  IPrevioApiRequestConfiguration
    /// má tvlastnosti RequestMethod,RequestContentType ,PostDataEncoding 
    /// Tyto vlastnosti říkají Províderovi, ketrej se ptá na data jak má nakonfigurovat Request
    /// </summary>
    public interface IPrevioApiRequestConfiguration : IRequestConfig
    {
    }
}