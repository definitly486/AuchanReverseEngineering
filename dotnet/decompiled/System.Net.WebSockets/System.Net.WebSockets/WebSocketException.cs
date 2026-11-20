using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Net.WebSockets;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class WebSocketException : Win32Exception
{
	private readonly WebSocketError _webSocketErrorCode;

	public override int ErrorCode => base.NativeErrorCode;

	public WebSocketException(WebSocketError error)
		: this(error, GetErrorMessage(error))
	{
	}

	public WebSocketException(WebSocketError error, string? message)
		: base(message ?? "net_WebSockets_Generic")
	{
		_webSocketErrorCode = error;
	}

	public WebSocketException(WebSocketError error, Exception? innerException)
		: this(error, GetErrorMessage(error), innerException)
	{
	}

	public WebSocketException(WebSocketError error, string? message, Exception? innerException)
		: base(message ?? "net_WebSockets_Generic", innerException)
	{
		_webSocketErrorCode = error;
	}

	public WebSocketException(string? message)
		: base(message ?? "net_WebSockets_Generic")
	{
	}

	public WebSocketException(string? message, Exception? innerException)
		: base(message ?? "net_WebSockets_Generic", innerException)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("WebSocketErrorCode", _webSocketErrorCode);
	}

	private static string GetErrorMessage(WebSocketError error)
	{
		return error switch
		{
			WebSocketError.InvalidMessageType => System.SR.Format("net_WebSockets_InvalidMessageType_Generic", "WebSocket.CloseAsync", "WebSocket.CloseOutputAsync"), 
			WebSocketError.Faulted => "net_Websockets_WebSocketBaseFaulted", 
			WebSocketError.NotAWebSocket => "net_WebSockets_NotAWebSocket_Generic", 
			WebSocketError.UnsupportedVersion => "net_WebSockets_UnsupportedWebSocketVersion_Generic", 
			WebSocketError.UnsupportedProtocol => "net_WebSockets_UnsupportedProtocol_Generic", 
			WebSocketError.HeaderError => "net_WebSockets_HeaderError_Generic", 
			WebSocketError.ConnectionClosedPrematurely => "net_WebSockets_ConnectionClosedPrematurely_Generic", 
			WebSocketError.InvalidState => "net_WebSockets_InvalidState_Generic", 
			_ => "net_WebSockets_Generic", 
		};
	}
}
