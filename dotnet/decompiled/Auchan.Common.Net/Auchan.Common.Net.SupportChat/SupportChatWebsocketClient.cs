using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.SupportChat;
using DryIoc;
using Websocket.Client;

namespace Auchan.Common.Net.SupportChat;

public sealed class SupportChatWebsocketClient : WebsocketClient
{
	private readonly TaskCompletionSource<bool> _connect = new TaskCompletionSource<bool>();

	private static string AuthSecret(IEnvironmentManager environmentManager)
	{
		IAdminContext adminContext = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IAdminContext>();
		if (adminContext.AppConfig.StageUrlConfigs.ContainsKey(environmentManager.CurrentEnvironment))
		{
			return adminContext.AppConfig.StageUrlConfigs[environmentManager.CurrentEnvironment].ChatbotWebsocketToken;
		}
		return string.Empty;
	}

	public SupportChatWebsocketClient(IUserContext userContext, SupportChatWebSocketUrlProvider urlProvider, IEnvironmentManager environmentManager, IDeviceService deviceService)
		: base(CreateUri(userContext, urlProvider, environmentManager), () => WebSocketFactory(environmentManager, deviceService))
	{
		base.ReconnectionHappened.Subscribe(OnClientReconnectionHappened);
		base.DisconnectionHappened.Subscribe(OnClientDisconnectionHappened);
	}

	private static Uri CreateUri(IUserContext userContext, SupportChatWebSocketUrlProvider urlProvider, IEnvironmentManager environmentManager)
	{
		return new Uri(urlProvider.BaseUrlForEnvironment(environmentManager.CurrentEnvironment) + "?CMD_ID=" + userContext.Profile?.ClientAccountId + "&acknowledge=true");
	}

	private static ClientWebSocket WebSocketFactory(IEnvironmentManager environmentManager, IDeviceService deviceService)
	{
		string text = AuthSecret(environmentManager);
		ClientWebSocket clientWebSocket = new ClientWebSocket();
		clientWebSocket.Options.CollectHttpResponseDetails = true;
		clientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30L);
		clientWebSocket.Options.SetRequestHeader("Authorization", "Basic " + text);
		clientWebSocket.Options.SetRequestHeader("x-app-user-agent", deviceService.AppUserAgent);
		return clientWebSocket;
	}

	public async Task<bool> ConnectAsync()
	{
		try
		{
			await Start();
		}
		catch (Exception)
		{
			_connect.TrySetResult(result: false);
		}
		return await _connect.Task;
	}

	private void OnClientReconnectionHappened(ReconnectionInfo info)
	{
		_connect?.TrySetResult(result: true);
	}

	private void OnClientDisconnectionHappened(DisconnectionInfo info)
	{
		_connect?.TrySetResult(result: false);
	}
}
