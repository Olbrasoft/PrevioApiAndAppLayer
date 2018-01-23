using System.Globalization;
using Moon.DAL.FromConfig;

namespace Moon.Globalization.DAL.FromConfig
{
    public class BaseConfigEnableCulturesReadOnlyRepository :BaseConfigAppSetingsReadOnlyRepository<CultureInfo>, IEnableCultureReadOnlyRepository
    {

        public BaseConfigEnableCulturesReadOnlyRepository(string appSettingsKey, string objectSeparator, ICultureInfoParser stringToCultureInfo)
            : base(appSettingsKey, objectSeparator, stringToCultureInfo)
        {}
        
   }
}
