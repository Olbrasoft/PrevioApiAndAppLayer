using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Jak mají být vrácená data seřazená
    /// </summary>
    [XmlType("order")]
    public class Order : IOrder
    {
        #region Constructors
        
        //Bezparametrický konstruktor nutnej pro serializaci do Xml
        public Order()
        {}

        
        public Order(string[] ordersBy)
        {
            By = ordersBy;
        }

        public Order(string orderBy,bool desc = false)
        {
            By = new[] {orderBy};
        }

        #endregion

        #region Properties

        [XmlElement("by")]
        public string[] By { get; set; }

        /// <summary>
        /// Radit sestupne vzestupne
        /// </summary>
        [XmlElement("desc")]
        public bool Desc { get; set; }

        #endregion
    }
}