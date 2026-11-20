using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.Swift;

[CLSCompliant(false)]
[Intrinsic]
public readonly struct SwiftIndirectResult
{
	public unsafe void* Value { get; }

	public unsafe SwiftIndirectResult(void* value)
	{
		Value = value;
	}
}
