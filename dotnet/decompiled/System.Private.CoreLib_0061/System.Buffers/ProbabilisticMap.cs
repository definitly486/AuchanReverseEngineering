using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

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
		if (false)
		{
		}
		Unsafe.Add(ref charMap, (uint)(value & 7)) |= (uint)(1 << (value >> 3));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BypassReadyToRun]
	private static bool IsCharBitSet(ref uint charMap, byte value)
	{
		_ = 0;
		_ = 0;
		return (Unsafe.Add(ref charMap, (uint)(value & 7)) & (uint)(1 << (value >> 3))) != 0;
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
		ReadOnlySpan<char> values2 = new ReadOnlySpan<char>(ref values, valuesLength);
		if (false)
		{
		}
		return IndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.Negate>(ref searchSpace, searchSpaceLength, values2);
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
		ReadOnlySpan<char> values2 = new ReadOnlySpan<char>(ref values, valuesLength);
		if (false)
		{
		}
		return LastIndexOfAnySimpleLoop<IndexOfAnyAsciiSearcher.Negate>(ref searchSpace, searchSpaceLength, values2);
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
		if (false)
		{
		}
		return ProbabilisticMapState.IndexOfAnySimpleLoop<TUseFastContains, IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAny<TUseFastContains>(ref char searchSpace, int searchSpaceLength, ref ProbabilisticMapState state) where TUseFastContains : struct, SearchValues.IRuntimeConst
	{
		_ = 0;
		if (false)
		{
		}
		return ProbabilisticMapState.LastIndexOfAnySimpleLoop<TUseFastContains, IndexOfAnyAsciiSearcher.DontNegate>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int MatchOffset(ref char searchSpace, ref char cur)
	{
		return (int)((nuint)Unsafe.ByteOffset(in searchSpace, in cur) / (nuint)2u);
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
