using System;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace Websocket.Client;

public class DisconnectionInfo
{
	[CompilerGenerated]
	private readonly string? _003CSubProtocol_003Ek__BackingField;

	public DisconnectionType Type { get; }

	public WebSocketCloseStatus? CloseStatus { get; }

	public string? CloseStatusDescription { get; }

	public Exception? Exception { get; }

	public bool CancelReconnection { get; }

	public bool CancelClosing { get; }

	public DisconnectionInfo(DisconnectionType type, WebSocketCloseStatus? closeStatus, string? closeStatusDescription, string? subProtocol, Exception? exception)
	{
		Type = type;
		CloseStatus = closeStatus;
		CloseStatusDescription = closeStatusDescription;
		_003CSubProtocol_003Ek__BackingField = subProtocol;
		Exception = exception;
	}

	public static DisconnectionInfo Create(DisconnectionType type, WebSocket? client, Exception? exception)
	{
		return new DisconnectionInfo(type, client?.CloseStatus, client?.CloseStatusDescription, client?.SubProtocol, exception);
	}
}
