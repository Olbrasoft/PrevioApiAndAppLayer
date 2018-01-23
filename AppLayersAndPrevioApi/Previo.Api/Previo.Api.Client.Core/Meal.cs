using System.Xml.Serialization;

namespace Previo.Api.Client
{
   [XmlType("meal")]
    public class Meal : BaseMeal
   {
      
       /// <summary>
       /// Název stravy
       /// </summary>
       [XmlElement("name")]
       public string Name;
       
   }
}
