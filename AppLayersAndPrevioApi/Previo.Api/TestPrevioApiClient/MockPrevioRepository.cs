using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Previo.Api.Client;

namespace TestPrevioApiClient
{
    public class MockPrevioRepository : IMockRepository
    {      
        public T Get<T>(string method, string innerPostData = "")
        {
            var xmlFileName = method + ".xml";
            var streamReader = new StreamReader(xmlFileName);
            var xml = streamReader.ReadToEnd();
            var byteArray = Encoding.UTF8.GetBytes(xml);
            var stream = new MemoryStream(byteArray);
            var reader = new XmlTextReader(stream);
            
           var serializer = new XmlSerializer(typeof (T))  ;
            
            return (T) serializer.Deserialize(reader);
         
        }

        public Documents GetDocuments(string innerPostData)
        {
            return Get<Documents>("Hotel.getDocuments", innerPostData);
        }


        public GuestCategories GetGuestCategories(string innerPostData)
        {
            return Get<GuestCategories>("Hotel.getGuestCategories", innerPostData);
        }


        public GuestReviews GetGuestReviews(string innerPostData)
        {
            return Get<GuestReviews>("Hotel.getGuestReviews", innerPostData);
        }

        public Messages GetMessages(string innerPostData)
        {
            return Get<Messages>("Hotel.getMessages", innerPostData);
        }

        public ObjectKinds GetObjectKinds(string innerPostData)
        {
            return Get<ObjectKinds>("Hotel.getObjectKinds", innerPostData);
        }

        public Photogalleries GetPhotogalleries(string innerPostData)
        {
            return Get<Photogalleries>("Hotel.getPhotogalleries", innerPostData);
        }

        public PriceActions GetPriceActions(string innerPostData)
        {
            return Get<PriceActions>("Hotel.getPriceActions", innerPostData);
        }

        public RatesContingentsClosures GetRates(string innerPostData)
        {
            return Get<RatesContingentsClosures>("Hotel.getRates", innerPostData);
        }


        public RoomKinds GetRoomKinds(string innerPostData)
        {
            return Get<RoomKinds>("Hotel.getRoomKinds", innerPostData);
        }


        public StayPackages GetStayPackages(string innerPostData)
        {
            return Get<StayPackages>("Hotel.getStayPackages", innerPostData);
        }


        public Reservations SearchReservations(string innerPostData)
        {
            return Get<Reservations>("Hotel.searchReservations", innerPostData);
        }

        
        public object AddAccountItem(string innerPostData)
        {
            throw new NotImplementedException();
        }

       
        public Collaboration SetCollaboration(string innerPostData)
        {
            throw new NotImplementedException();
        }


        public Packages GetPackages(string innerPostData)
        {
            return Get<Packages>("Hotel.getPackages", innerPostData);
        }

        public Hotel Get(string innerPostData)
        {
            return Get<Hotel>("Hotel.get", innerPostData);
        }

        public Hotels Search(string innerPostData = "")
        {
            return Get<Hotels>("Hotels.search", innerPostData);
        }

        public Bonuses SearchBonuses(string innerPostData = "")
        {
            return Get<Bonuses>("Hotels.searchBonuses", innerPostData);
        }

        public Changes GetChanges(string innerPostData = "")
        {
            return Get<Changes>("System.getChanges", innerPostData);
        }


        public Currencies GetCurrencies(string innerPostData = "")
        {
            return Get<Currencies>("System.getCurrencies", innerPostData);
        }
        
     
        public GroupHotelProperties GetHotelProperties(string innerPostData = "")
        {
            return Get<GroupHotelProperties>("System.getHotelProperties", innerPostData);
        }

        public HotelTypes GetHotelTypes(string innerPostData = "")
        {
            return Get<HotelTypes>("System.getHotelTypes", innerPostData);
        }

        public Languages GetLanguages(string innerPostData = "")
        {
            return Get<Languages>("System.getLanguages", innerPostData);
        }

        public Localities GetLocalities()
        {
            return Get<Localities>("System.getLocalities");
        }

        public Meals GetMeals(string innerPostData = "")
        {
            return Get<Meals>("System.getMeals", innerPostData);
        }

        
        public ObjectKindProperties GetObjectKindProperties(string innerPostData = "")
        {
            throw new NotImplementedException();
        }

        public ReservationStatuses GetReservationStatuses(string innerPostData = "")
        {
            return Get<ReservationStatuses>("System.getReservationStatuses", innerPostData);
        }

        public StayProcedures GetStayProcedures(string innerPostData = "")
        {
            return Get<StayProcedures>("System.getStayProcedures", innerPostData);
        }

        public StayPrograms GetStayPrograms(string innerPostData = "")
        {
            return Get<StayPrograms>("System.getStayPrograms", innerPostData);
        }

        /// <summary>
        ///<![CDATA[ <name>Bob</name> ]]> 
        /// </summary>
        /// <returns><![CDATA[ <name>Bob</name> ]]> </returns>
        public Regions GetZips()
        {
            return Get<Regions>("System.getZips");
        }

        public FreeCapacity GetFreeCapacity(string innerPostData = "")
        {
            throw new NotImplementedException();
        }
    }
}