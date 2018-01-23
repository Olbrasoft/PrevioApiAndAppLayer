using System;
using System.IO;
using System.Net;
using Moon.Net;
namespace Moon.Api
{
    /// <summary>
    ///     To request the return result as string
    /// </summary>
    public class ApiStringProvider : IApiStringProvider
    {
        protected readonly IRequestConfig RequestConfig;

        public ApiStringProvider(IRequestConfig requestConfig)
        {
            RequestConfig = requestConfig;
        }
        
        
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
        public virtual string Get(Uri urlToRequest, string postData = null)
        {
            var stream = CreateRequest(urlToRequest, postData).ToHttpWebResponse().GetResponseStream();
            return stream == null ? null : new StreamReader(stream, true).ReadToEnd();
        }


        /// <summary>
        /// Odesle pripadna data
        /// </summary>
        /// <param name="request">Request ve kterém se mají odeslat data</param>
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
        private void SendData(WebRequest request, string postData)
        {
            if (request == null) throw new ArgumentNullException("request");
            if (string.IsNullOrEmpty(postData)) return;
            request.ContentLength = postData.Length;
            var newStream = request.GetRequestStream();

            // Send the data
            newStream.Write(postData.ToBytes(RequestConfig.PostDataEncoding), 0, postData.Length);
            newStream.Close();
        }

        /// <summary>
        ///     Vytvoří dotaz na předané url a případně odešle předaná data
        /// </summary>
        /// <param name="urlToRequest">Na jakou adresu má být udělán request (zpravidla adresa api + adresa funkce)
        ///  například https://api.previo.cz/x1/System/getReservationStatuses
        /// </param>
        /// <param name="postData">
        ///     pokud je request typu post predavaji se zpravidla nejaka data.
        ///     například:
        ///     &lt;?xml version=&quot;1.0&quot;?&gt;
        ///     &lt;request&gt;
        ///     &lt;login&gt;User&lt;/login&gt;
        ///     &lt;password&gt;password&lt;/password&gt;
        ///     &lt;hotId&gt;40&lt;/hotId&gt;
        ///     &lt;/request&gt;
        /// </param>
        /// <returns></returns>
        private HttpWebRequest CreateRequest(Uri urlToRequest, string postData = null)
        {
            var request =
                (HttpWebRequest) WebRequest.Create(urlToRequest);
            request.Method = RequestConfig.RequestMethod;
            request.ContentType = RequestConfig.RequestContentType;
            SendData(request, postData);
            return request;
        }
    }
}