using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

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

			internal static SafeJObjectHandle CreateGlobalReferenceFromHandle(nint handle)
			{
				SafeJObjectHandle safeJObjectHandle = new SafeJObjectHandle();
				Marshal.InitHandle(safeJObjectHandle, NewGlobalReference(handle));
				return safeJObjectHandle;
			}
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_NewGlobalReference", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_NewGlobalReference")]
		internal static extern nint NewGlobalReference(nint obj);

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DeleteGlobalReference", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DeleteGlobalReference")]
		internal static extern void DeleteGlobalReference(nint obj);
	}

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

		internal static readonly int EVP_MAX_MD_SIZE;

		private static volatile nint s_evpMd5;

		private static volatile nint s_evpSha1;

		private static volatile nint s_evpSha256;

		private static volatile nint s_evpSha384;

		private static volatile nint s_evpSha512;

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_BigNumToBinary")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int BigNumToBinary(SafeBignumHandle a, byte* to)
		{
			int num = 0;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(a);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), to);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_BigNumToBinary", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __a_native, byte* __to_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetBigNumBytes")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int GetBigNumBytes(SafeBignumHandle a)
		{
			int num = 0;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(a);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetBigNumBytes", ExactSpelling = true)]
			static extern int __PInvoke(nint __a_native);
		}

		internal unsafe static byte[] ExtractBignum(SafeBignumHandle bignum, int targetSize)
		{
			if (bignum == null || bignum.IsInvalid)
			{
				return null;
			}
			int bigNumBytes = GetBigNumBytes(bignum);
			if (targetSize < bigNumBytes)
			{
				targetSize = bigNumBytes;
			}
			int num = targetSize - bigNumBytes;
			byte[] array = new byte[targetSize];
			fixed (byte* ptr = array)
			{
				byte* to = ptr + num;
				BigNumToBinary(bignum, to);
			}
			return array;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherCreate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeEvpCipherCtxHandle EvpCipherCreate(nint cipher, ref byte key, int keyLength, ref byte iv, int enc)
		{
			bool flag = false;
			SafeEvpCipherCtxHandle safeEvpCipherCtxHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* _iv_native = &iv)
				{
					fixed (byte* _key_native = &key)
					{
						value = __PInvoke(cipher, _key_native, keyLength, _iv_native, enc);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherCreate", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(nint __cipher_native, byte* __key_native, int __keyLength_native, byte* __iv_native, int __enc_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherDestroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherDestroy")]
		internal static extern void EvpCipherDestroy(nint ctx);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherReset")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool EvpCipherReset(SafeEvpCipherCtxHandle ctx, byte* pIv, int cIv)
		{
			bool flag = false;
			SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), pIv, cIv) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherReset", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __pIv_native, int __cIv_native);
		}

		internal unsafe static bool EvpCipherReset(SafeEvpCipherCtxHandle ctx, ReadOnlySpan<byte> iv)
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(iv))
			{
				return EvpCipherReset(ctx, reference, iv.Length);
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherCtxSetPadding")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static bool EvpCipherCtxSetPadding(SafeEvpCipherCtxHandle x, int padding)
		{
			bool flag = false;
			SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(x);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), padding) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherCtxSetPadding", ExactSpelling = true)]
			static extern int __PInvoke(nint __x_native, int __padding_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherUpdate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool EvpCipherUpdate(SafeEvpCipherCtxHandle ctx, ref byte @out, out int outl, ref byte @in, int inl)
		{
			outl = 0;
			bool flag = false;
			int num = 0;
			SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (byte* _in_native = &@in)
				{
					fixed (int* _outl_native = &outl)
					{
						fixed (byte* _out_native = &@out)
						{
							num = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _out_native, _outl_native, _in_native, inl);
						}
					}
				}
				return num != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherUpdate", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __out_native, int* __outl_native, byte* __in_native, int __inl_native);
		}

		internal static bool EvpCipherUpdate(SafeEvpCipherCtxHandle ctx, Span<byte> output, out int bytesWritten, ReadOnlySpan<byte> input)
		{
			return EvpCipherUpdate(ctx, ref MemoryMarshal.GetReference(output), out bytesWritten, ref MemoryMarshal.GetReference(input), input.Length);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherFinalEx")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool EvpCipherFinalEx(SafeEvpCipherCtxHandle ctx, ref byte outm, out int outl)
		{
			outl = 0;
			bool flag = false;
			int num = 0;
			SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpCipherCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (int* _outl_native = &outl)
				{
					fixed (byte* _outm_native = &outm)
					{
						num = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _outm_native, _outl_native);
					}
				}
				return num != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_CipherFinalEx", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __outm_native, int* __outl_native);
		}

		internal static bool EvpCipherFinalEx(SafeEvpCipherCtxHandle ctx, Span<byte> output, out int bytesWritten)
		{
			return EvpCipherFinalEx(ctx, ref MemoryMarshal.GetReference(output), out bytesWritten);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Ecb", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Ecb")]
		internal static extern nint EvpAes128Ecb();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cbc", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cbc")]
		internal static extern nint EvpAes128Cbc();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cfb8", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cfb8")]
		internal static extern nint EvpAes128Cfb8();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cfb128", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes128Cfb128")]
		internal static extern nint EvpAes128Cfb128();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Ecb", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Ecb")]
		internal static extern nint EvpAes192Ecb();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cbc", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cbc")]
		internal static extern nint EvpAes192Cbc();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cfb8", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cfb8")]
		internal static extern nint EvpAes192Cfb8();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cfb128", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes192Cfb128")]
		internal static extern nint EvpAes192Cfb128();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Ecb", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Ecb")]
		internal static extern nint EvpAes256Ecb();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cbc", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cbc")]
		internal static extern nint EvpAes256Cbc();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cfb128", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cfb128")]
		internal static extern nint EvpAes256Cfb128();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cfb8", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Aes256Cfb8")]
		internal static extern nint EvpAes256Cfb8();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesCbc", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesCbc")]
		internal static extern nint EvpDesCbc();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesEcb", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesEcb")]
		internal static extern nint EvpDesEcb();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesCfb8", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DesCfb8")]
		internal static extern nint EvpDesCfb8();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cbc", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cbc")]
		internal static extern nint EvpDes3Cbc();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Ecb", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Ecb")]
		internal static extern nint EvpDes3Ecb();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cfb8", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cfb8")]
		internal static extern nint EvpDes3Cfb8();

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cfb64", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Des3Cfb64")]
		internal static extern nint EvpDes3Cfb64();

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_ErrGetErrorAlloc")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static ulong ErrGetErrorAlloc([MarshalAs(UnmanagedType.Bool)] out bool isAllocFailure)
		{
			isAllocFailure = false;
			Unsafe.SkipInit(out int num);
			ulong result = __PInvoke(&num);
			isAllocFailure = num != 0;
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_ErrGetErrorAlloc", ExactSpelling = true)]
			static extern unsafe ulong __PInvoke(int* __isAllocFailure_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_ErrErrorStringN", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_ErrErrorStringN")]
		private unsafe static extern void ErrErrorStringN(ulong e, byte* buf, int len);

		private unsafe static string ErrErrorStringN(ulong error)
		{
			byte[] array = new byte[1024];
			fixed (byte* ptr = &array[0])
			{
				ErrErrorStringN(error, ptr, array.Length);
				return Marshal.PtrToStringUTF8((nint)ptr);
			}
		}

		internal static Exception CreateOpenSslCryptographicException()
		{
			bool isAllocFailure;
			ulong num = ErrGetErrorAlloc(out isAllocFailure);
			ulong num2 = num;
			bool isAllocFailure2 = isAllocFailure;
			while (num2 != 0L)
			{
				num = num2;
				isAllocFailure = isAllocFailure2;
				num2 = ErrGetErrorAlloc(out isAllocFailure2);
			}
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

		internal static void CheckValidOpenSslHandle(SafeHandle handle)
		{
			if (handle == null || handle.IsInvalid)
			{
				Exception ex = CreateOpenSslCryptographicException();
				handle?.Dispose();
				throw ex;
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdCtxCreate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeEvpMdCtxHandle EvpMdCtxCreate(nint type)
		{
			bool flag = false;
			SafeEvpMdCtxHandle safeEvpMdCtxHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(type);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdCtxCreate", ExactSpelling = true)]
			static extern nint __PInvoke(nint __type_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdCtxDestroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdCtxDestroy")]
		internal static extern void EvpMdCtxDestroy(nint ctx);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestReset")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int EvpDigestReset(SafeEvpMdCtxHandle ctx, nint type)
		{
			int num = 0;
			SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), type);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestReset", ExactSpelling = true)]
			static extern int __PInvoke(nint __ctx_native, nint __type_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestUpdate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int EvpDigestUpdate(SafeEvpMdCtxHandle ctx, ReadOnlySpan<byte> d, int cnt)
		{
			int num = 0;
			SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (byte* ptr = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(d))
				{
					void* _d_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (byte*)_d_native, cnt);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestUpdate", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __d_native, int __cnt_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestFinalEx")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int EvpDigestFinalEx(SafeEvpMdCtxHandle ctx, ref byte md, ref uint s)
		{
			int num = 0;
			SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEvpMdCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (uint* _s_native = &s)
				{
					fixed (byte* _md_native = &md)
					{
						return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _md_native, _s_native);
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestFinalEx", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __md_native, uint* __s_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestOneShot", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpDigestOneShot")]
		internal unsafe static extern int EvpDigestOneShot(nint type, byte* source, int sourceSize, byte* md, uint* mdSize);

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdSize", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EvpMdSize")]
		internal static extern int EvpMdSize(nint md);

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_GetMaxMdSize", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_GetMaxMdSize")]
		private static extern int GetMaxMdSize();

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Pbkdf2", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int Pbkdf2(string algorithmName, ReadOnlySpan<byte> pPassword, int passwordLength, ReadOnlySpan<byte> pSalt, int saltLength, int iterations, Span<byte> pDestination, int destinationLength)
		{
			int num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(algorithmName, buffer);
				fixed (byte* ptr = &SpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(pDestination))
				{
					void* _pDestination_native = ptr;
					fixed (byte* ptr2 = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(pSalt))
					{
						void* _pSalt_native = ptr2;
						fixed (byte* ptr3 = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(pPassword))
						{
							void* _pPassword_native = ptr3;
							return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (byte*)_pPassword_native, passwordLength, (byte*)_pSalt_native, saltLength, iterations, (byte*)_pDestination_native, destinationLength);
						}
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_Pbkdf2", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __algorithmName_native, byte* __pPassword_native, int __passwordLength_native, byte* __pSalt_native, int __saltLength_native, int __iterations_native, byte* __pDestination_native, int __destinationLength_native);
		}

		internal static void Pbkdf2(string algorithmName, ReadOnlySpan<byte> password, ReadOnlySpan<byte> salt, int iterations, Span<byte> destination)
		{
			switch (Pbkdf2(algorithmName, password, password.Length, salt, salt.Length, iterations, destination, destination.Length))
			{
			case 1:
				break;
			case -1:
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", algorithmName));
			case 0:
				throw new CryptographicException();
			default:
				throw new CryptographicException();
			}
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		private static extern nint CryptoNative_EvpMd5();

		internal static nint EvpMd5()
		{
			if (s_evpMd5 == IntPtr.Zero)
			{
				return s_evpMd5 = CryptoNative_EvpMd5();
			}
			return s_evpMd5;
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		internal static extern nint CryptoNative_EvpSha1();

		internal static nint EvpSha1()
		{
			if (s_evpSha1 == IntPtr.Zero)
			{
				return s_evpSha1 = CryptoNative_EvpSha1();
			}
			return s_evpSha1;
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		internal static extern nint CryptoNative_EvpSha256();

		internal static nint EvpSha256()
		{
			if (s_evpSha256 == IntPtr.Zero)
			{
				return s_evpSha256 = CryptoNative_EvpSha256();
			}
			return s_evpSha256;
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		internal static extern nint CryptoNative_EvpSha384();

		internal static nint EvpSha384()
		{
			if (s_evpSha384 == IntPtr.Zero)
			{
				return s_evpSha384 = CryptoNative_EvpSha384();
			}
			return s_evpSha384;
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		internal static extern nint CryptoNative_EvpSha512();

		internal static nint EvpSha512()
		{
			if (s_evpSha512 == IntPtr.Zero)
			{
				return s_evpSha512 = CryptoNative_EvpSha512();
			}
			return s_evpSha512;
		}

		internal static nint HashAlgorithmToEvp(string hashAlgorithmId)
		{
			switch (hashAlgorithmId)
			{
			case "SHA1":
				return EvpSha1();
			case "SHA256":
				return EvpSha256();
			case "SHA384":
				return EvpSha384();
			case "SHA512":
				return EvpSha512();
			case "MD5":
				return EvpMd5();
			case "SHA3-256":
			case "SHA3-384":
			case "SHA3-512":
				throw new PlatformNotSupportedException();
			case "SHAKE256":
			case "SHAKE128":
				throw new PlatformNotSupportedException();
			default:
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", hashAlgorithmId));
			}
		}

		internal static bool HashAlgorithmSupported(string hashAlgorithmId)
		{
			switch (hashAlgorithmId)
			{
			case "SHA256":
			case "SHA384":
			case "SHA512":
			case "SHA1":
			case "MD5":
				return true;
			case "SHA3-256":
			case "SHAKE256":
			case "SHA3-384":
			case "SHA3-512":
			case "SHAKE128":
				return false;
			default:
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", hashAlgorithmId));
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacCreate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeHmacCtxHandle HmacCreate(ref byte key, int keyLen, nint md)
		{
			bool flag = false;
			SafeHmacCtxHandle safeHmacCtxHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* _key_native = &key)
				{
					value = __PInvoke(_key_native, keyLen, md);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacCreate", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __key_native, int __keyLen_native, nint __md_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacDestroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacDestroy")]
		internal static extern void HmacDestroy(nint ctx);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacReset")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int HmacReset(SafeHmacCtxHandle ctx)
		{
			int num = 0;
			SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacReset", ExactSpelling = true)]
			static extern int __PInvoke(nint __ctx_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacUpdate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int HmacUpdate(SafeHmacCtxHandle ctx, ReadOnlySpan<byte> data, int len)
		{
			int num = 0;
			SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (byte* ptr = &ReadOnlySpanMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(data))
				{
					void* _data_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (byte*)_data_native, len);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacUpdate", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __data_native, int __len_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacFinal")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int HmacFinal(SafeHmacCtxHandle ctx, ref byte data, ref int len)
		{
			int num = 0;
			SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHmacCtxHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (int* _len_native = &len)
				{
					fixed (byte* _data_native = &data)
					{
						return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _data_native, _len_native);
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacFinal", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, byte* __data_native, int* __len_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacOneShot")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int HmacOneShot(nint type, byte* key, int keySize, byte* source, int sourceSize, byte* md, ref int mdSize)
		{
			int result;
			fixed (int* _mdSize_native = &mdSize)
			{
				result = __PInvoke(type, key, keySize, source, sourceSize, md, _mdSize_native);
			}
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_HmacOneShot", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __type_native, byte* __key_native, int __keySize_native, byte* __source_native, int __sourceSize_native, byte* __md_native, int* __mdSize_native);
		}

		internal unsafe static int HmacOneShot(nint type, ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination)
		{
			int mdSize = destination.Length;
			fixed (byte* key2 = key)
			{
				fixed (byte* source2 = source)
				{
					fixed (byte* md = destination)
					{
						if (HmacOneShot(type, key2, key.Length, source2, source.Length, md, ref mdSize) != 1)
						{
							throw CreateOpenSslCryptographicException();
						}
					}
				}
			}
			return mdSize;
		}

		static Crypto()
		{
			EVP_MAX_MD_SIZE = GetMaxMdSize();
			CryptoInitializer.Initialize();
		}

		internal unsafe static bool GetRandomBytes(byte* pbBuffer, int count)
		{
			return CryptoNative_GetRandomBytes(pbBuffer, count);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool CryptoNative_GetRandomBytes(byte* buf, int num)
		{
			return __PInvoke(buf, num) != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_GetRandomBytes", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __buf_native, int __num_native);
		}
	}

	internal static class AndroidCrypto
	{
		internal enum PAL_KeyAlgorithm
		{
			DSA = 0,
			EC = 1,
			RSA = 2,
			UnknownAlgorithm = -1
		}

		internal struct ValidationError
		{
			public nint Message;

			public int Index;

			public int Status;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaGenerateKey")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool DsaGenerateKey(out SafeDsaHandle dsa, int bits)
		{
			bool flag = false;
			dsa = null;
			nint value = 0;
			bool flag2 = false;
			SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedOut();
			try
			{
				int num = __PInvoke(&value, bits);
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value);
				flag2 = num != 0;
				dsa = managedToUnmanagedOut.ToManaged();
				return flag2;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaGenerateKey", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint* __dsa_native, int __bits_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaSizeP")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int DsaSizeP(SafeDsaHandle dsa)
		{
			int num = 0;
			SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(dsa);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaSizeP", ExactSpelling = true)]
			static extern int __PInvoke(nint __dsa_native);
		}

		internal static int DsaKeySize(SafeDsaHandle dsa)
		{
			return (DsaSizeP(dsa) + 7) / 8 * 8;
		}

		internal static DSAParameters ExportDsaParameters(SafeDsaHandle key, bool includePrivateParameters)
		{
			if (key == null || key.IsInvalid)
			{
				throw new CryptographicException();
			}
			if (!GetDsaParameters(key, out var p, out var p_cb, out var q, out var q_cb, out var g, out var g_cb, out var y, out var y_cb, out var x, out var x_cb))
			{
				p.Dispose();
				q.Dispose();
				g.Dispose();
				y.Dispose();
				x.Dispose();
				throw new CryptographicException();
			}
			using (p)
			{
				using (q)
				{
					using (g)
					{
						using (y)
						{
							using (x)
							{
								int max = GetMax(p_cb, g_cb, y_cb);
								int max2 = GetMax(q_cb, x_cb);
								DSAParameters result = new DSAParameters
								{
									P = Crypto.ExtractBignum(p, max),
									Q = Crypto.ExtractBignum(q, max2),
									G = Crypto.ExtractBignum(g, max),
									Y = Crypto.ExtractBignum(y, max)
								};
								if (includePrivateParameters)
								{
									result.X = Crypto.ExtractBignum(x, max2);
								}
								return result;
							}
						}
					}
				}
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetDsaParameters")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool GetDsaParameters(SafeDsaHandle key, out SafeBignumHandle p, out int p_cb, out SafeBignumHandle q, out int q_cb, out SafeBignumHandle g, out int g_cb, out SafeBignumHandle y, out int y_cb, out SafeBignumHandle x, out int x_cb)
		{
			bool flag = false;
			p = null;
			p_cb = 0;
			q = null;
			q_cb = 0;
			g = null;
			g_cb = 0;
			y = null;
			y_cb = 0;
			x = null;
			x_cb = 0;
			nint value = 0;
			nint value2 = 0;
			nint value3 = 0;
			nint value4 = 0;
			nint value5 = 0;
			bool flag2 = false;
			int num = 0;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut2 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut3 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut4 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut5 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(key);
				fixed (int* _x_cb_native = &x_cb)
				{
					fixed (int* _y_cb_native = &y_cb)
					{
						fixed (int* _g_cb_native = &g_cb)
						{
							fixed (int* _q_cb_native = &q_cb)
							{
								fixed (int* _p_cb_native = &p_cb)
								{
									num = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), &value, _p_cb_native, &value2, _q_cb_native, &value3, _g_cb_native, &value4, _y_cb_native, &value5, _x_cb_native);
								}
							}
						}
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value5);
				managedToUnmanagedOut2.FromUnmanaged(value4);
				managedToUnmanagedOut3.FromUnmanaged(value3);
				managedToUnmanagedOut4.FromUnmanaged(value2);
				managedToUnmanagedOut5.FromUnmanaged(value);
				flag2 = num != 0;
				x = managedToUnmanagedOut.ToManaged();
				y = managedToUnmanagedOut2.ToManaged();
				g = managedToUnmanagedOut3.ToManaged();
				q = managedToUnmanagedOut4.ToManaged();
				p = managedToUnmanagedOut5.ToManaged();
				return flag2;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
					managedToUnmanagedOut2.Free();
					managedToUnmanagedOut3.Free();
					managedToUnmanagedOut4.Free();
					managedToUnmanagedOut5.Free();
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetDsaParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __key_native, nint* __p_native, int* __p_cb_native, nint* __q_native, int* __q_cb_native, nint* __g_native, int* __g_cb_native, nint* __y_native, int* __y_cb_native, nint* __x_native, int* __x_cb_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaKeyCreateByExplicitParameters")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool DsaKeyCreateByExplicitParameters(out SafeDsaHandle dsa, byte[] p, int pLength, byte[] q, int qLength, byte[] g, int gLength, byte[] y, int yLength, byte[] x, int xLength)
		{
			bool flag = false;
			dsa = null;
			nint value = 0;
			bool flag2 = false;
			int num = 0;
			SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeDsaHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* ptr = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(x))
				{
					void* _x_native = ptr;
					fixed (byte* ptr2 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(y))
					{
						void* _y_native = ptr2;
						fixed (byte* ptr3 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(g))
						{
							void* _g_native = ptr3;
							fixed (byte* ptr4 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(q))
							{
								void* _q_native = ptr4;
								fixed (byte* ptr5 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(p))
								{
									void* _p_native = ptr5;
									num = __PInvoke(&value, (byte*)_p_native, pLength, (byte*)_q_native, qLength, (byte*)_g_native, gLength, (byte*)_y_native, yLength, (byte*)_x_native, xLength);
								}
							}
						}
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value);
				flag2 = num != 0;
				dsa = managedToUnmanagedOut.ToManaged();
				return flag2;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DsaKeyCreateByExplicitParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint* __dsa_native, byte* __p_native, int __pLength_native, byte* __q_native, int __qLength_native, byte* __g_native, int __gLength_native, byte* __y_native, int __yLength_native, byte* __x_native, int __xLength_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByKeyParameters", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int EcKeyCreateByKeyParameters(out SafeEcKeyHandle key, string oid, byte[] qx, int qxLength, byte[] qy, int qyLength, byte[] d, int dLength)
		{
			bool flag = false;
			key = null;
			nint value = 0;
			byte* ptr = default(byte*);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut();
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(oid, buffer);
				fixed (byte* ptr2 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(d))
				{
					void* _d_native = ptr2;
					fixed (byte* ptr3 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(qy))
					{
						void* _qy_native = ptr3;
						fixed (byte* ptr4 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(qx))
						{
							void* _qx_native = ptr4;
							ptr = managedToUnmanagedIn.ToUnmanaged();
							result = __PInvoke(&value, ptr, (byte*)_qx_native, qxLength, (byte*)_qy_native, qyLength, (byte*)_d_native, dLength);
						}
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value);
				key = managedToUnmanagedOut.ToManaged();
				return result;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByKeyParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint* __key_native, byte* __oid_native, byte* __qx_native, int __qxLength_native, byte* __qy_native, int __qyLength_native, byte* __d_native, int __dLength_native);
		}

		internal static SafeEcKeyHandle EcKeyCreateByKeyParameters(string oid, byte[] qx, int qxLength, byte[] qy, int qyLength, byte[] d, int dLength)
		{
			if (EcKeyCreateByKeyParameters(out var key, oid, qx, qxLength, qy, qyLength, d, dLength) == -1)
			{
				key?.Dispose();
				throw new PlatformNotSupportedException(System.SR.Format("Cryptography_CurveNotSupported", oid));
			}
			return key;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByExplicitParameters")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeEcKeyHandle EcKeyCreateByExplicitParameters(ECCurve.ECCurveType curveType, byte[] qx, int qxLength, byte[] qy, int qyLength, byte[] d, int dLength, byte[] p, int pLength, byte[] a, int aLength, byte[] b, int bLength, byte[] gx, int gxLength, byte[] gy, int gyLength, byte[] order, int nLength, byte[] cofactor, int cofactorLength, byte[] seed, int seedLength)
		{
			bool flag = false;
			SafeEcKeyHandle safeEcKeyHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* ptr = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(seed))
				{
					void* _seed_native = ptr;
					fixed (byte* ptr2 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(cofactor))
					{
						void* _cofactor_native = ptr2;
						fixed (byte* ptr3 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(order))
						{
							void* _order_native = ptr3;
							fixed (byte* ptr4 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(gy))
							{
								void* _gy_native = ptr4;
								fixed (byte* ptr5 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(gx))
								{
									void* _gx_native = ptr5;
									fixed (byte* ptr6 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(b))
									{
										void* _b_native = ptr6;
										fixed (byte* ptr7 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(a))
										{
											void* _a_native = ptr7;
											fixed (byte* ptr8 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(p))
											{
												void* _p_native = ptr8;
												fixed (byte* ptr9 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(d))
												{
													void* _d_native = ptr9;
													fixed (byte* ptr10 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(qy))
													{
														void* _qy_native = ptr10;
														fixed (byte* ptr11 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(qx))
														{
															void* _qx_native = ptr11;
															value = __PInvoke(curveType, (byte*)_qx_native, qxLength, (byte*)_qy_native, qyLength, (byte*)_d_native, dLength, (byte*)_p_native, pLength, (byte*)_a_native, aLength, (byte*)_b_native, bLength, (byte*)_gx_native, gxLength, (byte*)_gy_native, gyLength, (byte*)_order_native, nLength, (byte*)_cofactor_native, cofactorLength, (byte*)_seed_native, seedLength);
														}
													}
												}
											}
										}
									}
								}
							}
						}
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByExplicitParameters", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(ECCurve.ECCurveType __curveType_native, byte* __qx_native, int __qxLength_native, byte* __qy_native, int __qyLength_native, byte* __d_native, int __dLength_native, byte* __p_native, int __pLength_native, byte* __a_native, int __aLength_native, byte* __b_native, int __bLength_native, byte* __gx_native, int __gxLength_native, byte* __gy_native, int __gyLength_native, byte* __order_native, int __nLength_native, byte* __cofactor_native, int __cofactorLength_native, byte* __seed_native, int __seedLength_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int AndroidCryptoNative_GetECKeyParameters(SafeEcKeyHandle key, [MarshalAs(UnmanagedType.Bool)] bool includePrivate, out SafeBignumHandle qx_bn, out int x_cb, out SafeBignumHandle qy_bn, out int y_cb, out SafeBignumHandle d_bn, out int d_cb)
		{
			bool flag = false;
			qx_bn = null;
			x_cb = 0;
			qy_bn = null;
			y_cb = 0;
			d_bn = null;
			d_cb = 0;
			int num = 0;
			nint value = 0;
			nint value2 = 0;
			nint value3 = 0;
			int result = 0;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut2 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut3 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn);
			try
			{
				num = (includePrivate ? 1 : 0);
				managedToUnmanagedIn.FromManaged(key);
				fixed (int* _d_cb_native = &d_cb)
				{
					fixed (int* _y_cb_native = &y_cb)
					{
						fixed (int* _x_cb_native = &x_cb)
						{
							result = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), num, &value, _x_cb_native, &value2, _y_cb_native, &value3, _d_cb_native);
						}
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value3);
				managedToUnmanagedOut2.FromUnmanaged(value2);
				managedToUnmanagedOut3.FromUnmanaged(value);
				d_bn = managedToUnmanagedOut.ToManaged();
				qy_bn = managedToUnmanagedOut2.ToManaged();
				qx_bn = managedToUnmanagedOut3.ToManaged();
				return result;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
					managedToUnmanagedOut2.Free();
					managedToUnmanagedOut3.Free();
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetECKeyParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __key_native, int __includePrivate_native, nint* __qx_bn_native, int* __x_cb_native, nint* __qy_bn_native, int* __y_cb_native, nint* __d_bn_native, int* __d_cb_native);
		}

		internal static ECParameters GetECKeyParameters(SafeEcKeyHandle key, bool includePrivate)
		{
			ECParameters result = default(ECParameters);
			SafeBignumHandle qx_bn;
			int x_cb;
			SafeBignumHandle qy_bn;
			int y_cb;
			SafeBignumHandle d_bn;
			int d_cb;
			int num = AndroidCryptoNative_GetECKeyParameters(key, includePrivate, out qx_bn, out x_cb, out qy_bn, out y_cb, out d_bn, out d_cb);
			using (qx_bn)
			{
				using (qy_bn)
				{
					using (d_bn)
					{
						switch (num)
						{
						case -1:
							throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
						default:
							throw new CryptographicException();
						case 1:
						{
							int value = (EcKeyGetSize(key) + 7) / 8;
							int max = GetMax(x_cb, y_cb, d_cb);
							max = GetMax(max, value);
							result.Q = new ECPoint
							{
								X = Crypto.ExtractBignum(qx_bn, max),
								Y = Crypto.ExtractBignum(qy_bn, max)
							};
							result.D = ((d_cb == 0) ? null : Crypto.ExtractBignum(d_bn, max));
							return result;
						}
						}
					}
				}
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int AndroidCryptoNative_GetECCurveParameters(SafeEcKeyHandle key, [MarshalAs(UnmanagedType.Bool)] bool includePrivate, out ECCurve.ECCurveType curveType, out SafeBignumHandle qx, out int x_cb, out SafeBignumHandle qy, out int y_cb, out SafeBignumHandle d, out int d_cb, out SafeBignumHandle p, out int P_cb, out SafeBignumHandle a, out int A_cb, out SafeBignumHandle b, out int B_cb, out SafeBignumHandle gx, out int Gx_cb, out SafeBignumHandle gy, out int Gy_cb, out SafeBignumHandle order, out int order_cb, out SafeBignumHandle cofactor, out int cofactor_cb, out SafeBignumHandle seed, out int seed_cb)
		{
			bool flag = false;
			curveType = ECCurve.ECCurveType.Implicit;
			qx = null;
			x_cb = 0;
			qy = null;
			y_cb = 0;
			d = null;
			d_cb = 0;
			p = null;
			P_cb = 0;
			a = null;
			A_cb = 0;
			b = null;
			B_cb = 0;
			gx = null;
			Gx_cb = 0;
			gy = null;
			Gy_cb = 0;
			order = null;
			order_cb = 0;
			cofactor = null;
			cofactor_cb = 0;
			seed = null;
			seed_cb = 0;
			int num = 0;
			nint value = 0;
			nint value2 = 0;
			nint value3 = 0;
			nint value4 = 0;
			nint value5 = 0;
			nint value6 = 0;
			nint value7 = 0;
			nint value8 = 0;
			nint value9 = 0;
			nint value10 = 0;
			nint value11 = 0;
			int result = 0;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut2 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut3 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut4 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut5 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut6 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut7 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut8 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut9 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut10 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut11 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn);
			try
			{
				num = (includePrivate ? 1 : 0);
				managedToUnmanagedIn.FromManaged(key);
				fixed (int* _seed_cb_native = &seed_cb)
				{
					fixed (int* _cofactor_cb_native = &cofactor_cb)
					{
						fixed (int* _order_cb_native = &order_cb)
						{
							fixed (int* _Gy_cb_native = &Gy_cb)
							{
								fixed (int* _Gx_cb_native = &Gx_cb)
								{
									fixed (int* _B_cb_native = &B_cb)
									{
										fixed (int* _A_cb_native = &A_cb)
										{
											fixed (int* _P_cb_native = &P_cb)
											{
												fixed (int* _d_cb_native = &d_cb)
												{
													fixed (int* _y_cb_native = &y_cb)
													{
														fixed (int* _x_cb_native = &x_cb)
														{
															fixed (ECCurve.ECCurveType* _curveType_native = &curveType)
															{
																result = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), num, _curveType_native, &value, _x_cb_native, &value2, _y_cb_native, &value3, _d_cb_native, &value4, _P_cb_native, &value5, _A_cb_native, &value6, _B_cb_native, &value7, _Gx_cb_native, &value8, _Gy_cb_native, &value9, _order_cb_native, &value10, _cofactor_cb_native, &value11, _seed_cb_native);
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value11);
				managedToUnmanagedOut2.FromUnmanaged(value10);
				managedToUnmanagedOut3.FromUnmanaged(value9);
				managedToUnmanagedOut4.FromUnmanaged(value8);
				managedToUnmanagedOut5.FromUnmanaged(value7);
				managedToUnmanagedOut6.FromUnmanaged(value6);
				managedToUnmanagedOut7.FromUnmanaged(value5);
				managedToUnmanagedOut8.FromUnmanaged(value4);
				managedToUnmanagedOut9.FromUnmanaged(value3);
				managedToUnmanagedOut10.FromUnmanaged(value2);
				managedToUnmanagedOut11.FromUnmanaged(value);
				seed = managedToUnmanagedOut.ToManaged();
				cofactor = managedToUnmanagedOut2.ToManaged();
				order = managedToUnmanagedOut3.ToManaged();
				gy = managedToUnmanagedOut4.ToManaged();
				gx = managedToUnmanagedOut5.ToManaged();
				b = managedToUnmanagedOut6.ToManaged();
				a = managedToUnmanagedOut7.ToManaged();
				p = managedToUnmanagedOut8.ToManaged();
				d = managedToUnmanagedOut9.ToManaged();
				qy = managedToUnmanagedOut10.ToManaged();
				qx = managedToUnmanagedOut11.ToManaged();
				return result;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
					managedToUnmanagedOut2.Free();
					managedToUnmanagedOut3.Free();
					managedToUnmanagedOut4.Free();
					managedToUnmanagedOut5.Free();
					managedToUnmanagedOut6.Free();
					managedToUnmanagedOut7.Free();
					managedToUnmanagedOut8.Free();
					managedToUnmanagedOut9.Free();
					managedToUnmanagedOut10.Free();
					managedToUnmanagedOut11.Free();
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetECCurveParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __key_native, int __includePrivate_native, ECCurve.ECCurveType* __curveType_native, nint* __qx_native, int* __x_cb_native, nint* __qy_native, int* __y_cb_native, nint* __d_native, int* __d_cb_native, nint* __p_native, int* __P_cb_native, nint* __a_native, int* __A_cb_native, nint* __b_native, int* __B_cb_native, nint* __gx_native, int* __Gx_cb_native, nint* __gy_native, int* __Gy_cb_native, nint* __order_native, int* __order_cb_native, nint* __cofactor_native, int* __cofactor_cb_native, nint* __seed_native, int* __seed_cb_native);
		}

		internal static ECParameters GetECCurveParameters(SafeEcKeyHandle key, bool includePrivate)
		{
			ECCurve.ECCurveType curveType;
			SafeBignumHandle qx;
			int x_cb;
			SafeBignumHandle qy;
			int y_cb;
			SafeBignumHandle d;
			int d_cb;
			SafeBignumHandle p;
			int P_cb;
			SafeBignumHandle a;
			int A_cb;
			SafeBignumHandle b;
			int B_cb;
			SafeBignumHandle gx;
			int Gx_cb;
			SafeBignumHandle gy;
			int Gy_cb;
			SafeBignumHandle order;
			int order_cb;
			SafeBignumHandle cofactor;
			int cofactor_cb;
			SafeBignumHandle seed;
			int seed_cb;
			int num = AndroidCryptoNative_GetECCurveParameters(key, includePrivate, out curveType, out qx, out x_cb, out qy, out y_cb, out d, out d_cb, out p, out P_cb, out a, out A_cb, out b, out B_cb, out gx, out Gx_cb, out gy, out Gy_cb, out order, out order_cb, out cofactor, out cofactor_cb, out seed, out seed_cb);
			using (qx)
			{
				using (qy)
				{
					using (p)
					{
						using (a)
						{
							using (b)
							{
								using (gx)
								{
									using (gy)
									{
										using (order)
										{
											using (cofactor)
											{
												using (seed)
												{
													using (d)
													{
														switch (num)
														{
														case -1:
															throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
														default:
															throw new CryptographicException();
														case 1:
														{
															int max;
															int targetSize;
															if (curveType == ECCurve.ECCurveType.Characteristic2)
															{
																max = GetMax(new int[6] { A_cb, B_cb, Gx_cb, Gy_cb, x_cb, y_cb });
																targetSize = P_cb;
															}
															else
															{
																max = GetMax(new int[7] { P_cb, A_cb, B_cb, Gx_cb, Gy_cb, x_cb, y_cb });
																targetSize = max;
															}
															int max2 = GetMax(order_cb, d_cb);
															ECParameters result = new ECParameters
															{
																Q = new ECPoint
																{
																	X = Crypto.ExtractBignum(qx, max),
																	Y = Crypto.ExtractBignum(qy, max)
																},
																D = ((d_cb == 0) ? null : Crypto.ExtractBignum(d, max2))
															};
															ECCurve curve = result.Curve;
															curve.CurveType = curveType;
															curve.A = Crypto.ExtractBignum(a, max);
															curve.B = Crypto.ExtractBignum(b, max);
															curve.G = new ECPoint
															{
																X = Crypto.ExtractBignum(gx, max),
																Y = Crypto.ExtractBignum(gy, max)
															};
															curve.Order = Crypto.ExtractBignum(order, max2);
															if (curveType == ECCurve.ECCurveType.Characteristic2)
															{
																curve.Polynomial = Crypto.ExtractBignum(p, targetSize);
															}
															else
															{
																curve.Prime = Crypto.ExtractBignum(p, targetSize);
															}
															curve.Cofactor = ((cofactor_cb == 0) ? null : Crypto.ExtractBignum(cofactor, cofactor_cb));
															curve.Seed = ((seed_cb == 0) ? null : Crypto.ExtractBignum(seed, seed_cb));
															result.Curve = curve;
															return result;
														}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private static int GetMax(int[] values)
		{
			int num = 0;
			foreach (int num2 in values)
			{
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		private static int GetMax(int value1, int value2)
		{
			if (value1 <= value2)
			{
				return value2;
			}
			return value1;
		}

		private static int GetMax(int value1, int value2, int value3)
		{
			return GetMax(GetMax(value1, value2), value3);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByOid", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static SafeEcKeyHandle AndroidCryptoNative_EcKeyCreateByOid(string oid)
		{
			bool flag = false;
			SafeEcKeyHandle safeEcKeyHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedOut();
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(oid, buffer);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyCreateByOid", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __oid_native);
		}

		internal static SafeEcKeyHandle EcKeyCreateByOid(string oid)
		{
			return AndroidCryptoNative_EcKeyCreateByOid(oid);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyDestroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyDestroy")]
		internal static extern void EcKeyDestroy(nint a);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyUpRef")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static bool EcKeyUpRef(nint r)
		{
			return __PInvoke(r) != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyUpRef", ExactSpelling = true)]
			static extern int __PInvoke(nint __r_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int AndroidCryptoNative_EcKeyGetSize(SafeEcKeyHandle ecKey, out int keySize)
		{
			keySize = 0;
			int num = 0;
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ecKey);
				fixed (int* _keySize_native = &keySize)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _keySize_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyGetSize", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ecKey_native, int* __keySize_native);
		}

		internal static int EcKeyGetSize(SafeEcKeyHandle key)
		{
			if (AndroidCryptoNative_EcKeyGetSize(key, out var keySize) == 1)
			{
				return keySize;
			}
			throw new CryptographicException();
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyGetCurveName")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int AndroidCryptoNative_EcKeyGetCurveName(SafeEcKeyHandle ecKey, out nint curveName)
		{
			curveName = 0;
			int num = 0;
			SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeEcKeyHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ecKey);
				fixed (nint* _curveName_native = &curveName)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _curveName_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_EcKeyGetCurveName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ecKey_native, nint* __curveName_native);
		}

		internal static string EcKeyGetCurveName(SafeEcKeyHandle key)
		{
			if (AndroidCryptoNative_EcKeyGetCurveName(key, out var curveName) == 1)
			{
				if (curveName == IntPtr.Zero)
				{
					return null;
				}
				string? result = Marshal.PtrToStringUni(curveName);
				Marshal.FreeHGlobal(curveName);
				return result;
			}
			throw new CryptographicException();
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaCreate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeRsaHandle RsaCreate()
		{
			bool flag = false;
			SafeRsaHandle safeRsaHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke();
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaCreate", ExactSpelling = true)]
			static extern nint __PInvoke();
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaUpRef")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static bool RsaUpRef(nint rsa)
		{
			return __PInvoke(rsa) != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaUpRef", ExactSpelling = true)]
			static extern int __PInvoke(nint __rsa_native);
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaDestroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaDestroy")]
		internal static extern void RsaDestroy(nint rsa);

		internal static SafeRsaHandle DecodeRsaSubjectPublicKeyInfo(ReadOnlySpan<byte> buf)
		{
			return DecodeRsaSubjectPublicKeyInfo(ref MemoryMarshal.GetReference(buf), buf.Length);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DecodeRsaSubjectPublicKeyInfo")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static SafeRsaHandle DecodeRsaSubjectPublicKeyInfo(ref byte buf, int len)
		{
			bool flag = false;
			SafeRsaHandle safeRsaHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* _buf_native = &buf)
				{
					value = __PInvoke(_buf_native, len);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_DecodeRsaSubjectPublicKeyInfo", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __buf_native, int __len_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaSize")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int RsaSize(SafeRsaHandle rsa)
		{
			int num = 0;
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(rsa);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaSize", ExactSpelling = true)]
			static extern int __PInvoke(nint __rsa_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaGenerateKeyEx")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int RsaGenerateKeyEx(SafeRsaHandle rsa, int bits)
		{
			int num = 0;
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(rsa);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), bits);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_RsaGenerateKeyEx", ExactSpelling = true)]
			static extern int __PInvoke(nint __rsa_native, int __bits_native);
		}

		internal static RSAParameters ExportRsaParameters(SafeRsaHandle key, bool includePrivateParameters)
		{
			if (key == null || key.IsInvalid)
			{
				throw new CryptographicException();
			}
			if (!GetRsaParameters(key, out var n, out var e, out var d, out var p, out var dmp, out var q, out var dmq, out var iqmp))
			{
				n.Dispose();
				e.Dispose();
				d.Dispose();
				p.Dispose();
				dmp.Dispose();
				q.Dispose();
				dmq.Dispose();
				iqmp.Dispose();
				throw new CryptographicException();
			}
			using (n)
			{
				using (e)
				{
					using (d)
					{
						using (p)
						{
							using (dmp)
							{
								using (q)
								{
									using (dmq)
									{
										using (iqmp)
										{
											int num = RsaSize(key);
											int targetSize = num / 2;
											RSAParameters result = new RSAParameters
											{
												Modulus = Crypto.ExtractBignum(n, num),
												Exponent = Crypto.ExtractBignum(e, 0)
											};
											if (includePrivateParameters)
											{
												result.D = Crypto.ExtractBignum(d, num);
												result.P = Crypto.ExtractBignum(p, targetSize);
												result.DP = Crypto.ExtractBignum(dmp, targetSize);
												result.Q = Crypto.ExtractBignum(q, targetSize);
												result.DQ = Crypto.ExtractBignum(dmq, targetSize);
												result.InverseQ = Crypto.ExtractBignum(iqmp, targetSize);
											}
											return result;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetRsaParameters")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool GetRsaParameters(SafeRsaHandle key, out SafeBignumHandle n, out SafeBignumHandle e, out SafeBignumHandle d, out SafeBignumHandle p, out SafeBignumHandle dmp1, out SafeBignumHandle q, out SafeBignumHandle dmq1, out SafeBignumHandle iqmp)
		{
			bool flag = false;
			n = null;
			e = null;
			d = null;
			p = null;
			dmp1 = null;
			q = null;
			dmq1 = null;
			iqmp = null;
			nint value = 0;
			nint value2 = 0;
			nint value3 = 0;
			nint value4 = 0;
			nint value5 = 0;
			nint value6 = 0;
			nint value7 = 0;
			nint value8 = 0;
			bool flag2 = false;
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut2 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut3 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut4 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut5 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut6 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut7 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut managedToUnmanagedOut8 = new SafeHandleMarshaller<SafeBignumHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(key);
				int num = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), &value, &value2, &value3, &value4, &value5, &value6, &value7, &value8);
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(value8);
				managedToUnmanagedOut2.FromUnmanaged(value7);
				managedToUnmanagedOut3.FromUnmanaged(value6);
				managedToUnmanagedOut4.FromUnmanaged(value5);
				managedToUnmanagedOut5.FromUnmanaged(value4);
				managedToUnmanagedOut6.FromUnmanaged(value3);
				managedToUnmanagedOut7.FromUnmanaged(value2);
				managedToUnmanagedOut8.FromUnmanaged(value);
				flag2 = num != 0;
				iqmp = managedToUnmanagedOut.ToManaged();
				dmq1 = managedToUnmanagedOut2.ToManaged();
				q = managedToUnmanagedOut3.ToManaged();
				dmp1 = managedToUnmanagedOut4.ToManaged();
				p = managedToUnmanagedOut5.ToManaged();
				d = managedToUnmanagedOut6.ToManaged();
				e = managedToUnmanagedOut7.ToManaged();
				n = managedToUnmanagedOut8.ToManaged();
				return flag2;
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
					managedToUnmanagedOut2.Free();
					managedToUnmanagedOut3.Free();
					managedToUnmanagedOut4.Free();
					managedToUnmanagedOut5.Free();
					managedToUnmanagedOut6.Free();
					managedToUnmanagedOut7.Free();
					managedToUnmanagedOut8.Free();
				}
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_GetRsaParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __key_native, nint* __n_native, nint* __e_native, nint* __d_native, nint* __p_native, nint* __dmp1_native, nint* __q_native, nint* __dmq1_native, nint* __iqmp_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SetRsaParameters")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool SetRsaParameters(SafeRsaHandle key, byte[] n, int nLength, byte[] e, int eLength, byte[] d, int dLength, byte[] p, int pLength, byte[] dmp1, int dmp1Length, byte[] q, int qLength, byte[] dmq1, int dmq1Length, byte[] iqmp, int iqmpLength)
		{
			bool flag = false;
			int num = 0;
			SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeRsaHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(key);
				fixed (byte* ptr = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(iqmp))
				{
					void* _iqmp_native = ptr;
					fixed (byte* ptr2 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(dmq1))
					{
						void* _dmq1_native = ptr2;
						fixed (byte* ptr3 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(q))
						{
							void* _q_native = ptr3;
							fixed (byte* ptr4 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(dmp1))
							{
								void* _dmp1_native = ptr4;
								fixed (byte* ptr5 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(p))
								{
									void* _p_native = ptr5;
									fixed (byte* ptr6 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(d))
									{
										void* _d_native = ptr6;
										fixed (byte* ptr7 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(e))
										{
											void* _e_native = ptr7;
											fixed (byte* ptr8 = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(n))
											{
												void* _n_native = ptr8;
												num = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (byte*)_n_native, nLength, (byte*)_e_native, eLength, (byte*)_d_native, dLength, (byte*)_p_native, pLength, (byte*)_dmp1_native, dmp1Length, (byte*)_q_native, qLength, (byte*)_dmq1_native, dmq1Length, (byte*)_iqmp_native, iqmpLength);
											}
										}
									}
								}
							}
						}
					}
				}
				return num != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_SetRsaParameters", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __key_native, byte* __n_native, int __nLength_native, byte* __e_native, int __eLength_native, byte* __d_native, int __dLength_native, byte* __p_native, int __pLength_native, byte* __dmp1_native, int __dmp1Length_native, byte* __q_native, int __qLength_native, byte* __dmq1_native, int __dmq1Length_native, byte* __iqmp_native, int __iqmpLength_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509Decode")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeX509Handle X509Decode(ref byte buf, int len)
		{
			bool flag = false;
			SafeX509Handle safeX509Handle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedOut();
			try
			{
				fixed (byte* _buf_native = &buf)
				{
					value = __PInvoke(_buf_native, len);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509Decode", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __buf_native, int __len_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509Encode")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int X509Encode(SafeX509Handle x, byte[] buf, ref int len)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(x);
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509Encode", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __x_native, byte* __buf_native, int* __len_native);
		}

		internal static byte[] X509Encode(SafeX509Handle x)
		{
			int len = 0;
			if (X509Encode(x, null, ref len) != -1)
			{
				throw new CryptographicException();
			}
			byte[] array = new byte[len];
			if (X509Encode(x, array, ref len) != 1)
			{
				throw new CryptographicException();
			}
			return array;
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

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509GetCertificateForPrivateKeyEntry", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509GetCertificateForPrivateKeyEntry")]
		private static extern nint GetPrivateKeyEntryCertificate(nint privatKeyEntryHandle);

		internal static SafeX509Handle GetPrivateKeyEntryCertificate(SafeHandle privatKeyEntryHandle)
		{
			bool success = false;
			try
			{
				privatKeyEntryHandle.DangerousAddRef(ref success);
				nint privateKeyEntryCertificate = GetPrivateKeyEntryCertificate(privatKeyEntryHandle.DangerousGetHandle());
				SafeX509Handle safeX509Handle = new SafeX509Handle();
				Marshal.InitHandle(safeX509Handle, privateKeyEntryCertificate);
				return safeX509Handle;
			}
			finally
			{
				if (success)
				{
					privatKeyEntryHandle.DangerousRelease();
				}
			}
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509DecodeCollection")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int X509DecodeCollection(ref byte buf, int bufLen, nint[] ptrs, ref int handlesLen)
		{
			int result;
			fixed (int* _handlesLen_native = &handlesLen)
			{
				fixed (nint* ptr = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(ptrs))
				{
					void* _ptrs_native = ptr;
					fixed (byte* _buf_native = &buf)
					{
						result = __PInvoke(_buf_native, bufLen, (nint*)_ptrs_native, _handlesLen_native);
					}
				}
			}
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509DecodeCollection", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __buf_native, int __bufLen_native, nint* __ptrs_native, int* __handlesLen_native);
		}

		internal static SafeX509Handle[] X509DecodeCollection(ReadOnlySpan<byte> data)
		{
			ref byte reference = ref MemoryMarshal.GetReference(data);
			int handlesLen = 0;
			int num = X509DecodeCollection(ref reference, data.Length, null, ref handlesLen);
			if (num == 1 && handlesLen == 0)
			{
				return Array.Empty<SafeX509Handle>();
			}
			if (num != -1)
			{
				throw new CryptographicException();
			}
			nint[] array = new nint[handlesLen];
			SafeX509Handle[] array2 = new SafeX509Handle[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = new SafeX509Handle();
			}
			num = X509DecodeCollection(ref reference, data.Length, array, ref handlesLen);
			if (num != 1)
			{
				SafeX509Handle[] array3 = array2;
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j].Dispose();
				}
				throw new CryptographicException();
			}
			for (int k = 0; k < array2.Length; k++)
			{
				Marshal.InitHandle(array2[k], array[k]);
			}
			return array2;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ExportPkcs7")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int X509ExportPkcs7(nint[] certs, int certsLen, byte[] buf, ref int len)
		{
			int result;
			fixed (int* _len_native = &len)
			{
				fixed (byte* ptr = &ArrayMarshaller<byte, byte>.ManagedToUnmanagedIn.GetPinnableReference(buf))
				{
					void* _buf_native = ptr;
					fixed (nint* ptr2 = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(certs))
					{
						void* _certs_native = ptr2;
						result = __PInvoke((nint*)_certs_native, certsLen, (byte*)_buf_native, _len_native);
					}
				}
			}
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ExportPkcs7", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint* __certs_native, int __certsLen_native, byte* __buf_native, int* __len_native);
		}

		internal static byte[] X509ExportPkcs7(nint[] certHandles)
		{
			int len = 0;
			if (X509ExportPkcs7(certHandles, certHandles.Length, null, ref len) != -1)
			{
				throw new CryptographicException();
			}
			byte[] array = new byte[len];
			if (X509ExportPkcs7(certHandles, certHandles.Length, array, ref len) != 1)
			{
				throw new CryptographicException();
			}
			return array;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509GetContentType")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static X509ContentType X509GetContentType(ref byte buf, int len)
		{
			X509ContentType result;
			fixed (byte* _buf_native = &buf)
			{
				result = __PInvoke(_buf_native, len);
			}
			return result;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509GetContentType", ExactSpelling = true)]
			static extern unsafe X509ContentType __PInvoke(byte* __buf_native, int __len_native);
		}

		internal static X509ContentType X509GetContentType(ReadOnlySpan<byte> data)
		{
			return X509GetContentType(ref MemoryMarshal.GetReference(data), data.Length);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509PublicKey")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static nint X509GetPublicKey(SafeX509Handle x, PAL_KeyAlgorithm algorithm)
		{
			nint num = 0;
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(x);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), algorithm);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509PublicKey", ExactSpelling = true)]
			static extern nint __PInvoke(nint __x_native, PAL_KeyAlgorithm __algorithm_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainCreateContext")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static SafeX509ChainContextHandle X509ChainCreateContext(SafeX509Handle cert, nint[] extraStore, int extraStoreLen)
		{
			bool flag = false;
			SafeX509ChainContextHandle safeX509ChainContextHandle = null;
			nint value = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedOut();
			SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509Handle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(cert);
				fixed (nint* ptr = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(extraStore))
				{
					void* _extraStore_native = ptr;
					value = __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (nint*)_extraStore_native, extraStoreLen);
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
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainCreateContext", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(nint __cert_native, nint* __extraStore_native, int __extraStoreLen_native);
		}

		internal static SafeX509ChainContextHandle X509ChainCreateContext(SafeX509Handle cert, nint[] extraStore)
		{
			SafeX509ChainContextHandle safeX509ChainContextHandle = X509ChainCreateContext(cert, extraStore, extraStore.Length);
			if (safeX509ChainContextHandle.IsInvalid)
			{
				safeX509ChainContextHandle.Dispose();
				throw new CryptographicException("Cryptography_AndroidX509ChainContextInitializationFailed");
			}
			return safeX509ChainContextHandle;
		}

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainDestroyContext", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainDestroyContext")]
		internal static extern void X509ChainDestroyContext(nint ctx);

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainBuild")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static bool X509ChainBuild(SafeX509ChainContextHandle ctx, long timeInMsFromUnixEpoch)
		{
			bool flag = false;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), timeInMsFromUnixEpoch) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainBuild", ExactSpelling = true)]
			static extern byte __PInvoke(nint __ctx_native, long __timeInMsFromUnixEpoch_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetCertificateCount")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int X509ChainGetCertificateCount(SafeX509ChainContextHandle ctx)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetCertificateCount", ExactSpelling = true)]
			static extern int __PInvoke(nint __ctx_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetCertificates")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int X509ChainGetCertificates(SafeX509ChainContextHandle ctx, nint[] certs, int certsLen)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (nint* ptr = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(certs))
				{
					void* _certs_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (nint*)_certs_native, certsLen);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetCertificates", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, nint* __certs_native, int __certsLen_native);
		}

		internal static X509Certificate2[] X509ChainGetCertificates(SafeX509ChainContextHandle ctx)
		{
			nint[] array = new nint[X509ChainGetCertificateCount(ctx)];
			int num = X509ChainGetCertificates(ctx, array, array.Length);
			X509Certificate2[] array2 = new X509Certificate2[array.Length];
			try
			{
				if (num == 0)
				{
					throw new CryptographicException();
				}
				for (int i = 0; i < num; i++)
				{
					array2[i] = new X509Certificate2(array[i]);
				}
			}
			finally
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] != IntPtr.Zero)
					{
						JObjectLifetime.DeleteGlobalReference(array[j]);
					}
				}
			}
			if (num == array.Length)
			{
				return array2;
			}
			return array2[0..num];
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetErrorCount")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static int X509ChainGetErrorCount(SafeX509ChainContextHandle ctx)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetErrorCount", ExactSpelling = true)]
			static extern int __PInvoke(nint __ctx_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetErrors")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int X509ChainGetErrors(SafeX509ChainContextHandle ctx, ValidationError[] errors, int errorsLen)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (ValidationError* ptr = &ArrayMarshaller<ValidationError, ValidationError>.ManagedToUnmanagedIn.GetPinnableReference(errors))
				{
					void* _errors_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (ValidationError*)_errors_native, errorsLen);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainGetErrors", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, ValidationError* __errors_native, int __errorsLen_native);
		}

		internal static ValidationError[] X509ChainGetErrors(SafeX509ChainContextHandle ctx)
		{
			int num = X509ChainGetErrorCount(ctx);
			if (num == 0)
			{
				return Array.Empty<ValidationError>();
			}
			ValidationError[] array = new ValidationError[num];
			if (X509ChainGetErrors(ctx, array, array.Length) != 1)
			{
				throw new CryptographicException();
			}
			return array;
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainSetCustomTrustStore")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int X509ChainSetCustomTrustStore(SafeX509ChainContextHandle ctx, nint[] customTrustStore, int customTrustStoreLen)
		{
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (nint* ptr = &ArrayMarshaller<nint, nint>.ManagedToUnmanagedIn.GetPinnableReference(customTrustStore))
				{
					void* _customTrustStore_native = ptr;
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), (nint*)_customTrustStore_native, customTrustStoreLen);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainSetCustomTrustStore", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, nint* __customTrustStore_native, int __customTrustStoreLen_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainValidate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int X509ChainValidate(SafeX509ChainContextHandle ctx, X509RevocationMode revocationMode, X509RevocationFlag revocationFlag, out byte checkedRevocation)
		{
			checkedRevocation = 0;
			int num = 0;
			SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509ChainContextHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(ctx);
				fixed (byte* _checkedRevocation_native = &checkedRevocation)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), revocationMode, revocationFlag, _checkedRevocation_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509ChainValidate", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __ctx_native, X509RevocationMode __revocationMode_native, X509RevocationFlag __revocationFlag_native, byte* __checkedRevocation_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreEnumerateCertificates")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool X509StoreEnumerateCertificates(SafeX509StoreHandle storeHandle, delegate* unmanaged<void*, void*, PAL_KeyAlgorithm, void*, void> callback, void* callbackContext)
		{
			bool flag = false;
			SafeHandleMarshaller<SafeX509StoreHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeX509StoreHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(storeHandle);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), callback, callbackContext) != 0;
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreEnumerateCertificates", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __storeHandle_native, delegate* unmanaged<void*, void*, PAL_KeyAlgorithm, void*, void> __callback_native, void* __callbackContext_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreEnumerateTrustedCertificates")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool X509StoreEnumerateTrustedCertificates(byte systemOnly, delegate* unmanaged<void*, void*, void> callback, void* callbackContext)
		{
			return __PInvoke(systemOnly, callback, callbackContext) != 0;
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreEnumerateTrustedCertificates", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte __systemOnly_native, delegate* unmanaged<void*, void*, void> __callback_native, void* __callbackContext_native);
		}

		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreOpenDefault")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeX509StoreHandle X509StoreOpenDefault()
		{
			bool flag = false;
			SafeX509StoreHandle safeX509StoreHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeX509StoreHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeX509StoreHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke();
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
			[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "AndroidCryptoNative_X509StoreOpenDefault", ExactSpelling = true)]
			static extern nint __PInvoke();
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

		[DllImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EnsureOpenSslInitialized", ExactSpelling = true)]
		[LibraryImport("libSystem.Security.Cryptography.Native.Android", EntryPoint = "CryptoNative_EnsureOpenSslInitialized")]
		private static extern int EnsureOpenSslInitialized();
	}
}
