using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace System.Net.Sockets;

public class Socket : IDisposable
{
	private sealed class TaskSocketAsyncEventArgs<TResult> : SocketAsyncEventArgs
	{
	}

	internal sealed class AwaitableSocketAsyncEventArgs : SocketAsyncEventArgs, IValueTaskSource, IValueTaskSource<int>, IValueTaskSource<Socket>, IValueTaskSource<SocketReceiveFromResult>, IValueTaskSource<SocketReceiveMessageFromResult>
	{
		private readonly Socket _owner;

		private readonly bool _isReadForCaching;

		private ManualResetValueTaskSourceCore<bool> _mrvtsc;

		private CancellationToken _cancellationToken;

		public bool WrapExceptionsForNetworkStream { get; set; }

		public AwaitableSocketAsyncEventArgs(Socket owner, bool isReceiveForCaching)
			: base(unsafeSuppressExecutionContextFlow: true)
		{
			_owner = owner;
			_isReadForCaching = isReceiveForCaching;
		}

		private void ReleaseForAsyncCompletion()
		{
			_cancellationToken = default(CancellationToken);
			_mrvtsc.Reset();
			ReleaseForSyncCompletion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ReleaseForSyncCompletion()
		{
			if (Interlocked.CompareExchange(ref _isReadForCaching ? ref _owner._singleBufferReceiveEventArgs : ref _owner._singleBufferSendEventArgs, this, null) != null)
			{
				Dispose();
			}
		}

		protected override void OnCompleted(SocketAsyncEventArgs _)
		{
			_mrvtsc.SetResult(result: true);
		}

		public ValueTask<Socket> AcceptAsync(Socket socket, CancellationToken cancellationToken)
		{
			if (socket.AcceptAsync(this, cancellationToken))
			{
				_cancellationToken = cancellationToken;
				return new ValueTask<Socket>(this, _mrvtsc.Version);
			}
			Socket acceptSocket = base.AcceptSocket;
			SocketError socketError = base.SocketError;
			base.AcceptSocket = null;
			ReleaseForSyncCompletion();
			if (socketError != SocketError.Success)
			{
				return ValueTask.FromException<Socket>(CreateException(socketError));
			}
			return new ValueTask<Socket>(acceptSocket);
		}

		public ValueTask<int> ReceiveAsync(Socket socket, CancellationToken cancellationToken)
		{
			if (socket.ReceiveAsync(this, cancellationToken))
			{
				_cancellationToken = cancellationToken;
				return new ValueTask<int>(this, _mrvtsc.Version);
			}
			int bytesTransferred = base.BytesTransferred;
			SocketError socketError = base.SocketError;
			ReleaseForSyncCompletion();
			if (socketError != SocketError.Success)
			{
				return ValueTask.FromException<int>(CreateException(socketError));
			}
			return new ValueTask<int>(bytesTransferred);
		}

		public ValueTask<int> SendAsync(Socket socket, CancellationToken cancellationToken)
		{
			if (socket.SendAsync(this, cancellationToken))
			{
				_cancellationToken = cancellationToken;
				return new ValueTask<int>(this, _mrvtsc.Version);
			}
			int bytesTransferred = base.BytesTransferred;
			SocketError socketError = base.SocketError;
			ReleaseForSyncCompletion();
			if (socketError != SocketError.Success)
			{
				return ValueTask.FromException<int>(CreateException(socketError));
			}
			return new ValueTask<int>(bytesTransferred);
		}

		public ValueTask SendAsyncForNetworkStream(Socket socket, CancellationToken cancellationToken)
		{
			if (socket.SendAsync(this, cancellationToken))
			{
				_cancellationToken = cancellationToken;
				return new ValueTask(this, _mrvtsc.Version);
			}
			SocketError socketError = base.SocketError;
			ReleaseForSyncCompletion();
			if (socketError != SocketError.Success)
			{
				return ValueTask.FromException(CreateException(socketError));
			}
			return default(ValueTask);
		}

		public ValueTask ConnectAsync(Socket socket, CancellationToken cancellationToken)
		{
			try
			{
				if (socket.ConnectAsync(this, userSocket: true, saeaMultiConnectCancelable: false, cancellationToken))
				{
					_cancellationToken = cancellationToken;
					return new ValueTask(this, _mrvtsc.Version);
				}
			}
			catch
			{
				ReleaseForSyncCompletion();
				throw;
			}
			SocketError socketError = base.SocketError;
			ReleaseForSyncCompletion();
			if (socketError != SocketError.Success)
			{
				return ValueTask.FromException(CreateException(socketError));
			}
			return default(ValueTask);
		}

		public ValueTaskSourceStatus GetStatus(short token)
		{
			return _mrvtsc.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_mrvtsc.OnCompleted(continuation, state, token, flags);
		}

		int IValueTaskSource<int>.GetResult(short token)
		{
			if (token != _mrvtsc.Version)
			{
				ThrowIncorrectTokenException();
			}
			SocketError socketError = base.SocketError;
			int bytesTransferred = base.BytesTransferred;
			CancellationToken cancellationToken = _cancellationToken;
			ReleaseForAsyncCompletion();
			if (socketError != SocketError.Success)
			{
				ThrowException(socketError, cancellationToken);
			}
			return bytesTransferred;
		}

		void IValueTaskSource.GetResult(short token)
		{
			if (token != _mrvtsc.Version)
			{
				ThrowIncorrectTokenException();
			}
			SocketError socketError = base.SocketError;
			CancellationToken cancellationToken = _cancellationToken;
			ReleaseForAsyncCompletion();
			if (socketError != SocketError.Success)
			{
				ThrowException(socketError, cancellationToken);
			}
		}

		Socket IValueTaskSource<Socket>.GetResult(short token)
		{
			if (token != _mrvtsc.Version)
			{
				ThrowIncorrectTokenException();
			}
			SocketError socketError = base.SocketError;
			Socket? acceptSocket = base.AcceptSocket;
			CancellationToken cancellationToken = _cancellationToken;
			base.AcceptSocket = null;
			ReleaseForAsyncCompletion();
			if (socketError != SocketError.Success)
			{
				ThrowException(socketError, cancellationToken);
			}
			return acceptSocket;
		}

		SocketReceiveFromResult IValueTaskSource<SocketReceiveFromResult>.GetResult(short token)
		{
			if (token != _mrvtsc.Version)
			{
				ThrowIncorrectTokenException();
			}
			SocketError socketError = base.SocketError;
			int bytesTransferred = base.BytesTransferred;
			EndPoint remoteEndPoint = base.RemoteEndPoint;
			CancellationToken cancellationToken = _cancellationToken;
			ReleaseForAsyncCompletion();
			if (socketError != SocketError.Success)
			{
				ThrowException(socketError, cancellationToken);
			}
			return new SocketReceiveFromResult
			{
				ReceivedBytes = bytesTransferred,
				RemoteEndPoint = remoteEndPoint
			};
		}

		SocketReceiveMessageFromResult IValueTaskSource<SocketReceiveMessageFromResult>.GetResult(short token)
		{
			if (token != _mrvtsc.Version)
			{
				ThrowIncorrectTokenException();
			}
			SocketError socketError = base.SocketError;
			int bytesTransferred = base.BytesTransferred;
			EndPoint remoteEndPoint = base.RemoteEndPoint;
			SocketFlags socketFlags = base.SocketFlags;
			IPPacketInformation receiveMessageFromPacketInfo = base.ReceiveMessageFromPacketInfo;
			CancellationToken cancellationToken = _cancellationToken;
			ReleaseForAsyncCompletion();
			if (socketError != SocketError.Success)
			{
				ThrowException(socketError, cancellationToken);
			}
			return new SocketReceiveMessageFromResult
			{
				ReceivedBytes = bytesTransferred,
				RemoteEndPoint = remoteEndPoint,
				SocketFlags = socketFlags,
				PacketInformation = receiveMessageFromPacketInfo
			};
		}

		private static void ThrowIncorrectTokenException()
		{
			throw new InvalidOperationException("InvalidOperation_IncorrectToken");
		}

		private void ThrowException(SocketError error, CancellationToken cancellationToken)
		{
			if ((error == SocketError.OperationAborted || error == SocketError.ConnectionAborted) ? true : false)
			{
				cancellationToken.ThrowIfCancellationRequested();
			}
			throw CreateException(error, forAsyncThrow: false);
		}

		private Exception CreateException(SocketError error, bool forAsyncThrow = true)
		{
			Exception ex = new SocketException((int)error);
			if (forAsyncThrow)
			{
				ex = ExceptionDispatchInfo.SetCurrentStackTrace(ex);
			}
			if (!WrapExceptionsForNetworkStream)
			{
				return ex;
			}
			return new IOException(System.SR.Format(_isReadForCaching ? "net_io_readfailure" : "net_io_writefailure", ex.Message), ex);
		}
	}

	private static readonly IPAddress s_IPAddressAnyMapToIPv6 = IPAddress.Any.MapToIPv6();

	private static readonly IPEndPoint s_IPEndPointIPv6 = new IPEndPoint(s_IPAddressAnyMapToIPv6, 0);

	private SafeSocketHandle _handle;

	internal EndPoint _rightEndPoint;

	internal EndPoint _remoteEndPoint;

	private EndPoint _localEndPoint;

	private bool _isConnected;

	private bool _isDisconnected;

	private bool _willBlock = 0 == 0;

	private bool _willBlockInternal = 0 == 0;

	private bool _isListening;

	private bool _nonBlockingConnectInProgress;

	private EndPoint _pendingConnectRightEndPoint;

	private AddressFamily _addressFamily;

	private SocketType _socketType;

	private ProtocolType _protocolType;

	private bool _receivingPacketInformation = false;

	private int _closeTimeout = -1;

	private bool _disposed;

	private AwaitableSocketAsyncEventArgs _singleBufferReceiveEventArgs;

	private AwaitableSocketAsyncEventArgs _singleBufferSendEventArgs;

	private TaskSocketAsyncEventArgs<int> _multiBufferReceiveEventArgs;

	private TaskSocketAsyncEventArgs<int> _multiBufferSendEventArgs;

	public static bool OSSupportsIPv4 => System.Net.SocketProtocolSupportPal.OSSupportsIPv4;

	public static bool OSSupportsIPv6 => System.Net.SocketProtocolSupportPal.OSSupportsIPv6;

	[UnsupportedOSPlatformGuard("wasi")]
	internal static bool OSSupportsIPv6DualMode
	{
		get
		{
			_ = 0;
			return OSSupportsIPv6;
		}
	}

	public static bool OSSupportsUnixDomainSockets => System.Net.SocketProtocolSupportPal.OSSupportsUnixDomainSockets;

	public unsafe EndPoint? LocalEndPoint
	{
		get
		{
			ThrowIfDisposed();
			CheckNonBlockingConnectCompleted();
			if (_rightEndPoint == null)
			{
				return null;
			}
			if (_localEndPoint == null)
			{
				Span<byte> span = stackalloc byte[SocketAddress.GetMaximumAddressSize(_addressFamily)];
				int length = span.Length;
				fixed (byte* reference = &MemoryMarshal.GetReference(span))
				{
					SocketError sockName = SocketPal.GetSockName(_handle, reference, &length);
					if (sockName != SocketError.Success)
					{
						UpdateStatusAfterSocketErrorAndThrowException(sockName, disconnectOnFailure: true, "LocalEndPoint");
					}
				}
				if (_addressFamily == AddressFamily.InterNetwork || _addressFamily == AddressFamily.InterNetworkV6)
				{
					_localEndPoint = System.Net.Sockets.IPEndPointExtensions.CreateIPEndPoint(span.Slice(0, length));
				}
				else
				{
					SocketAddress socketAddress = new SocketAddress(_rightEndPoint.AddressFamily, length);
					span.Slice(0, length).CopyTo(socketAddress.Buffer.Span);
					_localEndPoint = _rightEndPoint.Create(socketAddress);
				}
			}
			return _localEndPoint;
		}
	}

	public EndPoint? RemoteEndPoint
	{
		get
		{
			ThrowIfDisposed();
			if (_remoteEndPoint == null)
			{
				CheckNonBlockingConnectCompleted();
				if (_rightEndPoint == null || !_isConnected)
				{
					return null;
				}
				Span<byte> buffer = stackalloc byte[SocketAddress.GetMaximumAddressSize(_addressFamily)];
				int nameLen = buffer.Length;
				SocketError peerName = SocketPal.GetPeerName(_handle, buffer, ref nameLen);
				if (peerName != SocketError.Success)
				{
					UpdateStatusAfterSocketErrorAndThrowException(peerName, disconnectOnFailure: true, "RemoteEndPoint");
				}
				try
				{
					if (_addressFamily == AddressFamily.InterNetwork || _addressFamily == AddressFamily.InterNetworkV6)
					{
						_remoteEndPoint = System.Net.Sockets.IPEndPointExtensions.CreateIPEndPoint(buffer.Slice(0, nameLen));
					}
					else
					{
						SocketAddress socketAddress = new SocketAddress(_rightEndPoint.AddressFamily, nameLen);
						buffer.Slice(0, nameLen).CopyTo(socketAddress.Buffer.Span);
						_remoteEndPoint = _rightEndPoint.Create(socketAddress);
					}
				}
				catch
				{
				}
			}
			return _remoteEndPoint;
		}
	}

	public bool Blocking => _willBlock;

	public bool Connected
	{
		get
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			CheckNonBlockingConnectCompleted();
			return _isConnected;
		}
	}

	public AddressFamily AddressFamily => _addressFamily;

	public SocketType SocketType => _socketType;

	public ProtocolType ProtocolType => _protocolType;

	public int ReceiveBufferSize
	{
		set
		{
			ArgumentOutOfRangeException.ThrowIfNegative(value, "value");
			SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, value);
		}
	}

	public int ReceiveTimeout
	{
		set
		{
			if (false)
			{
			}
			ArgumentOutOfRangeException.ThrowIfLessThan(value, -1, "value");
			if (value == -1)
			{
				value = 0;
			}
			SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, value);
		}
	}

	public int SendTimeout
	{
		set
		{
			if (false)
			{
			}
			ArgumentOutOfRangeException.ThrowIfLessThan(value, -1, "value");
			if (value == -1)
			{
				value = 0;
			}
			SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, value);
		}
	}

	public bool NoDelay
	{
		set
		{
			SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, value ? 1 : 0);
		}
	}

	public bool DualMode
	{
		get
		{
			if (AddressFamily != AddressFamily.InterNetworkV6)
			{
				return false;
			}
			if (false)
			{
			}
			return (int)GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only) == 0;
		}
		set
		{
			if (AddressFamily != AddressFamily.InterNetworkV6)
			{
				throw new NotSupportedException("net_invalidversion");
			}
			if ((0u & (value ? 1u : 0u)) != 0)
			{
				throw new PlatformNotSupportedException();
			}
			SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, (!value) ? 1 : 0);
		}
	}

	private bool IsDualMode
	{
		get
		{
			if (AddressFamily == AddressFamily.InterNetworkV6)
			{
				return DualMode;
			}
			return false;
		}
	}

	internal bool Disposed => _disposed;

	private bool IsConnectionOriented => _socketType == SocketType.Stream;

	internal bool PreferInlineCompletions
	{
		set
		{
			_handle.PreferInlineCompletions = value;
		}
	}

	internal bool CanProceedWithMultiConnect => !_handle.ExposedHandleOrUntrackedConfiguration;

	public Socket(SocketType socketType, ProtocolType protocolType)
		: this(OSSupportsIPv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork, socketType, protocolType)
	{
		if (OSSupportsIPv6DualMode)
		{
			DualMode = true;
		}
	}

	public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		SocketError socketError = SocketPal.CreateSocket(addressFamily, socketType, protocolType, out _handle);
		if (socketError != SocketError.Success)
		{
			throw new SocketException((int)socketError);
		}
		_addressFamily = addressFamily;
		_socketType = socketType;
		_protocolType = protocolType;
	}

	private unsafe Socket(SafeSocketHandle handle, bool loadPropertiesFromHandle)
	{
		_handle = handle;
		_addressFamily = AddressFamily.Unknown;
		_socketType = SocketType.Unknown;
		_protocolType = ProtocolType.Unknown;
		if (!loadPropertiesFromHandle)
		{
			return;
		}
		try
		{
			LoadSocketTypeFromHandle(handle, out _addressFamily, out _socketType, out _protocolType, out _willBlockInternal, out _isListening, out var isSocket);
			if (!isSocket)
			{
				return;
			}
			Span<byte> span = stackalloc byte[SocketPal.MaximumAddressSize];
			int nameLen = span.Length;
			fixed (byte* buffer = span)
			{
				if (SocketPal.GetSockName(handle, buffer, &nameLen) != SocketError.Success)
				{
					return;
				}
			}
			switch (_addressFamily)
			{
			case AddressFamily.InterNetwork:
				_rightEndPoint = new IPEndPoint(new IPAddress((long)System.Net.SocketAddressPal.GetIPv4Address(span.Slice(0, nameLen)) & 0xFFFFFFFFL), System.Net.SocketAddressPal.GetPort(span));
				break;
			case AddressFamily.InterNetworkV6:
			{
				Span<byte> span2 = stackalloc byte[16];
				System.Net.SocketAddressPal.GetIPv6Address(span.Slice(0, nameLen), span2, out var scope);
				_rightEndPoint = new IPEndPoint(new IPAddress(span2, scope), System.Net.SocketAddressPal.GetPort(span));
				break;
			}
			case AddressFamily.Unix:
				if (!OSSupportsUnixDomainSockets)
				{
					throw new PlatformNotSupportedException();
				}
				_rightEndPoint = new UnixDomainSocketEndPoint(span.Slice(0, nameLen));
				break;
			}
			if (_rightEndPoint == null)
			{
				return;
			}
			try
			{
				nameLen = span.Length;
				switch (SocketPal.GetPeerName(handle, span, ref nameLen))
				{
				case SocketError.Success:
					switch (_addressFamily)
					{
					case AddressFamily.InterNetwork:
						_remoteEndPoint = new IPEndPoint(new IPAddress((long)System.Net.SocketAddressPal.GetIPv4Address(span.Slice(0, nameLen)) & 0xFFFFFFFFL), System.Net.SocketAddressPal.GetPort(span));
						break;
					case AddressFamily.InterNetworkV6:
					{
						Span<byte> span3 = stackalloc byte[16];
						System.Net.SocketAddressPal.GetIPv6Address(span.Slice(0, nameLen), span3, out var scope2);
						_remoteEndPoint = new IPEndPoint(new IPAddress(span3, scope2), System.Net.SocketAddressPal.GetPort(span));
						break;
					}
					case AddressFamily.Unix:
						if (!OSSupportsUnixDomainSockets)
						{
							throw new PlatformNotSupportedException();
						}
						_remoteEndPoint = new UnixDomainSocketEndPoint(span.Slice(0, nameLen));
						break;
					}
					_isConnected = true;
					break;
				case SocketError.InvalidArgument:
					_isConnected = true;
					break;
				}
			}
			catch
			{
			}
		}
		catch
		{
			_handle = null;
			GC.SuppressFinalize(this);
			throw;
		}
	}

	internal bool CanTryAddressFamily(AddressFamily family)
	{
		if (family != _addressFamily)
		{
			if (family == AddressFamily.InterNetwork)
			{
				return IsDualMode;
			}
			return false;
		}
		return true;
	}

	public void Bind(EndPoint localEP)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(localEP, "localEP");
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		SocketAddress socketAddress = Serialize(ref localEP);
		DoBind(localEP, socketAddress);
	}

	private void DoBind(EndPoint endPointSnapshot, SocketAddress socketAddress)
	{
		IPEndPoint iPEndPoint = endPointSnapshot as IPEndPoint;
		if (!OSSupportsIPv4 && iPEndPoint != null && iPEndPoint.Address.IsIPv4MappedToIPv6)
		{
			UpdateStatusAfterSocketErrorAndThrowException(SocketError.InvalidArgument, disconnectOnFailure: true, "DoBind");
		}
		SocketError socketError = SocketPal.Bind(_handle, _protocolType, socketAddress.Buffer.Span.Slice(0, socketAddress.Size));
		if (socketError != SocketError.Success)
		{
			UpdateStatusAfterSocketErrorAndThrowException(socketError, disconnectOnFailure: true, "DoBind");
		}
		_rightEndPoint = ((endPointSnapshot is UnixDomainSocketEndPoint unixDomainSocketEndPoint) ? unixDomainSocketEndPoint.CreateBoundEndPoint() : endPointSnapshot);
	}

	public void Connect(EndPoint remoteEP)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(remoteEP, "remoteEP");
		if (_isDisconnected)
		{
			throw new InvalidOperationException("net_sockets_disconnectedConnect");
		}
		if (_isListening)
		{
			throw new InvalidOperationException("net_sockets_mustnotlisten");
		}
		ThrowIfConnectedStreamSocket();
		ValidateBlockingMode();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		ValidateForMultiConnect();
		if (remoteEP is DnsEndPoint dnsEndPoint)
		{
			if (dnsEndPoint.AddressFamily != AddressFamily.Unspecified && !CanTryAddressFamily(dnsEndPoint.AddressFamily))
			{
				throw new NotSupportedException("net_invalidversion");
			}
			Connect(dnsEndPoint.Host, dnsEndPoint.Port);
		}
		else
		{
			SocketAddress socketAddress = Serialize(ref remoteEP);
			_pendingConnectRightEndPoint = remoteEP;
			_nonBlockingConnectInProgress = !Blocking;
			DoConnect(remoteEP, socketAddress);
		}
	}

	public void Connect(IPAddress address, int port)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(address, "address");
		if (!System.Net.TcpValidationHelpers.ValidatePortNumber(port))
		{
			throw new ArgumentOutOfRangeException("port");
		}
		ThrowIfConnectedStreamSocket();
		ValidateForMultiConnect();
		if (!CanTryAddressFamily(address.AddressFamily))
		{
			throw new NotSupportedException("net_invalidversion");
		}
		IPEndPoint remoteEP = new IPEndPoint(address, port);
		Connect(remoteEP);
	}

	public void Connect(string host, int port)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(host, "host");
		if (!System.Net.TcpValidationHelpers.ValidatePortNumber(port))
		{
			throw new ArgumentOutOfRangeException("port");
		}
		if (_addressFamily != AddressFamily.InterNetwork && _addressFamily != AddressFamily.InterNetworkV6)
		{
			throw new NotSupportedException("net_invalidversion");
		}
		if (IPAddress.TryParse(host, out IPAddress address))
		{
			Connect(address, port);
			return;
		}
		IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
		Connect(hostAddresses, port);
	}

	public void Connect(IPAddress[] addresses, int port)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(addresses, "addresses");
		if (addresses.Length == 0)
		{
			throw new ArgumentException("net_sockets_invalid_ipaddress_length", "addresses");
		}
		if (!System.Net.TcpValidationHelpers.ValidatePortNumber(port))
		{
			throw new ArgumentOutOfRangeException("port");
		}
		if (_addressFamily != AddressFamily.InterNetwork && _addressFamily != AddressFamily.InterNetworkV6)
		{
			throw new NotSupportedException("net_invalidversion");
		}
		ThrowIfConnectedStreamSocket();
		ValidateForMultiConnect();
		ExceptionDispatchInfo exceptionDispatchInfo = null;
		foreach (IPAddress iPAddress in addresses)
		{
			if (CanTryAddressFamily(iPAddress.AddressFamily))
			{
				try
				{
					Connect(new IPEndPoint(iPAddress, port));
					exceptionDispatchInfo = null;
				}
				catch (Exception ex) when (CanProceedWithMultiConnect && !ExceptionCheck.IsFatal(ex))
				{
					exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
					continue;
				}
				break;
			}
		}
		exceptionDispatchInfo?.Throw();
		if (!Connected)
		{
			throw new ArgumentException("net_invalidAddressList", "addresses");
		}
	}

	public void Close()
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		Dispose();
	}

	public void Close(int timeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(timeout, -1, "timeout");
		_closeTimeout = timeout;
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		Dispose();
	}

	public void Listen(int backlog)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		ThrowIfDisposed();
		SocketError socketError = SocketPal.Listen(_handle, backlog);
		if (socketError != SocketError.Success)
		{
			UpdateStatusAfterSocketErrorAndThrowException(socketError, disconnectOnFailure: true, "Listen");
		}
		_isListening = true;
	}

	public Socket Accept()
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		if (_rightEndPoint == null)
		{
			throw new InvalidOperationException("net_sockets_mustbind");
		}
		if (!_isListening)
		{
			throw new InvalidOperationException("net_sockets_mustlisten");
		}
		if (_isDisconnected)
		{
			throw new InvalidOperationException("net_sockets_disconnectedAccept");
		}
		ValidateBlockingMode();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		SocketAddress socketAddress = new SocketAddress(_addressFamily);
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		SocketError socketError;
		SafeSocketHandle socket;
		try
		{
			socketError = SocketPal.Accept(_handle, socketAddress.Buffer, out var socketAddressLen, out socket);
			socketAddress.Size = socketAddressLen;
		}
		catch (Exception ex)
		{
			SocketsTelemetry.Log.AfterAccept(SocketError.Interrupted, ex.Message);
			throw;
		}
		if (socketError != SocketError.Success)
		{
			UpdateAcceptSocketErrorForDisposed(ref socketError);
			SocketsTelemetry.Log.AfterAccept(socketError);
			socket.Dispose();
			UpdateStatusAfterSocketErrorAndThrowException(socketError, disconnectOnFailure: true, "Accept");
		}
		SocketsTelemetry.Log.AfterAccept(SocketError.Success);
		Socket result = CreateAcceptSocket(socket, _rightEndPoint.Create(socketAddress));
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return result;
	}

	public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
	{
		if (1 == 0)
		{
		}
		SocketError errorCode;
		int result = Send(buffer, offset, size, socketFlags, out errorCode);
		if (errorCode != SocketError.Success)
		{
			throw new SocketException((int)errorCode);
		}
		return result;
	}

	public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBufferArguments(buffer, offset, size);
		ValidateBlockingMode();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		errorCode = SocketPal.Send(_handle, buffer, offset, size, socketFlags, out var bytesTransferred);
		if (errorCode != SocketError.Success)
		{
			UpdateSendSocketErrorForDisposed(ref errorCode);
			UpdateStatusAfterSocketError(errorCode);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return 0;
		}
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return bytesTransferred;
	}

	public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags)
	{
		if (1 == 0)
		{
		}
		SocketError errorCode;
		int result = Send(buffer, socketFlags, out errorCode);
		if (errorCode != SocketError.Success)
		{
			throw new SocketException((int)errorCode);
		}
		return result;
	}

	public int Send(ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBlockingMode();
		errorCode = SocketPal.Send(_handle, buffer, socketFlags, out var bytesTransferred);
		if (errorCode != SocketError.Success)
		{
			UpdateSendSocketErrorForDisposed(ref errorCode);
			UpdateStatusAfterSocketError(errorCode);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return 0;
		}
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		return bytesTransferred;
	}

	public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags)
	{
		if (1 == 0)
		{
		}
		SocketError errorCode;
		int result = Receive(buffer, offset, size, socketFlags, out errorCode);
		if (errorCode != SocketError.Success)
		{
			throw new SocketException((int)errorCode);
		}
		return result;
	}

	public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBufferArguments(buffer, offset, size);
		ValidateBlockingMode();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		errorCode = SocketPal.Receive(_handle, buffer, offset, size, socketFlags, out var bytesTransferred);
		UpdateReceiveSocketErrorForDisposed(ref errorCode, bytesTransferred);
		if (errorCode != SocketError.Success)
		{
			UpdateStatusAfterSocketError(errorCode);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return 0;
		}
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return bytesTransferred;
	}

	public int Receive(Span<byte> buffer, SocketFlags socketFlags)
	{
		if (1 == 0)
		{
		}
		SocketError errorCode;
		int result = Receive(buffer, socketFlags, out errorCode);
		if (errorCode != SocketError.Success)
		{
			throw new SocketException((int)errorCode);
		}
		return result;
	}

	public int Receive(Span<byte> buffer, SocketFlags socketFlags, out SocketError errorCode)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBlockingMode();
		errorCode = SocketPal.Receive(_handle, buffer, socketFlags, out var bytesTransferred);
		UpdateReceiveSocketErrorForDisposed(ref errorCode, bytesTransferred);
		if (errorCode != SocketError.Success)
		{
			UpdateStatusAfterSocketError(errorCode);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return 0;
		}
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		return bytesTransferred;
	}

	public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
	{
		ThrowIfDisposed();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		SetSocketOption(optionLevel, optionName, optionValue, silent: false);
	}

	public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
	{
		SetSocketOption(optionLevel, optionName, optionValue ? 1 : 0);
	}

	public object? GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName)
	{
		ThrowIfDisposed();
		if (optionLevel == SocketOptionLevel.Socket && optionName == SocketOptionName.Linger)
		{
			return GetLingerOpt();
		}
		if (optionLevel == SocketOptionLevel.IP && (optionName == SocketOptionName.AddMembership || optionName == SocketOptionName.DropMembership))
		{
			return GetMulticastOpt(optionName);
		}
		if (optionLevel == SocketOptionLevel.IPv6 && (optionName == SocketOptionName.AddMembership || optionName == SocketOptionName.DropMembership))
		{
			return GetIPv6MulticastOpt(optionName);
		}
		int optionValue;
		SocketError sockOpt = SocketPal.GetSockOpt(_handle, optionLevel, optionName, out optionValue);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (sockOpt != SocketError.Success)
		{
			UpdateStatusAfterSocketOptionErrorAndThrowException(sockOpt, "GetSocketOption");
		}
		return optionValue;
	}

	public bool Poll(int microSeconds, SelectMode mode)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		bool status;
		SocketError socketError = SocketPal.Poll(_handle, microSeconds, mode, out status);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (socketError != SocketError.Success)
		{
			UpdateStatusAfterSocketErrorAndThrowException(socketError, disconnectOnFailure: true, "Poll");
		}
		return status;
	}

	public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback? callback, object? state)
	{
		return TaskToAsyncResult.Begin(ConnectAsync(remoteEP), callback, state);
	}

	public void EndConnect(IAsyncResult asyncResult)
	{
		TaskToAsyncResult.End(asyncResult);
	}

	public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBufferArguments(buffer, offset, size);
		return TaskToAsyncResult.Begin(SendAsync(new ReadOnlyMemory<byte>(buffer, offset, size), socketFlags).AsTask(), callback, state);
	}

	public int EndSend(IAsyncResult asyncResult)
	{
		return TaskToAsyncResult.End<int>(asyncResult);
	}

	public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback? callback, object? state)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ValidateBufferArguments(buffer, offset, size);
		return TaskToAsyncResult.Begin(ReceiveAsync(new ArraySegment<byte>(buffer, offset, size), socketFlags, fromNetworkStream: false, default(CancellationToken)).AsTask(), callback, state);
	}

	public int EndReceive(IAsyncResult asyncResult)
	{
		return TaskToAsyncResult.End<int>(asyncResult);
	}

	public IAsyncResult BeginAccept(AsyncCallback? callback, object? state)
	{
		return TaskToAsyncResult.Begin(AcceptAsync(), callback, state);
	}

	public Socket EndAccept(IAsyncResult asyncResult)
	{
		return TaskToAsyncResult.End<Socket>(asyncResult);
	}

	private bool AcceptAsync(SocketAsyncEventArgs e, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(e, "e");
		if (e.HasMultipleBuffers)
		{
			throw new ArgumentException("net_multibuffernotsupported", "e");
		}
		if (_rightEndPoint == null)
		{
			throw new InvalidOperationException("net_sockets_mustbind");
		}
		if (!_isListening)
		{
			throw new InvalidOperationException("net_sockets_mustlisten");
		}
		e.AcceptSocket = GetOrCreateAcceptSocket(e.AcceptSocket, checkDisconnected: true, "AcceptSocket", out var handle);
		if (SocketsTelemetry.Log.IsEnabled())
		{
		}
		e.StartOperationCommon(this, SocketAsyncOperation.Accept);
		e.StartOperationAccept();
		SocketError socketError;
		try
		{
			socketError = e.DoOperationAccept(this, _handle, handle, cancellationToken);
		}
		catch (Exception ex)
		{
			SocketsTelemetry.Log.AfterAccept(SocketError.Interrupted, ex.Message);
			e.Complete();
			throw;
		}
		return socketError == SocketError.IOPending;
	}

	internal bool ConnectAsync(SocketAsyncEventArgs e, bool userSocket, bool saeaMultiConnectCancelable, CancellationToken cancellationToken = default(CancellationToken))
	{
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(e, "e");
		if (e.HasMultipleBuffers)
		{
			throw new ArgumentException("net_multibuffernotsupported", "BufferList");
		}
		ArgumentNullException.ThrowIfNull(e.RemoteEndPoint, "remoteEP");
		if (_isListening)
		{
			throw new InvalidOperationException("net_sockets_mustnotlisten");
		}
		ThrowIfConnectedStreamSocket();
		ValidateForMultiConnect();
		EndPoint remoteEP = e.RemoteEndPoint;
		if (remoteEP is DnsEndPoint dnsEndPoint)
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			if (dnsEndPoint.AddressFamily != AddressFamily.Unspecified && !CanTryAddressFamily(dnsEndPoint.AddressFamily))
			{
				throw new NotSupportedException("net_invalidversion");
			}
			e.StartOperationCommon(this, SocketAsyncOperation.Connect);
			e.StartOperationConnect(saeaMultiConnectCancelable, userSocket);
			try
			{
				return e.DnsConnectAsync(dnsEndPoint, (SocketType)0, ProtocolType.IP, cancellationToken);
			}
			catch
			{
				e.Complete();
				throw;
			}
		}
		if (!CanTryAddressFamily(e.RemoteEndPoint.AddressFamily))
		{
			throw new NotSupportedException("net_invalidversion");
		}
		e._socketAddress = Serialize(ref remoteEP);
		_pendingConnectRightEndPoint = remoteEP;
		_nonBlockingConnectInProgress = false;
		e.ConnectActivity = SocketsTelemetry.Log.ConnectStart(e._socketAddress, _protocolType, remoteEP, keepActivityCurrent: true);
		try
		{
			e.StartOperationCommon(this, SocketAsyncOperation.Connect);
			e.StartOperationConnect(saeaMultiConnectCancelable: false, userSocket);
		}
		catch (Exception ex)
		{
			SocketsTelemetry.Log.AfterConnect(SocketError.NotSocket, e.ConnectActivity, ex.Message);
			e.ConnectActivity = null;
			throw;
		}
		try
		{
			return ((_socketType == SocketType.Stream && remoteEP.AddressFamily != AddressFamily.Unix) ? e.DoOperationConnectEx(this, _handle, cancellationToken) : e.DoOperationConnect(_handle, cancellationToken)) == SocketError.IOPending;
		}
		catch (Exception ex2)
		{
			SocketsTelemetry.Log.AfterConnect(SocketError.NotSocket, e.ConnectActivity, ex2.Message);
			e.ConnectActivity = null;
			_localEndPoint = null;
			e.Complete();
			throw;
		}
	}

	private bool ReceiveAsync(SocketAsyncEventArgs e, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(e, "e");
		e.StartOperationCommon(this, SocketAsyncOperation.Receive);
		SocketError socketError;
		try
		{
			socketError = e.DoOperationReceive(_handle, cancellationToken);
		}
		catch
		{
			e.Complete();
			throw;
		}
		return socketError == SocketError.IOPending;
	}

	private bool SendAsync(SocketAsyncEventArgs e, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(e, "e");
		e.StartOperationCommon(this, SocketAsyncOperation.Send);
		SocketError socketError;
		try
		{
			socketError = e.DoOperationSend(_handle, cancellationToken);
		}
		catch
		{
			e.Complete();
			throw;
		}
		return socketError == SocketError.IOPending;
	}

	internal static int GetAddressSize(EndPoint endPoint)
	{
		return endPoint.AddressFamily switch
		{
			AddressFamily.InterNetworkV6 => System.Net.SocketAddressPal.IPv6AddressSize, 
			AddressFamily.InterNetwork => System.Net.SocketAddressPal.IPv4AddressSize, 
			_ => endPoint.Serialize().Size, 
		};
	}

	private SocketAddress Serialize(ref EndPoint remoteEP)
	{
		if (remoteEP is IPEndPoint iPEndPoint)
		{
			IPAddress address = iPEndPoint.Address;
			if (address.AddressFamily == AddressFamily.InterNetwork && IsDualMode)
			{
				address = address.MapToIPv6();
				remoteEP = new IPEndPoint(address, iPEndPoint.Port);
			}
		}
		else if (remoteEP is DnsEndPoint)
		{
			throw new ArgumentException(System.SR.Format("net_sockets_invalid_dnsendpoint", "remoteEP"), "remoteEP");
		}
		return remoteEP.Serialize();
	}

	private void DoConnect(EndPoint endPointSnapshot, SocketAddress socketAddress)
	{
		Activity activity = SocketsTelemetry.Log.ConnectStart(socketAddress, _protocolType, endPointSnapshot, keepActivityCurrent: false);
		SocketError socketError;
		try
		{
			socketError = SocketPal.Connect(_handle, socketAddress.Buffer.Slice(0, socketAddress.Size));
		}
		catch (Exception ex)
		{
			SocketsTelemetry.Log.AfterConnect(SocketError.NotSocket, activity, ex.Message);
			throw;
		}
		if (socketError != SocketError.Success)
		{
			UpdateConnectSocketErrorForDisposed(ref socketError);
			SocketException ex2 = SocketExceptionFactory.CreateSocketException((int)socketError, endPointSnapshot);
			UpdateStatusAfterSocketError(ex2);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			SocketsTelemetry.Log.AfterConnect(socketError, activity);
			throw ex2;
		}
		SocketsTelemetry.Log.AfterConnect(SocketError.Success, activity);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		_pendingConnectRightEndPoint = endPointSnapshot;
		_nonBlockingConnectInProgress = false;
		SetToConnected();
		if (!System.Net.NetEventSource.Log.IsEnabled())
		{
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (Interlocked.Exchange(ref _disposed, value: true))
		{
			return;
		}
		SetToDisconnected();
		SafeSocketHandle handle = _handle;
		if (handle != null)
		{
			if (!disposing)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				handle.Dispose();
			}
			else if (handle.OwnsHandle)
			{
				try
				{
					int closeTimeout = _closeTimeout;
					if (closeTimeout == 0)
					{
						if (System.Net.NetEventSource.Log.IsEnabled())
						{
						}
						handle.CloseAsIs(abortive: true);
					}
					else
					{
						if (!_willBlock || !_willBlockInternal)
						{
							bool willBlock;
							SocketError socketError = SocketPal.SetBlocking(handle, shouldBlock: false, out willBlock);
							if (!System.Net.NetEventSource.Log.IsEnabled())
							{
							}
						}
						if (closeTimeout < 0)
						{
							if (System.Net.NetEventSource.Log.IsEnabled())
							{
							}
							handle.CloseAsIs(abortive: false);
						}
						else
						{
							SocketError socketError = SocketPal.Shutdown(handle, _isConnected, _isDisconnected, SocketShutdown.Send);
							if (System.Net.NetEventSource.Log.IsEnabled())
							{
							}
							socketError = SocketPal.SetSockOpt(handle, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, closeTimeout);
							if (System.Net.NetEventSource.Log.IsEnabled())
							{
							}
							if (socketError != SocketError.Success)
							{
								handle.CloseAsIs(abortive: true);
							}
							else
							{
								socketError = SocketPal.Receive(handle, Array.Empty<byte>(), 0, 0, SocketFlags.None, out var _);
								if (System.Net.NetEventSource.Log.IsEnabled())
								{
								}
								if (socketError != SocketError.Success)
								{
									handle.CloseAsIs(abortive: true);
								}
								else
								{
									int available = 0;
									socketError = SocketPal.GetAvailable(handle, out available);
									if (System.Net.NetEventSource.Log.IsEnabled())
									{
									}
									if (socketError != SocketError.Success || available != 0)
									{
										handle.CloseAsIs(abortive: true);
									}
									else
									{
										handle.CloseAsIs(abortive: false);
									}
								}
							}
						}
					}
				}
				catch (ObjectDisposedException)
				{
				}
			}
			else
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				handle.CloseAsIs(abortive: false);
			}
			if (_rightEndPoint is UnixDomainSocketEndPoint { BoundFileName: not null } unixDomainSocketEndPoint)
			{
				try
				{
					File.Delete(unixDomainSocketEndPoint.BoundFileName);
				}
				catch
				{
				}
			}
		}
		DisposeCachedTaskSocketAsyncEventArgs();
	}

	public void Dispose()
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~Socket()
	{
		Dispose(disposing: false);
	}

	internal void InternalShutdown(SocketShutdown how)
	{
		if (Disposed || _handle.IsInvalid)
		{
			return;
		}
		try
		{
			SocketPal.Shutdown(_handle, _isConnected, _isDisconnected, how);
		}
		catch (ObjectDisposedException)
		{
		}
	}

	internal void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue, bool silent)
	{
		if (false)
		{
		}
		if (silent && (Disposed || _handle.IsInvalid))
		{
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return;
		}
		SocketError socketError;
		try
		{
			socketError = SocketPal.SetSockOpt(_handle, optionLevel, optionName, optionValue);
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}
		catch
		{
			if (silent && _handle.IsInvalid)
			{
				return;
			}
			throw;
		}
		if (optionName == SocketOptionName.PacketInformation && optionValue == 0 && socketError == SocketError.Success)
		{
			_receivingPacketInformation = false;
		}
		if (!silent && socketError != SocketError.Success)
		{
			UpdateStatusAfterSocketOptionErrorAndThrowException(socketError, "SetSocketOption");
		}
	}

	private LingerOption GetLingerOpt()
	{
		if (false)
		{
		}
		LingerOption optionValue;
		SocketError lingerOption = SocketPal.GetLingerOption(_handle, out optionValue);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (lingerOption != SocketError.Success)
		{
			UpdateStatusAfterSocketOptionErrorAndThrowException(lingerOption, "GetLingerOpt");
		}
		return optionValue;
	}

	private MulticastOption GetMulticastOpt(SocketOptionName optionName)
	{
		MulticastOption optionValue;
		SocketError multicastOption = SocketPal.GetMulticastOption(_handle, optionName, out optionValue);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (multicastOption != SocketError.Success)
		{
			UpdateStatusAfterSocketOptionErrorAndThrowException(multicastOption, "GetMulticastOpt");
		}
		return optionValue;
	}

	private IPv6MulticastOption GetIPv6MulticastOpt(SocketOptionName optionName)
	{
		IPv6MulticastOption optionValue;
		SocketError iPv6MulticastOption = SocketPal.GetIPv6MulticastOption(_handle, optionName, out optionValue);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (iPv6MulticastOption != SocketError.Success)
		{
			UpdateStatusAfterSocketOptionErrorAndThrowException(iPv6MulticastOption, "GetIPv6MulticastOpt");
		}
		return optionValue;
	}

	private SocketError InternalSetBlocking(bool desired, out bool current)
	{
		if (Disposed)
		{
			current = _willBlock;
			return SocketError.Success;
		}
		bool willBlock = false;
		SocketError socketError;
		try
		{
			socketError = SocketPal.SetBlocking(_handle, desired, out willBlock);
		}
		catch (ObjectDisposedException)
		{
			socketError = SocketError.NotSocket;
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (socketError == SocketError.Success)
		{
			_willBlockInternal = willBlock;
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		current = _willBlockInternal;
		return socketError;
	}

	internal void InternalSetBlocking(bool desired)
	{
		InternalSetBlocking(desired, out var _);
	}

	internal Socket CreateAcceptSocket(SafeSocketHandle fd, EndPoint remoteEP)
	{
		Socket socket = new Socket(fd, loadPropertiesFromHandle: false);
		return UpdateAcceptSocket(socket, remoteEP);
	}

	internal Socket UpdateAcceptSocket(Socket socket, EndPoint remoteEP)
	{
		socket._addressFamily = _addressFamily;
		socket._socketType = _socketType;
		socket._protocolType = _protocolType;
		socket._remoteEndPoint = remoteEP;
		if (_rightEndPoint is UnixDomainSocketEndPoint { BoundFileName: not null } unixDomainSocketEndPoint)
		{
			socket._rightEndPoint = unixDomainSocketEndPoint.CreateUnboundEndPoint();
		}
		else
		{
			socket._rightEndPoint = _rightEndPoint;
		}
		socket._localEndPoint = ((!IsWildcardEndPoint(_localEndPoint)) ? _localEndPoint : null);
		socket.SetToConnected();
		socket._willBlock = _willBlock;
		socket.InternalSetBlocking(_willBlock);
		return socket;
	}

	internal void SetToConnected()
	{
		if (!_isConnected)
		{
			_isConnected = true;
			_isDisconnected = false;
			if (_rightEndPoint == null)
			{
				_rightEndPoint = _pendingConnectRightEndPoint;
			}
			_pendingConnectRightEndPoint = null;
			UpdateLocalEndPointOnConnect();
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}
	}

	private void UpdateLocalEndPointOnConnect()
	{
		if (IsWildcardEndPoint(_localEndPoint))
		{
			_localEndPoint = null;
		}
	}

	private static bool IsWildcardEndPoint(EndPoint endPoint)
	{
		if (endPoint == null)
		{
			return false;
		}
		if (endPoint is IPEndPoint iPEndPoint)
		{
			IPAddress address = iPEndPoint.Address;
			if (!IPAddress.Any.Equals(address) && !IPAddress.IPv6Any.Equals(address))
			{
				return s_IPAddressAnyMapToIPv6.Equals(address);
			}
			return true;
		}
		return false;
	}

	internal void SetToDisconnected()
	{
		if (_isConnected)
		{
			_isConnected = false;
			_isDisconnected = true;
			if (!Disposed && !System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}
	}

	private void UpdateStatusAfterSocketOptionErrorAndThrowException(SocketError error, [CallerMemberName] string callerName = null)
	{
		bool disconnectOnFailure = error != SocketError.ProtocolOption && error != SocketError.OperationNotSupported;
		UpdateStatusAfterSocketErrorAndThrowException(error, disconnectOnFailure, callerName);
	}

	private void UpdateStatusAfterSocketErrorAndThrowException(SocketError error, bool disconnectOnFailure = true, [CallerMemberName] string callerName = null)
	{
		SocketException ex = new SocketException((int)error);
		UpdateStatusAfterSocketError(ex, disconnectOnFailure);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		throw ex;
	}

	internal void UpdateStatusAfterSocketError(SocketException socketException, bool disconnectOnFailure = true)
	{
		UpdateStatusAfterSocketError(socketException.SocketErrorCode, disconnectOnFailure);
	}

	internal void UpdateStatusAfterSocketError(SocketError errorCode, bool disconnectOnFailure = true)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (disconnectOnFailure && _isConnected && (_handle.IsInvalid || (errorCode != SocketError.WouldBlock && errorCode != SocketError.IOPending && errorCode != SocketError.NoBufferSpaceAvailable && errorCode != SocketError.TimedOut && errorCode != SocketError.OperationAborted)))
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			SetToDisconnected();
		}
	}

	private void ValidateBlockingMode()
	{
		if (_willBlock && !_willBlockInternal)
		{
			throw new InvalidOperationException("net_invasync");
		}
	}

	private void ValidateForMultiConnect()
	{
		if (_handle.ExposedHandleOrUntrackedConfiguration && _handle.LastConnectFailed)
		{
			ThrowMultiConnectNotSupported();
		}
		ReplaceHandleIfNecessaryAfterFailedConnect();
	}

	private void UpdateReceiveSocketErrorForDisposed(ref SocketError socketError, int bytesTransferred)
	{
		if (bytesTransferred == 0 && Disposed)
		{
			socketError = (IsConnectionOriented ? SocketError.ConnectionAborted : SocketError.Interrupted);
		}
	}

	private void UpdateSendSocketErrorForDisposed(ref SocketError socketError)
	{
		if (Disposed)
		{
			socketError = (IsConnectionOriented ? SocketError.ConnectionAborted : SocketError.Interrupted);
		}
	}

	private void UpdateConnectSocketErrorForDisposed(ref SocketError socketError)
	{
		if (Disposed)
		{
			socketError = SocketError.NotSocket;
		}
	}

	private void UpdateAcceptSocketErrorForDisposed(ref SocketError socketError)
	{
		if (Disposed)
		{
			socketError = SocketError.Interrupted;
		}
	}

	private void ThrowIfDisposed()
	{
		ObjectDisposedException.ThrowIf(Disposed, this);
	}

	private void ThrowIfConnectedStreamSocket()
	{
		if (_isConnected && _socketType == SocketType.Stream)
		{
			throw new SocketException(10056);
		}
	}

	private void CheckNonBlockingConnectCompleted()
	{
		if (_nonBlockingConnectInProgress && SocketPal.HasNonBlockingConnectCompleted(_handle, out var success))
		{
			_nonBlockingConnectInProgress = false;
			if (success)
			{
				SetToConnected();
			}
		}
	}

	public Task<Socket> AcceptAsync()
	{
		return AcceptAsync((Socket?)null, CancellationToken.None).AsTask();
	}

	public ValueTask<Socket> AcceptAsync(Socket? acceptSocket, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<Socket>(cancellationToken);
		}
		AwaitableSocketAsyncEventArgs obj = Interlocked.Exchange(ref _singleBufferSendEventArgs, null) ?? new AwaitableSocketAsyncEventArgs(this, isReceiveForCaching: false);
		obj.SetBuffer(null, 0, 0);
		obj.AcceptSocket = acceptSocket;
		obj.WrapExceptionsForNetworkStream = false;
		return obj.AcceptAsync(this, cancellationToken);
	}

	public Task ConnectAsync(EndPoint remoteEP)
	{
		return ConnectAsync(remoteEP, default(CancellationToken)).AsTask();
	}

	public ValueTask ConnectAsync(EndPoint remoteEP, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled(cancellationToken);
		}
		AwaitableSocketAsyncEventArgs obj = Interlocked.Exchange(ref _singleBufferReceiveEventArgs, null) ?? new AwaitableSocketAsyncEventArgs(this, isReceiveForCaching: true);
		obj.RemoteEndPoint = remoteEP;
		return obj.ConnectAsync(this, cancellationToken);
	}

	public ValueTask ConnectAsync(IPAddress[] addresses, int port, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(addresses, "addresses");
		if (addresses.Length == 0)
		{
			throw new ArgumentException("net_invalidAddressList", "addresses");
		}
		if (!System.Net.TcpValidationHelpers.ValidatePortNumber(port))
		{
			throw new ArgumentOutOfRangeException("port");
		}
		if (_isListening)
		{
			throw new InvalidOperationException("net_sockets_mustnotlisten");
		}
		if (_isConnected)
		{
			throw new SocketException(10056);
		}
		ValidateForMultiConnect();
		return Core(addresses, port, cancellationToken);
		async ValueTask Core(IPAddress[] array, int port2, CancellationToken cancellationToken2)
		{
			Exception source = null;
			IPEndPoint endPoint = null;
			foreach (IPAddress address in array)
			{
				try
				{
					if (endPoint == null)
					{
						endPoint = new IPEndPoint(address, port2);
					}
					else
					{
						endPoint.Address = address;
					}
					await ConnectAsync(endPoint, cancellationToken2).ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				catch (Exception ex) when (CanProceedWithMultiConnect && !(ex is OperationCanceledException))
				{
					source = ex;
				}
			}
			ExceptionDispatchInfo.Throw(source);
		}
	}

	public Task ConnectAsync(string host, int port)
	{
		return ConnectAsync(host, port, default(CancellationToken)).AsTask();
	}

	public ValueTask ConnectAsync(string host, int port, CancellationToken cancellationToken)
	{
		ArgumentNullException.ThrowIfNull(host, "host");
		IPAddress address;
		EndPoint remoteEP = (IPAddress.TryParse(host, out address) ? ((EndPoint)new IPEndPoint(address, port)) : ((EndPoint)new DnsEndPoint(host, port)));
		return ConnectAsync(remoteEP, cancellationToken);
	}

	internal ValueTask<int> ReceiveAsync(Memory<byte> buffer, SocketFlags socketFlags, bool fromNetworkStream, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<int>(cancellationToken);
		}
		AwaitableSocketAsyncEventArgs obj = Interlocked.Exchange(ref _singleBufferReceiveEventArgs, null) ?? new AwaitableSocketAsyncEventArgs(this, isReceiveForCaching: true);
		obj.SetBuffer(buffer);
		obj.SocketFlags = socketFlags;
		obj.WrapExceptionsForNetworkStream = fromNetworkStream;
		return obj.ReceiveAsync(this, cancellationToken);
	}

	public ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<int>(cancellationToken);
		}
		AwaitableSocketAsyncEventArgs obj = Interlocked.Exchange(ref _singleBufferSendEventArgs, null) ?? new AwaitableSocketAsyncEventArgs(this, isReceiveForCaching: false);
		obj.SetBuffer(MemoryMarshal.AsMemory(buffer));
		obj.SocketFlags = socketFlags;
		obj.WrapExceptionsForNetworkStream = false;
		return obj.SendAsync(this, cancellationToken);
	}

	internal ValueTask SendAsyncForNetworkStream(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return ValueTask.FromCanceled(cancellationToken);
		}
		AwaitableSocketAsyncEventArgs obj = Interlocked.Exchange(ref _singleBufferSendEventArgs, null) ?? new AwaitableSocketAsyncEventArgs(this, isReceiveForCaching: false);
		obj.SetBuffer(MemoryMarshal.AsMemory(buffer));
		obj.SocketFlags = socketFlags;
		obj.WrapExceptionsForNetworkStream = true;
		return obj.SendAsyncForNetworkStream(this, cancellationToken);
	}

	private static void ValidateBufferArguments(byte[] buffer, int offset, int size)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)offset, (uint)buffer.Length, "offset");
		ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)size, (uint)(buffer.Length - offset), "size");
	}

	private void DisposeCachedTaskSocketAsyncEventArgs()
	{
		Interlocked.Exchange(ref _multiBufferReceiveEventArgs, null)?.Dispose();
		Interlocked.Exchange(ref _multiBufferSendEventArgs, null)?.Dispose();
		Interlocked.Exchange(ref _singleBufferReceiveEventArgs, null)?.Dispose();
		Interlocked.Exchange(ref _singleBufferSendEventArgs, null)?.Dispose();
	}

	private static void LoadSocketTypeFromHandle(SafeSocketHandle handle, out AddressFamily addressFamily, out SocketType socketType, out ProtocolType protocolType, out bool blocking, out bool isListening, out bool isSocket)
	{
		if (false)
		{
		}
		if (global::Interop.Sys.FStat(handle, out var output) == -1)
		{
			throw new SocketException(10038);
		}
		isSocket = (output.Mode & 0xC000) == 49152;
		handle.IsSocket = isSocket;
		if (isSocket)
		{
			global::Interop.Sys.GetSocketType(handle, out addressFamily, out socketType, out protocolType, out isListening);
		}
		else
		{
			addressFamily = AddressFamily.Unknown;
			socketType = SocketType.Unknown;
			protocolType = ProtocolType.Unknown;
			isListening = false;
		}
		global::Interop.Sys.Fcntl.GetIsNonBlocking(handle, out var isNonBlocking);
		blocking = !isNonBlocking;
	}

	internal void ReplaceHandleIfNecessaryAfterFailedConnect()
	{
		if (_handle.LastConnectFailed)
		{
			SocketError socketError = ReplaceHandle();
			if (socketError != SocketError.Success)
			{
				throw new SocketException((int)socketError);
			}
			_handle.LastConnectFailed = false;
		}
	}

	internal SocketError ReplaceHandle()
	{
		Span<int> span = stackalloc int[26];
		_handle.GetTrackedSocketOptions(span, out var lingerOption);
		SafeSocketHandle handle = _handle;
		SafeSocketHandle socket;
		SocketError socketError = SocketPal.CreateSocket(_addressFamily, _socketType, _protocolType, out socket);
		Volatile.Write(ref _handle, socket);
		handle.TransferTrackedState(_handle);
		handle.Dispose();
		if (socketError != SocketError.Success)
		{
			return socketError;
		}
		if (Volatile.Read(in _disposed))
		{
			_handle.Dispose();
			throw new ObjectDisposedException(GetType().FullName);
		}
		_handle.SetTrackedSocketOptions(span, lingerOption);
		return SocketError.Success;
	}

	private static void ThrowMultiConnectNotSupported()
	{
		throw new PlatformNotSupportedException("net_sockets_connect_multiconnect_notsupported");
	}

	private Socket GetOrCreateAcceptSocket(Socket acceptSocket, bool checkDisconnected, string propertyName, out SafeSocketHandle handle)
	{
		if (acceptSocket != null)
		{
			if (acceptSocket._handle.HasShutdownSend)
			{
				throw new SocketException(10022);
			}
			if (acceptSocket._rightEndPoint != null && (!checkDisconnected || !acceptSocket._isDisconnected))
			{
				throw new InvalidOperationException(System.SR.Format("net_sockets_namedmustnotbebound", propertyName));
			}
		}
		handle = null;
		return acceptSocket;
	}

	internal void DisposeHandle()
	{
		_handle.Dispose();
	}

	internal void ClearHandle()
	{
		_handle = null;
	}

	internal Socket CopyStateFromSource(Socket source)
	{
		_addressFamily = source._addressFamily;
		_closeTimeout = source._closeTimeout;
		_disposed = source._disposed;
		_handle = source._handle;
		_isConnected = source._isConnected;
		_isDisconnected = source._isDisconnected;
		_isListening = source._isListening;
		_nonBlockingConnectInProgress = source._nonBlockingConnectInProgress;
		_protocolType = source._protocolType;
		_receivingPacketInformation = source._receivingPacketInformation;
		_remoteEndPoint = source._remoteEndPoint;
		_rightEndPoint = source._rightEndPoint;
		_socketType = source._socketType;
		_willBlock = source._willBlock;
		_willBlockInternal = source._willBlockInternal;
		_localEndPoint = source._localEndPoint;
		_multiBufferReceiveEventArgs = source._multiBufferReceiveEventArgs;
		_multiBufferSendEventArgs = source._multiBufferSendEventArgs;
		_pendingConnectRightEndPoint = source._pendingConnectRightEndPoint;
		_singleBufferReceiveEventArgs = source._singleBufferReceiveEventArgs;
		return this;
	}
}
