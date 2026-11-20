using System.Runtime.CompilerServices;

namespace System.Resources;

public sealed class ResourceWriter : IDisposable
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw new NotSupportedException("Linked away");
	}
}
