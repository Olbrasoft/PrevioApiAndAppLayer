using System.Xml.Serialization;

namespace Previo.Api.Client
{
       /// <summary>
       /// Hodnocení hotelu hostem, který byl v hotelu ubytován
       /// </summary>
    [XmlType("guestReview")]
    public class GuestReview
    {
        /// <summary>
        ///Termín ubytování
        /// [1]
        /// </summary>
        [XmlElement("term")]
        public Term Term;

        /// <summary>
        ///Id recenze
        /// [1]
        /// </summary>
        [XmlElement("gurId")]
        public int GurId;

        /// <summary>
        ///Bodové hodnocení personálu
        /// [1]
        /// </summary>
        [XmlElement("staff")]
        public int Staff;

        /// <summary>
        ///Bodové hodnocení čistoty
        /// [1]
        /// </summary>
        [XmlElement("clean")]
        public int Clean;

        /// <summary>
        ///Bodové hodnocení poměru cena/výkon
        /// [1]
        /// </summary>
        [XmlElement("ratio")]
        public int Ratio;

        /// <summary>
        ///Bodové hodnocení služeb
        /// [1]
        /// </summary>
        [XmlElement("service")]
        public int Service;

        /// <summary>
        ///Bodové hodnocení komfortu
        /// [1]
        /// </summary>
        [XmlElement("comfort")]
        public int Comfort;

        /// <summary>
        ///Záporné textové hodnocení
        /// [1]
        /// </summary>
        [XmlElement("textMinus")]
        public string TextMinus;

        /// <summary>
        ///Kladné textové hodnocení
        /// [1]
        /// </summary>
        [XmlElement("textPlus")]
        public string TextPlus;

        /// <summary>
        ///Vyjádření hotelu
        /// [1]
        /// </summary>
        [XmlElement("textHotel")]
        public string TextHotel;

        /// <summary>
        ///Jméno hosta
        ///[0..1]
        /// </summary>
        [XmlElement("guestName")]
        public string GuestName;

        /// <summary>
        ///Země, z které host pochází
        ///[0..1]
        /// </summary>
        [XmlElement("guestCountry")]
        public string GuestCountry;

        /// <summary>
        ///Město, z kterého host pochází
        ///[0..1]
        /// </summary>
        [XmlElement("guestTown")]
        public string GuestTown;

        /// <summary>
        ///
        ///[0..1]
        /// </summary>
        [XmlElement("guestGroup")]
        public string GuestGroup;


        /// <summary>
        ///
        ///[0..1]
        /// </summary>
        [XmlElement("<guestStay")]
        public string GuestStay;

        /// <summary>
        ///Schválení
        /// [1]
        /// </summary>
        [XmlElement("approval")]
        public string Approval;

         /// <summary>
        ///Způsob zobrazení
        /// [1]
        /// </summary>
        [XmlElement("viewFormat")]
        public string ViewFormat;

    }
}
