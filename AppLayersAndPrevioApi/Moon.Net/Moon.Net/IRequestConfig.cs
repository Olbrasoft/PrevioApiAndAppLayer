using System.Text;

namespace Moon.Net
{
    public interface IRequestConfig
    {
        /// <summary>
        ///     HttpWebRequest Request.Method POST/GET ..
        /// </summary>
        string RequestMethod { get; }

        /// <summary>
        ///     HttpWebRequest Request.ContentType  "application/xml"
        /// </summary>
        string RequestContentType { get; }


        /// <summary>
        /// Jak jsou případná data pro request POST encodovana
        /// </summary>
        Encoding PostDataEncoding { get; }
    }
}