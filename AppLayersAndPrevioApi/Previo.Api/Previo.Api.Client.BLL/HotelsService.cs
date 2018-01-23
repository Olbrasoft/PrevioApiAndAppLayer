using Moon.Xml.Serialization;
using Previo.Api.Client.DAL;

namespace Previo.Api.Client.BLL
{
    /// <summary>
    /// Třída umí vyhledávat hotely a provize
    /// </summary>
    public class HotelsService : BasePrevioService, IHotelsService
    {
      
        #region Constructors
        
        /// <summary>
        /// Zavolá constructor z bázové třídy, které předá objekt implementující rozhraní IPrevioRepository.
        /// Bázová třída Inicializuje vlastnost Repository a naplní jí objektem Implementující rozhraní IPrevioRepository
        /// </summary>
        /// <param name="repository">Třída, která umí vracet data z prévia</param>
        public HotelsService(IPrevioRepository repository)
            : base(repository)
        {
        }

        #endregion
        

        #region Public Functions

        /// <summary>
        ///     Pozor volat alespon s nejakym filtrem jinak error prilis velke data
        ///     Vyhledávání partnerských provizí
        ///     Previo v každé zemi fakturuje provize v jednotné měně, rezervace v jiných měnách jsou do cílové měny přepočítány.
        ///     Proto tato operace vrací na api.previo.cz všechny částky (price, previoBonusAmount, partnerBonusAmount a totalBonusAmount) v CZK a na api.previo.sk v EUR.
        ///     Měnu, ve které byla rezervace zaplacena, zjistíte z elementu account.
        /// </summary>
        /// <param name="filter">Filtr</param>
        /// //todo problem s filtrem from
        /// <param name="order">Pořadí výsledků</param>
        /// //todo neuvedeli se desc radi sestupne ?
        /// <param name="limit">Omezení počtu výsledků</param>
        /// <returns>Partnerské provize</returns>
        public Bonuses SearchBonuses(ISeacrhBonusesFilter filter, IOrder order, ILimit limit)
        {
            return
                Repository.SearchBonuses(filter.ToSnippetXmlOrNull() + order.ToSnippetXmlOrNull() +
                                         limit.ToSnippetXmlOrNull());
        }


        /// <summary>
        ///     Vyhledávání hotelů
        /// </summary>
        /// <param name="filter">Filtr výsledků</param>
        /// <param name="order">Pořadí výsledků</param>
        /// <param name="limit">Omezení počtu výsledků</param>
        /// <returns>Hotels má vlastnost </returns>
        public Hotels Search(ISearchFilter filter, IOrder order = null, ILimit limit = null)
        {
            return
                Repository.Search(filter.ToSnippetXmlOrNull() + order.ToSnippetXmlOrNull() + limit.ToSnippetXmlOrNull());
        }

        #endregion

       
    }
}