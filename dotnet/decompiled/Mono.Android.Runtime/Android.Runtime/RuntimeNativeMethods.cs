using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Java;
using System.Text;

namespace Android.Runtime;

internal static class RuntimeNativeMethods
{
	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void monodroid_log(LogLevel level, LogCategories category, string message);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint monodroid_timing_start(string? message);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void monodroid_timing_stop(nint sequence, string? message);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void monodroid_free(nint ptr);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_gref_get();

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_weak_gref_get();

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint _monodroid_lookup_replacement_type(string jniSimpleReference);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint _monodroid_lookup_replacement_method_info(string jniSourceType, string jniMethodName, string jniMethodSignature);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint _monodroid_timezone_get_default_id();

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_getifaddrs(out nint ifap);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_freeifaddrs(nint ifap);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_detect_cpu_and_architecture(ref ushort built_for_cpu, ref ushort running_on_cpu, ref byte is64bit);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_gc_wait_for_bridge_processing();

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_gref_log(string message);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_gref_log_new(nint curHandle, byte curType, nint newHandle, byte newType, string? threadName, int threadId, [In] StringBuilder? from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_gref_log_delete(nint handle, byte type, string? threadName, int threadId, [In] StringBuilder? from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_weak_gref_new(nint curHandle, byte curType, nint newHandle, byte newType, string? threadName, int threadId, [In] StringBuilder? from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_weak_gref_delete(nint handle, byte type, string? threadName, int threadId, [In] StringBuilder? from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_lref_log_new(int lrefc, nint handle, byte type, string? threadName, int threadId, [In] StringBuilder from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void _monodroid_lref_log_delete(int lrefc, nint handle, byte type, string? threadName, int threadId, [In] StringBuilder from, int from_writable);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint monodroid_TypeManager_get_java_class_name(nint klass);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int _monodroid_max_gref_get();

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern nint clr_typemap_managed_to_java(string fullName, nint mvid);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal static extern bool clr_typemap_java_to_managed(string java_type_name, out nint managed_assembly_name, out uint managed_type_token_id);

	[DllImport("xa-internal-api", CallingConvention = CallingConvention.Cdecl)]
	internal unsafe static extern delegate* unmanaged<MarkCrossReferencesArgs*, void> clr_initialize_gc_bridge(delegate* unmanaged<MarkCrossReferencesArgs*, void> bridge_processing_started_callback, delegate* unmanaged<MarkCrossReferencesArgs*, void> bridge_processing_finished_callback);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void monodroid_unhandled_exception(Exception javaException);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void monodroid_debugger_unhandled_exception(Exception e);
}
