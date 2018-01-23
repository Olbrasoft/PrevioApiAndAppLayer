using System.Globalization;
using Moon.Globalization.DAL;

namespace Moon.Globalization.BLL
{
    public class DefaultCultureWebConfigReadOnlyService : IDefaultCultureService
    {
        protected readonly IDefaultCultureReadOnlyRepository DefaultCultureRepository;
        public DefaultCultureWebConfigReadOnlyService(IDefaultCultureReadOnlyRepository defaultCultureRepository)
        {
            DefaultCultureRepository = defaultCultureRepository;
        }

        public virtual CultureInfo GetDefaultCulture()
        {
            return DefaultCultureRepository.GetDefaultCulture();
        }
    }
}
