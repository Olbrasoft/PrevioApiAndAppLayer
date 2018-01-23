using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestWebConfigPrevioApiConfiguration
    {
        [TestMethod]
        public void TestAppSetings()
        {
            var neco = ConfigurationManager.AppSettings.Get("key1");
            Assert.IsTrue(neco == "nejaka hodnota");
        }


        [TestMethod]
        public void TestSimpleExampleConnfiguration()
        {
            var config = (ExampleSimpleConfiguration) ConfigurationManager.GetSection("simpleExampleSeting");

            Assert.IsTrue(config.NejakaHodnodaTypu == "jojo type");
            Assert.IsTrue(config.NejakeJmeno == "ne ne jmeno ");
        }


        [TestMethod]
        public void TestExampleAdvanceConnfiguration()
        {
            var config = (ExampleAdvanceConfiguration) ConfigurationManager.GetSection("exampleAdvanceSeting");
            Assert.IsTrue(config.SpolecnaVlastnost == "hura");
        }


        [TestMethod]
        public void TestSimpleReadConnfiguration()
        {
            var config = (PrevioApiConfiguration) ConfigurationManager.GetSection("previoApiSeting");

            Assert.IsTrue(config.Credentials[0].Password == "TestPassword");
            Assert.IsTrue(config.Credentials[0].UserName == "TestUserName");
            Assert.IsTrue(config.DefaultCredential.Name == "hotelUbytovaniCom");
        }
    }
}