using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Extensions;

namespace Auchan.Common.Networking;

internal sealed class XAppUserAgentHeaderInjector : IHeaderInjector2
{
	private readonly IDeviceService _deviceService;

	private readonly IReadOnlyList<string> ExcludeDomains = new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "pay.auchan.ru", "pay.test.auchan.ru" });

	public XAppUserAgentHeaderInjector(IDeviceService deviceService)
	{
		_deviceService = deviceService;
	}

	public void Inject(string? url, IDictionary<string, string> headers)
	{
		if (Uri.TryCreate(url, UriKind.Absolute, out Uri result) && !ExcludeDomains.Any(result.Host.Contains) && result.IsAuchanHost())
		{
			headers["x-app-user-agent"] = _deviceService.AppUserAgent;
		}
	}
}
