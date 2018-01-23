using System;
using System.IO;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client.DAL;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestPrevioApiXmlProvider
    {
        private const string PathData = "..\\..\\MockData\\";
        protected IPrevioApiXmlProvider Provider;

        public TestPrevioApiXmlProvider()
        {
            ActivateDependencyInjection.Activate();

            Provider = ServiceLocator.Current.GetInstance<IPrevioApiXmlProvider>();

        }


        [TestMethod]
        [DeploymentItem(PathData + "TestReturnXmlBookingGetFreeCapacity.xml")]
        public void TestReturnXmlBookingGetFreeCapacity()
        {
            Assert.IsTrue(System.IO.File.Exists("TestReturnXmlBookingGetFreeCapacity.xml"));



            var streamReader = new StreamReader("TestReturnXmlBookingGetFreeCapacity.xml");
             var xmlToEquals  = streamReader.ReadToEnd();
            streamReader.Close();
            xmlToEquals = xmlToEquals.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");
            var xmlfreeCapacity = Provider.Get(new Uri("https://api.previo.cz/x1/booking/getFreeCapacity"), 
               @"<?xml version=""1.0""?><request><login>hotelubytovani</login><password>uby24hot39</password><hotId>2</hotId><term><from>2010-10-30</from><to>2010-10-31</to></term></request>");
            xmlfreeCapacity = xmlfreeCapacity.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ","");

            Assert.IsTrue(xmlToEquals == xmlfreeCapacity);

        }
    }
}
