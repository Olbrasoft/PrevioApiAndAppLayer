using System;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;
using Previo.Api.Client.BLL;
using Previo.Api.Client.DAL;
using Moon.Xml.Serialization;

namespace TestPrevioApiClient
{
    [TestClass]
    public class TestFilterSearchBonuses
    {
        public TestFilterSearchBonuses()
        {
            ActivateDependencyInjection.Activate();
            Repository = ServiceLocator.Current.GetInstance<IPrevioRepository>();
            HotelService = ServiceLocator.Current.GetInstance<IHotelsService>();
        }

        public IPrevioRepository Repository { get; set; }
        public IHotelsService HotelService { get; set; }

        
        [TestMethod]
        public void TestSearchBonuses()
        {
       
            var from = new DateTime(2013, 01, 05, 0, 0, 0);
            var to = new DateTime(2013, 01, 07, 23, 59, 59);
            var bonuses =
                HotelService.SearchBonuses(
                    new FilterSearchBonuses(from, to), new Order("hotId"), null);
            Assert.IsTrue(bonuses.Any());
           
            
            //vraci to rezervace se spatnym from poslan dotaz do previa
            //test jestli byly vráceny rezervace jen pro požadovanej datum

            foreach (var bonuse in bonuses)
            {
               
                //  Assert.IsTrue(bonuse.Term.From >= from && bonuse.Term.To <= to);
            }

            var comId = bonuses.FirstOrDefault().ComIds.FirstOrDefault();
            var hotId = bonuses.FirstOrDefault().HotId;

            bonuses = HotelService.SearchBonuses(new FilterSearchBonuses(comId), null, null);

            Assert.IsTrue(bonuses.Count == 1 && bonuses.FirstOrDefault().ComIds.FirstOrDefault() == comId);

            bonuses = HotelService.SearchBonuses(new FilterSearchBonuses(hotId, null), null, null);

            //Filtrování podle hotId
            foreach (var bonuse in bonuses)
            {
                Assert.IsTrue(bonuse.HotId == hotId);
            }

            //razeni vracenych provizi
            bonuses =
                HotelService.SearchBonuses(
                    new FilterSearchBonuses(from, to), new Order("bookdate"), null);

            Assert.IsTrue(hotId != bonuses.FirstOrDefault().HotId);

#pragma warning disable 219
            var tempBookDate = bonuses.FirstOrDefault().Bookdate.AddDays(-1);
#pragma warning restore 219

            foreach (var bonuse in bonuses)
            {
                //todo poslan dotaz do previa nejak to radi divne
                //  Assert.IsTrue(bonuse.Bookdate > tempBookDate);
                tempBookDate = bonuse.Bookdate;
            }


            //testování limitu
            bonuses =
                HotelService.SearchBonuses(
                    new FilterSearchBonuses(from, to), new Order("hotId"), new Limit(10));

            Assert.IsTrue(bonuses.Count == 10);

            hotId = bonuses[5].HotId;

            bonuses =
                HotelService.SearchBonuses(
                    new FilterSearchBonuses(from, to), new Order("hotId"), new Limit(7, 5));
            Assert.IsTrue(bonuses.Count == 7);
            Assert.IsTrue(bonuses.FirstOrDefault().HotId == hotId);
        }

        [TestMethod]
        public void TestSeralizeFilterSearchBonuses()
        {
            var bonuses = Repository.SearchBonuses("<filter><from>2013-01-01</from><to>2013-01-07</to></filter>");
            Assert.IsNotNull(bonuses);
            var realizedBonuses = bonuses.Where(p => p.Approval == Bonuses.Bonus.Approvals.Realized).ToList();
            Assert.IsTrue(realizedBonuses.Any());
        }

        [TestMethod]
        public void TestSmazat()
        {

          //  var result = Repository.Get<Hotels>("Hotels.search",@"<filter><in><field>hotId</field><value xmlns:q1=""http://www.w3.org/2001/XMLSchema"" p4:type=""q1:int"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">1</value></in></filter>");
            
            var a = new FilterSeacrh ("hotId", 1).ToSnippetXmlOrNull();

            //var t = new FilterSearchItem();

            //var filter = new FilterSeacrh
            //    {
            //        new FilterSearchItem {Key = "hotId", Value = 1},
            //        new FilterSearchItem {Key = "field", Value = "collaboration"},
            //        new FilterSearchItem {Key = "value", Value = "active"}
            //    };

            //var tt = filter.ToSnippetXmlOrNull();
        }
    }
}