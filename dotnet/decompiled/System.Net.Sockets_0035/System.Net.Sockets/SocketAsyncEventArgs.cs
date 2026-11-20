using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace System.Net.Sockets;

public class SocketAsyncEventArgs : EventArgs, IDisposable
{
	private enum OperationState
	{
		Configuring = -1,
		Free,
		InProgress,
		Disposed
	}

	private sealed class MultiConnectSocketAsyncEventArgs : SocketAsyncEventArgs, IValueTaskSource
	{
		private ManualResetValueTaskSourceCore<bool> _mrvtsc;

		private bool _isCompleted;

		public short Version => _mrvtsc.Version;

		public MultiConnectSocketAsyncEventArgs()
			: base(unsafeSuppressExecutionContextFlow: false)
		{
		}

		public void GetResult(short token)
		{
			_mrvtsc.GetResult(token);
		}

		public ValueTaskSourceStatus GetStatus(short token)
		{
			return _mrvtsc.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_mrvtsc.OnCompleted(continuation, state, token, flags);
		}

		public void Reset()
		{
			_mrvtsc.Reset();
		}

		protected override void OnCompleted(SocketAsyncEventArgs e)
		{
			_mrvtsc.SetResult(result: true);
		}

		public bool ReachedCoordinationPointFirst()
		{
			return !Interlocked.Exchange(ref _isCompleted, value: true);
		}
	}

	private Socket _acceptSocket;

	private Socket _connectSocket;

	private Memory<byte> _buffer;

	private int _offset;

	private int _count;

	private bool _bufferIsExplicitArray;

	private IList<ArraySegment<byte>> _bufferList;

	private List<ArraySegment<byte>> _bufferListInternal;

	private int _bytesTransferred;

	private SocketAsyncOperation _completedOperation;

	private IPPacketInformation _receiveMessageFromPacketInfo;

	private EndPoint _remoteEndPoint;

	private SocketError _socketError;

	private Exception _connectByNameError;

	private SocketFlags _socketFlags;

	private byte[] _acceptBuffer;

	private int _acceptAddressBufferCount;

	internal SocketAddress _socketAddress;

	private readonly bool _flowExecutionContext;

	private ExecutionContext _context;

	private static readonly ContextCallback s_executionCallback = ExecutionCallback;

	private static ConditionalWeakTable<SocketAsyncEventArgs, Activity> s_connectActivityTable;

	private Socket _currentSocket;

	private bool _userSocket;

	private bool _disposeCalled;

	private OperationState _operating;

	private CancellationTokenSource _multipleConnectCancellation;

	[CompilerGenerated]
	private EventHandler<SocketAsyncEventArgs> Completed;

	private nint _acceptedFileDescriptor;

	private int _socketAddressSize;

	private SocketFlags _receivedFlags;

	private Action<int, Memory<byte>, SocketFlags, SocketError> _transferCompletionCallback;

	public Socket? AcceptSocket
	{
		get
		{
			return _acceptSocket;
		}
		set
		{
			_acceptSocket = value;
		}
	}

	public Socket? ConnectSocket => _connectSocket;

	public int BytesTransferred => _bytesTransferred;

	public SocketAsyncOperation LastOperation => _completedOperation;

	public IPPacketInformation ReceiveMessageFromPacketInfo => _receiveMessageFromPacketInfo;

	public EndPoint? RemoteEndPoint
	{
		get
		{
			return _remoteEndPoint;
		}
		set
		{
			_remoteEndPoint = value;
		}
	}

	public SocketError SocketError => _socketError;

	public SocketFlags SocketFlags
	{
		get
		{
			return _socketFlags;
		}
		set
		{
			_socketFlags = value;
		}
	}

	internal Activity? ConnectActivity
	{
		get
		{
			ConditionalWeakTable<SocketAsyncEventArgs, Activity> conditionalWeakTable = s_connectActivityTable;
			if (conditionalWeakTable == null || !conditionalWeakTable.TryGetValue(this, out var value))
			{
				return null;
			}
			return value;
		}
		set
		{
			if (value != null)
			{
				LazyInitializer.EnsureInitialized(ref s_connectActivityTable, () => new ConditionalWeakTable<SocketAsyncEventArgs, Activity>());
				s_connectActivityTable.AddOrUpdate(this, value);
			}
			else
			{
				s_connectActivityTable?.Remove(this);
			}
		}
	}

	internal bool HasMultipleBuffers => _bufferList != null;

	private Action<int, Memory<byte>, SocketFlags, SocketError> TransferCompletionCallback => TransferCompletionCallbackCore;

	public SocketAsyncEventArgs(bool unsafeSuppressExecutionContextFlow)
	{
		_flowExecutionContext = !unsafeSuppressExecutionContextFlow;
	}

	private void OnCompletedInternal()
	{
		if (LastOperation <= SocketAsyncOperation.Connect)
		{
			AfterConnectAcceptTelemetry();
		}
		OnCompleted(this);
	}

	protected virtual void OnCompleted(SocketAsyncEventArgs e)
	{
		Completed?.Invoke(e._currentSocket, e);
	}

	private void AfterConnectAcceptTelemetry()
	{
		switch (LastOperation)
		{
		case SocketAsyncOperation.Accept:
			SocketsTelemetry.Log.AfterAccept(SocketError);
			break;
		case SocketAsyncOperation.Connect:
			SocketsTelemetry.Log.AfterConnect(SocketError, ConnectActivity);
			ConnectActivity = null;
			break;
		}
	}

	internal void CopyBufferFrom(SocketAsyncEventArgs source)
	{
		StartConfiguring();
		try
		{
			_buffer = source._buffer;
			_offset = source._offset;
			_count = source._count;
			_bufferIsExplicitArray = source._bufferIsExplicitArray;
		}
		finally
		{
			Complete();
		}
	}

	public void SetBuffer(byte[]? buffer, int offset, int count)
	{
		StartConfiguring();
		try
		{
			if (buffer == null)
			{
				_buffer = default(Memory<byte>);
				_offset = 0;
				_count = 0;
				_bufferIsExplicitArray = false;
				return;
			}
			if (_bufferList != null)
			{
				throw new ArgumentException("net_ambiguousbuffers");
			}
			ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)offset, (uint)buffer.Length, "offset");
			ArgumentOutOfRangeException.ThrowIfGreaterThan<long>((uint)count, buffer.Length - offset, "count");
			_buffer = buffer;
			_offset = offset;
			_count = count;
			_bufferIsExplicitArray = true;
		}
		finally
		{
			Complete();
		}
	}

	public void SetBuffer(Memory<byte> buffer)
	{
		StartConfiguring();
		try
		{
			if (buffer.Length != 0 && _bufferList != null)
			{
				throw new ArgumentException("net_ambiguousbuffers");
			}
			_buffer = buffer;
			_offset = 0;
			_count = buffer.Length;
			_bufferIsExplicitArray = false;
		}
		finally
		{
			Complete();
		}
	}

	internal void SetResults(SocketError socketError, int bytesTransferred, SocketFlags flags)
	{
		_socketError = socketError;
		_connectByNameError = null;
		_bytesTransferred = bytesTransferred;
		_socketFlags = flags;
	}

	internal void SetResults(Exception exception, int bytesTransferred, SocketFlags flags)
	{
		_connectByNameError = exception;
		_bytesTransferred = bytesTransferred;
		_socketFlags = flags;
		if (exception == null)
		{
			_socketError = SocketError.Success;
		}
		else if (exception is SocketException ex)
		{
			_socketError = ex.SocketErrorCode;
		}
		else if (exception is OperationCanceledException)
		{
			_socketError = SocketError.OperationAborted;
		}
		else
		{
			_socketError = SocketError.SocketError;
		}
	}

	private static void ExecutionCallback(object state)
	{
		((SocketAsyncEventArgs)state).OnCompletedInternal();
	}

	internal void Complete()
	{
		_context = null;
		_operating = OperationState.Free;
		if (_disposeCalled)
		{
			Dispose();
		}
	}

	public void Dispose()
	{
		_disposeCalled = true;
		if (Interlocked.CompareExchange(ref _operating, OperationState.Disposed, OperationState.Free) == OperationState.Free)
		{
			GC.SuppressFinalize(this);
		}
	}

	~SocketAsyncEventArgs()
	{
		_ = 0;
	}

	private void StartConfiguring()
	{
		OperationState operationState = Interlocked.CompareExchange(ref _operating, OperationState.Configuring, OperationState.Free);
		if (operationState != OperationState.Free)
		{
			ThrowForNonFreeStatus(operationState);
		}
	}

	private void ThrowForNonFreeStatus(OperationState status)
	{
		ObjectDisposedException.ThrowIf(status == OperationState.Disposed, this);
		throw new InvalidOperationException("net_socketopinprogress");
	}

	internal void StartOperationCommon(Socket socket, SocketAsyncOperation operation)
	{
		OperationState operationState = Interlocked.CompareExchange(ref _operating, OperationState.InProgress, OperationState.Free);
		if (operationState != OperationState.Free)
		{
			ThrowForNonFreeStatus(operationState);
		}
		_completedOperation = operation;
		_currentSocket = socket;
		if (_flowExecutionContext || SocketsTelemetry.Log.IsEnabled())
		{
			_context = ExecutionContext.Capture();
		}
	}

	internal void StartOperationAccept()
	{
		_acceptAddressBufferCount = 2 * (Socket.GetAddressSize(_currentSocket._rightEndPoint) + 16);
		if (!_buffer.Equals(default(Memory<byte>)))
		{
			if (_count < _acceptAddressBufferCount)
			{
				throw new ArgumentException("net_buffercounttoosmall", "Count");
			}
		}
		else if (_acceptBuffer == null || _acceptBuffer.Length < _acceptAddressBufferCount)
		{
			_acceptBuffer = new byte[_acceptAddressBufferCount];
		}
	}

	internal void StartOperationConnect(bool saeaMultiConnectCancelable, bool userSocket)
	{
		_multipleConnectCancellation = (saeaMultiConnectCancelable ? new CancellationTokenSource() : null);
		_connectSocket = null;
		_userSocket = userSocket;
	}

	internal void FinishOperationSyncFailure(SocketError socketError, int bytesTransferred, SocketFlags flags)
	{
		SetResults(socketError, bytesTransferred, flags);
		Socket currentSocket = _currentSocket;
		if (currentSocket != null)
		{
			currentSocket.UpdateStatusAfterSocketError(socketError);
			if (_completedOperation == SocketAsyncOperation.Connect && !_userSocket)
			{
				currentSocket.Dispose();
				_currentSocket = null;
			}
		}
		_ = _completedOperation;
		_ = 8;
		Complete();
	}

	internal void FinishOperationAsyncFailure(SocketError socketError, int bytesTransferred, SocketFlags flags)
	{
		ExecutionContext context = _context;
		FinishOperationSyncFailure(socketError, bytesTransferred, flags);
		if (context == null)
		{
			OnCompletedInternal();
		}
		else
		{
			ExecutionContext.Run(context, s_executionCallback, this);
		}
	}

	internal bool DnsConnectAsync(DnsEndPoint endPoint, SocketType socketType, ProtocolType protocolType, CancellationToken cancellationToken)
	{
		if (_multipleConnectCancellation != null)
		{
			cancellationToken = _multipleConnectCancellation.Token;
		}
		Task<IPAddress[]> hostAddressesAsync = Dns.GetHostAddressesAsync(endPoint.Host, endPoint.AddressFamily, cancellationToken);
		MultiConnectSocketAsyncEventArgs e = new MultiConnectSocketAsyncEventArgs();
		e.CopyBufferFrom(this);
		Core(e, hostAddressesAsync, endPoint.Port, socketType, protocolType, cancellationToken);
		return e.ReachedCoordinationPointFirst();
		async Task Core(MultiConnectSocketAsyncEventArgs internalArgs, Task<IPAddress[]> addressesTask, int port, SocketType socketType2, ProtocolType protocolType2, CancellationToken cancellationToken2)
		{
			Socket tempSocketIPv4 = null;
			Socket tempSocketIPv6 = null;
			Exception caughtException = null;
			try
			{
				SocketError lastError = SocketError.NoData;
				IPAddress[] array = await addressesTask.ConfigureAwait(continueOnCapturedContext: false);
				foreach (IPAddress iPAddress in array)
				{
					Socket attemptSocket = null;
					if (_currentSocket != null)
					{
						if (!_currentSocket.CanTryAddressFamily(iPAddress.AddressFamily))
						{
							continue;
						}
						attemptSocket = _currentSocket;
					}
					else
					{
						if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
						{
							Socket socket = tempSocketIPv6;
							if (socket == null)
							{
								Socket socket2;
								tempSocketIPv6 = (socket2 = (Socket.OSSupportsIPv6 ? new Socket(AddressFamily.InterNetworkV6, socketType2, protocolType2) : null));
								socket = socket2;
							}
							attemptSocket = socket;
							if (attemptSocket != null && iPAddress.IsIPv4MappedToIPv6)
							{
								attemptSocket.DualMode = true;
							}
						}
						else if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
						{
							Socket socket3 = tempSocketIPv4;
							if (socket3 == null)
							{
								Socket socket2;
								tempSocketIPv4 = (socket2 = (Socket.OSSupportsIPv4 ? new Socket(AddressFamily.InterNetwork, socketType2, protocolType2) : null));
								socket3 = socket2;
							}
							attemptSocket = socket3;
						}
						if (attemptSocket == null)
						{
							continue;
						}
					}
					attemptSocket.ReplaceHandleIfNecessaryAfterFailedConnect();
					if (internalArgs.RemoteEndPoint is IPEndPoint iPEndPoint)
					{
						iPEndPoint.Address = iPAddress;
					}
					else
					{
						internalArgs.RemoteEndPoint = new IPEndPoint(iPAddress, port);
					}
					if (attemptSocket.ConnectAsync(internalArgs, userSocket: true, saeaMultiConnectCancelable: false, cancellationToken2))
					{
						await new ValueTask(internalArgs, internalArgs.Version).ConfigureAwait(continueOnCapturedContext: false);
					}
					if (internalArgs.SocketError == SocketError.Success)
					{
						return;
					}
					if (cancellationToken2.IsCancellationRequested)
					{
						lastError = SocketError.OperationAborted;
						break;
					}
					lastError = internalArgs.SocketError;
					if (!attemptSocket.CanProceedWithMultiConnect)
					{
						break;
					}
					internalArgs.Reset();
				}
				caughtException = new SocketException((int)lastError);
			}
			catch (ObjectDisposedException)
			{
				caughtException = new SocketException(995);
			}
			catch (Exception ex2)
			{
				caughtException = ex2;
			}
			finally
			{
				if (tempSocketIPv4 != null && !tempSocketIPv4.Connected)
				{
					tempSocketIPv4.Dispose();
				}
				if (tempSocketIPv6 != null && !tempSocketIPv6.Connected)
				{
					tempSocketIPv6.Dispose();
				}
				if (_currentSocket != null && ((!_userSocket && !_currentSocket.Connected) || caughtException is OperationCanceledException || caughtException is SocketException { SocketErrorCode: SocketError.OperationAborted }))
				{
					_currentSocket.Dispose();
				}
				if (caughtException != null)
				{
					SetResults(caughtException, 0, SocketFlags.None);
					_currentSocket?.UpdateStatusAfterSocketError(_socketError);
				}
				else
				{
					SetResults(SocketError.Success, internalArgs.BytesTransferred, internalArgs.SocketFlags);
					_connectSocket = (_currentSocket = internalArgs.ConnectSocket);
				}
				if (SocketsTelemetry.Log.IsEnabled())
				{
				}
				Complete();
				internalArgs.Dispose();
				if (!internalArgs.ReachedCoordinationPointFirst())
				{
					OnCompleted(this);
				}
			}
		}
	}

	internal void FinishOperationSyncSuccess(int bytesTransferred, SocketFlags flags)
	{
		SetResults(SocketError.Success, bytesTransferred, flags);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		switch (_completedOperation)
		{
		case SocketAsyncOperation.Accept:
		{
			SocketAddress socketAddress = _currentSocket._rightEndPoint.Serialize();
			SocketError socketError = FinishOperationAccept(socketAddress);
			if (socketError == SocketError.Success)
			{
				_acceptSocket = _currentSocket.UpdateAcceptSocket(_acceptSocket, _currentSocket._rightEndPoint.Create(socketAddress));
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
					break;
				}
			}
			SetResults(socketError, bytesTransferred, flags);
			_acceptSocket = null;
			_currentSocket.UpdateStatusAfterSocketError(socketError);
			break;
		}
		case SocketAsyncOperation.Connect:
		{
			SocketError socketError = SocketError.Success;
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			_currentSocket.SetToConnected();
			_connectSocket = _currentSocket;
			break;
		}
		case SocketAsyncOperation.Disconnect:
			_currentSocket.SetToDisconnected();
			_currentSocket._remoteEndPoint = null;
			break;
		case SocketAsyncOperation.ReceiveFrom:
			UpdateReceivedSocketAddress(_socketAddress);
			if (_remoteEndPoint == null)
			{
				_socketAddress = null;
			}
			else
			{
				if (System.Net.Sockets.SocketAddressExtensions.Equals(_socketAddress, _remoteEndPoint))
				{
					break;
				}
				try
				{
					if (_remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6 && _socketAddress.Family == AddressFamily.InterNetwork)
					{
						_remoteEndPoint = new IPEndPoint(_socketAddress.GetIPAddress().MapToIPv6(), _socketAddress.GetPort());
					}
					else
					{
						_remoteEndPoint = _remoteEndPoint.Create(_socketAddress);
					}
				}
				catch
				{
				}
			}
			break;
		case SocketAsyncOperation.ReceiveMessageFrom:
			UpdateReceivedSocketAddress(_socketAddress);
			if (System.Net.Sockets.SocketAddressExtensions.Equals(_socketAddress, _remoteEndPoint))
			{
				break;
			}
			try
			{
				if (_remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6 && _socketAddress.Family == AddressFamily.InterNetwork)
				{
					_remoteEndPoint = new IPEndPoint(_socketAddress.GetIPAddress().MapToIPv6(), _socketAddress.GetPort());
				}
				else
				{
					_remoteEndPoint = _remoteEndPoint.Create(_socketAddress);
				}
			}
			catch
			{
			}
			break;
		}
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		Complete();
	}

	internal void FinishOperationAsyncSuccess(int bytesTransferred, SocketFlags flags)
	{
		ExecutionContext context = _context;
		FinishOperationSyncSuccess(bytesTransferred, flags);
		if (context == null)
		{
			OnCompletedInternal();
		}
		else
		{
			ExecutionContext.Run(context, s_executionCallback, this);
		}
	}

	private void FinishOperationSync(SocketError socketError, int bytesTransferred, SocketFlags flags)
	{
		if (socketError == SocketError.Success)
		{
			FinishOperationSyncSuccess(bytesTransferred, flags);
		}
		else
		{
			FinishOperationSyncFailure(socketError, bytesTransferred, flags);
		}
		if (LastOperation <= SocketAsyncOperation.Connect)
		{
			AfterConnectAcceptTelemetry();
		}
	}

	private void AcceptCompletionCallback(nint acceptedFileDescriptor, Memory<byte> socketAddress, SocketError socketError)
	{
		CompleteAcceptOperation(acceptedFileDescriptor, socketAddress, socketError);
		CompletionCallback(0, SocketFlags.None, socketError);
	}

	private void CompleteAcceptOperation(nint acceptedFileDescriptor, Memory<byte> socketAddress, SocketError socketError)
	{
		_acceptedFileDescriptor = acceptedFileDescriptor;
		if (socketError == SocketError.Success)
		{
			_acceptAddressBufferCount = socketAddress.Length;
		}
		else
		{
			_acceptAddressBufferCount = 0;
		}
	}

	internal SocketError DoOperationAccept(Socket _, SafeSocketHandle handle, SafeSocketHandle acceptHandle, CancellationToken cancellationToken)
	{
		if (!_buffer.Equals(default(Memory<byte>)))
		{
			throw new PlatformNotSupportedException("net_sockets_accept_receive_notsupported");
		}
		_acceptedFileDescriptor = -1;
		int socketAddressLen;
		nint acceptedFd;
		SocketError socketError = handle.AsyncContext.AcceptAsync(_acceptBuffer, out socketAddressLen, out acceptedFd, AcceptCompletionCallback, cancellationToken);
		if (socketError != SocketError.IOPending)
		{
			CompleteAcceptOperation(acceptedFd, new Memory<byte>(_acceptBuffer, 0, socketAddressLen), socketError);
			FinishOperationSync(socketError, 0, SocketFlags.None);
		}
		return socketError;
	}

	private void ConnectCompletionCallback(int bytesTransferred, Memory<byte> socketAddress, SocketFlags receivedFlags, SocketError socketError)
	{
		CompletionCallback(bytesTransferred, SocketFlags.None, socketError);
	}

	internal SocketError DoOperationConnectEx(Socket _, SafeSocketHandle handle, CancellationToken cancellationToken)
	{
		int sentBytes;
		SocketError socketError = handle.AsyncContext.ConnectAsync(_socketAddress.Buffer, ConnectCompletionCallback, _buffer.Slice(_offset, _count), out sentBytes, cancellationToken);
		if (socketError != SocketError.IOPending)
		{
			FinishOperationSync(socketError, sentBytes, SocketFlags.None);
		}
		return socketError;
	}

	internal SocketError DoOperationConnect(SafeSocketHandle handle, CancellationToken cancellationToken)
	{
		int sentBytes;
		SocketError socketError = handle.AsyncContext.ConnectAsync(_socketAddress.Buffer, ConnectCompletionCallback, Memory<byte>.Empty, out sentBytes, cancellationToken);
		if (socketError != SocketError.IOPending)
		{
			FinishOperationSync(socketError, 0, SocketFlags.None);
		}
		return socketError;
	}

	private void TransferCompletionCallbackCore(int bytesTransferred, Memory<byte> socketAddress, SocketFlags receivedFlags, SocketError socketError)
	{
		CompleteTransferOperation(socketAddress, socketAddress.Length, receivedFlags);
		CompletionCallback(bytesTransferred, receivedFlags, socketError);
	}

	private void CompleteTransferOperation(Memory<byte> _, int socketAddressSize, SocketFlags receivedFlags)
	{
		_socketAddressSize = socketAddressSize;
		_receivedFlags = receivedFlags;
	}

	internal SocketError DoOperationReceive(SafeSocketHandle handle, CancellationToken cancellationToken)
	{
		_receivedFlags = SocketFlags.None;
		_socketAddressSize = 0;
		SocketError socketError;
		int bytesReceived;
		SocketFlags receivedFlags;
		if (_bufferList == null)
		{
			if (_currentSocket.ProtocolType == ProtocolType.Tcp)
			{
				socketError = handle.AsyncContext.ReceiveAsync(_buffer.Slice(_offset, _count), _socketFlags, out bytesReceived, TransferCompletionCallback, cancellationToken);
				receivedFlags = SocketFlags.None;
			}
			else
			{
				socketError = handle.AsyncContext.ReceiveAsync(_buffer.Slice(_offset, _count), _socketFlags, out bytesReceived, out receivedFlags, TransferCompletionCallback, cancellationToken);
			}
		}
		else
		{
			socketError = handle.AsyncContext.ReceiveAsync(_bufferListInternal, _socketFlags, out bytesReceived, out receivedFlags, TransferCompletionCallback);
		}
		if (socketError != SocketError.IOPending)
		{
			CompleteTransferOperation(null, 0, receivedFlags);
			FinishOperationSync(socketError, bytesReceived, receivedFlags);
		}
		return socketError;
	}

	internal SocketError DoOperationSend(SafeSocketHandle handle, CancellationToken cancellationToken)
	{
		_receivedFlags = SocketFlags.None;
		_socketAddressSize = 0;
		int bytesSent;
		SocketError socketError = ((_bufferList != null) ? handle.AsyncContext.SendAsync(_bufferListInternal, _socketFlags, out bytesSent, TransferCompletionCallback) : handle.AsyncContext.SendAsync(_buffer, _offset, _count, _socketFlags, out bytesSent, TransferCompletionCallback, cancellationToken));
		if (socketError != SocketError.IOPending)
		{
			CompleteTransferOperation(null, 0, SocketFlags.None);
			FinishOperationSync(socketError, bytesSent, SocketFlags.None);
		}
		return socketError;
	}

	private SocketError FinishOperationAccept(SocketAddress remoteSocketAddress)
	{
		new ReadOnlySpan<byte>(_acceptBuffer, 0, _acceptAddressBufferCount).CopyTo(remoteSocketAddress.Buffer.Span);
		remoteSocketAddress.Size = _acceptAddressBufferCount;
		Socket socket = _currentSocket.CreateAcceptSocket(SocketPal.CreateSocket(_acceptedFileDescriptor), (remoteSocketAddress.Size > 0) ? _currentSocket._rightEndPoint.Create(remoteSocketAddress) : null);
		if (_acceptSocket == null)
		{
			_acceptSocket = socket;
		}
		else
		{
			_acceptSocket.DisposeHandle();
			_acceptSocket.CopyStateFromSource(socket);
			socket.ClearHandle();
			socket.Dispose();
		}
		return SocketError.Success;
	}

	private void UpdateReceivedSocketAddress(SocketAddress socketAddress)
	{
		socketAddress.Size = _socketAddressSize;
	}

	private void CompletionCallback(int bytesTransferred, SocketFlags flags, SocketError socketError)
	{
		if (socketError == SocketError.Success)
		{
			FinishOperationAsyncSuccess(bytesTransferred, flags);
			return;
		}
		if (_currentSocket.Disposed)
		{
			socketError = SocketError.OperationAborted;
		}
		FinishOperationAsyncFailure(socketError, bytesTransferred, flags);
	}
}
