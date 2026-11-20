using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Sockets;

public class NetworkStream : Stream
{
	private readonly Socket _streamSocket;

	private readonly bool _ownsSocket;

	private bool _readable;

	private bool _writeable;

	private bool _disposed;

	private int _closeTimeout = -1;

	private int _currentReadTimeout = -1;

	private int _currentWriteTimeout = -1;

	public Socket Socket => _streamSocket;

	public override bool CanRead => _readable;

	public override bool CanSeek => false;

	public override bool CanWrite => _writeable;

	public override bool CanTimeout => true;

	public override int ReadTimeout
	{
		get
		{
			if (false)
			{
			}
			int num = (int)_streamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
			if (num == 0)
			{
				return -1;
			}
			return num;
		}
		set
		{
			if (false)
			{
			}
			if (value <= 0 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value", "net_io_timeout_use_gt_zero");
			}
			SetSocketTimeoutOption(SocketShutdown.Receive, value, silent: false);
		}
	}

	public override int WriteTimeout
	{
		get
		{
			if (false)
			{
			}
			int num = (int)_streamSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout);
			if (num == 0)
			{
				return -1;
			}
			return num;
		}
		set
		{
			if (false)
			{
			}
			if (value <= 0 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value", "net_io_timeout_use_gt_zero");
			}
			SetSocketTimeoutOption(SocketShutdown.Send, value, silent: false);
		}
	}

	public override long Length
	{
		get
		{
			throw new NotSupportedException("net_noseek");
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException("net_noseek");
		}
		set
		{
			throw new NotSupportedException("net_noseek");
		}
	}

	public NetworkStream(Socket socket, bool ownsSocket)
		: this(socket, FileAccess.ReadWrite, ownsSocket)
	{
	}

	public NetworkStream(Socket socket, FileAccess access, bool ownsSocket)
	{
		ArgumentNullException.ThrowIfNull(socket, "socket");
		_ = 0;
		if (!socket.Blocking)
		{
			throw new IOException("net_sockets_blocking");
		}
		if (!socket.Connected)
		{
			throw new IOException("net_notconnected");
		}
		if (socket.SocketType != SocketType.Stream)
		{
			throw new IOException("net_notstream");
		}
		_streamSocket = socket;
		_ownsSocket = ownsSocket;
		switch (access)
		{
		case FileAccess.Read:
			_readable = true;
			break;
		case FileAccess.Write:
			_writeable = true;
			break;
		default:
			_readable = true;
			_writeable = true;
			break;
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("net_noseek");
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (1 == 0)
		{
		}
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanRead)
		{
			throw new InvalidOperationException("net_writeonlystream");
		}
		try
		{
			return _streamSocket.Receive(buffer, offset, count, SocketFlags.None);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public override int Read(Span<byte> buffer)
	{
		if (1 == 0)
		{
		}
		if (GetType() != typeof(NetworkStream))
		{
			return base.Read(buffer);
		}
		ThrowIfDisposed();
		if (!CanRead)
		{
			throw new InvalidOperationException("net_writeonlystream");
		}
		try
		{
			return _streamSocket.Receive(buffer, SocketFlags.None);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public unsafe override int ReadByte()
	{
		if (1 == 0)
		{
		}
		Unsafe.SkipInit(out byte result);
		if (Read(new Span<byte>(&result, 1)) != 0)
		{
			return result;
		}
		return -1;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (1 == 0)
		{
		}
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanWrite)
		{
			throw new InvalidOperationException("net_readonlystream");
		}
		try
		{
			_streamSocket.Send(buffer, offset, count, SocketFlags.None);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public override void Write(ReadOnlySpan<byte> buffer)
	{
		if (1 == 0)
		{
		}
		if (GetType() != typeof(NetworkStream))
		{
			base.Write(buffer);
			return;
		}
		ThrowIfDisposed();
		if (!CanWrite)
		{
			throw new InvalidOperationException("net_readonlystream");
		}
		try
		{
			_streamSocket.Send(buffer, SocketFlags.None);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public unsafe override void WriteByte(byte value)
	{
		Write(new ReadOnlySpan<byte>(&value, 1));
	}

	public void Close(int timeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(timeout, -1, "timeout");
		_closeTimeout = timeout;
		Dispose();
	}

	protected override void Dispose(bool disposing)
	{
		if (Interlocked.Exchange(ref _disposed, value: true))
		{
			return;
		}
		if (disposing)
		{
			_readable = false;
			_writeable = false;
			if (_ownsSocket)
			{
				_streamSocket.InternalShutdown(SocketShutdown.Both);
				_streamSocket.Close(_closeTimeout);
			}
		}
		base.Dispose(disposing);
	}

	~NetworkStream()
	{
		Dispose(disposing: false);
	}

	public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
	{
		if (1 == 0)
		{
		}
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanRead)
		{
			throw new InvalidOperationException("net_writeonlystream");
		}
		try
		{
			return _streamSocket.BeginReceive(buffer, offset, count, SocketFlags.None, callback, state);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public override int EndRead(IAsyncResult asyncResult)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(asyncResult, "asyncResult");
		try
		{
			return _streamSocket.EndReceive(asyncResult);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
	{
		if (1 == 0)
		{
		}
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanWrite)
		{
			throw new InvalidOperationException("net_readonlystream");
		}
		try
		{
			return _streamSocket.BeginSend(buffer, offset, count, SocketFlags.None, callback, state);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		if (1 == 0)
		{
		}
		ThrowIfDisposed();
		ArgumentNullException.ThrowIfNull(asyncResult, "asyncResult");
		try
		{
			_streamSocket.EndSend(asyncResult);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanRead)
		{
			throw new InvalidOperationException("net_writeonlystream");
		}
		try
		{
			return _streamSocket.ReceiveAsync(new Memory<byte>(buffer, offset, count), SocketFlags.None, fromNetworkStream: true, cancellationToken).AsTask();
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		bool canRead = CanRead;
		ThrowIfDisposed();
		if (!canRead)
		{
			throw new InvalidOperationException("net_writeonlystream");
		}
		try
		{
			return _streamSocket.ReceiveAsync(buffer, SocketFlags.None, fromNetworkStream: true, cancellationToken);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_readfailure", ex);
		}
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		Stream.ValidateBufferArguments(buffer, offset, count);
		ThrowIfDisposed();
		if (!CanWrite)
		{
			throw new InvalidOperationException("net_readonlystream");
		}
		try
		{
			return _streamSocket.SendAsyncForNetworkStream(new ReadOnlyMemory<byte>(buffer, offset, count), SocketFlags.None, cancellationToken).AsTask();
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
	{
		bool canWrite = CanWrite;
		ThrowIfDisposed();
		if (!canWrite)
		{
			throw new InvalidOperationException("net_readonlystream");
		}
		try
		{
			return _streamSocket.SendAsyncForNetworkStream(buffer, SocketFlags.None, cancellationToken);
		}
		catch (Exception ex) when (!(ex is OutOfMemoryException))
		{
			throw WrapException("net_io_writefailure", ex);
		}
	}

	public override void Flush()
	{
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("net_noseek");
	}

	internal void SetSocketTimeoutOption(SocketShutdown mode, int timeout, bool silent)
	{
		if (false)
		{
		}
		if (timeout < 0)
		{
			timeout = 0;
		}
		if ((mode == SocketShutdown.Send || mode == SocketShutdown.Both) && timeout != _currentWriteTimeout)
		{
			_streamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout, silent);
			_currentWriteTimeout = timeout;
		}
		if ((mode == SocketShutdown.Receive || mode == SocketShutdown.Both) && timeout != _currentReadTimeout)
		{
			_streamSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeout, silent);
			_currentReadTimeout = timeout;
		}
	}

	private void ThrowIfDisposed()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
	}

	private static IOException WrapException(string resourceFormatString, Exception innerException)
	{
		return new IOException(System.SR.Format(resourceFormatString, innerException.Message), innerException);
	}
}
