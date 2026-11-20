using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Ssse3 : Sse3
{
	public new abstract class X64 : Sse3.X64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}
	}

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static Vector128<byte> Abs(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Abs(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Abs(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AlignRight(Vector128<sbyte> left, Vector128<sbyte> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AlignRight(Vector128<byte> left, Vector128<byte> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AlignRight(Vector128<short> left, Vector128<short> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AlignRight(Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AlignRight(Vector128<int> left, Vector128<int> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AlignRight(Vector128<uint> left, Vector128<uint> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AlignRight(Vector128<long> left, Vector128<long> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AlignRight(Vector128<ulong> left, Vector128<ulong> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> HorizontalAdd(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> HorizontalAdd(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> HorizontalAddSaturate(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> HorizontalSubtract(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> HorizontalSubtract(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> HorizontalSubtractSaturate(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyAddAdjacent(Vector128<byte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyHighRoundScale(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Shuffle(Vector128<sbyte> value, Vector128<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Shuffle(Vector128<byte> value, Vector128<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Sign(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Sign(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Sign(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}
}
