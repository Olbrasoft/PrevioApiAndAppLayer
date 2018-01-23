using System.IO;
using System.Xml.Serialization;

namespace Moon.Xml.Serialization
{
    /// <summary>
    ///     Předanej string xml  deseralizuje na objekt požadovaného typu s naplněnými vlastnostmi hodnotami  z p ředaného xml
    /// </summary>
    public class GenericObjectXmlDeserializer : IGenericObjectXmlDeseserialize
    {
        /// <summary>
        ///     Předanej string xml  deseralizuje na objekt požadovaného typu s naplněnými vlastnostmi hodnotami  z p ředaného xml
        /// </summary>
        /// <typeparam name="T">Na jeký typ chceme deserializovat předané xml </typeparam>
        /// <param name="xml">Xml ze kterého se má deserializovat objekt</param>
        /// <returns> objekt požadovaného typu s naplněnými vlastnostmi hodnotami  z p ředaného xml</returns>
        public T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(new StringReader(xml));
        }
    }
}