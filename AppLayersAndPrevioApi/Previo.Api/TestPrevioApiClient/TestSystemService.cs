using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.Xml.Serialization;
using Previo.Api.Client;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestSystemService : BaseTest
    {
        [TestMethod]
        [DeploymentItem(PathData + "System.getObjectKindProperties.xml")]
        public void TestObjectKindPropertiesDeserializationFromLocalXml()
        {
            var properties = MockRepository.Get<ObjectKindProperties>("System.getObjectKindProperties");

            Assert.IsTrue(properties.Count > 10);

            var objectKindProperty = properties.FirstOrDefault();
            Assert.IsTrue(objectKindProperty != null && objectKindProperty.ProId == 3);
            var firstOrDefault = properties.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.Name == "Postýlka");

            var kindProperty = properties.FirstOrDefault();
            Assert.IsTrue(kindProperty != null && kindProperty.IconUrl.ToString() ==
                          new Uri("http://admin.previo.cz/images/share/propertyRoom/24x24/03.gif").ToString());
        }


        [TestMethod]
        public void TestGetObjectKindProperties()
        {
            var properties = SystemService.GetObjectKindProperties();
            Assert.IsTrue(properties.Any());

           
            properties = SystemService.GetObjectKindProperties(2);

            Assert.IsTrue(properties.Any());

            var objectKindProperty = properties.FirstOrDefault(p => p.ProId == 4);
            Assert.IsTrue(objectKindProperty != null && objectKindProperty.Name == "Phone No.");

        }


        [TestMethod]
        public void TestGetLocalities()
        {
            var localities = SystemService.GetLocalities();
            Assert.IsNotNull(localities);

            Assert.IsTrue(localities.Count > 10);

            var firstOrDefault = localities.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && (firstOrDefault.LctId != 0 && firstOrDefault.Name != ""));
        }

        [TestMethod]
        public void JakVypadaSerializaceIntNull()
        {
            var testClass = new TestNullClass();
            //testClass.Url = new Uri("http://admin.previo.cz/images/share/propertyHotel/31x31/03.gif")
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof (TestNullClass));
            var stringWriter = new StringWriter();

            serializer.Serialize(stringWriter,testClass);

            var xml = stringWriter.ToString();

            Assert.IsTrue(xml.Length > 0);

        }

        //[TestMethod]
        //public void TestBuildXmlSelectionTypeChangesXml()
        //{

        //    const string xml = "<changes><change>GetFreeCapacity</change><change>GetGuestReview</change><change>GetMessages</change></changes>";
        //    var changes = new []
        //        {
        //            ChangeType.GetFreeCapacity,
        //            ChangeType.GetGuestReview,
        //            ChangeType.GetMessages


        //        };

        //    Assert.IsTrue(xml == Previo.Api.Client.System.BuildXmlSelectionTypeChangesXml(changes));

        //}
        [TestMethod]
        public void TestSerializationChangeType()
        {
            const string xmlToEquals =
                "<changes><change>Get</change><change>GetFreeCapacity</change><change>GetGuestReview</change></changes>";
            var changes = new[] {ChangeType.Get, ChangeType.GetFreeCapacity, ChangeType.GetGuestReview};
            var xml = changes.ToSnippetXml("changes", "change");

            Assert.IsTrue(xmlToEquals == xml);
        }

        [TestMethod]
        public void TestGetChages()
        {
            var changes = SystemService.GetChages();
            Assert.IsTrue(changes.Any());

            var firstOrDefault = changes.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && !string.IsNullOrEmpty(firstOrDefault.Type.ToString().Trim()));

            var changesTypes = new[]
                {
                    ChangeType.GetFreeCapacity,
                    ChangeType.GetGuestReview,
                    ChangeType.GetMessages
                };

            changes = SystemService.GetChages(changesTypes);

            Assert.IsTrue(changes.Any());


            foreach (var change in changes)
            {
                Assert.IsTrue(change.Type == ChangeType.GetFreeCapacity || change.Type == ChangeType.GetGuestReview ||
                              change.Type == ChangeType.GetMessages);
            }

            changesTypes = new[]
                {
                    ChangeType.GetFreeCapacity
                };

            changes = SystemService.GetChages(changesTypes);

            foreach (var change in changes)
            {
                Assert.IsTrue(change.Type == ChangeType.GetFreeCapacity);
            }
        }

        [TestMethod]
        public void TestGetCurrencies()
        {
            var currencies = SystemService.GetCurrencies();
            Assert.IsTrue(currencies.DefaultCurId != 0);
            var firstOrDefault = currencies.AllCurrencies.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.CurId != 0);

            var currency = SystemService.GetCurrencies(2).AllCurrencies.FirstOrDefault(p => p.CurId == 7);
            Assert.IsTrue(currency != null && currency.Name == "Russian ruble");
        }

        [TestMethod]
        public void TestGetHotelTypes()
        {
            var hotelTypes = SystemService.GetHotelTypes();
            Assert.IsTrue(hotelTypes.Any());

            hotelTypes = SystemService.GetHotelTypes(2);
            Assert.IsTrue(hotelTypes.Any());

            var hotelType = hotelTypes.FirstOrDefault(p => p.HoyId == 10);

            Assert.IsTrue(hotelType != null && hotelType.Name == "Summer cottage");
        }


        [TestMethod]
        public void TestGetLanguages()
        {
            var languages = SystemService.GetLanguages();
            Assert.IsTrue(languages.Any());

            languages = SystemService.GetLanguages(2);
            Assert.IsTrue(languages.Any());

            var language = languages.FirstOrDefault(p => p.LanId == 7);

            Assert.IsTrue(language != null && language.Name == "Español");
        }

        [TestMethod]
        public void TestGetMeals()
        {
            var meals = SystemService.GetMeals();
            Assert.IsTrue(meals.Any());

            meals = SystemService.GetMeals(2);
            Assert.IsTrue(meals.Any());

            var meal = meals.FirstOrDefault(p => p.MeaId == 5);
            Assert.IsTrue(meal != null && meal.Name == "half-board");
        }

        [TestMethod]
        public void GetReservationStatuses()
        {
            var reservationStatuses = SystemService.GetReservationStatuses();
            Assert.IsTrue(reservationStatuses.Any());

            reservationStatuses = SystemService.GetReservationStatuses(6);
            Assert.IsTrue(reservationStatuses.Any());
            //todo at predavam, jakékoliv id jazyka vždy dostávám stejné texty poslan dotaz do previa 5.3.2013

            //  var reservation = reservationStatuses.FirstOrDefault();
        }

        [TestMethod]
        public void TestGetStayProcedures()
        {
            var stayProcedures = SystemService.GetStayProcedures();
            Assert.IsTrue(stayProcedures.Any());

            stayProcedures = SystemService.GetStayProcedures(2);
            Assert.IsTrue(stayProcedures.Any());

            var stayProcedure = stayProcedures.FirstOrDefault(p => p.SycId == 5);
            Assert.IsTrue(stayProcedure.Name == "Cupping");
        }

        [TestMethod]
        public void TestGetStayPrograms()
        {
            var stayPrograms = SystemService.GetStayPrograms();
            Assert.IsTrue(stayPrograms.Any());

            stayPrograms = SystemService.GetStayPrograms(2);
            Assert.IsTrue(stayPrograms.Any());

            var stayProgram = stayPrograms.FirstOrDefault(p => p.SyrId == 22);
            Assert.IsTrue(stayProgram.Name == "Summer stays");
        }

        [TestMethod]
        public void TestGetZips()
        {
            var regions = SystemService.GetZips();
            Assert.IsTrue(regions.Any());
            Assert.IsTrue(regions.FirstOrDefault().Counties.FirstOrDefault().Towns.Zips.Count() > 200);
        }


        /// <summary>
        /// Testuje deserializaci proti localnim datum
        /// </summary>
        [TestMethod]
        [DeploymentItem(PathData + "System.getHotelProperties.xml")]
        public void TesDeserializeHotelProperties()
        {
            var groupProperties = MockRepository.Get<GroupHotelProperties>("System.getHotelProperties");

            Assert.IsTrue(groupProperties.Any());

            var groupProperty = groupProperties.FirstOrDefault();
            
            Assert.IsTrue(groupProperty != null && groupProperty.HpkId == 1);
            
            Assert.IsTrue(groupProperty.Name == "Služby a vybavení");

            var property = groupProperty.Properties.FirstOrDefault();

            Assert.IsTrue(property != null && property.HopId == 3);
             
            Assert.IsTrue(property.Name == "Konferenční/společenská místnost" );


            Assert.IsTrue(property.IconUrl.ToString() == new Uri("http://admin.previo.cz/images/share/propertyHotel/31x31/03.gif").ToString());
            
            Assert.IsTrue(property.DistanceGet &&  property.CapacityGet ==false && property.HotelOrRoomGet && property.SupervisedGet  );
        }

        /// <summary>
        /// testuje stazeni Ciselniku Vlastnosti hotelu 
        /// </summary>
         [TestMethod]
        public void TesGetGroupHotelProperties()
        {
            var groupProperties = SystemService.GetHotelProperties();
            Assert.IsTrue(groupProperties.Any());
            var groupProperty = groupProperties.FirstOrDefault();

            Assert.IsTrue(groupProperty != null && groupProperty.HpkId == 1);

            Assert.IsTrue(groupProperty.Name == "Služby a vybavení");
            
             Assert.IsTrue(groupProperty.Properties.Any() );
            
             
            groupProperties = SystemService.GetHotelProperties(2);

            Assert.IsTrue(groupProperties.Any());
             
             groupProperty = groupProperties.FirstOrDefault();

             Assert.IsTrue(groupProperty != null && groupProperty.HpkId == 1);
   
             Assert.IsTrue(groupProperty != null && groupProperty.Name == "Services and facilities");
             
        }

    }
}