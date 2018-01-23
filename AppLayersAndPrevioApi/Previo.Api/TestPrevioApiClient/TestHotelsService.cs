using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;
using Previo.Api.Client.BLL;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestHotelsService
    {
        public TestHotelsService()
        {
            ActivateDependencyInjection.Activate();
            Service = ServiceLocator.Current.GetInstance<IHotelsService>();
        }

        public IHotelsService Service { get; set; }

        [TestMethod]
        public void TestDependencyInjection()
        {
            Assert.IsNotNull(Service);
        }


        [TestMethod]
        public void TesSearchHotels()
        {
            //var hotels = HotelService.SearchHotels(new FilterSeacrh {new FilterSearchItem("hoId", 1)});
            //Assert.IsTrue(hotels.Count == 1);
            //var firstOrDefault = hotels.FirstOrDefault();
            //Assert.IsTrue(firstOrDefault != null && firstOrDefault.HotId == 1);

            ////test limit a sort
            var hotels = Service.Search(new FilterSeacrh("hotId", 1));

            var firstOrDefault = hotels.FirstOrDefault();
            Assert.IsTrue( firstOrDefault.HotId == 1);
            //                                   new Order("name"), new Limit(10));

            //Assert.IsTrue(hotels.Count == 10);

            //foreach (var hotel in hotels)
            //{
            //    Assert.IsTrue(hotel.Collaboration);
            //}
        }
    }
}