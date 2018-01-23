using System;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Základní třída umí získavat z previa údaje týkajících se hotelů.
    /// Kromě toho sama má vlastnosti a vrací typ hotel s naplněnými vlastnostmi
    /// pomocí metody Get
    /// </summary>
    [XmlType("hotel")]
    public struct Hotel 
    {
        #region Public Properties

        /// <summary>
        ///     Id hotelu
        /// </summary>
        [XmlElement("hotId")]
        public int HotId { get; set; }


        /// <summary>
        ///     Id typu zařízení (penzion, chalupa atd...)
        /// </summary>
        [XmlElement("hoyId")]
        public int HoyId { get; set; }

        /// <summary>
        ///     Název hotelu
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Adresa hotelu
        ///     [1]
        /// </summary>
        [XmlElement("address")]
        public Address Address { get; set; }

        /// <summary>
        ///     Adresa majite (identická struktura jako u  Address
        ///     [1]
        /// </summary>
        [XmlElement("owner")]
        public Address Owner { get; set; }

        /// <summary>
        ///     Plátce Dph
        ///     [1]
        /// </summary>
        [XmlElement("vatPayer")]
        public bool VatPayer { get; set; }

        /// <summary>
        ///     Podmínky spolupráce hotelu s Previo partnerem.
        ///     Element chybí pokud přihlášený uživatel není Previo partner.
        ///     http://api.previo.cz/Hotel.setCollaboration
        ///     [0..1]
        /// </summary>
        [XmlElement("collaboration")]
        public Collaboration Collaboration { get; set; }

        /// <summary>
        ///     Url adresa webových stránek hotelu
        ///     [0..1]
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        ///     Licence systému Previo
        ///     http://api.previo.cz/Hotel.get#sect.license
        ///     [1]
        /// </summary>
        [XmlElement("license")]
        public License License { get; set; }

        /// <summary>
        ///     Čas nájezdu (check-in)
        ///     [1]
        /// </summary>
        [XmlElement("arrival")]
        public DateTime Arrival { get; set; }


        /// <summary>
        ///     Čas odjezdu (check-out)
        ///     [1]
        /// </summary>
        [XmlElement("departure")]
        public DateTime Departure { get; set; }


        /// <summary>
        ///     Hotel má k dispozici lůžek
        ///     [0..1]
        /// </summary>
        [XmlElement("beds")]
        public int Beds { get; set; }

        /// <summary>
        ///     Hotel má k dispozici přistýlek
        /// </summary>
        [XmlElement("extraBeds")]
        public int ExtraBeds { get; set; }

        /// <summary>
        ///     Turistická lokalita
        ///     http://api.previo.cz/System.getLocalities
        /// </summary>
        [XmlElement("locality")]
        public Locality Locality { get; set; }

        /// <summary>
        ///     Gps souřadnice hotelu v decimálním formátu (používají např. Google Maps).
        ///     https://developers.google.com/maps/?hl=cs
        ///     [0..1]
        /// </summary>
        [XmlElement("gps")]
        public Gps Gps { get; set; }

        /// <summary>
        ///     Ubytovací poplatek
        /// </summary>
        [XmlElement("accommodationTax")]
        public Tax AccommodationTax { get; set; }

        /// <summary>
        ///     Rekreační poplatek
        /// </summary>
        [XmlElement("recreationTax")]
        public Tax RecreationTax { get; set; }

        /// <summary>
        ///     Hvězdičkové hodnocení hotelu
        /// </summary>
        [XmlElement("classification")]
        public Classification Classification { get; set; }

        /// <summary>
        ///     Interní hodnocení hotelu. Element je přítomen pouze pokud je právě přihlášený uživatel Previo partner.
        ///     0..1]
        /// </summary>
        [XmlElement("rating")]
        public Rating Rating { get; set; }

        /// <summary>
        ///     Vybavení. Každý hotel si vybírá podmnožinu z globálního číselníku vybavení.
        ///     Jestli jde u vybavení zadat vzdálenost (elementy onSite a distance),
        ///     zjistíte z globálního číselníku (element priceGet). Analogicky je to i u dalších možností (cena, kapacita).
        ///     http://api.previo.cz/System.getHotelProperties
        ///     [0..*]
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public HotelProperty[] Properties { get; set; }


        /// <summary>
        ///     Jazyky webových stránek. Hotel si vybírá podmnožinu z globálního číselníku jazyků.
        ///     http://api.previo.cz/System.getLanguages
        ///     [1..*]
        /// </summary>
        [XmlArray("languages")]
        [XmlArrayItem("language")]
        public Language[] Languages { get; set; }

        /// <summary>
        ///     Měny, kterými lze platit. Hotel si vybírá podmnožinu z globálního číselníku měn.
        ///     http://api.previo.cz/System.getCurrencies
        /// </summary>
        [XmlElement("currencies")]
        public Currencies Currencies { get; set; }


        /// <summary>
        ///     Akceptované typy kreditních karet
        /// </summary>
        [XmlArray("creditCardTypes")]
        [XmlArrayItem("creditCardType")]
        public CreditCardType[] CreditCardTypes { get; set; }


        /// <summary>
        ///     Popisky ve výchozím jazyce Previo API. Jejich překlady získáte pomocí Hotel.getMessages.
        ///     http://api.previo.cz/Hotel.getMessages
        /// </summary>
        [XmlElement("descriptions")]
        public Descriptions Descriptions { get; set; }


        /// <summary>
        ///     Obchodní a storno podmínky
        ///     Plné znění obchodních a storno podmínek (může obsahovat HTML značky)
        /// </summary>
        [XmlArray("conditions")]
        [XmlArrayItem("text")] //[0...1]
        public string[] Conditions { get; set; }

        #endregion


    }
}