using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    /// </summary>
    [XmlRoot("filter")]
    public class FilterSeacrh : ISearchFilter
    {
        public FilterSeacrh()
        {
        }

        public FilterSeacrh(string name, object value)
        {
            Item = new FilterItem {Name = name, Value = value};
        }

        [XmlElement("in")]
        public FilterItem Item { get; set; }

        [XmlType("in")]
        public struct FilterItem
        {
            [XmlElement("field")]
            public string Name { get; set; }

         

            [XmlElement("value")]
            public object Value { get; set; }
        }

        //public public  Type { get; set; }

        //todo filtrovani poslan dotaz do pravia
        //public string ToSnippetXmlOrNull()
        //{
        //    if (Count == 0) return null;

        //    var dictNumerator = GetEnumerator();

        //    string result="";

        //    while (dictNumerator.MoveNext())
        //    {
        //       result += string.Format("<field>{0}</field><value>{1}</value>", dictNumerator.Current.Key,dictNumerator.Current.Value);
        //    }

        //    return string.Format("</filter>", result);

        //}
    }
}