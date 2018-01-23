
namespace Previo.Api.Client
{
    /// <summary>
    /// Druh popisu
    /// </summary>
    public enum MessageType 
    {

        /// <summary>
        /// Název druhu pokoje
        /// </summary>
        NameTypeRoom = 1,
     
        /// <summary>
        /// Popis druhu pokoje
        /// </summary>
        DescriptionTypeRoom = 2,

        /// <summary>
        /// Krátký popis hotelu
        /// </summary>
        ShortHotelDescription = 3,
        
        /// <summary>
        /// Dlouhý popis hotelu
        /// </summary>
        LongHotelDescription =4,

        /// <summary>
        /// Popis pokojů
        /// </summary>
        RoomsDescription =5,

        /// <summary>
        /// Otevírací doba recepce
        /// </summary>
        ReceptionOpeningHours=6,

        /// <summary>
        /// Gastronomie
        /// </summary>
        Gastronomie=7,

        /// <summary>
        /// Popis okolí
        /// </summary>
        VicinityDescription=8,

        /// <summary>
        /// Dopravní dostupnost
        /// </summary>
        TransportAccessibility=9,

        /// <summary>
        /// Další informace
        /// </summary>
        MoreInformation=10,

        /// <summary>
        /// Speciální akce a nabídky
        /// </summary>
        SpecialEventsAndOffers =11,

        /// <summary>
        /// 	Název pokoje
        /// </summary>
        RoomName =12,
        
        /// <summary>
        /// Obchodní a storno podmínky
        /// </summary>
        BusinessAndCancelationConditions=13,

        /// <summary>
        /// Název kategorie hostů
        /// </summary>
        CategoryGuestsName = 14,

        /// <summary>
        /// Název pobytového balíčku
        /// </summary>
        AccommodationPackageName =19,

        /// <summary>
        /// Popis pobytového balíčku
        /// </summary>
        AccommodationPackageDescription = 20,

        /// <summary>
        /// Poznámka pobytového balíčku
        /// </summary>
        AccommodationPackageNote =21,

        /// <summary>
        /// Textový popis, co zahrnuje pobytový balíček
        /// </summary>
        AccommodationPackageIncludesDescription=22
 	
    }
}
