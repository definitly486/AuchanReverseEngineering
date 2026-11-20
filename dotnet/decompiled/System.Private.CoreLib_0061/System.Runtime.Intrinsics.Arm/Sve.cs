using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[CLSCompliant(false)]
[Experimental("SYSLIB5003", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
public abstract class Sve : AdvSimd
{
	public new abstract class Arm64 : AdvSimd.Arm64
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

	public static Vector<double> Abs(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Abs(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Abs(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Abs(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Abs(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Abs(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AbsoluteCompareGreaterThan(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AbsoluteCompareGreaterThan(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AbsoluteCompareGreaterThanOrEqual(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AbsoluteCompareGreaterThanOrEqual(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AbsoluteCompareLessThan(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AbsoluteCompareLessThan(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AbsoluteCompareLessThanOrEqual(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AbsoluteCompareLessThanOrEqual(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AbsoluteDifference(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AbsoluteDifference(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifference(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifference(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifference(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AbsoluteDifference(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AbsoluteDifference(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifference(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifference(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifference(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Add(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Add(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Add(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Add(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Add(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Add(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Add(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Add(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Add(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Add(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AddAcross(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AddAcross(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AddRotateComplex(Vector<double> left, Vector<double> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AddRotateComplex(Vector<float> left, Vector<float> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddSaturate(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddSaturate(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddSaturate(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddSaturate(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddSaturate(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddSaturate(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddSaturate(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddSaturate(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AddSequentialAcross(Vector<double> initial, Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AddSequentialAcross(Vector<float> initial, Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> And(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> And(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> And(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> And(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> And(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> And(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> And(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> And(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AndAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AndAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AndAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AndAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AndAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AndAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AndAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AndAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BitwiseClear(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BitwiseClear(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BitwiseClear(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BitwiseClear(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BitwiseClear(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BitwiseClear(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BitwiseClear(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BitwiseClear(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BooleanNot(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BooleanNot(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BooleanNot(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BooleanNot(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BooleanNot(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BooleanNot(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BooleanNot(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BooleanNot(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Compact(Vector<double> mask, Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Compact(Vector<int> mask, Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Compact(Vector<long> mask, Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Compact(Vector<float> mask, Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compact(Vector<uint> mask, Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compact(Vector<ulong> mask, Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareEqual(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareEqual(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareEqual(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareEqual(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareEqual(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareEqual(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareEqual(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareEqual(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareEqual(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareEqual(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareEqual(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareEqual(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareEqual(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareGreaterThan(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareGreaterThan(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareGreaterThan(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareGreaterThan(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareGreaterThan(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareGreaterThan(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareGreaterThan(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareGreaterThan(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareGreaterThan(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareGreaterThan(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareGreaterThan(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareGreaterThan(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareGreaterThan(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareGreaterThan(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareGreaterThan(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareGreaterThan(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareGreaterThanOrEqual(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareGreaterThanOrEqual(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareGreaterThanOrEqual(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareGreaterThanOrEqual(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareGreaterThanOrEqual(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareGreaterThanOrEqual(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareGreaterThanOrEqual(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareGreaterThanOrEqual(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareGreaterThanOrEqual(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareGreaterThanOrEqual(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareGreaterThanOrEqual(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareGreaterThanOrEqual(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareGreaterThanOrEqual(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareGreaterThanOrEqual(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareGreaterThanOrEqual(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareGreaterThanOrEqual(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareLessThan(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareLessThan(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareLessThan(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareLessThan(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareLessThan(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareLessThan(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareLessThan(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareLessThan(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareLessThan(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareLessThan(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareLessThan(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareLessThan(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareLessThan(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareLessThan(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareLessThan(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareLessThan(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareLessThanOrEqual(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareLessThanOrEqual(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareLessThanOrEqual(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareLessThanOrEqual(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareLessThanOrEqual(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareLessThanOrEqual(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareLessThanOrEqual(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareLessThanOrEqual(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareLessThanOrEqual(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareLessThanOrEqual(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareLessThanOrEqual(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareLessThanOrEqual(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareLessThanOrEqual(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareLessThanOrEqual(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareLessThanOrEqual(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareLessThanOrEqual(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CompareNotEqualTo(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareNotEqualTo(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareNotEqualTo(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CompareNotEqualTo(Vector<short> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareNotEqualTo(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CompareNotEqualTo(Vector<int> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CompareNotEqualTo(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareNotEqualTo(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CompareNotEqualTo(Vector<sbyte> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareNotEqualTo(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CompareNotEqualTo(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CompareNotEqualTo(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CompareNotEqualTo(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CompareUnordered(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CompareUnordered(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute16BitAddresses(Vector<uint> bases, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute16BitAddresses(Vector<uint> bases, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute16BitAddresses(Vector<ulong> bases, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute16BitAddresses(Vector<ulong> bases, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute32BitAddresses(Vector<uint> bases, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute32BitAddresses(Vector<uint> bases, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute32BitAddresses(Vector<ulong> bases, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute32BitAddresses(Vector<ulong> bases, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute64BitAddresses(Vector<uint> bases, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute64BitAddresses(Vector<uint> bases, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute64BitAddresses(Vector<ulong> bases, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute64BitAddresses(Vector<ulong> bases, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute8BitAddresses(Vector<uint> bases, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Compute8BitAddresses(Vector<uint> bases, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute8BitAddresses(Vector<ulong> bases, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Compute8BitAddresses(Vector<ulong> bases, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ConditionalExtractAfterLastActiveElement(Vector<byte> mask, Vector<byte> defaultScalar, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte ConditionalExtractAfterLastActiveElement(Vector<byte> mask, byte defaultValue, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConditionalExtractAfterLastActiveElement(Vector<double> mask, Vector<double> defaultScalar, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static double ConditionalExtractAfterLastActiveElement(Vector<double> mask, double defaultValue, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ConditionalExtractAfterLastActiveElement(Vector<short> mask, Vector<short> defaultScalar, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static short ConditionalExtractAfterLastActiveElement(Vector<short> mask, short defaultValue, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConditionalExtractAfterLastActiveElement(Vector<int> mask, Vector<int> defaultScalar, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConditionalExtractAfterLastActiveElement(Vector<int> mask, int defaultValue, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConditionalExtractAfterLastActiveElement(Vector<long> mask, Vector<long> defaultScalar, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static long ConditionalExtractAfterLastActiveElement(Vector<long> mask, long defaultValue, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ConditionalExtractAfterLastActiveElement(Vector<sbyte> mask, Vector<sbyte> defaultScalar, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte ConditionalExtractAfterLastActiveElement(Vector<sbyte> mask, sbyte defaultValue, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConditionalExtractAfterLastActiveElement(Vector<float> mask, Vector<float> defaultScalar, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static float ConditionalExtractAfterLastActiveElement(Vector<float> mask, float defaultValue, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ConditionalExtractAfterLastActiveElement(Vector<ushort> mask, Vector<ushort> defaultScalar, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort ConditionalExtractAfterLastActiveElement(Vector<ushort> mask, ushort defaultValue, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConditionalExtractAfterLastActiveElement(Vector<uint> mask, Vector<uint> defaultScalar, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConditionalExtractAfterLastActiveElement(Vector<uint> mask, uint defaultValue, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConditionalExtractAfterLastActiveElement(Vector<ulong> mask, Vector<ulong> defaultScalar, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong ConditionalExtractAfterLastActiveElement(Vector<ulong> mask, ulong defaultValue, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<byte> mask, Vector<byte> defaultValues, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<double> mask, Vector<double> defaultValues, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<short> mask, Vector<short> defaultValues, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<int> mask, Vector<int> defaultValues, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<long> mask, Vector<long> defaultValues, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<sbyte> mask, Vector<sbyte> defaultValues, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<float> mask, Vector<float> defaultValues, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<ushort> mask, Vector<ushort> defaultValues, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<uint> mask, Vector<uint> defaultValues, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConditionalExtractAfterLastActiveElementAndReplicate(Vector<ulong> mask, Vector<ulong> defaultValues, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ConditionalExtractLastActiveElement(Vector<byte> mask, Vector<byte> defaultScalar, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte ConditionalExtractLastActiveElement(Vector<byte> mask, byte defaultValue, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConditionalExtractLastActiveElement(Vector<double> mask, Vector<double> defaultScalar, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static double ConditionalExtractLastActiveElement(Vector<double> mask, double defaultValue, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ConditionalExtractLastActiveElement(Vector<short> mask, Vector<short> defaultScalar, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static short ConditionalExtractLastActiveElement(Vector<short> mask, short defaultValue, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConditionalExtractLastActiveElement(Vector<int> mask, Vector<int> defaultScalar, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ConditionalExtractLastActiveElement(Vector<int> mask, int defaultValue, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConditionalExtractLastActiveElement(Vector<long> mask, Vector<long> defaultScalar, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static long ConditionalExtractLastActiveElement(Vector<long> mask, long defaultValue, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ConditionalExtractLastActiveElement(Vector<sbyte> mask, Vector<sbyte> defaultScalar, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte ConditionalExtractLastActiveElement(Vector<sbyte> mask, sbyte defaultValue, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConditionalExtractLastActiveElement(Vector<float> mask, Vector<float> defaultScalar, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static float ConditionalExtractLastActiveElement(Vector<float> mask, float defaultValue, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ConditionalExtractLastActiveElement(Vector<ushort> mask, Vector<ushort> defaultScalar, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort ConditionalExtractLastActiveElement(Vector<ushort> mask, ushort defaultValue, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConditionalExtractLastActiveElement(Vector<uint> mask, Vector<uint> defaultScalar, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ConditionalExtractLastActiveElement(Vector<uint> mask, uint defaultValue, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConditionalExtractLastActiveElement(Vector<ulong> mask, Vector<ulong> defaultScalar, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong ConditionalExtractLastActiveElement(Vector<ulong> mask, ulong defaultValue, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ConditionalExtractLastActiveElementAndReplicate(Vector<byte> mask, Vector<byte> defaultValues, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConditionalExtractLastActiveElementAndReplicate(Vector<double> mask, Vector<double> defaultValues, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ConditionalExtractLastActiveElementAndReplicate(Vector<short> mask, Vector<short> defaultValues, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConditionalExtractLastActiveElementAndReplicate(Vector<int> mask, Vector<int> defaultValues, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConditionalExtractLastActiveElementAndReplicate(Vector<long> mask, Vector<long> defaultValues, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ConditionalExtractLastActiveElementAndReplicate(Vector<sbyte> mask, Vector<sbyte> defaultValues, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConditionalExtractLastActiveElementAndReplicate(Vector<float> mask, Vector<float> defaultValues, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ConditionalExtractLastActiveElementAndReplicate(Vector<ushort> mask, Vector<ushort> defaultValues, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConditionalExtractLastActiveElementAndReplicate(Vector<uint> mask, Vector<uint> defaultValues, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConditionalExtractLastActiveElementAndReplicate(Vector<ulong> mask, Vector<ulong> defaultValues, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ConditionalSelect(Vector<byte> mask, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConditionalSelect(Vector<double> mask, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ConditionalSelect(Vector<short> mask, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConditionalSelect(Vector<int> mask, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConditionalSelect(Vector<long> mask, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ConditionalSelect(Vector<sbyte> mask, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConditionalSelect(Vector<float> mask, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ConditionalSelect(Vector<ushort> mask, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConditionalSelect(Vector<uint> mask, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConditionalSelect(Vector<ulong> mask, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDouble(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDouble(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDouble(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDouble(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDouble(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConvertToInt32(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ConvertToInt32(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConvertToInt64(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ConvertToInt64(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingle(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingle(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingle(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingle(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingle(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConvertToUInt32(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ConvertToUInt32(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConvertToUInt64(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ConvertToUInt64(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong Count16BitElements([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong Count32BitElements([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong Count64BitElements([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong Count8BitElements([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateBreakAfterMask(Vector<byte> totalMask, Vector<byte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateBreakAfterMask(Vector<short> totalMask, Vector<short> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateBreakAfterMask(Vector<int> totalMask, Vector<int> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateBreakAfterMask(Vector<long> totalMask, Vector<long> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateBreakAfterMask(Vector<sbyte> totalMask, Vector<sbyte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateBreakAfterMask(Vector<ushort> totalMask, Vector<ushort> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateBreakAfterMask(Vector<uint> totalMask, Vector<uint> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateBreakAfterMask(Vector<ulong> totalMask, Vector<ulong> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateBreakAfterPropagateMask(Vector<byte> mask, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateBreakAfterPropagateMask(Vector<short> mask, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateBreakAfterPropagateMask(Vector<int> mask, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateBreakAfterPropagateMask(Vector<long> mask, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateBreakAfterPropagateMask(Vector<sbyte> mask, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateBreakAfterPropagateMask(Vector<ushort> mask, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateBreakAfterPropagateMask(Vector<uint> mask, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateBreakAfterPropagateMask(Vector<ulong> mask, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateBreakBeforeMask(Vector<byte> totalMask, Vector<byte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateBreakBeforeMask(Vector<short> totalMask, Vector<short> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateBreakBeforeMask(Vector<int> totalMask, Vector<int> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateBreakBeforeMask(Vector<long> totalMask, Vector<long> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateBreakBeforeMask(Vector<sbyte> totalMask, Vector<sbyte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateBreakBeforeMask(Vector<ushort> totalMask, Vector<ushort> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateBreakBeforeMask(Vector<uint> totalMask, Vector<uint> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateBreakBeforeMask(Vector<ulong> totalMask, Vector<ulong> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateBreakBeforePropagateMask(Vector<byte> mask, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateBreakBeforePropagateMask(Vector<short> mask, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateBreakBeforePropagateMask(Vector<int> mask, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateBreakBeforePropagateMask(Vector<long> mask, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateBreakBeforePropagateMask(Vector<sbyte> mask, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateBreakBeforePropagateMask(Vector<ushort> mask, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateBreakBeforePropagateMask(Vector<uint> mask, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateBreakBeforePropagateMask(Vector<ulong> mask, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateBreakPropagateMask(Vector<byte> totalMask, Vector<byte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateBreakPropagateMask(Vector<short> totalMask, Vector<short> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateBreakPropagateMask(Vector<int> totalMask, Vector<int> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateBreakPropagateMask(Vector<long> totalMask, Vector<long> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateBreakPropagateMask(Vector<sbyte> totalMask, Vector<sbyte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateBreakPropagateMask(Vector<ushort> totalMask, Vector<ushort> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateBreakPropagateMask(Vector<uint> totalMask, Vector<uint> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateBreakPropagateMask(Vector<ulong> totalMask, Vector<ulong> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateFalseMaskByte()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CreateFalseMaskDouble()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateFalseMaskInt16()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateFalseMaskInt32()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateFalseMaskInt64()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateFalseMaskSByte()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CreateFalseMaskSingle()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateFalseMaskUInt16()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateFalseMaskUInt32()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateFalseMaskUInt64()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateMaskForFirstActiveElement(Vector<byte> totalMask, Vector<byte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateMaskForFirstActiveElement(Vector<short> totalMask, Vector<short> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateMaskForFirstActiveElement(Vector<int> totalMask, Vector<int> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateMaskForFirstActiveElement(Vector<long> totalMask, Vector<long> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateMaskForFirstActiveElement(Vector<sbyte> totalMask, Vector<sbyte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateMaskForFirstActiveElement(Vector<ushort> totalMask, Vector<ushort> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateMaskForFirstActiveElement(Vector<uint> totalMask, Vector<uint> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateMaskForFirstActiveElement(Vector<ulong> totalMask, Vector<ulong> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateMaskForNextActiveElement(Vector<byte> totalMask, Vector<byte> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateMaskForNextActiveElement(Vector<ushort> totalMask, Vector<ushort> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateMaskForNextActiveElement(Vector<uint> totalMask, Vector<uint> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateMaskForNextActiveElement(Vector<ulong> totalMask, Vector<ulong> fromMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateTrueMaskByte([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> CreateTrueMaskDouble([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> CreateTrueMaskInt16([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> CreateTrueMaskInt32([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> CreateTrueMaskInt64([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> CreateTrueMaskSByte([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> CreateTrueMaskSingle([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateTrueMaskUInt16([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateTrueMaskUInt32([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateTrueMaskUInt64([ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanMask16Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanMask16Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanMask16Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanMask16Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanMask32Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanMask32Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanMask32Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanMask32Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanMask64Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanMask64Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanMask64Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanMask64Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanMask8Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanMask8Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanMask8Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanMask8Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanOrEqualMask16Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanOrEqualMask16Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanOrEqualMask16Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> CreateWhileLessThanOrEqualMask16Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanOrEqualMask32Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanOrEqualMask32Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanOrEqualMask32Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> CreateWhileLessThanOrEqualMask32Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanOrEqualMask64Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanOrEqualMask64Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanOrEqualMask64Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> CreateWhileLessThanOrEqualMask64Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanOrEqualMask8Bit(int left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanOrEqualMask8Bit(long left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanOrEqualMask8Bit(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> CreateWhileLessThanOrEqualMask8Bit(ulong left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Divide(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Divide(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> DotProduct(Vector<int> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> DotProduct(Vector<long> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> DotProduct(Vector<uint> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> DotProduct(Vector<ulong> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> DotProductBySelectedScalar(Vector<int> addend, Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> DotProductBySelectedScalar(Vector<long> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> DotProductBySelectedScalar(Vector<uint> addend, Vector<byte> left, Vector<byte> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> DotProductBySelectedScalar(Vector<ulong> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> DuplicateSelectedScalarToVector(Vector<byte> data, [ConstantExpected(Min = 0, Max = 63)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> DuplicateSelectedScalarToVector(Vector<double> data, [ConstantExpected(Min = 0, Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> DuplicateSelectedScalarToVector(Vector<short> data, [ConstantExpected(Min = 0, Max = 31)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> DuplicateSelectedScalarToVector(Vector<int> data, [ConstantExpected(Min = 0, Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> DuplicateSelectedScalarToVector(Vector<long> data, [ConstantExpected(Min = 0, Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> DuplicateSelectedScalarToVector(Vector<sbyte> data, [ConstantExpected(Min = 0, Max = 63)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> DuplicateSelectedScalarToVector(Vector<float> data, [ConstantExpected(Min = 0, Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> DuplicateSelectedScalarToVector(Vector<ushort> data, [ConstantExpected(Min = 0, Max = 31)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> DuplicateSelectedScalarToVector(Vector<uint> data, [ConstantExpected(Min = 0, Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> DuplicateSelectedScalarToVector(Vector<ulong> data, [ConstantExpected(Min = 0, Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ExtractAfterLastActiveElement(Vector<byte> mask, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte ExtractAfterLastActiveElementScalar(Vector<byte> mask, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ExtractAfterLastActiveElement(Vector<double> mask, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static double ExtractAfterLastActiveElementScalar(Vector<double> mask, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ExtractAfterLastActiveElement(Vector<short> mask, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static short ExtractAfterLastActiveElementScalar(Vector<short> mask, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ExtractAfterLastActiveElement(Vector<int> mask, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ExtractAfterLastActiveElementScalar(Vector<int> mask, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ExtractAfterLastActiveElement(Vector<long> mask, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static long ExtractAfterLastActiveElementScalar(Vector<long> mask, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ExtractAfterLastActiveElement(Vector<sbyte> mask, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte ExtractAfterLastActiveElementScalar(Vector<sbyte> mask, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ExtractAfterLastActiveElement(Vector<float> mask, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static float ExtractAfterLastActiveElementScalar(Vector<float> mask, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ExtractAfterLastActiveElement(Vector<ushort> mask, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort ExtractAfterLastActiveElementScalar(Vector<ushort> mask, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ExtractAfterLastActiveElement(Vector<uint> mask, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ExtractAfterLastActiveElementScalar(Vector<uint> mask, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ExtractAfterLastActiveElement(Vector<ulong> mask, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong ExtractAfterLastActiveElementScalar(Vector<ulong> mask, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ExtractLastActiveElement(Vector<byte> mask, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte ExtractLastActiveElementScalar(Vector<byte> mask, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ExtractLastActiveElement(Vector<double> mask, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static double ExtractLastActiveElementScalar(Vector<double> mask, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ExtractLastActiveElement(Vector<short> mask, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static short ExtractLastActiveElementScalar(Vector<short> mask, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ExtractLastActiveElement(Vector<int> mask, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static int ExtractLastActiveElementScalar(Vector<int> mask, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ExtractLastActiveElement(Vector<long> mask, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static long ExtractLastActiveElementScalar(Vector<long> mask, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ExtractLastActiveElement(Vector<sbyte> mask, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte ExtractLastActiveElementScalar(Vector<sbyte> mask, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ExtractLastActiveElement(Vector<float> mask, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static float ExtractLastActiveElementScalar(Vector<float> mask, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ExtractLastActiveElement(Vector<ushort> mask, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort ExtractLastActiveElementScalar(Vector<ushort> mask, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ExtractLastActiveElement(Vector<uint> mask, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ExtractLastActiveElementScalar(Vector<uint> mask, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ExtractLastActiveElement(Vector<ulong> mask, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong ExtractLastActiveElementScalar(Vector<ulong> mask, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ExtractVector(Vector<byte> upper, Vector<byte> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ExtractVector(Vector<double> upper, Vector<double> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ExtractVector(Vector<short> upper, Vector<short> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ExtractVector(Vector<int> upper, Vector<int> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ExtractVector(Vector<long> upper, Vector<long> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ExtractVector(Vector<sbyte> upper, Vector<sbyte> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ExtractVector(Vector<float> upper, Vector<float> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ExtractVector(Vector<ushort> upper, Vector<ushort> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ExtractVector(Vector<uint> upper, Vector<uint> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ExtractVector(Vector<ulong> upper, Vector<ulong> lower, [ConstantExpected] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FloatingPointExponentialAccelerator(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FloatingPointExponentialAccelerator(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplyAdd(Vector<double> addend, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplyAdd(Vector<float> addend, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplyAddBySelectedScalar(Vector<double> addend, Vector<double> left, Vector<double> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplyAddBySelectedScalar(Vector<float> addend, Vector<float> left, Vector<float> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplyAddNegated(Vector<double> addend, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplyAddNegated(Vector<float> addend, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplySubtract(Vector<double> minuend, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplySubtract(Vector<float> minuend, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplySubtractBySelectedScalar(Vector<double> minuend, Vector<double> left, Vector<double> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplySubtractBySelectedScalar(Vector<float> minuend, Vector<float> left, Vector<float> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> FusedMultiplySubtractNegated(Vector<double> minuend, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> FusedMultiplySubtractNegated(Vector<float> minuend, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<short> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<short> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<short> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch16Bit(Vector<short> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<short> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<ushort> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<ushort> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<ushort> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch16Bit(Vector<ushort> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch16Bit(Vector<ushort> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<int> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<int> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<int> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch32Bit(Vector<int> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<int> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<uint> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<uint> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<uint> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch32Bit(Vector<uint> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch32Bit(Vector<uint> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<long> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<long> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<long> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch64Bit(Vector<long> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<long> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<ulong> mask, void* address, Vector<int> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<ulong> mask, void* address, Vector<long> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<ulong> mask, void* address, Vector<uint> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch64Bit(Vector<ulong> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch64Bit(Vector<ulong> mask, void* address, Vector<ulong> indices, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<byte> mask, void* address, Vector<int> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<byte> mask, void* address, Vector<long> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<byte> mask, void* address, Vector<uint> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch8Bit(Vector<byte> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<byte> mask, void* address, Vector<ulong> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<sbyte> mask, void* address, Vector<int> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<sbyte> mask, void* address, Vector<long> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<sbyte> mask, void* address, Vector<uint> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static void GatherPrefetch8Bit(Vector<sbyte> mask, Vector<ulong> addresses, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void GatherPrefetch8Bit(Vector<sbyte> mask, void* address, Vector<ulong> offsets, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVector(Vector<double> mask, double* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> GatherVector(Vector<double> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVector(Vector<double> mask, double* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVector(Vector<int> mask, int* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVector(Vector<int> mask, int* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVector(Vector<long> mask, long* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVector(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVector(Vector<long> mask, long* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVector(Vector<float> mask, float* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVector(Vector<float> mask, float* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVector(Vector<uint> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVector(Vector<uint> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVector(Vector<ulong> mask, ulong* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVector(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVector(Vector<ulong> mask, ulong* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorByteZeroExtend(Vector<int> mask, byte* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorByteZeroExtend(Vector<int> mask, byte* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorByteZeroExtend(Vector<long> mask, byte* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorByteZeroExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorByteZeroExtend(Vector<long> mask, byte* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorByteZeroExtend(Vector<uint> mask, byte* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorByteZeroExtend(Vector<uint> mask, byte* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorByteZeroExtend(Vector<ulong> mask, byte* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorByteZeroExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorByteZeroExtend(Vector<ulong> mask, byte* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorByteZeroExtendFirstFaulting(Vector<int> mask, byte* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorByteZeroExtendFirstFaulting(Vector<int> mask, byte* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorByteZeroExtendFirstFaulting(Vector<long> mask, byte* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorByteZeroExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorByteZeroExtendFirstFaulting(Vector<long> mask, byte* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorByteZeroExtendFirstFaulting(Vector<uint> mask, byte* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorByteZeroExtendFirstFaulting(Vector<uint> mask, byte* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorByteZeroExtendFirstFaulting(Vector<ulong> mask, byte* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorByteZeroExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorByteZeroExtendFirstFaulting(Vector<ulong> mask, byte* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorFirstFaulting(Vector<double> mask, double* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> GatherVectorFirstFaulting(Vector<double> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorFirstFaulting(Vector<double> mask, double* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorFirstFaulting(Vector<int> mask, int* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorFirstFaulting(Vector<int> mask, int* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorFirstFaulting(Vector<long> mask, long* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorFirstFaulting(Vector<long> mask, long* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorFirstFaulting(Vector<float> mask, float* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorFirstFaulting(Vector<float> mask, float* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorFirstFaulting(Vector<uint> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorFirstFaulting(Vector<uint> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorFirstFaulting(Vector<ulong> mask, ulong* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorFirstFaulting(Vector<ulong> mask, ulong* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16SignExtend(Vector<int> mask, short* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16SignExtend(Vector<int> mask, short* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16SignExtend(Vector<long> mask, short* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorInt16SignExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16SignExtend(Vector<long> mask, short* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16SignExtend(Vector<uint> mask, short* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16SignExtend(Vector<uint> mask, short* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16SignExtend(Vector<ulong> mask, short* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorInt16SignExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16SignExtend(Vector<ulong> mask, short* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16SignExtendFirstFaulting(Vector<int> mask, short* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16SignExtendFirstFaulting(Vector<int> mask, short* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16SignExtendFirstFaulting(Vector<long> mask, short* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorInt16SignExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16SignExtendFirstFaulting(Vector<long> mask, short* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16SignExtendFirstFaulting(Vector<uint> mask, short* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16SignExtendFirstFaulting(Vector<uint> mask, short* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16SignExtendFirstFaulting(Vector<ulong> mask, short* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorInt16SignExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16SignExtendFirstFaulting(Vector<ulong> mask, short* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16WithByteOffsetsSignExtend(Vector<int> mask, short* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16WithByteOffsetsSignExtend(Vector<int> mask, short* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16WithByteOffsetsSignExtend(Vector<long> mask, short* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16WithByteOffsetsSignExtend(Vector<long> mask, short* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16WithByteOffsetsSignExtend(Vector<uint> mask, short* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16WithByteOffsetsSignExtend(Vector<uint> mask, short* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16WithByteOffsetsSignExtend(Vector<ulong> mask, short* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16WithByteOffsetsSignExtend(Vector<ulong> mask, short* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<int> mask, short* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<int> mask, short* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<long> mask, short* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<long> mask, short* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<uint> mask, short* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<uint> mask, short* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<ulong> mask, short* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt16WithByteOffsetsSignExtendFirstFaulting(Vector<ulong> mask, short* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32SignExtend(Vector<long> mask, int* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorInt32SignExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32SignExtend(Vector<long> mask, int* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32SignExtend(Vector<ulong> mask, int* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorInt32SignExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32SignExtend(Vector<ulong> mask, int* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32SignExtendFirstFaulting(Vector<long> mask, int* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorInt32SignExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32SignExtendFirstFaulting(Vector<long> mask, int* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32SignExtendFirstFaulting(Vector<ulong> mask, int* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorInt32SignExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32SignExtendFirstFaulting(Vector<ulong> mask, int* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32WithByteOffsetsSignExtend(Vector<long> mask, int* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32WithByteOffsetsSignExtend(Vector<long> mask, int* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32WithByteOffsetsSignExtend(Vector<ulong> mask, int* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32WithByteOffsetsSignExtend(Vector<ulong> mask, int* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32WithByteOffsetsSignExtendFirstFaulting(Vector<long> mask, int* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorInt32WithByteOffsetsSignExtendFirstFaulting(Vector<long> mask, int* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32WithByteOffsetsSignExtendFirstFaulting(Vector<ulong> mask, int* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorInt32WithByteOffsetsSignExtendFirstFaulting(Vector<ulong> mask, int* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorSByteSignExtend(Vector<int> mask, sbyte* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorSByteSignExtend(Vector<int> mask, sbyte* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorSByteSignExtend(Vector<long> mask, sbyte* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorSByteSignExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorSByteSignExtend(Vector<long> mask, sbyte* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorSByteSignExtend(Vector<uint> mask, sbyte* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorSByteSignExtend(Vector<uint> mask, sbyte* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorSByteSignExtend(Vector<ulong> mask, sbyte* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorSByteSignExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorSByteSignExtend(Vector<ulong> mask, sbyte* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorSByteSignExtendFirstFaulting(Vector<int> mask, sbyte* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorSByteSignExtendFirstFaulting(Vector<int> mask, sbyte* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorSByteSignExtendFirstFaulting(Vector<long> mask, sbyte* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorSByteSignExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorSByteSignExtendFirstFaulting(Vector<long> mask, sbyte* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorSByteSignExtendFirstFaulting(Vector<uint> mask, sbyte* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorSByteSignExtendFirstFaulting(Vector<uint> mask, sbyte* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorSByteSignExtendFirstFaulting(Vector<ulong> mask, sbyte* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorSByteSignExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorSByteSignExtendFirstFaulting(Vector<ulong> mask, sbyte* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<int> mask, ushort* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<int> mask, ushort* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<long> mask, ushort* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<long> mask, ushort* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<uint> mask, ushort* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<uint> mask, ushort* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<ulong> mask, ushort* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16WithByteOffsetsZeroExtend(Vector<ulong> mask, ushort* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<int> mask, ushort* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<int> mask, ushort* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<long> mask, ushort* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<long> mask, ushort* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<uint> mask, ushort* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<uint> mask, ushort* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<ulong> mask, ushort* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16WithByteOffsetsZeroExtendFirstFaulting(Vector<ulong> mask, ushort* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16ZeroExtend(Vector<int> mask, ushort* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16ZeroExtend(Vector<int> mask, ushort* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16ZeroExtend(Vector<long> mask, ushort* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorUInt16ZeroExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16ZeroExtend(Vector<long> mask, ushort* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16ZeroExtend(Vector<uint> mask, ushort* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16ZeroExtend(Vector<uint> mask, ushort* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16ZeroExtend(Vector<ulong> mask, ushort* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorUInt16ZeroExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16ZeroExtend(Vector<ulong> mask, ushort* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<int> mask, ushort* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<int> mask, ushort* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<long> mask, ushort* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<long> mask, ushort* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<uint> mask, ushort* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<uint> mask, ushort* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<ulong> mask, ushort* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt16ZeroExtendFirstFaulting(Vector<ulong> mask, ushort* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<int> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<int> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<long> mask, uint* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<long> mask, uint* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<uint> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<uint> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<ulong> mask, uint* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32WithByteOffsetsZeroExtend(Vector<ulong> mask, uint* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<int> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<int> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<long> mask, uint* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<long> mask, uint* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<uint> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<uint> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<ulong> mask, uint* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32WithByteOffsetsZeroExtendFirstFaulting(Vector<ulong> mask, uint* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32ZeroExtend(Vector<int> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32ZeroExtend(Vector<int> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32ZeroExtend(Vector<long> mask, uint* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorUInt32ZeroExtend(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32ZeroExtend(Vector<long> mask, uint* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32ZeroExtend(Vector<uint> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32ZeroExtend(Vector<uint> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32ZeroExtend(Vector<ulong> mask, uint* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorUInt32ZeroExtend(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32ZeroExtend(Vector<ulong> mask, uint* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<int> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<int> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<long> mask, uint* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<long> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<long> mask, uint* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<uint> mask, uint* address, Vector<int> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<uint> mask, uint* address, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<ulong> mask, uint* address, Vector<long> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<ulong> mask, Vector<ulong> addresses)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorUInt32ZeroExtendFirstFaulting(Vector<ulong> mask, uint* address, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorWithByteOffsetFirstFaulting(Vector<double> mask, double* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorWithByteOffsetFirstFaulting(Vector<double> mask, double* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorWithByteOffsetFirstFaulting(Vector<int> mask, int* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorWithByteOffsetFirstFaulting(Vector<int> mask, int* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorWithByteOffsetFirstFaulting(Vector<long> mask, long* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorWithByteOffsetFirstFaulting(Vector<long> mask, long* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorWithByteOffsetFirstFaulting(Vector<float> mask, float* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorWithByteOffsetFirstFaulting(Vector<float> mask, float* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorWithByteOffsetFirstFaulting(Vector<uint> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorWithByteOffsetFirstFaulting(Vector<uint> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorWithByteOffsetFirstFaulting(Vector<ulong> mask, ulong* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorWithByteOffsetFirstFaulting(Vector<ulong> mask, ulong* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorWithByteOffsets(Vector<double> mask, double* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> GatherVectorWithByteOffsets(Vector<double> mask, double* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorWithByteOffsets(Vector<int> mask, int* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> GatherVectorWithByteOffsets(Vector<int> mask, int* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorWithByteOffsets(Vector<long> mask, long* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> GatherVectorWithByteOffsets(Vector<long> mask, long* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorWithByteOffsets(Vector<float> mask, float* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> GatherVectorWithByteOffsets(Vector<float> mask, float* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorWithByteOffsets(Vector<uint> mask, uint* address, Vector<int> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> GatherVectorWithByteOffsets(Vector<uint> mask, uint* address, Vector<uint> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorWithByteOffsets(Vector<ulong> mask, ulong* address, Vector<long> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> GatherVectorWithByteOffsets(Vector<ulong> mask, ulong* address, Vector<ulong> offsets)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<byte> mask, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<double> mask, Vector<double> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<short> mask, Vector<short> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<int> mask, Vector<int> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<long> mask, Vector<long> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<sbyte> mask, Vector<sbyte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<float> mask, Vector<float> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<ushort> mask, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<uint> mask, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong GetActiveElementCount(Vector<ulong> mask, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> GetFfrByte()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> GetFfrInt16()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> GetFfrInt32()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> GetFfrInt64()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> GetFfrSByte()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> GetFfrUInt16()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> GetFfrUInt32()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> GetFfrUInt64()
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> InsertIntoShiftedVector(Vector<byte> left, byte right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> InsertIntoShiftedVector(Vector<double> left, double right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> InsertIntoShiftedVector(Vector<short> left, short right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> InsertIntoShiftedVector(Vector<int> left, int right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> InsertIntoShiftedVector(Vector<long> left, long right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> InsertIntoShiftedVector(Vector<sbyte> left, sbyte right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> InsertIntoShiftedVector(Vector<float> left, float right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> InsertIntoShiftedVector(Vector<ushort> left, ushort right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> InsertIntoShiftedVector(Vector<uint> left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> InsertIntoShiftedVector(Vector<ulong> left, ulong right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> LeadingSignCount(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> LeadingSignCount(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> LeadingSignCount(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> LeadingSignCount(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> LeadingZeroCount(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> LeadingZeroCount(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> LeadingZeroCount(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> LeadingZeroCount(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> LeadingZeroCount(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> LeadingZeroCount(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> LeadingZeroCount(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> LeadingZeroCount(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<byte> LoadVector(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> LoadVector(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVector(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVector(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVector(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<sbyte> LoadVector(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> LoadVector(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVector(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVector(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVector(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<byte> LoadVector128AndReplicateToVector(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> LoadVector128AndReplicateToVector(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVector128AndReplicateToVector(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVector128AndReplicateToVector(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVector128AndReplicateToVector(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<sbyte> LoadVector128AndReplicateToVector(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> LoadVector128AndReplicateToVector(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVector128AndReplicateToVector(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVector128AndReplicateToVector(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVector128AndReplicateToVector(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorByteNonFaultingZeroExtendToInt16(Vector<short> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorByteNonFaultingZeroExtendToInt32(Vector<int> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorByteNonFaultingZeroExtendToInt64(Vector<long> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorByteNonFaultingZeroExtendToUInt16(Vector<ushort> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorByteNonFaultingZeroExtendToUInt32(Vector<uint> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorByteNonFaultingZeroExtendToUInt64(Vector<ulong> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorByteZeroExtendFirstFaulting(Vector<short> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorByteZeroExtendFirstFaulting(Vector<int> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorByteZeroExtendFirstFaulting(Vector<long> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorByteZeroExtendFirstFaulting(Vector<ushort> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorByteZeroExtendFirstFaulting(Vector<uint> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorByteZeroExtendFirstFaulting(Vector<ulong> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorByteZeroExtendToInt16(Vector<short> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorByteZeroExtendToInt32(Vector<int> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorByteZeroExtendToInt64(Vector<long> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorByteZeroExtendToUInt16(Vector<ushort> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorByteZeroExtendToUInt32(Vector<uint> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorByteZeroExtendToUInt64(Vector<ulong> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<byte> LoadVectorFirstFaulting(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> LoadVectorFirstFaulting(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorFirstFaulting(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorFirstFaulting(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorFirstFaulting(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<sbyte> LoadVectorFirstFaulting(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> LoadVectorFirstFaulting(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorFirstFaulting(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorFirstFaulting(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorFirstFaulting(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorInt16NonFaultingSignExtendToInt32(Vector<int> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt16NonFaultingSignExtendToInt64(Vector<long> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorInt16NonFaultingSignExtendToUInt32(Vector<uint> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt16NonFaultingSignExtendToUInt64(Vector<ulong> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorInt16SignExtendFirstFaulting(Vector<int> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt16SignExtendFirstFaulting(Vector<long> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorInt16SignExtendFirstFaulting(Vector<uint> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt16SignExtendFirstFaulting(Vector<ulong> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorInt16SignExtendToInt32(Vector<int> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt16SignExtendToInt64(Vector<long> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorInt16SignExtendToUInt32(Vector<uint> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt16SignExtendToUInt64(Vector<ulong> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt32NonFaultingSignExtendToInt64(Vector<long> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt32NonFaultingSignExtendToUInt64(Vector<ulong> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt32SignExtendFirstFaulting(Vector<long> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt32SignExtendFirstFaulting(Vector<ulong> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorInt32SignExtendToInt64(Vector<long> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorInt32SignExtendToUInt64(Vector<ulong> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<byte> LoadVectorNonFaulting(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> LoadVectorNonFaulting(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorNonFaulting(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorNonFaulting(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorNonFaulting(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<sbyte> LoadVectorNonFaulting(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> LoadVectorNonFaulting(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorNonFaulting(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorNonFaulting(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorNonFaulting(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<byte> LoadVectorNonTemporal(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<double> LoadVectorNonTemporal(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorNonTemporal(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorNonTemporal(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorNonTemporal(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<sbyte> LoadVectorNonTemporal(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<float> LoadVectorNonTemporal(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorNonTemporal(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorNonTemporal(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorNonTemporal(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorSByteNonFaultingSignExtendToInt16(Vector<short> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorSByteNonFaultingSignExtendToInt32(Vector<int> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorSByteNonFaultingSignExtendToInt64(Vector<long> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorSByteNonFaultingSignExtendToUInt16(Vector<ushort> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorSByteNonFaultingSignExtendToUInt32(Vector<uint> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorSByteNonFaultingSignExtendToUInt64(Vector<ulong> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorSByteSignExtendFirstFaulting(Vector<short> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorSByteSignExtendFirstFaulting(Vector<int> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorSByteSignExtendFirstFaulting(Vector<long> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorSByteSignExtendFirstFaulting(Vector<ushort> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorSByteSignExtendFirstFaulting(Vector<uint> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorSByteSignExtendFirstFaulting(Vector<ulong> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<short> LoadVectorSByteSignExtendToInt16(Vector<short> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorSByteSignExtendToInt32(Vector<int> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorSByteSignExtendToInt64(Vector<long> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ushort> LoadVectorSByteSignExtendToUInt16(Vector<ushort> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorSByteSignExtendToUInt32(Vector<uint> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorSByteSignExtendToUInt64(Vector<ulong> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorUInt16NonFaultingZeroExtendToInt32(Vector<int> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt16NonFaultingZeroExtendToInt64(Vector<long> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorUInt16NonFaultingZeroExtendToUInt32(Vector<uint> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt16NonFaultingZeroExtendToUInt64(Vector<ulong> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorUInt16ZeroExtendFirstFaulting(Vector<int> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt16ZeroExtendFirstFaulting(Vector<long> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorUInt16ZeroExtendFirstFaulting(Vector<uint> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt16ZeroExtendFirstFaulting(Vector<ulong> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<int> LoadVectorUInt16ZeroExtendToInt32(Vector<int> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt16ZeroExtendToInt64(Vector<long> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<uint> LoadVectorUInt16ZeroExtendToUInt32(Vector<uint> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt16ZeroExtendToUInt64(Vector<ulong> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt32NonFaultingZeroExtendToInt64(Vector<long> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt32NonFaultingZeroExtendToUInt64(Vector<ulong> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt32ZeroExtendFirstFaulting(Vector<long> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt32ZeroExtendFirstFaulting(Vector<ulong> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<long> LoadVectorUInt32ZeroExtendToInt64(Vector<long> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector<ulong> LoadVectorUInt32ZeroExtendToUInt64(Vector<ulong> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<byte>, Vector<byte>) Load2xVectorAndUnzip(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<double>, Vector<double>) Load2xVectorAndUnzip(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<short>, Vector<short>) Load2xVectorAndUnzip(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<int>, Vector<int>) Load2xVectorAndUnzip(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<long>, Vector<long>) Load2xVectorAndUnzip(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<sbyte>, Vector<sbyte>) Load2xVectorAndUnzip(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<float>, Vector<float>) Load2xVectorAndUnzip(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ushort>, Vector<ushort>) Load2xVectorAndUnzip(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<uint>, Vector<uint>) Load2xVectorAndUnzip(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ulong>, Vector<ulong>) Load2xVectorAndUnzip(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<byte>, Vector<byte>, Vector<byte>) Load3xVectorAndUnzip(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<double>, Vector<double>, Vector<double>) Load3xVectorAndUnzip(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<short>, Vector<short>, Vector<short>) Load3xVectorAndUnzip(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<int>, Vector<int>, Vector<int>) Load3xVectorAndUnzip(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<long>, Vector<long>, Vector<long>) Load3xVectorAndUnzip(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<sbyte>, Vector<sbyte>, Vector<sbyte>) Load3xVectorAndUnzip(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<float>, Vector<float>, Vector<float>) Load3xVectorAndUnzip(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ushort>, Vector<ushort>, Vector<ushort>) Load3xVectorAndUnzip(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<uint>, Vector<uint>, Vector<uint>) Load3xVectorAndUnzip(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ulong>, Vector<ulong>, Vector<ulong>) Load3xVectorAndUnzip(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<byte>, Vector<byte>, Vector<byte>, Vector<byte>) Load4xVectorAndUnzip(Vector<byte> mask, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<double>, Vector<double>, Vector<double>, Vector<double>) Load4xVectorAndUnzip(Vector<double> mask, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<short>, Vector<short>, Vector<short>, Vector<short>) Load4xVectorAndUnzip(Vector<short> mask, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<int>, Vector<int>, Vector<int>, Vector<int>) Load4xVectorAndUnzip(Vector<int> mask, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<long>, Vector<long>, Vector<long>, Vector<long>) Load4xVectorAndUnzip(Vector<long> mask, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<sbyte>, Vector<sbyte>, Vector<sbyte>, Vector<sbyte>) Load4xVectorAndUnzip(Vector<sbyte> mask, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<float>, Vector<float>, Vector<float>, Vector<float>) Load4xVectorAndUnzip(Vector<float> mask, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ushort>, Vector<ushort>, Vector<ushort>, Vector<ushort>) Load4xVectorAndUnzip(Vector<ushort> mask, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<uint>, Vector<uint>, Vector<uint>, Vector<uint>) Load4xVectorAndUnzip(Vector<uint> mask, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static (Vector<ulong>, Vector<ulong>, Vector<ulong>, Vector<ulong>) Load4xVectorAndUnzip(Vector<ulong> mask, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Max(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Max(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Max(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Max(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Max(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Max(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Max(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Max(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Max(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Max(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MaxAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MaxAcross(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MaxAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MaxAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MaxAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MaxAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MaxAcross(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MaxAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MaxAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MaxAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MaxNumber(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MaxNumber(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MaxNumberAcross(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MaxNumberAcross(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Min(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Min(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Min(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Min(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Min(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Min(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Min(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Min(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Min(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Min(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MinAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MinAcross(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MinAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MinAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MinAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MinAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MinAcross(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MinAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MinAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MinAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MinNumber(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MinNumber(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MinNumberAcross(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MinNumberAcross(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Multiply(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Multiply(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Multiply(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Multiply(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Multiply(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Multiply(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Multiply(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Multiply(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Multiply(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Multiply(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MultiplyAdd(Vector<byte> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAdd(Vector<short> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAdd(Vector<int> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyAdd(Vector<long> addend, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyAdd(Vector<sbyte> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyAdd(Vector<ushort> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyAdd(Vector<uint> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyAdd(Vector<ulong> addend, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MultiplyAddRotateComplex(Vector<double> addend, Vector<double> left, Vector<double> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MultiplyAddRotateComplex(Vector<float> addend, Vector<float> left, Vector<float> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MultiplyAddRotateComplexBySelectedScalar(Vector<float> addend, Vector<float> left, Vector<float> right, [ConstantExpected(Min = 0, Max = 1)] byte rightIndex, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MultiplyBySelectedScalar(Vector<double> left, Vector<double> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MultiplyBySelectedScalar(Vector<float> left, Vector<float> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MultiplyExtended(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MultiplyExtended(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MultiplySubtract(Vector<byte> minuend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplySubtract(Vector<short> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplySubtract(Vector<int> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplySubtract(Vector<long> minuend, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplySubtract(Vector<sbyte> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplySubtract(Vector<ushort> minuend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplySubtract(Vector<uint> minuend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplySubtract(Vector<ulong> minuend, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Negate(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Negate(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Negate(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Negate(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Negate(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Negate(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Not(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Not(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Not(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Not(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Not(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Not(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Not(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Not(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Or(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Or(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Or(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Or(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Or(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Or(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Or(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Or(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> OrAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> OrAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> OrAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> OrAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> OrAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> OrAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> OrAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> OrAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> PopCount(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> PopCount(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> PopCount(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> PopCount(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> PopCount(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> PopCount(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> PopCount(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> PopCount(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> PopCount(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> PopCount(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Prefetch16Bit(Vector<ushort> mask, void* address, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Prefetch32Bit(Vector<uint> mask, void* address, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Prefetch64Bit(Vector<ulong> mask, void* address, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Prefetch8Bit(Vector<byte> mask, void* address, [ConstantExpected] SvePrefetchType prefetchType)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReciprocalEstimate(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReciprocalEstimate(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReciprocalExponent(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReciprocalExponent(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReciprocalSqrtEstimate(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReciprocalSqrtEstimate(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReciprocalSqrtStep(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReciprocalSqrtStep(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReciprocalStep(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReciprocalStep(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ReverseBits(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ReverseBits(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ReverseBits(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ReverseBits(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ReverseBits(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ReverseBits(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReverseBits(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ReverseBits(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ReverseElement(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ReverseElement(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ReverseElement(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ReverseElement(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ReverseElement(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ReverseElement(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ReverseElement(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ReverseElement(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReverseElement(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ReverseElement(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ReverseElement16(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ReverseElement16(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReverseElement16(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ReverseElement16(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ReverseElement32(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ReverseElement32(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ReverseElement8(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ReverseElement8(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ReverseElement8(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ReverseElement8(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReverseElement8(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ReverseElement8(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> RoundAwayFromZero(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> RoundAwayFromZero(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> RoundToNearest(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> RoundToNearest(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> RoundToNegativeInfinity(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> RoundToNegativeInfinity(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> RoundToPositiveInfinity(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> RoundToPositiveInfinity(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> RoundToZero(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> RoundToZero(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingDecrementBy16BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementBy16BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingDecrementBy16BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementBy16BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SaturatingDecrementBy16BitElementCount(Vector<short> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SaturatingDecrementBy16BitElementCount(Vector<ushort> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingDecrementBy32BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementBy32BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingDecrementBy32BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementBy32BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SaturatingDecrementBy32BitElementCount(Vector<int> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SaturatingDecrementBy32BitElementCount(Vector<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingDecrementBy64BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementBy64BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingDecrementBy64BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementBy64BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SaturatingDecrementBy64BitElementCount(Vector<long> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SaturatingDecrementBy64BitElementCount(Vector<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingDecrementBy8BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementBy8BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingDecrementBy8BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementBy8BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(int value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(long value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(uint value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(ulong value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SaturatingDecrementByActiveElementCount(Vector<short> value, Vector<short> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SaturatingDecrementByActiveElementCount(Vector<int> value, Vector<int> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SaturatingDecrementByActiveElementCount(Vector<long> value, Vector<long> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(int value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(long value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(uint value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(ulong value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SaturatingDecrementByActiveElementCount(Vector<ushort> value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(int value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(long value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(uint value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(ulong value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SaturatingDecrementByActiveElementCount(Vector<uint> value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(int value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingDecrementByActiveElementCount(long value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(uint value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingDecrementByActiveElementCount(ulong value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SaturatingDecrementByActiveElementCount(Vector<ulong> value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingIncrementBy16BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementBy16BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingIncrementBy16BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementBy16BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SaturatingIncrementBy16BitElementCount(Vector<short> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SaturatingIncrementBy16BitElementCount(Vector<ushort> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingIncrementBy32BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementBy32BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingIncrementBy32BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementBy32BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SaturatingIncrementBy32BitElementCount(Vector<int> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SaturatingIncrementBy32BitElementCount(Vector<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingIncrementBy64BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementBy64BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingIncrementBy64BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementBy64BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SaturatingIncrementBy64BitElementCount(Vector<long> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SaturatingIncrementBy64BitElementCount(Vector<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static int SaturatingIncrementBy8BitElementCount(int value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementBy8BitElementCount(long value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint SaturatingIncrementBy8BitElementCount(uint value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementBy8BitElementCount(ulong value, [ConstantExpected(Min = 1, Max = 16)] byte scale, [ConstantExpected] SveMaskPattern pattern = SveMaskPattern.All)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(int value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(long value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(uint value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(ulong value, Vector<byte> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SaturatingIncrementByActiveElementCount(Vector<short> value, Vector<short> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SaturatingIncrementByActiveElementCount(Vector<int> value, Vector<int> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SaturatingIncrementByActiveElementCount(Vector<long> value, Vector<long> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(int value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(long value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(uint value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(ulong value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SaturatingIncrementByActiveElementCount(Vector<ushort> value, Vector<ushort> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(int value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(long value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(uint value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(ulong value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SaturatingIncrementByActiveElementCount(Vector<uint> value, Vector<uint> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(int value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static long SaturatingIncrementByActiveElementCount(long value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(uint value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong SaturatingIncrementByActiveElementCount(ulong value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SaturatingIncrementByActiveElementCount(Vector<ulong> value, Vector<ulong> from)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Scale(Vector<double> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Scale(Vector<float> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<double> mask, double* address, Vector<long> indicies, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter(Vector<double> mask, Vector<ulong> addresses, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<double> mask, double* address, Vector<ulong> indicies, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<int> mask, int* address, Vector<int> indicies, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<int> mask, int* address, Vector<uint> indicies, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<long> mask, long* address, Vector<long> indicies, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter(Vector<long> mask, Vector<ulong> addresses, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<long> mask, long* address, Vector<ulong> indicies, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<float> mask, float* address, Vector<int> indicies, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<float> mask, float* address, Vector<uint> indicies, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<uint> mask, uint* address, Vector<int> indicies, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<uint> mask, uint* address, Vector<uint> indicies, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<ulong> mask, ulong* address, Vector<long> indicies, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter(Vector<ulong> mask, Vector<ulong> addresses, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter(Vector<ulong> mask, ulong* address, Vector<ulong> indicies, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter16BitNarrowing(Vector<long> mask, Vector<ulong> addresses, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter16BitNarrowing(Vector<ulong> mask, Vector<ulong> addresses, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<int> mask, short* address, Vector<int> indices, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<int> mask, short* address, Vector<uint> indices, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<long> mask, short* address, Vector<long> indices, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<long> mask, short* address, Vector<ulong> indices, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<uint> mask, ushort* address, Vector<int> indices, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<uint> mask, ushort* address, Vector<uint> indices, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<ulong> mask, ushort* address, Vector<long> indices, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitNarrowing(Vector<ulong> mask, ushort* address, Vector<ulong> indices, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<int> mask, short* address, Vector<int> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<int> mask, short* address, Vector<uint> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<long> mask, short* address, Vector<long> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<long> mask, short* address, Vector<ulong> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<uint> mask, ushort* address, Vector<int> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<uint> mask, ushort* address, Vector<uint> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<ulong> mask, ushort* address, Vector<long> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter16BitWithByteOffsetsNarrowing(Vector<ulong> mask, ushort* address, Vector<ulong> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter32BitNarrowing(Vector<long> mask, Vector<ulong> addresses, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter32BitNarrowing(Vector<ulong> mask, Vector<ulong> addresses, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitNarrowing(Vector<long> mask, int* address, Vector<long> indices, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitNarrowing(Vector<long> mask, int* address, Vector<ulong> indices, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitNarrowing(Vector<ulong> mask, uint* address, Vector<long> indices, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitNarrowing(Vector<ulong> mask, uint* address, Vector<ulong> indices, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitWithByteOffsetsNarrowing(Vector<long> mask, int* address, Vector<long> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitWithByteOffsetsNarrowing(Vector<long> mask, int* address, Vector<ulong> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitWithByteOffsetsNarrowing(Vector<ulong> mask, uint* address, Vector<long> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter32BitWithByteOffsetsNarrowing(Vector<ulong> mask, uint* address, Vector<ulong> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter8BitNarrowing(Vector<long> mask, Vector<ulong> addresses, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Scatter8BitNarrowing(Vector<ulong> mask, Vector<ulong> addresses, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<int> mask, sbyte* address, Vector<int> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<int> mask, sbyte* address, Vector<uint> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<long> mask, sbyte* address, Vector<long> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<long> mask, sbyte* address, Vector<ulong> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<uint> mask, byte* address, Vector<int> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<uint> mask, byte* address, Vector<uint> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<ulong> mask, byte* address, Vector<long> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Scatter8BitWithByteOffsetsNarrowing(Vector<ulong> mask, byte* address, Vector<ulong> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<double> mask, double* address, Vector<long> offsets, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<double> mask, double* address, Vector<ulong> offsets, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<int> mask, int* address, Vector<int> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<int> mask, int* address, Vector<uint> offsets, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<long> mask, long* address, Vector<long> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<long> mask, long* address, Vector<ulong> offsets, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<float> mask, float* address, Vector<int> offsets, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<float> mask, float* address, Vector<uint> offsets, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<uint> mask, uint* address, Vector<int> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<uint> mask, uint* address, Vector<uint> offsets, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<ulong> mask, ulong* address, Vector<long> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void ScatterWithByteOffsets(Vector<ulong> mask, ulong* address, Vector<ulong> offsets, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static void SetFfr(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLeftLogical(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLeftLogical(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftLeftLogical(Vector<short> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftLeftLogical(Vector<short> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftLeftLogical(Vector<int> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftLeftLogical(Vector<int> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftLeftLogical(Vector<long> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftLeftLogical(Vector<sbyte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftLeftLogical(Vector<sbyte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogical(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogical(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogical(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogical(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftLogical(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmetic(Vector<short> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmetic(Vector<short> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmetic(Vector<int> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmetic(Vector<int> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightArithmetic(Vector<long> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmetic(Vector<sbyte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmetic(Vector<sbyte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticForDivide(Vector<short> value, [ConstantExpected(Min = 1, Max = 16)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticForDivide(Vector<int> value, [ConstantExpected(Min = 1, Max = 32)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightArithmeticForDivide(Vector<long> value, [ConstantExpected(Min = 1, Max = 64)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticForDivide(Vector<sbyte> value, [ConstantExpected(Min = 1, Max = 8)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogical(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogical(Vector<byte> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogical(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogical(Vector<ushort> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogical(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogical(Vector<uint> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftRightLogical(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SignExtend16(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SignExtend16(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SignExtend32(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SignExtend8(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SignExtend8(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SignExtend8(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SignExtendWideningLower(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SignExtendWideningLower(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SignExtendWideningLower(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SignExtendWideningUpper(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SignExtendWideningUpper(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SignExtendWideningUpper(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Splice(Vector<byte> mask, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Splice(Vector<double> mask, Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Splice(Vector<short> mask, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Splice(Vector<int> mask, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Splice(Vector<long> mask, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Splice(Vector<sbyte> mask, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Splice(Vector<float> mask, Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Splice(Vector<ushort> mask, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Splice(Vector<uint> mask, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Splice(Vector<ulong> mask, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Sqrt(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Sqrt(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<byte> mask, byte* address, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<byte> mask, byte* address, (Vector<byte> Value1, Vector<byte> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<byte> mask, byte* address, (Vector<byte> Value1, Vector<byte> Value2, Vector<byte> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<byte> mask, byte* address, (Vector<byte> Value1, Vector<byte> Value2, Vector<byte> Value3, Vector<byte> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<double> mask, double* address, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<double> mask, double* address, (Vector<double> Value1, Vector<double> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<double> mask, double* address, (Vector<double> Value1, Vector<double> Value2, Vector<double> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<double> mask, double* address, (Vector<double> Value1, Vector<double> Value2, Vector<double> Value3, Vector<double> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<short> mask, short* address, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<short> mask, short* address, (Vector<short> Value1, Vector<short> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<short> mask, short* address, (Vector<short> Value1, Vector<short> Value2, Vector<short> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<short> mask, short* address, (Vector<short> Value1, Vector<short> Value2, Vector<short> Value3, Vector<short> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<int> mask, int* address, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<int> mask, int* address, (Vector<int> Value1, Vector<int> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<int> mask, int* address, (Vector<int> Value1, Vector<int> Value2, Vector<int> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<int> mask, int* address, (Vector<int> Value1, Vector<int> Value2, Vector<int> Value3, Vector<int> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<long> mask, long* address, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<long> mask, long* address, (Vector<long> Value1, Vector<long> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<long> mask, long* address, (Vector<long> Value1, Vector<long> Value2, Vector<long> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<long> mask, long* address, (Vector<long> Value1, Vector<long> Value2, Vector<long> Value3, Vector<long> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<sbyte> mask, sbyte* address, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<sbyte> mask, sbyte* address, (Vector<sbyte> Value1, Vector<sbyte> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<sbyte> mask, sbyte* address, (Vector<sbyte> Value1, Vector<sbyte> Value2, Vector<sbyte> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<sbyte> mask, sbyte* address, (Vector<sbyte> Value1, Vector<sbyte> Value2, Vector<sbyte> Value3, Vector<sbyte> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<float> mask, float* address, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<float> mask, float* address, (Vector<float> Value1, Vector<float> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<float> mask, float* address, (Vector<float> Value1, Vector<float> Value2, Vector<float> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<float> mask, float* address, (Vector<float> Value1, Vector<float> Value2, Vector<float> Value3, Vector<float> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ushort> mask, ushort* address, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ushort> mask, ushort* address, (Vector<ushort> Value1, Vector<ushort> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ushort> mask, ushort* address, (Vector<ushort> Value1, Vector<ushort> Value2, Vector<ushort> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ushort> mask, ushort* address, (Vector<ushort> Value1, Vector<ushort> Value2, Vector<ushort> Value3, Vector<ushort> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<uint> mask, uint* address, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<uint> mask, uint* address, (Vector<uint> Value1, Vector<uint> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<uint> mask, uint* address, (Vector<uint> Value1, Vector<uint> Value2, Vector<uint> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<uint> mask, uint* address, (Vector<uint> Value1, Vector<uint> Value2, Vector<uint> Value3, Vector<uint> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ulong> mask, ulong* address, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ulong> mask, ulong* address, (Vector<ulong> Value1, Vector<ulong> Value2) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ulong> mask, ulong* address, (Vector<ulong> Value1, Vector<ulong> Value2, Vector<ulong> Value3) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreAndZip(Vector<ulong> mask, ulong* address, (Vector<ulong> Value1, Vector<ulong> Value2, Vector<ulong> Value3, Vector<ulong> Value4) data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<short> mask, sbyte* address, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<int> mask, sbyte* address, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<int> mask, short* address, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<long> mask, sbyte* address, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<long> mask, short* address, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<long> mask, int* address, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<ushort> mask, byte* address, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<uint> mask, byte* address, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<uint> mask, ushort* address, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<ulong> mask, byte* address, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<ulong> mask, ushort* address, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNarrowing(Vector<ulong> mask, uint* address, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<byte> mask, byte* address, Vector<byte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<double> mask, double* address, Vector<double> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<short> mask, short* address, Vector<short> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<int> mask, int* address, Vector<int> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<long> mask, long* address, Vector<long> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<sbyte> mask, sbyte* address, Vector<sbyte> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<float> mask, float* address, Vector<float> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<ushort> mask, ushort* address, Vector<ushort> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<uint> mask, uint* address, Vector<uint> data)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreNonTemporal(Vector<ulong> mask, ulong* address, Vector<ulong> data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Subtract(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> Subtract(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Subtract(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Subtract(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Subtract(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Subtract(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> Subtract(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Subtract(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Subtract(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Subtract(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> SubtractSaturate(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractSaturate(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractSaturate(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractSaturate(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> SubtractSaturate(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractSaturate(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractSaturate(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractSaturate(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<byte> mask, Vector<byte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<short> mask, Vector<short> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<int> mask, Vector<int> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<long> mask, Vector<long> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<sbyte> mask, Vector<sbyte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<ushort> mask, Vector<ushort> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<uint> mask, Vector<uint> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestAnyTrue(Vector<ulong> mask, Vector<ulong> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<byte> leftMask, Vector<byte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<short> leftMask, Vector<short> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<int> leftMask, Vector<int> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<long> leftMask, Vector<long> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<sbyte> leftMask, Vector<sbyte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<ushort> leftMask, Vector<ushort> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<uint> leftMask, Vector<uint> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestFirstTrue(Vector<ulong> leftMask, Vector<ulong> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<byte> leftMask, Vector<byte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<short> leftMask, Vector<short> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<int> leftMask, Vector<int> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<long> leftMask, Vector<long> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<sbyte> leftMask, Vector<sbyte> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<ushort> leftMask, Vector<ushort> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<uint> leftMask, Vector<uint> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool TestLastTrue(Vector<ulong> leftMask, Vector<ulong> rightMask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> TransposeEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> TransposeEven(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> TransposeEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> TransposeEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> TransposeEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> TransposeEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> TransposeEven(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> TransposeEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> TransposeEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> TransposeEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> TransposeOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> TransposeOdd(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> TransposeOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> TransposeOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> TransposeOdd(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> TransposeOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> TransposeOdd(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> TransposeOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> TransposeOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> TransposeOdd(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> TrigonometricMultiplyAddCoefficient(Vector<double> left, Vector<double> right, [ConstantExpected(Min = 0, Max = 7)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> TrigonometricMultiplyAddCoefficient(Vector<float> left, Vector<float> right, [ConstantExpected(Min = 0, Max = 7)] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> TrigonometricSelectCoefficient(Vector<double> value, Vector<ulong> selector)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> TrigonometricSelectCoefficient(Vector<float> value, Vector<uint> selector)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> TrigonometricStartingValue(Vector<double> value, Vector<ulong> sign)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> TrigonometricStartingValue(Vector<float> value, Vector<uint> sign)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> UnzipEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> UnzipEven(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> UnzipEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> UnzipEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> UnzipEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> UnzipEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> UnzipEven(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> UnzipEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> UnzipEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> UnzipEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> UnzipOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> UnzipOdd(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> UnzipOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> UnzipOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> UnzipOdd(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> UnzipOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> UnzipOdd(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> UnzipOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> UnzipOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> UnzipOdd(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> VectorTableLookup(Vector<byte> data, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> VectorTableLookup(Vector<double> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> VectorTableLookup(Vector<short> data, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> VectorTableLookup(Vector<int> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> VectorTableLookup(Vector<long> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> VectorTableLookup(Vector<sbyte> data, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> VectorTableLookup(Vector<float> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> VectorTableLookup(Vector<ushort> data, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> VectorTableLookup(Vector<uint> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> VectorTableLookup(Vector<ulong> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Xor(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Xor(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Xor(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Xor(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Xor(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Xor(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Xor(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Xor(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> XorAcross(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> XorAcross(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> XorAcross(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> XorAcross(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> XorAcross(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> XorAcross(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> XorAcross(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> XorAcross(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZeroExtend16(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZeroExtend16(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZeroExtend32(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ZeroExtend8(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZeroExtend8(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZeroExtend8(Vector<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ZeroExtendWideningLower(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZeroExtendWideningLower(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZeroExtendWideningLower(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ZeroExtendWideningUpper(Vector<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZeroExtendWideningUpper(Vector<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZeroExtendWideningUpper(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ZipHigh(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ZipHigh(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ZipHigh(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ZipHigh(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ZipHigh(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ZipHigh(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ZipHigh(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ZipHigh(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZipHigh(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZipHigh(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ZipLow(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ZipLow(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ZipLow(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ZipLow(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ZipLow(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ZipLow(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ZipLow(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ZipLow(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ZipLow(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ZipLow(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}
}
