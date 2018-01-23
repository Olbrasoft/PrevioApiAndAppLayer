namespace Previo.Api.Client.BLL
{
    /// <summary>
    /// Na třídu impolementující rozhraní ITerm se vztahuje Extension ( např ExToSnippetXml)
    /// , pomocí které je možné serializovat danou třídu do snipppetXml
    /// </summary>
    public interface ITerm : IToPrevioSnippetXml
    {
    }
}