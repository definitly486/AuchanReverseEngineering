using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System.Buffers;

internal sealed class SingleStringSearchValuesThreeChars<TValueLength, TCaseSensitivity> : StringSearchValuesBase where TValueLength : struct, StringSearchValuesHelper.IValueLength where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	private readonly StringSearchValuesHelper.SingleValueState _valueState;

	private readonly nint _minusValueTailLength;

	private readonly nuint _ch2ByteOffset;

	private readonly nuint _ch3ByteOffset;

	private readonly ushort _ch1;

	private readonly ushort _ch2;

	private readonly ushort _ch3;

	private static bool IgnoreCase => typeof(TCaseSensitivity) != typeof(StringSearchValuesHelper.CaseSensitive);

	private static bool CanSkipAnchorMatchVerification
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (typeof(TValueLength) == typeof(StringSearchValuesHelper.ValueLengthLessThan4))
			{
				if (!(typeof(TCaseSensitivity) == typeof(StringSearchValuesHelper.CaseSensitive)))
				{
					return typeof(TCaseSensitivity) == typeof(StringSearchValuesHelper.CaseInsensitiveAsciiLetters);
				}
				return true;
			}
			return false;
		}
	}

	public SingleStringSearchValuesThreeChars(HashSet<string> uniqueValues, string value, int ch2Offset, int ch3Offset)
		: base(uniqueValues)
	{
		_valueState = new StringSearchValuesHelper.SingleValueState(value, IgnoreCase);
		_minusValueTailLength = -(value.Length - 1);
		_ch1 = value[0];
		_ch2 = value[ch2Offset];
		_ch3 = value[ch3Offset];
		if (IgnoreCase)
		{
			_ch1 &= 65503;
			_ch2 &= 65503;
			_ch3 &= 65503;
		}
		_ch2ByteOffset = (nuint)ch2Offset * (nuint)2u;
		_ch3ByteOffset = (nuint)ch3Offset * (nuint)2u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal override int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		return IndexOf(ref MemoryMarshal.GetReference(span), span.Length);
	}

	private int IndexOf(ref char searchSpace, int searchSpaceLength)
	{
		ref char searchSpaceStart = ref searchSpace;
		nint num = searchSpaceLength + _minusValueTailLength;
		if (Vector128.IsHardwareAccelerated && num >= Vector128<ushort>.Count)
		{
			nuint ch2ByteOffset = _ch2ByteOffset;
			nuint ch3ByteOffset = _ch3ByteOffset;
			if (false)
			{
			}
			if (false)
			{
			}
			Vector128<ushort> ch = Vector128.Create(_ch1);
			Vector128<ushort> ch2 = Vector128.Create(_ch2);
			Vector128<ushort> ch3 = Vector128.Create(_ch3);
			ref char reference = ref Unsafe.Add(ref searchSpace, num - Vector128<ushort>.Count);
			int offsetFromStart;
			while (true)
			{
				Vector128<byte> comparisonResult = GetComparisonResult(ref searchSpace, ch2ByteOffset, ch3ByteOffset, ch, ch2, ch3);
				if (comparisonResult != Vector128<byte>.Zero && TryMatch(ref searchSpaceStart, searchSpaceLength, ref searchSpace, comparisonResult.ExtractMostSignificantBits(), out offsetFromStart))
				{
					break;
				}
				searchSpace = ref Unsafe.Add(ref searchSpace, Vector128<ushort>.Count);
				if (Unsafe.IsAddressGreaterThan(in searchSpace, in reference))
				{
					if (Unsafe.AreSame(in searchSpace, in Unsafe.Add(ref reference, Vector128<ushort>.Count)))
					{
						return -1;
					}
					searchSpace = ref reference;
				}
			}
			return offsetFromStart;
		}
		char rawStringData = _valueState.Value.GetRawStringData();
		for (nint num2 = 0; num2 < num; num2++)
		{
			ref char reference2 = ref Unsafe.Add(ref searchSpace, num2);
			if ((typeof(TCaseSensitivity) == typeof(StringSearchValuesHelper.CaseInsensitiveUnicode) || TCaseSensitivity.TransformInput(reference2) == rawStringData) && TCaseSensitivity.Equals<TValueLength>(ref reference2, in _valueState))
			{
				return (int)num2;
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> GetComparisonResult(ref char searchSpace, nuint ch2ByteOffset, nuint ch3ByteOffset, Vector128<ushort> ch1, Vector128<ushort> ch2, Vector128<ushort> ch3)
	{
		if (typeof(TCaseSensitivity) == typeof(StringSearchValuesHelper.CaseSensitive))
		{
			Vector128<ushort> vector = Vector128.Equals(ch1, Vector128.LoadUnsafe(ref searchSpace));
			Vector128<ushort> vector2 = Vector128.Equals(ch2, Vector128.LoadUnsafe(in Unsafe.As<char, byte>(ref searchSpace), ch2ByteOffset).AsUInt16());
			Vector128<ushort> vector3 = Vector128.Equals(ch3, Vector128.LoadUnsafe(in Unsafe.As<char, byte>(ref searchSpace), ch3ByteOffset).AsUInt16());
			return (vector & vector2 & vector3).AsByte();
		}
		Vector128<ushort> vector4 = Vector128.Create((ushort)65503);
		Vector128<ushort> vector5 = Vector128.Equals(ch1, Vector128.LoadUnsafe(ref searchSpace) & vector4);
		Vector128<ushort> vector6 = Vector128.Equals(ch2, Vector128.LoadUnsafe(in Unsafe.As<char, byte>(ref searchSpace), ch2ByteOffset).AsUInt16() & vector4);
		Vector128<ushort> vector7 = Vector128.Equals(ch3, Vector128.LoadUnsafe(in Unsafe.As<char, byte>(ref searchSpace), ch3ByteOffset).AsUInt16() & vector4);
		return (vector5 & vector6 & vector7).AsByte();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TryMatch(ref char searchSpaceStart, int searchSpaceLength, ref char searchSpace, uint mask, out int offsetFromStart)
	{
		do
		{
			int num = BitOperations.TrailingZeroCount(mask);
			ref char reference = ref Unsafe.AddByteOffset(ref searchSpace, num);
			if (CanSkipAnchorMatchVerification || TCaseSensitivity.Equals<TValueLength>(ref reference, in _valueState))
			{
				offsetFromStart = (int)((nuint)Unsafe.ByteOffset(in searchSpaceStart, in reference) / (nuint)2u);
				return true;
			}
			mask = BitOperations.ResetLowestSetBit(BitOperations.ResetLowestSetBit(mask));
		}
		while (mask != 0);
		offsetFromStart = 0;
		return false;
	}

	internal override bool ContainsCore(string value)
	{
		if (!base.HasUniqueValues)
		{
			return _valueState.Value.Equals(value, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}
		return base.ContainsCore(value);
	}

	internal override string[] GetValues()
	{
		if (!base.HasUniqueValues)
		{
			return new string[1] { _valueState.Value };
		}
		return base.GetValues();
	}
}
