using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Informace ubytovaném hostu.
    /// </summary>
   [XmlType("guest")]
   public class Guest
   {
       
       /// <summary>
       ///Id hosta
       /// může v některých případech nabývat i hodnoty null. Proto se musí deserializovat jako string int null nelze deserializovat.
       ///Pokud má hotel v rezervaci 2 hosty, následně jednoho smaže a ponechá počet hostů v rezervaci 2 druhý host se může vracet s gueId NULL.
       /// </summary>
       [XmlElement("gueId")]
       public string StringGueId {
           get { return GueId.ToString(); }
           set
           {
               if (string.IsNullOrEmpty(value.Trim()))
               {
                   GueId = null;
               }
               else
               {
                   GueId = int.Parse(value);
               }
           }
       }

       /// <summary>
       /// Id hosta
       /// může v některých případech nabývat i hodnoty null. Proto se musí deserializovat jako string int null nelze deserializovat.
       ///Pokud má hotel v rezervaci 2 hosty, následně jednoho smaže a ponechá počet hostů v rezervaci 2 druhý host se může vracet s gueId NULL.
       /// </summary>
       public int? GueId { get; set; }


       /// <summary>
       ///Jméno hosta.
       /// [[0..1]	
       /// </summary>
       [XmlElement("name")]
       public string Name { get; set; }

       /// <summary>
       ///Telefonní číslo hosta.
       /// [[0..1]	
       /// </summary>
       [XmlElement("phone")]
       public string Phone { get; set; }

       /// <summary>
       ///Email hosta.
       /// [[0..1]	
       /// </summary>
       [XmlElement("email")]
       public string Email { get; set; }

       /// <summary>
       ///Adresa hosta.
       /// [[0..1]	
       /// </summary>
       [XmlElement("address")]
       public string Addressl { get; set; }

       /// <summary>
       /// ISO kód země původu návštěvníka 
       /// (přednastavena CZE)
       /// [[0..1]	
       /// </summary>
       [XmlElement("countryCode")]
       public string CountryCode { get; set; }

       /// <summary>
       /// Kategorie hostů
       /// [1]
       /// </summary>
       [XmlElement("guestCategory")]
       public GuestCategory GuestCategory { get; set; }
       
   }
}
