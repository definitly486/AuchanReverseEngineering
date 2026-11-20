using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Extensions;

namespace Auchan.Common.Networking;

internal static class AuchanHeaderHostFilter
{
	private static readonly IReadOnlyList<string> ExcludedHosts = new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "pay.auchan.ru", "pay.test.auchan.ru" });

	public static bool ShouldInject(string? url)
	{
		if (Uri.TryCreate(url, UriKind.Absolute, out Uri result))
		{
			return ShouldInject(result);
		}
		return false;
	}

	public static bool ShouldInject(Uri? uri)
	{
		if (uri == null)
		{
			return false;
		}
		string host = uri.IdnHost.TrimEnd('.');
		if (uri.IsAuchanHost())
		{
			return !ExcludedHosts.Any((string excludedHost) => IsHostOrSubdomainOf(host, excludedHost));
		}
		return false;
	}

	private static bool IsHostOrSubdomainOf(string host, string domain)
	{
		if (!host.EqualsIgnoreCase(domain))
		{
			return host.EndsWith("." + domain, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}
}
