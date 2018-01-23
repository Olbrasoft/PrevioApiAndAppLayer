using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Typy požadované zálohy
    /// </summary>
    [XmlType("type")]
    public enum RequiredGuaranteeTypes
    {
        /// <summary>
        ///     Procenta z částky
        /// </summary>
        [XmlEnum("per")] PercentAmount = 0,

        /// <summary>
        ///     absolutní částka
        /// </summary>
        [XmlEnum("abs")] AbsoluteAmount = 1,

        /// <summary>
        ///     částka za počet nocí
        /// </summary>
        [XmlEnum("night")] AmountForNumberNights = 2,
    }
}