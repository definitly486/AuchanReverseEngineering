using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.Swift;

[CLSCompliant(false)]
[Intrinsic]
public readonly struct SwiftSelf
{
	public unsafe void* Value { get; }

	public unsafe SwiftSelf(void* value)
	{
		Value = value;
	}
}
[Intrinsic]
public readonly struct SwiftSelf<T> where T : unmanaged
{
	public T Value { get; }

	public SwiftSelf(T value)
	{
		Value = value;
	}
}
