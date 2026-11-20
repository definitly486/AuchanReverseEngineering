using System.Numerics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace System.Buffers;

internal readonly struct ProbabilisticMap
{
	private readonly uint _e0;

	private readonly uint _e1;

	private readonly uint _e2;

	private readonly uint _e3;

	private readonly uint _e4;

	private readonly uint _e5;

	private readonly uint _e6;

	private readonly uint _e7;

	public ProbabilisticMap(ReadOnlySpan<char> values)
	{
		_e0 = 0u;
		_e1 = 0u;
		_e2 = 0u;
		_e3 = 0u;
		_e4 = 0u;
		_e5 = 0u;
		_e6 = 0u;
		_e7 = 0u;
		bool flag = false;
		ref readonly uint e = ref _e0;
		for (int i = 0; i < values.Length; i++)
		{
			int num = values[i];
			SetCharBit(ref e, (byte)num);
			num >>= 8;
			if (num == 0)
			{
				flag = true;
			}
			else
			{
				SetCharBit(ref e, (byte)num);
			}
		}
		if (flag)
		{
			SetCharBit(ref e, 0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BypassReadyToRun]
	private static void SetCharBit(ref uint charMap, byte value)
	{
		_ = 0;
		if (AdvSimd.Arm64.IsSupported)
		{
			Unsafe.Add(ref Unsafe.As<uint, byte>(ref charMap), (uint)(value & 0x1F)) |= (byte)(1 << (value >> 5));
		}
		else
		{
			Unsafe.Add(ref charMap, (uint)(value & 7)) |= (uint)(1 << (value >> 3));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BypassReadyToRun]
	private static bool IsCharBitSet(ref uint charMap, byte value)
	{
		_ = 0;
		if (!AdvSimd.Arm64.IsSupported)
		{
			return (Unsafe.Add(ref charMap, (uint)(value & 7)) & (uint)(1 << (value >> 3))) != 0;
		}
		return (Unsafe.Add(ref Unsafe.As<uint, byte>(ref charMap), (uint)(value & 0x1F)) & (1 << (value >> 5))) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool Contains(ref uint charMap, ReadOnlySpan<char> values, int ch)
	{
		if (IsCharBitSet(ref charMap, (byte)ch) && IsCharBitSet(ref charMap, (byte)(ch >> 8)))
		{
			return Contains(values, (char)ch);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool Contains(ReadOnlySpan<char> values, char ch)
	{
		return SpanHelpers.NonPackedContainsValueType(ref Unsafe.As<char, short>(ref MemoryMarshal.GetReference(values)), (short)ch, values.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> ContainsMask16Chars(Vector128<byte> charMapLower, Vector128<byte> charMapUpper, ref char searchSpace)
	{
		Vector128<ushort> vector = Vector128.LoadUnsafe(ref searchSpace);
		Vector128<ushort> vector2 = Vector128.LoadUnsafe(ref searchSpace, (nuint)Vector128<ushort>.Count);
		if (false)
		{
		}
		Vector128<byte> values;
		Vector128<byte> values2;
		if (AdvSimd.Arm64.IsSupported)
		{
			values = AdvSimd.Arm64.UnzipEven(vector.AsByte(), vector2.AsByte());
			values2 = AdvSimd.Arm64.UnzipOdd(vector.AsByte(), vector2.AsByte());
		}
		else
		{
			ThrowHelper.ThrowUnreachableException();
			values = default(Vector128<byte>);
			values2 = default(Vector128<byte>);
		}
		Vector128<byte> vector3 = IsCharBitNotSet(charMapLower, charMapUpper, values);
		Vector128<byte> vector4 = IsCharBitNotSet(charMapLower, charMapUpper, values2);
		return ~(vector3 | vector4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> IsCharBitNotSet(Vector128<byte> charMapLower, Vector128<byte> charMapUpper, Vector128<byte> values)
	{
		Vector128<byte> indices = values >>> 5;
		Vector128<byte> vector = Vector128.ShuffleNative(Vector128.Create(9241421688590303745uL).AsByte(), indices);
		Vector128<byte> vector2 = values & Vector128.Create((byte)31);
		Vector128<byte> vector3;
		if (AdvSimd.Arm64.IsSupported)
		{
			vector3 = AdvSimd.Arm64.VectorTableLookup((charMapLower, charMapUpper), vector2);
		}
		else
		{
			Vector128<byte> right = Vector128.ShuffleNative(charMapLower, vector2);
			Vector128<byte> left = Vector128.ShuffleNative(charMapUpper, vector2 - Vector128.Create((byte)16));
			vector3 = Vector128.ConditionalSelect(Vector128.GreaterThan(vector2, Vector128.Create((byte)15)), left, right);
		}
		return Vector128.Equals(vector3 & vector, Vector128<byte>.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool ShouldUseSimpleLoop(int searchSpaceLength, int valuesLength)
	{
		if (searchSpaceLength >= Vector128<short>.Count)
		{
			if (searchSpaceLength < 20)
			{
				return searchSpaceLength < valuesLength >> 1;
			}
			return false;
		}
		return true;
	}

	public static int IndexOfAny(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		if (ShouldUseSimpleLoop(searchSpaceLength, valuesLength))
		{
			return IndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, readOnlySpan);
		}
		if (IndexOfAnyAsciiSearcher.TryIndexOfAny(ref searchSpace, searchSpaceLength, readOnlySpan, out var index))
		{
			return index;
		}
		return ProbabilisticIndexOfAny(ref searchSpace, searchSpaceLength, ref values, valuesLength);
	}

	public static int IndexOfAnyExcept(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		if (IndexOfAnyAsciiSearcher.IsVectorizationSupported && !ShouldUseSimpleLoop(searchSpaceLength, valuesLength) && IndexOfAnyAsciiSearcher.TryIndexOfAnyExcept(ref searchSpace, searchSpaceLength, readOnlySpan, out var index))
		{
			return index;
		}
		return IndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.Negate>(ref searchSpace, searchSpaceLength, readOnlySpan);
	}

	public static int LastIndexOfAny(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		if (ShouldUseSimpleLoop(searchSpaceLength, valuesLength))
		{
			return LastIndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, readOnlySpan);
		}
		if (IndexOfAnyAsciiSearcher.TryLastIndexOfAny(ref searchSpace, searchSpaceLength, readOnlySpan, out var index))
		{
			return index;
		}
		return ProbabilisticLastIndexOfAny(ref searchSpace, searchSpaceLength, ref values, valuesLength);
	}

	public static int LastIndexOfAnyExcept(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		if (IndexOfAnyAsciiSearcher.IsVectorizationSupported && !ShouldUseSimpleLoop(searchSpaceLength, valuesLength) && IndexOfAnyAsciiSearcher.TryLastIndexOfAnyExcept(ref searchSpace, searchSpaceLength, readOnlySpan, out var index))
		{
			return index;
		}
		return LastIndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.Negate>(ref searchSpace, searchSpaceLength, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe static int ProbabilisticIndexOfAny(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		ProbabilisticMapState state = new ProbabilisticMapState(&readOnlySpan);
		return IndexOfAny<SearchValues.FalseConst>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe static int ProbabilisticLastIndexOfAny(ref char searchSpace, int searchSpaceLength, ref char values, int valuesLength)
	{
		ReadOnlySpan<char> readOnlySpan = new ReadOnlySpan<char>(ref values, valuesLength);
		ProbabilisticMapState state = new ProbabilisticMapState(&readOnlySpan);
		return LastIndexOfAny<SearchValues.FalseConst>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAny<TUseFastContains>(ref char searchSpace, int searchSpaceLength, ref ProbabilisticMapState state) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		_ = 0;
		if (AdvSimd.Arm64.IsSupported && searchSpaceLength >= 16)
		{
			if (false)
			{
			}
			return IndexOfAnyVectorized<TUseFastContains>(ref searchSpace, searchSpaceLength, ref state);
		}
		return ProbabilisticMapState.IndexOfAnySimpleLoop<TUseFastContains, IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAny<TUseFastContains>(ref char searchSpace, int searchSpaceLength, ref ProbabilisticMapState state) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		_ = 0;
		if (AdvSimd.Arm64.IsSupported && searchSpaceLength >= 16)
		{
			if (false)
			{
			}
			return LastIndexOfAnyVectorized<TUseFastContains>(ref searchSpace, searchSpaceLength, ref state);
		}
		return ProbabilisticMapState.LastIndexOfAnySimpleLoop<TUseFastContains, IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, ref state);
	}

	private static int IndexOfAnyVectorized<TUseFastContains>(ref char searchSpace, int searchSpaceLength, ref ProbabilisticMapState state) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		ref char reference = ref Unsafe.Add(ref searchSpace, searchSpaceLength);
		ref char reference2 = ref searchSpace;
		Vector128<byte> charMapLower = Vector128.LoadUnsafe(in Unsafe.As<ProbabilisticMap, byte>(ref state.Map));
		Vector128<byte> charMapUpper = Vector128.LoadUnsafe(in Unsafe.As<ProbabilisticMap, byte>(ref state.Map), (nuint)Vector128<byte>.Count);
		if (false)
		{
		}
		ref char reference3 = ref Unsafe.Subtract(ref reference, 16);
		while (true)
		{
			Vector128<byte> vector = ContainsMask16Chars(charMapLower, charMapUpper, ref reference2);
			if (vector != Vector128<byte>.Zero && TryFindMatch<TUseFastContains>(ref reference2, vector.ExtractMostSignificantBits(), ref state, out var index))
			{
				return MatchOffset(ref searchSpace, ref reference2) + index;
			}
			reference2 = ref Unsafe.Add(ref reference2, 16);
			if (Unsafe.IsAddressGreaterThan(in reference2, in reference3))
			{
				if (Unsafe.AreSame(in reference2, in reference))
				{
					break;
				}
				reference2 = ref reference3;
			}
		}
		return -1;
	}

	private static int LastIndexOfAnyVectorized<TUseFastContains>(ref char searchSpace, int searchSpaceLength, ref ProbabilisticMapState state) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		ref char reference = ref Unsafe.Add(ref searchSpace, searchSpaceLength);
		Vector128<byte> charMapLower = Vector128.LoadUnsafe(in Unsafe.As<ProbabilisticMap, byte>(ref state.Map));
		Vector128<byte> charMapUpper = Vector128.LoadUnsafe(in Unsafe.As<ProbabilisticMap, byte>(ref state.Map), (nuint)Vector128<byte>.Count);
		if (false)
		{
		}
		ref char reference2 = ref Unsafe.Add(ref searchSpace, 16);
		while (true)
		{
			reference = ref Unsafe.Subtract(ref reference, 16);
			Vector128<byte> vector = ContainsMask16Chars(charMapLower, charMapUpper, ref reference);
			if (vector != Vector128<byte>.Zero && TryFindLastMatch<TUseFastContains>(ref reference, vector.ExtractMostSignificantBits(), ref state, out var index))
			{
				return MatchOffset(ref searchSpace, ref reference) + index;
			}
			if (Unsafe.IsAddressLessThanOrEqualTo(in reference, in reference2))
			{
				if (Unsafe.AreSame(in reference, in searchSpace))
				{
					break;
				}
				reference = ref reference2;
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int MatchOffset(ref char searchSpace, ref char cur)
	{
		return (int)((nuint)Unsafe.ByteOffset(in searchSpace, in cur) / (nuint)2u);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryFindMatch<TUseFastContains>(ref char cur, uint mask, ref ProbabilisticMapState state, out int index) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		do
		{
			index = BitOperations.TrailingZeroCount(mask);
			if (state.ConfirmProbabilisticMatch<TUseFastContains>(Unsafe.Add(ref cur, index)))
			{
				return true;
			}
			mask = BitOperations.ResetLowestSetBit(mask);
		}
		while (mask != 0);
		index = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryFindLastMatch<TUseFastContains>(ref char cur, uint mask, ref ProbabilisticMapState state, out int index) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		do
		{
			index = 31 - BitOperations.LeadingZeroCount(mask);
			if (state.ConfirmProbabilisticMatch<TUseFastContains>(Unsafe.Add(ref cur, index)))
			{
				return true;
			}
			mask = BitOperations.FlipBit(mask, index);
		}
		while (mask != 0);
		index = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnySimpleLoop<TNegator>(ref char searchSpace, int searchSpaceLength, ReadOnlySpan<char> values) where TNegator : struct, IndexOfAnyAsciiSearcher.INegator
	{
		ref char right = ref Unsafe.Add(ref searchSpace, searchSpaceLength);
		ref char reference = ref searchSpace;
		while (!Unsafe.AreSame(in reference, in right))
		{
			char ch = reference;
			if (TNegator.NegateIfNeeded(Contains(values, ch)))
			{
				return MatchOffset(ref searchSpace, ref reference);
			}
			reference = ref Unsafe.Add(ref reference, 1);
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnySimpleLoop<TNegator>(ref char searchSpace, int searchSpaceLength, ReadOnlySpan<char> values) where TNegator : struct, IndexOfAnyAsciiSearcher.INegator
	{
		for (int num = searchSpaceLength - 1; num >= 0; num--)
		{
			char ch = Unsafe.Add(ref searchSpace, num);
			if (TNegator.NegateIfNeeded(Contains(values, ch)))
			{
				return num;
			}
		}
		return -1;
	}
}
