using System.Xml.Serialization;
using Previo.Api.Client.BLL;

namespace Previo.Api.Client
{
    /// <summary>
    /// </summary>
    [XmlType("FilterSearchItem")]
    public class FilterSearchItem : ISearchFilterItem
    {
        #region Properties
            
            public string Key { get; set; }
            public object Value { get; set; }
        
        #endregion

        #region Constructors

        public FilterSearchItem()
        {
            
        }

        public FilterSearchItem(string key,object value)
        {
            Key = key;
            Value = value;
        }

        #endregion

        #region Public Methods

        public string ToSnippetXmlOrNull()
        {
            if (string.IsNullOrEmpty(Key.Trim()) || string.IsNullOrEmpty(Value.ToString()))
                return null;
            return "<" + Key + ">" + Value + "</" + Key + ">";
        }

        #endregion

     
    }
}