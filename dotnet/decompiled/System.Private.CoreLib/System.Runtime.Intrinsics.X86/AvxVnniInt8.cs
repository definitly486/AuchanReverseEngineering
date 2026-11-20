using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class AvxVnniInt8 : Avx2
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

	public abstract class V512
	{
		public static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector512<int> MultiplyWideningAndAdd(Vector512<int> addend, Vector512<sbyte> left, Vector512<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAdd(Vector512<int> addend, Vector512<sbyte> left, Vector512<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> MultiplyWideningAndAdd(Vector512<uint> addend, Vector512<byte> left, Vector512<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAddSaturate(Vector512<int> addend, Vector512<sbyte> left, Vector512<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAddSaturate(Vector512<int> addend, Vector512<sbyte> left, Vector512<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> MultiplyWideningAndAddSaturate(Vector512<uint> addend, Vector512<byte> left, Vector512<byte> right)
		{
			throw new PlatformNotSupportedException();
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

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<sbyte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningAndAdd(Vector128<uint> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<sbyte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> MultiplyWideningAndAdd(Vector256<uint> addend, Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<sbyte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningAndAddSaturate(Vector128<uint> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<sbyte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> MultiplyWideningAndAddSaturate(Vector256<uint> addend, Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}
}
