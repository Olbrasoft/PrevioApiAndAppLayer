namespace Previo.Api.Client.BLL
{
    /// <summary>
    ///     Na třídu impolementující rozhraní IBookingService se vztahuje Extension ( např ExToSnippetXml)
    ///     , pomocí které je možné serializovat danou třídu do snipppetXml
    /// </summary>
    public interface IBookingService
    {
        FreeCapacity GetFreeCapacity(int hotId,ITerm term);
    }
}