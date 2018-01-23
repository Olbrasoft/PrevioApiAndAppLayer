using System.Xml.Serialization;

namespace Previo.Api.Client
{
   
     /// <summary>
     /// Typy změn v datech hotelu .
     /// System.GetChanges2
     /// Názvy v podstatě znamenají co máme zavolat aby jsme měli aktualní data o hotelech
     /// </summary>
    [XmlType("type")]
    public enum ChangeType
    {
        /// <summary>
        /// Z historického hlediska (časem přestane být podporován)
        /// </summary>
        [XmlEnum("other")]
        Other,
        /// <summary>
        /// Hotel.Get
        /// </summary>
        [XmlEnum("get")]
        Get,
        /// <summary>
        /// Hotel.GuestCategories
        /// </summary>
        [XmlEnum("getGuestCategories")]
        GetGuestCategories,
       
        /// <summary>
        ///Hotel.GetMessages
        /// </summary>
        [XmlEnum("getMessages")]
        GetMessages,

        /// <summary>
        /// Hotel.GetObjectKinds
        /// </summary>
        [XmlEnum("getObjectKinds")]
        GetObjectKinds,
        /// <summary>
        /// Hotel.GetPackages
        /// </summary>
        [XmlEnum("getPackages")]
	    GetPackages,
        /// <summary>
        /// Hotel.GetPhotogalleries
        /// </summary>
        [XmlEnum("getPhotogalleries")]
        GetPhotogalleries,
       
        /// <summary>
        /// Hotel.GetRates
        /// </summary>
        [XmlEnum("getRates")]
        GetRates,
       
        /// <summary>
        /// Hotel.GetRoomKinds
        /// </summary>
        [XmlEnum("getRoomKinds")]
        GetRoomKinds,
        
        /// <summary>
        ///  Booking.GetFreeCapacity
        /// </summary>
        [XmlEnum("getFreeCapacity")]
        GetFreeCapacity,
        
        /// <summary>
        /// Hotels.SearchBonuses
        /// </summary>
        [XmlEnum("getBonuses")]
        SearchBonuses,
        
        /// <summary>
        /// Hotel.GetGuestReview
        /// </summary>
        [XmlEnum("getGuestReview")]
        GetGuestReview,
     }
}
