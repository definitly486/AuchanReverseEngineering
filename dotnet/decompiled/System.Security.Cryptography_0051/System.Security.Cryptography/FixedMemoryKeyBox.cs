using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography;

internal sealed class FixedMemoryKeyBox : SafeHandle
{
	public override bool IsInvalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ReleaseHandle()
	{
		throw new NotSupportedException("Linked away");
	}
}
