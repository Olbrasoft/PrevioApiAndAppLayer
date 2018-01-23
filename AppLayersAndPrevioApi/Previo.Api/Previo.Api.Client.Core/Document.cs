using System;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    [XmlRoot("document")]
    public class Document
    {
        /// <summary>
        ///     Identifikátor dokladu
        ///     [1]
        /// </summary>
        [XmlElement("invId")]
        public int InvId { get; set; }

        /// <summary>
        ///     Identifikátor rezervace
        ///     [1]
        /// </summary>
        [XmlElement("comId")]
        public int ComId { get; set; }

        /// <summary>
        ///     Název dokladu
        ///     [1]
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Číslo dokladu
        ///     [1]
        /// </summary>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        ///     Dodavatel
        ///     Hotel.getDocuments
        ///     [1]
        /// </summary>
        [XmlElement("supplier")]
        public string Supplier { get; set; }

        /// <summary>
        ///     Odběratel
        ///     Hotel.getDocuments
        ///     [0..1]
        /// </summary>
        [XmlElement("customer")]
        public string Customer { get; set; }

        /// <summary>
        ///     Variabilní symbol
        ///     [0..1]
        /// </summary>
        [XmlElement("variableSymbol")]
        public string VariableSymbol { get; set; }

        /// <summary>
        ///     Konstantní symbol
        ///     [0..1]
        /// </summary>
        [XmlElement("constantSymbol")]
        public string ConstantSymbol { get; set; }

        /// <summary>
        ///     Datum vystavení
        ///     [0..1]
        /// </summary>
        [XmlElement("dateIssued")]
        public DateTime DateIssued { get; set; }

        /// <summary>
        ///     Datum zůčtování
        ///     [0..1]
        /// </summary>
        [XmlElement("dateAccounting")]
        public DateTime DateAccounting { get; set; }

        /// <summary>
        ///     Datum zdanitelného plnění
        ///     [0..1]
        /// </summary>
        [XmlElement("dateTax")]
        public DateTime DateTax { get; set; }

        /// <summary>
        ///     Číslo účtu
        ///     [0..1]
        /// </summary>
        [XmlElement("accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        ///     Název účtu
        ///     [0..1]
        /// </summary>
        [XmlElement("accountName")]
        public string AccountName { get; set; }

        /// <summary>
        ///     Kód banky
        ///     [0..1]
        /// </summary>
        [XmlElement("bankCode")]
        public string BankCode { get; set; }

        /// <summary>
        ///     Název banky
        ///     [0..1]
        /// </summary>
        [XmlElement("bankName")]
        public string BankName { get; set; }

        /// <summary>
        ///     iban
        ///     [0..1]
        /// </summary>
        [XmlElement("iban")]
        public string Iban { get; set; }

        /// <summary>
        ///     swift
        ///     [0..1]
        /// </summary>
        [XmlElement("swift")]
        public string Swift { get; set; }

        /// <summary>
        ///     Identifikátor měny
        ///     http://api.previo.cz/System.getCurrencies
        ///     [0..1]
        /// </summary>
        [XmlElement("curId")]
        public int CurId { get; set; }

        /// <summary>
        ///     Cena bez DPH na dokladu
        ///     [0..1]
        /// </summary>
        [XmlElement("priceSumNoVat")]
        public float PriceSumNoVat { get; set; }

        /// <summary>
        ///     Celková cena na dokladu
        ///     [0..1]
        /// </summary>
        [XmlElement("priceSum")]
        public float PriceSum { get; set; }

        /// <summary>
        ///     Celkova suma daně na dokladu
        ///     [0..1]
        /// </summary>
        [XmlElement("vatSum")]
        public float VatSum { get; set; }
    }
}