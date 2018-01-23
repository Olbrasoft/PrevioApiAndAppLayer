using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    ///     Vybavení pokojů
    /// </summary>
    [XmlRoot("objectKindProperties")]
    public class ObjectKindProperties : List<ObjectKindProperties.ObjectKindProperty>
    {
        /// <summary>
        /// Vybavení pokoje
        /// </summary>
        [XmlType("property")]
        public class ObjectKindProperty:BaseProperty
        {
            /// <summary>
            ///     Id vybavení
            /// </summary>
            [XmlElement("proId")]
            public int ProId { get; set; }
            
       
        }
    }
}