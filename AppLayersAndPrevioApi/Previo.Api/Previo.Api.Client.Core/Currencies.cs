using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Měny, kterými lze platit. Hotel si vybírá podmnožinu z globálního číselníku měn.
    ///     http://api.previo.cz/System.getCurrencies
    ///     [1]
    /// </summary>
    [XmlType("currencies")]
    public class Currencies : ICurrencies
    {
        /// <summary>
        ///     Id výchozí měny Previo API (na api.previo.cz = 1, na api.previo.sk = 2)
        ///     Vrací pouze System.GetCurrencies http://api.previo.cz/System.getCurrencies
        ///     [1]
        /// </summary>
        [XmlElement("defaultCurId")]
        public int DefaultCurId { get; set; }

        /// <summary>
        ///     Výchozí měna
        ///     [1]
        /// </summary>
        [XmlElement("defaultCurrency")]
        public Currency DefaultCurrency { get; set; }

        /// <summary>
        ///     Seznam všech akceptovaných měn
        ///     (včetně výchozí)
        ///     [1..*]
        /// </summary>
        [XmlElement("currency")]
        public Currency[] AllCurrencies { get; set; }
    }
}