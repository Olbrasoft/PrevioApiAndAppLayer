using System;
using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Termín (například termín ubytování)
    /// </summary>
    [XmlType("term")]
    public class Term : BaseFromTo, ITerm
    {
        public Term()
        {}

        /// <summary>
        /// Parametrický konstruktor se používá například při vytváření 
        /// instance třídy , například pro filtrování dat IBookingService.GetFreeCapacity
        /// Filtruje se tak že stačí aby alespoň From or To vyhovělo a data jsou vrácena
        ///  </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected Term(DateTime from, DateTime to)
        {
            
            From = from;
            To = to;
        }
    }
}