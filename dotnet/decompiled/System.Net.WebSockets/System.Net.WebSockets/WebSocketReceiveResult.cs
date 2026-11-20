using System.Runtime.CompilerServices;

namespace System.Net.WebSockets;

public class WebSocketReceiveResult
{
	[CompilerGenerated]
	private readonly WebSocketCloseStatus? _003CCloseStatus_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CCloseStatusDescription_003Ek__BackingField;

	public int Count { get; }

	public bool EndOfMessage { get; }

	public WebSocketMessageType MessageType { get; }

	public WebSocketReceiveResult(int count, WebSocketMessageType messageType, bool endOfMessage, WebSocketCloseStatus? closeStatus, string? closeStatusDescription)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		Count = count;
		EndOfMessage = endOfMessage;
		MessageType = messageType;
		_003CCloseStatus_003Ek__BackingField = closeStatus;
		_003CCloseStatusDescription_003Ek__BackingField = closeStatusDescription;
	}
}
