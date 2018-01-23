namespace Previo.Api.Client.BLL
{
    /// <summary>
    /// Na třídu impolementující rozhraní IOrder se vztahuje Extension ( např ExToSnippetXml)
    /// , pomocí které je možné serializovat danou třídu do snipppetXml
    /// </summary>
    public interface IOrder : IToPrevioSnippetXml
    {
    }
}