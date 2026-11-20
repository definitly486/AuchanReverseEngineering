using System.Runtime.CompilerServices;

namespace System.IO.Packaging;

internal class PartBasedPackageProperties : PackageProperties
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Flush()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Close()
	{
		throw new NotSupportedException("Linked away");
	}
}
