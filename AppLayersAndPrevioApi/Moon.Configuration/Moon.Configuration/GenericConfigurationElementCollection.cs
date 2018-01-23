using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Moon.Configuration
{
    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T>
        where T : ConfigurationElement, new()
    {
        private readonly List<T> _elements = new List<T>();

        public new IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
        

        /// <summary>
        /// Gets or sets the <see cref="ConfigurationElement"/> at the specified index.
        /// </summary>
        /// <value></value>
        public T this[int index]
        {
            get { return BaseGet(index) as T; }
            set
            {
                if (BaseGet(index) != null)
                { BaseRemoveAt(index); }
                BaseAdd(index, value);
            }
        }


        /// <summary>
        /// One ConfigurationElement by Key
        /// </summary>
        /// <param name="key">Key userName</param>
        /// <returns>One  Credential </returns>
        public new T this[string key]
        {
            get { return BaseGet(key) as T; }
        }


        protected override ConfigurationElement CreateNewElement()
        {
            var newElement = new T();
            _elements.Add(newElement);
            return newElement;
        }
        


        protected override object GetElementKey(ConfigurationElement element)
        {
            foreach (var propertyInfo in from propertyInfo in element.GetType().GetProperties()
                                         let attributes = propertyInfo.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), false) 
                                         from attribute in attributes where ((ConfigurationPropertyAttribute)attribute).IsKey select propertyInfo)
            {
                return propertyInfo.GetValue(element);
            }

            throw new KeyNotFoundException("Can not finde Key for " + element);
        }
    }
}