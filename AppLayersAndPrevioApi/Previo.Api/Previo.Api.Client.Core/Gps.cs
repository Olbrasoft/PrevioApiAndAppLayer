using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Gps souřadnice hotelu v decimálním formátu
    ///  (používají např. Google Maps).
    /// https://developers.google.com/maps/?hl=cs
    /// [0..1]
    /// </summary>
    public struct Gps
    {
        /// <summary>
        /// lat
        /// [1]
        /// </summary>
        [XmlElement("lat")]
        public double Lat { get; set; }

        /// <summary>
        /// lng
        /// [1]
        /// </summary>
        [XmlElement("lng")]
        public double Lng { get; set; }

    }
}
