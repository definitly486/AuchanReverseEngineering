using System.Runtime.CompilerServices;

namespace System.Diagnostics;

internal sealed class AsyncStreamReader
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CancelOperation()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw new NotSupportedException("Linked away");
	}
}
