using System;
using System.CodeDom.Compiler;
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

	internal static class Sys
	{
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

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform")]
		[SuppressGCTransition]
		internal static extern int ConvertErrorPalToPlatform(Error error);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR")]
		private unsafe static extern byte* StrErrorR(int platformErrno, byte* buffer, int bufferSize);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketAddressSizes", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSocketAddressSizes")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetSocketAddressSizes(int* ipv4SocketAddressSize, int* ipv6SocketAddressSize, int* udsSocketAddressSize, int* maxSocketAddressSize);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetAddressFamily", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetAddressFamily")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetAddressFamily(byte* socketAddress, int socketAddressLen, int* addressFamily);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetAddressFamily", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetAddressFamily")]
		[SuppressGCTransition]
		internal unsafe static extern Error SetAddressFamily(byte* socketAddress, int socketAddressLen, int addressFamily);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPort", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPort")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetPort(byte* socketAddress, int socketAddressLen, ushort* port);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetPort", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetPort")]
		[SuppressGCTransition]
		internal unsafe static extern Error SetPort(byte* socketAddress, int socketAddressLen, ushort port);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv4Address")]
		[SuppressGCTransition]
		internal unsafe static extern Error GetIPv4Address(byte* socketAddress, int socketAddressLen, uint* address);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv4Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv4Address")]
		[SuppressGCTransition]
		internal unsafe static extern Error SetIPv4Address(byte* socketAddress, int socketAddressLen, uint address);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetIPv6Address")]
		internal unsafe static extern Error GetIPv6Address(byte* socketAddress, int socketAddressLen, byte* address, int addressLen, uint* scopeId);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv6Address", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetIPv6Address")]
		internal unsafe static extern Error SetIPv6Address(byte* socketAddress, int socketAddressLen, byte* address, int addressLen, uint scopeId);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_InterfaceNameToIndex", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		public unsafe static uint InterfaceNameToIndex(ReadOnlySpan<byte> utf8NullTerminatedName)
		{
			uint result;
			int lastSystemError;
			fixed (byte* ptr = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(utf8NullTerminatedName))
			{
				void* _utf8NullTerminatedName_native = ptr;
				Marshal.SetLastSystemError(0);
				result = __PInvoke((byte*)_utf8NullTerminatedName_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_InterfaceNameToIndex", ExactSpelling = true)]
			static extern unsafe uint __PInvoke(byte* __utf8NullTerminatedName_native);
		}
	}
}
