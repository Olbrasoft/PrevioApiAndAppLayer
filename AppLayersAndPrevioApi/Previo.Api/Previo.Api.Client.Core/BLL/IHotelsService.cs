namespace Previo.Api.Client.BLL
{   
    /// <summary>
    /// Třída Implementující rozhraní IHotelsService, bude umět vyhledat hotely
    /// a dále vyhledat provize rezervací
    /// </summary>
    public interface IHotelsService
    {
        /// <summary>
        ///     Vyhledávání partnerských provizí
        /// </summary>
        /// <param name="filter">Filtr výběru provizí</param>
        /// <param name="order">řezení vrácených provizí</param>
        /// <param name="limit">Omezení počtu vrácených rezervací skip/top</param>
        /// <returns>Partnerské provize</returns>
        Bonuses SearchBonuses(ISeacrhBonusesFilter filter, IOrder order, ILimit limit);


        /// <summary>
        ///     Vyhledávání hotelů
        /// </summary>
        /// <param name="filter">Filtr výsledků</param>
        /// <param name="order">Pořadí výsledků</param>
        /// <param name="limit">Omezení počtu výsledků</param>
        /// <returns>Hotels má vlastnost </returns>
        Hotels Search(ISearchFilter filter, IOrder order=null, ILimit limit=null);
    }
}