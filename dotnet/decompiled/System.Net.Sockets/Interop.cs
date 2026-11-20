using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static class Interop
{
	internal static class Sys
	{
		[Flags]
		internal enum SocketEvents
		{
			None = 0,
			Read = 1,
			Write = 2,
			ReadClose = 4,
			Close = 8,
			Error = 0x10
		}

		internal struct SocketEvent
		{
			public nint Data;

			public SocketEvents Events;

			private int _padding;
		}

		internal static class Fcntl
		{
			[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetIsNonBlocking", SetLastError = true)]
			[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
			internal static int DangerousSetIsNonBlocking(nint fd, int isNonBlocking)
			{
				Marshal.SetLastSystemError(0);
				int result = __PInvoke(fd, isNonBlocking);
				Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
				return result;
				[DllImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetIsNonBlocking", ExactSpelling = true)]
				static extern int __PInvoke(nint __fd_native, int __isNonBlocking_native);
			}

			[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetIsNonBlocking", SetLastError = true)]
			[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
			internal static int SetIsNonBlocking(SafeHandle fd, int isNonBlocking)
			{
				int result = 0;
				SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
				int lastSystemError;
				try
				{
					managedToUnmanagedIn.FromManaged(fd);
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, isNonBlocking);
					lastSystemError = Marshal.GetLastSystemError();
				}
				finally
				{
					managedToUnmanagedIn.Free();
				}
				Marshal.SetLastPInvokeError(lastSystemError);
				return result;
				[DllImport("libSystem.Native", EntryPoint = "SystemNative_FcntlSetIsNonBlocking", ExactSpelling = true)]
				static extern int __PInvoke(nint __fd_native, int __isNonBlocking_native);
			}

			[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FcntlGetIsNonBlocking", SetLastError = true)]
			[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
			internal unsafe static int GetIsNonBlocking(SafeHandle fd, [MarshalAs(UnmanagedType.Bool)] out bool isNonBlocking)
			{
				isNonBlocking = false;
				int num = 0;
				int result = 0;
				SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
				int lastSystemError;
				try
				{
					managedToUnmanagedIn.FromManaged(fd);
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, &num);
					lastSystemError = Marshal.GetLastSystemError();
					isNonBlocking = num != 0;
				}
				finally
				{
					managedToUnmanagedIn.Free();
				}
				Marshal.SetLastPInvokeError(lastSystemError);
				return result;
				[DllImport("libSystem.Native", EntryPoint = "SystemNative_FcntlGetIsNonBlocking", ExactSpelling = true)]
				static extern unsafe int __PInvoke(nint __fd_native, int* __isNonBlocking_native);
			}

			[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FcntlGetFD", SetLastError = true)]
			[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
			internal static int GetFD(nint fd)
			{
				Marshal.SetLastSystemError(0);
				int result = __PInvoke(fd);
				Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
				return result;
				[DllImport("libSystem.Native", EntryPoint = "SystemNative_FcntlGetFD", ExactSpelling = true)]
				static extern int __PInvoke(nint __fd_native);
			}
		}

		internal struct IPAddress : IEquatable<IPAddress>
		{
			internal unsafe fixed byte Address[16];

			private uint _isIPv6;

			internal uint ScopeId;

			public bool IsIPv6 => _isIPv6 != 0;

			public unsafe override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.AddBytes(MemoryMarshal.CreateReadOnlySpan(in Address[0], IsIPv6 ? 16 : 4));
				return hashCode.ToHashCode();
			}

			public override bool Equals([NotNullWhen(true)] object obj)
			{
				if (obj is IPAddress other)
				{
					return Equals(other);
				}
				return false;
			}

			public unsafe bool Equals(IPAddress other)
			{
				int length;
				if (IsIPv6)
				{
					if (!other.IsIPv6)
					{
						return false;
					}
					if (ScopeId != other.ScopeId)
					{
						return false;
					}
					length = 16;
				}
				else
				{
					if (other.IsIPv6)
					{
						return false;
					}
					length = 4;
				}
				return MemoryMarshal.CreateReadOnlySpan(in Address[0], length).SequenceEqual(new ReadOnlySpan<byte>(other.Address, length));
			}
		}

		internal struct LingerOption
		{
			public int OnOff;

			public int Seconds;
		}

		internal struct FileStatus
		{
			internal FileStatusFlags Flags;

			internal int Mode;

			internal uint Uid;

			internal uint Gid;

			internal long Size;

			internal long ATime;

			internal long ATimeNsec;

			internal long MTime;

			internal long MTimeNsec;

			internal long CTime;

			internal long CTimeNsec;

			internal long BirthTime;

			internal long BirthTimeNsec;

			internal long Dev;

			internal long RDev;

			internal long Ino;

			internal uint UserFlags;
		}

		[Flags]
		internal enum FileStatusFlags
		{
			None = 0,
			HasBirthTime = 1
		}

		internal struct IOVector
		{
			public unsafe byte* Base;

			public nuint Count;
		}

		internal struct MessageHeader
		{
			public unsafe byte* SocketAddress;

			public unsafe IOVector* IOVectors;

			public unsafe byte* ControlBuffer;

			public int SocketAddressLen;

			public int IOVectorCount;

			public int ControlBufferLen;

			public SocketFlags Flags;
		}

		internal enum MulticastOption
		{
			MULTICAST_ADD,
			MULTICAST_DROP,
			MULTICAST_IF
		}

		internal struct IPv4MulticastOption
		{
			public uint MulticastAddress;

			public uint LocalAddress;

			public int InterfaceIndex;

			private int _padding;
		}

		internal struct IPv6MulticastOption
		{
			public IPAddress Address;

			public int InterfaceIndex;

			private int _padding;
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_CreateSocketEventPort", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CreateSocketEventPort")]
		internal unsafe static extern Error CreateSocketEventPort(nint* port);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_CloseSocketEventPort", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CloseSocketEventPort")]
		internal static extern Error CloseSocketEventPort(nint port);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_CreateSocketEventBuffer", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CreateSocketEventBuffer")]
		internal unsafe static extern Error CreateSocketEventBuffer(int count, SocketEvent** buffer);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_FreeSocketEventBuffer", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FreeSocketEventBuffer")]
		internal unsafe static extern Error FreeSocketEventBuffer(SocketEvent* buffer);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_TryChangeSocketEventRegistration", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_TryChangeSocketEventRegistration")]
		internal static extern Error TryChangeSocketEventRegistration(nint port, nint socket, SocketEvents currentEvents, SocketEvents newEvents, nint data);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_WaitForSocketEvents", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_WaitForSocketEvents")]
		internal unsafe static extern Error WaitForSocketEvents(nint port, SocketEvent* buffer, int* count);

		internal static Error GetLastError()
		{
			return ConvertErrorPlatformToPal(Marshal.GetLastPInvokeError());
		}

		internal unsafe static string StrError(int platformErrno)
		{
			byte* ptr = stackalloc byte[1024];
			byte* ptr2 = StrErrorR(platformErrno, ptr, 1024);
			if (ptr2 == null)
			{
				ptr2 = ptr;
			}
			return Marshal.PtrToStringUTF8((nint)ptr2);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal")]
		[SuppressGCTransition]
		internal static extern Error ConvertErrorPlatformToPal(int platformErrno);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform")]
		[SuppressGCTransition]
		internal static extern int ConvertErrorPalToPlatform(Error error);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR")]
		private unsafe static extern byte* StrErrorR(int platformErrno, byte* buffer, int bufferSize);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Accept")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error Accept(SafeHandle socket, byte* socketAddress, int* socketAddressLen, nint* acceptedFd)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketAddress, socketAddressLen, acceptedFd);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Accept", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __socketAddress_native, int* __socketAddressLen_native, nint* __acceptedFd_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Bind")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static Error Bind(SafeHandle socket, ProtocolType socketProtocolType, ReadOnlySpan<byte> socketAddress, int socketAddressLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				fixed (byte* ptr = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(socketAddress))
				{
					void* _socketAddress_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketProtocolType, (byte*)_socketAddress_native, socketAddressLen);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Bind", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, ProtocolType __socketProtocolType_native, byte* __socketAddress_native, int __socketAddressLen_native);
		}

		internal static Error Bind(SafeHandle socket, ProtocolType socketProtocolType, ReadOnlySpan<byte> socketAddress)
		{
			return Bind(socket, socketProtocolType, socketAddress, socketAddress.Length);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Close", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int Close(nint fd)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(fd);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Close", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Connect")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error Connect(SafeHandle socket, byte* socketAddress, int socketAddressLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketAddress, socketAddressLen);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Connect", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __socketAddress_native, int __socketAddressLen_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Connectx")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error Connectx(SafeHandle socket, byte* socketAddress, int socketAddressLen, Span<byte> buffer, int bufferLen, int enableTfo, int* sent)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				fixed (byte* ptr = &SpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(buffer))
				{
					void* _buffer_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketAddress, socketAddressLen, (byte*)_buffer_native, bufferLen, enableTfo, sent);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Connectx", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __socketAddress_native, int __socketAddressLen_native, byte* __buffer_native, int __bufferLen_native, int __enableTfo_native, int* __sent_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Disconnect", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Disconnect")]
		internal static extern Error Disconnect(nint socket);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetBytesAvailable")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetBytesAvailable(SafeHandle socket, int* available)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), available);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetBytesAvailable", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, int* __available_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetDomainSocketSizes", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetDomainSocketSizes")]
		[SuppressGCTransition]
		internal unsafe static extern void GetDomainSocketSizes(int* pathOffset, int* pathSize, int* addressSize);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetMaximumAddressSize", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetMaximumAddressSize")]
		[SuppressGCTransition]
		internal static extern int GetMaximumAddressSize();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPeerName")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetPeerName(SafeHandle socket, byte* socketAddress, int* socketAddressLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketAddress, socketAddressLen);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPeerName", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __socketAddress_native, int* __socketAddressLen_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketErrorOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetSocketErrorOption(SafeHandle socket, Error* socketError)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketError);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketErrorOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, Error* __socketError_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketType")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetSocketType(SafeSocketHandle socket, out AddressFamily addressFamily, out SocketType socketType, out ProtocolType protocolType, [MarshalAs(UnmanagedType.Bool)] out bool isListening)
		{
			addressFamily = AddressFamily.Unspecified;
			socketType = (SocketType)0;
			protocolType = ProtocolType.IP;
			isListening = false;
			int num = 0;
			Error result = Error.SUCCESS;
			SafeHandleMarshaller<SafeSocketHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSocketHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				fixed (ProtocolType* _protocolType_native = &protocolType)
				{
					fixed (SocketType* _socketType_native = &socketType)
					{
						fixed (AddressFamily* _addressFamily_native = &addressFamily)
						{
							result = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _addressFamily_native, _socketType_native, _protocolType_native, &num);
						}
					}
				}
				isListening = num != 0;
				return result;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketType", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, AddressFamily* __addressFamily_native, SocketType* __socketType_native, ProtocolType* __protocolType_native, int* __isListening_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSockName")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetSockName(SafeHandle socket, byte* socketAddress, int* socketAddressLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), socketAddress, socketAddressLen);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSockName", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __socketAddress_native, int* __socketAddressLen_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSockOpt")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetSockOpt(SafeHandle socket, SocketOptionLevel optionLevel, SocketOptionName optionName, byte* optionValue, int* optionLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), optionLevel, optionName, optionValue, optionLen);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSockOpt", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, SocketOptionLevel __optionLevel_native, SocketOptionName __optionName_native, byte* __optionValue_native, int* __optionLen_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSockOpt", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSockOpt")]
		internal unsafe static extern Error GetSockOpt(nint socket, SocketOptionLevel optionLevel, SocketOptionName optionName, byte* optionValue, int* optionLen);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetLingerOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetLingerOption(SafeHandle socket, LingerOption* option)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), option);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetLingerOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, LingerOption* __option_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetLingerOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error SetLingerOption(SafeHandle socket, LingerOption* option)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), option);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetLingerOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, LingerOption* __option_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetLingerOption", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetLingerOption")]
		internal unsafe static extern Error SetLingerOption(nint socket, LingerOption* option);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetSendTimeout")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static Error SetSendTimeout(SafeHandle socket, int millisecondsTimeout)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), millisecondsTimeout);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetSendTimeout", ExactSpelling = true)]
			static extern Error __PInvoke(nint __socket_native, int __millisecondsTimeout_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetReceiveTimeout")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static Error SetReceiveTimeout(SafeHandle socket, int millisecondsTimeout)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), millisecondsTimeout);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetReceiveTimeout", ExactSpelling = true)]
			static extern Error __PInvoke(nint __socket_native, int __millisecondsTimeout_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FStat", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int FStat(SafeHandle fd, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				fixed (FileStatus* _output_native = &output)
				{
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, FileStatus* __output_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Listen")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static Error Listen(SafeHandle socket, int backlog)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), backlog);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Listen", ExactSpelling = true)]
			static extern Error __PInvoke(nint __socket_native, int __backlog_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4MulticastOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetIPv4MulticastOption(SafeHandle socket, MulticastOption multicastOption, IPv4MulticastOption* option)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), multicastOption, option);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4MulticastOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, MulticastOption __multicastOption_native, IPv4MulticastOption* __option_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv4MulticastOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error SetIPv4MulticastOption(SafeHandle socket, MulticastOption multicastOption, IPv4MulticastOption* option)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), multicastOption, option);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv4MulticastOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, MulticastOption __multicastOption_native, IPv4MulticastOption* __option_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6MulticastOption")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error GetIPv6MulticastOption(SafeHandle socket, MulticastOption multicastOption, IPv6MulticastOption* option)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), multicastOption, option);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6MulticastOption", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, MulticastOption __multicastOption_native, IPv6MulticastOption* __option_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Poll", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Poll")]
		internal unsafe static extern Error Poll(PollEvent* pollEvents, uint eventCount, int timeout, uint* triggered);

		internal unsafe static Error Poll(SafeHandle fd, PollEvents events, int timeout, out PollEvents triggered)
		{
			bool success = false;
			try
			{
				fd.DangerousAddRef(ref success);
				PollEvent pollEvent = new PollEvent
				{
					FileDescriptor = ((IntPtr)fd.DangerousGetHandle()).ToInt32(),
					Events = events
				};
				Unsafe.SkipInit(out uint num);
				Error result = Poll(&pollEvent, 1u, timeout, &num);
				triggered = pollEvent.TriggeredEvents;
				return result;
			}
			finally
			{
				if (success)
				{
					fd.DangerousRelease();
				}
			}
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_PlatformSupportsDualModeIPv4PacketInfo", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PlatformSupportsDualModeIPv4PacketInfo")]
		[SuppressGCTransition]
		internal static extern int PlatformSupportsDualModeIPv4PacketInfo();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Read", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Read(SafeHandle fd, byte* buffer, int count)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, count);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Read", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __count_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Receive")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error Receive(SafeHandle socket, byte* buffer, int bufferLen, SocketFlags flags, int* received)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), buffer, bufferLen, flags, received);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Receive", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __buffer_native, int __bufferLen_native, SocketFlags __flags_native, int* __received_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ReceiveMessage")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error ReceiveMessage(SafeHandle socket, MessageHeader* messageHeader, SocketFlags flags, long* received)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), messageHeader, flags, received);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ReceiveMessage", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, MessageHeader* __messageHeader_native, SocketFlags __flags_native, long* __received_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Send")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error Send(SafeHandle socket, byte* buffer, int bufferLen, SocketFlags flags, int* sent)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), buffer, bufferLen, flags, sent);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Send", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, byte* __buffer_native, int __bufferLen_native, SocketFlags __flags_native, int* __sent_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SendMessage")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error SendMessage(SafeHandle socket, MessageHeader* messageHeader, SocketFlags flags, long* sent)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), messageHeader, flags, sent);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SendMessage", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, MessageHeader* __messageHeader_native, SocketFlags __flags_native, long* __sent_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetSockOpt")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static Error SetSockOpt(SafeHandle socket, SocketOptionLevel optionLevel, SocketOptionName optionName, byte* optionValue, int optionLen)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), optionLevel, optionName, optionValue, optionLen);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetSockOpt", ExactSpelling = true)]
			static extern unsafe Error __PInvoke(nint __socket_native, SocketOptionLevel __optionLevel_native, SocketOptionName __optionName_native, byte* __optionValue_native, int __optionLen_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetSockOpt", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetSockOpt")]
		internal unsafe static extern Error SetSockOpt(nint socket, SocketOptionLevel optionLevel, SocketOptionName optionName, byte* optionValue, int optionLen);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Shutdown")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static Error Shutdown(SafeHandle socket, SocketShutdown how)
		{
			Error error = Error.SUCCESS;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(socket);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), how);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Shutdown", ExactSpelling = true)]
			static extern Error __PInvoke(nint __socket_native, SocketShutdown __how_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Shutdown", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Shutdown")]
		internal static extern Error Shutdown(nint socket, SocketShutdown how);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Socket", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Socket")]
		internal unsafe static extern Error Socket(int addressFamily, int socketType, int protocolType, nint* socket);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketAddressSizes", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketAddressSizes")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetSocketAddressSizes(int* ipv4SocketAddressSize, int* ipv6SocketAddressSize, int* udsSocketAddressSize, int* maxSocketAddressSize);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetAddressFamily", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetAddressFamily")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetAddressFamily(byte* socketAddress, int socketAddressLen, int* addressFamily);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPort", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPort")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetPort(byte* socketAddress, int socketAddressLen, ushort* port);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4Address")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetIPv4Address(byte* socketAddress, int socketAddressLen, uint* address);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6Address")]
		internal unsafe static extern Error GetIPv6Address(byte* socketAddress, int socketAddressLen, byte* address, int addressLen, uint* scopeId);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Write", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Write(SafeHandle fd, byte* buffer, int bufferSize)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, bufferSize);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Write", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __bufferSize_native);
		}
	}

	internal enum Error
	{
		SUCCESS = 0,
		E2BIG = 65537,
		EACCES = 65538,
		EADDRINUSE = 65539,
		EADDRNOTAVAIL = 65540,
		EAFNOSUPPORT = 65541,
		EAGAIN = 65542,
		EALREADY = 65543,
		EBADF = 65544,
		EBADMSG = 65545,
		EBUSY = 65546,
		ECANCELED = 65547,
		ECHILD = 65548,
		ECONNABORTED = 65549,
		ECONNREFUSED = 65550,
		ECONNRESET = 65551,
		EDEADLK = 65552,
		EDESTADDRREQ = 65553,
		EDOM = 65554,
		EDQUOT = 65555,
		EEXIST = 65556,
		EFAULT = 65557,
		EFBIG = 65558,
		EHOSTUNREACH = 65559,
		EIDRM = 65560,
		EILSEQ = 65561,
		EINPROGRESS = 65562,
		EINTR = 65563,
		EINVAL = 65564,
		EIO = 65565,
		EISCONN = 65566,
		EISDIR = 65567,
		ELOOP = 65568,
		EMFILE = 65569,
		EMLINK = 65570,
		EMSGSIZE = 65571,
		EMULTIHOP = 65572,
		ENAMETOOLONG = 65573,
		ENETDOWN = 65574,
		ENETRESET = 65575,
		ENETUNREACH = 65576,
		ENFILE = 65577,
		ENOBUFS = 65578,
		ENODEV = 65580,
		ENOENT = 65581,
		ENOEXEC = 65582,
		ENOLCK = 65583,
		ENOLINK = 65584,
		ENOMEM = 65585,
		ENOMSG = 65586,
		ENOPROTOOPT = 65587,
		ENOSPC = 65588,
		ENOSYS = 65591,
		ENOTCONN = 65592,
		ENOTDIR = 65593,
		ENOTEMPTY = 65594,
		ENOTRECOVERABLE = 65595,
		ENOTSOCK = 65596,
		ENOTSUP = 65597,
		ENOTTY = 65598,
		ENXIO = 65599,
		EOVERFLOW = 65600,
		EOWNERDEAD = 65601,
		EPERM = 65602,
		EPIPE = 65603,
		EPROTO = 65604,
		EPROTONOSUPPORT = 65605,
		EPROTOTYPE = 65606,
		ERANGE = 65607,
		EROFS = 65608,
		ESPIPE = 65609,
		ESRCH = 65610,
		ESTALE = 65611,
		ETIMEDOUT = 65613,
		ETXTBSY = 65614,
		EXDEV = 65615,
		ESOCKTNOSUPPORT = 65630,
		EPFNOSUPPORT = 65632,
		ESHUTDOWN = 65644,
		EHOSTDOWN = 65648,
		ENODATA = 65649,
		EHOSTNOTFOUND = 131073,
		ESOCKETERROR = 131074,
		EOPNOTSUPP = 65597,
		EWOULDBLOCK = 65542
	}

	internal struct ErrorInfo
	{
		private readonly Error _error;

		private int _rawErrno;

		internal Error Error => _error;

		internal int RawErrno
		{
			get
			{
				if (_rawErrno != -1)
				{
					return _rawErrno;
				}
				return _rawErrno = Sys.ConvertErrorPalToPlatform(_error);
			}
		}

		internal ErrorInfo(Error error)
		{
			_error = error;
			_rawErrno = -1;
		}

		internal string GetErrorMessage()
		{
			return Sys.StrError(RawErrno);
		}

		public override string ToString()
		{
			return $"RawErrno: {RawErrno} Error: {Error} GetErrorMessage: {GetErrorMessage()}";
		}
	}

	[Flags]
	internal enum PollEvents : short
	{
		POLLNONE = 0,
		POLLIN = 1,
		POLLPRI = 2,
		POLLOUT = 4,
		POLLERR = 8,
		POLLHUP = 0x10,
		POLLNVAL = 0x20
	}

	internal struct PollEvent
	{
		internal int FileDescriptor;

		internal PollEvents Events;

		internal PollEvents TriggeredEvents;
	}
}
