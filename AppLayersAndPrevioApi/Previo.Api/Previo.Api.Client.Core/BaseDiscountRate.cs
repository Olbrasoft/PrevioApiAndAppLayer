using System.Xml.Serialization;

namespace Previo.Api.Client
{
    ///aaaa
    ///novej komentar
    /// <summary>
    /// Sleva může nabývat i záporných hodnot pokud je to příplatek: 
    /// +50% - sleva 50 %
    ///-50% - příplatek 50 %
    /// </summary>
    public abstract class BaseDiscountRate
    {
        /// <summary>
        ///Procentuální slev
        ///  Sleva může nabývat i záporných hodnot pokud je to příplatek: 
        /// +50% - sleva 50 %
        ///-50% - příplatek 50 %
        /// [1]	
        /// </summary>
        [XmlElement("discountRate")]
        public double DiscountRate { get; set; }
    }
}
