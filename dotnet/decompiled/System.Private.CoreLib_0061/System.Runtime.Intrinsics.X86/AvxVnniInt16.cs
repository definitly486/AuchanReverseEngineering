using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class AvxVnniInt16 : Avx2
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

	[Intrinsic]
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

		public static Vector512<int> MultiplyWideningAndAdd(Vector512<int> addend, Vector512<short> left, Vector512<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAdd(Vector512<int> addend, Vector512<ushort> left, Vector512<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> MultiplyWideningAndAdd(Vector512<uint> addend, Vector512<ushort> left, Vector512<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAddSaturate(Vector512<int> addend, Vector512<short> left, Vector512<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> MultiplyWideningAndAddSaturate(Vector512<int> addend, Vector512<ushort> left, Vector512<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> MultiplyWideningAndAddSaturate(Vector512<uint> addend, Vector512<ushort> left, Vector512<ushort> right)
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

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<short> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAdd(Vector128<int> addend, Vector128<ushort> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningAndAdd(Vector128<uint> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<short> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAdd(Vector256<int> addend, Vector256<ushort> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> MultiplyWideningAndAdd(Vector256<uint> addend, Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningAndAddSaturate(Vector128<int> addend, Vector128<ushort> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningAndAddSaturate(Vector128<uint> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<short> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> MultiplyWideningAndAddSaturate(Vector256<int> addend, Vector256<ushort> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> MultiplyWideningAndAddSaturate(Vector256<uint> addend, Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}
}
