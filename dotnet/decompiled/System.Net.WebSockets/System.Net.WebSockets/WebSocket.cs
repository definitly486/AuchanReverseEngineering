using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.WebSockets;

public abstract class WebSocket : IDisposable
{
	public abstract WebSocketCloseStatus? CloseStatus { get; }

	public abstract string? CloseStatusDescription { get; }

	public abstract string? SubProtocol { get; }

	public abstract WebSocketState State { get; }

	public abstract void Abort();

	public abstract Task CloseAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken);

	public abstract Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken);

	public abstract void Dispose();

	public abstract Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken);

	public abstract Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);

	public virtual async ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken)
	{
		if (MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)buffer, out ArraySegment<byte> segment))
		{
			WebSocketReceiveResult webSocketReceiveResult = await ReceiveAsync(segment, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return new ValueWebSocketReceiveResult(webSocketReceiveResult.Count, webSocketReceiveResult.MessageType, webSocketReceiveResult.EndOfMessage);
		}
		byte[] array = ArrayPool<byte>.Shared.Rent(buffer.Length);
		try
		{
			WebSocketReceiveResult webSocketReceiveResult2 = await ReceiveAsync(new ArraySegment<byte>(array, 0, buffer.Length), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			new Span<byte>(array, 0, webSocketReceiveResult2.Count).CopyTo(buffer.Span);
			return new ValueWebSocketReceiveResult(webSocketReceiveResult2.Count, webSocketReceiveResult2.MessageType, webSocketReceiveResult2.EndOfMessage);
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	public virtual ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
	{
		if (!MemoryMarshal.TryGetArray(buffer, out var segment))
		{
			return SendWithArrayPoolAsync(buffer, messageType, endOfMessage, cancellationToken);
		}
		return new ValueTask(SendAsync(segment, messageType, endOfMessage, cancellationToken));
	}

	public virtual ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, WebSocketMessageFlags messageFlags, CancellationToken cancellationToken = default(CancellationToken))
	{
		return SendAsync(buffer, messageType, messageFlags.HasFlag(WebSocketMessageFlags.EndOfMessage), cancellationToken);
	}

	private async ValueTask SendWithArrayPoolAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(buffer.Length);
		try
		{
			buffer.Span.CopyTo(array);
			await SendAsync(new ArraySegment<byte>(array, 0, buffer.Length), messageType, endOfMessage, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	public static WebSocket CreateFromStream(Stream stream, WebSocketCreationOptions options)
	{
		ArgumentNullException.ThrowIfNull(stream, "stream");
		ArgumentNullException.ThrowIfNull(options, "options");
		if (!stream.CanRead || !stream.CanWrite)
		{
			throw new ArgumentException((!stream.CanRead) ? "NotReadableStream" : "NotWriteableStream", "stream");
		}
		return new ManagedWebSocket(stream, options);
	}
}
