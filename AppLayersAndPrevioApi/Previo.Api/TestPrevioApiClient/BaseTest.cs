using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client.BLL;
using Previo.Api.Client.DAL;

namespace TestPrevioApiClient
{
    /// <summary>
    ///     Bazova trida pro testovani Services
    ///     Resi declaraci a inicializaci Services
    /// </summary>
    [TestClass]
    public class BaseTest
    {
        protected const string PathData = "..\\..\\MockData\\";
      
        public BaseTest()
        {
            ActivateDependencyInjection.Activate();
             
            HotelService = ServiceLocator.Current.GetInstance<IHotelService>();
            HotelsService = ServiceLocator.Current.GetInstance<IHotelsService>();
            SystemService = ServiceLocator.Current.GetInstance<ISystemService>();
            BookingService = ServiceLocator.Current.GetInstance<IBookingService>();
            MockRepository = ServiceLocator.Current.GetInstance<IMockRepository>();
            Repository = ServiceLocator.Current.GetInstance<IPrevioRepository>();
        }

        protected IPrevioRepository Repository { get; set; }
        protected IHotelService HotelService { get; set; }
        protected IHotelsService HotelsService { get; set; }
        protected ISystemService SystemService { get; set; }
        protected IBookingService BookingService { get; set; }
        protected IMockRepository MockRepository { get; set; }

        [TestMethod]
        public void TestDependencyInjection()
        {
            Assert.IsNotNull(Repository);
            Assert.IsNotNull(HotelService);
            Assert.IsNotNull(HotelsService);
            Assert.IsNotNull(SystemService);
            Assert.IsNotNull(BookingService);
            Assert.IsNotNull(MockRepository);
        }
    }
}