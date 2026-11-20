using System.CodeDom.Compiler;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Win32.SafeHandles;

internal static class Interop
{
	internal static class Brotli
	{
		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeBrotliDecoderHandle BrotliDecoderCreateInstance(nint allocFunc, nint freeFunc, nint opaque)
		{
			bool flag = false;
			SafeBrotliDecoderHandle safeBrotliDecoderHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(allocFunc, freeFunc, opaque);
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
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliDecoderCreateInstance", ExactSpelling = true)]
			static extern nint __PInvoke(nint __allocFunc_native, nint __freeFunc_native, nint __opaque_native);
		}

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int BrotliDecoderDecompressStream(SafeBrotliDecoderHandle state, ref nuint availableIn, byte** nextIn, ref nuint availableOut, byte** nextOut, out nuint totalOut)
		{
			totalOut = 0u;
			int num = 0;
			SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(state);
				fixed (nuint* _totalOut_native = &totalOut)
				{
					fixed (nuint* _availableOut_native = &availableOut)
					{
						fixed (nuint* _availableIn_native = &availableIn)
						{
							return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _availableIn_native, nextIn, _availableOut_native, nextOut, _totalOut_native);
						}
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliDecoderDecompressStream", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __state_native, nuint* __availableIn_native, byte** __nextIn_native, nuint* __availableOut_native, byte** __nextOut_native, nuint* __totalOut_native);
		}

		[DllImport("libSystem.IO.Compression.Native", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native")]
		internal static extern void BrotliDecoderDestroyInstance(nint state);

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static BOOL BrotliDecoderIsFinished(SafeBrotliDecoderHandle state)
		{
			BOOL bOOL = BOOL.FALSE;
			SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBrotliDecoderHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(state);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliDecoderIsFinished", ExactSpelling = true)]
			static extern BOOL __PInvoke(nint __state_native);
		}

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static SafeBrotliEncoderHandle BrotliEncoderCreateInstance(nint allocFunc, nint freeFunc, nint opaque)
		{
			bool flag = false;
			SafeBrotliEncoderHandle safeBrotliEncoderHandle = null;
			nint num = 0;
			SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedOut();
			try
			{
				num = __PInvoke(allocFunc, freeFunc, opaque);
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
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliEncoderCreateInstance", ExactSpelling = true)]
			static extern nint __PInvoke(nint __allocFunc_native, nint __freeFunc_native, nint __opaque_native);
		}

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static BOOL BrotliEncoderSetParameter(SafeBrotliEncoderHandle state, BrotliEncoderParameter parameter, uint value)
		{
			BOOL bOOL = BOOL.FALSE;
			SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(state);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), parameter, value);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliEncoderSetParameter", ExactSpelling = true)]
			static extern BOOL __PInvoke(nint __state_native, BrotliEncoderParameter __parameter_native, uint __value_native);
		}

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static BOOL BrotliEncoderCompressStream(SafeBrotliEncoderHandle state, BrotliEncoderOperation op, ref nuint availableIn, byte** nextIn, ref nuint availableOut, byte** nextOut, out nuint totalOut)
		{
			totalOut = 0u;
			BOOL bOOL = BOOL.FALSE;
			SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(state);
				fixed (nuint* _totalOut_native = &totalOut)
				{
					fixed (nuint* _availableOut_native = &availableOut)
					{
						fixed (nuint* _availableIn_native = &availableIn)
						{
							return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), op, _availableIn_native, nextIn, _availableOut_native, nextOut, _totalOut_native);
						}
					}
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliEncoderCompressStream", ExactSpelling = true)]
			static extern unsafe BOOL __PInvoke(nint __state_native, BrotliEncoderOperation __op_native, nuint* __availableIn_native, byte** __nextIn_native, nuint* __availableOut_native, byte** __nextOut_native, nuint* __totalOut_native);
		}

		[LibraryImport("libSystem.IO.Compression.Native")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static BOOL BrotliEncoderHasMoreOutput(SafeBrotliEncoderHandle state)
		{
			BOOL bOOL = BOOL.FALSE;
			SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeBrotliEncoderHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(state);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.IO.Compression.Native", EntryPoint = "BrotliEncoderHasMoreOutput", ExactSpelling = true)]
			static extern BOOL __PInvoke(nint __state_native);
		}

		[DllImport("libSystem.IO.Compression.Native", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native")]
		internal static extern void BrotliEncoderDestroyInstance(nint state);
	}

	internal enum BOOL
	{
		FALSE,
		TRUE
	}
}
