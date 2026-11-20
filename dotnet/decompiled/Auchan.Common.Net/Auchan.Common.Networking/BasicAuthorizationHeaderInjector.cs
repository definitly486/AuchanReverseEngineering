using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;

namespace Auchan.Common.Networking;

public sealed class BasicAuthorizationHeaderInjector : IBasicAuthorizationHeaderInjector
{
	private readonly IEnvironmentManager _environmentManager;

	private readonly Lazy<IAdminContext> _adminContext;

	public BasicAuthorizationHeaderInjector(IEnvironmentManager environmentManager, Lazy<IAdminContext> adminContext)
	{
		_environmentManager = environmentManager;
		_adminContext = adminContext;
	}

	public async Task Inject(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		Uri requestUri = request.RequestUri;
		if (_environmentManager.CurrentEnvironment != Environment.Production && !request.Headers.Contains("Authorization") && !(requestUri == null) && AuchanHeaderHostFilter.ShouldInject(requestUri) && !IsAdminToolRequest(requestUri))
		{
			string basicAuthToken = (await _adminContext.Value.WaitForAppConfig()).BasicAuthToken;
			if (basicAuthToken != null && basicAuthToken.Length > 0)
			{
				request.Headers.TryAddWithoutValidation("Authorization", "Basic " + basicAuthToken);
			}
		}
	}

	private static bool IsAdminToolRequest(Uri requestUri)
	{
		if (requestUri.Host.StartsWith("mobile", StringComparison.OrdinalIgnoreCase))
		{
			return requestUri.AbsolutePath.StartsWith("/api", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}
}
