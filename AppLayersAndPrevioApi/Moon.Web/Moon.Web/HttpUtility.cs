using System;
using System.Globalization;
using System.Linq;

namespace Moon.Web
{
    public static class HttpUtility
    {
        #region Private Static functions

        private static string FullHtmlEncode(string text)
        {
          return text.Aggregate("", (current, c) => current + String.Format("&#{0};", Convert.ToUInt32(c)));
        }
        
        private static string SpecialCharsAndMaskTextHtmlEncode(string text)
        {
            var beCoded = true;
            var result = "";
            var tempCount = 0;

            foreach (var c in text)
            {
                if (HtmlEncode(c.ToString(CultureInfo.InvariantCulture)) != c.ToString(CultureInfo.InvariantCulture))
                {
                    result += HtmlEncode(c.ToString(CultureInfo.InvariantCulture));
                    beCoded = false;
                }
                else
                {
                    if (beCoded || c == ' ' || Convert.ToInt32(c) > 127)
                    {
                        result += FullHtmlEncode(c.ToString(CultureInfo.InvariantCulture));
                        beCoded = false;
                    }
                    else
                    {
                        result += c;
                        tempCount++;
                        if (tempCount > 1)
                        {
                            tempCount = 0;
                            beCoded = true;
                        }

                    }
                }
            }

            return result;
        }


        private static string FullUrlEncode(string url)
        {
            return url.Aggregate("", (current, c) => current + String.Format("%{0:x2}", Convert.ToUInt32(c)));
        }


        private static string SpecialCharsAndMaskTextUrlEncode (string url)
        {
            var beCoded = true;
            var result = "";

            foreach (var c in url)
            {
                if (UrlEncode(c.ToString(CultureInfo.InvariantCulture)) != c.ToString(CultureInfo.InvariantCulture))
                {
                    result += UrlEncode(c.ToString(CultureInfo.InvariantCulture));
                    beCoded = false;
                }
                else
                {
                    if (beCoded)
                    {
                        result += FullUrlEncode(c.ToString(CultureInfo.InvariantCulture));
                        beCoded = false;
                    }
                    else
                    {
                        result += c;
                        beCoded = true;
                    }
                }
            }
            return result;
        }

        #endregion

        #region Public Static Function


        public static string UrlEncode(string url)
        {
            return System.Web.HttpUtility.UrlEncode(url);
        }


        public static string HtmlEncode(string text)
        {
            return System.Web.HttpUtility.HtmlEncode(text);
        }


        public static string UrlEncode(string url, EncodeOptions encodeOptions)
        {
            switch (encodeOptions)
            {
                case EncodeOptions.FullEncode:
                    return FullUrlEncode(url);

                case EncodeOptions.SpecialCharsAndMaskText:
                    return SpecialCharsAndMaskTextUrlEncode(url);

            }

            return UrlEncode(url);
        }

        public static string HtmlEncode(string text, EncodeOptions encodeOptions)
        {
            switch (encodeOptions)
            {
                case EncodeOptions.FullEncode :
                    return FullHtmlEncode(text);
            
                case EncodeOptions.SpecialCharsAndMaskText:
                    return SpecialCharsAndMaskTextHtmlEncode(text);
            }
            
            return HtmlEncode(text);
        }
    }
        #endregion
}
