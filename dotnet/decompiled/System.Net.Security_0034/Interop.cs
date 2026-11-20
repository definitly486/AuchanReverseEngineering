using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

internal static class Interop
{
	internal static class JObjectLifetime
	{
		internal class SafeJObjectHandle : SafeHandle
		{
			public override bool IsInvalid => handle == IntPtr.Zero;

			public SafeJObjectHandle()
				: base(IntPtr.Zero, ownsHandle: true)
			{
			}

			internal SafeJObjectHandle(nint ptr)
				: base(IntPtr.Zero, ownsHandle: true)
			{
				SetHandle(ptr);
			}

			protected override bool ReleaseHandle()
			{
				DeleteGlobalReference(handle);
				SetHandle(IntPtr.Zero);
				return true;
			}
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DeleteGlobalReference", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DeleteGlobalReference")]
		internal static extern void DeleteGlobalReference(nint obj);
	}

	internal static class AndroidCrypto
	{
		internal enum PAL_SSLStreamStatus
		{
			OK,
			NeedData,
			Error,
			Renegotiate,
			Closed
		}

		private struct ApplicationProtocolData
		{
			public unsafe byte* Data;

			public int Length;
		}

		internal sealed class SslException : Exception
		{
			internal SslException()
			{
			}

			internal SslException(int errorCode)
			{
				base.HResult = errorCode;
			}
		}

		internal enum PAL_KeyAlgorithm
		{
			DSA = 0,
			EC = 1,
			RSA = 2,
			UnknownAlgorithm = -1
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static SafeSslHandle SSLStreamCreate(nint sslStreamProxyHandle)
		{
			bool flag = false;
			SafeSslHandle safeSslHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(sslStreamProxyHandle);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreate", ExactSpelling = true)]
			static extern nint __PInvoke(nint __sslStreamProxyHandle_native);
		}

		internal static SafeSslHandle SSLStreamCreate(SslStream.JavaProxy sslStreamProxy)
		{
			return SSLStreamCreate(sslStreamProxy.Handle);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreateWithCertificates")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static SafeSslHandle SSLStreamCreateWithCertificates(nint sslStreamProxyHandle, ref byte pkcs8PrivateKey, int pkcs8PrivateKeyLen, PAL_KeyAlgorithm algorithm, nint[] certs, int certsLen)
		{
			bool flag = false;
			SafeSslHandle safeSslHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (nint* ptr = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(certs))
				{
					void* _certs_native = ptr;
					fixed (byte* _pkcs8PrivateKey_native = &pkcs8PrivateKey)
					{
						value = __PInvoke(sslStreamProxyHandle, _pkcs8PrivateKey_native, pkcs8PrivateKeyLen, algorithm, (nint*)_certs_native, certsLen);
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value);
				return managedToUnmanagedOut.ToManaged();
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreateWithCertificates", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(nint __sslStreamProxyHandle_native, byte* __pkcs8PrivateKey_native, int __pkcs8PrivateKeyLen_native, PAL_KeyAlgorithm __algorithm_native, nint* __certs_native, int __certsLen_native);
		}

		internal static SafeSslHandle SSLStreamCreateWithCertificates(SslStream.JavaProxy sslStreamProxy, ReadOnlySpan<byte> pkcs8PrivateKey, PAL_KeyAlgorithm algorithm, nint[] certificates)
		{
			return SSLStreamCreateWithCertificates(sslStreamProxy.Handle, ref MemoryMarshal.GetReference(pkcs8PrivateKey), pkcs8PrivateKey.Length, algorithm, certificates, certificates.Length);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreateWithKeyStorePrivateKeyEntry")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static SafeSslHandle SSLStreamCreateWithKeyStorePrivateKeyEntry(nint sslStreamProxyHandle, nint keyStorePrivateKeyEntryHandle)
		{
			bool flag = false;
			SafeSslHandle safeSslHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(sslStreamProxyHandle, keyStorePrivateKeyEntryHandle);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamCreateWithKeyStorePrivateKeyEntry", ExactSpelling = true)]
			static extern nint __PInvoke(nint __sslStreamProxyHandle_native, nint __keyStorePrivateKeyEntryHandle_native);
		}

		internal static SafeSslHandle SSLStreamCreateWithKeyStorePrivateKeyEntry(SslStream.JavaProxy sslStreamProxy, nint keyStorePrivateKeyEntryHandle)
		{
			return SSLStreamCreateWithKeyStorePrivateKeyEntry(sslStreamProxy.Handle, keyStorePrivateKeyEntryHandle);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RegisterRemoteCertificateValidationCallback", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RegisterRemoteCertificateValidationCallback")]
		internal unsafe static extern void RegisterRemoteCertificateValidationCallback(delegate* unmanaged<nint, bool> verifyRemoteCertificate);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamInitialize")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamInitializeImpl(SafeSslHandle sslHandle, [MarshalAs(UnmanagedType.U1)] bool isServer, nint managedContextHandle, delegate* unmanaged<nint, byte*, int*, PAL_SSLStreamStatus> streamRead, delegate* unmanaged<nint, byte*, int, void> streamWrite, delegate* unmanaged<nint, void> managedContextCleanup, int appBufferSize, [MarshalAs(UnmanagedType.LPUTF8Str)] string peerHost)
		{
			byte b = 0;
			byte* ptr = default(byte*);
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(peerHost, buffer);
				b = (isServer ? ((byte)1) : ((byte)0));
				managedToUnmanagedIn2.FromManaged(sslHandle);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				return __PInvoke(managedToUnmanagedIn2.ToUnmanaged(), b, managedContextHandle, streamRead, streamWrite, managedContextCleanup, appBufferSize, ptr);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamInitialize", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sslHandle_native, byte __isServer_native, nint __managedContextHandle_native, delegate* unmanaged<nint, byte*, int*, PAL_SSLStreamStatus> __streamRead_native, delegate* unmanaged<nint, byte*, int, void> __streamWrite_native, delegate* unmanaged<nint, void> __managedContextCleanup_native, int __appBufferSize_native, byte* __peerHost_native);
		}

		internal unsafe static void SSLStreamInitialize(SafeSslHandle sslHandle, bool isServer, nint managedContextHandle, delegate* unmanaged<nint, byte*, int*, PAL_SSLStreamStatus> streamRead, delegate* unmanaged<nint, byte*, int, void> streamWrite, delegate* unmanaged<nint, void> managedContextCleanup, int appBufferSize, string peerHost)
		{
			if (SSLStreamInitializeImpl(sslHandle, isServer, managedContextHandle, streamRead, streamWrite, managedContextCleanup, appBufferSize, peerHost) != 1)
			{
				throw new SslException();
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetTargetHost")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamSetTargetHostImpl(SafeSslHandle sslHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string targetHost)
		{
			byte* ptr = default(byte*);
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(targetHost, buffer);
				managedToUnmanagedIn2.FromManaged(sslHandle);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				return __PInvoke(managedToUnmanagedIn2.ToUnmanaged(), ptr);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetTargetHost", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sslHandle_native, byte* __targetHost_native);
		}

		internal static void SSLStreamSetTargetHost(SafeSslHandle sslHandle, string targetHost)
		{
			switch (SSLStreamSetTargetHostImpl(sslHandle, targetHost))
			{
			case 2:
				throw new PlatformNotSupportedException("net_android_ssl_api_level_unsupported");
			default:
				throw new SslException();
			case 1:
				break;
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamIsLocalCertificateUsed")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static bool SSLStreamIsLocalCertificateUsed(SafeSslHandle sslHandle)
		{
			bool flag = false;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged()) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamIsLocalCertificateUsed", ExactSpelling = true)]
			static extern byte __PInvoke(nint __sslHandle_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRequestClientAuthentication")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static void SSLStreamRequestClientAuthentication(SafeSslHandle sslHandle)
		{
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				__PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRequestClientAuthentication", ExactSpelling = true)]
			static extern void __PInvoke(nint __sslHandle_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetApplicationProtocols")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamSetApplicationProtocols(SafeSslHandle sslHandle, ApplicationProtocolData[] protocolData, int count)
		{
			int num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				fixed (ApplicationProtocolData* ptr = &ArrayMarshaller<ApplicationProtocolData, ApplicationProtocolData>.ManagedToUnmanagedIn.GetPinnableReference(protocolData))
				{
					void* _protocolData_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (ApplicationProtocolData*)_protocolData_native, count);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetApplicationProtocols", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sslHandle_native, ApplicationProtocolData* __protocolData_native, int __count_native);
		}

		internal unsafe static void SSLStreamSetApplicationProtocols(SafeSslHandle sslHandle, List<SslApplicationProtocol> protocols)
		{
			int count = protocols.Count;
			MemoryHandle[] array = new MemoryHandle[count];
			ApplicationProtocolData[] array2 = new ApplicationProtocolData[count];
			try
			{
				for (int i = 0; i < count; i++)
				{
					ReadOnlyMemory<byte> protocol = protocols[i].Protocol;
					array[i] = protocol.Pin();
					array2[i] = new ApplicationProtocolData
					{
						Data = (byte*)array[i].Pointer,
						Length = protocol.Length
					};
				}
				if (SSLStreamSetApplicationProtocols(sslHandle, array2, count) != 1)
				{
					throw new SslException();
				}
			}
			finally
			{
				MemoryHandle[] array3 = array;
				foreach (MemoryHandle memoryHandle in array3)
				{
					memoryHandle.Dispose();
				}
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetEnabledProtocols")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamSetEnabledProtocols(SafeSslHandle sslHandle, ref SslProtocols protocols, int length)
		{
			int num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				fixed (SslProtocols* _protocols_native = &protocols)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _protocols_native, length);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamSetEnabledProtocols", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sslHandle_native, SslProtocols* __protocols_native, int __length_native);
		}

		internal static void SSLStreamSetEnabledProtocols(SafeSslHandle sslHandle, ReadOnlySpan<SslProtocols> protocols)
		{
			if (SSLStreamSetEnabledProtocols(sslHandle, ref MemoryMarshal.GetReference(protocols), protocols.Length) != 1)
			{
				throw new SslException();
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamHandshake")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static PAL_SSLStreamStatus SSLStreamHandshake(SafeSslHandle sslHandle)
		{
			PAL_SSLStreamStatus pAL_SSLStreamStatus = PAL_SSLStreamStatus.OK;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamHandshake", ExactSpelling = true)]
			static extern PAL_SSLStreamStatus __PInvoke(nint __sslHandle_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetApplicationProtocol")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamGetApplicationProtocol(SafeSslHandle ssl, byte[] buf, ref int len)
		{
			int num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ssl);
				fixed (int* _len_native = &len)
				{
					fixed (byte* ptr = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(buf))
					{
						void* _buf_native = ptr;
						return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (byte*)_buf_native, _len_native);
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetApplicationProtocol", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ssl_native, byte* __buf_native, int* __len_native);
		}

		internal static byte[] SSLStreamGetApplicationProtocol(SafeSslHandle ssl)
		{
			int len = 0;
			if (SSLStreamGetApplicationProtocol(ssl, null, ref len) != -1)
			{
				return null;
			}
			byte[] array = new byte[len];
			if (SSLStreamGetApplicationProtocol(ssl, array, ref len) != 1)
			{
				return null;
			}
			return array;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRead")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static PAL_SSLStreamStatus SSLStreamRead(SafeSslHandle sslHandle, byte* buffer, int length, out int bytesRead)
		{
			bytesRead = 0;
			PAL_SSLStreamStatus pAL_SSLStreamStatus = PAL_SSLStreamStatus.OK;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				fixed (int* _bytesRead_native = &bytesRead)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), buffer, length, _bytesRead_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRead", ExactSpelling = true)]
			static extern unsafe PAL_SSLStreamStatus __PInvoke(nint __sslHandle_native, byte* __buffer_native, int __length_native, int* __bytesRead_native);
		}

		internal unsafe static PAL_SSLStreamStatus SSLStreamRead(SafeSslHandle sslHandle, ReadOnlySpan<byte> buffer, out int bytesRead)
		{
			fixed (byte* buffer2 = buffer)
			{
				return SSLStreamRead(sslHandle, buffer2, buffer.Length, out bytesRead);
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamWrite")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static PAL_SSLStreamStatus SSLStreamWrite(SafeSslHandle sslHandle, byte* buffer, int length)
		{
			PAL_SSLStreamStatus pAL_SSLStreamStatus = PAL_SSLStreamStatus.OK;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(sslHandle);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), buffer, length);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamWrite", ExactSpelling = true)]
			static extern unsafe PAL_SSLStreamStatus __PInvoke(nint __sslHandle_native, byte* __buffer_native, int __length_native);
		}

		internal unsafe static PAL_SSLStreamStatus SSLStreamWrite(SafeSslHandle sslHandle, ReadOnlyMemory<byte> buffer)
		{
			using MemoryHandle memoryHandle = buffer.Pin();
			return SSLStreamWrite(sslHandle, (byte*)memoryHandle.Pointer, buffer.Length);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRelease", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamRelease")]
		internal static extern void SSLStreamRelease(nint ptr);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetProtocol")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamGetProtocol(SafeSslHandle ssl, out nint protocol)
		{
			protocol = 0;
			int num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ssl);
				fixed (nint* _protocol_native = &protocol)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _protocol_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetProtocol", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ssl_native, nint* __protocol_native);
		}

		internal static string SSLStreamGetProtocol(SafeSslHandle ssl)
		{
			if (SSLStreamGetProtocol(ssl, out var protocol) != 1)
			{
				throw new SslException();
			}
			if (protocol == IntPtr.Zero)
			{
				return string.Empty;
			}
			string? result = Marshal.PtrToStringUni(protocol);
			Marshal.FreeHGlobal(protocol);
			return result;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetPeerCertificate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static System.Security.Cryptography.X509Certificates.SafeX509Handle SSLStreamGetPeerCertificate(SafeSslHandle ssl)
		{
			bool flag = false;
			System.Security.Cryptography.X509Certificates.SafeX509Handle safeX509Handle = null;
			nint num = 0;
			SafeHandleMarshaller<System.Security.Cryptography.X509Certificates.SafeX509Handle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<System.Security.Cryptography.X509Certificates.SafeX509Handle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ssl);
				num = __PInvoke(managedToUnmanagedIn.ToUnmanaged());
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
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetPeerCertificate", ExactSpelling = true)]
			static extern nint __PInvoke(nint __ssl_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetPeerCertificates")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static void SSLStreamGetPeerCertificates(SafeSslHandle ssl, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out nint[] certs, out int count)
		{
			bool flag = false;
			certs = null;
			count = 0;
			nint* ptr = default(nint*);
			Unsafe.SkipInit<int>(out var value);
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ssl);
				fixed (int* _count_native = &count)
				{
					__PInvoke(managedToUnmanagedIn.ToUnmanaged(), &ptr, _count_native);
				}
				flag = true;
				value = count;
				certs = ArrayMarshaller<nint, nint>.AllocateContainerForManagedElements(ptr, value);
				ArrayMarshaller<nint, nint>.GetUnmanagedValuesSource(ptr, value).CopyTo(ArrayMarshaller<nint, nint>.GetManagedValuesDestination(certs));
			}
			finally
			{
				if (flag)
				{
					ArrayMarshaller<nint, nint>.Free(ptr);
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetPeerCertificates", ExactSpelling = true)]
			static extern unsafe void __PInvoke(nint __ssl_native, nint** __certs_native, int* __count_native);
		}

		internal static nint[] SSLStreamGetPeerCertificates(SafeSslHandle ssl)
		{
			SSLStreamGetPeerCertificates(ssl, out var certs, out var _);
			return certs;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetCipherSuite")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int SSLStreamGetCipherSuite(SafeSslHandle ssl, out nint cipherSuite)
		{
			cipherSuite = 0;
			int num = 0;
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ssl);
				fixed (nint* _cipherSuite_native = &cipherSuite)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _cipherSuite_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamGetCipherSuite", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ssl_native, nint* __cipherSuite_native);
		}

		internal static string SSLStreamGetCipherSuite(SafeSslHandle ssl)
		{
			if (SSLStreamGetCipherSuite(ssl, out var cipherSuite) != 1)
			{
				throw new SslException();
			}
			if (cipherSuite == IntPtr.Zero)
			{
				return string.Empty;
			}
			string? result = Marshal.PtrToStringUni(cipherSuite);
			Marshal.FreeHGlobal(cipherSuite);
			return result;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamVerifyHostname")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal unsafe static bool SSLStreamVerifyHostname(SafeSslHandle ssl, [MarshalAs(UnmanagedType.LPUTF8Str)] string hostname)
		{
			byte* ptr = default(byte*);
			bool flag = false;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeSslHandle>.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(hostname, buffer);
				managedToUnmanagedIn2.FromManaged(ssl);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				return __PInvoke(managedToUnmanagedIn2.ToUnmanaged(), ptr) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLStreamVerifyHostname", ExactSpelling = true)]
			static extern unsafe byte __PInvoke(nint __ssl_native, byte* __hostname_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLGetSupportedProtocols", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLGetSupportedProtocols")]
		internal static extern SslProtocols SSLGetSupportedProtocols();

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLSupportsApplicationProtocolsConfiguration")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static bool SSLSupportsApplicationProtocolsConfiguration()
		{
			return __PInvoke() != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SSLSupportsApplicationProtocolsConfiguration", ExactSpelling = true)]
			static extern byte __PInvoke();
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509IsKeyStorePrivateKeyEntry")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static bool IsKeyStorePrivateKeyEntry(nint handle)
		{
			return __PInvoke(handle) != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509IsKeyStorePrivateKeyEntry", ExactSpelling = true)]
			static extern int __PInvoke(nint __handle_native);
		}
	}
}
