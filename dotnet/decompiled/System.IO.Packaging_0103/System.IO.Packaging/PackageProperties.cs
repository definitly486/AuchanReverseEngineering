using System.Runtime.CompilerServices;

namespace System.IO.Packaging;

public abstract class PackageProperties
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw new NotSupportedException("Linked away");
	}
}
