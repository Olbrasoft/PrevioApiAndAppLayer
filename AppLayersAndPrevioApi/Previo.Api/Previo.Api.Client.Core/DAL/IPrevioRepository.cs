namespace Previo.Api.Client.DAL
{
    public interface IPrevioRepository //sasas
    {
        /// <summary>
        /// !!! Není otestováno nejsou práva, určeno pro hotely
        /// Vrací seznam vydaných dokladů k dané rezervaci
        /// </summary>
        /// <param name="innerPostData">
        /// &lt;hotId&gt;1&lt;/hotId&gt;
        ///&lt;comId&gt;12554&lt;/comId&gt;  
        /// </param>
        /// <returns>Seznam vydaných dokladů k dané rezervaci</returns>
        Documents GetDocuments(string innerPostData);

        /// <summary>
        /// Vrátí kategorie hostů v hotelu
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Kategorie hostů v hotelu</returns>
        GuestCategories GetGuestCategories(string innerPostData);

        /// <summary>
        ///Vrací recenze hostů na hotel 
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Recenze hostů </returns>
        GuestReviews GetGuestReviews(string innerPostData);

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
        Messages GetMessages(string innerPostData);

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
        ObjectKinds GetObjectKinds(string innerPostData);

        /// <summary>
        ///     Vrátí fotogalerie hotelu a pokojů
        ///     Jako titulní fotku hotelu použijte první fotku z první fotogalerie.
        ///     Název souboru (fotografie) se skládá z [timestamp.extension]
        ///     kde timestamp je čas nahrání souboru na server
        /// </summary>
        /// <param name="innerPostData"></param>
        /// <returns>Fotogalerie hotelu a pokojů</returns>
        Photogalleries GetPhotogalleries(string innerPostData);

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
        PriceActions GetPriceActions(string innerPostData);

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
        RatesContingentsClosures GetRates(string innerPostData);

        /// <summary>
        ///     Vrátí pokoje v hotelu
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml Id hotelu pro filtr výsledků
        ///     například:
        ///     &lt;hotId&gt;45698754&lt;/hotId&gt;
        /// </param>
        /// <returns>Pokoje v hotelu</returns>
        RoomKinds GetRoomKinds(string innerPostData);

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
        StayPackages GetStayPackages(string innerPostData);

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
        Reservations SearchReservations(string innerPostData);

        object AddAccountItem(string innerPostData);

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
        Collaboration SetCollaboration(string innerPostData);

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
        Packages GetPackages(string innerPostData);

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
        Hotel Get(string innerPostData);

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
        Hotels Search(string innerPostData = "");

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
        Bonuses SearchBonuses(string innerPostData = "");

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
        Changes GetChanges(string innerPostData = "");

        /// <summary>
        ///     Globální číselník měn
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru //todo nefunguje poslan dotaz do pravia
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník měn</returns>
        Currencies GetCurrencies(string innerPostData = "");

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
        GroupHotelProperties GetHotelProperties(string innerPostData = "");

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
        HotelTypes GetHotelTypes(string innerPostData = "");

        /// <summary>
        ///     Globální číselník jazyků
        /// </summary>
        /// <param name="innerPostData">
        ///     inner snippet xml pro omezení výběru //todo nefunguje poslan dotaz do pravia
        ///     jazyka například:
        ///     &lt;lanId&gt;1&lt;/lanId&gt;
        /// </param>
        /// <returns>Globální číselník jazyků</returns>
        Languages GetLanguages(string innerPostData = "");

        /// <summary>
        ///     Globální číselník turistických lokalit
        ///     Každý hotel může patřit do jedné turistické lokality.
        ///     Její id a název jsou součástí výstupu operace Get.
        /// </summary>
        /// <returns>Globální číselník turistických lokalit</returns>
        Localities GetLocalities();

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
        Meals GetMeals(string innerPostData = "");

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
        ObjectKindProperties GetObjectKindProperties(string innerPostData = "");

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
        ReservationStatuses GetReservationStatuses(string innerPostData = "");

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
        StayProcedures GetStayProcedures(string innerPostData = "");

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
        StayPrograms GetStayPrograms(string innerPostData = "");

        /// <summary>
        ///     Globální číselník krajů, okresů, obcí a PSČ
        /// </summary>
        /// <returns>Globální číselník krajů, okresů, obcí a PSČ</returns>
        Regions GetZips();

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
        FreeCapacity GetFreeCapacity(string innerPostData = "");
    }
}