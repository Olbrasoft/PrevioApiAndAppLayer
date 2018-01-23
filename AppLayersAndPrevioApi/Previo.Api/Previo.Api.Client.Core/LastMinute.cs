using System.Xml.Serialization;

namespace Previo.Api.Client
{
    public class LastMinute : BaseDiscountRate
    {
        /// <summary>
        ///     Identifikátor slevy
        ///     [1]
        /// </summary>
        [XmlElement("plmId")]
        public int PlmId { get; set; }

        /// <summary>
        ///     Minimální počet dní před vytvořením rezervace pro uplatnění slevy
        ///     [1]
        /// </summary>
        [XmlElement("maxNumOfHoursBeforeArrival")]
        public int MaxNumOfHoursBeforeArrival { get; set; }
    }
}