using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.Unicode;

namespace System.Globalization;

internal static class Ordinal
{
	internal static int CompareStringIgnoreCase(ref char strA, int lengthA, ref char strB, int lengthB)
	{
		int num = Math.Min(lengthA, lengthB);
		int num2 = num;
		ref char reference = ref strA;
		ref char reference2 = ref strB;
		while (num != 0 && reference <= '\u007f' && reference2 <= '\u007f')
		{
			if (reference == reference2 || ((reference | 0x20) == (reference2 | 0x20) && char.IsAsciiLetter(reference)))
			{
				num--;
				reference = ref Unsafe.Add(ref reference, 1);
				reference2 = ref Unsafe.Add(ref reference2, 1);
				continue;
			}
			int num3 = reference;
			int num4 = reference2;
			if (char.IsAsciiLetterLower(reference))
			{
				num3 -= 32;
			}
			if (char.IsAsciiLetterLower(reference2))
			{
				num4 -= 32;
			}
			return num3 - num4;
		}
		if (num == 0)
		{
			return lengthA - lengthB;
		}
		num2 -= num;
		return CompareStringIgnoreCaseNonAscii(ref reference, lengthA - num2, ref reference2, lengthB - num2);
	}

	internal static int CompareStringIgnoreCaseNonAscii(ref char strA, int lengthA, ref char strB, int lengthB)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		if (false)
		{
		}
		return OrdinalCasing.CompareStringIgnoreCase(ref strA, lengthA, ref strB, lengthB);
	}

	private static bool EqualsIgnoreCase_Vector<TVector>(ref char charA, ref char charB, int length) where TVector : struct, ISimdVector<TVector, ushort>
	{
		nuint num = (nuint)length;
		nuint num2 = num - (nuint)TVector.ElementCount;
		nuint num3 = 0u;
		TVector val = TVector.Create(32);
		TVector val2 = TVector.Create(97);
		TVector right = TVector.Create(25);
		TVector val3;
		TVector val4;
		while (true)
		{
			val3 = TVector.LoadUnsafe(in Unsafe.As<char, ushort>(ref charA), num3);
			val4 = TVector.LoadUnsafe(in Unsafe.As<char, ushort>(ref charB), num3);
			if (!Utf16Utility.AllCharsInVectorAreAscii(val3 | val4))
			{
				break;
			}
			TVector val5 = ~TVector.Equals(val3, val4);
			if (!val5.Equals(TVector.Zero))
			{
				val3 |= val;
				val4 |= val;
				if (TVector.GreaterThanAny((val3 - val2) & val5, right) || !val3.Equals(val4))
				{
					return false;
				}
			}
			num3 += (nuint)TVector.ElementCount;
			if (num3 <= num2)
			{
				continue;
			}
			if (num3 != num)
			{
				num3 = num - (nuint)TVector.ElementCount;
				val3 = TVector.LoadUnsafe(in Unsafe.As<char, ushort>(ref charA), num3);
				val4 = TVector.LoadUnsafe(in Unsafe.As<char, ushort>(ref charB), num3);
				if (!Utf16Utility.AllCharsInVectorAreAscii(val3 | val4))
				{
					break;
				}
				TVector val6 = ~TVector.Equals(val3, val4);
				if (!val6.Equals(TVector.Zero))
				{
					val3 |= val;
					val4 |= val;
					if (TVector.GreaterThanAny((val3 - val2) & val6, right) || !val3.Equals(val4))
					{
						return false;
					}
				}
			}
			return true;
		}
		if (Utf16Utility.AllCharsInVectorAreAscii(val3) || Utf16Utility.AllCharsInVectorAreAscii(val4))
		{
			return false;
		}
		return CompareStringIgnoreCase(ref Unsafe.Add(ref charA, num3), (int)(num - num3), ref Unsafe.Add(ref charB, num3), (int)(num - num3)) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool EqualsIgnoreCase(ref char charA, ref char charB, int length)
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<ushort>.Count)
		{
			return EqualsIgnoreCase_Scalar(ref charA, ref charB, length);
		}
		if (false)
		{
		}
		if (false)
		{
		}
		return EqualsIgnoreCase_Vector<Vector128<ushort>>(ref charA, ref charB, length);
	}

	internal static bool EqualsIgnoreCase_Scalar(ref char charA, ref char charB, int length)
	{
		nint num = IntPtr.Zero;
		uint num2 = 0u;
		uint num3 = 0u;
		while (true)
		{
			switch (length)
			{
			default:
				num2 = Unsafe.ReadUnaligned<uint>(in Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charA, num)));
				num3 = Unsafe.ReadUnaligned<uint>(in Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charB, num)));
				if (Utf16Utility.AllCharsInUInt32AreAscii(num2 | num3))
				{
					if (Utf16Utility.UInt32OrdinalIgnoreCaseAscii(num2, num3))
					{
						goto IL_0045;
					}
					return false;
				}
				break;
			case 1:
				num2 = Unsafe.AddByteOffset(ref charA, num);
				num3 = Unsafe.AddByteOffset(ref charB, num);
				if ((num2 | num3) <= 127)
				{
					if (num2 == num3)
					{
						return true;
					}
					num2 |= 0x20;
					if (num2 - 97 > 25)
					{
						return false;
					}
					return num2 == (num3 | 0x20);
				}
				break;
			case 0:
				return true;
			}
			break;
			IL_0045:
			num += 4;
			length -= 2;
		}
		if (Utf16Utility.AllCharsInUInt32AreAscii(num2) || Utf16Utility.AllCharsInUInt32AreAscii(num3))
		{
			return false;
		}
		return CompareStringIgnoreCase(ref Unsafe.AddByteOffset(ref charA, num), length, ref Unsafe.AddByteOffset(ref charB, num), length) == 0;
	}

	internal static int IndexOf(string source, string value, int startIndex, int count, bool ignoreCase)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		if (!source.TryGetSpan(startIndex, count, out var slice))
		{
			if ((uint)startIndex > (uint)source.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
			}
			else
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
			}
		}
		int num = (ignoreCase ? IndexOfOrdinalIgnoreCase(slice, value.AsSpan()) : slice.IndexOf(value.AsSpan()));
		if (num < 0)
		{
			return num;
		}
		return num + startIndex;
	}

	internal static int IndexOfOrdinalIgnoreCase(ReadOnlySpan<char> source, ReadOnlySpan<char> value)
	{
		if (value.Length == 0)
		{
			return 0;
		}
		if (value.Length > source.Length)
		{
			return -1;
		}
		if (GlobalizationMode.Invariant)
		{
		}
		if (false)
		{
		}
		ref char reference = ref MemoryMarshal.GetReference(value);
		char c = reference;
		if (!char.IsAscii(c))
		{
			return OrdinalCasing.IndexOf(source, value);
		}
		int num = value.Length - 1;
		int num2 = source.Length - num;
		ref char reference2 = ref MemoryMarshal.GetReference(source);
		char c2 = '\0';
		char value2 = '\0';
		nint num3 = 0;
		bool flag = false;
		if (Vector128.IsHardwareAccelerated && num != 0 && num2 >= Vector128<ushort>.Count)
		{
			c2 = Unsafe.Add(ref reference, num);
			if (char.IsAscii(c2))
			{
				c = (char)(c | 0x20);
				c2 = (char)(c2 | 0x20);
				nint num4 = num;
				while (c2 == c && num4 > 1)
				{
					char c3 = Unsafe.Add(ref reference, num4 - 1);
					if (!char.IsAscii(c3))
					{
						break;
					}
					num4--;
					c2 = (char)(c3 | 0x20);
				}
				if (false)
				{
				}
				Vector128<ushort> left = Vector128.Create((ushort)c);
				Vector128<ushort> left2 = Vector128.Create((ushort)c2);
				nint num5 = (nint)num2 - (nint)Vector128<ushort>.Count;
				while (true)
				{
					Vector128<ushort> vector = Vector128.Equals(left2, Vector128.BitwiseOr(Vector128.LoadUnsafe(ref reference2, (nuint)(num3 + num4)), Vector128.Create((ushort)32)));
					Vector128<byte> vector2 = (Vector128.Equals(left, Vector128.BitwiseOr(Vector128.LoadUnsafe(ref reference2, (nuint)num3), Vector128.Create((ushort)32))) & vector).AsByte();
					if (vector2 != Vector128<byte>.Zero)
					{
						uint num6 = vector2.ExtractMostSignificantBits();
						do
						{
							nint num7 = (nint)(uint.TrailingZeroCount(num6) / 2);
							if (EqualsIgnoreCase(ref Unsafe.Add(ref reference2, num3 + num7), ref reference, value.Length))
							{
								return (int)(num3 + num7);
							}
							num6 = BitOperations.ResetLowestSetBit(BitOperations.ResetLowestSetBit(num6));
						}
						while (num6 != 0);
					}
					num3 += Vector128<ushort>.Count;
					if (num3 == num2)
					{
						break;
					}
					if (num3 > num5)
					{
						num3 = num5;
					}
				}
				return -1;
			}
		}
		if (char.IsAsciiLetter(c))
		{
			c2 = (char)(c & -33);
			value2 = (char)(c | 0x20);
			flag = true;
		}
		do
		{
			int num8;
			if (!flag)
			{
				num8 = SpanHelpers.IndexOfChar(ref Unsafe.Add(ref reference2, num3), c, num2);
			}
			else
			{
				_ = 0;
				num8 = SpanHelpers.IndexOfAnyChar(ref Unsafe.Add(ref reference2, num3), c2, value2, num2);
			}
			int num9 = num8;
			if (num9 < 0)
			{
				break;
			}
			num2 -= num9;
			if (num2 <= 0)
			{
				break;
			}
			num3 += num9;
			if (num == 0 || EqualsIgnoreCase(ref Unsafe.Add(ref reference2, (nuint)(num3 + 1)), ref Unsafe.Add(ref reference, 1), num))
			{
				return (int)num3;
			}
			num2--;
			num3++;
		}
		while (num2 > 0);
		return -1;
	}

	internal static int LastIndexOfOrdinalIgnoreCase(ReadOnlySpan<char> source, ReadOnlySpan<char> value)
	{
		if (value.Length == 0)
		{
			return source.Length;
		}
		if (value.Length > source.Length)
		{
			return -1;
		}
		if (GlobalizationMode.Invariant)
		{
		}
		if (false)
		{
		}
		return OrdinalCasing.LastIndexOf(source, value);
	}

	internal static int ToUpperOrdinal(ReadOnlySpan<char> source, Span<char> destination)
	{
		if (source.Overlaps(destination))
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_SpanOverlappedOperation);
		}
		if (destination.Length < source.Length)
		{
			return -1;
		}
		if (GlobalizationMode.Invariant)
		{
		}
		if (false)
		{
		}
		OrdinalCasing.ToUpperOrdinal(source, destination);
		return source.Length;
	}

	internal static bool EqualsStringIgnoreCaseUtf8(ref byte strA, int lengthA, ref byte strB, int lengthB)
	{
		int num = Math.Min(lengthA, lengthB);
		int num2 = num;
		ref byte reference = ref strA;
		ref byte reference2 = ref strB;
		while (num != 0 && reference <= 127 && reference2 <= 127)
		{
			if (reference == reference2 || ((reference | 0x20) == (reference2 | 0x20) && char.IsAsciiLetter((char)reference)))
			{
				num--;
				reference = ref Unsafe.Add(ref reference, 1);
				reference2 = ref Unsafe.Add(ref reference2, 1);
				continue;
			}
			return false;
		}
		if (num == 0)
		{
			return lengthA == lengthB;
		}
		num2 -= num;
		return EqualsStringIgnoreCaseNonAsciiUtf8(ref reference, lengthA - num2, ref reference2, lengthB - num2);
	}

	internal static bool EqualsStringIgnoreCaseNonAsciiUtf8(ref byte strA, int lengthA, ref byte strB, int lengthB)
	{
		ReadOnlySpan<byte> source = MemoryMarshal.CreateReadOnlySpan(in strA, lengthA);
		ReadOnlySpan<byte> source2 = MemoryMarshal.CreateReadOnlySpan(in strB, lengthB);
		do
		{
			Rune result;
			int bytesConsumed;
			OperationStatus operationStatus = Rune.DecodeFromUtf8(source, out result, out bytesConsumed);
			Rune result2;
			int bytesConsumed2;
			OperationStatus operationStatus2 = Rune.DecodeFromUtf8(source2, out result2, out bytesConsumed2);
			if (operationStatus != operationStatus2)
			{
				return false;
			}
			if (operationStatus == OperationStatus.Done)
			{
				if (Rune.ToUpperInvariant(result) != Rune.ToUpperInvariant(result2))
				{
					return false;
				}
			}
			else if (!source.Slice(0, bytesConsumed).SequenceEqual(source2.Slice(0, bytesConsumed2)))
			{
				return false;
			}
			source = source.Slice(bytesConsumed);
			source2 = source2.Slice(bytesConsumed2);
		}
		while ((source.Length | source2.Length) != 0);
		return true;
	}

	private static bool EqualsIgnoreCaseUtf8_Vector128(ref byte charA, int lengthA, ref byte charB, int lengthB)
	{
		nuint num = Math.Min((uint)lengthA, (uint)lengthB);
		nuint num2 = num - (nuint)Vector128<byte>.Count;
		nuint num3 = 0u;
		Vector128<byte> vector;
		Vector128<byte> vector2;
		while (true)
		{
			vector = Vector128.LoadUnsafe(in charA, num3);
			vector2 = Vector128.LoadUnsafe(in charB, num3);
			if (!Utf8Utility.AllBytesInVector128AreAscii(vector | vector2))
			{
				break;
			}
			if (!Utf8Utility.Vector128OrdinalIgnoreCaseAscii(vector, vector2))
			{
				return false;
			}
			num3 += (nuint)Vector128<byte>.Count;
			if (num3 > num2)
			{
				if (num3 == num)
				{
					return lengthA == lengthB;
				}
				return EqualsIgnoreCaseUtf8_Scalar(ref Unsafe.Add(ref charA, num3), (int)(num - num3), ref Unsafe.Add(ref charB, num3), (int)(num - num3));
			}
		}
		if (Utf8Utility.AllBytesInVector128AreAscii(vector) || Utf8Utility.AllBytesInVector128AreAscii(vector2))
		{
			return false;
		}
		return EqualsStringIgnoreCaseUtf8(ref Unsafe.Add(ref charA, num3), lengthA - (int)num3, ref Unsafe.Add(ref charB, num3), lengthB - (int)num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool EqualsIgnoreCaseUtf8(ref byte charA, int lengthA, ref byte charB, int lengthB)
	{
		if (!Vector128.IsHardwareAccelerated || lengthA < Vector128<byte>.Count || lengthB < Vector128<byte>.Count)
		{
			return EqualsIgnoreCaseUtf8_Scalar(ref charA, lengthA, ref charB, lengthB);
		}
		return EqualsIgnoreCaseUtf8_Vector128(ref charA, lengthA, ref charB, lengthB);
	}

	internal static bool EqualsIgnoreCaseUtf8_Scalar(ref byte charA, int lengthA, ref byte charB, int lengthB)
	{
		nint num = IntPtr.Zero;
		int num2 = Math.Min(lengthA, lengthB);
		int num3 = num2;
		uint num4 = 0u;
		uint num5 = 0u;
		while (true)
		{
			if ((uint)num2 >= 4u)
			{
				num4 = Unsafe.ReadUnaligned<uint>(in Unsafe.AddByteOffset(ref charA, num));
				num5 = Unsafe.ReadUnaligned<uint>(in Unsafe.AddByteOffset(ref charB, num));
				if (!Utf8Utility.AllBytesInUInt32AreAscii(num4 | num5))
				{
					break;
				}
				if (!Utf8Utility.UInt32OrdinalIgnoreCaseAscii(num4, num5))
				{
					return false;
				}
				num += 4;
				num2 -= 4;
				continue;
			}
			if (num2 != 0)
			{
				switch (num2)
				{
				case 3:
					num4 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref charA, num));
					num5 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref charB, num));
					num += 2;
					num4 |= (uint)(Unsafe.AddByteOffset(ref charA, num) << 16);
					num5 |= (uint)(Unsafe.AddByteOffset(ref charB, num) << 16);
					break;
				case 2:
					num4 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref charA, num));
					num5 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref charB, num));
					break;
				default:
					num4 = Unsafe.AddByteOffset(ref charA, num);
					num5 = Unsafe.AddByteOffset(ref charB, num);
					break;
				}
				if (!Utf8Utility.AllBytesInUInt32AreAscii(num4 | num5))
				{
					break;
				}
				if (lengthA != lengthB)
				{
					return false;
				}
				if (num4 == num5)
				{
					return true;
				}
				return Utf8Utility.UInt32OrdinalIgnoreCaseAscii(num4, num5);
			}
			return lengthA == lengthB;
		}
		if (Utf8Utility.AllBytesInUInt32AreAscii(num4) || Utf8Utility.AllBytesInUInt32AreAscii(num5))
		{
			return false;
		}
		num3 -= num2;
		return EqualsStringIgnoreCaseUtf8(ref Unsafe.AddByteOffset(ref charA, num), lengthA - num3, ref Unsafe.AddByteOffset(ref charB, num), lengthB - num3);
	}

	internal static bool StartsWithStringIgnoreCaseUtf8(ref byte source, int sourceLength, ref byte prefix, int prefixLength)
	{
		int num = Math.Min(sourceLength, prefixLength);
		int num2 = num;
		while (num != 0 && source <= 127 && prefix <= 127)
		{
			if (source == prefix || ((source | 0x20) == (prefix | 0x20) && char.IsAsciiLetter((char)source)))
			{
				num--;
				source = ref Unsafe.Add(ref source, 1);
				prefix = ref Unsafe.Add(ref prefix, 1);
				continue;
			}
			return false;
		}
		if (num == 0)
		{
			return prefixLength == 0;
		}
		num2 -= num;
		return StartsWithStringIgnoreCaseNonAsciiUtf8(ref source, sourceLength - num2, ref prefix, prefixLength - num2);
	}

	internal static bool StartsWithStringIgnoreCaseNonAsciiUtf8(ref byte source, int sourceLength, ref byte prefix, int prefixLength)
	{
		ReadOnlySpan<byte> source2 = MemoryMarshal.CreateReadOnlySpan(in source, sourceLength);
		ReadOnlySpan<byte> source3 = MemoryMarshal.CreateReadOnlySpan(in prefix, prefixLength);
		do
		{
			Rune result;
			int bytesConsumed;
			OperationStatus operationStatus = Rune.DecodeFromUtf8(source2, out result, out bytesConsumed);
			Rune result2;
			int bytesConsumed2;
			OperationStatus operationStatus2 = Rune.DecodeFromUtf8(source3, out result2, out bytesConsumed2);
			if (operationStatus != operationStatus2)
			{
				return false;
			}
			if (operationStatus == OperationStatus.Done)
			{
				if (Rune.ToUpperInvariant(result) != Rune.ToUpperInvariant(result2))
				{
					return false;
				}
			}
			else if (!source2.Slice(0, bytesConsumed).SequenceEqual(source3.Slice(0, bytesConsumed2)))
			{
				return false;
			}
			source2 = source2.Slice(bytesConsumed);
			source3 = source3.Slice(bytesConsumed2);
		}
		while (source3.Length != 0);
		return true;
	}

	private static bool StartsWithIgnoreCaseUtf8_Vector128(ref byte source, int sourceLength, ref byte prefix, int prefixLength)
	{
		nuint num = Math.Min((uint)sourceLength, (uint)prefixLength);
		nuint num2 = num - (nuint)Vector128<byte>.Count;
		nuint num3 = 0u;
		Vector128<byte> vector;
		Vector128<byte> vector2;
		while (true)
		{
			vector = Vector128.LoadUnsafe(in source, num3);
			vector2 = Vector128.LoadUnsafe(in prefix, num3);
			if (!Utf8Utility.AllBytesInVector128AreAscii(vector | vector2))
			{
				break;
			}
			if (!Utf8Utility.Vector128OrdinalIgnoreCaseAscii(vector, vector2))
			{
				return false;
			}
			num3 += (nuint)Vector128<byte>.Count;
			if (num3 > num2)
			{
				if (num3 == (uint)prefixLength)
				{
					return true;
				}
				return StartsWithIgnoreCaseUtf8_Scalar(ref Unsafe.Add(ref source, num3), (int)(num - num3), ref Unsafe.Add(ref prefix, num3), (int)(num - num3));
			}
		}
		if (Utf8Utility.AllBytesInVector128AreAscii(vector) || Utf8Utility.AllBytesInVector128AreAscii(vector2))
		{
			return false;
		}
		return StartsWithStringIgnoreCaseUtf8(ref Unsafe.Add(ref source, num3), sourceLength - (int)num3, ref Unsafe.Add(ref prefix, num3), prefixLength - (int)num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool StartsWithIgnoreCaseUtf8(ref byte source, int sourceLength, ref byte prefix, int prefixLength)
	{
		if (!Vector128.IsHardwareAccelerated || sourceLength < Vector128<byte>.Count || prefixLength < Vector128<byte>.Count)
		{
			return StartsWithIgnoreCaseUtf8_Scalar(ref source, sourceLength, ref prefix, prefixLength);
		}
		return StartsWithIgnoreCaseUtf8_Vector128(ref source, sourceLength, ref prefix, prefixLength);
	}

	internal static bool StartsWithIgnoreCaseUtf8_Scalar(ref byte source, int sourceLength, ref byte prefix, int prefixLength)
	{
		nint num = IntPtr.Zero;
		int num2 = Math.Min(sourceLength, prefixLength);
		int num3 = num2;
		uint num4 = 0u;
		uint num5 = 0u;
		while (true)
		{
			if ((uint)num2 >= 4u)
			{
				num4 = Unsafe.ReadUnaligned<uint>(in Unsafe.AddByteOffset(ref source, num));
				num5 = Unsafe.ReadUnaligned<uint>(in Unsafe.AddByteOffset(ref prefix, num));
				if (!Utf8Utility.AllBytesInUInt32AreAscii(num4 | num5))
				{
					break;
				}
				if (!Utf8Utility.UInt32OrdinalIgnoreCaseAscii(num4, num5))
				{
					return false;
				}
				num += 4;
				num2 -= 4;
				continue;
			}
			if (num2 != 0)
			{
				switch (num2)
				{
				case 3:
					num4 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref source, num));
					num5 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref prefix, num));
					num += 2;
					num4 |= (uint)(Unsafe.AddByteOffset(ref source, num) << 16);
					num5 |= (uint)(Unsafe.AddByteOffset(ref prefix, num) << 16);
					break;
				case 2:
					num4 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref source, num));
					num5 = Unsafe.ReadUnaligned<ushort>(in Unsafe.AddByteOffset(ref prefix, num));
					break;
				default:
					num4 = Unsafe.AddByteOffset(ref source, num);
					num5 = Unsafe.AddByteOffset(ref prefix, num);
					break;
				}
				if (!Utf8Utility.AllBytesInUInt32AreAscii(num4 | num5))
				{
					break;
				}
				if (num3 != prefixLength)
				{
					return false;
				}
				if (num4 == num5)
				{
					return true;
				}
				if (!Utf8Utility.UInt32OrdinalIgnoreCaseAscii(num4, num5))
				{
					return false;
				}
				num += 4;
				num2 -= 4;
			}
			return prefixLength <= sourceLength;
		}
		if (Utf8Utility.AllBytesInUInt32AreAscii(num4) || Utf8Utility.AllBytesInUInt32AreAscii(num5))
		{
			return false;
		}
		num3 -= num2;
		return StartsWithStringIgnoreCaseUtf8(ref Unsafe.AddByteOffset(ref source, num), sourceLength - num3, ref Unsafe.AddByteOffset(ref prefix, num), prefixLength - num3);
	}
}
