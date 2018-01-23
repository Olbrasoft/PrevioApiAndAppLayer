using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Stavy, kterých může nabývat spolupráce s hotelem
    /// </summary>
    [XmlType("status")]
    public enum StatusesCollaboration
    {
        /// <summary>
        ///     Chybí propojení
        /// </summary>
        [XmlEnum("none")] None = 0,

        /// <summary>
        ///     Čeká se na hotel
        /// </summary>
        [XmlEnum("waitingForHotel")] WaitingForHotel = 1,

        /// <summary>
        ///     Čeká se na partnera
        /// </summary>
        [XmlEnum("waitingForPartner")] WaitingForPartner = 2,

        /// <summary>
        ///     Aktivní spolupráce
        /// </summary>
        [XmlEnum("active")] Active = 3
    }
}