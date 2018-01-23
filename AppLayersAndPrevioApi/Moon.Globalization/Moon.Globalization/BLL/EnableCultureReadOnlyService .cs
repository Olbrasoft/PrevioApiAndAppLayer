using System.Globalization;
using Moon.BLL;
using Moon.Globalization.DAL;

namespace Moon.Globalization.BLL
{
    public class EnableCultureReadOnlyService : BaseReadOnlySimpleService<CultureInfo>, IEnableCultureReadOnlyService
    {
        protected new readonly IEnableCultureReadOnlyRepository Repository;
        protected readonly IDefaultCultureService DefaultCultureService;

        public  EnableCultureReadOnlyService(IEnableCultureReadOnlyRepository repository, IDefaultCultureService defaultCultureService)
            : base(repository)
        {
            Repository = (IEnableCultureReadOnlyRepository) base.Repository;
            DefaultCultureService = defaultCultureService;
        }
        
        public virtual CultureInfo GetDefaultCulture()
        {
           return DefaultCultureService.GetDefaultCulture();
        }
    }
}
