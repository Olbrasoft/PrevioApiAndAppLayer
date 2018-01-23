using Previo.Api.Client.DAL;

namespace TestPrevioApiClient
{
    public interface IMockRepository :  IPrevioRepository
    {
        T Get<T>(string method, string innerPostData = "");
    }
}
