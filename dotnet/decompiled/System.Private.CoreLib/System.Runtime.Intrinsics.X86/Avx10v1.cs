using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Avx10v1 : Avx2
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

		public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, long value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, ulong value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertScalarToVector128Double(Vector128<double> upper, ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertScalarToVector128Double(Vector128<double> upper, long value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertScalarToVector128Double(Vector128<double> upper, ulong value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static long ConvertToInt64(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static long ConvertToInt64(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64WithTruncation(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ConvertToUInt64WithTruncation(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}
	}

	public abstract class V512 : Avx512BW
	{
		[Intrinsic]
		public new abstract class X64 : Avx512BW.X64
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

		public static Vector512<float> And(Vector512<float> left, Vector512<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> And(Vector512<double> left, Vector512<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> AndNot(Vector512<float> left, Vector512<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> AndNot(Vector512<double> left, Vector512<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> BroadcastPairScalarToVector512(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> BroadcastPairScalarToVector512(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> BroadcastPairScalarToVector512(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<long> BroadcastVector128ToVector512(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<ulong> BroadcastVector128ToVector512(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<double> BroadcastVector128ToVector512(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<int> BroadcastVector256ToVector512(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<uint> BroadcastVector256ToVector512(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<float> BroadcastVector256ToVector512(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> Classify(Vector512<double> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> Classify(Vector512<float> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> Compress(Vector512<byte> merge, Vector512<byte> mask, Vector512<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<short> Compress(Vector512<short> merge, Vector512<short> mask, Vector512<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<sbyte> Compress(Vector512<sbyte> merge, Vector512<sbyte> mask, Vector512<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ushort> Compress(Vector512<ushort> merge, Vector512<ushort> mask, Vector512<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void CompressStore(byte* address, Vector512<byte> mask, Vector512<byte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void CompressStore(short* address, Vector512<short> mask, Vector512<short> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void CompressStore(sbyte* address, Vector512<sbyte> mask, Vector512<sbyte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void CompressStore(ushort* address, Vector512<ushort> mask, Vector512<ushort> source)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> ConvertToVector256Single(Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> ConvertToVector256Single(Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> ConvertToVector256Single(Vector512<long> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> ConvertToVector256Single(Vector512<ulong> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> ConvertToVector512Double(Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> ConvertToVector512Double(Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> ConvertToVector512Double(Vector512<long> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> ConvertToVector512Double(Vector512<ulong> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64(Vector512<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64(Vector256<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64WithTruncation(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> ConvertToVector512Int64WithTruncation(Vector512<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64(Vector512<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64(Vector256<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64WithTruncation(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> ConvertToVector512UInt64WithTruncation(Vector512<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> DetectConflicts(Vector512<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> DetectConflicts(Vector512<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> DetectConflicts(Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> DetectConflicts(Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> Expand(Vector512<byte> merge, Vector512<byte> mask, Vector512<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<short> Expand(Vector512<short> merge, Vector512<short> mask, Vector512<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<sbyte> Expand(Vector512<sbyte> merge, Vector512<sbyte> mask, Vector512<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ushort> Expand(Vector512<ushort> merge, Vector512<ushort> mask, Vector512<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<byte> ExpandLoad(byte* address, Vector512<byte> mask, Vector512<byte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<short> ExpandLoad(short* address, Vector512<short> mask, Vector512<short> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<sbyte> ExpandLoad(sbyte* address, Vector512<sbyte> mask, Vector512<sbyte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector512<ushort> ExpandLoad(ushort* address, Vector512<ushort> mask, Vector512<ushort> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector128<long> ExtractVector128(Vector512<long> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector128<ulong> ExtractVector128(Vector512<ulong> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector128<double> ExtractVector128(Vector512<double> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector256<int> ExtractVector256(Vector512<int> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector256<uint> ExtractVector256(Vector512<uint> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector256<float> ExtractVector256(Vector512<float> value, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<long> InsertVector128(Vector512<long> value, Vector128<long> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<ulong> InsertVector128(Vector512<ulong> value, Vector128<ulong> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<double> InsertVector128(Vector512<double> value, Vector128<double> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<int> InsertVector256(Vector512<int> value, Vector256<int> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<uint> InsertVector256(Vector512<uint> value, Vector256<uint> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public new static Vector512<float> InsertVector256(Vector512<float> value, Vector256<float> data, [ConstantExpected] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<int> LeadingZeroCount(Vector512<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<uint> LeadingZeroCount(Vector512<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> LeadingZeroCount(Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> LeadingZeroCount(Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static int MoveMask(Vector512<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static int MoveMask(Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static int MoveMask(Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<long> MultiplyLow(Vector512<long> left, Vector512<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> MultiplyLow(Vector512<ulong> left, Vector512<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> MultiShift(Vector512<byte> control, Vector512<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<sbyte> MultiShift(Vector512<sbyte> control, Vector512<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> Or(Vector512<float> left, Vector512<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> Or(Vector512<double> left, Vector512<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<sbyte> PermuteVar64x8(Vector512<sbyte> left, Vector512<sbyte> control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> PermuteVar64x8(Vector512<byte> left, Vector512<byte> control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<byte> PermuteVar64x8x2(Vector512<byte> lower, Vector512<byte> indices, Vector512<byte> upper)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<sbyte> PermuteVar64x8x2(Vector512<sbyte> lower, Vector512<sbyte> indices, Vector512<sbyte> upper)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> Range(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> Range(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> Reduce(Vector512<float> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> Reduce(Vector512<double> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<float> Xor(Vector512<float> left, Vector512<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<double> Xor(Vector512<double> left, Vector512<double> right)
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

	public static Vector128<ulong> Abs(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Abs(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> AddScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AddScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AlignRight32(Vector128<int> left, Vector128<int> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AlignRight32(Vector128<uint> left, Vector128<uint> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> AlignRight32(Vector256<int> left, Vector256<int> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> AlignRight32(Vector256<uint> left, Vector256<uint> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AlignRight64(Vector128<long> left, Vector128<long> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AlignRight64(Vector128<ulong> left, Vector128<ulong> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> AlignRight64(Vector256<long> left, Vector256<long> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> AlignRight64(Vector256<ulong> left, Vector256<ulong> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<byte> BlendVariable(Vector128<byte> left, Vector128<byte> right, Vector128<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> BlendVariable(Vector128<double> left, Vector128<double> right, Vector128<double> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<short> BlendVariable(Vector128<short> left, Vector128<short> right, Vector128<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<int> BlendVariable(Vector128<int> left, Vector128<int> right, Vector128<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<long> BlendVariable(Vector128<long> left, Vector128<long> right, Vector128<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<sbyte> BlendVariable(Vector128<sbyte> left, Vector128<sbyte> right, Vector128<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> BlendVariable(Vector128<float> left, Vector128<float> right, Vector128<float> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<ushort> BlendVariable(Vector128<ushort> left, Vector128<ushort> right, Vector128<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<uint> BlendVariable(Vector128<uint> left, Vector128<uint> right, Vector128<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<ulong> BlendVariable(Vector128<ulong> left, Vector128<ulong> right, Vector128<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<byte> BlendVariable(Vector256<byte> left, Vector256<byte> right, Vector256<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> BlendVariable(Vector256<double> left, Vector256<double> right, Vector256<double> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<short> BlendVariable(Vector256<short> left, Vector256<short> right, Vector256<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<int> BlendVariable(Vector256<int> left, Vector256<int> right, Vector256<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<long> BlendVariable(Vector256<long> left, Vector256<long> right, Vector256<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<sbyte> BlendVariable(Vector256<sbyte> left, Vector256<sbyte> right, Vector256<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> BlendVariable(Vector256<float> left, Vector256<float> right, Vector256<float> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<ushort> BlendVariable(Vector256<ushort> left, Vector256<ushort> right, Vector256<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<uint> BlendVariable(Vector256<uint> left, Vector256<uint> right, Vector256<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<ulong> BlendVariable(Vector256<ulong> left, Vector256<ulong> right, Vector256<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> BroadcastPairScalarToVector128(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> BroadcastPairScalarToVector128(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> BroadcastPairScalarToVector256(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> BroadcastPairScalarToVector256(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> BroadcastPairScalarToVector256(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Classify(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Classify(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Classify(Vector256<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Classify(Vector256<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ClassifyScalar(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ClassifyScalar(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<byte> CompareEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareGreaterThan(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareGreaterThanOrEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareLessThan(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareLessThanOrEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareNotEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<byte> CompareEqual(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> CompareGreaterThan(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> CompareGreaterThanOrEqual(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> CompareLessThan(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> CompareLessThanOrEqual(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> CompareNotEqual(Vector256<byte> left, Vector256<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> Compare(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareGreaterThan(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareLessThan(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareLessThanOrEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareNotEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareNotGreaterThan(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareNotGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareNotLessThan(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareNotLessThanOrEqual(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareOrdered(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<double> CompareUnordered(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> Compare(Vector256<double> left, Vector256<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareGreaterThan(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareGreaterThanOrEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareLessThan(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareLessThanOrEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareNotEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareNotGreaterThan(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareNotGreaterThanOrEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareNotLessThan(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareNotLessThanOrEqual(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareOrdered(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<double> CompareUnordered(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<short> CompareEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<short> CompareGreaterThan(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareGreaterThanOrEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<short> CompareLessThan(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareLessThanOrEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareNotEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<short> CompareEqual(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<short> CompareGreaterThan(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> CompareGreaterThanOrEqual(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> CompareLessThan(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> CompareLessThanOrEqual(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> CompareNotEqual(Vector256<short> left, Vector256<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<int> CompareEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<int> CompareGreaterThan(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareGreaterThanOrEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<int> CompareLessThan(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareLessThanOrEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareNotEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<int> CompareEqual(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<int> CompareGreaterThan(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> CompareGreaterThanOrEqual(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> CompareLessThan(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> CompareLessThanOrEqual(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> CompareNotEqual(Vector256<int> left, Vector256<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<long> CompareEqual(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<long> CompareGreaterThan(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> CompareGreaterThanOrEqual(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> CompareLessThan(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> CompareLessThanOrEqual(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> CompareNotEqual(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<long> CompareEqual(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<long> CompareGreaterThan(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> CompareGreaterThanOrEqual(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> CompareLessThan(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> CompareLessThanOrEqual(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> CompareNotEqual(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<sbyte> CompareEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<sbyte> CompareGreaterThan(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareGreaterThanOrEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<sbyte> CompareLessThan(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareLessThanOrEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareNotEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<sbyte> CompareEqual(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<sbyte> CompareGreaterThan(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> CompareGreaterThanOrEqual(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> CompareLessThan(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> CompareLessThanOrEqual(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> CompareNotEqual(Vector256<sbyte> left, Vector256<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> Compare(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareGreaterThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareLessThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareLessThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareNotEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareNotGreaterThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareNotGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareNotLessThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareNotLessThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareOrdered(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<float> CompareUnordered(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> Compare(Vector256<float> left, Vector256<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareGreaterThan(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareGreaterThanOrEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareLessThan(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareLessThanOrEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareNotEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareNotGreaterThan(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareNotGreaterThanOrEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareNotLessThan(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareNotLessThanOrEqual(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareOrdered(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<float> CompareUnordered(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<ushort> CompareEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareGreaterThan(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareGreaterThanOrEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareLessThan(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareLessThanOrEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareNotEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<ushort> CompareEqual(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> CompareGreaterThan(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> CompareGreaterThanOrEqual(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> CompareLessThan(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> CompareLessThanOrEqual(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> CompareNotEqual(Vector256<ushort> left, Vector256<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<uint> CompareEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareGreaterThan(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareGreaterThanOrEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareLessThan(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareLessThanOrEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareNotEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<uint> CompareEqual(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> CompareGreaterThan(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> CompareGreaterThanOrEqual(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> CompareLessThan(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> CompareLessThanOrEqual(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> CompareNotEqual(Vector256<uint> left, Vector256<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector128<ulong> CompareEqual(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CompareGreaterThan(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CompareGreaterThanOrEqual(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CompareLessThan(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CompareLessThanOrEqual(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CompareNotEqual(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector256<ulong> CompareEqual(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> CompareGreaterThan(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> CompareGreaterThanOrEqual(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> CompareLessThan(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> CompareLessThanOrEqual(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> CompareNotEqual(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Compress(Vector128<byte> merge, Vector128<byte> mask, Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Compress(Vector128<double> merge, Vector128<double> mask, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Compress(Vector128<short> merge, Vector128<short> mask, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Compress(Vector128<int> merge, Vector128<int> mask, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Compress(Vector128<long> merge, Vector128<long> mask, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Compress(Vector128<sbyte> merge, Vector128<sbyte> mask, Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Compress(Vector128<float> merge, Vector128<float> mask, Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Compress(Vector128<ushort> merge, Vector128<ushort> mask, Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Compress(Vector128<uint> merge, Vector128<uint> mask, Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Compress(Vector128<ulong> merge, Vector128<ulong> mask, Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> Compress(Vector256<byte> merge, Vector256<byte> mask, Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Compress(Vector256<double> merge, Vector256<double> mask, Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> Compress(Vector256<short> merge, Vector256<short> mask, Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> Compress(Vector256<int> merge, Vector256<int> mask, Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> Compress(Vector256<long> merge, Vector256<long> mask, Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> Compress(Vector256<sbyte> merge, Vector256<sbyte> mask, Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Compress(Vector256<float> merge, Vector256<float> mask, Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> Compress(Vector256<ushort> merge, Vector256<ushort> mask, Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> Compress(Vector256<uint> merge, Vector256<uint> mask, Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Compress(Vector256<ulong> merge, Vector256<ulong> mask, Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(byte* address, Vector128<byte> mask, Vector128<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(double* address, Vector128<double> mask, Vector128<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(short* address, Vector128<short> mask, Vector128<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(int* address, Vector128<int> mask, Vector128<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(long* address, Vector128<long> mask, Vector128<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(float* address, Vector128<float> mask, Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(ushort* address, Vector128<ushort> mask, Vector128<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(uint* address, Vector128<uint> mask, Vector128<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(ulong* address, Vector128<ulong> mask, Vector128<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(byte* address, Vector256<byte> mask, Vector256<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(double* address, Vector256<double> mask, Vector256<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(short* address, Vector256<short> mask, Vector256<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(int* address, Vector256<int> mask, Vector256<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(long* address, Vector256<long> mask, Vector256<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(float* address, Vector256<float> mask, Vector256<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(ushort* address, Vector256<ushort> mask, Vector256<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(uint* address, Vector256<uint> mask, Vector256<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(ulong* address, Vector256<ulong> mask, Vector256<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ConvertScalarToVector128Double(Vector128<double> upper, uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, int value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, uint value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConvertToInt32(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConvertToInt32(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32WithTruncation(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ConvertToVector128Double(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ConvertToVector128Double(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ConvertToVector128Double(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16WithSaturation(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16WithSaturation(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16WithSaturation(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16WithSaturation(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32WithSaturation(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToVector128Int32WithSaturation(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ConvertToVector128Int64(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ConvertToVector128Int64(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ConvertToVector128Int64WithTruncation(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ConvertToVector128Int64WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToVector128Single(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToVector128Single(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToVector128Single(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToVector128Single(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToVector128Single(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16WithSaturation(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16WithSaturation(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16WithSaturation(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16WithSaturation(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32WithSaturation(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32WithSaturation(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ConvertToVector128UInt64(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ConvertToVector128UInt64(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ConvertToVector128UInt64WithTruncation(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ConvertToVector128UInt64WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> ConvertToVector256Double(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> ConvertToVector256Double(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> ConvertToVector256Double(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ConvertToVector256Int64(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ConvertToVector256Int64(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ConvertToVector256Int64WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ConvertToVector256Int64WithTruncation(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> ConvertToVector256Single(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32WithTruncation(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> ConvertToVector256UInt64(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> ConvertToVector256UInt64(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> ConvertToVector256UInt64WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> ConvertToVector256UInt64WithTruncation(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> DetectConflicts(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> DetectConflicts(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> DetectConflicts(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> DetectConflicts(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> DetectConflicts(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> DetectConflicts(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> DetectConflicts(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> DetectConflicts(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> DivideScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> DivideScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Expand(Vector128<byte> merge, Vector128<byte> mask, Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Expand(Vector128<double> merge, Vector128<double> mask, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Expand(Vector128<short> merge, Vector128<short> mask, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Expand(Vector128<int> merge, Vector128<int> mask, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Expand(Vector128<long> merge, Vector128<long> mask, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Expand(Vector128<sbyte> merge, Vector128<sbyte> mask, Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Expand(Vector128<float> merge, Vector128<float> mask, Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Expand(Vector128<ushort> merge, Vector128<ushort> mask, Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Expand(Vector128<uint> merge, Vector128<uint> mask, Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Expand(Vector128<ulong> merge, Vector128<ulong> mask, Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> Expand(Vector256<byte> merge, Vector256<byte> mask, Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Expand(Vector256<double> merge, Vector256<double> mask, Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> Expand(Vector256<short> merge, Vector256<short> mask, Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> Expand(Vector256<int> merge, Vector256<int> mask, Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> Expand(Vector256<long> merge, Vector256<long> mask, Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> Expand(Vector256<sbyte> merge, Vector256<sbyte> mask, Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Expand(Vector256<float> merge, Vector256<float> mask, Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> Expand(Vector256<ushort> merge, Vector256<ushort> mask, Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> Expand(Vector256<uint> merge, Vector256<uint> mask, Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Expand(Vector256<ulong> merge, Vector256<ulong> mask, Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> ExpandLoad(byte* address, Vector128<byte> mask, Vector128<byte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> ExpandLoad(double* address, Vector128<double> mask, Vector128<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> ExpandLoad(short* address, Vector128<short> mask, Vector128<short> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> ExpandLoad(int* address, Vector128<int> mask, Vector128<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> ExpandLoad(long* address, Vector128<long> mask, Vector128<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> ExpandLoad(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> ExpandLoad(float* address, Vector128<float> mask, Vector128<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> ExpandLoad(ushort* address, Vector128<ushort> mask, Vector128<ushort> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> ExpandLoad(uint* address, Vector128<uint> mask, Vector128<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> ExpandLoad(ulong* address, Vector128<ulong> mask, Vector128<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<byte> ExpandLoad(byte* address, Vector256<byte> mask, Vector256<byte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<double> ExpandLoad(double* address, Vector256<double> mask, Vector256<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<short> ExpandLoad(short* address, Vector256<short> mask, Vector256<short> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<int> ExpandLoad(int* address, Vector256<int> mask, Vector256<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<long> ExpandLoad(long* address, Vector256<long> mask, Vector256<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<sbyte> ExpandLoad(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<float> ExpandLoad(float* address, Vector256<float> mask, Vector256<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<ushort> ExpandLoad(ushort* address, Vector256<ushort> mask, Vector256<ushort> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<uint> ExpandLoad(uint* address, Vector256<uint> mask, Vector256<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<ulong> ExpandLoad(ulong* address, Vector256<ulong> mask, Vector256<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Fixup(Vector128<double> left, Vector128<double> right, Vector128<long> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Fixup(Vector128<float> left, Vector128<float> right, Vector128<int> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Fixup(Vector256<double> left, Vector256<double> right, Vector256<long> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Fixup(Vector256<float> left, Vector256<float> right, Vector256<int> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FixupScalar(Vector128<double> left, Vector128<double> right, Vector128<long> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FixupScalar(Vector128<float> left, Vector128<float> right, Vector128<int> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplyAddNegatedScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplyAddNegatedScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplyAddScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplyAddScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplySubtractNegatedScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplySubtractNegatedScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplySubtractScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplySubtractScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetExponent(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetExponent(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> GetExponent(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> GetExponent(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetExponentScalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetExponentScalar(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetExponentScalar(Vector128<float> upper, Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetExponentScalar(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetMantissa(Vector128<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetMantissa(Vector128<float> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> GetMantissa(Vector256<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> GetMantissa(Vector256<float> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetMantissaScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> GetMantissaScalar(Vector128<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetMantissaScalar(Vector128<float> upper, Vector128<float> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetMantissaScalar(Vector128<float> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> LeadingZeroCount(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> LeadingZeroCount(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> LeadingZeroCount(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> LeadingZeroCount(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> LeadingZeroCount(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> LeadingZeroCount(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> LeadingZeroCount(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> LeadingZeroCount(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> MaskLoad(byte* address, Vector128<byte> mask, Vector128<byte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> MaskLoad(double* address, Vector128<double> mask, Vector128<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> MaskLoad(short* address, Vector128<short> mask, Vector128<short> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> MaskLoad(int* address, Vector128<int> mask, Vector128<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> MaskLoad(long* address, Vector128<long> mask, Vector128<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> MaskLoad(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> MaskLoad(float* address, Vector128<float> mask, Vector128<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> MaskLoad(ushort* address, Vector128<ushort> mask, Vector128<ushort> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> MaskLoad(uint* address, Vector128<uint> mask, Vector128<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> MaskLoad(ulong* address, Vector128<ulong> mask, Vector128<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<byte> MaskLoad(byte* address, Vector256<byte> mask, Vector256<byte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<double> MaskLoad(double* address, Vector256<double> mask, Vector256<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<short> MaskLoad(short* address, Vector256<short> mask, Vector256<short> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<int> MaskLoad(int* address, Vector256<int> mask, Vector256<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<long> MaskLoad(long* address, Vector256<long> mask, Vector256<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<sbyte> MaskLoad(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<float> MaskLoad(float* address, Vector256<float> mask, Vector256<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<ushort> MaskLoad(ushort* address, Vector256<ushort> mask, Vector256<ushort> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<uint> MaskLoad(uint* address, Vector256<uint> mask, Vector256<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<ulong> MaskLoad(ulong* address, Vector256<ulong> mask, Vector256<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> MaskLoadAligned(double* address, Vector128<double> mask, Vector128<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> MaskLoadAligned(int* address, Vector128<int> mask, Vector128<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> MaskLoadAligned(long* address, Vector128<long> mask, Vector128<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> MaskLoadAligned(float* address, Vector128<float> mask, Vector128<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> MaskLoadAligned(uint* address, Vector128<uint> mask, Vector128<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> MaskLoadAligned(ulong* address, Vector128<ulong> mask, Vector128<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<double> MaskLoadAligned(double* address, Vector256<double> mask, Vector256<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<int> MaskLoadAligned(int* address, Vector256<int> mask, Vector256<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<long> MaskLoadAligned(long* address, Vector256<long> mask, Vector256<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<float> MaskLoadAligned(float* address, Vector256<float> mask, Vector256<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<uint> MaskLoadAligned(uint* address, Vector256<uint> mask, Vector256<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector256<ulong> MaskLoadAligned(ulong* address, Vector256<ulong> mask, Vector256<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(byte* address, Vector128<byte> mask, Vector128<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(double* address, Vector128<double> mask, Vector128<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(short* address, Vector128<short> mask, Vector128<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(int* address, Vector128<int> mask, Vector128<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(long* address, Vector128<long> mask, Vector128<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(float* address, Vector128<float> mask, Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(ushort* address, Vector128<ushort> mask, Vector128<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(uint* address, Vector128<uint> mask, Vector128<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(ulong* address, Vector128<ulong> mask, Vector128<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(byte* address, Vector256<byte> mask, Vector256<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(double* address, Vector256<double> mask, Vector256<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(short* address, Vector256<short> mask, Vector256<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(int* address, Vector256<int> mask, Vector256<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(long* address, Vector256<long> mask, Vector256<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(float* address, Vector256<float> mask, Vector256<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(ushort* address, Vector256<ushort> mask, Vector256<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(uint* address, Vector256<uint> mask, Vector256<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void MaskStore(ulong* address, Vector256<ulong> mask, Vector256<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(double* address, Vector128<double> mask, Vector128<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(int* address, Vector128<int> mask, Vector128<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(long* address, Vector128<long> mask, Vector128<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(float* address, Vector128<float> mask, Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(uint* address, Vector128<uint> mask, Vector128<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(ulong* address, Vector128<ulong> mask, Vector128<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(double* address, Vector256<double> mask, Vector256<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(int* address, Vector256<int> mask, Vector256<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(long* address, Vector256<long> mask, Vector256<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(float* address, Vector256<float> mask, Vector256<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(uint* address, Vector256<uint> mask, Vector256<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(ulong* address, Vector256<ulong> mask, Vector256<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Max(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Max(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> Max(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Max(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Min(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Min(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> Min(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Min(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyLow(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyLow(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> MultiplyLow(Vector256<long> left, Vector256<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> MultiplyLow(Vector256<ulong> left, Vector256<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> MultiplyScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MultiplyScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> MultiShift(Vector128<byte> control, Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> MultiShift(Vector128<sbyte> control, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> MultiShift(Vector256<byte> control, Vector256<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> MultiShift(Vector256<sbyte> control, Vector256<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> PermuteVar16x16(Vector256<short> left, Vector256<short> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> PermuteVar16x16(Vector256<ushort> left, Vector256<ushort> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> PermuteVar16x16x2(Vector256<short> lower, Vector256<short> indices, Vector256<short> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> PermuteVar16x16x2(Vector256<ushort> lower, Vector256<ushort> indices, Vector256<ushort> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> PermuteVar16x8(Vector128<byte> left, Vector128<byte> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> PermuteVar16x8(Vector128<sbyte> left, Vector128<sbyte> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> PermuteVar16x8x2(Vector128<byte> lower, Vector128<byte> indices, Vector128<byte> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> PermuteVar16x8x2(Vector128<sbyte> lower, Vector128<sbyte> indices, Vector128<sbyte> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> PermuteVar2x64x2(Vector128<double> lower, Vector128<long> indices, Vector128<double> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> PermuteVar2x64x2(Vector128<long> lower, Vector128<long> indices, Vector128<long> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> PermuteVar2x64x2(Vector128<ulong> lower, Vector128<ulong> indices, Vector128<ulong> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> PermuteVar32x8(Vector256<byte> left, Vector256<byte> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> PermuteVar32x8(Vector256<sbyte> left, Vector256<sbyte> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> PermuteVar32x8x2(Vector256<byte> lower, Vector256<byte> indices, Vector256<byte> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> PermuteVar32x8x2(Vector256<sbyte> lower, Vector256<sbyte> indices, Vector256<sbyte> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> PermuteVar4x32x2(Vector128<float> lower, Vector128<int> indices, Vector128<float> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> PermuteVar4x32x2(Vector128<int> lower, Vector128<int> indices, Vector128<int> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> PermuteVar4x32x2(Vector128<uint> lower, Vector128<uint> indices, Vector128<uint> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> PermuteVar4x64(Vector256<double> value, Vector256<long> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> PermuteVar4x64(Vector256<long> value, Vector256<long> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> PermuteVar4x64(Vector256<ulong> value, Vector256<ulong> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> PermuteVar4x64x2(Vector256<double> lower, Vector256<long> indices, Vector256<double> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> PermuteVar4x64x2(Vector256<long> lower, Vector256<long> indices, Vector256<long> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> PermuteVar4x64x2(Vector256<ulong> lower, Vector256<ulong> indices, Vector256<ulong> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> PermuteVar8x16(Vector128<short> left, Vector128<short> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> PermuteVar8x16(Vector128<ushort> left, Vector128<ushort> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> PermuteVar8x16x2(Vector128<short> lower, Vector128<short> indices, Vector128<short> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> PermuteVar8x16x2(Vector128<ushort> lower, Vector128<ushort> indices, Vector128<ushort> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> PermuteVar8x32x2(Vector256<float> lower, Vector256<int> indices, Vector256<float> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> PermuteVar8x32x2(Vector256<int> lower, Vector256<int> indices, Vector256<int> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> PermuteVar8x32x2(Vector256<uint> lower, Vector256<uint> indices, Vector256<uint> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Range(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Range(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Range(Vector256<double> left, Vector256<double> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Range(Vector256<float> left, Vector256<float> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> RangeScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RangeScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Reciprocal14(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Reciprocal14(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Reciprocal14(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Reciprocal14(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Reciprocal14Scalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Reciprocal14Scalar(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Reciprocal14Scalar(Vector128<float> upper, Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Reciprocal14Scalar(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ReciprocalSqrt14(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSqrt14(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> ReciprocalSqrt14(Vector256<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> ReciprocalSqrt14(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ReciprocalSqrt14Scalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ReciprocalSqrt14Scalar(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSqrt14Scalar(Vector128<float> upper, Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSqrt14Scalar(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Reduce(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Reduce(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Reduce(Vector256<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Reduce(Vector256<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ReduceScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ReduceScalar(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReduceScalar(Vector128<float> upper, Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReduceScalar(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> RotateLeft(Vector128<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> RotateLeft(Vector128<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> RotateLeft(Vector128<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> RotateLeft(Vector128<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> RotateLeft(Vector256<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> RotateLeft(Vector256<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> RotateLeft(Vector256<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> RotateLeft(Vector256<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> RotateLeftVariable(Vector128<int> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> RotateLeftVariable(Vector128<long> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> RotateLeftVariable(Vector128<uint> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> RotateLeftVariable(Vector128<ulong> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> RotateLeftVariable(Vector256<int> value, Vector256<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> RotateLeftVariable(Vector256<long> value, Vector256<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> RotateLeftVariable(Vector256<uint> value, Vector256<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> RotateLeftVariable(Vector256<ulong> value, Vector256<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> RotateRight(Vector128<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> RotateRight(Vector128<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> RotateRight(Vector128<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> RotateRight(Vector128<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> RotateRight(Vector256<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> RotateRight(Vector256<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> RotateRight(Vector256<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> RotateRight(Vector256<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> RotateRightVariable(Vector128<int> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> RotateRightVariable(Vector128<long> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> RotateRightVariable(Vector128<uint> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> RotateRightVariable(Vector128<ulong> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> RotateRightVariable(Vector256<int> value, Vector256<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> RotateRightVariable(Vector256<long> value, Vector256<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> RotateRightVariable(Vector256<uint> value, Vector256<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> RotateRightVariable(Vector256<ulong> value, Vector256<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> RoundScale(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundScale(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> RoundScale(Vector256<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> RoundScale(Vector256<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> RoundScaleScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> RoundScaleScalar(Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundScaleScalar(Vector128<float> upper, Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundScaleScalar(Vector128<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Scale(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Scale(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Scale(Vector256<double> left, Vector256<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Scale(Vector256<float> left, Vector256<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ScaleScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ScaleScalar(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ScaleScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ScaleScalar(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftLogicalVariable(Vector128<short> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogicalVariable(Vector128<ushort> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ShiftLeftLogicalVariable(Vector256<short> value, Vector256<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ShiftLeftLogicalVariable(Vector256<ushort> value, Vector256<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmetic(Vector128<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmetic(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ShiftRightArithmetic(Vector256<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ShiftRightArithmetic(Vector256<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmeticVariable(Vector128<long> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticVariable(Vector128<short> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ShiftRightArithmeticVariable(Vector256<long> value, Vector256<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ShiftRightArithmeticVariable(Vector256<short> value, Vector256<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalVariable(Vector128<short> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalVariable(Vector128<ushort> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ShiftRightLogicalVariable(Vector256<short> value, Vector256<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ShiftRightLogicalVariable(Vector256<ushort> value, Vector256<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> Shuffle2x128(Vector256<double> left, Vector256<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> Shuffle2x128(Vector256<float> left, Vector256<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> Shuffle2x128(Vector256<int> left, Vector256<int> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> Shuffle2x128(Vector256<long> left, Vector256<long> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> Shuffle2x128(Vector256<uint> left, Vector256<uint> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> Shuffle2x128(Vector256<ulong> left, Vector256<ulong> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> SqrtScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> SqrtScalar(Vector128<float> upper, Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> SubtractScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> SubtractScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SumAbsoluteDifferencesInBlock32(Vector128<byte> left, Vector128<byte> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> SumAbsoluteDifferencesInBlock32(Vector256<byte> left, Vector256<byte> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> TernaryLogic(Vector128<byte> a, Vector128<byte> b, Vector128<byte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> TernaryLogic(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> TernaryLogic(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> TernaryLogic(Vector128<int> a, Vector128<int> b, Vector128<int> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> TernaryLogic(Vector128<long> a, Vector128<long> b, Vector128<long> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> TernaryLogic(Vector128<sbyte> a, Vector128<sbyte> b, Vector128<sbyte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> TernaryLogic(Vector128<short> a, Vector128<short> b, Vector128<short> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> TernaryLogic(Vector128<uint> a, Vector128<uint> b, Vector128<uint> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> TernaryLogic(Vector128<ulong> a, Vector128<ulong> b, Vector128<ulong> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> TernaryLogic(Vector128<ushort> a, Vector128<ushort> b, Vector128<ushort> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> TernaryLogic(Vector256<byte> a, Vector256<byte> b, Vector256<byte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> TernaryLogic(Vector256<double> a, Vector256<double> b, Vector256<double> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> TernaryLogic(Vector256<float> a, Vector256<float> b, Vector256<float> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> TernaryLogic(Vector256<int> a, Vector256<int> b, Vector256<int> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> TernaryLogic(Vector256<long> a, Vector256<long> b, Vector256<long> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> TernaryLogic(Vector256<sbyte> a, Vector256<sbyte> b, Vector256<sbyte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> TernaryLogic(Vector256<short> a, Vector256<short> b, Vector256<short> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> TernaryLogic(Vector256<uint> a, Vector256<uint> b, Vector256<uint> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> TernaryLogic(Vector256<ulong> a, Vector256<ulong> b, Vector256<ulong> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> TernaryLogic(Vector256<ushort> a, Vector256<ushort> b, Vector256<ushort> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}
}
