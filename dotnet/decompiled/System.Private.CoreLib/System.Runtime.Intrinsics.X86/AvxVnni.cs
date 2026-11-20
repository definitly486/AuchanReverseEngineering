using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class AvxVnni : Avx2
{
	public new abstract class X64 : Avx2.X64
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

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<byte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<byte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<byte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<byte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}
}
