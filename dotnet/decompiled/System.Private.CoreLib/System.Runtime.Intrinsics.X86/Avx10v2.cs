using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Avx10v2 : Avx10v1
{
	public new abstract class X64 : Avx10v1.X64
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

	public new abstract class V512 : Avx10v1.V512
	{
		[Intrinsic]
		public new abstract class X64 : Avx10v1.V512.X64
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

		public static Vector512<double> MinMax(Vector512<double> left, Vector512<double> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> MinMax(Vector512<float> left, Vector512<float> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToSByteWithSaturationAndZeroExtendToInt32(Vector512<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToSByteWithSaturationAndZeroExtendToInt32(Vector512<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToByteWithSaturationAndZeroExtendToInt32(Vector512<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToByteWithSaturationAndZeroExtendToInt32(Vector512<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToSByteWithTruncatedSaturationAndZeroExtendToInt32(Vector512<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> ConvertToByteWithTruncatedSaturationAndZeroExtendToInt32(Vector512<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ushort> MultipleSumAbsoluteDifferences(Vector512<byte> left, Vector512<byte> right, [ConstantExpected] byte mask)
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

	public static Vector128<double> MinMax(Vector128<double> left, Vector128<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> MinMax(Vector256<double> left, Vector256<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MinMax(Vector128<float> left, Vector128<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> MinMax(Vector256<float> left, Vector256<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> MinMaxScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MinMaxScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToSByteWithSaturationAndZeroExtendToInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToSByteWithSaturationAndZeroExtendToInt32(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToByteWithSaturationAndZeroExtendToInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToByteWithSaturationAndZeroExtendToInt32(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToSByteWithTruncatedSaturationAndZeroExtendToInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToSByteWithTruncatedSaturationAndZeroExtendToInt32(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToByteWithTruncatedSaturationAndZeroExtendToInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToByteWithTruncatedSaturationAndZeroExtendToInt32(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MoveScalar(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MoveScalar(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MoveScalar(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MoveScalar(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreScalar(short* address, Vector128<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreScalar(ushort* address, Vector128<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}
}
