using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
[Experimental("SYSLIB5003", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
public abstract class Sve2 : Sve
{
	[Intrinsic]
	public new abstract class Arm64 : Sve.Arm64
	{
		public new static bool IsSupported => false;
	}

	public new static bool IsSupported => false;

	public static Vector<sbyte> AbsSaturate(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsSaturate(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsSaturate(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsSaturate(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AbsoluteDifferenceAdd(Vector<byte> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifferenceAdd(Vector<short> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifferenceAdd(Vector<int> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifferenceAdd(Vector<long> addend, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AbsoluteDifferenceAdd(Vector<sbyte> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifferenceAdd(Vector<ushort> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifferenceAdd(Vector<uint> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifferenceAdd(Vector<ulong> addend, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifferenceWideningLowerAndAddEven(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifferenceWideningLowerAndAddEven(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifferenceWideningLowerAndAddEven(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifferenceWideningLowerAndAddEven(Vector<ushort> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifferenceWideningLowerAndAddEven(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifferenceWideningLowerAndAddEven(Vector<ulong> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<ushort> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifferenceWideningLowerAndAddOdd(Vector<ulong> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifferenceWideningEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifferenceWideningEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifferenceWideningEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifferenceWideningEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifferenceWideningEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifferenceWideningEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AbsoluteDifferenceWideningOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AbsoluteDifferenceWideningOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AbsoluteDifferenceWideningOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AbsoluteDifferenceWideningOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AbsoluteDifferenceWideningOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AbsoluteDifferenceWideningOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddCarryWideningEven(Vector<uint> op1, Vector<uint> op2, Vector<uint> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddCarryWideningEven(Vector<ulong> op1, Vector<ulong> op2, Vector<ulong> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddCarryWideningOdd(Vector<uint> op1, Vector<uint> op2, Vector<uint> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddCarryWideningOdd(Vector<ulong> op1, Vector<ulong> op2, Vector<ulong> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddHighNarrowingEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddHighNarrowingEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddHighNarrowingEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddHighNarrowingEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddHighNarrowingEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddHighNarrowingEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddHighNarrowingOdd(Vector<byte> even, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddHighNarrowingOdd(Vector<short> even, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddHighNarrowingOdd(Vector<int> even, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddHighNarrowingOdd(Vector<sbyte> even, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddHighNarrowingOdd(Vector<ushort> even, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddHighNarrowingOdd(Vector<uint> even, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddPairwise(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> AddPairwise(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddPairwise(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddPairwise(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddPairwise(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddPairwise(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> AddPairwise(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddPairwise(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddPairwise(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddPairwise(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddPairwiseWideningAndAdd(Vector<short> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddPairwiseWideningAndAdd(Vector<int> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddPairwiseWideningAndAdd(Vector<long> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddPairwiseWideningAndAdd(Vector<ushort> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddPairwiseWideningAndAdd(Vector<uint> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddPairwiseWideningAndAdd(Vector<ulong> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddRotateComplex(Vector<byte> left, Vector<byte> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddRotateComplex(Vector<short> left, Vector<short> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddRotateComplex(Vector<int> left, Vector<int> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddRotateComplex(Vector<long> left, Vector<long> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddRotateComplex(Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddRotateComplex(Vector<ushort> left, Vector<ushort> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddRotateComplex(Vector<uint> left, Vector<uint> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddRotateComplex(Vector<ulong> left, Vector<ulong> right, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddRoundedHighNarrowingEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddRoundedHighNarrowingEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddRoundedHighNarrowingEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddRoundedHighNarrowingEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddRoundedHighNarrowingEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddRoundedHighNarrowingEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddRoundedHighNarrowingOdd(Vector<byte> even, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddRoundedHighNarrowingOdd(Vector<short> even, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddRoundedHighNarrowingOdd(Vector<int> even, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddRoundedHighNarrowingOdd(Vector<sbyte> even, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddRoundedHighNarrowingOdd(Vector<ushort> even, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddRoundedHighNarrowingOdd(Vector<uint> even, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<byte> AddSaturate(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<short> AddSaturate(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<int> AddSaturate(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<long> AddSaturate(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<sbyte> AddSaturate(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<ushort> AddSaturate(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<uint> AddSaturate(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<ulong> AddSaturate(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddSaturateRotateComplex(Vector<short> op1, Vector<short> op2, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddSaturateRotateComplex(Vector<int> op1, Vector<int> op2, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddSaturateRotateComplex(Vector<long> op1, Vector<long> op2, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddSaturateRotateComplex(Vector<sbyte> op1, Vector<sbyte> op2, [ConstantExpected(Min = 0, Max = 1)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> AddSaturateWithSignedAddend(Vector<byte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddSaturateWithSignedAddend(Vector<ushort> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddSaturateWithSignedAddend(Vector<uint> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddSaturateWithSignedAddend(Vector<ulong> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> AddSaturateWithUnsignedAddend(Vector<sbyte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddSaturateWithUnsignedAddend(Vector<short> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddSaturateWithUnsignedAddend(Vector<int> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddSaturateWithUnsignedAddend(Vector<long> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddWideningEven(Vector<short> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddWideningEven(Vector<int> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddWideningEven(Vector<long> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddWideningEven(Vector<ushort> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddWideningEven(Vector<uint> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddWideningEven(Vector<ulong> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddWideningEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddWideningEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddWideningEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddWideningEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddWideningEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddWideningEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddWideningEvenOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddWideningEvenOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddWideningEvenOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddWideningOdd(Vector<short> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddWideningOdd(Vector<int> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddWideningOdd(Vector<long> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddWideningOdd(Vector<ushort> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddWideningOdd(Vector<uint> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddWideningOdd(Vector<ulong> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> AddWideningOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> AddWideningOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> AddWideningOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> AddWideningOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> AddWideningOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> AddWideningOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BitwiseClearXor(Vector<byte> xor, Vector<byte> value, Vector<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BitwiseClearXor(Vector<short> xor, Vector<short> value, Vector<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BitwiseClearXor(Vector<int> xor, Vector<int> value, Vector<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BitwiseClearXor(Vector<long> xor, Vector<long> value, Vector<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BitwiseClearXor(Vector<sbyte> xor, Vector<sbyte> value, Vector<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BitwiseClearXor(Vector<ushort> xor, Vector<ushort> value, Vector<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BitwiseClearXor(Vector<uint> xor, Vector<uint> value, Vector<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BitwiseClearXor(Vector<ulong> xor, Vector<ulong> value, Vector<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BitwiseSelect(Vector<byte> select, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BitwiseSelect(Vector<short> select, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BitwiseSelect(Vector<int> select, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BitwiseSelect(Vector<long> select, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BitwiseSelect(Vector<sbyte> select, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BitwiseSelect(Vector<ushort> select, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BitwiseSelect(Vector<uint> select, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BitwiseSelect(Vector<ulong> select, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BitwiseSelectLeftInverted(Vector<byte> select, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BitwiseSelectLeftInverted(Vector<short> select, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BitwiseSelectLeftInverted(Vector<int> select, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BitwiseSelectLeftInverted(Vector<long> select, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BitwiseSelectLeftInverted(Vector<sbyte> select, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BitwiseSelectLeftInverted(Vector<ushort> select, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BitwiseSelectLeftInverted(Vector<uint> select, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BitwiseSelectLeftInverted(Vector<ulong> select, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> BitwiseSelectRightInverted(Vector<byte> select, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> BitwiseSelectRightInverted(Vector<short> select, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> BitwiseSelectRightInverted(Vector<int> select, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> BitwiseSelectRightInverted(Vector<long> select, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> BitwiseSelectRightInverted(Vector<sbyte> select, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> BitwiseSelectRightInverted(Vector<ushort> select, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> BitwiseSelectRightInverted(Vector<uint> select, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> BitwiseSelectRightInverted(Vector<ulong> select, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> DotProductRotateComplex(Vector<int> op1, Vector<sbyte> op2, Vector<sbyte> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> DotProductRotateComplex(Vector<long> op1, Vector<short> op2, Vector<short> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> DotProductRotateComplexBySelectedIndex(Vector<int> op1, Vector<sbyte> op2, Vector<sbyte> op3, [ConstantExpected(Min = 0, Max = 3)] byte imm_index, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> DotProductRotateComplexBySelectedIndex(Vector<long> op1, Vector<short> op2, Vector<short> op3, [ConstantExpected(Min = 0, Max = 1)] byte imm_index, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> ConvertToDoubleOdd(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> ConvertToSingleEvenRoundToOdd(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> FusedAddHalving(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> FusedAddHalving(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> FusedAddHalving(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> FusedAddHalving(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> FusedAddHalving(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> FusedAddHalving(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> FusedAddHalving(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> FusedAddHalving(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> FusedSubtractHalving(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> FusedSubtractHalving(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> FusedSubtractHalving(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> FusedSubtractHalving(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> FusedSubtractHalving(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> FusedSubtractHalving(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> FusedSubtractHalving(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> FusedSubtractHalving(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> FusedAddRoundedHalving(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> FusedAddRoundedHalving(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> FusedAddRoundedHalving(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> FusedAddRoundedHalving(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> FusedAddRoundedHalving(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> FusedAddRoundedHalving(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> FusedAddRoundedHalving(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> FusedAddRoundedHalving(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> InterleavingXorEvenOdd(Vector<byte> odd, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> InterleavingXorEvenOdd(Vector<short> odd, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> InterleavingXorEvenOdd(Vector<int> odd, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> InterleavingXorEvenOdd(Vector<long> odd, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> InterleavingXorEvenOdd(Vector<sbyte> odd, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> InterleavingXorEvenOdd(Vector<ushort> odd, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> InterleavingXorEvenOdd(Vector<uint> odd, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> InterleavingXorEvenOdd(Vector<ulong> odd, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> InterleavingXorOddEven(Vector<byte> even, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> InterleavingXorOddEven(Vector<short> even, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> InterleavingXorOddEven(Vector<int> even, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> InterleavingXorOddEven(Vector<long> even, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> InterleavingXorOddEven(Vector<sbyte> even, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> InterleavingXorOddEven(Vector<ushort> even, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> InterleavingXorOddEven(Vector<uint> even, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> InterleavingXorOddEven(Vector<ulong> even, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Log2(Vector<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Log2(Vector<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MaxNumberPairwise(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MaxNumberPairwise(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MaxPairwise(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MaxPairwise(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MaxPairwise(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MaxPairwise(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MaxPairwise(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MaxPairwise(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MaxPairwise(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MaxPairwise(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MaxPairwise(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MaxPairwise(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MinNumberPairwise(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MinNumberPairwise(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MinPairwise(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> MinPairwise(Vector<double> left, Vector<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MinPairwise(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MinPairwise(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MinPairwise(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MinPairwise(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> MinPairwise(Vector<float> left, Vector<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MinPairwise(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MinPairwise(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MinPairwise(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAddBySelectedScalar(Vector<short> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAddBySelectedScalar(Vector<int> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyAddBySelectedScalar(Vector<long> addend, Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyAddBySelectedScalar(Vector<ushort> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyAddBySelectedScalar(Vector<uint> addend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyAddBySelectedScalar(Vector<ulong> addend, Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> MultiplyAddRotateComplex(Vector<byte> addend, Vector<byte> left, Vector<byte> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAddRotateComplex(Vector<short> addend, Vector<short> left, Vector<short> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAddRotateComplex(Vector<int> addend, Vector<int> left, Vector<int> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyAddRotateComplex(Vector<long> addend, Vector<long> left, Vector<long> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyAddRotateComplex(Vector<sbyte> addend, Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyAddRotateComplex(Vector<ushort> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyAddRotateComplex(Vector<uint> addend, Vector<uint> left, Vector<uint> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyAddRotateComplex(Vector<ulong> addend, Vector<ulong> left, Vector<ulong> right, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAddRotateComplexBySelectedScalar(Vector<short> addend, Vector<short> left, Vector<short> right, [ConstantExpected(Min = 0, Max = 3)] byte rightIndex, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAddRotateComplexBySelectedScalar(Vector<int> addend, Vector<int> left, Vector<int> right, [ConstantExpected(Min = 0, Max = 1)] byte rightIndex, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyAddRotateComplexBySelectedScalar(Vector<ushort> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected(Min = 0, Max = 3)] byte rightIndex, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyAddRotateComplexBySelectedScalar(Vector<uint> addend, Vector<uint> left, Vector<uint> right, [ConstantExpected(Min = 0, Max = 1)] byte rightIndex, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAddRoundedDoublingSaturateHighRotateComplex(Vector<short> op1, Vector<short> op2, Vector<short> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAddRoundedDoublingSaturateHighRotateComplex(Vector<int> op1, Vector<int> op2, Vector<int> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyAddRoundedDoublingSaturateHighRotateComplex(Vector<long> op1, Vector<long> op2, Vector<long> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyAddRoundedDoublingSaturateHighRotateComplex(Vector<sbyte> op1, Vector<sbyte> op2, Vector<sbyte> op3, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyAddRoundedDoublingSaturateHighRotateComplexBySelectedScalar(Vector<short> op1, Vector<short> op2, Vector<short> op3, [ConstantExpected(Min = 0, Max = 3)] byte imm_index, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyAddRoundedDoublingSaturateHighRotateComplexBySelectedScalar(Vector<int> op1, Vector<int> op2, Vector<int> op3, [ConstantExpected(Min = 0, Max = 1)] byte imm_index, [ConstantExpected(Min = 0, Max = 3)] byte rotation)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningEvenAndAdd(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningEvenAndAdd(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningEvenAndAdd(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningEvenAndAdd(Vector<ushort> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningEvenAndAdd(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningEvenAndAdd(Vector<ulong> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningEvenAndAdd(Vector<int> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningEvenAndAdd(Vector<long> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningEvenAndAdd(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningEvenAndAdd(Vector<ulong> addend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningOddAndAdd(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningOddAndAdd(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningOddAndAdd(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningOddAndAdd(Vector<ushort> addend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningOddAndAdd(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningOddAndAdd(Vector<ulong> addend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningOddAndAdd(Vector<int> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningOddAndAdd(Vector<long> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningOddAndAdd(Vector<uint> addend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningOddAndAdd(Vector<ulong> addend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyBySelectedScalar(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalar(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalar(Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyBySelectedScalar(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalar(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalar(Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplySubtractBySelectedScalar(Vector<short> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplySubtractBySelectedScalar(Vector<int> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplySubtractBySelectedScalar(Vector<long> minuend, Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplySubtractBySelectedScalar(Vector<ushort> minuend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplySubtractBySelectedScalar(Vector<uint> minuend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplySubtractBySelectedScalar(Vector<ulong> minuend, Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningEvenAndSubtract(Vector<short> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningEvenAndSubtract(Vector<int> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningEvenAndSubtract(Vector<long> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningEvenAndSubtract(Vector<ushort> minuend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningEvenAndSubtract(Vector<uint> minuend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningEvenAndSubtract(Vector<ulong> minuend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningEvenAndSubtract(Vector<int> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningEvenAndSubtract(Vector<long> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningEvenAndSubtract(Vector<uint> minuend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningEvenAndSubtract(Vector<ulong> minuend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningOddAndSubtract(Vector<short> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningOddAndSubtract(Vector<int> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningOddAndSubtract(Vector<long> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningOddAndSubtract(Vector<ushort> minuend, Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningOddAndSubtract(Vector<uint> minuend, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningOddAndSubtract(Vector<ulong> minuend, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningOddAndSubtract(Vector<int> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningOddAndSubtract(Vector<long> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningOddAndSubtract(Vector<uint> minuend, Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningOddAndSubtract(Vector<ulong> minuend, Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingBySelectedScalarSaturateHigh(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingBySelectedScalarSaturateHigh(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingBySelectedScalarSaturateHigh(Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyDoublingSaturateHigh(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingSaturateHigh(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingSaturateHigh(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingSaturateHigh(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningEven(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningEven(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningEven(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningEven(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyWideningOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyWideningOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyWideningOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> MultiplyWideningOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyWideningOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyWideningOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyBySelectedScalarWideningOdd(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyBySelectedScalarWideningOdd(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> MultiplyBySelectedScalarWideningOdd(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> MultiplyBySelectedScalarWideningOdd(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> PolynomialMultiply(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> PolynomialMultiply(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> PolynomialMultiplyWideningEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> PolynomialMultiplyWideningEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> PolynomialMultiplyWideningOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> PolynomialMultiplyWideningOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndAddSaturateEven(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndAddSaturateEven(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndAddSaturateEven(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndAddSaturateEvenOdd(Vector<short> addend, Vector<sbyte> leftEven, Vector<sbyte> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndAddSaturateEvenOdd(Vector<int> addend, Vector<short> leftEven, Vector<short> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndAddSaturateEvenOdd(Vector<long> addend, Vector<int> leftEven, Vector<int> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndAddSaturateOdd(Vector<short> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndAddSaturateOdd(Vector<int> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndAddSaturateOdd(Vector<long> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndSubtractSaturateEven(Vector<short> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndSubtractSaturateEven(Vector<int> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndSubtractSaturateEven(Vector<long> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndSubtractSaturateEvenOdd(Vector<short> minuend, Vector<sbyte> leftEven, Vector<sbyte> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndSubtractSaturateEvenOdd(Vector<int> minuend, Vector<short> leftEven, Vector<short> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndSubtractSaturateEvenOdd(Vector<long> minuend, Vector<int> leftEven, Vector<int> rightOdd)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningAndSubtractSaturateOdd(Vector<short> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningAndSubtractSaturateOdd(Vector<int> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningAndSubtractSaturateOdd(Vector<long> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningBySelectedScalarAndAddSaturateEven(Vector<int> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningBySelectedScalarAndAddSaturateEven(Vector<long> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningBySelectedScalarAndAddSaturateOdd(Vector<int> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningBySelectedScalarAndAddSaturateOdd(Vector<long> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningBySelectedScalarAndSubtractSaturateEven(Vector<int> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningBySelectedScalarAndSubtractSaturateEven(Vector<long> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningBySelectedScalarAndSubtractSaturateOdd(Vector<int> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningBySelectedScalarAndSubtractSaturateOdd(Vector<long> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningSaturateEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningSaturateEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningSaturateEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningSaturateEvenBySelectedScalar(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningSaturateEvenBySelectedScalar(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyDoublingWideningSaturateOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningSaturateOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningSaturateOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyDoublingWideningSaturateOddBySelectedScalar(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyDoublingWideningSaturateOddBySelectedScalar(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyRoundedDoublingSaturateAndAddHigh(Vector<sbyte> addend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingSaturateAndAddHigh(Vector<short> addend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingSaturateAndAddHigh(Vector<int> addend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingSaturateAndAddHigh(Vector<long> addend, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyRoundedDoublingSaturateAndSubtractHigh(Vector<sbyte> minuend, Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingSaturateAndSubtractHigh(Vector<short> minuend, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingSaturateAndSubtractHigh(Vector<int> minuend, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingSaturateAndSubtractHigh(Vector<long> minuend, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingSaturateBySelectedScalarAndAddHigh(Vector<short> addend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingSaturateBySelectedScalarAndAddHigh(Vector<int> addend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingSaturateBySelectedScalarAndAddHigh(Vector<long> addend, Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingSaturateBySelectedScalarAndSubtractHigh(Vector<short> minuend, Vector<short> left, Vector<short> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingSaturateBySelectedScalarAndSubtractHigh(Vector<int> minuend, Vector<int> left, Vector<int> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingSaturateBySelectedScalarAndSubtractHigh(Vector<long> minuend, Vector<long> left, Vector<long> right, [ConstantExpected] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> MultiplyRoundedDoublingSaturateHigh(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> MultiplyRoundedDoublingSaturateHigh(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> MultiplyRoundedDoublingSaturateHigh(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> MultiplyRoundedDoublingSaturateHigh(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> NegateSaturate(Vector<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> NegateSaturate(Vector<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> NegateSaturate(Vector<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> NegateSaturate(Vector<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReciprocalEstimate(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ReciprocalSqrtEstimate(Vector<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftArithmeticRounded(Vector<short> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftArithmeticRounded(Vector<int> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftArithmeticRounded(Vector<long> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftArithmeticRounded(Vector<sbyte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftArithmeticRoundedSaturate(Vector<short> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftArithmeticRoundedSaturate(Vector<int> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftArithmeticRoundedSaturate(Vector<long> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftArithmeticRoundedSaturate(Vector<sbyte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftArithmeticSaturate(Vector<short> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftArithmeticSaturate(Vector<int> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftArithmeticSaturate(Vector<long> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftArithmeticSaturate(Vector<sbyte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLeftAndInsert(Vector<byte> left, Vector<byte> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftLeftAndInsert(Vector<short> left, Vector<short> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftLeftAndInsert(Vector<int> left, Vector<int> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftLeftAndInsert(Vector<long> left, Vector<long> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftLeftAndInsert(Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftAndInsert(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftAndInsert(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftAndInsert(Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLeftLogicalSaturate(Vector<byte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogicalSaturate(Vector<ushort> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogicalSaturate(Vector<uint> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftLogicalSaturate(Vector<ulong> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLeftLogicalSaturateUnsigned(Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogicalSaturateUnsigned(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogicalSaturateUnsigned(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftLogicalSaturateUnsigned(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftLeftLogicalWideningEven(Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftLeftLogicalWideningEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftLeftLogicalWideningEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogicalWideningEven(Vector<byte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogicalWideningEven(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftLogicalWideningEven(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftLeftLogicalWideningOdd(Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftLeftLogicalWideningOdd(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftLeftLogicalWideningOdd(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLeftLogicalWideningOdd(Vector<byte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLeftLogicalWideningOdd(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLeftLogicalWideningOdd(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLogicalRounded(Vector<byte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLogicalRounded(Vector<ushort> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLogicalRounded(Vector<uint> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLogicalRounded(Vector<ulong> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftLogicalRoundedSaturate(Vector<byte> value, Vector<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftLogicalRoundedSaturate(Vector<ushort> value, Vector<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftLogicalRoundedSaturate(Vector<uint> value, Vector<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftLogicalRoundedSaturate(Vector<ulong> value, Vector<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightAndInsert(Vector<byte> left, Vector<byte> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightAndInsert(Vector<short> left, Vector<short> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightAndInsert(Vector<int> left, Vector<int> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightAndInsert(Vector<long> left, Vector<long> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightAndInsert(Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightAndInsert(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightAndInsert(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftRightAndInsert(Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticAdd(Vector<short> addend, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticAdd(Vector<int> addend, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightArithmeticAdd(Vector<long> addend, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticAdd(Vector<sbyte> addend, Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticNarrowingSaturateEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticNarrowingSaturateEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticNarrowingSaturateEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticNarrowingSaturateOdd(Vector<short> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticNarrowingSaturateOdd(Vector<int> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticNarrowingSaturateOdd(Vector<sbyte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightArithmeticNarrowingSaturateUnsignedEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightArithmeticNarrowingSaturateUnsignedEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightArithmeticNarrowingSaturateUnsignedEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightArithmeticNarrowingSaturateUnsignedOdd(Vector<byte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightArithmeticNarrowingSaturateUnsignedOdd(Vector<ushort> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightArithmeticNarrowingSaturateUnsignedOdd(Vector<uint> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticRounded(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticRounded(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightArithmeticRounded(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticRounded(Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticRoundedAdd(Vector<short> addend, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticRoundedAdd(Vector<int> addend, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> ShiftRightArithmeticRoundedAdd(Vector<long> addend, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticRoundedAdd(Vector<sbyte> addend, Vector<sbyte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticRoundedNarrowingSaturateEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticRoundedNarrowingSaturateEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticRoundedNarrowingSaturateEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightArithmeticRoundedNarrowingSaturateOdd(Vector<short> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightArithmeticRoundedNarrowingSaturateOdd(Vector<int> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightArithmeticRoundedNarrowingSaturateOdd(Vector<sbyte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedOdd(Vector<byte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedOdd(Vector<ushort> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedOdd(Vector<uint> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalAdd(Vector<byte> addend, Vector<byte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalAdd(Vector<ushort> addend, Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalAdd(Vector<uint> addend, Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftRightLogicalAdd(Vector<ulong> addend, Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalNarrowingEven(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightLogicalNarrowingEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightLogicalNarrowingEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightLogicalNarrowingEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalNarrowingEven(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalNarrowingEven(Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalNarrowingOdd(Vector<byte> even, Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightLogicalNarrowingOdd(Vector<short> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightLogicalNarrowingOdd(Vector<int> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightLogicalNarrowingOdd(Vector<sbyte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalNarrowingOdd(Vector<ushort> even, Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalNarrowingOdd(Vector<uint> even, Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRounded(Vector<byte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRounded(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRounded(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftRightLogicalRounded(Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRoundedAdd(Vector<byte> addend, Vector<byte> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRoundedAdd(Vector<ushort> addend, Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRoundedAdd(Vector<uint> addend, Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> ShiftRightLogicalRoundedAdd(Vector<ulong> addend, Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRoundedNarrowingEven(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightLogicalRoundedNarrowingEven(Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightLogicalRoundedNarrowingEven(Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightLogicalRoundedNarrowingEven(Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRoundedNarrowingEven(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRoundedNarrowingEven(Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRoundedNarrowingOdd(Vector<byte> even, Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> ShiftRightLogicalRoundedNarrowingOdd(Vector<short> even, Vector<int> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> ShiftRightLogicalRoundedNarrowingOdd(Vector<int> even, Vector<long> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> ShiftRightLogicalRoundedNarrowingOdd(Vector<sbyte> even, Vector<short> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRoundedNarrowingOdd(Vector<ushort> even, Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRoundedNarrowingOdd(Vector<uint> even, Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRoundedNarrowingSaturateEven(Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRoundedNarrowingSaturateEven(Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRoundedNarrowingSaturateEven(Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> ShiftRightLogicalRoundedNarrowingSaturateOdd(Vector<byte> even, Vector<ushort> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> ShiftRightLogicalRoundedNarrowingSaturateOdd(Vector<ushort> even, Vector<uint> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> ShiftRightLogicalRoundedNarrowingSaturateOdd(Vector<uint> even, Vector<ulong> value, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractBorrowWideningEven(Vector<uint> op1, Vector<uint> op2, Vector<uint> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractBorrowWideningEven(Vector<ulong> op1, Vector<ulong> op2, Vector<ulong> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractBorrowWideningOdd(Vector<uint> op1, Vector<uint> op2, Vector<uint> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractBorrowWideningOdd(Vector<ulong> op1, Vector<ulong> op2, Vector<ulong> op3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> SubtractHighNarrowingEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractHighNarrowingEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractHighNarrowingEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> SubtractHighNarrowingEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractHighNarrowingEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractHighNarrowingEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> SubtractHighNarrowingOdd(Vector<byte> even, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractHighNarrowingOdd(Vector<short> even, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractHighNarrowingOdd(Vector<int> even, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> SubtractHighNarrowingOdd(Vector<sbyte> even, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractHighNarrowingOdd(Vector<ushort> even, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractHighNarrowingOdd(Vector<uint> even, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> SubtractRoundedHighNarrowingEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractRoundedHighNarrowingEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractRoundedHighNarrowingEven(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> SubtractRoundedHighNarrowingEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractRoundedHighNarrowingEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractRoundedHighNarrowingEven(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> SubtractRoundedHighNarrowingOdd(Vector<byte> even, Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractRoundedHighNarrowingOdd(Vector<short> even, Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractRoundedHighNarrowingOdd(Vector<int> even, Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> SubtractRoundedHighNarrowingOdd(Vector<sbyte> even, Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractRoundedHighNarrowingOdd(Vector<ushort> even, Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractRoundedHighNarrowingOdd(Vector<uint> even, Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<byte> SubtractSaturate(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<short> SubtractSaturate(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<int> SubtractSaturate(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<long> SubtractSaturate(Vector<long> left, Vector<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<sbyte> SubtractSaturate(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<ushort> SubtractSaturate(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<uint> SubtractSaturate(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public new static Vector<ulong> SubtractSaturate(Vector<ulong> left, Vector<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningEven(Vector<short> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningEven(Vector<int> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningEven(Vector<long> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractWideningEven(Vector<ushort> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractWideningEven(Vector<uint> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractWideningEven(Vector<ulong> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractWideningEven(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractWideningEven(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractWideningEven(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningEvenOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningEvenOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningEvenOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningOdd(Vector<short> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningOdd(Vector<int> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningOdd(Vector<long> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractWideningOdd(Vector<ushort> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractWideningOdd(Vector<uint> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractWideningOdd(Vector<ulong> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningOdd(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningOdd(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningOdd(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> SubtractWideningOdd(Vector<byte> left, Vector<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> SubtractWideningOdd(Vector<ushort> left, Vector<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> SubtractWideningOdd(Vector<uint> left, Vector<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> SubtractWideningOddEven(Vector<sbyte> left, Vector<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> SubtractWideningOddEven(Vector<short> left, Vector<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> SubtractWideningOddEven(Vector<int> left, Vector<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> VectorTableLookup((Vector<byte> data1, Vector<byte> data2) table, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> VectorTableLookup((Vector<ushort> data1, Vector<ushort> data2) table, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> VectorTableLookup((Vector<uint> data1, Vector<uint> data2) table, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> VectorTableLookup((Vector<ulong> data1, Vector<ulong> data2) table, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> VectorTableLookup((Vector<float> data1, Vector<float> data2) table, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> VectorTableLookup((Vector<double> data1, Vector<double> data2) table, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> VectorTableLookup((Vector<sbyte> data1, Vector<sbyte> data2) table, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> VectorTableLookup((Vector<short> data1, Vector<short> data2) table, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> VectorTableLookup((Vector<int> data1, Vector<int> data2) table, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> VectorTableLookup((Vector<long> data1, Vector<long> data2) table, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> VectorTableLookupExtension(Vector<byte> defaultValues, Vector<byte> data, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> VectorTableLookupExtension(Vector<ushort> defaultValues, Vector<ushort> data, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> VectorTableLookupExtension(Vector<uint> defaultValues, Vector<uint> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> VectorTableLookupExtension(Vector<ulong> defaultValues, Vector<ulong> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<float> VectorTableLookupExtension(Vector<float> defaultValues, Vector<float> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<double> VectorTableLookupExtension(Vector<double> defaultValues, Vector<double> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> VectorTableLookupExtension(Vector<sbyte> defaultValues, Vector<sbyte> data, Vector<byte> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> VectorTableLookupExtension(Vector<short> defaultValues, Vector<short> data, Vector<ushort> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> VectorTableLookupExtension(Vector<int> defaultValues, Vector<int> data, Vector<uint> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> VectorTableLookupExtension(Vector<long> defaultValues, Vector<long> data, Vector<ulong> indices)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> Xor(Vector<byte> value1, Vector<byte> value2, Vector<byte> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> Xor(Vector<short> value1, Vector<short> value2, Vector<short> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> Xor(Vector<int> value1, Vector<int> value2, Vector<int> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> Xor(Vector<long> value1, Vector<long> value2, Vector<long> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> Xor(Vector<sbyte> value1, Vector<sbyte> value2, Vector<sbyte> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> Xor(Vector<ushort> value1, Vector<ushort> value2, Vector<ushort> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> Xor(Vector<uint> value1, Vector<uint> value2, Vector<uint> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> Xor(Vector<ulong> value1, Vector<ulong> value2, Vector<ulong> value3)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<byte> XorRotateRight(Vector<byte> left, Vector<byte> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<short> XorRotateRight(Vector<short> left, Vector<short> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<int> XorRotateRight(Vector<int> left, Vector<int> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<long> XorRotateRight(Vector<long> left, Vector<long> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<sbyte> XorRotateRight(Vector<sbyte> left, Vector<sbyte> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ushort> XorRotateRight(Vector<ushort> left, Vector<ushort> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<uint> XorRotateRight(Vector<uint> left, Vector<uint> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector<ulong> XorRotateRight(Vector<ulong> left, Vector<ulong> right, [ConstantExpected] byte count)
	{
		throw new PlatformNotSupportedException();
	}
}
