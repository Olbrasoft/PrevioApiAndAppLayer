using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Partnerské provize
    /// </summary>
    [XmlRoot("bonuses")]
    public class Bonuses : List<Bonuses.Bonus>
    {
        /// <summary>
        ///     Počet výsledků, které byly vráceny,
        ///     kdyby nebyl použit limit
        /// </summary>
        [XmlElement("foundBonuses")]
        public int FoundBonuses { get; set; }


        /// <summary>
        ///     Provize
        /// </summary>
        [XmlType("bonus")]
        public struct Bonus
        {
            /// <summary>
            ///     Stavy schválení
            /// </summary>
            [XmlType("approval")]
            public enum Approvals
            {
                /// <summary>
                ///     neodbydleno
                /// </summary>
                [XmlEnum("0")] NotRealized = 0,

                /// <summary>
                ///     odbydleno
                /// </summary>
                [XmlEnum("1")] Realized = 1,

                /// <summary>
                ///     odbydleno se změněnou cenou
                /// </summary>
                [XmlEnum("2")] RealizedPriceChange = 2,

                /// <summary>
                ///     neznámá odbydlenost
                /// </summary>
                [XmlEnum("3")] UnknownStatus = 3
            }

            /// <summary>
            ///     Datum vytvoření rezervace
            /// </summary>
            [XmlElement("hotId")]
            public int HotId { get; set; }

            /// <summary>
            ///     Datum vytvoření rezervace
            /// </summary>
            [XmlElement("bookdate")]
            public DateTime Bookdate { get; set; }

            /// <summary>
            ///     Termín rezervace
            /// </summary>
            [XmlElement("term")]
            public Term Term { get; set; }


            //poslan dotaz do previa
            /// <summary>
            ///     Id rezervací
            ///     více com_id je pokud je skupinová rezervace.
            ///     Pokud si host objedná např. tři různé pokoje na stejný termín každá rezervace pro každý pokoj má své vlastní com_id.
            ///     V případě objednání tří pokojů tedy vrací tři různá com_id.
            /// </summary>
            [XmlArray("comIds")]
            [XmlArrayItem("comId")] //Id rezervace [1..*] 
            public int[] ComIds { get; set; }

            /// <summary>
            ///     Číslo voucheru
            ///     [0..1]
            /// </summary>
            [XmlElement("voucher")]
            public string Voucher { get; set; }

            /// <summary>
            ///     Stav rezervace
            ///     http://api.previo.cz/System.getReservationStatuses
            /// </summary>
            [XmlElement("cosId")]
            public int StatusId { get; set; }

            /// <summary>
            ///     Důvod změny.
            ///     Poznámka proč host nepřijel, nebo je jiná cena.
            ///     [0..1]
            /// </summary>
            [XmlElement("note")]
            public string Note { get; set; }

            /// <summary>
            ///     Stav schválení
            /// </summary>
            [XmlElement("approval")]
            public Approvals Approval { get; set; }

            /// <summary>
            ///     Hotel je plátce DPH (true|false)
            /// </summary>
            [XmlElement("vatPayer")]
            public bool VatPayer { get; set; }

            /// <summary>
            ///     Hotelový účet
            /// </summary>
            [XmlElement("account")]
            public Rate Account { get; set; }

            /// <summary>
            ///     Cena pro výpočet provize
            /// </summary>
            [XmlElement("price")]
            public float Price { get; set; }

            /// <summary>
            ///     Výše provize Previo
            /// </summary>
            [XmlElement("previoBonusAmount")]
            public float PrevioBonusAmount { get; set; }

            /// <summary>
            ///     Výše provize partner
            /// </summary>
            [XmlElement("partnerBonusAmount")]
            public float PartnerBonusAmount { get; set; }

            /// <summary>
            ///     Celková výše provize
            /// </summary>
            [XmlElement("totalBonusAmount")]
            public float TotalBonusAmount { get; set; }

            /// <summary>
            ///     Byla provize fakturována
            /// </summary>
            [XmlElement("invoiceSent")]
            public bool InvoiceSent { get; set; }

            /// <summary>
            ///     Datum kdy byla provize fakturována
            /// </summary>
            [XmlElement("invoiceSentDate")]
            public DateTime InvoiceSentDate { get; set; }

            /// <summary>
            ///     Číslo faktury (řetězec, např. "FV20100547")
            /// </summary>
            [XmlElement("invoiceNumber")]
            public string InvoiceNumber { get; set; }

            /// <summary>
            ///     Byla přijata platba za fakturu
            /// </summary>
            [XmlElement("invoicePaid")]
            public bool InvoicePaid { get; set; }

            /// <summary>
            ///     Datum kdy byla přijata platba za fakturu
            /// </summary>
            [XmlElement("invoicePaidDate")]
            public DateTime InvoicePaidDate { get; set; }

            /// <summary>
            ///     Byla provize fakturována partnerem
            /// </summary>
            [XmlElement("partnerInvoiceSent")]
            public bool PartnerInvoiceSent { get; set; }

            /// <summary>
            ///     Byla partnerovi uhrazena platba za fakturu
            /// </summary>
            [XmlElement("partnerInvoicePaid")]
            public bool PartnerInvoicePaid { get; set; }
        }
    }
}