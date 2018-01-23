using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Firma
    /// </summary>
    [XmlType("company")]
   public class Company
   {
       /// <summary>
       ///Jméno
       /// [1]
       /// </summary>
       [XmlElement("name")]
       public string Name { get; set; }
        
       /// <summary>
       ///Adresa
       /// [0..1]
       /// </summary>
       [XmlElement("address")]
       public string Address { get; set; }

       /// <summary>
       ///IC firmy
       /// [0..1]
       /// </summary>
       [XmlElement("ic")]
       public string Ic { get; set; }

       /// <summary>
       ///dic firmy
       /// [0..1]
       /// </summary>
       [XmlElement("dic")]
       public string Dic { get; set; }

       /// <summary>
       ///Jméno kontaktní osoby
       /// [0..1]
       /// </summary>
       [XmlElement("contactPersonName")]
       public string ContactPersonName { get; set; }

       /// <summary>
       ///Jméno kontaktní osoby
       /// [0..1]
       /// </summary>
       [XmlElement("contactPersonPhone")]
       public string ContactPersonPhone { get; set; }

       /// <summary>
       ///Email kontaktní osoby
       /// [0..1]
       /// </summary>
       [XmlElement("contactPersonEmail")]
       public string ContactPersonEmail { get; set; }

    }
}
