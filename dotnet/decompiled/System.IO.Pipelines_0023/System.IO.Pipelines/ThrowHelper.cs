using System.Runtime.CompilerServices;

namespace System.IO.Pipelines;

internal static class ThrowHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NotSupportedException CreateNotSupportedException_UnflushedBytes()
	{
		return new NotSupportedException("UnflushedBytesNotSupported");
	}
}
