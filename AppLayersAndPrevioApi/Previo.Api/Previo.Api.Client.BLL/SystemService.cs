using Moon.Xml.Serialization;
using Previo.Api.Client.DAL;

namespace Previo.Api.Client.BLL
{
    /// <summary>
    ///     Získávání číselníků
    /// </summary>
    public class SystemService : BasePrevioService, ISystemService
    {
        #region PrivateFields

        #endregion

        #region Constructors

        /// <summary>
        /// Zavolá constructor z bázové třídy, které předá objekt implementující rozhraní IPrevioRepository.
        /// Bázová třída Inicializuje vlastnost Repository a naplní jí objektem Implementující rozhraní IPrevioRepository
        /// </summary>
        /// <param name="repository">Třída, která umí vracet data z prévia</param>
        public SystemService(IPrevioRepository repository)
            : base(repository)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Public Functions

        /// <summary>
        ///     Funkce vrací pouze změny, které se udály od poslední Vaší synchronizace (zavolání dané API funkce) příslušných dat z Previa.
        ///     Previo API je potřeba volat s rozvahou. Data získaná např. operacemi Hotel.get nebo Hotel.getRoomKinds si vždy nejprve uložte do cache nebo do databáze a odtud je teprve poskytujte návštěvníkům vašich stránek.
        ///     Úkolem operace System.getChanges2 je, aby tato data byla co nejvíce čerstvá. Volejte ji v pravidelných intervalech (5 - 15 minut) a aktualizujte svoje data podle instrukcí.
        ///     Pokud element change obsahuje element hotId, aktualizujte data hotelu s tímto id. Pokud ne, aktualizujte data všech hotelů z Previa.
        ///     Funkce vrací maximálně 100 změn v jednom volání. Jeden typ změny (např. změna ceníku) je pro každý hotel vždy uveden pouze jedenkrát s datem nejposlednější úpravy. Pokud nezavoláte API funkci, která vrací ta data, jenž byla změněna, nezískáte další změny ve frontě (bude se Vám vracet stále stejných 100 změn).
        ///     Omezení vráceného počtu změn
        ///     PŘ: Hotelu s hotId 1 se změní cena, informace o změně se dostane do této fronty.
        ///     Poté příjde 99 recenzí, každá na jiný hotel. A nakonec příjde změna popisku hotelu s hotId 2.
        ///     Ve frontě bude pro Vás 100 změn (celkově jich je ale 101) a dokud nezavoláte API funkci, která vrací ceník (getRates)
        ///     nebo API funkci, která vrací recenze pro některý z těch 99 hotelů, tak se o změně popisku na hotId 2 nedozvíte.
        ///     funkce vrací jen změny, na které má daný uživatel oprávnění.
        /// </summary>
        /// <param name="changeTypes">Nepovinný parametr , který umožňuje volat jen změny konkrétního typu.</param>
        /// <returns>Změny v datech hotelů s rozlišením o jaký typ změny se jedná</returns>
        public Changes GetChages(ChangeType[] changeTypes = null)
        {
            return Repository.GetChanges(changeTypes.ToSnippetXml("changes", "change"));
        }

        /// <summary>
        ///     Globální číselník jazyků
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Globální číselník jazyků</returns>
        public Currencies GetCurrencies(int? lanId = null)
        {
            return Repository.GetCurrencies(BuildXmlSelectionLanId(lanId));
        }


        /// <summary>
        ///     Globální číselník vybavení hotelů
        ///     Každý hotel ve výstupu operací HotelService.Get a HotelsService.Search obsahuje 0..* vybavení, které jsou vybrány z tohoto číselníku.
        ///     U některých vybavení lze navíc zadat cenu nebo vzdálenost.
        ///     Vybavení je sdruženo do několika skupin. Můžete si vybrat, jestli ho takto budete prezentovat i na vašich stránkách nebo vše na jedné hromadě.
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     SystemService.GetLanguages  http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Číselník vybavení hotelů</returns>
        public GroupHotelProperties GetHotelProperties(int? lanId = null)
        {
            return Repository.GetHotelProperties(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník typů zařízení
        ///     Každý hotel si z tohoto číselníku vybírá právě jeden typ.
        ///     Který to je, zjistíte z elementu hoyId ve výstupu operace HotelService.Get.
        ///     http://api.previo.cz/Hotel.get
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     System.GetLanguages()  http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Globální číselník typů zařízení</returns>
        public HotelTypes GetHotelTypes(int? lanId = null)
        {
            return Repository.GetHotelTypes(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník jazyků
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     SystemService.GetLanguages  http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Globální číselník jazyků</returns>
        public Languages GetLanguages(int? lanId = null)
        {
            return Repository.GetLanguages(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník turistických lokalit
        ///     Každý hotel může patřit do jedné turistické lokality.
        ///     Její id a název jsou součástí výstupu operace Hotel.get.
        /// </summary>
        /// <returns>Turistické lokality</returns>
        public Localities GetLocalities()
        {
            return Repository.GetLocalities();
        }

        /// <summary>
        ///     Každý hotel může v různých termínech nabízet jinou podmnožinu z tohoto číselníku.
        ///     Více zjistíte pomocí operace HotelService.GetRates  http://api.previo.cz/Hotel.getRates.
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     SystemService.GetLanguages()  http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Globální číselník strav</returns>
        public Meals GetMeals(int? lanId = null)
        {
            return Repository.GetMeals(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník vybavení pokojů.
        ///     Každý druh pokojů ve výstupu operací SystemService.GetObjectKinds a SystemService.GetRoomKinds
        ///     obsahuje 0..* id vybavení, které jsou vybrány z tohoto číselníku.
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     Číselník jazyků vrací SystemService.GetLanguages
        /// </param>
        /// <returns>Číselník vybavení pokojů.</returns>
        public ObjectKindProperties GetObjectKindProperties(int? lanId = null)
        {
            return Repository.GetObjectKindProperties(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Vrátí všechny existující stavy rezervací (zaplaceno, potvrzeno, ...)
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        ///     System.GetLanguages()  http://api.previo.cz/System.getLanguages
        /// </param>
        /// <returns>Globální číselník stavů rezervace</returns>
        public ReservationStatuses GetReservationStatuses(int? lanId = null)
        {
            return Repository.GetReservationStatuses(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník procedur pro pobytové balíčky
        ///     Vrátí všechny existující procedury k pobytovým balíčkům
        ///     Data se získávají z  previa z SystemService.GetStayProcedures
        ///     více na  http://api.previo.cz/System.getStayProcedures
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        /// </param>
        /// <returns>Všechny existující procedury k pobytovým balíčkům</returns>
        public StayProcedures GetStayProcedures(int? lanId = null)
        {
            return Repository.GetStayProcedures(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     Globální číselník typu pobytu pro pobytové balíčky
        ///     Vrátí všechny existující typy pobytu k pobytovým balíčkům
        ///     Data se získávají z  previa z SystemService.GetStayPrograms
        ///     více na http://api.previo.cz/System.getStayPrograms
        /// </summary>
        /// <param name="lanId">
        ///     Identifikátor jazyka (nepovinné)
        /// </param>
        /// <returns>Všechny existující typy pobytu k pobytovým balíčkům</returns>
        public StayPrograms GetStayPrograms(int? lanId = null)
        {
            return Repository.GetStayPrograms(BuildXmlSelectionLanId(lanId));
        }

        /// <summary>
        ///     číselník krajů, okresů, obcí a PSČ
        ///     Kraje mají vlastost okresy , okresy mají vlastnost obce atd ...
        ///     Plně naplněná kolekce obsahuje celý číselník krajů, okresů, obcí a PSČ
        ///     více na http://api.previo.cz/System.getZips
        /// </summary>
        /// <returns>Číselník krajů, okresů, obcí a PSČ</returns>
        public Regions GetZips()
        {
            return Repository.GetZips();
        }


        /// <summary>
        ///     Z předaného LanId sestaví xml pro request
        /// </summary>
        /// <param name="lanId">Identifikátor jazyla</param>
        /// <returns>xml pro previo api  Request </returns>
        public static string BuildXmlSelectionLanId(int? lanId)
        {
            return lanId == null ? null : string.Format("<lanId>{0}</lanId>", lanId);
        }

        #endregion
    }
}