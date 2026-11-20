using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Avx512BW : Avx512F
{
	public new abstract class VL : Avx512F.VL
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector128<byte> BlendVariable(Vector128<byte> left, Vector128<byte> right, Vector128<byte> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> BlendVariable(Vector128<short> left, Vector128<short> right, Vector128<short> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> BlendVariable(Vector128<sbyte> left, Vector128<sbyte> right, Vector128<sbyte> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> BlendVariable(Vector128<ushort> left, Vector128<ushort> right, Vector128<ushort> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<byte> BlendVariable(Vector256<byte> left, Vector256<byte> right, Vector256<byte> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<short> BlendVariable(Vector256<short> left, Vector256<short> right, Vector256<short> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<sbyte> BlendVariable(Vector256<sbyte> left, Vector256<sbyte> right, Vector256<sbyte> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ushort> BlendVariable(Vector256<ushort> left, Vector256<ushort> right, Vector256<ushort> mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> CompareEqual(Vector128<byte> left, Vector128<byte> right)
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

		public static Vector256<byte> CompareEqual(Vector256<byte> left, Vector256<byte> right)
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

		public static Vector128<short> CompareEqual(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> CompareGreaterThan(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> CompareGreaterThanOrEqual(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> CompareLessThan(Vector128<short> left, Vector128<short> right)
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

		public static Vector256<short> CompareEqual(Vector256<short> left, Vector256<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<short> CompareGreaterThan(Vector256<short> left, Vector256<short> right)
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

		public static Vector128<sbyte> CompareEqual(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> CompareGreaterThan(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> CompareGreaterThanOrEqual(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> CompareLessThan(Vector128<sbyte> left, Vector128<sbyte> right)
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

		public static Vector256<sbyte> CompareEqual(Vector256<sbyte> left, Vector256<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<sbyte> CompareGreaterThan(Vector256<sbyte> left, Vector256<sbyte> right)
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

		public static Vector128<ushort> CompareEqual(Vector128<ushort> left, Vector128<ushort> right)
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

		public static Vector256<ushort> CompareEqual(Vector256<ushort> left, Vector256<ushort> right)
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

		public static Vector128<byte> ConvertToVector128Byte(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128Byte(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128Byte(Vector256<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128Byte(Vector256<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ConvertToVector128ByteWithSaturation(Vector256<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector256<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByte(Vector256<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ConvertToVector128SByteWithSaturation(Vector256<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<byte> MaskLoad(byte* address, Vector128<byte> mask, Vector128<byte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<short> MaskLoad(short* address, Vector128<short> mask, Vector128<short> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<sbyte> MaskLoad(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<ushort> MaskLoad(ushort* address, Vector128<ushort> mask, Vector128<ushort> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector256<byte> MaskLoad(byte* address, Vector256<byte> mask, Vector256<byte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector256<short> MaskLoad(short* address, Vector256<short> mask, Vector256<short> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector256<sbyte> MaskLoad(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector256<ushort> MaskLoad(ushort* address, Vector256<ushort> mask, Vector256<ushort> merge)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(byte* address, Vector128<byte> mask, Vector128<byte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(short* address, Vector128<short> mask, Vector128<short> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(sbyte* address, Vector128<sbyte> mask, Vector128<sbyte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(ushort* address, Vector128<ushort> mask, Vector128<ushort> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(byte* address, Vector256<byte> mask, Vector256<byte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(short* address, Vector256<short> mask, Vector256<short> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(sbyte* address, Vector256<sbyte> mask, Vector256<sbyte> source)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void MaskStore(ushort* address, Vector256<ushort> mask, Vector256<ushort> source)
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

		public static Vector128<short> ShiftRightArithmeticVariable(Vector128<short> value, Vector128<ushort> count)
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

		public static Vector128<ushort> SumAbsoluteDifferencesInBlock32(Vector128<byte> left, Vector128<byte> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ushort> SumAbsoluteDifferencesInBlock32(Vector256<byte> left, Vector256<byte> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}
	}

	public new abstract class X64 : Avx512F.X64
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

	public static Vector512<byte> Abs(Vector512<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Abs(Vector512<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Add(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Add(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Add(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Add(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> AddSaturate(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> AddSaturate(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> AddSaturate(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> AddSaturate(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> AlignRight(Vector512<sbyte> left, Vector512<sbyte> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> AlignRight(Vector512<byte> left, Vector512<byte> right, [ConstantExpected] byte mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Average(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Average(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> BlendVariable(Vector512<byte> left, Vector512<byte> right, Vector512<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> BlendVariable(Vector512<short> left, Vector512<short> right, Vector512<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> BlendVariable(Vector512<sbyte> left, Vector512<sbyte> right, Vector512<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> BlendVariable(Vector512<ushort> left, Vector512<ushort> right, Vector512<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> BroadcastScalarToVector512(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> BroadcastScalarToVector512(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> BroadcastScalarToVector512(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> BroadcastScalarToVector512(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareEqual(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareGreaterThan(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareGreaterThanOrEqual(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareLessThan(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareLessThanOrEqual(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> CompareNotEqual(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareEqual(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareGreaterThan(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareGreaterThanOrEqual(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareLessThan(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareLessThanOrEqual(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> CompareNotEqual(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareEqual(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareGreaterThan(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareGreaterThanOrEqual(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareLessThan(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareLessThanOrEqual(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> CompareNotEqual(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareEqual(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareGreaterThan(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareGreaterThanOrEqual(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareLessThan(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareLessThanOrEqual(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> CompareNotEqual(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> ConvertToVector256Byte(Vector512<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> ConvertToVector256Byte(Vector512<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<byte> ConvertToVector256ByteWithSaturation(Vector512<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> ConvertToVector256SByte(Vector512<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> ConvertToVector256SByte(Vector512<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector256<sbyte> ConvertToVector256SByteWithSaturation(Vector512<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ConvertToVector512Int16(Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ConvertToVector512Int16(Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ConvertToVector512UInt16(Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ConvertToVector512UInt16(Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static Vector512<sbyte> LoadVector512(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static Vector512<byte> LoadVector512(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static Vector512<short> LoadVector512(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static Vector512<ushort> LoadVector512(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<byte> MaskLoad(byte* address, Vector512<byte> mask, Vector512<byte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<short> MaskLoad(short* address, Vector512<short> mask, Vector512<short> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<sbyte> MaskLoad(sbyte* address, Vector512<sbyte> mask, Vector512<sbyte> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector512<ushort> MaskLoad(ushort* address, Vector512<ushort> mask, Vector512<ushort> merge)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(byte* address, Vector512<byte> mask, Vector512<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(short* address, Vector512<short> mask, Vector512<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(sbyte* address, Vector512<sbyte> mask, Vector512<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void MaskStore(ushort* address, Vector512<ushort> mask, Vector512<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Max(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Max(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Max(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Max(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Min(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Min(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Min(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Min(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public new static int MoveMask(Vector256<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static long MoveMask(Vector512<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector512<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static long MoveMask(Vector512<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int MoveMask(Vector512<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<int> MultiplyAddAdjacent(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> MultiplyAddAdjacent(Vector512<byte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> MultiplyHigh(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> MultiplyHigh(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> MultiplyHighRoundScale(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> MultiplyLow(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> MultiplyLow(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> PackSignedSaturate(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> PackSignedSaturate(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> PackUnsignedSaturate(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> PackUnsignedSaturate(Vector512<int> left, Vector512<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> PermuteVar32x16(Vector512<short> left, Vector512<short> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> PermuteVar32x16(Vector512<ushort> left, Vector512<ushort> control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> PermuteVar32x16x2(Vector512<short> lower, Vector512<short> indices, Vector512<short> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> PermuteVar32x16x2(Vector512<ushort> lower, Vector512<ushort> indices, Vector512<ushort> upper)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftLeftLogical(Vector512<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftLeftLogical(Vector512<ushort> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftLeftLogical(Vector512<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftLeftLogical(Vector512<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> ShiftLeftLogical128BitLane(Vector512<sbyte> value, [ConstantExpected] byte numBytes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> ShiftLeftLogical128BitLane(Vector512<byte> value, [ConstantExpected] byte numBytes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftLeftLogicalVariable(Vector512<short> value, Vector512<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftLeftLogicalVariable(Vector512<ushort> value, Vector512<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightArithmetic(Vector512<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightArithmetic(Vector512<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightArithmeticVariable(Vector512<short> value, Vector512<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightLogical(Vector512<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftRightLogical(Vector512<ushort> value, Vector128<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightLogical(Vector512<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftRightLogical(Vector512<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> ShiftRightLogical128BitLane(Vector512<sbyte> value, [ConstantExpected] byte numBytes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> ShiftRightLogical128BitLane(Vector512<byte> value, [ConstantExpected] byte numBytes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShiftRightLogicalVariable(Vector512<short> value, Vector512<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShiftRightLogicalVariable(Vector512<ushort> value, Vector512<ushort> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Shuffle(Vector512<sbyte> value, Vector512<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Shuffle(Vector512<byte> value, Vector512<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShuffleHigh(Vector512<short> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShuffleHigh(Vector512<ushort> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> ShuffleLow(Vector512<short> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> ShuffleLow(Vector512<ushort> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void Store(sbyte* address, Vector512<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void Store(byte* address, Vector512<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void Store(short* address, Vector512<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public new unsafe static void Store(ushort* address, Vector512<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> Subtract(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> Subtract(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> Subtract(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> Subtract(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> SubtractSaturate(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> SubtractSaturate(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> SubtractSaturate(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> SubtractSaturate(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> SumAbsoluteDifferences(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> SumAbsoluteDifferencesInBlock32(Vector512<byte> left, Vector512<byte> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> UnpackHigh(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> UnpackHigh(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> UnpackHigh(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> UnpackHigh(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<sbyte> UnpackLow(Vector512<sbyte> left, Vector512<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<byte> UnpackLow(Vector512<byte> left, Vector512<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<short> UnpackLow(Vector512<short> left, Vector512<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector512<ushort> UnpackLow(Vector512<ushort> left, Vector512<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}
}
