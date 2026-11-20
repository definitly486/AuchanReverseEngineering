using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Net.Sockets;

internal static class SocketPal
{
	public static readonly int MaximumAddressSize = global::Interop.Sys.GetMaximumAddressSize();

	private static readonly bool SupportsDualModeIPv4PacketInfo = GetPlatformSupportsDualModeIPv4PacketInfo();

	private static readonly bool SelectOverPollIsBroken;

	private static bool GetPlatformSupportsDualModeIPv4PacketInfo()
	{
		return global::Interop.Sys.PlatformSupportsDualModeIPv4PacketInfo() != 0;
	}

	public static SocketError GetSocketErrorForErrorCode(global::Interop.Error errorCode)
	{
		return System.Net.Sockets.SocketErrorPal.GetSocketErrorForNativeError(errorCode);
	}

	public unsafe static SocketError CreateSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, out SafeSocketHandle socket)
	{
		socket = new SafeSocketHandle();
		Unsafe.SkipInit(out nint num);
		global::Interop.Error error = global::Interop.Sys.Socket((int)addressFamily, (int)socketType, (int)protocolType, &num);
		SocketError result;
		if (error == global::Interop.Error.SUCCESS)
		{
			result = SocketError.Success;
			_ = 0;
			if (addressFamily == AddressFamily.InterNetworkV6 && socketType != SocketType.Raw)
			{
				int num2 = 1;
				error = global::Interop.Sys.SetSockOpt(num, SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, (byte*)(&num2), 4);
				if (error != global::Interop.Error.SUCCESS)
				{
					global::Interop.Sys.Close(num);
					num = -1;
					result = GetSocketErrorForErrorCode(error);
				}
			}
		}
		else
		{
			result = GetSocketErrorForErrorCode(error);
		}
		Marshal.InitHandle(socket, num);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (socket.IsInvalid)
		{
			socket.Dispose();
		}
		return result;
	}

	private unsafe static int SysRead(SafeSocketHandle handle, Span<byte> buffer, out global::Interop.Error errno)
	{
		int num = 0;
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			num = global::Interop.Sys.Read(handle, reference, buffer.Length);
			errno = ((num == -1) ? global::Interop.Sys.GetLastError() : global::Interop.Error.SUCCESS);
		}
		return num;
	}

	private unsafe static int SysReceive(SafeSocketHandle socket, SocketFlags flags, Span<byte> buffer, out global::Interop.Error errno)
	{
		int result = 0;
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			errno = global::Interop.Sys.Receive(socket, reference, buffer.Length, flags, &result);
		}
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		return result;
	}

	private unsafe static int SysReceive(SafeSocketHandle socket, SocketFlags flags, Span<byte> buffer, Span<byte> socketAddress, out int socketAddressLen, out SocketFlags receivedFlags, out global::Interop.Error errno)
	{
		long num = 0L;
		fixed (byte* reference = &MemoryMarshal.GetReference(socketAddress))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference(buffer))
			{
				global::Interop.Sys.IOVector iOVector = new global::Interop.Sys.IOVector
				{
					Base = reference2,
					Count = (nuint)buffer.Length
				};
				global::Interop.Sys.MessageHeader messageHeader = new global::Interop.Sys.MessageHeader
				{
					SocketAddress = reference,
					SocketAddressLen = socketAddress.Length,
					IOVectors = &iOVector,
					IOVectorCount = 1
				};
				errno = global::Interop.Sys.ReceiveMessage(socket, &messageHeader, flags, &num);
				receivedFlags = messageHeader.Flags;
				socketAddressLen = messageHeader.SocketAddressLen;
			}
		}
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		return checked((int)num);
	}

	private unsafe static int SysWrite(SafeSocketHandle handle, ReadOnlySpan<byte> buffer, ref int offset, ref int count, out global::Interop.Error errno)
	{
		int num;
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			num = global::Interop.Sys.Write(handle, reference + offset, count);
			if (num == -1)
			{
				errno = global::Interop.Sys.GetLastError();
			}
			else
			{
				errno = global::Interop.Error.SUCCESS;
				offset += num;
				count -= num;
			}
		}
		return num;
	}

	private static ReadOnlySpan<byte> AvoidNullReference(ReadOnlySpan<byte> buffer)
	{
		if (!Unsafe.IsNullRef(in MemoryMarshal.GetReference(buffer)))
		{
			return buffer;
		}
		return Array.Empty<byte>();
	}

	private unsafe static int SysSend(SafeSocketHandle socket, SocketFlags flags, ReadOnlySpan<byte> buffer, ref int offset, ref int count, out global::Interop.Error errno)
	{
		buffer = AvoidNullReference(buffer);
		Unsafe.SkipInit(out int num);
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			errno = global::Interop.Sys.Send(socket, reference + offset, count, flags, &num);
		}
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		offset += num;
		count -= num;
		return num;
	}

	private unsafe static int SysSend(SafeSocketHandle socket, SocketFlags flags, ReadOnlySpan<byte> buffer, ref int offset, ref int count, ReadOnlySpan<byte> socketAddress, out global::Interop.Error errno)
	{
		buffer = AvoidNullReference(buffer);
		int num2;
		fixed (byte* socketAddress2 = socketAddress)
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
			{
				global::Interop.Sys.IOVector iOVector = new global::Interop.Sys.IOVector
				{
					Base = reference + offset,
					Count = (nuint)count
				};
				global::Interop.Sys.MessageHeader messageHeader = new global::Interop.Sys.MessageHeader
				{
					SocketAddress = socketAddress2,
					SocketAddressLen = socketAddress.Length,
					IOVectors = &iOVector,
					IOVectorCount = 1
				};
				long num = 0L;
				errno = global::Interop.Sys.SendMessage(socket, &messageHeader, flags, &num);
				num2 = checked((int)num);
			}
		}
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		offset += num2;
		count -= num2;
		return num2;
	}

	private unsafe static int SysSend(SafeSocketHandle socket, SocketFlags flags, IList<ArraySegment<byte>> buffers, ref int bufferIndex, ref int offset, ReadOnlySpan<byte> socketAddress, out global::Interop.Error errno)
	{
		int num = bufferIndex;
		int num2 = offset;
		int num3 = checked(buffers.Count - num);
		if (false)
		{
		}
		bool flag = (uint)num3 <= 8u;
		Span<GCHandle> span = ((!flag) ? ((Span<GCHandle>)new GCHandle[num3]) : stackalloc GCHandle[8]);
		Span<GCHandle> span2 = span;
		Span<global::Interop.Sys.IOVector> span3 = ((!flag) ? ((Span<global::Interop.Sys.IOVector>)new global::Interop.Sys.IOVector[num3]) : stackalloc global::Interop.Sys.IOVector[8]);
		Span<global::Interop.Sys.IOVector> span4 = span3;
		int num4 = 0;
		int num7;
		try
		{
			int num5 = 0;
			while (num5 < num3)
			{
				ArraySegment<byte> segment = buffers[num + num5];
				RangeValidationHelpers.ValidateSegment(segment);
				span2[num5] = GCHandle.Alloc(segment.Array, GCHandleType.Pinned);
				num4++;
				span4[num5].Base = (byte*)(span2[num5].AddrOfPinnedObject() + (segment.Offset + num2));
				span4[num5].Count = (nuint)(segment.Count - num2);
				num5++;
				num2 = 0;
			}
			fixed (byte* socketAddress2 = socketAddress)
			{
				fixed (global::Interop.Sys.IOVector* iOVectors = span4)
				{
					global::Interop.Sys.MessageHeader messageHeader = new global::Interop.Sys.MessageHeader
					{
						SocketAddress = socketAddress2,
						SocketAddressLen = socketAddress.Length,
						IOVectors = iOVectors,
						IOVectorCount = num4
					};
					long num6 = 0L;
					errno = global::Interop.Sys.SendMessage(socket, &messageHeader, flags, &num6);
					num7 = checked((int)num6);
				}
			}
		}
		finally
		{
			for (int i = 0; i < num4; i++)
			{
				span2[i].Free();
			}
		}
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		int num8 = bufferIndex;
		int num9 = offset;
		int num10 = num7;
		while (num8 < buffers.Count && num10 > 0)
		{
			int num11 = buffers[num8].Count - num9;
			if (num11 > num10)
			{
				num9 += num10;
				break;
			}
			num10 -= num11;
			num8++;
			num9 = 0;
		}
		bufferIndex = num8;
		offset = num9;
		return num7;
	}

	private unsafe static int SysReceive(SafeSocketHandle socket, SocketFlags flags, IList<ArraySegment<byte>> buffers, Span<byte> socketAddress, out int socketAddressLen, out SocketFlags receivedFlags, out global::Interop.Error errno)
	{
		int count = buffers.Count;
		if (false)
		{
		}
		bool flag = (uint)count <= 8u;
		int num = int.MaxValue;
		if (!flag)
		{
			errno = global::Interop.Sys.GetBytesAvailable(socket, &num);
			if (errno != global::Interop.Error.SUCCESS)
			{
				receivedFlags = SocketFlags.None;
				socketAddressLen = 0;
				return -1;
			}
			if (num == 0)
			{
				num = int.MaxValue;
			}
		}
		Span<GCHandle> span = ((!flag) ? ((Span<GCHandle>)new GCHandle[count]) : stackalloc GCHandle[8]);
		Span<GCHandle> span2 = span;
		Span<global::Interop.Sys.IOVector> span3 = ((!flag) ? ((Span<global::Interop.Sys.IOVector>)new global::Interop.Sys.IOVector[count]) : stackalloc global::Interop.Sys.IOVector[8]);
		Span<global::Interop.Sys.IOVector> span4 = span3;
		int num2 = socketAddress.Length;
		long num3 = 0L;
		int num4 = 0;
		int num5 = 0;
		try
		{
			for (int i = 0; i < count; i++)
			{
				ArraySegment<byte> segment = buffers[i];
				RangeValidationHelpers.ValidateSegment(segment);
				int count2 = segment.Count;
				span2[i] = GCHandle.Alloc(segment.Array, GCHandleType.Pinned);
				num5++;
				span4[i].Base = (byte*)(span2[i].AddrOfPinnedObject() + segment.Offset);
				span4[i].Count = (nuint)count2;
				num4 += count2;
				if (num4 >= num)
				{
					for (int j = i + 1; j < count; j++)
					{
						RangeValidationHelpers.ValidateSegment(buffers[j]);
					}
					break;
				}
			}
			fixed (byte* socketAddress2 = socketAddress)
			{
				fixed (global::Interop.Sys.IOVector* iOVectors = span4)
				{
					global::Interop.Sys.MessageHeader messageHeader = new global::Interop.Sys.MessageHeader
					{
						SocketAddress = socketAddress2,
						SocketAddressLen = num2,
						IOVectors = iOVectors,
						IOVectorCount = num5
					};
					errno = global::Interop.Sys.ReceiveMessage(socket, &messageHeader, flags, &num3);
					receivedFlags = messageHeader.Flags;
					num2 = messageHeader.SocketAddressLen;
				}
			}
		}
		finally
		{
			for (int k = 0; k < num5; k++)
			{
				span2[k].Free();
			}
		}
		socketAddressLen = num2;
		if (errno != global::Interop.Error.SUCCESS)
		{
			return -1;
		}
		return checked((int)num3);
	}

	public unsafe static bool TryCompleteAccept(SafeSocketHandle socket, Memory<byte> socketAddress, out int socketAddressLen, out nint acceptedFd, out SocketError errorCode)
	{
		nint zero = IntPtr.Zero;
		int length = socketAddress.Length;
		global::Interop.Error error;
		fixed (byte* socketAddress2 = socketAddress.Span)
		{
			try
			{
				error = global::Interop.Sys.Accept(socket, socketAddress2, &length, &zero);
				socketAddressLen = length;
			}
			catch (ObjectDisposedException)
			{
				errorCode = SocketError.OperationAborted;
				acceptedFd = -1;
				socketAddressLen = 0;
				return true;
			}
		}
		if (error == global::Interop.Error.SUCCESS)
		{
			errorCode = SocketError.Success;
			acceptedFd = zero;
			return true;
		}
		acceptedFd = -1;
		if (error != global::Interop.Error.EAGAIN && error != global::Interop.Error.EAGAIN)
		{
			errorCode = GetSocketErrorForErrorCode(error);
			return true;
		}
		errorCode = SocketError.Success;
		return false;
	}

	public static bool TryStartConnect(SafeSocketHandle socket, Memory<byte> socketAddress, out SocketError errorCode)
	{
		int sent;
		return TryStartConnect(socket, socketAddress, out errorCode, Span<byte>.Empty, tfo: false, out sent);
	}

	public unsafe static bool TryStartConnect(SafeSocketHandle socket, Memory<byte> socketAddress, out SocketError errorCode, Span<byte> data, bool tfo, out int sent)
	{
		sent = 0;
		if (socket.IsDisconnected)
		{
			errorCode = SocketError.IsConnected;
			return true;
		}
		global::Interop.Error error;
		fixed (byte* socketAddress2 = socketAddress.Span)
		{
			if (data.Length > 0)
			{
				int num = 0;
				error = global::Interop.Sys.Connectx(socket, socketAddress2, socketAddress.Length, data, data.Length, tfo ? 1 : 0, &num);
				sent = num;
			}
			else
			{
				error = global::Interop.Sys.Connect(socket, socketAddress2, socketAddress.Length);
			}
		}
		switch (error)
		{
		case global::Interop.Error.SUCCESS:
			errorCode = SocketError.Success;
			return true;
		default:
			errorCode = GetSocketErrorForErrorCode(error);
			return true;
		case global::Interop.Error.EINPROGRESS:
			errorCode = SocketError.Success;
			return false;
		}
	}

	public unsafe static bool TryCompleteConnect(SafeSocketHandle socket, out SocketError errorCode)
	{
		global::Interop.Error error = global::Interop.Error.SUCCESS;
		global::Interop.Error error2;
		try
		{
			error2 = global::Interop.Sys.Poll(socket, global::Interop.PollEvents.POLLOUT, 0, out var triggered);
			if (error2 == global::Interop.Error.SUCCESS)
			{
				if (triggered == global::Interop.PollEvents.POLLNONE)
				{
					error = global::Interop.Error.EINPROGRESS;
				}
				else
				{
					error2 = global::Interop.Sys.GetSocketErrorOption(socket, &error);
				}
			}
		}
		catch (ObjectDisposedException)
		{
			errorCode = SocketError.OperationAborted;
			return true;
		}
		if (error2 != global::Interop.Error.SUCCESS)
		{
			errorCode = SocketError.SocketError;
			return true;
		}
		switch (error)
		{
		case global::Interop.Error.SUCCESS:
			errorCode = SocketError.Success;
			return true;
		case global::Interop.Error.EINPROGRESS:
			errorCode = SocketError.Success;
			return false;
		default:
			errorCode = GetSocketErrorForErrorCode(error);
			return true;
		}
	}

	public static bool TryCompleteReceiveFrom(SafeSocketHandle socket, Span<byte> buffer, SocketFlags flags, Span<byte> socketAddress, out int socketAddressLen, out int bytesReceived, out SocketFlags receivedFlags, out SocketError errorCode)
	{
		return TryCompleteReceiveFrom(socket, buffer, null, flags, socketAddress, out socketAddressLen, out bytesReceived, out receivedFlags, out errorCode);
	}

	public static bool TryCompleteReceiveFrom(SafeSocketHandle socket, IList<ArraySegment<byte>> buffers, SocketFlags flags, Span<byte> socketAddress, out int socketAddressLen, out int bytesReceived, out SocketFlags receivedFlags, out SocketError errorCode)
	{
		return TryCompleteReceiveFrom(socket, default(Span<byte>), buffers, flags, socketAddress, out socketAddressLen, out bytesReceived, out receivedFlags, out errorCode);
	}

	public unsafe static bool TryCompleteReceive(SafeSocketHandle socket, Span<byte> buffer, SocketFlags flags, out int bytesReceived, out SocketError errorCode)
	{
		try
		{
			int num;
			global::Interop.Error errno;
			if (!socket.IsSocket)
			{
				num = SysRead(socket, buffer, out errno);
			}
			else if (buffer.Length == 0)
			{
				Unsafe.SkipInit(out byte b);
				num = SysReceive(socket, flags | SocketFlags.Peek, new Span<byte>(&b, 1), out errno);
				if (num > 0)
				{
					num = 0;
				}
			}
			else
			{
				num = SysReceive(socket, flags, buffer, out errno);
			}
			if (num != -1)
			{
				bytesReceived = num;
				errorCode = SocketError.Success;
				return true;
			}
			bytesReceived = 0;
			if (errno != global::Interop.Error.EAGAIN && errno != global::Interop.Error.EAGAIN)
			{
				errorCode = GetSocketErrorForErrorCode(errno);
				return true;
			}
			errorCode = SocketError.Success;
			return false;
		}
		catch (ObjectDisposedException)
		{
			bytesReceived = 0;
			errorCode = SocketError.OperationAborted;
			return true;
		}
	}

	public unsafe static bool TryCompleteReceiveFrom(SafeSocketHandle socket, Span<byte> buffer, IList<ArraySegment<byte>> buffers, SocketFlags flags, Span<byte> socketAddress, out int receivedSocketAddressLength, out int bytesReceived, out SocketFlags receivedFlags, out SocketError errorCode)
	{
		try
		{
			int num;
			global::Interop.Error errno;
			if (!socket.IsSocket)
			{
				receivedFlags = SocketFlags.None;
				num = SysRead(socket, buffer, out errno);
				receivedSocketAddressLength = 0;
			}
			else if (buffers != null)
			{
				num = SysReceive(socket, flags, buffers, socketAddress, out receivedSocketAddressLength, out receivedFlags, out errno);
			}
			else if (buffer.Length == 0)
			{
				Unsafe.SkipInit(out byte b);
				num = SysReceive(socket, flags | SocketFlags.Peek, new Span<byte>(&b, 1), socketAddress, out receivedSocketAddressLength, out receivedFlags, out errno);
				if (num > 0)
				{
					num = 0;
				}
			}
			else
			{
				num = SysReceive(socket, flags, buffer, socketAddress, out receivedSocketAddressLength, out receivedFlags, out errno);
			}
			if (num != -1)
			{
				bytesReceived = num;
				errorCode = SocketError.Success;
				return true;
			}
			bytesReceived = 0;
			receivedSocketAddressLength = 0;
			if (errno != global::Interop.Error.EAGAIN && errno != global::Interop.Error.EAGAIN)
			{
				errorCode = GetSocketErrorForErrorCode(errno);
				return true;
			}
			errorCode = SocketError.Success;
			return false;
		}
		catch (ObjectDisposedException)
		{
			bytesReceived = 0;
			receivedFlags = SocketFlags.None;
			receivedSocketAddressLength = 0;
			errorCode = SocketError.OperationAborted;
			return true;
		}
	}

	public static bool TryCompleteSendTo(SafeSocketHandle socket, Span<byte> buffer, ref int offset, ref int count, SocketFlags flags, ReadOnlySpan<byte> socketAddress, ref int bytesSent, out SocketError errorCode)
	{
		int bufferIndex = 0;
		return TryCompleteSendTo(socket, buffer, null, ref bufferIndex, ref offset, ref count, flags, socketAddress, ref bytesSent, out errorCode);
	}

	public static bool TryCompleteSendTo(SafeSocketHandle socket, ReadOnlySpan<byte> buffer, SocketFlags flags, ReadOnlySpan<byte> socketAddress, ref int bytesSent, out SocketError errorCode)
	{
		int bufferIndex = 0;
		int offset = 0;
		int count = buffer.Length;
		return TryCompleteSendTo(socket, buffer, null, ref bufferIndex, ref offset, ref count, flags, socketAddress, ref bytesSent, out errorCode);
	}

	public static bool TryCompleteSendTo(SafeSocketHandle socket, IList<ArraySegment<byte>> buffers, ref int bufferIndex, ref int offset, SocketFlags flags, ReadOnlySpan<byte> socketAddress, ref int bytesSent, out SocketError errorCode)
	{
		int count = 0;
		return TryCompleteSendTo(socket, default(ReadOnlySpan<byte>), buffers, ref bufferIndex, ref offset, ref count, flags, socketAddress, ref bytesSent, out errorCode);
	}

	public static bool TryCompleteSendTo(SafeSocketHandle socket, ReadOnlySpan<byte> buffer, IList<ArraySegment<byte>> buffers, ref int bufferIndex, ref int offset, ref int count, SocketFlags flags, ReadOnlySpan<byte> socketAddress, ref int bytesSent, out SocketError errorCode)
	{
		bool flag = false;
		long num = ((socket.IsUnderlyingHandleBlocking && socket.SendTimeout > 0) ? Environment.TickCount64 : 0);
		do
		{
			int num2;
			global::Interop.Error errno;
			try
			{
				num2 = (socket.IsSocket ? ((buffers != null) ? SysSend(socket, flags, buffers, ref bufferIndex, ref offset, socketAddress, out errno) : (socketAddress.IsEmpty ? SysSend(socket, flags, buffer, ref offset, ref count, out errno) : SysSend(socket, flags, buffer, ref offset, ref count, socketAddress, out errno))) : SysWrite(socket, buffer, ref offset, ref count, out errno));
			}
			catch (ObjectDisposedException)
			{
				errorCode = SocketError.OperationAborted;
				return true;
			}
			if (num2 == -1)
			{
				if (!flag && errno != global::Interop.Error.EAGAIN && errno != global::Interop.Error.EAGAIN)
				{
					errorCode = GetSocketErrorForErrorCode(errno);
					return true;
				}
				errorCode = ((!flag) ? SocketError.WouldBlock : SocketError.Success);
				return false;
			}
			flag = true;
			bytesSent += num2;
			if (num2 == 0 || (buffers == null && count == 0) || (buffers != null && bufferIndex == buffers.Count))
			{
				errorCode = SocketError.Success;
				return true;
			}
		}
		while (!socket.IsUnderlyingHandleBlocking || socket.SendTimeout <= 0 || Environment.TickCount64 - num < socket.SendTimeout);
		errorCode = SocketError.TimedOut;
		return true;
	}

	public static SocketError SetBlocking(SafeSocketHandle handle, bool shouldBlock, out bool willBlock)
	{
		if ((0u & (shouldBlock ? 1u : 0u)) != 0)
		{
			throw new PlatformNotSupportedException();
		}
		handle.IsNonBlocking = !shouldBlock;
		willBlock = shouldBlock;
		return SocketError.Success;
	}

	public unsafe static SocketError GetSockName(SafeSocketHandle handle, byte* buffer, int* nameLen)
	{
		global::Interop.Error sockName = global::Interop.Sys.GetSockName(handle, buffer, nameLen);
		if (sockName != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(sockName);
		}
		return SocketError.Success;
	}

	public unsafe static SocketError GetAvailable(SafeSocketHandle handle, out int available)
	{
		int num = 0;
		global::Interop.Error bytesAvailable = global::Interop.Sys.GetBytesAvailable(handle, &num);
		available = num;
		if (bytesAvailable != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(bytesAvailable);
		}
		return SocketError.Success;
	}

	public unsafe static SocketError GetPeerName(SafeSocketHandle handle, Span<byte> buffer, ref int nameLen)
	{
		int num = nameLen;
		global::Interop.Error peerName;
		fixed (byte* socketAddress = buffer)
		{
			peerName = global::Interop.Sys.GetPeerName(handle, socketAddress, &num);
		}
		nameLen = num;
		if (peerName != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(peerName);
		}
		return SocketError.Success;
	}

	public static SocketError Bind(SafeSocketHandle handle, ProtocolType socketProtocolType, ReadOnlySpan<byte> buffer)
	{
		global::Interop.Error error = global::Interop.Sys.Bind(handle, socketProtocolType, buffer);
		if (error != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(error);
		}
		return SocketError.Success;
	}

	public static SocketError Listen(SafeSocketHandle handle, int backlog)
	{
		global::Interop.Error error = global::Interop.Sys.Listen(handle, backlog);
		if (error != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(error);
		}
		return SocketError.Success;
	}

	public static SocketError Accept(SafeSocketHandle listenSocket, Memory<byte> socketAddress, out int socketAddressLen, out SafeSocketHandle socket)
	{
		socket = new SafeSocketHandle();
		SocketError errorCode;
		nint acceptedFd;
		if (!listenSocket.IsNonBlocking)
		{
			errorCode = listenSocket.AsyncContext.Accept(socketAddress, out socketAddressLen, out acceptedFd);
		}
		else if (!TryCompleteAccept(listenSocket, socketAddress, out socketAddressLen, out acceptedFd, out errorCode))
		{
			errorCode = SocketError.WouldBlock;
		}
		Marshal.InitHandle(socket, acceptedFd);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return errorCode;
	}

	public static SocketError Connect(SafeSocketHandle handle, Memory<byte> socketAddress)
	{
		if (!handle.IsNonBlocking)
		{
			return handle.AsyncContext.Connect(socketAddress);
		}
		if (TryStartConnect(handle, socketAddress, out var errorCode))
		{
			handle.RegisterConnectResult(errorCode);
			return errorCode;
		}
		return SocketError.WouldBlock;
	}

	public static SocketError Send(SafeSocketHandle handle, byte[] buffer, int offset, int count, SocketFlags socketFlags, out int bytesTransferred)
	{
		if (!handle.IsNonBlocking)
		{
			return handle.AsyncContext.Send(buffer, offset, count, socketFlags, handle.SendTimeout, out bytesTransferred);
		}
		bytesTransferred = 0;
		TryCompleteSendTo(handle, buffer, ref offset, ref count, socketFlags, ReadOnlySpan<byte>.Empty, ref bytesTransferred, out var errorCode);
		return errorCode;
	}

	public static SocketError Send(SafeSocketHandle handle, ReadOnlySpan<byte> buffer, SocketFlags socketFlags, out int bytesTransferred)
	{
		if (!handle.IsNonBlocking)
		{
			return handle.AsyncContext.Send(buffer, socketFlags, handle.SendTimeout, out bytesTransferred);
		}
		bytesTransferred = 0;
		TryCompleteSendTo(handle, buffer, socketFlags, ReadOnlySpan<byte>.Empty, ref bytesTransferred, out var errorCode);
		return errorCode;
	}

	public static SocketError Receive(SafeSocketHandle handle, byte[] buffer, int offset, int count, SocketFlags socketFlags, out int bytesTransferred)
	{
		if (!handle.IsNonBlocking)
		{
			return handle.AsyncContext.Receive(new Memory<byte>(buffer, offset, count), socketFlags, handle.ReceiveTimeout, out bytesTransferred);
		}
		if (!TryCompleteReceive(handle, new Span<byte>(buffer, offset, count), socketFlags, out bytesTransferred, out var errorCode))
		{
			return SocketError.WouldBlock;
		}
		return errorCode;
	}

	public static SocketError Receive(SafeSocketHandle handle, Span<byte> buffer, SocketFlags socketFlags, out int bytesTransferred)
	{
		if (!handle.IsNonBlocking)
		{
			return handle.AsyncContext.Receive(buffer, socketFlags, handle.ReceiveTimeout, out bytesTransferred);
		}
		if (!TryCompleteReceive(handle, buffer, socketFlags, out bytesTransferred, out var errorCode))
		{
			return SocketError.WouldBlock;
		}
		return errorCode;
	}

	private static SocketError GetErrorAndTrackSetting(SafeSocketHandle handle, SocketOptionLevel optionLevel, SocketOptionName optionName, global::Interop.Error err)
	{
		if (err == global::Interop.Error.SUCCESS)
		{
			handle.TrackSocketOption(optionLevel, optionName);
			return SocketError.Success;
		}
		return GetSocketErrorForErrorCode(err);
	}

	public unsafe static SocketError SetSockOpt(SafeSocketHandle handle, SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
	{
		global::Interop.Error err;
		switch (optionLevel)
		{
		case SocketOptionLevel.Socket:
			switch (optionName)
			{
			case SocketOptionName.ReceiveTimeout:
				handle.ReceiveTimeout = ((optionValue == 0) ? (-1) : optionValue);
				err = global::Interop.Sys.SetReceiveTimeout(handle, optionValue);
				return GetErrorAndTrackSetting(handle, optionLevel, optionName, err);
			case SocketOptionName.SendTimeout:
				handle.SendTimeout = ((optionValue == 0) ? (-1) : optionValue);
				err = global::Interop.Sys.SetSendTimeout(handle, optionValue);
				return GetErrorAndTrackSetting(handle, optionLevel, optionName, err);
			}
			break;
		case SocketOptionLevel.IP:
			if (optionName == SocketOptionName.MulticastInterface)
			{
				int num = IPAddress.NetworkToHostOrder(optionValue);
				if ((num & 0xFF000000u) == 0L)
				{
					global::Interop.Sys.IPv4MulticastOption pv4MulticastOption = new global::Interop.Sys.IPv4MulticastOption
					{
						MulticastAddress = 0u,
						LocalAddress = 0u,
						InterfaceIndex = num
					};
					err = global::Interop.Sys.SetIPv4MulticastOption(handle, global::Interop.Sys.MulticastOption.MULTICAST_IF, &pv4MulticastOption);
					return GetErrorAndTrackSetting(handle, optionLevel, optionName, err);
				}
			}
			break;
		}
		err = global::Interop.Sys.SetSockOpt(handle, optionLevel, optionName, (byte*)(&optionValue), 4);
		if (err == global::Interop.Error.SUCCESS && optionLevel == SocketOptionLevel.IPv6 && optionName == SocketOptionName.IPv6Only)
		{
			handle.DualMode = optionValue == 0;
		}
		return GetErrorAndTrackSetting(handle, optionLevel, optionName, err);
	}

	public unsafe static SocketError SetLingerOption(SafeSocketHandle handle, LingerOption optionValue)
	{
		global::Interop.Sys.LingerOption lingerOption = new global::Interop.Sys.LingerOption
		{
			OnOff = (optionValue.Enabled ? 1 : 0),
			Seconds = optionValue.LingerTime
		};
		global::Interop.Error err = global::Interop.Sys.SetLingerOption(handle, &lingerOption);
		return GetErrorAndTrackSetting(handle, SocketOptionLevel.Socket, SocketOptionName.Linger, err);
	}

	public unsafe static SocketError GetSockOpt(SafeSocketHandle handle, SocketOptionLevel optionLevel, SocketOptionName optionName, out int optionValue)
	{
		if (optionLevel == SocketOptionLevel.Socket)
		{
			switch (optionName)
			{
			case SocketOptionName.ReceiveTimeout:
				optionValue = ((handle.ReceiveTimeout != -1) ? handle.ReceiveTimeout : 0);
				return SocketError.Success;
			case SocketOptionName.SendTimeout:
				optionValue = ((handle.SendTimeout != -1) ? handle.SendTimeout : 0);
				return SocketError.Success;
			}
		}
		if (optionName == SocketOptionName.Error)
		{
			global::Interop.Error errorCode = global::Interop.Error.SUCCESS;
			global::Interop.Error socketErrorOption = global::Interop.Sys.GetSocketErrorOption(handle, &errorCode);
			optionValue = (int)GetSocketErrorForErrorCode(errorCode);
			if (socketErrorOption != global::Interop.Error.SUCCESS)
			{
				return GetSocketErrorForErrorCode(socketErrorOption);
			}
			return SocketError.Success;
		}
		int num = 0;
		int num2 = 4;
		global::Interop.Error sockOpt = global::Interop.Sys.GetSockOpt(handle, optionLevel, optionName, (byte*)(&num), &num2);
		optionValue = num;
		if (sockOpt != global::Interop.Error.SUCCESS)
		{
			return GetSocketErrorForErrorCode(sockOpt);
		}
		return SocketError.Success;
	}

	public unsafe static SocketError GetMulticastOption(SafeSocketHandle handle, SocketOptionName optionName, out MulticastOption optionValue)
	{
		global::Interop.Sys.MulticastOption multicastOption = ((optionName != SocketOptionName.AddMembership) ? global::Interop.Sys.MulticastOption.MULTICAST_DROP : global::Interop.Sys.MulticastOption.MULTICAST_ADD);
		global::Interop.Sys.IPv4MulticastOption pv4MulticastOption = default(global::Interop.Sys.IPv4MulticastOption);
		global::Interop.Error iPv4MulticastOption = global::Interop.Sys.GetIPv4MulticastOption(handle, multicastOption, &pv4MulticastOption);
		if (iPv4MulticastOption != global::Interop.Error.SUCCESS)
		{
			optionValue = null;
			return GetSocketErrorForErrorCode(iPv4MulticastOption);
		}
		IPAddress iPAddress = new IPAddress(pv4MulticastOption.MulticastAddress);
		IPAddress mcint = new IPAddress(pv4MulticastOption.LocalAddress);
		optionValue = new MulticastOption(iPAddress, mcint)
		{
			InterfaceIndex = pv4MulticastOption.InterfaceIndex
		};
		return SocketError.Success;
	}

	public unsafe static SocketError GetIPv6MulticastOption(SafeSocketHandle handle, SocketOptionName optionName, out IPv6MulticastOption optionValue)
	{
		global::Interop.Sys.MulticastOption multicastOption = ((optionName != SocketOptionName.AddMembership) ? global::Interop.Sys.MulticastOption.MULTICAST_DROP : global::Interop.Sys.MulticastOption.MULTICAST_ADD);
		global::Interop.Sys.IPv6MulticastOption pv6MulticastOption = default(global::Interop.Sys.IPv6MulticastOption);
		global::Interop.Error iPv6MulticastOption = global::Interop.Sys.GetIPv6MulticastOption(handle, multicastOption, &pv6MulticastOption);
		if (iPv6MulticastOption != global::Interop.Error.SUCCESS)
		{
			optionValue = null;
			return GetSocketErrorForErrorCode(iPv6MulticastOption);
		}
		optionValue = new IPv6MulticastOption(pv6MulticastOption.Address.GetIPAddress(), pv6MulticastOption.InterfaceIndex);
		return SocketError.Success;
	}

	public unsafe static SocketError GetLingerOption(SafeSocketHandle handle, out LingerOption optionValue)
	{
		global::Interop.Sys.LingerOption lingerOption = default(global::Interop.Sys.LingerOption);
		global::Interop.Error lingerOption2 = global::Interop.Sys.GetLingerOption(handle, &lingerOption);
		if (lingerOption2 != global::Interop.Error.SUCCESS)
		{
			optionValue = null;
			return GetSocketErrorForErrorCode(lingerOption2);
		}
		optionValue = new LingerOption(lingerOption.OnOff != 0, lingerOption.Seconds);
		return SocketError.Success;
	}

	public static SocketError Poll(SafeSocketHandle handle, int microseconds, SelectMode mode, out bool status)
	{
		global::Interop.PollEvents events = global::Interop.PollEvents.POLLNONE;
		switch (mode)
		{
		case SelectMode.SelectRead:
			events = global::Interop.PollEvents.POLLIN;
			break;
		case SelectMode.SelectWrite:
			events = global::Interop.PollEvents.POLLOUT;
			break;
		case SelectMode.SelectError:
			events = global::Interop.PollEvents.POLLPRI;
			break;
		}
		int timeout = ((microseconds == -1) ? (-1) : (microseconds / 1000));
		global::Interop.PollEvents triggered;
		global::Interop.Error error = global::Interop.Sys.Poll(handle, events, timeout, out triggered);
		if (error != global::Interop.Error.SUCCESS)
		{
			status = false;
			return GetSocketErrorForErrorCode(error);
		}
		switch (mode)
		{
		case SelectMode.SelectRead:
			status = (triggered & (global::Interop.PollEvents.POLLIN | global::Interop.PollEvents.POLLHUP)) != 0;
			break;
		case SelectMode.SelectWrite:
			status = (triggered & global::Interop.PollEvents.POLLOUT) != 0;
			break;
		case SelectMode.SelectError:
			status = (triggered & (global::Interop.PollEvents.POLLPRI | global::Interop.PollEvents.POLLERR)) != 0;
			break;
		default:
			status = false;
			break;
		}
		return SocketError.Success;
	}

	public static SocketError Shutdown(SafeSocketHandle handle, bool isConnected, bool isDisconnected, SocketShutdown how)
	{
		global::Interop.Error error = global::Interop.Sys.Shutdown(handle, how);
		switch (error)
		{
		case global::Interop.Error.SUCCESS:
			handle.TrackShutdown(how);
			return SocketError.Success;
		case global::Interop.Error.ENOTCONN:
			if (isConnected || isDisconnected)
			{
				handle.TrackShutdown(how);
				return SocketError.Success;
			}
			break;
		}
		return GetSocketErrorForErrorCode(error);
	}

	internal static SafeSocketHandle CreateSocket(nint fileDescriptor)
	{
		SafeSocketHandle result = new SafeSocketHandle(fileDescriptor, ownsHandle: true);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return result;
	}

	internal static bool HasNonBlockingConnectCompleted(SafeSocketHandle handle, out bool success)
	{
		global::Interop.PollEvents triggered;
		global::Interop.Error error = global::Interop.Sys.Poll(handle, global::Interop.PollEvents.POLLOUT, 0, out triggered);
		if (error != global::Interop.Error.SUCCESS)
		{
			throw new SocketException((int)GetSocketErrorForErrorCode(error));
		}
		if ((triggered & global::Interop.PollEvents.POLLOUT) == 0)
		{
			success = false;
			return false;
		}
		int optionValue;
		SocketError sockOpt = GetSockOpt(handle, SocketOptionLevel.Socket, SocketOptionName.Error, out optionValue);
		if (sockOpt != SocketError.Success)
		{
			throw new SocketException((int)sockOpt);
		}
		success = optionValue == 0;
		return true;
	}

	static SocketPal()
	{
		_ = 0;
		_ = 0;
		_ = 0;
		SelectOverPollIsBroken = false;
	}
}
