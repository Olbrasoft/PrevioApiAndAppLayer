using System.Globalization;

namespace Moon.Globalization.DAL
{
    public interface IDefaultCultureReadOnlyRepository
    {
        CultureInfo GetDefaultCulture();
    }
}
