using System;

namespace Previo.Api.Client.BLL
{
    public interface IHotelService
    {
        /// <summary>
        ///     Vrátí podrobné informace o hotelu
        ///     Pokud chcete zjišťovat informace o více hotelech najednou, použijte operaci IHotelsService.Search, která má identický výstup.
        ///     Metoda reprezentuje http://api.previo.cz/Hotel.get
        /// </summary>
        /// <param name="hotId">Identifikátor hotelu</param>
        /// <returns> Podrobné informace o hotelu</returns>
        Hotel Get(int hotId);

        /// <summary>
        ///     Vrací seznam vydaných dokladů k dané rezervaci
        /// </summary>
        /// <param name="hotId">Identifikátor hotelu</param>
        /// <param name="comId">Identifikátor rezervace</param>
        /// <returns>Doklady k dané rezervaci </returns>
        Documents GetDocuments(int hotId, int comId);

        /// <summary>
        ///     Vrátí kategorie hostů v hotelu
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>kategorie hostů v hotelu</returns>
        GuestCategories GetGuestCategories(int hotId);

        /// <summary>
        ///     Vrací recenze hostů na hotel
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>Recenze hostů na hotel</returns>
        GuestReviews GetGuestReviews(int hotId);

        /// <summary>
        ///     Popisky a překlady
        ///     Všechny operace Previo API vrací řetězce (např. popis hotelu nebo název pokoje) ve výchozím jazyce serveru, tzn.
        ///     na api.previo.cz česky, na api.previo.sk slovensky atd.
        ///     Pomocí této operace můžete získat najednou všechny řetězce ve všech podporovaných jazycích (včetně výchozího).
        ///     http://api.previo.cz/Hotel.getMessages
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <param name="languages">
        ///     Omezení výběru jazyků.
        ///     Pokud vynecháno, vrátí řetězce ve všech podporovaných jazycích.
        /// </param>
        /// <returns>Popisky a překlady</returns>
        Messages GetMessages(int hotId, Languages languages = null);

        /// <summary>
        ///     Vrátí pokoje a další prostory v hotelu
        ///     Ve většině případů vás budou zajímat pouze pokoje.
        ///     Potom použijte operaci Hotel.getRoomKinds, která má stejné parametry a formát výstupu, ale vrací pouze pokoje (obtId = 1).
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>Vrátí pokoje a další prostory v hotelu</returns>
        ObjectKinds GetObjectKinds(int hotId);

        /// <summary>
        ///     Výstup této operace je identický jako výstup operace Hotel.getObjectKinds.
        ///     Jediný rozdíl je v tom, že jsou vráceny pouze druhy pokojů s obtId = 1 (pokoje).
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>Vrátí pokoje a další prostory v hotelu</returns>
        RoomKinds GetRoomKinds(int hotId);

        /// <summary>
        ///     Vraci balicky hotelu typu: sampanske na pokoji, bowling, masaz.
        ///     Tyto balicky si uzivatel objednava az ve druhem kroku rezervace.
        ///     Tato operace vrací všechna data, které lze nastavit v menu Nastavení - Balíčky.
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <param name="term">
        ///     Vrátí nastavení balíčků v daném rozsahu datumů.
        ///     Datumy uvádějte ve formátu W3 date. Např. 2010-04-29. http://www.w3.org/TR/NOTE-datetime
        /// </param>
        /// <param name="currencies">
        ///     Specifikuje, v jakých měnách budou vráceny ceny balíčků.
        ///     Vždy můžete vybírat pouze ty měny, které má hotel povoleny. http://api.previo.cz/Hotel.get
        ///     Pokud tento parametr vynecháte, operace vrátí ceny ve výchozí měně hotelu.
        /// </param>
        /// <returns>Balíčky hotelu typu: šampaňské na pokoji, bowling, masáž. </returns>
        Packages GetPackages(int hotId, ITerm term, Currencies currencies = null);

        /// <summary>
        ///     Vrátí všechny pobytové balíčky hotelu.
        ///     Tato operace vrací všechna potřebná data k prezentování pobytových balíčků
        ///     http://api.previo.cz/Hotel.getStayPackages
        ///     vraci balicky typu: romanticky vikend pro dva na horach.
        ///     Tyto balicky maji v rezervacnim formulari samostatnou zalozku
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>Všechny pobytové balíčky hotelu.</returns>
        StayPackages GetStayPackages(int hotId);

        /// <summary>
        ///     Hotely nabízejí určité slevy, odvíjející se od doby objednání pobytu.
        ///     Tato funkce vrací data potřebná k určení slevy.
        /// </summary>
        /// <param name="hotId">Identifikátor hotelu</param>
        /// <returns>Slevy které nabízí hotel</returns>
        PriceActions GetPriceActions(int hotId);

        /// <summary>
        ///     Vrátí fotogalerie hotelu a pokojů
        ///     Jako titulní fotku hotelu použijte první fotku z první fotogalerie.
        ///     Název souboru (fotografie) se skládá z [timestamp.extension],
        ///     kde timestamp je čas nahrání souboru na server
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <returns>Fotogalerie hotelu a pokojů</returns>
        Photogalleries GetPhotogalleries(int hotId);

        /// <summary>
        ///     Vrátí všechny rezervace a seznam aktuálně ubytovaných hostů pro daný hotel v požadovaném termínu,
        ///     případně konkrétní rezervace. http://api.previo.cz/Hotel.searchReservations
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <param name="term">
        ///     Vrátí rezervace v daném rozsahu datumů.
        ///     Při použití tohoto parametru, funkce vypíše pouze rezervace, které jsou viditelné na plachtě. (např: opce, potvrzeno atd..)
        /// </param>
        /// <param name="comIds">
        ///     Vrátí rezervace s danými identifikátory rezervací.
        ///     Pokud je hodnota zadána, funkce ignoruje zadané datum.
        ///     Funkce vypisuje i rezervace, které nemusí být vidět na plachtě. (např: waiting list atd..)
        /// </param>
        /// <returns>
        ///     rezervace a seznam aktuálně ubytovaných hostů pro daný hotel v požadovaném termínu,
        ///     případně konkrétní rezervace.
        /// </returns>
        Reservations SearchReservations(int hotId, ITerm term, int[] comIds = null);

        /// <summary>
        ///     Vrátí ceny, kontingenty, uzavírky, omezení a nastavení plateb http://api.previo.cz/Hotel.getRates
        ///     Tato operace vrací všechna data, které lze nastavit v menu Nastavení - Ceny.
        ///     Doporučujeme si proto nejříve toto nastavení vyzkoušet http://demoadmin.previo.cz/40/rates/
        ///     , ať lépe pochopíte strukturu dat.
        /// </summary>
        /// <param name="hotId"> 	Id hotelu</param>
        /// <param name="term">
        ///     Termín
        ///     Vrátí nastavení cen v daném rozsahu datumů. Snažíme se hotely donutit nastavit ceny alespoň na rok dopředu.
        /// </param>
        /// <param name="currencies">
        ///     Tímto parametrem můžete specifikovat, v jakých měnách budou vráceny ceny ubytování a stravy.
        ///     Vždy můžete vybírat pouze ty měny, které má hotel povoleny.  http://api.previo.cz/Hotel.get
        /// </param>
        /// <param name="prlIds">
        ///     Filtr cenových plánů
        ///     Nastavením tohoto parametru lze získat další cenové plány.
        ///     Operace vždy vrací základní cenový plán.  Pokud tento parametr vynecháte,
        ///     jste Previo Partner a hotel má pro vás definován zvláštní cenový plán, operace ho vrátí spolu se zákládním plánem.
        ///     todo nechat si to jeste vysvetlit od previa
        /// </param>
        /// <param name="obkIds">
        ///     Tímto parametrem lze vymezit, pro jaké druhy pokojů http://api.previo.cz/Hotel.getObjectKinds
        ///     vás zajímají ceny ubytování, kontingenty a uzavírky.
        ///     Pokud ho vynecháte, operace vrátí tyto pro informace pro všechny definované druhy pokojů.
        /// </param>
        /// <returns>Kntingenty, uzavírky, omezení a nastavení plateb.</returns>
        /// <exception cref="ArgumentNullException">term;term is required</exception>
        RatesContingentsClosures GetRates(
            int hotId, ITerm term, ICurrencies currencies = null, int[] prlIds = null, int[] obkIds = null
            );

        
        //todo dotaz do previa ohledne formatovani pozamky cestiny a prepnuti do stavu ceka se na hotel i pri snizeni provize
        /// <summary>
        ///     Nastaví podmínky spolupráce s hotelem
        ///     Spolupráce partnera a hotelu se řídí stavem a provizí. Aktuální podmínky spolupráce s hotelem zjistíte z výstupu operace Get.
        ///     Previo API vždy udržuje výchozí poměr provizí Previa a partnera. Stačí tedy zadat pouze jednu z provizí (TotalBonusRate, PartnerBonusRate nebo PrevioBonusRate)
        ///     a zbylé jsou dopočítány automaticky. Pokud jich je zadáno víc, vezme se první v pořadí total - partner - previo a zbylé hodnoty se zahodí.
        ///     Dopočítané hodnoty jsou součástí výstupu této operace.
        ///     Previo API chrání hotel, při zvýšení celkové provize se stav spolupráce automaticky přepne z active a WaitingForPartner na WaitingForHotel.
        ///     Automaticky přepnutý stav je součástí výstupu této operace.
        /// </summary>
        /// <param name="hotId">Id hotelu</param>
        /// <param name="collaboration">Podmínky spolupráce které se mají  pro hotel nastavit.
        /// Stačí  zadat pouze jednu z provizí (TotalBonusRate, PartnerBonusRate nebo PrevioBonusRate)
        /// Pokud jich je zadáno víc, vezme se první v pořadí total - partner - previo a zbylé hodnoty se zahodí.
        /// Změnímeli status z None nebo z WaitingForHotel na stav Active nebo WaitingForPartner je nastaven stejně status WaitingForHotel.
        /// </param>
        /// <param name="htmlText">
        /// Html Text poznámky, která se přidá do emailu, který odchází z Previa na hotel.
        /// Email odchází pouze v případě změny podmínek a pouze když není nastaven status None.
        /// Pokud je nastaven status none a jsou změněny podmínky provize, žádný email neodchází hotel se nic nedoví.
        /// Pokud se nemění provize ale změní se stav z None na WaitingForHotel  email odchází
        /// </param>
        /// <returns>Pdmínky spolupráce včetně dopočítaných nezadaných.</returns>
        Collaboration SetCollaboration(int hotId,ICollaboration collaboration, string htmlText);
    }
}