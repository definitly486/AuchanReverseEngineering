using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.Text;

internal static class Latin1Utility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static nuint GetIndexOfFirstNonLatin1Char(char* pBuffer, nuint bufferLength)
	{
		_ = 0;
		return GetIndexOfFirstNonLatin1Char_Default(pBuffer, bufferLength);
	}

	private unsafe static nuint GetIndexOfFirstNonLatin1Char_Default(char* pBuffer, nuint bufferLength)
	{
		char* ptr = pBuffer;
		if (Vector.IsHardwareAccelerated && bufferLength >= (uint)(2 * Vector<ushort>.Count))
		{
			uint count = (uint)Vector<ushort>.Count;
			uint count2 = (uint)Vector<byte>.Count;
			Vector<ushort> right = new Vector<ushort>(255);
			if (Vector.LessThanOrEqualAll(Unsafe.ReadUnaligned<Vector<ushort>>(pBuffer), right))
			{
				char* ptr2 = pBuffer + bufferLength - count;
				pBuffer = (char*)((nuint)((byte*)pBuffer + count2) & ~(nuint)(count2 - 1));
				while (!Vector.GreaterThanAny(Unsafe.Read<Vector<ushort>>(pBuffer), right))
				{
					pBuffer += count;
					if (pBuffer > ptr2)
					{
						break;
					}
				}
				bufferLength -= (nuint)(nint)(pBuffer - ptr);
			}
		}
		while (true)
		{
			uint num;
			if (bufferLength >= 4)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				uint num2 = Unsafe.ReadUnaligned<uint>(pBuffer + 2);
				if (!AllCharsInUInt32AreLatin1(num | num2))
				{
					if (AllCharsInUInt32AreLatin1(num))
					{
						num = num2;
						pBuffer += 2;
					}
					goto IL_010a;
				}
				pBuffer += 4;
				bufferLength -= 4;
				continue;
			}
			if ((bufferLength & 2) != 0)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				if (!AllCharsInUInt32AreLatin1(num))
				{
					goto IL_010a;
				}
				pBuffer += 2;
			}
			if ((bufferLength & 1) != 0 && *pBuffer <= 'ÿ')
			{
				pBuffer++;
			}
			break;
			IL_010a:
			if (FirstCharInUInt32IsLatin1(num))
			{
				pBuffer++;
			}
			break;
		}
		return (nuint)(pBuffer - ptr);
	}

	public unsafe static nuint NarrowUtf16ToLatin1(char* pUtf16Buffer, byte* pLatin1Buffer, nuint elementCount)
	{
		nuint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		ulong num4 = 0uL;
		if (false)
		{
		}
		if (Vector.IsHardwareAccelerated)
		{
			uint num5 = (uint)sizeof(Vector<byte>);
			if (elementCount >= 2 * num5)
			{
				if (4 >= 8)
				{
				}
				num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer);
				num3 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + 2);
				if (!AllCharsInUInt32AreLatin1(num2 | num3))
				{
					goto IL_0186;
				}
				Vector<ushort> right = new Vector<ushort>(255);
				nuint num6 = elementCount - 2 * num5;
				do
				{
					Vector<ushort> vector = Unsafe.ReadUnaligned<Vector<ushort>>(pUtf16Buffer + num);
					Vector<ushort> vector2 = Unsafe.ReadUnaligned<Vector<ushort>>(pUtf16Buffer + num + Vector<ushort>.Count);
					if (Vector.GreaterThanAny(Vector.BitwiseOr(vector, vector2), right))
					{
						break;
					}
					Vector<byte> value = Vector.Narrow(vector, vector2);
					Unsafe.WriteUnaligned(pLatin1Buffer + num, value);
					num += num5;
				}
				while (num <= num6);
			}
		}
		nuint num7 = elementCount - num;
		if (num7 < 4)
		{
			goto IL_012f;
		}
		nuint num8 = num + num7 - 4;
		while (true)
		{
			if (4 >= 8)
			{
			}
			num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num);
			num3 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num + 2);
			if (!AllCharsInUInt32AreLatin1(num2 | num3))
			{
				break;
			}
			NarrowTwoUtf16CharsToLatin1AndWriteToBuffer(ref pLatin1Buffer[num], num2);
			NarrowTwoUtf16CharsToLatin1AndWriteToBuffer(ref pLatin1Buffer[num + 2], num3);
			num += 4;
			if (num <= num8)
			{
				continue;
			}
			goto IL_012f;
		}
		goto IL_0186;
		IL_012f:
		if (((int)num7 & 2) != 0)
		{
			num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num);
			if (!AllCharsInUInt32AreLatin1(num2))
			{
				goto IL_01a8;
			}
			NarrowTwoUtf16CharsToLatin1AndWriteToBuffer(ref pLatin1Buffer[num], num2);
			num += 2;
		}
		if (((int)num7 & 1) != 0)
		{
			num2 = pUtf16Buffer[num];
			if (num2 <= 255)
			{
				pLatin1Buffer[num] = (byte)num2;
				num++;
			}
		}
		goto IL_0184;
		IL_01a8:
		if (FirstCharInUInt32IsLatin1(num2))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			pLatin1Buffer[num] = (byte)num2;
			num++;
		}
		goto IL_0184;
		IL_0184:
		return num;
		IL_0186:
		if (4 >= 8)
		{
		}
		if (AllCharsInUInt32AreLatin1(num2))
		{
			NarrowTwoUtf16CharsToLatin1AndWriteToBuffer(ref pLatin1Buffer[num], num2);
			num2 = num3;
			num += 2;
		}
		goto IL_01a8;
	}

	public unsafe static void WidenLatin1ToUtf16(byte* pLatin1Buffer, char* pUtf16Buffer, nuint elementCount)
	{
		if (false)
		{
		}
		WidenLatin1ToUtf16_Fallback(pLatin1Buffer, pUtf16Buffer, elementCount);
	}

	private unsafe static void WidenLatin1ToUtf16_Fallback(byte* pLatin1Buffer, char* pUtf16Buffer, nuint elementCount)
	{
		nuint num = 0u;
		if (Vector.IsHardwareAccelerated)
		{
			uint count = (uint)Vector<byte>.Count;
			if (elementCount >= count)
			{
				nuint num2 = elementCount - count;
				do
				{
					Vector.Widen(Vector.AsVectorByte(Unsafe.ReadUnaligned<Vector<byte>>(pLatin1Buffer + num)), out var low, out var high);
					Unsafe.WriteUnaligned(pUtf16Buffer + num, low);
					Unsafe.WriteUnaligned(pUtf16Buffer + num + Vector<ushort>.Count, high);
					num += count;
				}
				while (num <= num2);
			}
		}
		for (; num < elementCount; num++)
		{
			pUtf16Buffer[num] = (char)pLatin1Buffer[num];
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInUInt32AreLatin1(uint value)
	{
		return (value & 0xFF00FF00u) == 0;
	}

	private static bool FirstCharInUInt32IsLatin1(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0xFF00) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void NarrowTwoUtf16CharsToLatin1AndWriteToBuffer(ref byte outputBuffer, uint value)
	{
		_ = BitConverter.IsLittleEndian;
		outputBuffer = (byte)value;
		Unsafe.Add(ref outputBuffer, 1) = (byte)(value >> 16);
	}
}
