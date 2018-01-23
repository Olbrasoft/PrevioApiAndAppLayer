using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Kolekce hotelů
    /// </summary>
    [XmlRoot("hotels")]
    public class Hotels : List<Hotel>
    {
        #region Properties

        /// <summary>
        ///     Počet hotelů, které by byly vráceny kdyby nebyl použit parametr limit
        ///     [1]
        /// </summary>
        [XmlElement("foundHotels")] public int FoundHotels;

        #endregion
    }
}