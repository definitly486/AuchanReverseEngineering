using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Auchan.Common.Extensions;

internal static class UriExtensions
{
	private const string AuchanHost = "auchan.ru";

	public static bool ShouldOpenInWebView(this Uri uri)
	{
		return HttpUtility.ParseQueryString(uri.Query).HasQueryParameter("openinwebview");
	}

	public static bool HasQueryParameter(this NameValueCollection query, string parameter)
	{
		StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
		if (!query.AllKeys.Any((string key) => string.Equals(key, parameter, comparison)))
		{
			return query.GetValues(null)?.Any((string value) => string.Equals(value, parameter, comparison)) ?? false;
		}
		return true;
	}

	public static bool IsAuchanHost(this Uri uri)
	{
		string text = uri.IdnHost.TrimEnd('.');
		if (!text.Equals("auchan.ru", StringComparison.OrdinalIgnoreCase))
		{
			return text.EndsWith(".auchan.ru", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}
}
