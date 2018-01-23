using System.Net;

namespace Moon.Net
{
    public static class ExHttpWebRequest
    {
        /// <summary>
        ///     Extension for convert WebRequest to HttpWebResponse
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Response</returns>
        public static HttpWebResponse ToHttpWebResponse(this HttpWebRequest request)
        {
            return (HttpWebResponse) request.GetResponse();
        }

   }
}