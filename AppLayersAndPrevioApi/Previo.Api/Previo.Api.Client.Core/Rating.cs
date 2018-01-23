using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Interní hodnocení hotelu. Element je přítomen pouze pokud je právě přihlášený uživatel Previo partner.
    /// [0..1]
    /// </summary>
    [XmlType("rating")]
    public class Rating
    {

        /// <summary>
        ///Rating hotelu podle výše provizního procenta, které dává konkrétnímu Previo partnerovi. Rozsah: -30 - +170 bodů.
        /// [1]
        /// </summary>
        [XmlElement("bonusPercent")]
        public double BonusPercent { get; set; }

        /// <summary>
        /// Rating hotelu podle konverzního poměru zaslaných poptávek na odbydlené rezervace. Rozsah: -50 - +50 bodů.
        ///  Nominálně počet odbydlených provizí / počet zaslaných poptávek od daného PP * 
        /// Při konverzi nad 30% dostane 0.5 bodu za každé procento. Pod 30% ztrácí body stejným tempem.
        ///  [1]
        /// </summary>
        [XmlElement("enquiryConversionRatio")]
        public double EnquiryConversionRatio { get; set; }

        /// <summary>
        /// Extra body, které dává konkrétnímu hotelu konkrétní Previo partner, aby ovlivnil své pořadí Rozsah: -1000 - +1000 bodů.
        ///  [1]
        /// </summary>
        [XmlElement("extraPodoubles")]
        public double ExtraPodoubles { get; set; }

        /// <summary>
        ///Rating hotelu podle počtu pokojonocí zpřístupněných formou kontingentu na následujících 50 dní
        ///  a podle zakoupené previo licence. Rozsah: 0-10 bodů.
        ///  [1]
        /// </summary>
        [XmlElement("canvasAvailability")]
        public double CanvasAvailability { get; set; }

        /// <summary>
        ///Rating hotelu podle toho jak rychle hradí faktury. Trestné body jsou za nejdéle neuhrazenou fakturu. 
        /// Rozsah: -nekonečno - 0 bodů.
        ///  [1]
        /// </summary>
        [XmlElement("paymentPractice")]
        public double PaymentPractice { get; set; }

        /// <summary>
        ///Body za hodnocení hostů. Závisí na průměrném hodnocení a počtu hodnocení. Rozsah: -35 - +15 bodů.
        ///  [1]
        /// </summary>
        [XmlElement("guestReviews")]
        public double GuestReviews { get; set; }

        /// <summary>
        ///  Rating hotelu podle toho jak má vyplněné ceníky na rok dopředu.
        ///  Vypočítává se ze souvislého počtu dní do budoucna, ve kterých jsou řádně vyplněny ceny (výchozí měna v základním cenovém plánu). 
        ///  Hranice 0 bodů je 90 dní do budoucna. Rozsah: -18 - 13.5 bodů.
        ///  [1]
        /// </summary>
        [XmlElement("priceDefinitions")]
        public double PriceDefinitions { get; set; }


        /// <summary>
        ///Součet všech bodů.
        ///  [1]
        /// </summary>
        [XmlElement("total")]
        public double Total { get; set; }
        
    }
}
