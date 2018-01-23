using System.Globalization;
using System.Xml.Serialization;
using Moon.Globalization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Jazyky webových stránek.
    ///     Hotel si vybírá podmnožinu z globálního číselníku jazyků.
    ///     http://api.previo.cz/System.getLanguages
    ///     [1..*]
    /// </summary>
    [XmlType("language")]
    public class Language
    {
        private CultureInfo _culture;

        /// <summary>
        /// Bezparametrický konstruktor slouží pro serializaci .
        /// Pro použití jako parametru se doporučuje parametrický konstruktor.
        /// </summary>
        public Language()
        {}


        /// <summary>
        /// Construktor inicializuje vlastnost Culture předaným parametrem
        /// </summary>
        /// <param name="cultureInfo">O jakou culturu/jazyk se jedná</param>
        public Language(CultureInfo cultureInfo)
        {
            Culture = cultureInfo;
        }


        [XmlIgnore]
        public CultureInfo Culture
        {
            set { _culture = value.ToNeutralCulture(); }
            get { return _culture; }
        }

        
        /// <summary>
        ///     Id jazyka
        /// Nepoužívat , pouze pro případ, že by jsme potřebovaly znát jaké id jazyka předastavuje v préviu
        /// Řiďte se vlastností  Culture
        /// </summary>
        [XmlElement("lanId")] public int? LanId;

        /// <summary>
        ///     Dvoupísmenný kód jazyka (ISO 639-1).
        ///     http://cs.wikipedia.org/wiki/Seznam_k%C3%B3d%C5%AF_ISO_639-1
        ///     [1]
        /// </summary>
        [XmlElement("code")]
        public string Code
        {
            set { Culture = new CultureInfo(value); }
            get { return Culture.Name; }
        }

        /// <summary>
        ///     Název jazyka
        ///     Vrací pouze ISystemService.GetLanguages
        ///     http://api.previo.cz/System.getLanguages
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}