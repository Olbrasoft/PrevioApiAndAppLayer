using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.Xml.Serialization;
using Previo.Api.Client;

namespace TestPrevioApiClient
{
    /// <summary>
    /// xdccc
    /// </summary>
    [TestClass]
    public class TestHotelService : BaseTest
    {
        [TestMethod]
        public void TestGet()
        {
           
            var hotel = HotelService.Get(2);
            Assert.IsNotNull(hotel);

            Assert.IsTrue(hotel.Address.Name != "");

            Assert.IsTrue(hotel.Address.Mails.FirstOrDefault() != "");

            Assert.IsTrue(hotel.Address.Phones.FirstOrDefault() != "");

            Assert.IsTrue(hotel.Owner.Name != "");

            Assert.IsTrue(hotel.Owner.Mails.FirstOrDefault() != "");

            Assert.IsTrue(hotel.Owner.Phones.FirstOrDefault() != "");

            Assert.IsNotNull(hotel.VatPayer);

            Assert.IsNotNull(hotel.Collaboration);

            // ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(hotel.Collaboration.PartnerBonusRate != 0);
            // ReSharper restore CompareOfFloatsByEqualityOperator

            Assert.IsTrue(!string.IsNullOrEmpty(hotel.Url) && hotel.Url != "");

            Assert.IsNotNull(hotel.License);

            Assert.IsTrue(!string.IsNullOrEmpty(hotel.License.Name) && hotel.License.Name != "");

            Assert.IsNotNull(hotel.Locality);

            Assert.IsTrue(!string.IsNullOrEmpty(hotel.Locality.Name) && hotel.Locality.Name.Trim() != "");

            Assert.IsNotNull(hotel.Gps);
            // ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(hotel.Gps.Lat != 0);
            // ReSharper restore CompareOfFloatsByEqualityOperator


            Assert.IsNotNull(hotel.AccommodationTax);

            // ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(hotel.AccommodationTax.Price != 0);
            // ReSharper restore CompareOfFloatsByEqualityOperator

            Assert.IsNotNull(hotel.RecreationTax);

            // ReSharper disable CompareOfFloatsByEqualityOperator
            Assert.IsTrue(hotel.RecreationTax.Price != 0);
            // ReSharper restore CompareOfFloatsByEqualityOperator

            Assert.IsNotNull(hotel.Classification);

            Assert.IsTrue(!string.IsNullOrEmpty(hotel.Classification.Stars.Trim()));

            Assert.IsNotNull(hotel.Rating);

            Assert.IsNotNull(hotel.Rating.BonusPercent);

            Assert.IsNotNull(hotel.Properties);

            Assert.IsTrue(hotel.Properties.Any());

            var firstOrDefault = hotel.Properties.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.HopId > 0);


            var orDefault = hotel.Languages.FirstOrDefault();
            Assert.IsTrue(orDefault != null && orDefault.LanId > 0);


            Assert.IsTrue(hotel.Currencies.DefaultCurrency.CurId > 0);

            var currency = hotel.Currencies.AllCurrencies.FirstOrDefault();

            Assert.IsTrue(currency != null && currency.CurId > 0);

            Assert.IsTrue(!string.IsNullOrEmpty(hotel.Descriptions.LongDescription.Trim()));

            var @default = hotel.Conditions.FirstOrDefault();
            Assert.IsTrue(@default != null && !string.IsNullOrEmpty(@default.Trim()));
        }


        [TestMethod]
        public void TestGetDocuments()
        {
            //var documents = Hotel.GetDocuments(5251, 114827252);

            //Assert.IsTrue(messages.Any());
        }


        [TestMethod]
        public void TestGetMessagesAllMessages()
        {
            var messages = HotelService.GetMessages(1);
            Assert.IsTrue(messages.Any());

            var message = messages.FirstOrDefault(p => p.MessageId == 7);
            Assert.IsTrue(message != null && message.MessageType == MessageType.Gastronomie);
        }


        [TestMethod]
        public void TestGuestCategories()
        {
            var categories = HotelService.GetGuestCategories(1);
            Assert.IsTrue(categories.Default != 0);
            var firstOrDefault = categories.Categories.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.GuaId != 0);
        }


        [TestMethod]
        public void TestGetGuestReviews()
        {
            var guestReviews = HotelService.GetGuestReviews(506);
            var firstOrDefault = guestReviews.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.GurId != 0);
        }

        [TestMethod]
        public void TestGetMessagesDistrictLanguageCs()
        {
            var messages = HotelService.GetMessages(1,
                                                    new Languages {new Language(new CultureInfo("cs-CZ"))}
                );

            Assert.IsTrue(messages.Any());

#pragma warning disable 168
            foreach (var message in messages.Where(message => message.Language.LanId != 1))
#pragma warning restore 168
            {
                Assert.Fail("Byly vráceny v jiném jak českém jazyce");
            }
        }

        [TestMethod]
        public void TestGetObjectKinds()
        {
            var objKinds = HotelService.GetObjectKinds(1);
            Assert.IsTrue(objKinds.Any());
        }

        [TestMethod]
        public void TestGetPackages()
        {
            var packages = HotelService.GetPackages(1,
                                                    new Term
                                                        {
                                                            From = new DateTime(2001, 1, 1),
                                                            To = new DateTime(2015, 1, 1)
                                                        });
            Assert.IsTrue(packages.Any());

            var firstOrDefault = packages.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.HotId != 0);
        }


        [TestMethod]
        public void TestGetPhotogalleries()
        {
            var photogalleries = HotelService.GetPhotogalleries(2002);


            var firstOrDefault = photogalleries.FirstOrDefault();

            var orDefault = firstOrDefault.Photos.FirstOrDefault();
            Assert.IsTrue(!string.IsNullOrEmpty(orDefault.Url.Trim()));
        }


        [TestMethod]
        public void TestGetPackagesUnit()
        {
            var packages = HotelService.GetPackages(1,
                                                    new Term
                                                        {
                                                            From = new DateTime(2001, 1, 1),
                                                            To = new DateTime(2015, 1, 1)
                                                        });
            Assert.IsTrue(packages.Any());

            var firstOrDefault = packages.FirstOrDefault();


            // ReSharper disable PossibleNullReferenceException
            Assert.IsNotNull(firstOrDefault.Unit);
            Assert.IsTrue(firstOrDefault.Unit.PcuId != 0);
            // ReSharper restore PossibleNullReferenceException
        }


        [TestMethod]
        public void TestGetPriceActions()
        {
            var pricesActions = HotelService.GetPriceActions(3);
            Assert.IsNotNull(pricesActions);
        }

        [TestMethod]
        public void TestGetRoomKinds()
        {
            var rooms = HotelService.GetRoomKinds(1);
            Assert.IsNotNull(rooms);
        }


        [TestMethod]
        public void TestGetPackagesDistrictCurrency()
        {
            var curencies = new Currencies {AllCurrencies = new[] {new Currency {Code = "EUR", CurId = 2}}};

            var packages = HotelService.GetPackages(1,
                                                    new Term
                                                        {
                                                            From = new DateTime(2001, 1, 1),
                                                            To = new DateTime(2015, 1, 1)
                                                        }, curencies);

            Assert.IsTrue(packages.Any());
        }


        [TestMethod]
        public void TestGetPackagesExceptionDefaultCurrency()
        {
            var curencies = new Currencies
                {
                    DefaultCurrency = new Currency {Code = "CZK"},
                    AllCurrencies =
                        new[] {new Currency {CurId = 1, Code = "CZK"}, new Currency {Code = "EUR", CurId = 2}}
                };

            try
            {
                if (HotelService != null)
                    HotelService.GetPackages(1,
                                             new Term
                                                 {
                                                     From = new DateTime(2001, 1, 1),
                                                     To = new DateTime(2015, 1, 1)
                                                 }, curencies);

                Assert.Fail("Tohle nemelo projit curencies obsahuje defaultni culturu");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof (ArgumentException));
            }
        }


        [TestMethod]
        public void TestSearchReservations()
        {
            var reservations = HotelService.SearchReservations
                (1, new Term {From = new DateTime(2000, 1, 1), To = new DateTime(2015, 1, 1)});

            Assert.IsTrue(reservations.Any());

            var firstOrDefault = reservations.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.ComId != 0);

            var orDefault = reservations.FirstOrDefault();
            Assert.IsTrue(orDefault != null && !string.IsNullOrEmpty(orDefault.ObjectKind.Name.Trim()));

            reservations = HotelService.SearchReservations
                (1, new Term {From = new DateTime(2000, 1, 1), To = new DateTime(2015, 1, 1)}, new[] {orDefault.ComId});

            var reservation = reservations.FirstOrDefault();
            Assert.IsTrue(reservation != null && (reservations.Count == 1 && reservation.ComId == orDefault.ComId));
        }

        [TestMethod]
        public void TestGetStayPackages()
        {
            var stayPackages = HotelService.GetStayPackages(1);

            Assert.IsTrue(stayPackages.Any());

            var firstOrDefault = stayPackages.FirstOrDefault();
            Assert.IsTrue(firstOrDefault != null && firstOrDefault.StyId != 0);

            Assert.IsTrue(firstOrDefault.UnitId == 1 || firstOrDefault.UnitId == 2);
        }


        [TestMethod]
        public void TestGetRates()
        {
            var rates = HotelService.GetRates(1, new Term {From = DateTime.Now, To = DateTime.Now.AddYears(1)});

            var firstOrDefault = rates.Seasons.FirstOrDefault();
            if (firstOrDefault != null)
            {
                var objectKind = firstOrDefault.RatePlans.FirstOrDefault().ObjectKinds.FirstOrDefault();
                Assert.IsTrue(
                    objectKind != null && (firstOrDefault != null && objectKind.ObkId != 0));
            }


            //todo testy na omezeni PrlIdAsString nenasel jsem vhodnej hotel
            //string prlIdToCompare = null;

            //foreach (var season in rates.Seasons)
            //{
            //    var ratePlan = season.RatePlans.FirstOrDefault(p => p.PrlIdAsString != null);

            //    if (ratePlan.PrlIdAsString != null)
            //        prlIdToCompare = ratePlan.PrlIdAsString;

            //}

            //rates = Hotel.GetRates(1, new Term() { From = DateTime.Now, To = DateTime.Now.AddYears(1) }, null, new[] { int.Parse(prlIdToCompare) });

            //foreach (var season in rates.Seasons)
            //{
            //    foreach (var ratePlan in season.RatePlans)
            //    {
            //        Assert.IsTrue(ratePlan.PrlIdAsString == prlIdToCompare);
            //    }

            //}           

            #region Testovani Omezeni vracenych dat podle obkIdT

            var obkIdToEqual = 0;
            var orDefault = rates.Seasons.FirstOrDefault();
            if (orDefault != null)
            {
                var objectKind = orDefault.RatePlans.FirstOrDefault().ObjectKinds.FirstOrDefault();
                if (objectKind != null)
                {
                    obkIdToEqual =
                        objectKind.ObkId;
                }
            }


            rates = HotelService.GetRates(1, new Term {From = DateTime.Now, To = DateTime.Now.AddYears(1)}, null, null,
                                          new[] {obkIdToEqual});

            foreach (
                var objectKind in
                    from season in rates.Seasons
                    from ratePlan in season.RatePlans
                    from objectKind in ratePlan.ObjectKinds
                    select objectKind)
            {
                Assert.IsTrue(objectKind.ObkId == obkIdToEqual);
            }

            #endregion
        }

        /// <summary>
        ///     Testuje jak se serializuje WelcomeEmailAddText do xml
        /// </summary>
        [TestMethod]
        public void TestSerializaceObjektuTypuWelcomeEmailAddText()
        {
            const string xmlToEquals =
                "<info><mail><noteHtml>Nějaký html text tohle bude třeba tučně &lt;b&gt;ěščřžýáíé&lt;/b&gt;</noteHtml></mail></info>";
            var welcomeText = new WelcomeEmailAddText("Nějaký html text tohle bude třeba tučně <b>ěščřžýáíé</b>");

            var xml = welcomeText.ToSnippetXmlOrNull();

            Assert.IsTrue(xmlToEquals == xml);
        }

        /// <summary>
        ///     Testuje jestli se správně vyserializuje objekt typ Collaboration do xml
        /// </summary>
        [TestMethod]
        public void TestSerializaceObjektuCollaboration()
        {
            const string xmlToEquals =
                "<collaboration><partnerBonusRate>0</partnerBonusRate><previoBonusRate>0</previoBonusRate><totalBonusRate>20.5</totalBonusRate><status>active</status></collaboration>";
            var collaboration = new Collaboration(StatusesCollaboration.Active, 20.5);
            var xml = collaboration.ToSnippetXmlOrNull();
            Assert.IsTrue(xmlToEquals == xml);
        }


        //todo dotaz do previa ohledne formatovani pozamky cestiny a prepnuti do stavu ceka se na hotel i pri snizeni provize
        [TestMethod]
        public void TestSetCollaboration()
        {
           var collaboration = new Collaboration(StatusesCollaboration.Active,20);

           var resultCollaboration = HotelService.SetCollaboration(1, collaboration, @"<a href=""http://previo.cz "">odkaz na previo bez cestiny</a>" + Moon.Web.HttpUtility.HtmlEncode("ěščřžýáíé",Moon.Web.EncodeOptions.FullEncode));

          Assert.IsTrue(resultCollaboration.Status == StatusesCollaboration.WaitingForHotel && Math.Abs(collaboration.TotalBonusRate - 20) < 0.001  ); 
        }
    }
}