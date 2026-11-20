using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices;

[CLSCompliant(false)]
[Intrinsic]
public readonly struct CLong : IEquatable<CLong>
{
	private readonly nint _value;

	public nint Value => _value;

	public CLong(int value)
	{
		_value = value;
	}

	public CLong(nint value)
	{
		_value = value;
	}

	public override bool Equals([NotNullWhen(true)] object? o)
	{
		if (o is CLong other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(CLong other)
	{
		return _value == other._value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)_value).GetHashCode();
	}

	public override string ToString()
	{
		return ((IntPtr)_value).ToString();
	}
}
