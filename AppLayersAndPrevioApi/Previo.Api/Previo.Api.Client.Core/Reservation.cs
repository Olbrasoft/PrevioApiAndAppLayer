using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Reprezentuje jednu rezervaci
    /// </summary>
    [XmlType("reservation")]
    public class Reservation
    {
        /// <summary>
        ///     Id rezervace.
        ///     [1]
        /// </summary>
        [XmlElement("comId")]
        public int ComId { get; set; }

        /// <summary>
        ///     Identifikátor případné skupinové rezervace
        ///     [1]
        /// </summary>
        [XmlElement("resId")]
        public int ResId { get; set; }

        /// <summary>
        ///     Číslo voucheru (string)
        ///     [1]
        /// </summary>
        [XmlElement("voucher")]
        public string Voucher { get; set; }


        /// <summary>
        ///     Termín rezervace.
        ///     [1]
        /// </summary>
        [XmlElement("term")]
        public Term Term { get; set; }


        /// <summary>
        ///     Stav rezervace
        ///     [1]
        /// </summary>
        [XmlElement("status")]
        public ReservationStatus Status { get; set; }

        /// <summary>
        ///     Celková cena
        ///     [1]
        /// </summary>
        [XmlElement("price")]
        public float Price { get; set; }

        /// <summary>
        ///     Měna
        ///     [1]
        /// </summary>
        [XmlElement("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        ///     Hosté, jenž patří do rezervace.
        ///     [0..*]
        /// </summary>
        [XmlElement("guest")]
        public Guest[] Guests { get; set; }

        /// <summary>
        ///     Firma
        ///     [0..1]
        /// </summary>
        [XmlElement("company")]
        public Company Company { get; set; }

        /// <summary>
        ///     Pokoj, na který se tato rezervace vztahuje.
        ///     [1]
        /// </summary>
        [XmlElement("object")]
        public Room Object { get; set; }

        /// <summary>
        ///     Druh pokoje, na který se tato rezervace vztahuje.
        ///     [1]
        /// </summary>
        [XmlElement("objectKind")]
        public ObjectKind ObjectKind { get; set; }
    }
}