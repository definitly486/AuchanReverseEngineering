using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Runtime.InteropServices;

public static class NativeLibrary
{
	private static ConditionalWeakTable<Assembly, DllImportResolver> s_nativeDllResolveMap;

	private static nint LoadLibraryByName(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, bool throwOnError)
	{
		return LoadByName(libraryName, (RuntimeAssembly)assembly, searchPath.HasValue, (uint)searchPath.GetValueOrDefault(), throwOnError);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint LoadFromPath(string libraryName, bool throwOnError);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint LoadByName(string libraryName, RuntimeAssembly callingAssembly, bool hasDllImportSearchPathFlag, uint dllImportSearchPathFlag, bool throwOnError);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void FreeLib(nint handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetSymbol(nint handle, string symbolName, bool throwOnError);

	private static void MonoLoadLibraryCallbackStub(string libraryName, Assembly assembly, bool hasDllImportSearchPathFlags, uint dllImportSearchPathFlags, ref nint dll)
	{
		dll = LoadLibraryCallbackStub(libraryName, assembly, hasDllImportSearchPathFlags, dllImportSearchPathFlags);
	}

	public static nint Load(string libraryPath)
	{
		ArgumentNullException.ThrowIfNull(libraryPath, "libraryPath");
		return LoadFromPath(libraryPath, throwOnError: true);
	}

	public static bool TryLoad(string libraryPath, out nint handle)
	{
		ArgumentNullException.ThrowIfNull(libraryPath, "libraryPath");
		handle = LoadFromPath(libraryPath, throwOnError: false);
		return handle != IntPtr.Zero;
	}

	public static nint Load(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		ArgumentNullException.ThrowIfNull(libraryName, "libraryName");
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		if (!(assembly is RuntimeAssembly))
		{
			throw new ArgumentException("Argument_MustBeRuntimeAssembly");
		}
		return LoadLibraryByName(libraryName, assembly, searchPath, throwOnError: true);
	}

	public static bool TryLoad(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out nint handle)
	{
		ArgumentNullException.ThrowIfNull(libraryName, "libraryName");
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		if (!(assembly is RuntimeAssembly))
		{
			throw new ArgumentException("Argument_MustBeRuntimeAssembly");
		}
		handle = LoadLibraryByName(libraryName, assembly, searchPath, throwOnError: false);
		return handle != IntPtr.Zero;
	}

	public static void Free(nint handle)
	{
		if (handle != IntPtr.Zero)
		{
			FreeLib(handle);
		}
	}

	public static nint GetExport(nint handle, string name)
	{
		ArgumentNullException.ThrowIfNull(handle, "handle");
		ArgumentNullException.ThrowIfNull(name, "name");
		return GetSymbol(handle, name, throwOnError: true);
	}

	public static bool TryGetExport(nint handle, string name, out nint address)
	{
		ArgumentNullException.ThrowIfNull(handle, "handle");
		ArgumentNullException.ThrowIfNull(name, "name");
		address = GetSymbol(handle, name, throwOnError: false);
		return address != IntPtr.Zero;
	}

	public static void SetDllImportResolver(Assembly assembly, DllImportResolver resolver)
	{
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		ArgumentNullException.ThrowIfNull(resolver, "resolver");
		if (!(assembly is RuntimeAssembly))
		{
			throw new ArgumentException("Argument_MustBeRuntimeAssembly");
		}
		if (s_nativeDllResolveMap == null)
		{
			Interlocked.CompareExchange(ref s_nativeDllResolveMap, new ConditionalWeakTable<Assembly, DllImportResolver>(), null);
		}
		if (!s_nativeDllResolveMap.TryAdd(assembly, resolver))
		{
			throw new InvalidOperationException("InvalidOperation_CannotRegisterSecondResolver");
		}
	}

	internal static nint LoadLibraryCallbackStub(string libraryName, Assembly assembly, bool hasDllImportSearchPathFlags, uint dllImportSearchPathFlags)
	{
		if (s_nativeDllResolveMap == null)
		{
			return IntPtr.Zero;
		}
		if (!s_nativeDllResolveMap.TryGetValue(assembly, out var value))
		{
			return IntPtr.Zero;
		}
		return value(libraryName, assembly, hasDllImportSearchPathFlags ? new DllImportSearchPath?((DllImportSearchPath)dllImportSearchPathFlags) : ((DllImportSearchPath?)null));
	}

	public static nint GetMainProgramHandle()
	{
		_ = IntPtr.Zero;
		nint defaultSearchOrderPseudoHandle = Interop.Sys.GetDefaultSearchOrderPseudoHandle();
		if (defaultSearchOrderPseudoHandle == IntPtr.Zero)
		{
			throw new Win32Exception(Marshal.GetLastPInvokeError());
		}
		return defaultSearchOrderPseudoHandle;
	}
}
