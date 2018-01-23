using System;
using System.Globalization;

namespace Moon.Globalization
{
    public static class ExCultureInfo
    {
   
        public static CultureInfo ToNeutralCulture(this CultureInfo cultureInfo)
        {
            if (cultureInfo.LCID == 127)
                throw new ArgumentException("Invalit culture info.  Can not be default (Invarinat Culture LCID 127). ",
                                            "cultureInfo");

            var result = cultureInfo;

            while (!result.IsNeutralCulture)
            {
                result = result.Parent;
            }
            return result;
        }
    }
}