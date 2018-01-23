using System.Xml.Serialization;

namespace Previo.Api.Client
{

  
   
    ///super komantar 2
    ///super komentar
    /// <summary>
    /// Adresa hotelu
    /// http://api.previo.cz/Hotel.get
    /// </summary>
   public struct Address 
   {
       ///super komentar 3
        /// <summary>
        /// Id státu
        /// [1]
        /// </summary>
        [XmlElement("couId")]
        public int CouId { get; set; }

        /// <summary>
       /// Id kraje
       /// ISystemService.GetZips
       /// http://api.previo.cz/System.getZips
        /// [1]
       /// </summary>
       [XmlElement("regId")]
       public int RegId;

        /// <summary>
        /// Id okresu
       /// ISystemService.GetZips
        /// http://api.previo.cz/System.getZips
        /// [1]
        /// </summary>
       [XmlElement("cotId")]
       public int CotId { get; set; }

        /// <summary>
        /// Id obce (města)
       /// ISystemService.GetZips
       /// http://api.previo.cz/System.getZips
       /// [1]
        /// </summary>
       [XmlElement("towId")]
       public int TowId { get; set; }

        /// <summary>
       /// Id psč
       /// ISystemService.GetZips
       /// http://api.previo.cz/System.getZips
       /// [1]
       /// </summary>
       [XmlElement("zipId")]
       public int ZipId { get; set; }



        /// <summary>
        /// Jméno (identické s názvem hotelu o úroveň výše)
       /// [1]
        /// </summary>
       [XmlElement("name")]
       public string Name { get; set; }

        /// <summary>
        /// Ulice
        /// [1]
        /// </summary>
       [XmlElement("street")]
       public string Street { get; set; }

        /// <summary>
        /// Město
        /// [1]
        /// </summary>
       [XmlElement("city")]
       public string City { get; set; }

        /// <summary>
       /// PSČ
       /// [1]
        /// </summary>
       [XmlElement("zip")]
       public string Zip;
        
        /// <summary>
        /// Země
        /// [1]
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Všechna zjištěná telefonní čísla. Seřazeny jsou podle toho,
        ///  jak jsou vhodné pro prezentaci hostům (číslo pro rezervaci ubytování je první).
        /// [0..1]
        /// </summary>
       [XmlArray("phone")]
       [XmlArrayItem("number")]
       public string[] Phones { get; set; }

       /// <summary>
       /// Všechy zjištěné emailové adresy. Seřazeny jsou podle toho, 
       /// jak jsou vhodné pro prezentaci hostům (email pro rezervaci ubytování je první).
       /// [1..*]
       /// </summary>
       [XmlArray("mail")]
       [XmlArrayItem("address")]
       public string[] Mails { get; set; }

   }
}
