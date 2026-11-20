using System;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Networking;

namespace Auchan.Common.SupportChat;

internal sealed class BeesenderFileServiseUrlProvider : IEnvironmentBaseUrlProvider
{
	private string? _fileServiceConnector;

	private readonly IAdminContext _adminContext;

	private readonly IChatSettingsApi _api;

	public BeesenderFileServiseUrlProvider(IAdminContext adminContext, IChatSettingsApi api)
	{
		_adminContext = adminContext;
		_api = api;
	}

	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		throw new NotImplementedException("dead code");
	}

	public async Task<string> BaseUrlForEnvironmentAsync(Auchan.Common.Networking.Environment env)
	{
		if (env == Auchan.Common.Networking.Environment.Production)
		{
			return _adminContext.AppConfig.StageUrlConfigs[env].ChatbotFileserverAddress;
		}
		if (!string.IsNullOrEmpty(_fileServiceConnector))
		{
			return _fileServiceConnector;
		}
		return _fileServiceConnector = (await _api.GetTestSettings()).Data.FileServiceConnector;
	}
}
