using System;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Previo.Api.Client;

namespace TestPrevioApiClient
{
    /// <summary>
    ///     Testuje deserializaci objektů a naplnění vlastností ,z lokálních xml souborů.
    /// </summary>
    [TestClass]
    public class TestDeserializationLocalXml
    {
        private const string PathData = "..\\..\\MockData\\";

        public TestDeserializationLocalXml()
        {
            ActivateDependencyInjection.Activate();
            Repository = ServiceLocator.Current.GetInstance<IMockRepository>();
        }

        public IMockRepository Repository { get; set; }

        [TestMethod]
        [DeploymentItem(PathData + "Hotel.getRates.xml")]
        public void TestDependencyInjection()
        {
            Assert.IsNotNull(Repository);

            var rates = Repository.Get<RatesContingentsClosures>("Hotel.getRates");

            Assert.IsTrue(rates.Seasons.Any());
        }

        /// <summary>
        ///     Testuje spravnou deserializaci z localniho xml do Bonuses
        ///     Hotels.searchBonuses
        /// </summary>
        [TestMethod]
        [DeploymentItem(PathData + "Hotels.searchBonuses.xml")]
        public void TestDeserialzationBonuses()
        {
            var bonuses = Repository.Get<Bonuses>("Hotels.searchBonuses");
            var bonus = bonuses.FirstOrDefault();

            Assert.IsTrue(bonus.HotId == 1);
            Assert.IsTrue(bonus.Bookdate == DateTime.Parse("2010-01-06T17:07:33+01:00"));

            Assert.IsTrue(bonus.Term.From == DateTime.Parse("2010-01-05T00:00:00+01:00"));
            Assert.IsTrue(bonus.Term.To == DateTime.Parse("2010-01-10T00:00:00+01:00"));

            Assert.IsTrue(bonus.ComIds.FirstOrDefault() == 2618631);
            Assert.IsTrue(bonus.Voucher == "VO20070663");
            Assert.IsTrue(bonus.StatusId == 1);
            Assert.IsTrue(bonus.Approval == Bonuses.Bonus.Approvals.NotRealized);

            Assert.IsTrue(bonus.VatPayer);
// ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(bonus.Account.Price == 2800);
// ReSharper restore CompareOfFloatsByEqualityOperator

            Assert.IsTrue(bonus.Account.Currency.CurId == 1);
            Assert.IsTrue(bonus.Account.Currency.Code == "CZK");
// ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(bonus.Price == 0);
// ReSharper restore CompareOfFloatsByEqualityOperator

            bonus = bonuses[1];

// ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(bonus.Price == 2800);
// ReSharper restore CompareOfFloatsByEqualityOperator


            Assert.IsTrue(Math.Abs(bonus.PrevioBonusAmount - 100.8) < 0.0001);


            Assert.IsTrue(Math.Abs(bonus.TotalBonusAmount - 305.45) < 0.0001);


            Assert.IsTrue(Math.Abs(bonus.PartnerBonusAmount - 204.65) < 0.0001);


            Assert.IsTrue(bonus.InvoiceSent);

            Assert.IsTrue(bonus.InvoiceSentDate == new DateTime(2010, 02, 12));

            Assert.IsTrue(bonus.PartnerInvoicePaid);

            Assert.IsTrue(bonus.InvoicePaidDate == new DateTime(2010, 2, 16));

            Assert.IsTrue(bonus.PartnerInvoiceSent);
        }
    }
}