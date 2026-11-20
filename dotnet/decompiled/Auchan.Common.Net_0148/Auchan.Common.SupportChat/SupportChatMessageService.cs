using System;
using System.Net.WebSockets;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Net.SupportChat;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Newtonsoft.Json;
using Websocket.Client;

namespace Auchan.Common.SupportChat;

public class SupportChatMessageService : ISupportChatMessageService
{
	private readonly ILogService _logService;

	private readonly Func<SupportChatWebsocketClient> _websocketClientFactory;

	private readonly IUserContext _userContext;

	private readonly CompositeDisposable _closeConnectionDisposables = new CompositeDisposable();

	private volatile SupportChatWebsocketClient? _client;

	public bool IsConnected => _client?.IsRunning ?? false;

	public event EventHandler<BaseWSMessageDTO>? OnMessageReceived;

	public event EventHandler? OnDisconnected;

	public SupportChatMessageService(ILogService logService, Func<SupportChatWebsocketClient> websocketClientFactory, IUserContext userContext)
	{
		_logService = logService;
		_websocketClientFactory = websocketClientFactory;
		_userContext = userContext;
	}

	public async Task<bool> ConnectAsync()
	{
		for (int i = 0; i < 5; i++)
		{
			await Task.Delay(100);
			if (await DoAsync())
			{
				return true;
			}
		}
		return false;
		Task<bool> DoAsync()
		{
			SupportChatWebsocketClient client = _client;
			if (client == null)
			{
				return ConnectInternalAsync();
			}
			return client.ConnectAsync();
		}
	}

	public async Task SendAcknowledgeAsync(int ackId)
	{
		SupportChatWebsocketClient client = _client;
		if (!IsConnected || client == null)
		{
			await ConnectAsync();
			client = _client;
		}
		if (IsConnected && client != null)
		{
			try
			{
				string message = JsonConvert.SerializeObject(new AcknowledgeDto(ackId));
				client.Send(message);
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}
	}

	public virtual async Task<Result<CacheMessage, DomainError>> SendMessage(CacheMessage message)
	{
		return await Task.Run(() => PrivateSendMessage(message));
	}

	private async Task<Result<CacheMessage, DomainError>> PrivateSendMessage(CacheMessage message)
	{
		SupportChatWebsocketClient client = _client;
		if (!IsConnected || client == null)
		{
			await ConnectAsync();
			client = _client;
		}
		if (!IsConnected || client == null)
		{
			string text = JsonConvert.SerializeObject(message.ToMessageDTO(_userContext.Profile.ClientAccountId));
			_logService.LogInfo("SupportChatMessageService", "message on disconnected [" + text + "]", LogType.UserAction, SystemType.MobileApp);
			return Result.Failure<CacheMessage, DomainError>(new UnknownError());
		}
		try
		{
			string text2 = JsonConvert.SerializeObject(message.ToMessageDTO(_userContext.Profile.ClientAccountId));
			_logService.LogInfo("SupportChatMessageService", "send [" + text2 + "]", LogType.ApiRequest, SystemType.MobileApp);
			return client.Send(text2) ? Result.Success<CacheMessage, DomainError>(message) : Result.Failure<CacheMessage, DomainError>(new UnknownError());
		}
		catch (Exception ex)
		{
			return Result.Failure<CacheMessage, DomainError>(new UnknownError
			{
				Message = ex.ToString()
			});
		}
	}

	private Task<bool> ConnectInternalAsync()
	{
		SupportChatWebsocketClient supportChatWebsocketClient = _websocketClientFactory();
		supportChatWebsocketClient.AddTo(_closeConnectionDisposables);
		supportChatWebsocketClient.MessageReceived.Subscribe(OnClientMessageReceived).AddTo(_closeConnectionDisposables);
		supportChatWebsocketClient.ReconnectionHappened.Subscribe(OnClientReconnectionHappened).AddTo(_closeConnectionDisposables);
		supportChatWebsocketClient.DisconnectionHappened.Subscribe(OnClientDisconnectionHappened).AddTo(_closeConnectionDisposables);
		Task<bool> result = supportChatWebsocketClient.ConnectAsync();
		_client = supportChatWebsocketClient;
		return result;
	}

	private void OnClientMessageReceived(ResponseMessage message)
	{
		if (message.MessageType == WebSocketMessageType.Text && !string.IsNullOrEmpty(message.Text))
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				OnClientTextMessageReceived(message.Text);
			});
		}
		else
		{
			_logService.LogInfo("SupportChatMessageService", $"on ignored message type: {message.MessageType}", LogType.ApiRequest, SystemType.MobileApp);
		}
	}

	private void OnClientTextMessageReceived(string text)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		_logService.LogInfo("SupportChatMessageService", "on message: [" + text + "]", LogType.ApiRequest, SystemType.MobileApp);
		BaseWSMessageDTO baseWSMessageDTO;
		try
		{
			baseWSMessageDTO = WSMessageJsonConverter.Deserialize(text);
		}
		catch (Exception value)
		{
			_logService.LogError("SupportChatMessageService", $"\nGot exception\n{value}\nwhile parsing message:\n------------------------------\n{text}\n------------------------------\n", LogType.ApiRequest, SystemType.MobileApp);
			return;
		}
		_logService.LogInfo("SupportChatMessageService", "on message - parsed ok: ", LogType.ApiRequest, SystemType.MobileApp);
		if (baseWSMessageDTO.Event != WSMessageEventType.Unknown)
		{
			this.OnMessageReceived?.Invoke(this, baseWSMessageDTO);
		}
	}

	private void OnClientReconnectionHappened(ReconnectionInfo info)
	{
		_logService.LogInfo("SupportChatMessageService", $"on open {info.Type}", LogType.ApiRequest, SystemType.MobileApp);
	}

	private void OnClientDisconnectionHappened(DisconnectionInfo info)
	{
		Disconnect(closeConnection: false);
		this.OnDisconnected?.Invoke(this, EventArgs.Empty);
		_logService.LogInfo("SupportChatMessageService", $"on close status: {info.CloseStatus?.ToString() ?? "unknown"}, \nreason: {info.CloseStatusDescription ?? "unknown"},\nexception: [{info.Exception?.Message ?? info.Exception?.InnerException?.Message ?? info.Type.ToString()}]\nstack trace: {info.Exception?.StackTrace ?? info.Exception?.InnerException?.StackTrace ?? "unknown"}", LogType.ApiRequest, SystemType.MobileApp);
	}

	public void Disconnect(bool closeConnection = true)
	{
		if (closeConnection)
		{
			_client?.Stop(WebSocketCloseStatus.NormalClosure, "");
		}
		_closeConnectionDisposables.Clear();
		_client = null;
	}
}
