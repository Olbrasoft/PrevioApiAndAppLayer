namespace Moon.Xml.Serialization
{
    /// <summary>
    /// Třída implementující rozhraní IBuildValidXml, bude umět z předaného xml udělat validní xml 
    /// </summary>
    public interface IBuildValidXml
    {
        /// <summary>
        /// Z předaného xml udělá validní xml, například při zpracocání xml od třetích strank kdy budeme potřebovat nějaké chybz v xml opravit 
        /// </summary>
        /// <param name="xml">nějaké xml </param>
        /// <returns>validní xml</returns>
        string BuildValidXml(string xml);

    }
}