using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static class Interop
{
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

	internal static class Sys
	{
		[Flags]
		internal enum GetNameInfoFlags
		{
			NI_NAMEREQD = 1,
			NI_NUMERICHOST = 2
		}

		internal struct HostEntry
		{
			internal unsafe byte* CanonicalName;

			internal unsafe byte** Aliases;

			internal unsafe IPAddress* IPAddressList;

			internal int IPAddressCount;
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

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int GetHostName(byte* name, int nameLength)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(name, nameLength);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __name_native, int __nameLength_native);
		}

		internal unsafe static string GetHostName()
		{
			if (false)
			{
			}
			byte* num = stackalloc byte[256];
			int hostName = GetHostName(num, 256);
			if (hostName != 0)
			{
				throw new InvalidOperationException($"{"GetHostName"}: {hostName}");
			}
			num[255] = 0;
			return Marshal.PtrToStringUTF8((nint)num);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetNameInfo", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetNameInfo")]
		internal unsafe static extern int GetNameInfo(byte* address, uint addressLength, byte isIpv6, byte* host, uint hostLength, byte* service, uint serviceLength, GetNameInfoFlags flags);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetHostEntryForName", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int GetHostEntryForName(string address, AddressFamily family, HostEntry* entry)
		{
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(address, buffer);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), family, entry);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetHostEntryForName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __address_native, AddressFamily __family_native, HostEntry* __entry_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_FreeHostEntry", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FreeHostEntry")]
		internal unsafe static extern void FreeHostEntry(HostEntry* entry);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Socket", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Socket")]
		internal unsafe static extern Error Socket(int addressFamily, int socketType, int protocolType, nint* socket);
	}
}
