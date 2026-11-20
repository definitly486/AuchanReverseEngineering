using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.Swift;

[CLSCompliant(false)]
[Intrinsic]
public readonly struct SwiftError
{
	public unsafe void* Value { get; }

	public unsafe SwiftError(void* value)
	{
		Value = value;
	}
}
