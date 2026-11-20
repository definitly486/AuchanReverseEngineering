using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Gfni : Sse41
{
	public new abstract class X64 : Sse41.X64
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

	public abstract class V256
	{
		public static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector256<byte> GaloisFieldAffineTransformInverse(Vector256<byte> x, Vector256<byte> a, [ConstantExpected] byte b)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<byte> GaloisFieldAffineTransform(Vector256<byte> x, Vector256<byte> a, [ConstantExpected] byte b)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<byte> GaloisFieldMultiply(Vector256<byte> left, Vector256<byte> right)
		{
			throw new PlatformNotSupportedException();
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

		public static Vector512<byte> GaloisFieldAffineTransformInverse(Vector512<byte> x, Vector512<byte> a, [ConstantExpected] byte b)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> GaloisFieldAffineTransform(Vector512<byte> x, Vector512<byte> a, [ConstantExpected] byte b)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> GaloisFieldMultiply(Vector512<byte> left, Vector512<byte> right)
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

	public static Vector128<byte> GaloisFieldAffineTransformInverse(Vector128<byte> x, Vector128<byte> a, [ConstantExpected] byte b)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> GaloisFieldAffineTransform(Vector128<byte> x, Vector128<byte> a, [ConstantExpected] byte b)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> GaloisFieldMultiply(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}
}
