using System.Text;

namespace Moon.Net
{
    /// <summary>
    ///     Config Request
    /// </summary>
    public class RequestConfig : IRequestConfig
    {
        /// <summary>
        ///     Konstruktor inicilalizuje vlastnost requestMethod jestli pujde o POST/GET ..
        ///     a  vlastnost RequestContentType "application/xml" ..
        /// </summary>
        /// <param name="requestMethod">HttpWebRequest Request.Method POST/GET ..</param>
        /// <param name="requestContentType"> HttpWebRequest Request.ContentType  "application/xml"</param>
        /// <param name="postDataEncoding"></param>
        public RequestConfig(string requestMethod, string requestContentType = null, Encoding postDataEncoding=null)
        {
            PostDataEncoding = postDataEncoding;
            RequestContentType = requestContentType;
            RequestMethod = requestMethod;
        }

        /// <summary>
        ///     HttpWebRequest Request.Method POST/GET ..
        /// </summary>
        public string RequestMethod { get; private set; }

        /// <summary>
        ///     HttpWebRequest Request.ContentType  "application/xml"
        /// </summary>
        public string RequestContentType { get; private set; }


        /// <summary>
        /// Jak jsou případná data pro request POST encodovana
        /// </summary>
        public Encoding PostDataEncoding { get; private set; }
    }
}