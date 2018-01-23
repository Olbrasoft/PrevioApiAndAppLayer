namespace Moon.Xml.Serialization
{
    /// <summary>
    ///     Třída Implementující rozhraní IGenericObjectXmlSeserializer, bude umět Deserializovat předané xml do požadovaného objektu
    /// </summary>
    public interface IGenericObjectXmlDeseserialize
    {
        /// <summary>
        ///     Metodě se předá xml jako string a deserializuje se na požadovaný objekt typu T
        /// </summary>
        /// <typeparam name="T">Na jakej typ chceme deserializovat předané xml</typeparam>
        /// <param name="xml">Xml ze kterého se má deserializövat objekt</param>
        /// <returns>Objekt požadovaného typu T s naplněnýma vlastnostmi hodnotamy z předaného xml </returns>
        T Deserialize<T>(string xml);
    }
}