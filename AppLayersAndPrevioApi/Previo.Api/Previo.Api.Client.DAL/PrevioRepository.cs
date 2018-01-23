using System;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    ///     Pro získávání a deserializaci dat .
    ///     Z webu previa. Řeší vytvoření přesné adresy na kterou se má poslat požadavek a
    ///     Sestavení xml pro post data ,které se odešlou v Requestu na api.
    ///     Vytvoření Requestu a vrácení přijatých dat obstará IPrevioApiXmlProvider, který je předán
    ///     v konstruktoru. Repository poté přijaté data převedou na požadovaný objekt a ten vrátí.
    /// </summary>
    public class PrevioRepository : IPrevioRepository
    {
        protected readonly IPrevioXmlDeserializer Deserializer;
        protected readonly IPrevioApiXmlProvider PrevioApiProvider;
        protected readonly IPrevioValidXmlBuilder ValidXmlBuilder;

        protected IConfigurationPrevioRepository Configuration { get; set; }

        #region Constructors

        /////     Před použitím však stejně musíme nastavit vlastnost Configuration
        /////     Využití pokud třeba budeme chtít získávat data pomocí několika uživatelů v previu.
        /////     Například jiná konfigurace jména hesla a bázové adresy na Slovenské a na České hotely
        /// <summary>
        /// </summary>
        /// <param name="apiProvider">Třída která umí udělat Request na požadovanou a vrácená data vrátí jako string</param>
        /// <param name="deserializer">Objekt který umí xml deserializovat na požadovanej objekt</param>
        /// <param name="validXmlBuilder">Objekt který umí z nevalidního xml předávaného z previa udělat validní xml</param>
        public PrevioRepository(IPrevioApiXmlProvider apiProvider, IPrevioXmlDeserializer deserializer,
                                IPrevioValidXmlBuilder validXmlBuilder)
            : this(null, apiProvider, deserializer, validXmlBuilder)
        {
        }

        /// <summary>
        ///     Vytvoří objekt typu PrevioRepository a rovnou nastaví vlastnost Configuration
        /// </summary>
        /// <param name="configuration">
        ///     Configurace Api Clienta heslo, jmeno bazova adresa n aktere je api
        /// </param>
        /// <param name="apiProvider">Třída která umí udělat Request na požadovanou a vrácená data vrátí jako string</param>
        /// <param name="deserializer">Objekt který umí xml deserializovat na požadovanej objekt</param>
        /// <param name="validXmlBuilder">Objekt který umí z nevalidního xml předávaného z previa udělat validní xml</param>
        public PrevioRepository(IConfigurationPrevioRepository configuration, IPrevioApiXmlProvider apiProvider,
                                IPrevioXmlDeserializer deserializer, IPrevioValidXmlBuilder validXmlBuilder)
        {
            Configuration = configuration;
            PrevioApiProvider = apiProvider;
            Deserializer = deserializer;
            ValidXmlBuilder = validXmlBuilder;
        }

        #endregion

        #region Public Functions

        /// <summary>
        ///     !!! Není otestováno nejsou práva, určeno pro hotely
        ///     Vrací seznam vydaných dokladů k dané rezervaci
        /// </summary>
        /// <param name="innerPostData">
        ///     &lt;hotId&gt;1&lt;/hotId&gt;
        ///     &lt;comId&gt;12554&lt;/comId&gt;
        /// </param>
        /// <returns>Seznam vydaných dokladů k dané rezervaci</returns>
        public Documents GetDocuments(string innerPostData)
        {
            return Get<Documents>("Hotel.getDocuments", innerPostData);
        }


        /// <summary>
        ///     Vrátí kategorie hostů v hotelu
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Kategorie hostů v hotelu</returns>
        public GuestCategories GetGuestCategories(string innerPostData)
        {
            return Get<GuestCategories>("Hotel.getGuestCategories", innerPostData);
        }


        /// <summary>
        ///     Vrací recenze hostů na hotel
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Recenze hostů </returns>
        public GuestReviews GetGuestReviews(string innerPostData)
        {
            return Get<GuestReviews>("Hotel.getGuestReviews", innerPostData);
        }

        /// <summary>
        ///     Popisky a překlady
        ///     Všechny operace Previo API vrací řetězce (např. popis hotelu nebo název pokoje)
        ///     ve výchozím jazyce serveru, tzn. na api.previo.cz česky, na api.previo.sk slovensky atd.
        ///     Pomocí této operace můžete získat najednou všechny řetězce ve všech podporovaných jazycích
        ///     ,které získáte zavoláním Funkce GetLanguages
        ///     (včetně výchozího).
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro filtr výsledků hotId Id hotelu
        ///     languages Omezení výběru jazyků. Pokud vynecháno, vrátí řetězce ve všech podporovaných jazycích,
        ///     které získáte zavoláním Funkce GetLanguages například:
        ///     &lt;hotId&gt;4587&lt;/hotId&gt;
        ///     &lt;languages&gt;
        ///     &lt;language&gt;
        ///     &lt;code&gt;en&lt;/code&gt;
        ///     &lt;/language&gt;
        ///     &lt;language&gt;
        ///     &lt;code&gt;de&lt;/code&gt;
        ///     &lt;/language&gt;
        ///     &lt;/languages&gt;
        /// </param>
        /// <returns></returns>
        public Messages GetMessages(string innerPostData)
        {
            return Get<Messages>("Hotel.getMessages", innerPostData);
        }

        /// <summary>
        ///     Vrátí pokoje a další prostory v hotelu
        ///     Ve většině případů vás budou zajímat pouze pokoje.
        ///     Potom použijte Funkcci GetRoomKinds, která má stejné parametry a formát výstupu,
        ///     ale vrací pouze pokoje (ObtId = 1).
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Pokoje a další prostory v hotelu.</returns>
        public ObjectKinds GetObjectKinds(string innerPostData)
        {
            return Get<ObjectKinds>("Hotel.getObjectKinds", innerPostData);
        }

        /// <summary>
        ///     Vrátí fotogalerie hotelu a pokojů
        ///     Jako titulní fotku hotelu použijte první fotku z první fotogalerie.
        ///     Název souboru (fotografie) se skládá z [timestamp.extension]
        ///     kde timestamp je čas nahrání souboru na server
        /// </summary>
        /// <param name="innerPostData"></param>
        /// <returns>Fotogalerie hotelu a pokojů</returns>
        public Photogalleries GetPhotogalleries(string innerPostData)
        {
            return Get<Photogalleries>("Hotel.getPhotogalleries", innerPostData);
        }

        /// <summary>
        ///     Hotely nabízejí určité slevy, odvíjející se od doby objednání pobytu.
        ///     Tato funkce vrací data potřebná k určení slevy.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Data potřebná k určení slevy.</returns>
        public PriceActions GetPriceActions(string innerPostData)
        {
            return Get<PriceActions>("Hotel.getPriceActions", innerPostData);
        }

        /// <summary>
        ///     Vrátí ceny, kontingenty, uzavírky, omezení a nastavení plateb
        ///     Tato operace vrací všechna data, které lze nastavit v menu Nastavení - Ceny.
        ///     Způsob účtování ceny ubytování
        ///     Pokud je hodnota vlastnosti PrmId 1, hotel účtuje ceny ubytování podle obsazenosti. Pokud je hodnota 2, cena je jednotná za celý pokoj nezávisle na počtu hostů.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro filtr výsledků hotId	Id hotelu
        ///     term	Termín
        ///     currencies	Filtr měn
        ///     prlIds	Filtr cenových plánů
        ///     obkIds	Filtr druhů pokojů  například:
        ///     &lt;hotId&gt;745896&lt;/hotId&gt;
        ///     &lt;term&gt;
        ///     &lt;from&gt;2010-01-01&lt;/from&gt;
        ///     &lt;to&gt;2010-12-31&lt;/to&gt;
        ///     &lt;/term&gt;
        ///     &lt;currencies&gt;
        ///     &lt;currency&gt;
        ///     &lt;code&gt;CZK&lt;/code&gt;
        ///     &lt;/currency&gt;
        ///     &lt;currency&gt;
        ///     &lt;code&gt;EUR&lt;/code&gt;
        ///     &lt;/currency&gt;
        ///     &lt;/currencies&gt;
        /// </param>
        /// <returns>Ceny, kontingenty, uzavírky, omezení a nastavení plateb</returns>
        public RatesContingentsClosures GetRates(string innerPostData)
        {
            return Get<RatesContingentsClosures>("Hotel.getRates", innerPostData);
        }


        /// <summary>
        ///     Vrátí pokoje v hotelu
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Pokoje v hotelu</returns>
        public RoomKinds GetRoomKinds(string innerPostData)
        {
            return Get<RoomKinds>("Hotel.getRoomKinds", innerPostData);
        }


        /// <summary>
        ///     Vrátí všechny pobytové balíčky hotelu.
        ///     Tato operace vrací všechna potřebná data k prezentování pobytových balíčků
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Všechny pobytové balíčky hotelu</returns>
        public StayPackages GetStayPackages(string innerPostData)
        {
            return Get<StayPackages>("Hotel.getStayPackages", innerPostData);
        }


        /// <summary>
        ///     Vrátí všechny rezervace a seznam aktuálně ubytovaných hostů pro daný hotel v požadovaném termínu
        ///     , případně konkrétní rezervace.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro
        ///     hotId Id hotelu term	Termín
        ///     comIds	Identifikátory rezervací
        ///     například:
        ///     &lt;request&gt;
        ///     &lt;login&gt;prihlasovaci_jmeno&lt;/login&gt;
        ///     &lt;password&gt;heslo&lt;/password&gt;
        ///     &lt;hotId&gt;745896&lt;/hotId&gt;
        ///     &lt;term&gt;
        ///     &lt;from&gt;2010-01-01&lt;/from&gt;
        ///     &lt;to&gt;2010-12-31&lt;/to&gt;
        ///     &lt;/term&gt;
        ///     &lt;comIds&gt;
        ///     &lt;comId&gt;55565445&lt;/comId&gt;
        ///     &lt;/comIds&gt;
        ///     &lt;/request&gt;
        /// </param>
        /// <returns>
        ///     Všechny rezervace a seznam aktuálně ubytovaných hostů pro daný hotel v požadovaném termínu
        ///     , případně konkrétní rezervace.
        /// </returns>
        public Reservations SearchReservations(string innerPostData)
        {
            return Get<Reservations>("Hotel.searchReservations", innerPostData);
        }


        //todo dodelat addAccountItem nekdy ?
        public object AddAccountItem(string innerPostData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Nastaví podmínky spolupráce s hotelem
        ///     Spolupráce partnera a hotelu se řídí stavem a provizí. Aktuální podmínky spolupráce s hotelem zjistíte z výstupu operace Get.
        ///     Previo API vždy udržuje výchozí poměr provizí Previa a partnera. Stačí tedy zadat pouze jednu z provizí (totalBonusRate, partnerBonusRate nebo previoBonusRate)
        ///     a zbylé jsou dopočítány automaticky. Pokud jich je zadáno víc, vezme se první v pořadí total - partner - previo a zbylé hodnoty se zahodí.
        ///     Dopočítané hodnoty jsou součástí výstupu této operace.
        ///     Previo API chrání hotel, při zvýšení celkové provize se stav spolupráce automaticky přepne z active a WaitingForPartner na WaitingForHotel.
        ///     Automaticky přepnutý stav je součástí výstupu této operace.
        /// </summary>
        /// <param name="innerPostData">inner Snippet  xml </param>
        /// <returns>Nově nastavené podmínky spolupráce s hotelem.</returns>
        public Collaboration SetCollaboration(string innerPostData)
        {
            return Get<Collaboration>("Hotel.setCollaboration", innerPostData);
        }


        /// <summary>
        ///     Vrátí všechny pobytové balíčky hotelu.
        ///     Tato operace vrací všechna potřebná data k prezentování pobytových balíčků
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Všechny pobytové balíčky hotelu.</returns>
        public Packages GetPackages(string innerPostData)
        {
            return Get<Packages>("Hotel.getPackages", innerPostData);
        }

        /// <summary>
        ///     Vrátí podrobné informace o hotelu
        ///     Pokud chcete zjišťovat informace o více hotelech najednou,
        ///     použijte operaci Search, která má identický výstup.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Podrobné informace o hotelu</returns>
        public Hotel Get(string innerPostData)
        {
            return Get<Hotel>("Hotel.get", innerPostData);
        }


        /// <summary>
        ///     Vyhledávání hotelů
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro Filtr výsledků
        ///     order Pořadí výsledků
        ///     limit Omezení počtu výsledků
        ///     například:
        ///     &lt;filter&gt;
        ///     &lt;in&gt;
        ///     &lt;field&gt;collaboration&lt;/field&gt;
        ///     &lt;value&gt;active&lt;/value&gt;
        ///     &lt;/in&gt;
        ///     &lt;/filter&gt;
        ///     &lt;order&gt;
        ///     &lt;by&gt;name&lt;/by&gt;
        ///     &lt;desc&gt;false&lt;/desc&gt;
        ///     &lt;/order&gt;
        ///     &lt;limit&gt;
        ///     &lt;offset&gt;100&lt;/offset&gt;
        ///     &lt;limit&gt;200&lt;/limit&gt;
        ///     &lt;/limit&gt;
        /// </param>
        /// <returns>Požadované hotely</returns>
        public Hotels Search(string innerPostData = "")
        {
            return Get<Hotels>("Hotels.search", innerPostData);
        }


        /// <summary>
        ///     Vyhledávání partnerských provizí
        ///     Previo v každé zemi fakturuje provize v jednotné měně, rezervace v jiných měnách jsou do cílové měny přepočítány.
        ///     Proto tato operace vrací na api.previo.cz všechny částky (Price, PrevioBonusAmount, PartnerBonusAmount a TotalBonusAmount)
        ///     v CZK a na api.previo.sk v EUR. Měnu, ve které byla rezervace zaplacena, zjistíte z Vlastnosti Account.
        /// </summary>
        /// <param name="innerPostData">
        ///     &lt;filter&gt;
        ///     &lt;hotId&gt;1&lt;/hotId&gt;
        ///     &lt;from&gt;2010-01-01&lt;/from&gt;
        ///     &lt;to&gt;2010-01-31&lt;/to&gt;
        ///     &lt;comIds&gt;
        ///     &lt;comId&gt;000111&lt;/comId&gt;
        ///     &lt;/comIds&gt;
        ///     &lt;/filter&gt;
        ///     &lt;order&gt;
        ///     &lt;by&gt;hotId&lt;/by&gt;
        ///     &lt;/order&gt;
        ///     &lt;limit&gt;
        ///     &lt;offset&gt;0&lt;/offset&gt;
        ///     &lt;limit&gt;100&lt;/limit&gt;
        ///     &lt;/limit&gt;
        /// </param>
        /// <returns>Partnerské provize</returns>
        public Bonuses SearchBonuses(string innerPostData = "")
        {
            return Get<Bonuses>("Hotels.searchBonuses", innerPostData);
        }

        /// <summary>
        ///     Změny v datech hotelů s rozlišením o jaký typ změny se jedná
        ///     Funkce vrací pouze změny, které se udály od poslední Vaší synchronizace
        ///     (zavolání dané API funkce) příslušných dat z Previa.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru požadováných typů změn ChangeType
        ///     Například :
        ///     &lt;changes&gt;
        ///     &lt;change&gt;get&lt;/change&gt;
        ///     &lt;change&gt;getGuestCategories&lt;/change&gt;
        ///     &lt;change&gt;searchBonuses&lt;/change&gt;
        /// </param>
        /// <returns>Změny v datech hotelů s rozlišením o jaký typ změny se jedná</returns>
        public Changes GetChanges(string innerPostData = "")
        {
            return Get<Changes>("System.getChanges2", innerPostData);
        }


        /// <summary>
        ///     Globální číselník měn
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru //todo nefunguje poslan dotaz do pravia
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník měn</returns>
        public Currencies GetCurrencies(string innerPostData = "")
        {
            return Get<Currencies>("System.getCurrencies", innerPostData);
        }

        /// <summary>
        ///     Globální číselník vybavení hotelů
        ///     Každý hotel ve výstupu operací Get a Search obsahuje 0..* vybavení, které jsou vybrány z tohoto číselníku.
        ///     U některých vybavení lze navíc zadat cenu nebo vzdálenost.
        ///     Vybavení je sdruženo do několika skupin. Můžete si vybrat, jestli ho takto budete prezentovat i na vašich stránkách nebo vše na jedné hromadě.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Číselník vybavení hotelů</returns>
        public GroupHotelProperties GetHotelProperties(string innerPostData = "")
        {
            return Get<GroupHotelProperties>("System.getHotelProperties", innerPostData);
        }

        /// <summary>
        ///     Globální číselník typů zařízení
        ///     Každý hotel si z tohoto číselníku vybírá právě jeden typ.
        ///     Který to je, zjistíte z elementu hoyId ve výstupu operace Get.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník typů zařízení</returns>
        public HotelTypes GetHotelTypes(string innerPostData = "")
        {
            return Get<HotelTypes>("System.getHotelTypes", innerPostData);
        }

        /// <summary>
        ///     Globální číselník jazyků
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru //todo nefunguje poslan dotaz do pravia
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník jazyků</returns>
        public Languages GetLanguages(string innerPostData = "")
        {
            return Get<Languages>("System.getLanguages", innerPostData);
        }

        /// <summary>
        ///     Globální číselník turistických lokalit
        ///     Každý hotel může patřit do jedné turistické lokality.
        ///     Její id a název jsou součástí výstupu operace Get.
        /// </summary>
        /// <returns>Globální číselník turistických lokalit</returns>
        public Localities GetLocalities()
        {
            return Get<Localities>("System.getLocalities");
        }

        /// <summary>
        ///     Globální číselník strav
        ///     Každý hotel může v různých termínech nabízet jinou podmnožinu z tohoto číselníku.
        ///     Více zjistíte pomocí operace GetRates.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník strav</returns>
        public Meals GetMeals(string innerPostData = "")
        {
            return Get<Meals>("System.getMeals", innerPostData);
        }

        /// <summary>
        ///     Globální číselník vybavení pokojů
        ///     Každý druh pokojů ve výstupu operací GetObjectKinds a GetRoomKinds obsahuje 0..* id vybavení,
        ///     které jsou vybrány z tohoto číselníku.
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník vybavení pokojů</returns>
        public ObjectKindProperties GetObjectKindProperties(string innerPostData = "")
        {
            return Get<ObjectKindProperties>("System.getObjectKindProperties", innerPostData);
        }

        /// <summary>
        ///     Globální číselník stavů rezervace
        ///     Vrátí všechny existující stavy rezervací (zaplaceno, potvrzeno, ...)
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník stavů rezervace</returns>
        public ReservationStatuses GetReservationStatuses(string innerPostData = "")
        {
            return Get<ReservationStatuses>("System.getReservationStatuses", innerPostData);
        }

        /// <summary>
        ///     Globální číselník procedur pro pobytové balíčky
        ///     Vrátí všechny existující procedury k pobytovým balíčkům
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník procedur pro pobytové balíčky</returns>
        public StayProcedures GetStayProcedures(string innerPostData = "")
        {
            return Get<StayProcedures>("System.getStayProcedures", innerPostData);
        }

        /// <summary>
        ///     Globální číselník typu pobytu pro pobytové balíčky
        ///     Vrátí všechny existující typy pobytu k pobytovým balíčkům
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>číselník typu pobytu pro pobytové balíčky</returns>
        public StayPrograms GetStayPrograms(string innerPostData = "")
        {
            return Get<StayPrograms>("System.getStayPrograms", innerPostData);
        }

        /// <summary>
        ///     Globální číselník krajů, okresů, obcí a PSČ
        /// </summary>
        /// <returns>Globální číselník krajů, okresů, obcí a PSČ</returns>
        public Regions GetZips()
        {
            return Get<Regions>("System.getZips");
        }

        /// <summary>
        ///     Vyhledávání volné kapacity
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru
        ///     Filtrování datumu funguje jako or
        ///     vrať data Where  From =&gt;  OR  To &lt;=
        ///     například:
        ///     &lt;hotId&gt;2&lt;/hotId&gt;
        ///     &lt;term&gt;
        ///     &lt;from&gt;2010-10-01&lt;/from&gt;
        ///     &lt;to&gt;2010-10-31&lt;/to&gt;
        ///     &lt;/term&gt;
        /// </param>
        /// <returns>Volné kapacity</returns>
        public FreeCapacity GetFreeCapacity(string innerPostData = "")
        {
            return Get<FreeCapacity>("Booking.getFreeCapacity", innerPostData);
        }

        /// <summary>
        ///     Umí z previa vrátit všechny data.
        ///     Všechny public Functions v PrevioRepository se na data dotazují pomocí této Funkce
        /// </summary>
        /// <typeparam name="T">Na jakej typ se mají vrácená xml data serializovat</typeparam>
        /// <param name="method">Jaká funkce / respektivně jaké url se bude volat. Pro vrácení xml z previa</param>
        /// <param name="innerPostData">Data, která se budou posílat v requestu na previo</param>
        /// <returns>Naplněný objekt typu T. </returns>
        public T Get<T>(string method, string innerPostData = "")
        {
            if (Configuration == null)
            {
                throw new NullReferenceException("Configuration is null !! Must seting property configuration.");
            }

            return Deserializer.Deserialize<T>(ValidXmlBuilder.BuildValidXml(
                PrevioApiProvider.Get(BuildUrlToRequest(method), BuildPostData(innerPostData))
                                                   )
                );
        }

        #endregion

        /// <summary>
        ///     Sestaví xml , které bude posláno jako post data v requestu na Api Previa
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru nebo nastavení
        ///     například:
        ///     &lt;hotId&gt;2&lt;/hotId&gt;
        ///     &lt;term&gt;
        ///     &lt;from&gt;2010-10-01&lt;/from&gt;
        ///     &lt;to&gt;2010-10-31&lt;/to&gt;
        ///     &lt;/term&gt;
        /// </param>
        /// <returns>xml , které bude posláno jako post data v requestu na Api Previa</returns>
        private string BuildPostData(string innerPostData)
        {
            return string.Format(
                @"<?xml version=""1.0""?>
                                <request>
                                    <login>{0}</login>
                                    <password>{1}</password>
                                    {2}
                                </request>",
                Configuration.User, Configuration.Password, innerPostData);
        }


        /// <summary>
        ///     Sestaví adresu na kterou se provede Request
        ///     například: https://api.previo.cz/x1/hotel/get
        ///     U adresy na api zalezi na velikosti pismen Hotel/get spatne hotel/get dobre
        /// </summary>
        /// <param name="methodName">
        ///     Název metody, z názvu se odvodí přesná adresa na kterou se má poslat request
        ///     například Hotel.get
        /// </param>
        /// <returns>
        ///     adresu na kterou se má provést Request
        ///     například: https://api.previo.cz/x1/hotel/get
        /// </returns>
        private Uri BuildUrlToRequest(string methodName)
        {
            methodName = methodName.Substring(0, 1).ToLower() + methodName.Substring(1);
            return new Uri(Configuration.BaseUrl + methodName.Replace(".", "/"));
        }
    }
}