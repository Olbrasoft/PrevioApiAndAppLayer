using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///Měna
    /// </summary>
    [XmlType("currency ")]
    public class Currency 
    {
        /// <summary>
        ///Id měny
        /// http://api.previo.cz/System.getCurrencies
        /// </summary>
        [XmlElement("curId")]
        public int CurId { get; set; }

        /// <summary>
        ///Kód měny  ISystemService.GetCurrencies
        /// http://api.previo.cz/System.getCurrencies
        /// Třípísmenný kód měny (ISO 4217). 
        /// http://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// Název jazyka
        /// Vrací pouze ISystemService.GetCurrencies
        ///  http://api.previo.cz/System.getCurrencies
        /// [1]
        /// </summary>
        [XmlElement("name")]
        public string Name{ get; set; }
       
    }
}
