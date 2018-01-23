using System;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    public abstract class BaseFromTo
    {
        /// <summary>
        ///     Datum Od
        /// </summary>
        [XmlElement("from")]
        public DateTime From { get; set; }

        /// <summary>
        ///     Datum Do
        /// </summary>
        [XmlElement("to")]
        public DateTime To { get; set; }
    }
}