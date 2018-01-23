using System.Xml.Serialization;

namespace Previo.Api.Client
{
    public struct Classification
    {
        /// <summary>
        ///Hvězdičky (textově). Např. "****" nebo "***+".
        /// [1]
        /// </summary>
        [XmlElement("stars")]
        public string Stars { get; set; }

        /// <summary>
        ///Pokud true tak bylo hodnocení schváleno oficiální autoritou (AHR)
        /// [1]
        /// </summary>
        [XmlElement("confirmed")]
        public bool Confirmed { get; set; }

    }
}
