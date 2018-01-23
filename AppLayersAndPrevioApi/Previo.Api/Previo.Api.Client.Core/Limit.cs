using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Omezení počtu vrácených záznamů
    ///     skip/top
    /// </summary>
    [XmlType("limit")]
    public class Limit : ILimit
    {
        #region Constructors

        public Limit()
        {
        }

        public Limit(int top, int skip = 0)
        {
            Top = top;
            Skip = skip;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     kolik záznamů se má přeskočit
        /// </summary>
        [XmlElement("offset")]
        public int Skip { get; set; }

        /// <summary>
        ///     Maximální počet vrácených záznamů
        /// </summary>
        [XmlElement("limit")]
        public int Top { get; set; }

        #endregion
    }
}