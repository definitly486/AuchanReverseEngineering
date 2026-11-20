using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System.Buffers;

internal abstract class AsciiStringSearchValuesTeddyBase<TBucketized, TStartCaseSensitivity, TCaseSensitivity> : StringSearchValuesRabinKarp<TCaseSensitivity> where TBucketized : struct, SearchValues.IRuntimeConst where TStartCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	private readonly EightObjects _buckets;

	private readonly Vector512<byte> _n0Low;

	private readonly Vector512<byte> _n0High;

	private readonly Vector512<byte> _n1Low;

	private readonly Vector512<byte> _n1High;

	private readonly Vector512<byte> _n2Low;

	private readonly Vector512<byte> _n2High;

	protected AsciiStringSearchValuesTeddyBase(ReadOnlySpan<string> values, HashSet<string> uniqueValues, int n)
		: base(values, uniqueValues)
	{
		ReadOnlySpan<object>.CastUp(values).CopyTo(_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<EightObjects, object>(ref _buckets, 8));
		(_n0Low, _n0High) = TeddyBucketizer.GenerateNonBucketizedFingerprint(values, 0);
		(_n1Low, _n1High) = TeddyBucketizer.GenerateNonBucketizedFingerprint(values, 1);
		if (n == 3)
		{
			(_n2Low, _n2High) = TeddyBucketizer.GenerateNonBucketizedFingerprint(values, 2);
		}
	}

	protected AsciiStringSearchValuesTeddyBase(string[][] buckets, ReadOnlySpan<string> values, HashSet<string> uniqueValues, int n)
		: base(values, uniqueValues)
	{
		((ReadOnlySpan<object>)buckets).CopyTo(_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<EightObjects, object>(ref _buckets, 8));
		(_n0Low, _n0High) = TeddyBucketizer.GenerateBucketizedFingerprint(buckets, 0);
		(_n1Low, _n1High) = TeddyBucketizer.GenerateBucketizedFingerprint(buckets, 1);
		if (n == 3)
		{
			(_n2Low, _n2High) = TeddyBucketizer.GenerateBucketizedFingerprint(buckets, 2);
		}
	}

	protected int IndexOfAnyN2(ReadOnlySpan<char> span)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return IndexOfAnyN2Vector128(span);
	}

	protected int IndexOfAnyN3(ReadOnlySpan<char> span)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return IndexOfAnyN3Vector128(span);
	}

	private int IndexOfAnyN2Vector128(ReadOnlySpan<char> span)
	{
		if (span.Length < 17)
		{
			return ShortInputFallback(span);
		}
		ref char reference = ref MemoryMarshal.GetReference(span);
		ref char reference2 = ref Unsafe.Add(ref reference, span.Length - 16);
		reference = ref Unsafe.Add(ref reference, 1);
		Vector128<byte> lower = _n0Low._lower._lower;
		Vector128<byte> lower2 = _n0High._lower._lower;
		Vector128<byte> lower3 = _n1Low._lower._lower;
		Vector128<byte> lower4 = _n1High._lower._lower;
		Vector128<byte> prev = Vector128<byte>.AllBitsSet;
		int offsetFromStart;
		while (true)
		{
			Vector128<byte> vector;
			(vector, prev) = TeddyHelper.ProcessInputN2(TStartCaseSensitivity.TransformInput(TeddyHelper.LoadAndPack16AsciiChars(ref reference)), prev, lower, lower2, lower3, lower4);
			if (vector != Vector128<byte>.Zero && TryFindMatch(span, ref reference, vector, 1, out offsetFromStart))
			{
				break;
			}
			reference = ref Unsafe.Add(ref reference, 16);
			if (Unsafe.IsAddressGreaterThan(in reference, in reference2))
			{
				if (Unsafe.AreSame(in reference, in Unsafe.Add(ref reference2, 16)))
				{
					return -1;
				}
				prev = Vector128<byte>.AllBitsSet;
				reference = ref reference2;
			}
		}
		return offsetFromStart;
	}

	private int IndexOfAnyN3Vector128(ReadOnlySpan<char> span)
	{
		if (span.Length < 18)
		{
			return ShortInputFallback(span);
		}
		ref char reference = ref MemoryMarshal.GetReference(span);
		ref char reference2 = ref Unsafe.Add(ref reference, span.Length - 16);
		reference = ref Unsafe.Add(ref reference, 2);
		Vector128<byte> lower = _n0Low._lower._lower;
		Vector128<byte> lower2 = _n0High._lower._lower;
		Vector128<byte> lower3 = _n1Low._lower._lower;
		Vector128<byte> lower4 = _n1High._lower._lower;
		Vector128<byte> lower5 = _n2Low._lower._lower;
		Vector128<byte> lower6 = _n2High._lower._lower;
		Vector128<byte> prev = Vector128<byte>.AllBitsSet;
		Vector128<byte> prev2 = Vector128<byte>.AllBitsSet;
		int offsetFromStart;
		while (true)
		{
			Vector128<byte> vector;
			(vector, prev, prev2) = TeddyHelper.ProcessInputN3(TStartCaseSensitivity.TransformInput(TeddyHelper.LoadAndPack16AsciiChars(ref reference)), prev, prev2, lower, lower2, lower3, lower4, lower5, lower6);
			if (vector != Vector128<byte>.Zero && TryFindMatch(span, ref reference, vector, 2, out offsetFromStart))
			{
				break;
			}
			reference = ref Unsafe.Add(ref reference, 16);
			if (Unsafe.IsAddressGreaterThan(in reference, in reference2))
			{
				if (Unsafe.AreSame(in reference, in Unsafe.Add(ref reference2, 16)))
				{
					return -1;
				}
				prev = Vector128<byte>.AllBitsSet;
				prev2 = Vector128<byte>.AllBitsSet;
				reference = ref reference2;
			}
		}
		return offsetFromStart;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TryFindMatch(ReadOnlySpan<char> span, ref char searchSpace, Vector128<byte> result, int matchStartOffset, out int offsetFromStart)
	{
		uint num = (~Vector128.Equals(result, Vector128<byte>.Zero)).ExtractMostSignificantBits();
		do
		{
			int num2 = BitOperations.TrailingZeroCount(num);
			ref char reference = ref Unsafe.Add(ref searchSpace, num2 - matchStartOffset);
			offsetFromStart = (int)((nuint)Unsafe.ByteOffset(in MemoryMarshal.GetReference(span), in reference) / (nuint)2u);
			int lengthRemaining = span.Length - offsetFromStart;
			uint num3 = Vector128.GetElementUnsafe(in result, num2);
			do
			{
				int index = BitOperations.TrailingZeroCount(num3);
				object o = _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<EightObjects, object>(in _buckets, 8)[index];
				if (TBucketized.Value ? StringSearchValuesHelper.StartsWith<TCaseSensitivity>(ref reference, lengthRemaining, Unsafe.As<string[]>(o)) : StringSearchValuesHelper.StartsWith<TCaseSensitivity>(ref reference, lengthRemaining, Unsafe.As<string>(o)))
				{
					return true;
				}
				num3 = BitOperations.ResetLowestSetBit(num3);
			}
			while (num3 != 0);
			num = BitOperations.ResetLowestSetBit(num);
		}
		while (num != 0);
		offsetFromStart = 0;
		return false;
	}
}
