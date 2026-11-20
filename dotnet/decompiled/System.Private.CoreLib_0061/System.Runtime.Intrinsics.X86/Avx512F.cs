using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Avx512F : Avx2
{
	public abstract class VL
	{
		public static bool IsSupported
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

		public static Vector128<double> BlendVariable(Vector128<double> left, Vector128<double> right, Vector128<double> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> BlendVariable(Vector128<int> left, Vector128<int> right, Vector128<int> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> BlendVariable(Vector128<long> left, Vector128<long> right, Vector128<long> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> BlendVariable(Vector128<float> left, Vector128<float> right, Vector128<float> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> BlendVariable(Vector128<uint> left, Vector128<uint> right, Vector128<uint> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> BlendVariable(Vector128<ulong> left, Vector128<ulong> right, Vector128<ulong> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> BlendVariable(Vector256<double> left, Vector256<double> right, Vector256<double> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<int> BlendVariable(Vector256<int> left, Vector256<int> right, Vector256<int> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> BlendVariable(Vector256<long> left, Vector256<long> right, Vector256<long> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> BlendVariable(Vector256<float> left, Vector256<float> right, Vector256<float> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<uint> BlendVariable(Vector256<uint> left, Vector256<uint> right, Vector256<uint> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ulong> BlendVariable(Vector256<ulong> left, Vector256<ulong> right, Vector256<ulong> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Compare(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareGreaterThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareLessThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareLessThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareNotEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareNotGreaterThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareNotGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareNotLessThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareNotLessThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareOrdered(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareUnordered(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> Compare(Vector256<double> left, Vector256<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareGreaterThan(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareGreaterThanOrEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareLessThan(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareLessThanOrEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareNotEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareNotGreaterThan(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareNotGreaterThanOrEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareNotLessThan(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareNotLessThanOrEqual(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareOrdered(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> CompareUnordered(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> CompareEqual(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> CompareGreaterThan(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> CompareGreaterThanOrEqual(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> CompareLessThan(Vector128<int> left, Vector128<int> right)
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

		public static Vector256<int> CompareEqual(Vector256<int> left, Vector256<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<int> CompareGreaterThan(Vector256<int> left, Vector256<int> right)
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

		public static Vector128<long> CompareEqual(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareGreaterThan(Vector128<long> left, Vector128<long> right)
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

		public static Vector256<long> CompareEqual(Vector256<long> left, Vector256<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> CompareGreaterThan(Vector256<long> left, Vector256<long> right)
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

		public static Vector128<float> Compare(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareGreaterThan(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareLessThan(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareLessThanOrEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareNotEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareNotGreaterThan(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareNotGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareNotLessThan(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareNotLessThanOrEqual(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareOrdered(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> CompareUnordered(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> Compare(Vector256<float> left, Vector256<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareGreaterThan(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareGreaterThanOrEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareLessThan(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareLessThanOrEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareNotEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareNotGreaterThan(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareNotGreaterThanOrEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareNotLessThan(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareNotLessThanOrEqual(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareOrdered(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> CompareUnordered(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> CompareEqual(Vector128<uint> left, Vector128<uint> right)
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

		public static Vector256<uint> CompareEqual(Vector256<uint> left, Vector256<uint> right)
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

		public static Vector128<ulong> CompareEqual(Vector128<ulong> left, Vector128<ulong> right)
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

		public static Vector256<ulong> CompareEqual(Vector256<ulong> left, Vector256<ulong> right)
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

		public static Vector128<double> Compress(Vector128<double> merge, Vector128<double> mask, Vector128<double> value)
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

		public static Vector128<float> Compress(Vector128<float> merge, Vector128<float> mask, Vector128<float> value)
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

		public static Vector256<double> Compress(Vector256<double> merge, Vector256<double> mask, Vector256<double> value)
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

		public static Vector256<float> Compress(Vector256<float> merge, Vector256<float> mask, Vector256<float> value)
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

		public unsafe static void CompressStore(double* address, Vector128<double> mask, Vector128<double> source)
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

		public unsafe static void CompressStore(float* address, Vector128<float> mask, Vector128<float> source)
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

		public unsafe static void CompressStore(double* address, Vector256<double> mask, Vector256<double> source)
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

		public unsafe static void CompressStore(float* address, Vector256<float> mask, Vector256<float> source)
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

		public static Vector128<byte> ConvertToVector128Byte(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128Byte(Vector128<long> value)
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

		public static Vector128<byte> ConvertToVector128Byte(Vector256<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128Byte(Vector256<long> value)
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

		public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<ulong> value)
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

		public static Vector128<double> ConvertToVector128Double(Vector128<uint> value)
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

		public static Vector128<sbyte> ConvertToVector128SByte(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector128<long> value)
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

		public static Vector128<sbyte> ConvertToVector128SByte(Vector256<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector256<long> value)
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

		public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<long> value)
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

		public static Vector128<float> ConvertToVector128Single(Vector128<uint> value)
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

		public static Vector128<uint> ConvertToVector128UInt32(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ConvertToVector128UInt32(Vector128<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ConvertToVector128UInt32(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ConvertToVector128UInt32(Vector128<double> value)
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

		public static Vector128<uint> ConvertToVector128UInt32(Vector256<double> value)
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

		public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ConvertToVector128UInt32WithTruncation(Vector256<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> ConvertToVector256Double(Vector128<uint> value)
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

		public static Vector128<double> Expand(Vector128<double> merge, Vector128<double> mask, Vector128<double> value)
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

		public static Vector128<float> Expand(Vector128<float> merge, Vector128<float> mask, Vector128<float> value)
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

		public static Vector256<double> Expand(Vector256<double> merge, Vector256<double> mask, Vector256<double> value)
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

		public static Vector256<float> Expand(Vector256<float> merge, Vector256<float> mask, Vector256<float> value)
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

		public unsafe static Vector128<double> ExpandLoad(double* address, Vector128<double> mask, Vector128<double> merge)
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

		public unsafe static Vector128<float> ExpandLoad(float* address, Vector128<float> mask, Vector128<float> merge)
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

		public unsafe static Vector256<double> ExpandLoad(double* address, Vector256<double> mask, Vector256<double> merge)
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

		public unsafe static Vector256<float> ExpandLoad(float* address, Vector256<float> mask, Vector256<float> merge)
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

		public static Vector128<float> Fixup(Vector128<float> left, Vector128<float> right, Vector128<int> table, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Fixup(Vector128<double> left, Vector128<double> right, Vector128<long> table, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> Fixup(Vector256<float> left, Vector256<float> right, Vector256<int> table, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> Fixup(Vector256<double> left, Vector256<double> right, Vector256<long> table, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> GetExponent(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> GetExponent(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> GetExponent(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> GetExponent(Vector256<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> GetMantissa(Vector128<float> value, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> GetMantissa(Vector128<double> value, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> GetMantissa(Vector256<float> value, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> GetMantissa(Vector256<double> value, [ConstantExpected(Max = 15)] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<double> MaskLoad(double* address, Vector128<double> mask, Vector128<double> merge)
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

		public unsafe static Vector128<float> MaskLoad(float* address, Vector128<float> mask, Vector128<float> merge)
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

		public unsafe static Vector256<double> MaskLoad(double* address, Vector256<double> mask, Vector256<double> merge)
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

		public unsafe static Vector256<float> MaskLoad(float* address, Vector256<float> mask, Vector256<float> merge)
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

		public unsafe static void MaskStore(double* address, Vector128<double> mask, Vector128<double> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(int* address, Vector128<int> mask, Vector128<int> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(long* address, Vector128<long> mask, Vector128<long> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(float* address, Vector128<float> mask, Vector128<float> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(uint* address, Vector128<uint> mask, Vector128<uint> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(ulong* address, Vector128<ulong> mask, Vector128<ulong> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(double* address, Vector256<double> mask, Vector256<double> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(int* address, Vector256<int> mask, Vector256<int> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(long* address, Vector256<long> mask, Vector256<long> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(float* address, Vector256<float> mask, Vector256<float> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(uint* address, Vector256<uint> mask, Vector256<uint> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(ulong* address, Vector256<ulong> mask, Vector256<ulong> source)
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

		public static Vector128<long> PermuteVar2x64x2(Vector128<long> lower, Vector128<long> indices, Vector128<long> upper)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> PermuteVar2x64x2(Vector128<ulong> lower, Vector128<ulong> indices, Vector128<ulong> upper)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> PermuteVar2x64x2(Vector128<double> lower, Vector128<long> indices, Vector128<double> upper)
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

		public static Vector128<float> PermuteVar4x32x2(Vector128<float> lower, Vector128<int> indices, Vector128<float> upper)
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

		public static Vector256<double> PermuteVar4x64(Vector256<double> value, Vector256<long> control)
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

		public static Vector256<double> PermuteVar4x64x2(Vector256<double> lower, Vector256<long> indices, Vector256<double> upper)
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

		public static Vector256<float> PermuteVar8x32x2(Vector256<float> lower, Vector256<int> indices, Vector256<float> upper)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> Reciprocal14(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Reciprocal14(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> Reciprocal14(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> Reciprocal14(Vector256<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ReciprocalSqrt14(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ReciprocalSqrt14(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> ReciprocalSqrt14(Vector256<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> ReciprocalSqrt14(Vector256<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> RotateLeft(Vector128<int> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> RotateLeft(Vector128<uint> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> RotateLeft(Vector128<long> value, [ConstantExpected] byte count)
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

		public static Vector256<uint> RotateLeft(Vector256<uint> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> RotateLeft(Vector256<long> value, [ConstantExpected] byte count)
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

		public static Vector128<uint> RotateLeftVariable(Vector128<uint> value, Vector128<uint> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> RotateLeftVariable(Vector128<long> value, Vector128<ulong> count)
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

		public static Vector256<uint> RotateLeftVariable(Vector256<uint> value, Vector256<uint> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> RotateLeftVariable(Vector256<long> value, Vector256<ulong> count)
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

		public static Vector128<uint> RotateRight(Vector128<uint> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> RotateRight(Vector128<long> value, [ConstantExpected] byte count)
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

		public static Vector256<uint> RotateRight(Vector256<uint> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> RotateRight(Vector256<long> value, [ConstantExpected] byte count)
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

		public static Vector128<uint> RotateRightVariable(Vector128<uint> value, Vector128<uint> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> RotateRightVariable(Vector128<long> value, Vector128<ulong> count)
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

		public static Vector256<uint> RotateRightVariable(Vector256<uint> value, Vector256<uint> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> RotateRightVariable(Vector256<long> value, Vector256<ulong> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ulong> RotateRightVariable(Vector256<ulong> value, Vector256<ulong> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> RoundScale(Vector128<float> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundScale(Vector128<double> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> RoundScale(Vector256<float> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> RoundScale(Vector256<double> value, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> Scale(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Scale(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> Scale(Vector256<float> left, Vector256<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> Scale(Vector256<double> left, Vector256<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ShiftRightArithmetic(Vector128<long> value, Vector128<long> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> ShiftRightArithmetic(Vector256<long> value, Vector128<long> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ShiftRightArithmetic(Vector128<long> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> ShiftRightArithmetic(Vector256<long> value, [ConstantExpected] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ShiftRightArithmeticVariable(Vector128<long> value, Vector128<ulong> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> ShiftRightArithmeticVariable(Vector256<long> value, Vector256<ulong> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> Shuffle2x128(Vector256<double> left, Vector256<double> right, [ConstantExpected] byte control)
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

		public static Vector256<float> Shuffle2x128(Vector256<float> left, Vector256<float> right, [ConstantExpected] byte control)
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

		public static Vector128<sbyte> TernaryLogic(Vector128<sbyte> a, Vector128<sbyte> b, Vector128<sbyte> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> TernaryLogic(Vector128<byte> a, Vector128<byte> b, Vector128<byte> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> TernaryLogic(Vector128<short> a, Vector128<short> b, Vector128<short> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> TernaryLogic(Vector128<ushort> a, Vector128<ushort> b, Vector128<ushort> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> TernaryLogic(Vector128<int> a, Vector128<int> b, Vector128<int> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> TernaryLogic(Vector128<uint> a, Vector128<uint> b, Vector128<uint> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> TernaryLogic(Vector128<long> a, Vector128<long> b, Vector128<long> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> TernaryLogic(Vector128<ulong> a, Vector128<ulong> b, Vector128<ulong> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> TernaryLogic(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> TernaryLogic(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<sbyte> TernaryLogic(Vector256<sbyte> a, Vector256<sbyte> b, Vector256<sbyte> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<byte> TernaryLogic(Vector256<byte> a, Vector256<byte> b, Vector256<byte> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<short> TernaryLogic(Vector256<short> a, Vector256<short> b, Vector256<short> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ushort> TernaryLogic(Vector256<ushort> a, Vector256<ushort> b, Vector256<ushort> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<int> TernaryLogic(Vector256<int> a, Vector256<int> b, Vector256<int> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<uint> TernaryLogic(Vector256<uint> a, Vector256<uint> b, Vector256<uint> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<long> TernaryLogic(Vector256<long> a, Vector256<long> b, Vector256<long> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ulong> TernaryLogic(Vector256<ulong> a, Vector256<ulong> b, Vector256<ulong> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<float> TernaryLogic(Vector256<float> a, Vector256<float> b, Vector256<float> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<double> TernaryLogic(Vector256<double> a, Vector256<double> b, Vector256<double> c, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}
	}

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

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static Vector512<uint> Abs(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Abs(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Add(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Add(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Add(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Add(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Add(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Add(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Add(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Add(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
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

	public static Vector512<int> AlignRight32(Vector512<int> left, Vector512<int> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> AlignRight32(Vector512<uint> left, Vector512<uint> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> AlignRight64(Vector512<long> left, Vector512<long> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> AlignRight64(Vector512<ulong> left, Vector512<ulong> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> And(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> And(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> And(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> And(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> And(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> And(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> And(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> And(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> AndNot(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> AndNot(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> AndNot(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> AndNot(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> AndNot(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> AndNot(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> AndNot(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> AndNot(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> BlendVariable(Vector512<double> left, Vector512<double> right, Vector512<double> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> BlendVariable(Vector512<int> left, Vector512<int> right, Vector512<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> BlendVariable(Vector512<long> left, Vector512<long> right, Vector512<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> BlendVariable(Vector512<float> left, Vector512<float> right, Vector512<float> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> BlendVariable(Vector512<uint> left, Vector512<uint> right, Vector512<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> BlendVariable(Vector512<ulong> left, Vector512<ulong> right, Vector512<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> BroadcastScalarToVector512(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> BroadcastScalarToVector512(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> BroadcastScalarToVector512(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> BroadcastScalarToVector512(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> BroadcastScalarToVector512(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> BroadcastScalarToVector512(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> BroadcastVector128ToVector512(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> BroadcastVector128ToVector512(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> BroadcastVector128ToVector512(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> BroadcastVector256ToVector512(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> BroadcastVector256ToVector512(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> BroadcastVector256ToVector512(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Compare(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareGreaterThan(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareGreaterThanOrEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareLessThan(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareLessThanOrEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareNotEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareNotGreaterThan(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareNotGreaterThanOrEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareNotLessThan(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareNotLessThanOrEqual(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareOrdered(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> CompareUnordered(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Compare(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareGreaterThan(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareGreaterThanOrEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareLessThan(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareLessThanOrEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareNotEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareNotGreaterThan(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareNotGreaterThanOrEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareNotLessThan(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareNotLessThanOrEqual(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareOrdered(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> CompareUnordered(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareEqual(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareGreaterThan(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareGreaterThanOrEqual(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareLessThan(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareLessThanOrEqual(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> CompareNotEqual(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareEqual(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareGreaterThan(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareGreaterThanOrEqual(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareLessThan(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareLessThanOrEqual(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> CompareNotEqual(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareEqual(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareGreaterThan(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareGreaterThanOrEqual(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareLessThan(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareLessThanOrEqual(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> CompareNotEqual(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareEqual(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareGreaterThan(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareGreaterThanOrEqual(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareLessThan(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareLessThanOrEqual(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> CompareNotEqual(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Compress(Vector512<double> merge, Vector512<double> mask, Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Compress(Vector512<int> merge, Vector512<int> mask, Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Compress(Vector512<long> merge, Vector512<long> mask, Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Compress(Vector512<float> merge, Vector512<float> mask, Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Compress(Vector512<uint> merge, Vector512<uint> mask, Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Compress(Vector512<ulong> merge, Vector512<ulong> mask, Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(double* address, Vector512<double> mask, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(int* address, Vector512<int> mask, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(long* address, Vector512<long> mask, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(float* address, Vector512<float> mask, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(uint* address, Vector512<uint> mask, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void CompressStore(ulong* address, Vector512<ulong> mask, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, uint value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		return ConvertScalarToVector128Single(upper, value, mode);
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, int value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertScalarToVector128Single(Vector128<float> upper, Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ConvertScalarToVector128Double(Vector128<double> upper, uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConvertToInt32(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConvertToInt32(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32(Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32WithTruncation(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConvertToUInt32WithTruncation(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128Byte(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ConvertToVector128Int16WithSaturation(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByte(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ConvertToVector128UInt16WithSaturation(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ConvertToVector256Int16(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ConvertToVector256Int16(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ConvertToVector256Int16WithSaturation(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32WithSaturation(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ConvertToVector256Int32WithTruncation(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> ConvertToVector256Single(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> ConvertToVector256Single(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ConvertToVector256UInt16(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ConvertToVector256UInt16(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ConvertToVector256UInt16WithSaturation(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32(Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32WithSaturation(Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ConvertToVector256UInt32WithTruncation(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> ConvertToVector512Double(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> ConvertToVector512Double(Vector256<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> ConvertToVector512Double(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> ConvertToVector512Single(Vector512<int> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> ConvertToVector512Single(Vector512<uint> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32(Vector512<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ConvertToVector512Int32WithTruncation(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ConvertToVector512Int64(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> ConvertToVector512Single(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> ConvertToVector512Single(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32(Vector512<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ConvertToVector512UInt32WithTruncation(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector256<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ConvertToVector512UInt64(Vector256<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Divide(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Divide(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Divide(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Divide(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
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

	public static Vector512<float> DuplicateEvenIndexed(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> DuplicateEvenIndexed(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> DuplicateOddIndexed(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Expand(Vector512<double> merge, Vector512<double> mask, Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Expand(Vector512<int> merge, Vector512<int> mask, Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Expand(Vector512<long> merge, Vector512<long> mask, Vector512<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Expand(Vector512<float> merge, Vector512<float> mask, Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Expand(Vector512<uint> merge, Vector512<uint> mask, Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Expand(Vector512<ulong> merge, Vector512<ulong> mask, Vector512<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> ExpandLoad(double* address, Vector512<double> mask, Vector512<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> ExpandLoad(int* address, Vector512<int> mask, Vector512<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> ExpandLoad(long* address, Vector512<long> mask, Vector512<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> ExpandLoad(float* address, Vector512<float> mask, Vector512<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> ExpandLoad(uint* address, Vector512<uint> mask, Vector512<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> ExpandLoad(ulong* address, Vector512<ulong> mask, Vector512<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ExtractVector128(Vector512<sbyte> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ExtractVector128(Vector512<byte> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ExtractVector128(Vector512<short> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ExtractVector128(Vector512<ushort> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ExtractVector128(Vector512<int> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ExtractVector128(Vector512<uint> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ExtractVector128(Vector512<long> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ExtractVector128(Vector512<ulong> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ExtractVector128(Vector512<float> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ExtractVector128(Vector512<double> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> ExtractVector256(Vector512<sbyte> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> ExtractVector256(Vector512<byte> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<short> ExtractVector256(Vector512<short> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ushort> ExtractVector256(Vector512<ushort> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<int> ExtractVector256(Vector512<int> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<uint> ExtractVector256(Vector512<uint> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<long> ExtractVector256(Vector512<long> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<ulong> ExtractVector256(Vector512<ulong> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<float> ExtractVector256(Vector512<float> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<double> ExtractVector256(Vector512<double> value, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Fixup(Vector512<float> left, Vector512<float> right, Vector512<int> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Fixup(Vector512<double> left, Vector512<double> right, Vector512<long> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FixupScalar(Vector128<float> left, Vector128<float> right, Vector128<int> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FixupScalar(Vector128<double> left, Vector128<double> right, Vector128<long> table, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAdd(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAdd(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAdd(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAdd(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplyAddScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplyAddScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAddSubtract(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAddSubtract(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAddSubtract(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAddSubtract(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtract(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtract(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtract(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtract(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplySubtractScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplySubtractScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtractAdd(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtractAdd(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtractAdd(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtractAdd(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAddNegated(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplyAddNegated(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAddNegated(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplyAddNegated(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplyAddNegatedScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplyAddNegatedScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtractNegated(Vector512<float> a, Vector512<float> b, Vector512<float> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> FusedMultiplySubtractNegated(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtractNegated(Vector512<double> a, Vector512<double> b, Vector512<double> c)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> FusedMultiplySubtractNegated(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplySubtractNegatedScalar(Vector128<float> a, Vector128<float> b, Vector128<float> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> FusedMultiplySubtractNegatedScalar(Vector128<double> a, Vector128<double> b, Vector128<double> c, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> GetExponent(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> GetExponent(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetExponentScalar(Vector128<float> value)
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

	public static Vector128<double> GetExponentScalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> GetMantissa(Vector512<float> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> GetMantissa(Vector512<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> GetMantissaScalar(Vector128<float> value, [ConstantExpected(Max = 15)] byte control)
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

	public static Vector128<double> GetMantissaScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected(Max = 15)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> InsertVector128(Vector512<sbyte> value, Vector128<sbyte> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> InsertVector128(Vector512<byte> value, Vector128<byte> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> InsertVector128(Vector512<short> value, Vector128<short> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> InsertVector128(Vector512<ushort> value, Vector128<ushort> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> InsertVector128(Vector512<int> value, Vector128<int> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> InsertVector128(Vector512<uint> value, Vector128<uint> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> InsertVector128(Vector512<long> value, Vector128<long> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> InsertVector128(Vector512<ulong> value, Vector128<ulong> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> InsertVector128(Vector512<float> value, Vector128<float> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> InsertVector128(Vector512<double> value, Vector128<double> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> InsertVector256(Vector512<sbyte> value, Vector256<sbyte> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> InsertVector256(Vector512<byte> value, Vector256<byte> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> InsertVector256(Vector512<short> value, Vector256<short> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> InsertVector256(Vector512<ushort> value, Vector256<ushort> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> InsertVector256(Vector512<int> value, Vector256<int> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> InsertVector256(Vector512<uint> value, Vector256<uint> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> InsertVector256(Vector512<long> value, Vector256<long> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> InsertVector256(Vector512<ulong> value, Vector256<ulong> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> InsertVector256(Vector512<float> value, Vector256<float> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> InsertVector256(Vector512<double> value, Vector256<double> data, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<byte> LoadAlignedVector512(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<sbyte> LoadAlignedVector512(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<short> LoadAlignedVector512(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ushort> LoadAlignedVector512(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> LoadAlignedVector512(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> LoadAlignedVector512(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> LoadAlignedVector512(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> LoadAlignedVector512(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> LoadAlignedVector512(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> LoadAlignedVector512(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<sbyte> LoadAlignedVector512NonTemporal(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<byte> LoadAlignedVector512NonTemporal(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<short> LoadAlignedVector512NonTemporal(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ushort> LoadAlignedVector512NonTemporal(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> LoadAlignedVector512NonTemporal(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> LoadAlignedVector512NonTemporal(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> LoadAlignedVector512NonTemporal(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> LoadAlignedVector512NonTemporal(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<sbyte> LoadVector512(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<byte> LoadVector512(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<short> LoadVector512(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ushort> LoadVector512(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> LoadVector512(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> LoadVector512(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> LoadVector512(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> LoadVector512(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> LoadVector512(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> LoadVector512(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> MaskLoad(double* address, Vector512<double> mask, Vector512<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> MaskLoad(int* address, Vector512<int> mask, Vector512<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> MaskLoad(long* address, Vector512<long> mask, Vector512<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> MaskLoad(float* address, Vector512<float> mask, Vector512<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> MaskLoad(uint* address, Vector512<uint> mask, Vector512<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> MaskLoad(ulong* address, Vector512<ulong> mask, Vector512<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<double> MaskLoadAligned(double* address, Vector512<double> mask, Vector512<double> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<int> MaskLoadAligned(int* address, Vector512<int> mask, Vector512<int> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<long> MaskLoadAligned(long* address, Vector512<long> mask, Vector512<long> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<float> MaskLoadAligned(float* address, Vector512<float> mask, Vector512<float> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<uint> MaskLoadAligned(uint* address, Vector512<uint> mask, Vector512<uint> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ulong> MaskLoadAligned(ulong* address, Vector512<ulong> mask, Vector512<ulong> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(double* address, Vector512<double> mask, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(int* address, Vector512<int> mask, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(long* address, Vector512<long> mask, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(float* address, Vector512<float> mask, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(uint* address, Vector512<uint> mask, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(ulong* address, Vector512<ulong> mask, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(double* address, Vector512<double> mask, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(int* address, Vector512<int> mask, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(long* address, Vector512<long> mask, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(float* address, Vector512<float> mask, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(uint* address, Vector512<uint> mask, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStoreAligned(ulong* address, Vector512<ulong> mask, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Max(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Max(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Max(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Max(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Max(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Max(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Min(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Min(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Min(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Min(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Min(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Min(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector256<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector512<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector512<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Multiply(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Multiply(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Multiply(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Multiply(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Multiply(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Multiply(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MultiplyScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> MultiplyScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> MultiplyLow(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> MultiplyLow(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Or(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Or(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Or(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Or(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Or(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Or(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Or(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Or(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Permute2x64(Vector512<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Permute4x32(Vector512<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Permute4x64(Vector512<long> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Permute4x64(Vector512<ulong> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Permute4x64(Vector512<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> PermuteVar2x64(Vector512<double> left, Vector512<long> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> PermuteVar4x32(Vector512<float> left, Vector512<int> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> PermuteVar8x64(Vector512<long> value, Vector512<long> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> PermuteVar8x64(Vector512<ulong> value, Vector512<ulong> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> PermuteVar8x64(Vector512<double> value, Vector512<long> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> PermuteVar8x64x2(Vector512<long> lower, Vector512<long> indices, Vector512<long> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> PermuteVar8x64x2(Vector512<ulong> lower, Vector512<ulong> indices, Vector512<ulong> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> PermuteVar8x64x2(Vector512<double> lower, Vector512<long> indices, Vector512<double> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> PermuteVar16x32(Vector512<int> left, Vector512<int> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> PermuteVar16x32(Vector512<uint> left, Vector512<uint> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> PermuteVar16x32(Vector512<float> left, Vector512<int> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> PermuteVar16x32x2(Vector512<int> lower, Vector512<int> indices, Vector512<int> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> PermuteVar16x32x2(Vector512<uint> lower, Vector512<uint> indices, Vector512<uint> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> PermuteVar16x32x2(Vector512<float> lower, Vector512<int> indices, Vector512<float> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Reciprocal14(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Reciprocal14(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Reciprocal14Scalar(Vector128<float> value)
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

	public static Vector128<double> Reciprocal14Scalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> ReciprocalSqrt14(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> ReciprocalSqrt14(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSqrt14Scalar(Vector128<float> value)
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

	public static Vector128<double> ReciprocalSqrt14Scalar(Vector128<double> upper, Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> RotateLeft(Vector512<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> RotateLeft(Vector512<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> RotateLeft(Vector512<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> RotateLeft(Vector512<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> RotateLeftVariable(Vector512<int> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> RotateLeftVariable(Vector512<uint> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> RotateLeftVariable(Vector512<long> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> RotateLeftVariable(Vector512<ulong> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> RotateRight(Vector512<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> RotateRight(Vector512<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> RotateRight(Vector512<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> RotateRight(Vector512<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> RotateRightVariable(Vector512<int> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> RotateRightVariable(Vector512<uint> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> RotateRightVariable(Vector512<long> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> RotateRightVariable(Vector512<ulong> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> RoundScale(Vector512<float> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> RoundScale(Vector512<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundScaleScalar(Vector128<float> value, [ConstantExpected] byte control)
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

	public static Vector128<double> RoundScaleScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Scale(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Scale(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Scale(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Scale(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ScaleScalar(Vector128<float> left, Vector128<float> right)
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

	public static Vector128<double> ScaleScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftLeftLogical(Vector512<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftLeftLogical(Vector512<uint> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftLeftLogical(Vector512<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftLeftLogical(Vector512<ulong> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftLeftLogical(Vector512<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftLeftLogical(Vector512<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftLeftLogical(Vector512<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftLeftLogical(Vector512<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftLeftLogicalVariable(Vector512<int> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftLeftLogicalVariable(Vector512<uint> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftLeftLogicalVariable(Vector512<long> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftLeftLogicalVariable(Vector512<ulong> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightArithmetic(Vector512<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightArithmetic(Vector512<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightArithmetic(Vector512<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightArithmetic(Vector512<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightArithmeticVariable(Vector512<int> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightArithmeticVariable(Vector512<long> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightLogical(Vector512<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftRightLogical(Vector512<uint> value, Vector128<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightLogical(Vector512<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftRightLogical(Vector512<ulong> value, Vector128<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightLogical(Vector512<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftRightLogical(Vector512<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightLogical(Vector512<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftRightLogical(Vector512<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> ShiftRightLogicalVariable(Vector512<int> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> ShiftRightLogicalVariable(Vector512<uint> value, Vector512<uint> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> ShiftRightLogicalVariable(Vector512<long> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> ShiftRightLogicalVariable(Vector512<ulong> value, Vector512<ulong> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Shuffle(Vector512<int> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Shuffle(Vector512<uint> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Shuffle(Vector512<float> value, Vector512<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Shuffle(Vector512<double> value, Vector512<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Shuffle4x128(Vector512<double> left, Vector512<double> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Shuffle4x128(Vector512<int> left, Vector512<int> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Shuffle4x128(Vector512<long> left, Vector512<long> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Shuffle4x128(Vector512<float> left, Vector512<float> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Shuffle4x128(Vector512<uint> left, Vector512<uint> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Shuffle4x128(Vector512<ulong> left, Vector512<ulong> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Sqrt(Vector512<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Sqrt(Vector512<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Sqrt(Vector512<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Sqrt(Vector512<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> SqrtScalar(Vector128<float> upper, Vector128<float> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> SqrtScalar(Vector128<double> upper, Vector128<double> value, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(sbyte* address, Vector512<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(byte* address, Vector512<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(short* address, Vector512<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ushort* address, Vector512<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(int* address, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(uint* address, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(long* address, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ulong* address, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(float* address, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(double* address, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(byte* address, Vector512<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(sbyte* address, Vector512<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(short* address, Vector512<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(ushort* address, Vector512<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(int* address, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(uint* address, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(long* address, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(ulong* address, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(float* address, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAligned(double* address, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(sbyte* address, Vector512<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(byte* address, Vector512<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(short* address, Vector512<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(ushort* address, Vector512<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(int* address, Vector512<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(uint* address, Vector512<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(long* address, Vector512<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(ulong* address, Vector512<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(float* address, Vector512<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAlignedNonTemporal(double* address, Vector512<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Subtract(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Subtract(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Subtract(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Subtract(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Subtract(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Subtract(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> Subtract(Vector512<float> left, Vector512<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> Subtract(Vector512<double> left, Vector512<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> SubtractScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> SubtractScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatRoundingMode.ToZero)] FloatRoundingMode mode)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> TernaryLogic(Vector512<sbyte> a, Vector512<sbyte> b, Vector512<sbyte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> TernaryLogic(Vector512<byte> a, Vector512<byte> b, Vector512<byte> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> TernaryLogic(Vector512<short> a, Vector512<short> b, Vector512<short> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> TernaryLogic(Vector512<ushort> a, Vector512<ushort> b, Vector512<ushort> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> TernaryLogic(Vector512<int> a, Vector512<int> b, Vector512<int> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> TernaryLogic(Vector512<uint> a, Vector512<uint> b, Vector512<uint> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> TernaryLogic(Vector512<long> a, Vector512<long> b, Vector512<long> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> TernaryLogic(Vector512<ulong> a, Vector512<ulong> b, Vector512<ulong> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> TernaryLogic(Vector512<float> a, Vector512<float> b, Vector512<float> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> TernaryLogic(Vector512<double> a, Vector512<double> b, Vector512<double> c, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> UnpackHigh(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> UnpackHigh(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> UnpackHigh(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> UnpackHigh(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> UnpackHigh(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> UnpackHigh(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> UnpackLow(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> UnpackLow(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> UnpackLow(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> UnpackLow(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<float> UnpackLow(Vector512<float> left, Vector512<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<double> UnpackLow(Vector512<double> left, Vector512<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Xor(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Xor(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Xor(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Xor(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> Xor(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<uint> Xor(Vector512<uint> left, Vector512<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<long> Xor(Vector512<long> left, Vector512<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ulong> Xor(Vector512<ulong> left, Vector512<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}
}
