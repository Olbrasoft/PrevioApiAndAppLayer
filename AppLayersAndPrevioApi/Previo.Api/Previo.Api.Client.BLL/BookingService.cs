using Moon.Xml.Serialization;
using Previo.Api.Client.DAL;

namespace Previo.Api.Client.BLL
{
    /// <summary>
    ///     Vyhledávání volné kapacity ssss
    /// </summary>
    public class BookingService : BasePrevioService, IBookingService
    {
        public BookingService(IPrevioRepository repository) : base(repository)
        {}

        /// <summary>
        /// Vyhledávání volné kapacity
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <param name="term">
        /// Vrátí volné kapacity pokojů v daném rozsahu datumů.
        /// !!! Stačí, že vyhoví alespoň jedno datum To OR From a data jsou vrácena
        /// vrať data Where  From =&gt;  OR  To &lt;= 
        /// </param>
        /// <returns></returns>
        public FreeCapacity GetFreeCapacity(int hotId, ITerm term)
        {
            return Repository.GetFreeCapacity(BuildHotIdSnippetXml(hotId) + term.ToSnippetXmlOrNull());
        }
    }
}