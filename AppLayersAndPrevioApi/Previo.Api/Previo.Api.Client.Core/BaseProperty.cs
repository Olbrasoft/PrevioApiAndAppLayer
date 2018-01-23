using System;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Společné vlastnosti  objektů představující vlastnosti Hotelu, pokojů ...
    /// </summary>
    public abstract class BaseProperty
    {
        /// <summary>
        ///     Nepoužívat pouze kůli deserializaci.
        ///     Použijte vlastnost IconUrl
        ///     Ikona vybavení
        /// </summary>
        [XmlElement("icon")] public PropertyIcon Icon;

        /// <summary>
        ///     Název vybavení
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }


        /// <summary>
        ///     Ikona vybavení
        ///     Veřejně přístupná url ikony
        /// </summary>
        public Uri IconUrl
        {
            get { return new Uri(Icon.Url); }
        }

        /// <summary>
        ///     pomocná kůli Deserializaci.
        ///     Pro pristup k vlastnosti url se doporucuje vlastnost  Uri Url
        /// </summary>
        [XmlType("icon")]
        public struct PropertyIcon
        {
            /// <summary>
            ///     Veřejně přístupná url ikony
            ///     Pro pristup k vlastnosti url se doporucuje vlastnost  Uri IconUrl
            /// </summary>
            [XmlElement("url")]
            public string Url { get; set; }
        }
    }
}