using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Moon.Xml.Serialization
{
    public static class ExToSnippetXml
    {
        /// <summary>
        ///     Serializuje object implementujici rozhrani IToSnippetXml
        ///     Do jednoducheho xml  bez jmeneho prostoru a declarace
        /// </summary>
        /// <param name="o">Object implementující rozhraní IToSnippetXml</param>
        /// <returns>Snippet/útržek  Xml</returns>
        public static string ToSnippetXml(this IToSnippetXml o)
        {
            var writerSettings = new XmlWriterSettings {OmitXmlDeclaration = true};
            var stringWriter = new StringWriter();
            var xmlWriter = XmlWriter.Create(stringWriter, writerSettings);

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            var ser = new XmlSerializer(o.GetType());

            ser.Serialize(xmlWriter, o, xns);

            return stringWriter.ToString();
        }

        /// <summary>
        ///     Serializuje object implementujici rozhrani IToSnippetXml
        ///     Do jednoducheho xml  bez jmeneho prostoru a declarace
        /// </summary>
        /// <param name="o">Object implementující rozhraní IToSnippetXml</param>
        /// <returns>Snippet/útržek  Xml nebo pokud je o null vrací null</returns>
        public static string ToSnippetXmlOrNull(this IToSnippetXml o)
        {
            return o == null ? null : o.ToSnippetXml();
        }


        /// <summary>
        ///     Serializuje pole int do jednoducheho xml  bez jmeneho prostoru a declarace
        /// </summary>
        /// <param name="array">pole</param>
        /// <param name="xmlArray">Název obalovacího tagu</param>
        /// <param name="xmlArrayItem">Název xml tagu reprezentujícího jedno int</param>
        /// <returns>Snippet/útržek  Xml nebo pokud je array null vrací null</returns>
        public static string ToSnippetXml<T>(this T[] array, string xmlArray, string xmlArrayItem)
        {
            if (array == null) return null;
            var result = array.Aggregate<T, string>(
                null, (current, t) => current + string.Format("<" + xmlArrayItem + ">{0}</" + xmlArrayItem + ">", t)
                );

            return string.Format("<" + xmlArray + ">{0}</" + xmlArray + ">", result);
        }
    }
}