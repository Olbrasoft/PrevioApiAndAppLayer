using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Moon
{
    public static class ExString
    {
        /// <summary>
        ///     Převede text na pole typu byte
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }


        /// <summary>
        ///     Remove Diacritics from a string
        ///     This converts accented characters to nonaccented, which means it is
        ///     easier to search for matching data with or without such accents.
        ///     This code from Micheal Kaplans Blog:
        ///     http://blogs.msdn.com/b/michkap/archive/2007/05/14/2629747.aspx
        ///     Respaced and converted to an Extension Method
        ///     <example>
        ///         aàáâãäåçc
        ///         is converted to
        ///         aaaaaaacc
        ///     </example>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String RemoveDiacritics(this String s)
        {
            var normalizedString = s.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (
                var c in
                    normalizedString.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                )
            {
                stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}