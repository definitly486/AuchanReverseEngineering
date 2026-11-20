using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System.Text.Unicode;

internal static class Utf8Utility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetIndexOfFirstInvalidUtf8Sequence(ReadOnlySpan<byte> utf8Data, out bool isAscii)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(utf8Data))
		{
			int utf16CodeUnitCountAdjustment;
			int scalarCountAdjustment;
			byte* pointerToFirstInvalidByte = GetPointerToFirstInvalidByte(reference, utf8Data.Length, out utf16CodeUnitCountAdjustment, out scalarCountAdjustment);
			int num = (int)Unsafe.ByteOffset(in *reference, in *pointerToFirstInvalidByte);
			isAscii = utf16CodeUnitCountAdjustment == 0;
			if (num >= utf8Data.Length)
			{
				return -1;
			}
			return num;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllBytesInUInt32AreAscii(uint value)
	{
		return (value & 0x80808080u) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ConvertAllAsciiBytesInUInt32ToLowercase(uint value)
	{
		int num = (int)value + -2139062144 - 1094795585;
		uint num2 = (uint)((int)value + -2139062144 - 1532713819);
		uint num3 = (((uint)num ^ num2) & 0x80808080u) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ConvertAllAsciiBytesInUInt32ToUppercase(uint value)
	{
		int num = (int)value + -2139062144 - 1633771873;
		uint num2 = (uint)((int)value + -2139062144 - 2071690107);
		uint num3 = (((uint)num ^ num2) & 0x80808080u) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool UInt32OrdinalIgnoreCaseAscii(uint valueA, uint valueB)
	{
		uint num = (((valueA + 1061109567) ^ (valueA + 623191333)) & 0x80808080u) >> 2;
		uint num2 = (((valueB + 1061109567) ^ (valueB + 623191333)) & 0x80808080u) >> 2;
		return (valueA | num) == (valueB | num2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllBytesInVector128AreAscii(Vector128<byte> vec)
	{
		return (vec & Vector128.Create((byte)128)) == Vector128<byte>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool Vector128OrdinalIgnoreCaseAscii(Vector128<byte> vec1, Vector128<byte> vec2)
	{
		Vector128<sbyte> right = Vector128.Create((sbyte)63) + vec1.AsSByte();
		Vector128<sbyte> right2 = Vector128.Create((sbyte)63) + vec2.AsSByte();
		Vector128<sbyte> right3 = Vector128.LessThan(Vector128.Create((sbyte)(-103)), right);
		Vector128<sbyte> right4 = Vector128.LessThan(Vector128.Create((sbyte)(-103)), right2);
		Vector128<sbyte> vector = Vector128.AndNot(Vector128.Create((sbyte)32), right3) + vec1.AsSByte();
		Vector128<sbyte> vector2 = Vector128.AndNot(Vector128.Create((sbyte)32), right4) + vec2.AsSByte();
		return (vector ^ vector2) == Vector128<sbyte>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractCharFromFirstThreeByteSequence(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return ((value & 0x3F0000) >> 16) | ((value & 0x3F00) >> 2) | ((value & 0xF) << 12);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractCharFromFirstTwoByteSequence(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		uint num = (uint)((byte)value << 6);
		return (byte)(value >> 8) + num - 12288 - 128;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractCharsFromFourByteSequence(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return ((uint)((byte)value << 8) | ((value & 0x3F00) >> 6) | ((value & 0x300000) >> 20) | ((value & 0x3F000000) >> 8) | ((value & 0xF0000) << 6)) - 64 - 8192 + 2048 + 3690987520u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractFourUtf8BytesFromSurrogatePair(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		value += 64;
		uint value2 = BinaryPrimitives.ReverseEndianness(value & 0x3F0700);
		value2 = BitOperations.RotateLeft(value2, 16);
		uint num = (value & 0xFC) << 6;
		uint num2 = (value >> 6) & 0xF0000;
		num2 |= num;
		return ((value & 3) << 20) | 0x808080F0u | value2 | num2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractTwoCharsPackedFromTwoAdjacentTwoByteSequences(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return ((value & 0x3F003F00) >> 8) | ((value & 0x1F001F) << 6);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractTwoUtf8TwoByteSequencesFromTwoPackedUtf16Chars(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return ((value >> 6) & 0x1F001F) + ((value << 8) & 0x3F003F00) + 2160099520u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ExtractUtf8TwoByteSequenceFromFirstUtf16Char(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		uint num = (value << 2) & 0x1F00;
		value &= 0x3F;
		return BinaryPrimitives.ReverseEndianness((ushort)(num + value + 49280));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFirstCharAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0xFF80) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFirstCharAtLeastThreeUtf8Bytes(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0xF800) == 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFirstCharSurrogate(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (((value - 55296) & 0xF800) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFirstCharTwoUtf8Bytes(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (((value - 128) & 0xFFFF) >= 1920)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsLowByteUtf8ContinuationByte(uint value)
	{
		return (uint)(byte)(value - 128) <= 63u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsSecondCharAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (value >= 8388608)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsSecondCharAtLeastThreeUtf8Bytes(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0xF8000000u) == 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsSecondCharSurrogate(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((uint)((int)value - -671088640) >= 134217728u)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsSecondCharTwoUtf8Bytes(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (!UnicodeUtility.IsInRangeInclusive(value, 8388608u, 134217727u))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsUtf8ContinuationByte(in byte value)
	{
		return (sbyte)value < -64;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsWellFormedUtf16SurrogatePair(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((((int)value - -603924480) & -67044352) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint ToLittleEndian(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32BeginsWithOverlongUtf8TwoByteSequence(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((uint)(byte)value >= 194u)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32BeginsWithUtf8FourByteMask(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((((int)value - -2139062032) & -1061109512) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32BeginsWithUtf8ThreeByteMask(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (((value - 8421600) & 0xC0C0F0) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32BeginsWithUtf8TwoByteMask(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (((value - 32960) & 0xC0E0) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32BeginsWithValidUtf8TwoByteSequenceLittleEndian(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (!UnicodeUtility.IsInRangeInclusive(value & 0xC0FF, 32962u, 32991u))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32EndsWithValidUtf8TwoByteSequenceLittleEndian(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if (!UnicodeUtility.IsInRangeInclusive(value & 0xC0FF0000u, 2160197632u, 2162098176u))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32FirstByteIsAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0x80) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32FourthByteIsAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((int)value < 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32SecondByteIsAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0x8000) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool UInt32ThirdByteIsAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0x800000) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void WriteTwoUtf16CharsAsTwoUtf8ThreeByteSequences(ref byte outputBuffer, uint value)
	{
		_ = BitConverter.IsLittleEndian;
		uint num = ((value << 2) & 0x3F00) | ((value & 0x3F) << 16);
		uint num2 = ((value >> 4) & 0xF000000) | ((value >> 12) & 0xF);
		Unsafe.WriteUnaligned(ref outputBuffer, num + num2 + 3766517984u);
		Unsafe.WriteUnaligned(ref Unsafe.Add(ref outputBuffer, 4), (ushort)(((value >> 22) & 0x3F) + ((value >> 8) & 0x3F00) + 32896));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void WriteFirstUtf16CharAsUtf8ThreeByteSequence(ref byte outputBuffer, uint value)
	{
		_ = BitConverter.IsLittleEndian;
		uint num = (value << 2) & 0x3F00;
		uint num2 = (uint)(ushort)value >> 12;
		Unsafe.WriteUnaligned(ref outputBuffer, (ushort)(num + num2 + 32992));
		Unsafe.Add(ref outputBuffer, 2) = (byte)((value & 0x3F) | 0xFFFFFF80u);
	}

	public unsafe static OperationStatus TranscodeToUtf16(byte* pInputBuffer, int inputLength, char* pOutputBuffer, int outputCharsRemaining, out byte* pInputBufferRemaining, out char* pOutputBufferRemaining)
	{
		nuint num = Ascii.WidenAsciiToUtf16(pInputBuffer, pOutputBuffer, (uint)Math.Min(inputLength, outputCharsRemaining));
		pInputBuffer += num;
		pOutputBuffer += num;
		if ((int)num == inputLength)
		{
			pInputBufferRemaining = pInputBuffer;
			pOutputBufferRemaining = pOutputBuffer;
			return OperationStatus.Done;
		}
		inputLength -= (int)num;
		outputCharsRemaining -= (int)num;
		if (inputLength < 4)
		{
			goto IL_0671;
		}
		byte* ptr = pInputBuffer + (uint)inputLength - 4;
		while (true)
		{
			IL_004a:
			uint num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
			while (true)
			{
				IL_0051:
				if (!Ascii.AllBytesInUInt32AreAscii(num2))
				{
					goto IL_0117;
				}
				int num4;
				uint num5;
				if (outputCharsRemaining >= 4)
				{
					Ascii.WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref *pOutputBuffer, num2);
					pInputBuffer += 4;
					pOutputBuffer += 4;
					outputCharsRemaining -= 4;
					uint num3 = Math.Min((uint)((int)Unsafe.ByteOffset(in *pInputBuffer, in *ptr) + 4), (uint)outputCharsRemaining) / 8;
					num4 = 0;
					while ((uint)num4 < num3)
					{
						num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
						num5 = Unsafe.ReadUnaligned<uint>(pInputBuffer + 4);
						if (Ascii.AllBytesInUInt32AreAscii(num2 | num5))
						{
							pInputBuffer += 8;
							Ascii.WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref *pOutputBuffer, num2);
							Ascii.WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref pOutputBuffer[4], num5);
							pOutputBuffer += 8;
							num4++;
							continue;
						}
						goto IL_00eb;
					}
					outputCharsRemaining -= 8 * num4;
					goto IL_0494;
				}
				goto IL_049b;
				IL_049b:
				inputLength = (int)Unsafe.ByteOffset(in *pInputBuffer, in *ptr) + 4;
				goto IL_0671;
				IL_0494:
				if (pInputBuffer <= ptr)
				{
					goto IL_004a;
				}
				goto IL_049b;
				IL_0117:
				if (UInt32FirstByteIsAscii(num2))
				{
					if (outputCharsRemaining >= 3)
					{
						uint num6 = ToLittleEndian(num2);
						nuint num7 = 1u;
						*pOutputBuffer = (char)(byte)num6;
						if (UInt32SecondByteIsAscii(num2))
						{
							num7++;
							num6 >>= 8;
							pOutputBuffer[1] = (char)(byte)num6;
							if (UInt32ThirdByteIsAscii(num2))
							{
								num7++;
								num6 >>= 8;
								pOutputBuffer[2] = (char)(byte)num6;
							}
						}
						pInputBuffer += num7;
						pOutputBuffer += num7;
						outputCharsRemaining -= (int)num7;
					}
					else
					{
						if (outputCharsRemaining == 0)
						{
							break;
						}
						uint num8 = ToLittleEndian(num2);
						pInputBuffer++;
						*(pOutputBuffer++) = (char)(byte)num8;
						outputCharsRemaining--;
						if (UInt32SecondByteIsAscii(num2))
						{
							if (outputCharsRemaining == 0)
							{
								break;
							}
							pInputBuffer++;
							num8 >>= 8;
							*(pOutputBuffer++) = (char)(byte)num8;
							if (UInt32ThirdByteIsAscii(num2))
							{
								break;
							}
							outputCharsRemaining = 0;
						}
					}
					if (pInputBuffer > ptr)
					{
						goto IL_049b;
					}
					num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
				}
				uint num9;
				while (UInt32BeginsWithUtf8TwoByteMask(num2))
				{
					if (!UInt32BeginsWithOverlongUtf8TwoByteSequence(num2))
					{
						while (true)
						{
							_ = BitConverter.IsLittleEndian;
							if (!UInt32EndsWithValidUtf8TwoByteSequenceLittleEndian(num2) && BitConverter.IsLittleEndian)
							{
								break;
							}
							if (outputCharsRemaining >= 2)
							{
								Unsafe.WriteUnaligned(pOutputBuffer, ExtractTwoCharsPackedFromTwoAdjacentTwoByteSequences(num2));
								pInputBuffer += 4;
								pOutputBuffer += 2;
								outputCharsRemaining -= 2;
								if (pInputBuffer <= ptr)
								{
									num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
									_ = BitConverter.IsLittleEndian;
									if (!UInt32BeginsWithValidUtf8TwoByteSequenceLittleEndian(num2))
									{
										goto IL_0051;
									}
									continue;
								}
							}
							goto IL_049b;
						}
						num9 = ExtractCharFromFirstTwoByteSequence(num2);
						if (UInt32ThirdByteIsAscii(num2))
						{
							if (UInt32FourthByteIsAscii(num2))
							{
								goto IL_0279;
							}
							if (outputCharsRemaining >= 2)
							{
								*pOutputBuffer = (char)num9;
								char* num10 = pOutputBuffer + 1;
								uint num11 = num2;
								if (!BitConverter.IsLittleEndian)
								{
								}
								*num10 = (char)(byte)(num11 >> 16);
								pInputBuffer += 3;
								pOutputBuffer += 2;
								outputCharsRemaining -= 2;
								if (ptr >= pInputBuffer)
								{
									num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
									continue;
								}
							}
						}
						else if (outputCharsRemaining != 0)
						{
							*pOutputBuffer = (char)num9;
							pInputBuffer += 2;
							pOutputBuffer++;
							outputCharsRemaining--;
							if (ptr >= pInputBuffer)
							{
								num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								break;
							}
						}
						goto IL_049b;
					}
					goto IL_0684;
				}
				if (UInt32BeginsWithUtf8ThreeByteMask(num2))
				{
					while (true)
					{
						_ = BitConverter.IsLittleEndian;
						if ((num2 & 0x200F) == 0 || ((num2 - 8205) & 0x200F) == 0)
						{
							break;
						}
						if (outputCharsRemaining == 0)
						{
							goto end_IL_0051;
						}
						_ = BitConverter.IsLittleEndian;
						if ((((int)num2 - -536870912) & -268435456) == 0 && outputCharsRemaining > 1 && Unsafe.ByteOffset(in *pInputBuffer, in *ptr) >= 3)
						{
							uint num12 = Unsafe.ReadUnaligned<uint>(pInputBuffer + 3);
							if (UInt32BeginsWithUtf8ThreeByteMask(num12) && (num12 & 0x200F) != 0 && ((num12 - 8205) & 0x200F) != 0)
							{
								*pOutputBuffer = (char)ExtractCharFromFirstThreeByteSequence(num2);
								pOutputBuffer[1] = (char)ExtractCharFromFirstThreeByteSequence(num12);
								pInputBuffer += 6;
								pOutputBuffer += 2;
								outputCharsRemaining -= 2;
								goto IL_03f1;
							}
						}
						*pOutputBuffer = (char)ExtractCharFromFirstThreeByteSequence(num2);
						pInputBuffer += 3;
						pOutputBuffer++;
						outputCharsRemaining--;
						goto IL_03f1;
						IL_03f1:
						if (UInt32FourthByteIsAscii(num2))
						{
							if (outputCharsRemaining == 0)
							{
								goto end_IL_0051;
							}
							_ = BitConverter.IsLittleEndian;
							*pOutputBuffer = (char)(num2 >> 24);
							pInputBuffer++;
							pOutputBuffer++;
							outputCharsRemaining--;
						}
						if (pInputBuffer <= ptr)
						{
							num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
							if (!UInt32BeginsWithUtf8ThreeByteMask(num2))
							{
								goto IL_0051;
							}
							continue;
						}
						goto IL_049b;
					}
				}
				else if (UInt32BeginsWithUtf8FourByteMask(num2))
				{
					_ = BitConverter.IsLittleEndian;
					if (UnicodeUtility.IsInRangeInclusive(BitOperations.RotateRight(num2 & 0xFFFF, 8), 4026531984u, 4093640847u))
					{
						if (outputCharsRemaining < 2)
						{
							break;
						}
						Unsafe.WriteUnaligned(pOutputBuffer, ExtractCharsFromFourByteSequence(num2));
						pInputBuffer += 4;
						pOutputBuffer += 2;
						outputCharsRemaining -= 2;
						goto IL_0494;
					}
				}
				goto IL_0684;
				IL_0279:
				if (outputCharsRemaining >= 3)
				{
					*pOutputBuffer = (char)num9;
					_ = BitConverter.IsLittleEndian;
					num2 >>= 16;
					pOutputBuffer[1] = (char)(byte)num2;
					num2 >>= 8;
					pOutputBuffer[2] = (char)num2;
					pInputBuffer += 4;
					pOutputBuffer += 3;
					outputCharsRemaining -= 3;
					goto IL_0494;
				}
				goto IL_049b;
				IL_00eb:
				if (Ascii.AllBytesInUInt32AreAscii(num2))
				{
					Ascii.WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref *pOutputBuffer, num2);
					num2 = num5;
					pInputBuffer += 4;
					pOutputBuffer += 4;
					outputCharsRemaining -= 4;
				}
				outputCharsRemaining -= 8 * num4;
				goto IL_0117;
				continue;
				end_IL_0051:
				break;
			}
			break;
		}
		goto IL_0680;
		IL_0684:
		OperationStatus result = OperationStatus.InvalidData;
		goto IL_0686;
		IL_0680:
		result = OperationStatus.DestinationTooSmall;
		goto IL_0686;
		IL_0686:
		pInputBufferRemaining = pInputBuffer;
		pOutputBufferRemaining = pOutputBuffer;
		return result;
		IL_0671:
		while (true)
		{
			if (inputLength > 0)
			{
				uint num13 = *pInputBuffer;
				if (num13 <= 127)
				{
					if (outputCharsRemaining != 0)
					{
						*pOutputBuffer = (char)num13;
						pInputBuffer++;
						pOutputBuffer++;
						inputLength--;
						outputCharsRemaining--;
						continue;
					}
					goto IL_0680;
				}
				num13 -= 194;
				if ((uint)(byte)num13 <= 29u)
				{
					if (inputLength < 2)
					{
						goto IL_067c;
					}
					uint num14 = pInputBuffer[1];
					if (IsLowByteUtf8ContinuationByte(num14))
					{
						if (outputCharsRemaining != 0)
						{
							uint num15 = (num13 << 6) + num14 + 128 - 128;
							*pOutputBuffer = (char)num15;
							pInputBuffer += 2;
							pOutputBuffer++;
							inputLength -= 2;
							outputCharsRemaining--;
							continue;
						}
						goto IL_0680;
					}
				}
				else if ((uint)(byte)num13 <= 45u)
				{
					if (inputLength >= 3)
					{
						uint num16 = pInputBuffer[1];
						uint num17 = pInputBuffer[2];
						if (IsLowByteUtf8ContinuationByte(num16) && IsLowByteUtf8ContinuationByte(num17))
						{
							uint num18 = (num13 << 12) + (num16 << 6);
							if (num18 >= 133120)
							{
								num18 -= 186368;
								if (num18 >= 2048)
								{
									if (outputCharsRemaining != 0)
									{
										num18 += num17;
										num18 += 55296;
										num18 -= 128;
										*pOutputBuffer = (char)num18;
										pInputBuffer += 3;
										pOutputBuffer++;
										inputLength -= 3;
										outputCharsRemaining--;
										continue;
									}
									goto IL_0680;
								}
							}
						}
					}
					else
					{
						if (inputLength < 2)
						{
							goto IL_067c;
						}
						uint num19 = pInputBuffer[1];
						if (IsLowByteUtf8ContinuationByte(num19))
						{
							uint num20 = (num13 << 6) + num19;
							if (num20 >= 2080 && !UnicodeUtility.IsInRangeInclusive(num20, 2912u, 2943u))
							{
								goto IL_067c;
							}
						}
					}
				}
				else if ((uint)(byte)num13 <= 50u)
				{
					if (inputLength < 2)
					{
						goto IL_067c;
					}
					uint num21 = pInputBuffer[1];
					if (IsLowByteUtf8ContinuationByte(num21) && UnicodeUtility.IsInRangeInclusive((num13 << 6) + num21, 3088u, 3343u))
					{
						if (inputLength < 3)
						{
							goto IL_067c;
						}
						if (IsLowByteUtf8ContinuationByte(pInputBuffer[2]))
						{
							if (inputLength < 4)
							{
								goto IL_067c;
							}
							if (IsLowByteUtf8ContinuationByte(pInputBuffer[3]))
							{
								goto IL_0680;
							}
						}
					}
				}
				goto IL_0684;
			}
			result = OperationStatus.Done;
			break;
			IL_067c:
			result = OperationStatus.NeedMoreData;
			break;
		}
		goto IL_0686;
	}

	public unsafe static OperationStatus TranscodeToUtf8(char* pInputBuffer, int inputLength, byte* pOutputBuffer, int outputBytesRemaining, out char* pInputBufferRemaining, out byte* pOutputBufferRemaining)
	{
		nuint num = Ascii.NarrowUtf16ToAscii(pInputBuffer, pOutputBuffer, (uint)Math.Min(inputLength, outputBytesRemaining));
		pInputBuffer += num;
		pOutputBuffer += num;
		if ((int)num == inputLength)
		{
			pInputBufferRemaining = pInputBuffer;
			pOutputBufferRemaining = pOutputBuffer;
			return OperationStatus.Done;
		}
		inputLength -= (int)num;
		outputBytesRemaining -= (int)num;
		if (inputLength < 2)
		{
			goto IL_0357;
		}
		char* ptr = pInputBuffer + (uint)inputLength - 2;
		_ = 0;
		if (false)
		{
		}
		uint num2;
		while (true)
		{
			num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
			int num6;
			while (true)
			{
				IL_0063:
				uint num7;
				if (Utf16Utility.AllCharsInUInt32AreAscii(num2))
				{
					if (outputBytesRemaining < 2)
					{
						break;
					}
					uint num3 = num2 | (num2 >> 8);
					Unsafe.WriteUnaligned(pOutputBuffer, (ushort)num3);
					pInputBuffer += 2;
					pOutputBuffer += 2;
					outputBytesRemaining -= 2;
					uint num4 = (uint)Math.Min((uint)((int)(ptr - pInputBuffer) + 2), outputBytesRemaining);
					_ = 0;
					if (false)
					{
					}
					uint num5 = num4 / 4;
					num6 = 0;
					while ((uint)num6 < num5)
					{
						num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
						num7 = Unsafe.ReadUnaligned<uint>(pInputBuffer + 2);
						if (Utf16Utility.AllCharsInUInt32AreAscii(num2 | num7))
						{
							Unsafe.WriteUnaligned(pOutputBuffer, (ushort)(num2 | (num2 >> 8)));
							Unsafe.WriteUnaligned(pOutputBuffer + 2, (ushort)(num7 | (num7 >> 8)));
							pInputBuffer += 4;
							pOutputBuffer += 4;
							num6++;
							continue;
						}
						goto IL_011f;
					}
					goto IL_0112;
				}
				goto IL_0150;
				IL_011f:
				outputBytesRemaining -= 4 * num6;
				if (Utf16Utility.AllCharsInUInt32AreAscii(num2))
				{
					Unsafe.WriteUnaligned(pOutputBuffer, (ushort)(num2 | (num2 >> 8)));
					pInputBuffer += 2;
					pOutputBuffer += 2;
					outputBytesRemaining -= 2;
					num2 = num7;
				}
				goto IL_0150;
				IL_0150:
				while (true)
				{
					if (IsFirstCharAscii(num2))
					{
						if (outputBytesRemaining == 0)
						{
							break;
						}
						_ = BitConverter.IsLittleEndian;
						*pOutputBuffer = (byte)num2;
						pInputBuffer++;
						pOutputBuffer++;
						outputBytesRemaining--;
						if (pInputBuffer > ptr)
						{
							goto IL_034c;
						}
						num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
					}
					if (!IsFirstCharAtLeastThreeUtf8Bytes(num2))
					{
						while (IsSecondCharTwoUtf8Bytes(num2))
						{
							if (outputBytesRemaining < 4)
							{
								goto end_IL_0063;
							}
							Unsafe.WriteUnaligned(pOutputBuffer, ExtractTwoUtf8TwoByteSequencesFromTwoPackedUtf16Chars(num2));
							pInputBuffer += 2;
							pOutputBuffer += 4;
							outputBytesRemaining -= 4;
							if (pInputBuffer <= ptr)
							{
								num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								if (!IsFirstCharTwoUtf8Bytes(num2))
								{
									goto IL_0063;
								}
								continue;
							}
							goto IL_034c;
						}
						if (outputBytesRemaining < 2)
						{
							break;
						}
						Unsafe.WriteUnaligned(pOutputBuffer, (ushort)ExtractUtf8TwoByteSequenceFromFirstUtf16Char(num2));
						if (IsSecondCharAscii(num2))
						{
							goto IL_01f6;
						}
						pInputBuffer++;
						pOutputBuffer += 2;
						outputBytesRemaining -= 2;
						if (pInputBuffer > ptr)
						{
							goto IL_034c;
						}
						num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
					}
					while (!IsFirstCharSurrogate(num2))
					{
						if (IsSecondCharAtLeastThreeUtf8Bytes(num2) && !IsSecondCharSurrogate(num2) && outputBytesRemaining >= 6)
						{
							WriteTwoUtf16CharsAsTwoUtf8ThreeByteSequences(ref *pOutputBuffer, num2);
							pInputBuffer += 2;
							pOutputBuffer += 6;
							outputBytesRemaining -= 6;
							if (pInputBuffer <= ptr)
							{
								num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								if (!IsFirstCharAtLeastThreeUtf8Bytes(num2))
								{
									goto IL_0063;
								}
								continue;
							}
						}
						else
						{
							if (outputBytesRemaining < 3)
							{
								goto end_IL_0150;
							}
							WriteFirstUtf16CharAsUtf8ThreeByteSequence(ref *pOutputBuffer, num2);
							pInputBuffer++;
							pOutputBuffer += 3;
							outputBytesRemaining -= 3;
							if (!IsSecondCharAscii(num2))
							{
								goto IL_0305;
							}
							if (outputBytesRemaining == 0)
							{
								goto end_IL_0150;
							}
							_ = BitConverter.IsLittleEndian;
							*pOutputBuffer = (byte)(num2 >> 16);
							pInputBuffer++;
							pOutputBuffer++;
							outputBytesRemaining--;
							if (pInputBuffer <= ptr)
							{
								num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								if (!IsFirstCharAtLeastThreeUtf8Bytes(num2))
								{
									goto IL_0063;
								}
								continue;
							}
						}
						goto IL_034c;
					}
					goto IL_0315;
					IL_0305:
					if (pInputBuffer <= ptr)
					{
						num2 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
						continue;
					}
					goto IL_034c;
					continue;
					end_IL_0150:
					break;
				}
				goto IL_040e;
				continue;
				end_IL_0063:
				break;
			}
			break;
			IL_0345:
			if (pInputBuffer <= ptr)
			{
				continue;
			}
			goto IL_034c;
			IL_0112:
			outputBytesRemaining -= 4 * num6;
			goto IL_0345;
			IL_01f6:
			if (outputBytesRemaining >= 3)
			{
				_ = BitConverter.IsLittleEndian;
				num2 >>= 16;
				pOutputBuffer[2] = (byte)num2;
				pInputBuffer += 2;
				pOutputBuffer += 3;
				outputBytesRemaining -= 3;
				goto IL_0345;
			}
			pInputBuffer++;
			pOutputBuffer += 2;
			goto IL_040e;
			IL_0315:
			if (IsWellFormedUtf16SurrogatePair(num2))
			{
				if (outputBytesRemaining >= 4)
				{
					Unsafe.WriteUnaligned(pOutputBuffer, ExtractFourUtf8BytesFromSurrogatePair(num2));
					pInputBuffer += 2;
					pOutputBuffer += 4;
					outputBytesRemaining -= 4;
					goto IL_0345;
				}
				goto IL_040e;
			}
			goto IL_0413;
		}
		_ = BitConverter.IsLittleEndian;
		uint num8 = num2 & 0xFFFF;
		goto IL_0372;
		IL_040e:
		OperationStatus result = OperationStatus.DestinationTooSmall;
		goto IL_0416;
		IL_0404:
		result = OperationStatus.Done;
		goto IL_0416;
		IL_0357:
		if (inputLength != 0)
		{
			num8 = *pInputBuffer;
			goto IL_0372;
		}
		goto IL_0404;
		IL_0416:
		pInputBufferRemaining = pInputBuffer;
		pOutputBufferRemaining = pOutputBuffer;
		return result;
		IL_0372:
		if (num8 <= 127)
		{
			if (outputBytesRemaining != 0)
			{
				*pOutputBuffer = (byte)num8;
				pInputBuffer++;
				pOutputBuffer++;
				goto IL_0400;
			}
		}
		else if (num8 < 2048)
		{
			if (outputBytesRemaining >= 2)
			{
				pOutputBuffer[1] = (byte)((num8 & 0x3F) | 0xFFFFFF80u);
				*pOutputBuffer = (byte)((num8 >> 6) | 0xFFFFFFC0u);
				pInputBuffer++;
				pOutputBuffer += 2;
				goto IL_0400;
			}
		}
		else
		{
			if (UnicodeUtility.IsSurrogateCodePoint(num8))
			{
				if (num8 > 56319)
				{
					goto IL_0413;
				}
				result = OperationStatus.NeedMoreData;
				goto IL_0416;
			}
			if (outputBytesRemaining >= 3)
			{
				pOutputBuffer[2] = (byte)((num8 & 0x3F) | 0xFFFFFF80u);
				pOutputBuffer[1] = (byte)(((num8 >> 6) & 0x3F) | 0xFFFFFF80u);
				*pOutputBuffer = (byte)((num8 >> 12) | 0xFFFFFFE0u);
				pInputBuffer++;
				pOutputBuffer += 3;
				goto IL_0400;
			}
		}
		goto IL_040e;
		IL_034c:
		inputLength = (int)(ptr - pInputBuffer) + 2;
		goto IL_0357;
		IL_0413:
		result = OperationStatus.InvalidData;
		goto IL_0416;
		IL_0400:
		if (inputLength <= 1)
		{
			goto IL_0404;
		}
		goto IL_040e;
	}

	public unsafe static byte* GetPointerToFirstInvalidByte(byte* pInputBuffer, int inputLength, out int utf16CodeUnitCountAdjustment, out int scalarCountAdjustment)
	{
		nuint indexOfFirstNonAsciiByte = Ascii.GetIndexOfFirstNonAsciiByte(pInputBuffer, (uint)inputLength);
		pInputBuffer += indexOfFirstNonAsciiByte;
		inputLength -= (int)indexOfFirstNonAsciiByte;
		if (inputLength == 0)
		{
			utf16CodeUnitCountAdjustment = 0;
			scalarCountAdjustment = 0;
			return pInputBuffer;
		}
		int num = 0;
		int num2 = 0;
		nuint num10;
		if (inputLength >= 4)
		{
			byte* ptr = pInputBuffer + (uint)inputLength - 4;
			while (pInputBuffer <= ptr)
			{
				uint num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
				while (true)
				{
					IL_0040:
					if (Ascii.AllBytesInUInt32AreAscii(num3))
					{
						pInputBuffer += 4;
						if (Unsafe.ByteOffset(in *pInputBuffer, in *ptr) < 16)
						{
							break;
						}
						num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
						if (Ascii.AllBytesInUInt32AreAscii(num3))
						{
							pInputBuffer = (byte*)((nuint)(pInputBuffer + 4) & (nuint)(~(nint)3));
							byte* ptr2 = ptr - 12;
							if (false)
							{
							}
							while (true)
							{
								if (false)
								{
								}
								if (Ascii.AllBytesInUInt32AreAscii(*(uint*)pInputBuffer | ((uint*)pInputBuffer)[1]))
								{
									if (Ascii.AllBytesInUInt32AreAscii(((uint*)pInputBuffer)[2] | ((uint*)pInputBuffer)[3]))
									{
										pInputBuffer += 16;
										if (pInputBuffer > ptr2)
										{
											break;
										}
										continue;
									}
									pInputBuffer += 8;
								}
								num3 = *(uint*)pInputBuffer;
								if (Ascii.AllBytesInUInt32AreAscii(num3))
								{
									pInputBuffer += 4;
									num3 = *(uint*)pInputBuffer;
								}
								goto IL_00d8;
							}
							break;
						}
					}
					goto IL_00d8;
					IL_00d8:
					uint num4 = Ascii.CountNumberOfLeadingAsciiBytesFromUInt32WithSomeNonAsciiData(num3);
					pInputBuffer += num4;
					if (ptr < pInputBuffer)
					{
						goto end_IL_029b;
					}
					num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
					while (true)
					{
						uint num5 = num3;
						if (!BitConverter.IsLittleEndian)
						{
						}
						num3 = num5 - 32960;
						uint num6 = num3;
						if (!BitConverter.IsLittleEndian)
						{
						}
						if ((num6 & 0xC0E0) != 0)
						{
							break;
						}
						_ = BitConverter.IsLittleEndian;
						if ((uint)(byte)num3 >= 2u)
						{
							if (!BitConverter.IsLittleEndian)
							{
							}
							while (true)
							{
								_ = BitConverter.IsLittleEndian;
								if (!UInt32EndsWithValidUtf8TwoByteSequenceLittleEndian(num3) && BitConverter.IsLittleEndian)
								{
									break;
								}
								pInputBuffer += 4;
								num -= 2;
								if (pInputBuffer > ptr)
								{
									goto end_IL_029b;
								}
								num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								_ = BitConverter.IsLittleEndian;
								if (!UInt32BeginsWithValidUtf8TwoByteSequenceLittleEndian(num3))
								{
									goto IL_0040;
								}
							}
							num--;
							if (UInt32ThirdByteIsAscii(num3))
							{
								if (UInt32FourthByteIsAscii(num3))
								{
									pInputBuffer += 4;
									goto end_IL_0040;
								}
								pInputBuffer += 3;
								if (pInputBuffer > ptr)
								{
									goto end_IL_0040;
								}
								num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
								continue;
							}
							pInputBuffer += 2;
							goto end_IL_0040;
						}
						goto IL_039a;
					}
					uint num7 = num3;
					if (!BitConverter.IsLittleEndian)
					{
					}
					num3 = num7 - 8388640;
					uint num8 = num3;
					if (!BitConverter.IsLittleEndian)
					{
					}
					if ((num8 & 0xC0C0F0) == 0)
					{
						while (true)
						{
							_ = BitConverter.IsLittleEndian;
							if ((num3 & 0x200F) == 0 || ((num3 - 8205) & 0x200F) == 0)
							{
								break;
							}
							_ = BitConverter.IsLittleEndian;
							nint num9 = (int)num3 >> 31;
							pInputBuffer += 4;
							pInputBuffer += num9;
							num -= 2;
							if (4 >= 8)
							{
							}
							if (pInputBuffer > ptr)
							{
								goto end_IL_029b;
							}
							num3 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
							if (!UInt32BeginsWithUtf8ThreeByteMask(num3))
							{
								goto IL_0040;
							}
						}
					}
					else
					{
						_ = BitConverter.IsLittleEndian;
						num3 &= 0xC0C0FFFFu;
						if ((int)num3 <= -2147467265)
						{
							num3 = BitOperations.RotateRight(num3, 8);
							if (UnicodeUtility.IsInRangeInclusive(num3, 276824080u, 343932943u))
							{
								pInputBuffer += 4;
								num -= 2;
								num2--;
								break;
							}
						}
					}
					goto IL_039a;
					continue;
					end_IL_0040:
					break;
				}
				continue;
				end_IL_029b:
				break;
			}
			num10 = (nuint)(Unsafe.ByteOffset(in *pInputBuffer, in *ptr) + 4);
		}
		else
		{
			num10 = (uint)inputLength;
		}
		while (num10 != 0)
		{
			uint num11 = *pInputBuffer;
			if ((uint)(byte)num11 < 128u)
			{
				pInputBuffer++;
				num10--;
				continue;
			}
			if (num10 < 2)
			{
				break;
			}
			uint value = pInputBuffer[1];
			if ((uint)(byte)num11 < 224u)
			{
				if ((uint)(byte)num11 < 194u || !IsLowByteUtf8ContinuationByte(value))
				{
					break;
				}
				pInputBuffer += 2;
				num--;
				num10 -= 2;
				continue;
			}
			if (num10 < 3 || (uint)(byte)num11 >= 240u)
			{
				break;
			}
			if ((byte)num11 == 224)
			{
				if (!UnicodeUtility.IsInRangeInclusive(value, 160u, 191u))
				{
					break;
				}
			}
			else if ((byte)num11 == 237)
			{
				if (!UnicodeUtility.IsInRangeInclusive(value, 128u, 159u))
				{
					break;
				}
			}
			else if (!IsLowByteUtf8ContinuationByte(value))
			{
				break;
			}
			if (!IsUtf8ContinuationByte(in pInputBuffer[2]))
			{
				break;
			}
			pInputBuffer += 3;
			num -= 2;
			num10 -= 3;
		}
		goto IL_039a;
		IL_039a:
		utf16CodeUnitCountAdjustment = num;
		scalarCountAdjustment = num2;
		return pInputBuffer;
	}
}
