using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoonApiTest
{
    [TestClass]
    public class TestStringProvider
    {

        [TestMethod]
        public void TestMethod1()
        {

           const string xmlPostData = @"<?xml version=""1.0""?><request><login>hotelubytovani</login><password>uby24hot39</password><hotId>2205</hotId></request>";
            var configuration = new Moon.Net.RequestConfig("POST", "application/xml",Encoding.UTF8);
            var api = new Moon.Api.ApiStringProvider(configuration);

            var xml = api.Get(new Uri("https://api.previo.cz/x1/hotel/get"), xmlPostData);

            Assert.IsTrue(xml.Length > 500);
        }
    }
}
