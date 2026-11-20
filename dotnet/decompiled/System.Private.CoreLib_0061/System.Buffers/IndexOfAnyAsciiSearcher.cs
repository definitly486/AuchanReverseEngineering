using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System.Buffers;

internal static class IndexOfAnyAsciiSearcher
{
	public struct AsciiState
	{
		public Vector256<byte> Bitmap;

		public readonly BitVector256 Lookup;
	}

	public readonly struct AnyByteState
	{
		public readonly Vector256<byte> Bitmap0;

		public readonly Vector256<byte> Bitmap1;

		public readonly BitVector256 Lookup;

		public AnyByteState(Vector128<byte> bitmap0, Vector128<byte> bitmap1, BitVector256 lookup)
		{
			Bitmap0 = Vector256.Create(bitmap0);
			Bitmap1 = Vector256.Create(bitmap1);
			Lookup = lookup;
		}
	}

	internal interface INegator
	{
		static abstract bool NegateIfNeeded(bool result);

		static abstract Vector128<byte> NegateIfNeeded(Vector128<byte> result);

		static abstract Vector256<byte> NegateIfNeeded(Vector256<byte> result);

		static abstract uint ExtractMask(Vector128<byte> result);

		static abstract uint ExtractMask(Vector256<byte> result);
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct DontNegate : INegator
	{
		public static bool NegateIfNeeded(bool result)
		{
			return result;
		}

		public static Vector128<byte> NegateIfNeeded(Vector128<byte> result)
		{
			return result;
		}

		public static Vector256<byte> NegateIfNeeded(Vector256<byte> result)
		{
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ExtractMask(Vector128<byte> result)
		{
			return ~Vector128.Equals(result, Vector128<byte>.Zero).ExtractMostSignificantBits();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ExtractMask(Vector256<byte> result)
		{
			return ~Vector256.Equals(result, Vector256<byte>.Zero).ExtractMostSignificantBits();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct Negate : INegator
	{
		public static bool NegateIfNeeded(bool result)
		{
			return !result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector128<byte> NegateIfNeeded(Vector128<byte> result)
		{
			return Vector128.Equals(result, Vector128<byte>.Zero);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector256<byte> NegateIfNeeded(Vector256<byte> result)
		{
			return Vector256.Equals(result, Vector256<byte>.Zero);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ExtractMask(Vector128<byte> result)
		{
			return result.ExtractMostSignificantBits();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ExtractMask(Vector256<byte> result)
		{
			return result.ExtractMostSignificantBits();
		}
	}

	internal interface IOptimizations
	{
		static abstract Vector128<byte> PackSources(Vector128<ushort> lower, Vector128<ushort> upper);

		static abstract Vector256<byte> PackSources(Vector256<ushort> lower, Vector256<ushort> upper);
	}

	private interface IResultMapper<T, TResult> where TResult : struct
	{
		static abstract TResult NotFound { get; }

		static abstract TResult ScalarResult(ref T searchSpace, ref T current);

		static abstract TResult FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector128<byte> result) where TNegator : struct, INegator;

		static abstract TResult FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector256<byte> result) where TNegator : struct, INegator;

		static abstract TResult FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector128<byte> result) where TNegator : struct, INegator;

		static abstract TResult FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector256<byte> result) where TNegator : struct, INegator;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct ContainsAnyResultMapper<T> : IResultMapper<T, bool>
	{
		public static bool NotFound => false;

		public static bool ScalarResult(ref T searchSpace, ref T current)
		{
			return true;
		}

		public static bool FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector128<byte> result) where TNegator : struct, INegator
		{
			return true;
		}

		public static bool FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector256<byte> result) where TNegator : struct, INegator
		{
			return true;
		}

		public static bool FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector128<byte> result) where TNegator : struct, INegator
		{
			return true;
		}

		public static bool FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector256<byte> result) where TNegator : struct, INegator
		{
			return true;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IndexOfAnyResultMapper<T> : IResultMapper<T, int>
	{
		public static int NotFound => -1;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ScalarResult(ref T searchSpace, ref T current)
		{
			return (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current) / (nuint)Unsafe.SizeOf<T>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector128<byte> result) where TNegator : struct, INegator
		{
			return BitOperations.TrailingZeroCount(TNegator.ExtractMask(result)) + (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current) / (nuint)Unsafe.SizeOf<T>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int FirstIndex<TNegator>(ref T searchSpace, ref T current, Vector256<byte> result) where TNegator : struct, INegator
		{
			if (typeof(T) == typeof(short))
			{
				result = PackedSpanHelpers.FixUpPackedVector256Result(result);
			}
			return BitOperations.TrailingZeroCount(TNegator.ExtractMask(result)) + (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current) / (nuint)Unsafe.SizeOf<T>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector128<byte> result) where TNegator : struct, INegator
		{
			int num = BitOperations.TrailingZeroCount(TNegator.ExtractMask(result));
			if (num >= Vector128<short>.Count)
			{
				current0 = ref current1;
				num -= Vector128<short>.Count;
			}
			return num + (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current0) / (nuint)Unsafe.SizeOf<T>());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int FirstIndexOverlapped<TNegator>(ref T searchSpace, ref T current0, ref T current1, Vector256<byte> result) where TNegator : struct, INegator
		{
			if (typeof(T) == typeof(short))
			{
				result = PackedSpanHelpers.FixUpPackedVector256Result(result);
			}
			int num = BitOperations.TrailingZeroCount(TNegator.ExtractMask(result));
			if (num >= Vector256<short>.Count)
			{
				current0 = ref current1;
				num -= Vector256<short>.Count;
			}
			return num + (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current0) / (nuint)Unsafe.SizeOf<T>());
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void SetBitmapBit(byte* bitmap, int value)
	{
		int num = value >> 4;
		int num2 = value & 0xF;
		byte* num3 = bitmap + (uint)num2;
		*num3 |= (byte)(1 << num);
	}

	internal unsafe static void ComputeAnyByteState(ReadOnlySpan<byte> values, out AnyByteState state)
	{
		Vector128<byte> bitmap = default(Vector128<byte>);
		Vector128<byte> bitmap2 = default(Vector128<byte>);
		byte* bitmap3 = (byte*)(&bitmap);
		byte* bitmap4 = (byte*)(&bitmap2);
		BitVector256 lookup = default(BitVector256);
		ReadOnlySpan<byte> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			lookup.Set(b);
			if (b < 128)
			{
				SetBitmapBit(bitmap3, b);
			}
			else
			{
				SetBitmapBit(bitmap4, b - 128);
			}
		}
		state = new AnyByteState(bitmap, bitmap2, lookup);
	}

	public static bool CanUseUniqueLowNibbleSearch<T>(ReadOnlySpan<T> values, int maxInclusive) where T : struct, IUnsignedNumber<T>
	{
		if (false)
		{
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryIndexOfAny(ref char searchSpace, int searchSpaceLength, ReadOnlySpan<char> asciiValues, out int index)
	{
		return TryIndexOfAny<DontNegate>(ref Unsafe.As<char, short>(ref searchSpace), searchSpaceLength, asciiValues, out index);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryLastIndexOfAny(ref char searchSpace, int searchSpaceLength, ReadOnlySpan<char> asciiValues, out int index)
	{
		return TryLastIndexOfAny<DontNegate>(ref Unsafe.As<char, short>(ref searchSpace), searchSpaceLength, asciiValues, out index);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryIndexOfAny<TNegator>(ref short searchSpace, int searchSpaceLength, ReadOnlySpan<char> asciiValues, out int index) where TNegator : struct, INegator
	{
		if (false)
		{
		}
		index = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryLastIndexOfAny<TNegator>(ref short searchSpace, int searchSpaceLength, ReadOnlySpan<char> asciiValues, out int index) where TNegator : struct, INegator
	{
		if (false)
		{
		}
		index = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ContainsAny<TNegator>(ref byte searchSpace, int searchSpaceLength, ref AnyByteState state) where TNegator : struct, INegator
	{
		return IndexOfAnyCore<bool, TNegator, ContainsAnyResultMapper<byte>>(ref searchSpace, searchSpaceLength, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int IndexOfAny<TNegator>(ref byte searchSpace, int searchSpaceLength, ref AnyByteState state) where TNegator : struct, INegator
	{
		return IndexOfAnyCore<int, TNegator, IndexOfAnyResultMapper<byte>>(ref searchSpace, searchSpaceLength, ref state);
	}

	private static TResult IndexOfAnyCore<TResult, TNegator, TResultMapper>(ref byte searchSpace, int searchSpaceLength, ref AnyByteState state) where TResult : struct where TNegator : struct, INegator where TResultMapper : struct, IResultMapper<byte, TResult>
	{
		ref byte reference = ref searchSpace;
		if (false)
		{
		}
		ref byte right = ref Unsafe.Add(ref searchSpace, searchSpaceLength);
		while (!Unsafe.AreSame(in reference, in right))
		{
			byte b = reference;
			if (TNegator.NegateIfNeeded(state.Lookup.Contains(b)))
			{
				return TResultMapper.ScalarResult(ref searchSpace, ref reference);
			}
			reference = ref Unsafe.Add(ref reference, 1);
		}
		return TResultMapper.NotFound;
	}

	public static int LastIndexOfAny<TNegator>(ref byte searchSpace, int searchSpaceLength, ref AnyByteState state) where TNegator : struct, INegator
	{
		if (false)
		{
		}
		for (int num = searchSpaceLength - 1; num >= 0; num--)
		{
			byte b = Unsafe.Add(ref searchSpace, num);
			if (TNegator.NegateIfNeeded(state.Lookup.Contains(b)))
			{
				return num;
			}
		}
		return -1;
	}
}
