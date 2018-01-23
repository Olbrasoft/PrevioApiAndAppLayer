using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;
using Previo.Api.Client.BLL;
using Previo.Api.Client.DAL;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestHotelLocalMockRepository
    {
        private const string PathData = "..\\..\\MockData\\";
        protected IHotelService Service;
        protected IPrevioRepository Repository;

        public TestHotelLocalMockRepository()
        {
           

            Repository = new MockPrevioRepository();
            Service = new HotelService(Repository);
        }


        /// <summary>
        ///     Aby byl soubor k dispozici tak se musi nakopirovat do adresare ve kterem se spousti testy
        ///     http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.deploymentitemattribute(v=vs.80).aspx
        /// </summary>
        [TestMethod]
        [DeploymentItem(PathData + "TestNullFile.txt")]
        public void TestCopyMockXmlFileToRunningDirectory()
        {
            const string file = "TestNullFile.txt";
            var e = File.Exists(file);
            // Check if the created file exists in the deployment directory
            Assert.IsTrue(e);
        }


        /// <summary>
        ///     Vrati data z localniho Hotel.getRates.xm tudiz se muzeme spolehnout na hodnoty,
        ///     ktere maji nabyvat vlastnosti deserializovaneho objktu RatesContingentsClosures
        /// </summary>
        [TestMethod]
        [DeploymentItem(PathData + "Hotel.getRates.xml")]
        public void TestGetRates()
        {
            var rates = Service.GetRates(1, new Term {From = DateTime.Now, To = DateTime.Now.AddYears(1)});
            Assert.IsNotNull(rates.PrmId == 1);
            Assert.IsTrue(rates.WayAccountingPricesAccommodation ==
                          WayAccountingPricesAccommodation.PriceByNumberPeopleInRoom);

            var season = rates.Seasons.FirstOrDefault();
            Assert.IsTrue(season != null && season.PriId == 4758);
            Assert.IsTrue(season != null && season.From == new DateTime(2010, 5, 1));
            Assert.IsTrue(season != null && season.To == new DateTime(2010, 5, 8));

            var ratePlan = season.RatePlans.FirstOrDefault();

            //todo doresit jestli muze byt jinej jak string int ?
            //Do localniho xml umele pridano do ukazkoveho xm 
            // http://api.previo.cz/Hotel.getRates#sect.prmId
            // aby bylo videt ze se serializuje
            Assert.IsTrue(ratePlan.PrlIdAsString == "100");

            var objKind = ratePlan.ObjectKinds.FirstOrDefault();

            Assert.IsTrue(objKind != null && objKind.ObkId == 111136);

            var rate = objKind.Rates.FirstOrDefault();


            Assert.IsTrue(rate != null && rate.Occupancy == 1);



            Assert.IsTrue(rate != null && Math.Abs(rate.Price - 500) < 0.0001);


            var currency = rate.Currency;

            Assert.IsTrue(currency != null && currency.Code == "CZK");
            Assert.IsTrue(currency != null && currency.CurId == 1);

            var contingent = objKind.Contingent;

            Assert.IsTrue(contingent.Expiration == 3);

            Assert.IsTrue(contingent.Total == 1);

            Assert.IsTrue(contingent.ObjIds.FirstOrDefault() == 957091);


            var closed = objKind.Closed;

            Assert.IsTrue(closed.Total == 2);

            Assert.IsTrue(closed.ObjIds.FirstOrDefault() == 957096);

            var meal = ratePlan.Meals.FirstOrDefault();

            Assert.IsTrue(meal != null && meal.MeaId == 2);

            Assert.IsTrue(meal != null && meal.GuaId == 71941);

            var rateMeal = meal.Rates.FirstOrDefault();

// ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(rateMeal != null && rateMeal.Price == 50);
// ReSharper restore CompareOfFloatsByEqualityOperator
            Assert.IsTrue(rateMeal != null && rateMeal.Currency.CurId == 1);
            Assert.IsTrue(rateMeal != null && rateMeal.Currency.Code == "CZK");

            //     <minStay>2</minStay>
            //<maxStay>10</maxStay>
            Assert.IsTrue(ratePlan.MinStay == 2);

            Assert.IsTrue(ratePlan.MaxStay == 10);

            var range = ratePlan.Ranges.FirstOrDefault();

            //pridano do localniho xml     
            //  <arrival>thu</arrival>
            //  <departure>sun</departure>
            //</range>
            //<range>
            //  <arrival>fri</arrival>
            //  <departure>sun</departure>
            //</range>
            //oproti  http://api.previo.cz/Hotel.getRates
            // aby bylo videt ze se serializuje
            Assert.IsTrue(range.Arrival == DaysWeek.Thursday);
            Assert.IsTrue(range.Departure == DaysWeek.Sunday);


            var payment = ratePlan.Payments.FirstOrDefault();

            Assert.IsTrue(payment.CosIdSuccess == 6);

            Assert.IsTrue(payment.CosIdFailure == 2);

            //pridano do localniho xml     
            //<advance>
            //        <type>per</type>
            //        <value>50</value>
            //        <expiration>3</expiration>
            //    </advance>
            //oproti  http://api.previo.cz/Hotel.getRates
            // aby bylo videt ze se serializuje
            Assert.IsTrue(payment.Advance.Type == RequiredGuaranteeTypes.PercentAmount );

            Assert.IsTrue(Math.Abs(payment.Advance.Value - 50) < 0.001);
            Assert.IsTrue(payment.Advance.Expiration == 3);
        }
    }
}