using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     v jakém stavu se nachází rezervace (odbydleno zrušeno atd ...)
    /// </summary>
    [XmlType("status")]
    public class ReservationStatus
    {
        /// <summary>
        ///     Stav rezervace
        ///     [1]
        /// </summary>
        [XmlElement("statusId")]
        public int StatusId { get; set; }


        /// <summary>
        ///     Vypršení opce
        ///     [0..1]
        ///     Plní se při volání IHotelService.SearchReservations
        /// </summary>
        [XmlElement("optionExpiration")]
        public string OptionExpiration { get; set; }

        /// <summary>
        ///     Název stavu rezervace
        ///     Plní se při volání ISystemService.GetReservationStatuses
        ///     [1]
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Popis stavu rezervace
        ///     Plní se při volání ISystemService.GetReservationStatuses
        ///     [1]
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }


        //todo da se dodelat System.Drawing.Color 
        /// <summary>
        ///     Hexadecimální popis barvy, kterou Previo znázorňuje tento stav
        ///     Plní se při volání ISystemService.GetReservationStatuses
        ///     [1]
        /// </summary>
        [XmlElement("color")]
        public string ColorAsString { get; set; }
    }
}