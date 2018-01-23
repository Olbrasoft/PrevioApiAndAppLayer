using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;
using System.Linq;
namespace TestPrevioApiClient
{
    [TestClass]
    public class TestBookingService : BaseTest
    {
        [TestMethod]
        [DeploymentItem(PathData + "TestReturnXmlBookingGetFreeCapacity.xml")]
        public void TestMethod1()
        {
            TestDependencyInjection();
            Assert.IsTrue(File.Exists("TestReturnXmlBookingGetFreeCapacity.xml"));
        }


        /// <summary>
        /// Testuje deserializaci proti localnim datum
        /// </summary>
        [TestMethod]
        [DeploymentItem(PathData + "TestReturnXmlBookingGetFreeCapacity.xml")]
        public void TesGetDeserializeFreeCapacity()
        {
            var freeCap = MockRepository.Get<FreeCapacity>("TestReturnXmlBookingGetFreeCapacity");
            var firstOrDefault
                = freeCap.ObjectKinds.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.ObkId==61);

            var orDefault = firstOrDefault.Rooms.FirstOrDefault();
            Assert.IsTrue(orDefault != null && orDefault.ObjId == 630);

            Assert.IsTrue(orDefault.Term.From == DateTime.Parse("2010-10-30T00:00:00+02:00"));
            Assert.IsTrue(orDefault.Term.To == DateTime.Parse("2010-10-31T00:00:00+02:00"));

        }
        

        [TestMethod]
        public void TesGetFreeCapacity()
        {
            var capacity = BookingService.GetFreeCapacity(1,
                                                          new Term
                                                              {
                                                                  From = DateTime.Now,
                                                                  To = DateTime.Now.AddYears(1)
                                                              }
                );

            Assert.IsTrue(capacity.ObjectKinds.Any());

        }
    }
}