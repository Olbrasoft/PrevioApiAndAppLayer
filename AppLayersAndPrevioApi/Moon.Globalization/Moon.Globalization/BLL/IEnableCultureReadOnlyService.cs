using System.Globalization;
using Moon.BLL;

namespace Moon.Globalization.BLL
{
    public interface IEnableCultureReadOnlyService :IReadOnlyService<CultureInfo>
    {
        CultureInfo GetDefaultCulture();
    }
}
