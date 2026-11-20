namespace System.Reflection.Metadata;

public static class AssemblyExtensions
{
	[CLSCompliant(false)]
	public unsafe static bool TryGetRawMetadata(this Assembly assembly, out byte* blob, out int length)
	{
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		if (assembly is RuntimeAssembly runtimeAssembly)
		{
			return runtimeAssembly.TryGetRawMetadata(out blob, out length);
		}
		blob = null;
		length = 0;
		return false;
	}
}
