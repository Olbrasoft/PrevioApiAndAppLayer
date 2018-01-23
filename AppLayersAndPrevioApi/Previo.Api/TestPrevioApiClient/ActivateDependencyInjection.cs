using Microsoft.Practices.ServiceLocation;
using Ninject;
using NinjectAdapter;
using Previo.Api.Client.BLL;
using Previo.Api.Client.DAL;

namespace TestPrevioApiClient
{
    public static class ActivateDependencyInjection
    {
        private static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
          
            kernel.Bind<IMockRepository>().To<MockPrevioRepository>().InSingletonScope();
            kernel.Bind<IPrevioApiRequestConfiguration>().To<PreviApiRequestConfiguration>().InSingletonScope();
            kernel.Bind<IPrevioValidXmlBuilder>().To<PrevioValidXmlBuilder>().InSingletonScope();
            kernel.Bind<IPrevioXmlDeserializer>().To<PrevioXmlDeserializer>().InSingletonScope();
            kernel.Bind<IPrevioApiXmlProvider>().To<PrevioApiXmlProvider>().InSingletonScope();
            kernel.Bind<IConfigurationPrevioRepository>().To<ConfigurationPrevioRepositoryFromWebConfig>().InSingletonScope();
            kernel.Bind<IPrevioRepository>().To<PrevioRepository>().InSingletonScope();
            kernel.Bind<IHotelsService>().To<HotelsService>().InSingletonScope();
            kernel.Bind<IHotelService>().To<HotelService>().InSingletonScope();
            kernel.Bind<ISystemService>().To<SystemService>().InSingletonScope();
            kernel.Bind<IBookingService>().To<BookingService>().InSingletonScope();
            return kernel;
        }

        public static void Activate()
        {
            var ninject = CreateKernel();
            var locator = new NinjectServiceLocator(ninject);

            ServiceLocator.SetLocatorProvider(() => locator);
            
        }
    }
}