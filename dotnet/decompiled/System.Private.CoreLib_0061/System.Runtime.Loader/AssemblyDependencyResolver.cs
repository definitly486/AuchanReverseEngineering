using System.Reflection;
using System.Runtime.Versioning;

namespace System.Runtime.Loader;

[UnsupportedOSPlatform("android")]
[UnsupportedOSPlatform("browser")]
[UnsupportedOSPlatform("ios")]
[UnsupportedOSPlatform("tvos")]
public sealed class AssemblyDependencyResolver
{
	public AssemblyDependencyResolver(string componentAssemblyPath)
	{
		throw new PlatformNotSupportedException();
	}

	public string? ResolveAssemblyToPath(AssemblyName assemblyName)
	{
		throw new PlatformNotSupportedException();
	}

	public string? ResolveUnmanagedDllToPath(string unmanagedDllName)
	{
		throw new PlatformNotSupportedException();
	}
}
