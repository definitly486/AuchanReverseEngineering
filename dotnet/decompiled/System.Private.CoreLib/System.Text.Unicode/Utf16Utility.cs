using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace System.Text.Unicode;

internal static class Utf16Utility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllCharsInUInt32AreAscii(uint value)
	{
		return (value & 0xFF80FF80u) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllCharsInUInt64AreAscii(ulong value)
	{
		return (value & 0xFF80FF80FF80FF80uL) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ConvertAllAsciiCharsInUInt32ToLowercase(uint value)
	{
		uint num = value + 8388736 - 4259905;
		uint num2 = value + 8388736 - 5963867;
		uint num3 = ((num ^ num2) & 0x800080) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ConvertAllAsciiCharsInUInt32ToUppercase(uint value)
	{
		uint num = value + 8388736 - 6357089;
		uint num2 = value + 8388736 - 8061051;
		uint num3 = ((num ^ num2) & 0x800080) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ulong ConvertAllAsciiCharsInUInt64ToUppercase(ulong value)
	{
		ulong num = value + 36029346783166592L - 27303489359118433L;
		ulong num2 = value + 36029346783166592L - 34621950424449147L;
		ulong num3 = ((num ^ num2) & 0x80008000800080L) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ulong ConvertAllAsciiCharsInUInt64ToLowercase(ulong value)
	{
		ulong num = value + 36029346783166592L - 18296152663326785L;
		ulong num2 = value + 36029346783166592L - 25614613728657499L;
		ulong num3 = ((num ^ num2) & 0x80008000800080L) >> 2;
		return value ^ num3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool UInt32ContainsAnyLowercaseAsciiChar(uint value)
	{
		uint num = value + 8388736 - 6357089;
		uint num2 = value + 8388736 - 8061051;
		return ((num ^ num2) & 0x800080) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool UInt32ContainsAnyUppercaseAsciiChar(uint value)
	{
		uint num = value + 8388736 - 4259905;
		uint num2 = value + 8388736 - 5963867;
		return ((num ^ num2) & 0x800080) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool UInt32OrdinalIgnoreCaseAscii(uint valueA, uint valueB)
	{
		uint num = (valueA ^ valueB) << 2;
		uint num2 = valueA + 327685;
		num2 |= 0xA000A0;
		num2 += 1703962;
		num2 |= 0xFF7FFF7Fu;
		return (num & num2) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool UInt64OrdinalIgnoreCaseAscii(ulong valueA, ulong valueB)
	{
		ulong num = (valueA ^ valueB) << 2;
		ulong num2 = valueA + 1407396358717445L;
		num2 |= 0xA000A000A000A0L;
		num2 += 7318461065330714L;
		num2 |= 0xFF7FFF7FFF7FFF7FuL;
		return (num & num2) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllCharsInVectorAreAscii<TVector>(TVector vec) where TVector : struct, ISimdVector<TVector, ushort>
	{
		return (vec & TVector.Create(65408)) == TVector.Zero;
	}

	public unsafe static char* GetPointerToFirstInvalidChar(char* pInputBuffer, int inputLength, out long utf8CodeUnitCountAdjustment, out int scalarCountAdjustment)
	{
		int num = (int)Ascii.GetIndexOfFirstNonAsciiChar(pInputBuffer, (uint)inputLength);
		pInputBuffer += (uint)num;
		inputLength -= num;
		if (inputLength == 0)
		{
			utf8CodeUnitCountAdjustment = 0L;
			scalarCountAdjustment = 0;
			return pInputBuffer;
		}
		long num2 = 0L;
		int num3 = 0;
		char* ptr = pInputBuffer + (uint)inputLength;
		if (false)
		{
		}
		if (!Vector128.IsHardwareAccelerated || inputLength < Vector128<ushort>.Count)
		{
			goto IL_024c;
		}
		Vector128<ushort> right = Vector128.Create<ushort>((ushort)128);
		Vector128<ushort> right2 = Vector128.Create<ushort>((ushort)1024);
		Vector128<ushort> right3 = Vector128.Create<ushort>((ushort)2048);
		Vector128<ushort> vector = Vector128.Create<ushort>((ushort)55296);
		char* ptr2 = ptr - Vector128<ushort>.Count;
		while (true)
		{
			Vector128<ushort> left = Vector128.Load((ushort*)pInputBuffer);
			Vector128<ushort> vector2 = Vector128.GreaterThanOrEqual(left, right);
			Vector128<ushort> vector3 = Vector128.GreaterThanOrEqual(left, right3);
			Vector128<nuint> vector4 = (Vector128<ushort>.Zero - vector2 - vector3).AsNUInt();
			nuint num4 = 0u;
			for (int i = 0; i < Vector128<nuint>.Count; i++)
			{
				num4 += vector4[i];
			}
			uint num5 = (uint)num4;
			_ = 8;
			num5 += (uint)(int)(num4 >> (0x20 & 0x3F));
			num5 = (ushort)num5 + (num5 >> 16);
			left -= vector;
			Vector128<ushort> vector5 = Vector128.LessThan(left, right3);
			if (vector5 != Vector128<ushort>.Zero)
			{
				Vector128<ushort> right4 = Vector128.LessThan(left, right2);
				Vector128<ushort> vector6 = Vector128.AndNot(vector5, right4);
				if (vector6[0] != 0)
				{
					break;
				}
				ushort num6 = 0;
				int num7 = 0;
				while (num7 < Vector128<ushort>.Count - 1)
				{
					num6 -= right4[num7];
					if (right4[num7] == vector6[num7 + 1])
					{
						num7++;
						continue;
					}
					goto IL_024c;
				}
				if (right4[Vector128<ushort>.Count - 1] != 0)
				{
					pInputBuffer--;
					num5 -= 2;
				}
				nint num8 = num6;
				num3 -= (int)num8;
				num2 -= num8;
				num2 -= num8;
			}
			num2 += num5;
			pInputBuffer += Vector128<ushort>.Count;
			if (pInputBuffer <= ptr2)
			{
				continue;
			}
			goto IL_024c;
		}
		goto IL_0250;
		IL_024c:
		while (pInputBuffer < ptr)
		{
			uint num9 = *pInputBuffer;
			if (num9 > 127)
			{
				num2 += num9 + 129024 >> 16;
				if (UnicodeUtility.IsSurrogateCodePoint(num9))
				{
					num2 -= 2;
					if ((nuint)((byte*)ptr - (nuint)pInputBuffer) < (nuint)4u)
					{
						break;
					}
					num9 = Unsafe.ReadUnaligned<uint>(pInputBuffer);
					uint num10 = num9;
					if (!BitConverter.IsLittleEndian)
					{
					}
					if ((((int)num10 - -603924480) & -67044352) != 0)
					{
						break;
					}
					num3--;
					num2 += 2;
					pInputBuffer++;
				}
			}
			pInputBuffer++;
		}
		goto IL_0250;
		IL_0250:
		utf8CodeUnitCountAdjustment = num2;
		scalarCountAdjustment = num3;
		return pInputBuffer;
	}
}
