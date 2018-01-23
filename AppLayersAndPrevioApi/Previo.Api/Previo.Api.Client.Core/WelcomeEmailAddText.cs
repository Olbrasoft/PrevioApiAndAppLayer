using System.Xml.Serialization;
using Moon.Web;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Vlastní poznámka do automaticky rozesílaného emailu. Text není nijak filtrován, můžete použít libovolné HTML značky.
    ///     Dbejte přitom zvýšené opatrnosti, neplatné HTML může rozhodit celý email.
    /// </summary>
    [XmlRoot("info")]
    public class WelcomeEmailAddText : IWelcomeEmailAddText
    {
        /// <summary>
        ///     Vlastní poznámka do automaticky rozesílaného emailu. Text není nijak filtrován, můžete použít libovolné HTML značky.
        ///     Dbejte přitom zvýšené opatrnosti, neplatné HTML může rozhodit celý email.
        /// </summary>
        /// <param name="htmlText">Html Text poznámky, která se přidá do emailu, který odchází z Previa po nastavení IHotelService.SetCollaboration </param>
        public WelcomeEmailAddText(string htmlText)
        {
            Mail = new WelcomMail(htmlText);
        }

        /// <summary>
        ///     Pro serializaci do xml je potřeba bezparamtrický konstruktor.
        /// </summary>
        public WelcomeEmailAddText()
        {}

        ///// <summary>
        /////     Pouze obálka kůli serializaci
        /////     příklad jak má vypadat serializavané xml
        /////     &lt;info&gt;
        /////     &lt;mail&gt;
        /////     &lt;noteHtml&gt;Nějak&#253; &lt;b&gt;html&lt;/b&gt; Text&lt;/noteHtml&gt;
        /////     &lt;/mail&gt;
        /////     &lt;/info&gt;
        ///// </summary>
        [XmlElement("mail")]
        public WelcomMail Mail { get; set; }


        /// <summary>
        ///     Pouze obálka kůli serializaci
        ///     příklad jak má vypadat serializavané xml
        ///     &lt;info&gt;
        ///     &lt;mail&gt;
        ///     &lt;noteHtml&gt;Nějak&#253; &lt;b&gt;html&lt;/b&gt; Text&lt;/noteHtml&gt;
        ///     &lt;/mail&gt;
        ///     &lt;/info&gt;
        /// </summary>
        [XmlType("mail")]
        public class WelcomMail
        {
            private string _htmlText;

            /// <summary>
            ///     Kuli serializaci do xml je potreba bezparamtrický konstruktor
            /// </summary>
            public WelcomMail()
            {}

            /// <summary>
            ///     Vlastní poznámka do automaticky rozesílaného emailu. Text není nijak filtrován, můžete použít libovolné HTML značky.
            ///     Dbejte přitom zvýšené opatrnosti, neplatné HTML může rozhodit celý email.
            /// </summary>
            /// <param name="htmlText">Html Text poznámky, která se přidá do emailu, který odchází z Previa po nastavení IHotelService.SetCollaboration </param>
            public WelcomMail(string htmlText)
            {
                HtmlText = htmlText;
            }

            /// <summary>
            ///     Html Text poznámky, která se přidá do emailu, který odchází z Previa po nastavení IHotelService.SetCollaboration
            /// </summary>
            [XmlElement("noteHtml")]
            public string HtmlText {
                set { _htmlText = value; }
                get { return _htmlText; }
                }
        }
    }
}