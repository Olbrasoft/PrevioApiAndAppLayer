using System;

namespace Moon.Api
{
    public interface IApiStringProvider
    {
        /// <summary>
        /// Vytvoří request a vrátí vrácená data jako string
        /// </summary>
        /// <param name="urlToRequest">Adresa na kterou se má poslat request
        /// například https://api.previo.cz/x1/System/getReservationStatuses
        /// </param>
        /// <param name="postData">Data která se mají odeslat
        ///     pokud je request typu post predavaji se zpravidla nejaka data.
        ///     například:
        ///     &lt;?xml version=&quot;1.0&quot;?&gt;
        ///     &lt;request&gt;
        ///     &lt;login&gt;User&lt;/login&gt;
        ///     &lt;password&gt;password&lt;/password&gt;
        ///     &lt;hotId&gt;40&lt;/hotId&gt;
        ///     &lt;/request&gt;
        /// </param>
        ///<returns>result reguest (response) as string</returns>
        string Get(Uri urlToRequest, string postData = null);
    }
}