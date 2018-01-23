using System;
using System.Text.RegularExpressions;

namespace Previo.Api.Client.DAL
{
    /// <summary>
    ///     Umí opravit  xml , které vrací previo aby bylo validní
    /// </summary>
    public class PrevioValidXmlBuilder : IPrevioValidXmlBuilder
    {
        private static string ReplaceOneFromTo(Match m)
        {
          return m.ToString().Replace(" ","T");
        }
        
        public string BuildValidXml(string xml)
        {
            var regEx = new Regex("<from>20[0-9][0-9]-[0-1][0-9]-[0-3][0-9] ");

            xml = regEx.Replace(xml, ReplaceOneFromTo);
            
            regEx = new Regex("<to>20[0-9][0-9]-[0-1][0-9]-[0-3][0-9] ");

            xml = regEx.Replace(xml, ReplaceOneFromTo);

            var buildXml = Regex.Replace(xml, "<[^/>]+/>", "");
            //oprava nevalidniho xml int? vraci jako <galId/> to nejde serializovat 
            //pro net by to muselo byt <galId xsi:nil=""true""/>
            //tudiz tagy <neco/> uplne odstranim
        
            return buildXml.Trim() == @"<?xml version=""1.0"" encoding=""UTF-8""?>" ? xml : buildXml;
        }
    }
}