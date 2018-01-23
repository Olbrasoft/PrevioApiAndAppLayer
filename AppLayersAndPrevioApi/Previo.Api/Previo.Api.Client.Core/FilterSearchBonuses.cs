using System;
using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Nastavení omezení výběru provizí pro IHotelsService.SearchBonuses
    ///     http://api.previo.cz/Hotels.searchBonuses
    /// </summary>
    [XmlType("filter")]
    public class FilterSearchBonuses : ISeacrhBonusesFilter
    {
        #region Constructors

        public FilterSearchBonuses()
        {
        }

        public FilterSearchBonuses(int[] comIds, int? hotelId = null, DateTime? from = null, DateTime? to = null)
        {
            ComIds = comIds;
            HotelId = hotelId;
            From = from;
            To = to;
        }

        public FilterSearchBonuses(DateTime? from = null, DateTime? to = null) : this(null, null, from, to)
        {
        }

        public FilterSearchBonuses(int comId) : this(new[] {comId})
        {
        }

        public FilterSearchBonuses(int hotId, DateTime? from = null, DateTime? to = null) : this(null, hotId, from, to)
        {
        }

        #endregion

        /// <summary>
        ///     Id hotelu
        /// </summary>
        [XmlElement("hotId")]
        public int? HotelId { get; set; }

        /// <summary>
        ///     Vyhledat provize od
        /// </summary>
        [XmlElement("from")]
        public DateTime? From { get; set; }

        /// <summary>
        ///     Vyhledat provize do
        /// </summary>
        [XmlElement("to")]
        public DateTime? To { get; set; }

        /// <summary>
        ///     identifikátory rezervací
        /// </summary>
        [XmlArray("comIds")]
        [XmlArrayItem("comId")]
        public int[] ComIds { get; set; }
    }
}