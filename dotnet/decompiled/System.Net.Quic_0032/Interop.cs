using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

internal static class Interop
{
	internal static class Crypto
	{
		private sealed class OpenSslCryptographicException : CryptographicException
		{
			internal OpenSslCryptographicException(int errorCode, string message)
				: base(message)
			{
				base.HResult = errorCode;
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_ErrGetExceptionError")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static ulong ErrGetExceptionError([MarshalAs(UnmanagedType.Bool)] out bool isAllocFailure)
		{
			isAllocFailure = false;
			Unsafe.SkipInit(out int num);
			ulong result = __PInvoke(&num);
			isAllocFailure = num != 0;
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_ErrGetExceptionError", ExactSpelling = true)]
			static extern unsafe ulong __PInvoke(int* __isAllocFailure_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_ErrErrorStringN", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_ErrErrorStringN")]
		private unsafe static extern void ErrErrorStringN(ulong e, byte* buf, int len);

		private unsafe static string ErrErrorStringN(ulong error)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(1024);
			string? result;
			fixed (byte* ptr = &array[0])
			{
				ErrErrorStringN(error, ptr, array.Length);
				result = Marshal.PtrToStringUTF8((nint)ptr);
			}
			ArrayPool<byte>.Shared.Return(array);
			return result;
		}

		internal static Exception CreateOpenSslCryptographicException()
		{
			bool isAllocFailure;
			ulong num = ErrGetExceptionError(out isAllocFailure);
			if (num == 0L)
			{
				return new CryptographicException();
			}
			if (isAllocFailure)
			{
				return new OutOfMemoryException();
			}
			return new OpenSslCryptographicException((int)num, ErrErrorStringN(num));
		}

		static Crypto()
		{
			CryptoInitializer.Initialize();
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_CheckX509IpAddress", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int CheckX509IpAddress(SafeX509Handle x509, byte[] addressBytes, int addressLen, string hostname, int cchHostname)
		{
			byte* ptr = default(byte*);
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(hostname, buffer);
				managedToUnmanagedIn2.FromManaged(x509);
				fixed (byte* ptr2 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(addressBytes))
				{
					void* _addressBytes_native = ptr2;
					ptr = managedToUnmanagedIn.ToUnmanaged();
					return __PInvoke(managedToUnmanagedIn2.ToUnmanaged(), (byte*)_addressBytes_native, addressLen, ptr, cchHostname);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_CheckX509IpAddress", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __x509_native, byte* __addressBytes_native, int __addressLen_native, byte* __hostname_native, int __cchHostname_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_CheckX509Hostname", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int CheckX509Hostname(SafeX509Handle x509, string hostname, int cchHostname)
		{
			byte* ptr = default(byte*);
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(hostname, buffer);
				managedToUnmanagedIn2.FromManaged(x509);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				return __PInvoke(managedToUnmanagedIn2.ToUnmanaged(), ptr, cchHostname);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_CheckX509Hostname", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __x509_native, byte* __hostname_native, int __cchHostname_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_X509Destroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_X509Destroy")]
		internal static extern void X509Destroy(nint a);

		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_X509UpRef")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeX509Handle X509UpRef(nint handle)
		{
			bool flag = false;
			SafeX509Handle safeX509Handle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(handle);
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(num);
				return managedToUnmanagedOut.ToManaged();
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
			}
			[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_X509UpRef", ExactSpelling = true)]
			static extern nint __PInvoke(nint __handle_native);
		}
	}

	internal static class CryptoInitializer
	{
		static CryptoInitializer()
		{
			if (EnsureOpenSslInitialized() != 0)
			{
				throw new InvalidOperationException();
			}
		}

		internal static void Initialize()
		{
		}

		[DllImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_EnsureOpenSslInitialized", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.OpenSsl", EntryPoint = "CryptoNative_EnsureOpenSslInitialized")]
		private static extern int EnsureOpenSslInitialized();
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

	internal static class Sys
	{
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
	}
}
