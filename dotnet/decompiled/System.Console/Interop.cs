using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static class Interop
{
	internal static class Logcat
	{
		internal enum LogLevel
		{
			Unknown,
			Default,
			Verbose,
			Debug,
			Info,
			Warn,
			Error,
			Fatal,
			Silent
		}

		[LibraryImport("liblog", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static void __android_log_print(LogLevel level, string tag, string format, string args, nint ptr)
		{
			byte* ptr2 = default(byte*);
			byte* ptr3 = default(byte*);
			byte* ptr4 = default(byte*);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn3 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				string managed = args;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = format;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				managed = tag;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn3.FromManaged(managed, buffer);
				ptr4 = managedToUnmanagedIn.ToUnmanaged();
				ptr3 = managedToUnmanagedIn2.ToUnmanaged();
				ptr2 = managedToUnmanagedIn3.ToUnmanaged();
				__PInvoke(level, ptr2, ptr3, ptr4, ptr);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
				managedToUnmanagedIn3.Free();
			}
			[DllImport("liblog", EntryPoint = "__android_log_print", ExactSpelling = true)]
			static extern unsafe void __PInvoke(LogLevel __level_native, byte* __tag_native, byte* __format_native, byte* __args_native, nint __ptr_native);
		}

		internal static void AndroidLogPrint(LogLevel level, string tag, string message)
		{
			__android_log_print(level, tag, "%s", message, IntPtr.Zero);
		}
	}
}
