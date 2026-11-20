using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace System.Runtime.InteropServices;

[UnsupportedOSPlatform("android")]
[UnsupportedOSPlatform("browser")]
[UnsupportedOSPlatform("ios")]
[UnsupportedOSPlatform("tvos")]
[CLSCompliant(false)]
public abstract class ComWrappers
{
	public struct ComInterfaceEntry
	{
		public Guid IID;

		public nint Vtable;
	}

	public struct ComInterfaceDispatch
	{
		public nint Vtable;

		public unsafe static T GetInstance<T>(ComInterfaceDispatch* dispatchPtr) where T : class
		{
			throw new PlatformNotSupportedException();
		}
	}

	protected unsafe abstract ComInterfaceEntry* ComputeVtables(object obj, CreateComInterfaceFlags flags, out int count);

	protected abstract object? CreateObject(nint externalComObject, CreateObjectFlags flags);

	protected virtual object? CreateObject(nint externalComObject, CreateObjectFlags flags, object? userState, out CreatedWrapperFlags wrapperFlags)
	{
		throw new PlatformNotSupportedException();
	}

	protected internal abstract void ReleaseObjects(IEnumerable objects);

	public static bool TryGetComInstance(object obj, out nint unknown)
	{
		unknown = 0;
		return false;
	}

	public static bool TryGetObject(nint unknown, [NotNullWhen(true)] out object? obj)
	{
		obj = null;
		return false;
	}

	public nint GetOrCreateComInterfaceForObject(object instance, CreateComInterfaceFlags flags)
	{
		throw new PlatformNotSupportedException();
	}

	public object GetOrCreateObjectForComInstance(nint externalComObject, CreateObjectFlags flags)
	{
		throw new PlatformNotSupportedException();
	}

	public object GetOrCreateObjectForComInstance(nint externalComObject, CreateObjectFlags flags, object? userState)
	{
		throw new PlatformNotSupportedException();
	}

	public object GetOrRegisterObjectForComInstance(nint externalComObject, CreateObjectFlags flags, object wrapper)
	{
		throw new PlatformNotSupportedException();
	}

	public object GetOrRegisterObjectForComInstance(nint externalComObject, CreateObjectFlags flags, object wrapper, nint inner)
	{
		throw new PlatformNotSupportedException();
	}

	public static void RegisterForTrackerSupport(ComWrappers instance)
	{
		throw new PlatformNotSupportedException();
	}

	[SupportedOSPlatform("windows")]
	public static void RegisterForMarshalling(ComWrappers instance)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GetIUnknownImpl(out nint fpQueryInterface, out nint fpAddRef, out nint fpRelease)
	{
		throw new PlatformNotSupportedException();
	}
}
