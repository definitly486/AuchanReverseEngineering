using System.Collections.Generic;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Mappers;

namespace Auchan.Common.Networking;

internal sealed class HeaderInjector : IHeaderInjector
{
	private readonly IHeaderProvider _provider;

	public HeaderInjector(IHeaderProvider provider)
	{
		_provider = provider;
	}

	public bool Inject(string url, IDictionary<string, string> existingHeaders)
	{
		if (AuchanHeaderHostFilter.ShouldInject(url) && !_provider.IsValidHeaders(existingHeaders))
		{
			IDictionary<string, string> headers = _provider.GetHeaders(url);
			existingHeaders.AddOrReplace(headers);
			return true;
		}
		return false;
	}
}
