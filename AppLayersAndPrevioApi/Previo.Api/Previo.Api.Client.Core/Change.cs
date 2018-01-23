using System;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Určuje jestli a jaká změna nastala v datech hotelů od poslední aktualizace.
    /// </summary>
    [XmlType("change")]
    public class Change
    {
        /// <summary>
        /// Id hotelu
        /// </summary>
        [XmlElement("hotId")]
        public int HotId { get; set; }


        /// <summary>
        /// Typ změny
        /// </summary>
        [XmlElement("type")]
        public ChangeType Type { get; set; }
        

    }

}
