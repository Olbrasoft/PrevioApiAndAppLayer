using System.Globalization;
using System.Web;

namespace Moon.Globalization.DAL
{
	public abstract class BaseDefaultCultureQueryStringReadOnlyRepository : IDefaultCultureReadOnlyRepository
	{
		protected readonly string QueryStringParameterName;
		protected readonly HttpContext Context;
		ICultureInfoParser CultureParser;

		protected BaseDefaultCultureQueryStringReadOnlyRepository(string queryStringParameterName, HttpContext context, ICultureInfoParser parser) {
			QueryStringParameterName = queryStringParameterName;
			Context = context;
			CultureParser = parser;
		}

		public virtual CultureInfo GetDefaultCulture() {
			string cultureName = Context.Request.QueryString[QueryStringParameterName];
			return CultureParser.Parse(cultureName);
		}
	}
}
