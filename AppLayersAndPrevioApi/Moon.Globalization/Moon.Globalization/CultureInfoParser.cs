using System;
using System.Globalization;
using System.Linq;
using Moon.Convert;

namespace Moon.Globalization
{
    public class CultureInfoParser : BaseParser<CultureInfo>, ICultureInfoParser
    {
        public override CultureInfo Parse(string s)
        {
            ThrowNullOrEmpty(s);
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures).Where
                (cultureInfo => String.Compare(s, cultureInfo.Name, StringComparison.OrdinalIgnoreCase) == 0))
            {
                // the String s matches a culture name
                return cultureInfo;
            }
            throw new FormatException();
        }
    }
}