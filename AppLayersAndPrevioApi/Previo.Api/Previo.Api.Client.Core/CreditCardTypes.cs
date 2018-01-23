using System.Collections.Generic;
using System.Xml.Serialization;

namespace Previo.Api.Client
{
    /// <summary>
    /// Kolekce kreditních karet
    /// </summary>
    [XmlType("creditCardTypes")]
    public class CreditCardTypes : List<CreditCardType>
    {   
     
    }
   
}
