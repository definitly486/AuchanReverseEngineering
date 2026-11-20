using System.IO;
using System.Net.WebSockets;

namespace Websocket.Client;

public class ResponseMessage
{
	private readonly byte[]? _binary;

	public string? Text { get; }

	public byte[]? Binary
	{
		get
		{
			if (Stream != null)
			{
				return Stream.ToArray();
			}
			return _binary;
		}
	}

	public MemoryStream? Stream { get; }

	public WebSocketMessageType MessageType { get; }

	private ResponseMessage(MemoryStream? memoryStream, byte[]? binary, string? text, WebSocketMessageType messageType)
	{
		Stream = memoryStream;
		_binary = binary;
		Text = text;
		MessageType = messageType;
	}

	public override string ToString()
	{
		if (MessageType == WebSocketMessageType.Text)
		{
			return Text ?? string.Empty;
		}
		return $"Type binary, length: {Binary?.Length}";
	}

	public static ResponseMessage TextMessage(string? data)
	{
		return new ResponseMessage(null, null, data, WebSocketMessageType.Text);
	}

	public static ResponseMessage BinaryMessage(byte[]? data)
	{
		return new ResponseMessage(null, data, null, WebSocketMessageType.Binary);
	}

	public static ResponseMessage BinaryStreamMessage(MemoryStream? memoryStream)
	{
		return new ResponseMessage(memoryStream, null, null, WebSocketMessageType.Binary);
	}
}
