using System;
using System.Buffers;
using System.IO;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IO;
using Websocket.Client.Exceptions;
using Websocket.Client.Threading;
using Websocket.Client.Validations;

namespace Websocket.Client;

public class WebsocketClient : IDisposable
{
	private readonly ILogger<WebsocketClient> _logger;

	private readonly WebsocketAsyncLock _locker = new WebsocketAsyncLock();

	private readonly Func<Uri, CancellationToken, Task<WebSocket>> _connectionFactory;

	private readonly RecyclableMemoryStreamManager? _memoryStreamManager;

	private static readonly Lazy<RecyclableMemoryStreamManager> _globalMemoryStreamManager = new Lazy<RecyclableMemoryStreamManager>(new RecyclableMemoryStreamManager());

	private Uri _url;

	private Timer? _lastChanceTimer;

	private DateTime _lastReceivedMsg = DateTime.UtcNow;

	private Timer? _errorReconnectTimer;

	private bool _disposing;

	private bool _reconnecting;

	private bool _stopping;

	private bool _isReconnectionEnabled = true;

	private WebSocket? _client;

	private CancellationTokenSource? _cancellation;

	private CancellationTokenSource? _cancellationTotal;

	private readonly Subject<ResponseMessage> _messageReceivedSubject = new Subject<ResponseMessage>();

	private readonly Subject<ReconnectionInfo> _reconnectionSubject = new Subject<ReconnectionInfo>();

	private readonly Subject<DisconnectionInfo> _disconnectedSubject = new Subject<DisconnectionInfo>();

	private readonly Channel<RequestMessage> _messagesTextToSendQueue = Channel.CreateUnbounded<RequestMessage>(new UnboundedChannelOptions
	{
		SingleReader = true,
		SingleWriter = false
	});

	private readonly Channel<ReadOnlySequence<byte>> _messagesBinaryToSendQueue = Channel.CreateUnbounded<ReadOnlySequence<byte>>(new UnboundedChannelOptions
	{
		SingleReader = true,
		SingleWriter = false
	});

	private static readonly byte[] _emptyArray = new byte[0];

	private RecyclableMemoryStreamManager MemoryStreamManager => _memoryStreamManager ?? _globalMemoryStreamManager.Value;

	public IObservable<ResponseMessage> MessageReceived => _messageReceivedSubject.AsObservable();

	public IObservable<ReconnectionInfo> ReconnectionHappened => _reconnectionSubject.AsObservable();

	public IObservable<DisconnectionInfo> DisconnectionHappened => _disconnectedSubject.AsObservable();

	public TimeSpan? ReconnectTimeout { get; } = TimeSpan.FromMinutes(1.0);

	public TimeSpan? ErrorReconnectTimeout { get; } = TimeSpan.FromMinutes(1.0);

	public TimeSpan? LostReconnectTimeout { get; }

	public bool IsReconnectionEnabled => _isReconnectionEnabled;

	public string? Name { get; }

	public bool IsStarted { get; private set; }

	public bool IsRunning { get; private set; }

	public bool IsTextMessageConversionEnabled { get; } = true;

	public bool IsStreamDisposedAutomatically { get; } = true;

	public Encoding? MessageEncoding { get; set; }

	public WebsocketClient(Uri url, Func<ClientWebSocket>? clientFactory = null, RecyclableMemoryStreamManager? memoryStreamManager = null)
		: this(url, null, GetClientFactory(clientFactory), memoryStreamManager)
	{
	}

	public WebsocketClient(Uri url, ILogger<WebsocketClient>? logger, Func<Uri, CancellationToken, Task<WebSocket>>? connectionFactory, RecyclableMemoryStreamManager? memoryStreamManager = null)
	{
		Websocket.Client.Validations.Validations.ValidateInput(url, "url");
		_logger = logger ?? NullLogger<WebsocketClient>.Instance;
		_url = url;
		_connectionFactory = connectionFactory ?? ((Func<Uri, CancellationToken, Task<WebSocket>>)async delegate(Uri uri, CancellationToken token)
		{
			ClientWebSocket client = new ClientWebSocket();
			await client.ConnectAsync(uri, token).ConfigureAwait(continueOnCapturedContext: false);
			return client;
		});
		_memoryStreamManager = memoryStreamManager;
	}

	public void Dispose()
	{
		_disposing = true;
		_logger.LogDebug(L("Disposing.."), Name);
		try
		{
			_messagesTextToSendQueue.Writer.Complete();
			_messagesBinaryToSendQueue.Writer.Complete();
			_lastChanceTimer?.Dispose();
			_errorReconnectTimer?.Dispose();
			_cancellation?.Cancel();
			_cancellationTotal?.Cancel();
			_client?.Abort();
			_client?.Dispose();
			_cancellation?.Dispose();
			_cancellationTotal?.Dispose();
			_messageReceivedSubject.OnCompleted();
			_reconnectionSubject.OnCompleted();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, L("Failed to dispose client, error: {error}"), Name, ex.Message);
		}
		if (IsRunning)
		{
			_disconnectedSubject.OnNext(DisconnectionInfo.Create(DisconnectionType.Exit, _client, null));
		}
		IsRunning = false;
		IsStarted = false;
		_disconnectedSubject.OnCompleted();
	}

	public Task Start()
	{
		return StartInternal(failFast: false);
	}

	public async Task<bool> Stop(WebSocketCloseStatus status, string statusDescription)
	{
		bool result = await StopInternal(_client, status, statusDescription, null, failFast: false, byServer: false).ConfigureAwait(continueOnCapturedContext: false);
		_disconnectedSubject.OnNext(DisconnectionInfo.Create(DisconnectionType.ByUser, _client, null));
		return result;
	}

	private static Func<Uri, CancellationToken, Task<WebSocket>>? GetClientFactory(Func<ClientWebSocket>? clientFactory)
	{
		if (clientFactory == null)
		{
			return null;
		}
		return async delegate(Uri uri, CancellationToken token)
		{
			ClientWebSocket client = clientFactory();
			await client.ConnectAsync(uri, token).ConfigureAwait(continueOnCapturedContext: false);
			return client;
		};
	}

	private async Task StartInternal(bool failFast)
	{
		if (_disposing)
		{
			throw new WebsocketException("Client " + Name + " is already disposed, starting not possible");
		}
		if (IsStarted)
		{
			_logger.LogDebug(L("Client already started, ignoring.."), Name);
			return;
		}
		IsStarted = true;
		_logger.LogDebug(L("Starting.."), Name);
		_cancellation = new CancellationTokenSource();
		_cancellationTotal = new CancellationTokenSource();
		await StartClient(_url, _cancellation.Token, ReconnectionType.Initial, failFast).ConfigureAwait(continueOnCapturedContext: false);
		StartBackgroundThreadForSendingText();
		StartBackgroundThreadForSendingBinary();
	}

	private async Task<bool> StopInternal(WebSocket? client, WebSocketCloseStatus status, string statusDescription, CancellationToken? cancellation, bool failFast, bool byServer)
	{
		if (_disposing)
		{
			throw new WebsocketException("Client " + Name + " is already disposed, stopping not possible");
		}
		DeactivateLastChance();
		if (client == null)
		{
			IsStarted = false;
			IsRunning = false;
			return false;
		}
		if (!IsRunning)
		{
			_logger.LogInformation(L("Client is already stopped"), Name);
			IsStarted = false;
			return false;
		}
		bool result = false;
		try
		{
			CancellationToken cancellationToken = cancellation ?? CancellationToken.None;
			_stopping = true;
			if (!byServer)
			{
				await client.CloseAsync(status, statusDescription, cancellationToken);
			}
			else
			{
				await client.CloseOutputAsync(status, statusDescription, cancellationToken);
			}
			result = true;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, L("Error while stopping client, message: '{error}'"), Name, ex.Message);
			if (failFast)
			{
				throw new WebsocketException($"Failed to stop Websocket client {Name}, error: '{ex.Message}'", ex);
			}
		}
		finally
		{
			IsRunning = false;
			_stopping = false;
			if (!byServer || !IsReconnectionEnabled)
			{
				IsStarted = false;
			}
		}
		return result;
	}

	private async Task StartClient(Uri uri, CancellationToken token, ReconnectionType type, bool failFast)
	{
		DeactivateLastChance();
		try
		{
			_client = await _connectionFactory(uri, token).ConfigureAwait(continueOnCapturedContext: false);
			Listen(_client, token);
			IsRunning = true;
			IsStarted = true;
			_reconnectionSubject.OnNext(ReconnectionInfo.Create(type));
			_lastReceivedMsg = DateTime.UtcNow;
			ActivateLastChance();
		}
		catch (Exception ex)
		{
			DisconnectionInfo disconnectionInfo = DisconnectionInfo.Create(DisconnectionType.Error, _client, ex);
			_disconnectedSubject.OnNext(disconnectionInfo);
			if (disconnectionInfo.CancelReconnection)
			{
				_logger.LogError(ex, L("Exception while connecting. Reconnecting canceled by user, exiting. Error: '{error}'"), Name, ex.Message);
				return;
			}
			if (failFast)
			{
				throw new WebsocketException($"Failed to start Websocket client {Name}, error: '{ex.Message}'", ex);
			}
			if (!ErrorReconnectTimeout.HasValue)
			{
				_logger.LogError(ex, L("Exception while connecting. Reconnecting disabled, exiting. Error: '{error}'"), Name, ex.Message);
				return;
			}
			TimeSpan value = ErrorReconnectTimeout.Value;
			_logger.LogError(ex, L("Exception while connecting. Waiting {timeout} sec before next reconnection try. Error: '{error}'"), Name, value.TotalSeconds, ex.Message);
			_errorReconnectTimer?.Dispose();
			_errorReconnectTimer = new Timer(ReconnectOnError, ex, value, Timeout.InfiniteTimeSpan);
		}
	}

	private void ReconnectOnError(object? state)
	{
		Reconnect(ReconnectionType.Error, failFast: false, state as Exception).ConfigureAwait(continueOnCapturedContext: false);
	}

	private bool IsClientConnected()
	{
		WebSocket? client = _client;
		if (client == null)
		{
			return false;
		}
		return client.State == WebSocketState.Open;
	}

	private async Task Listen(WebSocket client, CancellationToken token)
	{
		Exception causedException = null;
		try
		{
			Memory<byte> buffer = new Memory<byte>(new byte[4096]);
			do
			{
				RecyclableMemoryStream ms = MemoryStreamManager.GetStream();
				ValueWebSocketReceiveResult valueWebSocketReceiveResult;
				do
				{
					valueWebSocketReceiveResult = await client.ReceiveAsync(buffer, token);
					ms.Write(buffer.Slice(0, valueWebSocketReceiveResult.Count).Span);
				}
				while (!valueWebSocketReceiveResult.EndOfMessage);
				ms.Seek(0L, SeekOrigin.Begin);
				bool flag = true;
				ResponseMessage responseMessage;
				if (valueWebSocketReceiveResult.MessageType == WebSocketMessageType.Text && IsTextMessageConversionEnabled)
				{
					responseMessage = ResponseMessage.TextMessage(GetEncoding().GetString(ms.GetBuffer(), 0, (int)ms.Length));
				}
				else
				{
					if (valueWebSocketReceiveResult.MessageType == WebSocketMessageType.Close)
					{
						_logger.LogTrace(L("Received close message"), Name);
						if (!IsStarted || _stopping)
						{
							return;
						}
						DisconnectionInfo disconnectionInfo = DisconnectionInfo.Create(DisconnectionType.ByServer, client, null);
						_disconnectedSubject.OnNext(disconnectionInfo);
						if (disconnectionInfo.CancelClosing)
						{
							if (IsReconnectionEnabled)
							{
								throw new OperationCanceledException("Websocket connection was closed by server (client: " + Name + ")");
							}
							continue;
						}
						await StopInternal(client, WebSocketCloseStatus.NormalClosure, "Closing", token, failFast: false, byServer: true);
						if (IsReconnectionEnabled && !ShouldIgnoreReconnection(client))
						{
							ReconnectSynchronized(ReconnectionType.Lost, failFast: false, null);
						}
						return;
					}
					if (IsStreamDisposedAutomatically)
					{
						responseMessage = ResponseMessage.BinaryMessage(ms.ToArray());
					}
					else
					{
						responseMessage = ResponseMessage.BinaryStreamMessage(ms);
						flag = false;
					}
				}
				if (flag)
				{
					ms.Dispose();
				}
				_logger.LogTrace(L("Received:  {message}"), Name, responseMessage);
				_lastReceivedMsg = DateTime.UtcNow;
				_messageReceivedSubject.OnNext(responseMessage);
			}
			while (client.State == WebSocketState.Open && !token.IsCancellationRequested);
		}
		catch (TaskCanceledException ex)
		{
			causedException = ex;
		}
		catch (OperationCanceledException ex2)
		{
			causedException = ex2;
		}
		catch (ObjectDisposedException ex3)
		{
			causedException = ex3;
		}
		catch (Exception ex4)
		{
			_logger.LogError(ex4, L("Error while listening to websocket stream, error: '{error}'"), Name, ex4.Message);
			causedException = ex4;
		}
		if (!ShouldIgnoreReconnection(client) && IsStarted)
		{
			if (LostReconnectTimeout.HasValue)
			{
				TimeSpan value = LostReconnectTimeout.Value;
				_logger.LogWarning(L("Listening websocket stream is lost. Waiting {timeout} sec before next reconnection try."), Name, value.TotalSeconds);
				await Task.Delay(value, token).ConfigureAwait(continueOnCapturedContext: false);
			}
			ReconnectSynchronized(ReconnectionType.Lost, failFast: false, causedException);
		}
	}

	private bool ShouldIgnoreReconnection(WebSocket client)
	{
		bool num = _disposing || _reconnecting || _stopping;
		bool flag = client != _client;
		return num || flag;
	}

	private Encoding GetEncoding()
	{
		if (MessageEncoding == null)
		{
			MessageEncoding = Encoding.UTF8;
		}
		return MessageEncoding;
	}

	private string L(string msg)
	{
		return "[WEBSOCKET {name}] " + msg;
	}

	private DisconnectionType TranslateTypeToDisconnection(ReconnectionType type)
	{
		return (DisconnectionType)type;
	}

	private async Task ReconnectSynchronized(ReconnectionType type, bool failFast, Exception? causedException)
	{
		using (await _locker.LockAsync())
		{
			await Reconnect(type, failFast, causedException);
		}
	}

	private async Task Reconnect(ReconnectionType type, bool failFast, Exception? causedException)
	{
		IsRunning = false;
		if (_disposing || !IsStarted)
		{
			return;
		}
		_reconnecting = true;
		DisconnectionInfo disconnectionInfo = DisconnectionInfo.Create(TranslateTypeToDisconnection(type), _client, causedException);
		if (type != ReconnectionType.Error)
		{
			_disconnectedSubject.OnNext(disconnectionInfo);
			if (disconnectionInfo.CancelReconnection)
			{
				_logger.LogInformation(L("Reconnecting canceled by user, exiting."), Name);
			}
		}
		_cancellation?.Cancel();
		try
		{
			_client?.Abort();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, L("Exception while aborting client. Error: '{error}'"), Name, ex.Message);
		}
		_client?.Dispose();
		if (!IsReconnectionEnabled || disconnectionInfo.CancelReconnection)
		{
			IsStarted = false;
			_reconnecting = false;
			return;
		}
		_logger.LogDebug(L("Reconnecting..."), Name);
		_cancellation = new CancellationTokenSource();
		await StartClient(_url, _cancellation.Token, type, failFast).ConfigureAwait(continueOnCapturedContext: false);
		_reconnecting = false;
	}

	private void ActivateLastChance()
	{
		int num = 1000;
		_lastChanceTimer = new Timer(LastChance, null, num, num);
	}

	private void DeactivateLastChance()
	{
		_lastChanceTimer?.Dispose();
		_lastChanceTimer = null;
	}

	private void LastChance(object? state)
	{
		if (!IsReconnectionEnabled || !ReconnectTimeout.HasValue)
		{
			DeactivateLastChance();
			return;
		}
		double num = Math.Abs(ReconnectTimeout.Value.TotalMilliseconds);
		if (Math.Abs(DateTime.UtcNow.Subtract(_lastReceivedMsg).TotalMilliseconds) > num)
		{
			_logger.LogDebug(L("Last message received more than {timeoutMs} ms ago. Hard restart.."), Name, num.ToString("F"));
			DeactivateLastChance();
			ReconnectSynchronized(ReconnectionType.NoMessageReceived, failFast: false, null);
		}
	}

	public bool Send(string message)
	{
		Websocket.Client.Validations.Validations.ValidateInput(message, "message");
		return _messagesTextToSendQueue.Writer.TryWrite(new RequestTextMessage(message));
	}

	private async Task SendTextFromQueue()
	{
		_ = 1;
		try
		{
			while (await _messagesTextToSendQueue.Reader.WaitToReadAsync())
			{
				RequestMessage message;
				while (_messagesTextToSendQueue.Reader.TryRead(out message))
				{
					try
					{
						await SendInternalSynchronized(message).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, L("Failed to send text message: '{message}'. Error: {error}"), Name, message, ex.Message);
					}
				}
			}
		}
		catch (TaskCanceledException)
		{
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex4)
		{
			if (!(_cancellationTotal?.IsCancellationRequested ?? false) && !_disposing)
			{
				_logger.LogTrace(L("Sending text thread failed, error: {error}. Creating a new sending thread."), Name, ex4.Message);
				StartBackgroundThreadForSendingText();
			}
		}
	}

	private async Task SendBinaryFromQueue()
	{
		_ = 1;
		try
		{
			while (await _messagesBinaryToSendQueue.Reader.WaitToReadAsync())
			{
				ReadOnlySequence<byte> message;
				while (_messagesBinaryToSendQueue.Reader.TryRead(out message))
				{
					try
					{
						await SendInternalSynchronized(message).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, L("Failed to send binary message: '{message}'. Error: {error}"), Name, message, ex.Message);
					}
				}
			}
		}
		catch (TaskCanceledException)
		{
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex4)
		{
			if (!(_cancellationTotal?.IsCancellationRequested ?? false) && !_disposing)
			{
				_logger.LogTrace(L("Sending binary thread failed, error: {error}. Creating a new sending thread."), Name, ex4.Message);
				StartBackgroundThreadForSendingBinary();
			}
		}
	}

	private void StartBackgroundThreadForSendingText()
	{
		Task.Factory.StartNew((object? _) => SendTextFromQueue(), TaskCreationOptions.LongRunning, _cancellationTotal?.Token ?? CancellationToken.None);
	}

	private void StartBackgroundThreadForSendingBinary()
	{
		Task.Factory.StartNew((object? _) => SendBinaryFromQueue(), TaskCreationOptions.LongRunning, _cancellationTotal?.Token ?? CancellationToken.None);
	}

	private async Task SendInternalSynchronized(RequestMessage message)
	{
		using (await _locker.LockAsync())
		{
			await SendInternal(message);
		}
	}

	private async Task SendInternal(RequestMessage message)
	{
		if (!(message is RequestTextMessage textMessage))
		{
			if (!(message is RequestBinaryMessage binaryMessage))
			{
				if (!(message is RequestBinarySegmentMessage segmentMessage))
				{
					if (!(message is RequestBinarySequenceMessage sequenceMessage))
					{
						throw new ArgumentException($"Unknown message type: {message.GetType()}");
					}
					await SendBinarySequenceMessage(sequenceMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await SendBinarySegmentMessage(segmentMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			else
			{
				await SendBinaryMessage(binaryMessage).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		else
		{
			await SendTextMessage(textMessage).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private async Task SendTextMessage(RequestTextMessage textMessage)
	{
		Memory<byte> memory = MemoryMarshal.AsMemory<byte>(GetEncoding().GetBytes(textMessage.Text));
		await SendInternal(memory, WebSocketMessageType.Text).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task SendBinaryMessage(RequestBinaryMessage binaryMessage)
	{
		Memory<byte> memory = MemoryMarshal.AsMemory<byte>(binaryMessage.Data);
		await SendInternal(memory, WebSocketMessageType.Text).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task SendBinarySegmentMessage(RequestBinarySegmentMessage segmentMessage)
	{
		await SendInternal(segmentMessage.Data, WebSocketMessageType.Text).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task SendBinarySequenceMessage(RequestBinarySequenceMessage sequenceMessage)
	{
		await SendInternal(sequenceMessage.Data, WebSocketMessageType.Text).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task SendInternalSynchronized(ReadOnlySequence<byte> message)
	{
		using (await _locker.LockAsync())
		{
			await SendInternal(message, WebSocketMessageType.Binary);
		}
	}

	private async Task SendInternal(ReadOnlySequence<byte> payload, WebSocketMessageType messageType)
	{
		if (payload.IsSingleSegment)
		{
			await SendInternal(payload.First, messageType).ConfigureAwait(continueOnCapturedContext: false);
		}
		else if (CheckClientConnection(payload.Length))
		{
			ReadOnlySequence<byte>.Enumerator enumerator = payload.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ReadOnlyMemory<byte> current = enumerator.Current;
				await _client.SendAsync(current, messageType, endOfMessage: false, _cancellation?.Token ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
			await _client.SendAsync(_emptyArray, messageType, endOfMessage: true, _cancellation?.Token ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private async Task SendInternal(ReadOnlyMemory<byte> payload, WebSocketMessageType messageType)
	{
		if (CheckClientConnection(payload.Length))
		{
			await _client.SendAsync(payload, messageType, endOfMessage: true, _cancellation?.Token ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private bool CheckClientConnection(long length)
	{
		if (!IsClientConnected())
		{
			_logger.LogDebug(L("Client is not connected to server, cannot send binary, length: {length}"), Name, length);
			return false;
		}
		_logger.LogTrace(L("Sending binary, length: {length}"), Name, length);
		return true;
	}
}
