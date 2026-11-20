using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Unicode;

namespace System;

internal static class HexConverter
{
	public enum Casing : uint
	{
		Upper = 0u,
		Lower = 8224u
	}

	private ref struct SpanCasingPair
	{
		public ReadOnlySpan<byte> Bytes { get; set; }

		public Casing Casing { get; set; }
	}

	public static ReadOnlySpan<byte> CharToHexLookup => new byte[256]
	{
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
		2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
		255, 255, 255, 255, 255, 10, 11, 12, 13, 14,
		15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
		13, 14, 15, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255
	};

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ToBytesBuffer(byte value, Span<byte> buffer, int startingIndex = 0, Casing casing = Casing.Upper)
	{
		uint num = (uint)(((value & 0xF0) << 4) + (value & 0xF) - 35209);
		uint num2 = ((((0 - num) & 0x7070) >> 4) + num + 47545) | (uint)casing;
		buffer[startingIndex + 1] = (byte)num2;
		buffer[startingIndex] = (byte)(num2 >> 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ToCharsBuffer(byte value, Span<char> buffer, int startingIndex = 0, Casing casing = Casing.Upper)
	{
		uint num = (uint)(((value & 0xF0) << 4) + (value & 0xF) - 35209);
		uint num2 = ((((0 - num) & 0x7070) >> 4) + num + 47545) | (uint)casing;
		buffer[startingIndex + 1] = (char)(num2 & 0xFF);
		buffer[startingIndex] = (char)(num2 >> 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static (Vector128<byte>, Vector128<byte>) AsciiToHexVector128(Vector128<byte> src, Vector128<byte> hexMap)
	{
		Vector128<byte> left = Vector128.ShiftRightLogical(src.AsUInt64(), 4).AsByte();
		Vector128<byte> vector = Vector128.UnpackLow(left, src);
		Vector128<byte> vector2 = Vector128.UnpackHigh(left, src);
		return (Vector128.ShuffleNative(hexMap, vector & Vector128.Create((byte)15)), Vector128.ShuffleNative(hexMap, vector2 & Vector128.Create((byte)15)));
	}

	private static void EncodeTo_Vector128<TChar>(ReadOnlySpan<byte> source, Span<TChar> destination, Casing casing)
	{
		ref byte reference = ref MemoryMarshal.GetReference(source);
		ref TChar reference2 = ref MemoryMarshal.GetReference(destination);
		Vector128<byte> hexMap = ((casing == Casing.Upper) ? Vector128.Create((byte)48, (byte)49, (byte)50, (byte)51, (byte)52, (byte)53, (byte)54, (byte)55, (byte)56, (byte)57, (byte)65, (byte)66, (byte)67, (byte)68, (byte)69, (byte)70) : Vector128.Create((byte)48, (byte)49, (byte)50, (byte)51, (byte)52, (byte)53, (byte)54, (byte)55, (byte)56, (byte)57, (byte)97, (byte)98, (byte)99, (byte)100, (byte)101, (byte)102));
		nuint num = 0u;
		nuint num2 = (nuint)source.Length - (nuint)(Vector128<TChar>.Count / 2);
		while (true)
		{
			Vector128<byte> src = ((!(typeof(TChar) == typeof(byte))) ? Vector128.CreateScalar(Unsafe.ReadUnaligned<uint>(in Unsafe.Add(ref reference, num))).AsByte() : Vector128.CreateScalar(Unsafe.ReadUnaligned<ulong>(in Unsafe.Add(ref reference, num))).AsByte());
			Vector128<byte> item = AsciiToHexVector128(src, hexMap).Item1;
			if (typeof(TChar) == typeof(byte))
			{
				item.As<byte, TChar>().StoreUnsafe(ref reference2, num * 2);
			}
			else
			{
				Vector128.WidenLower(item).As<ushort, TChar>().StoreUnsafe(ref reference2, num * 2);
			}
			num += (nuint)(Vector128<TChar>.Count / 2);
			if (num == (nuint)source.Length)
			{
				break;
			}
			if (num > num2)
			{
				num = num2;
			}
		}
	}

	public static void EncodeToUtf8(ReadOnlySpan<byte> source, Span<byte> utf8Destination, Casing casing = Casing.Upper)
	{
		if ((AdvSimd.Arm64.IsSupported ? true : false) && source.Length >= Vector128<byte>.Count / 2)
		{
			EncodeTo_Vector128(source, utf8Destination, casing);
			return;
		}
		for (int i = 0; i < source.Length; i++)
		{
			ToBytesBuffer(source[i], utf8Destination, i * 2, casing);
		}
	}

	public static void EncodeToUtf16(ReadOnlySpan<byte> source, Span<char> destination, Casing casing = Casing.Upper)
	{
		if ((AdvSimd.Arm64.IsSupported ? true : false) && source.Length >= Vector128<ushort>.Count / 2)
		{
			EncodeTo_Vector128(source, Unsafe.BitCast<Span<char>, Span<ushort>>(destination), casing);
			return;
		}
		for (int i = 0; i < source.Length; i++)
		{
			ToCharsBuffer(source[i], destination, i * 2, casing);
		}
	}

	public static string ToString(ReadOnlySpan<byte> bytes, Casing casing = Casing.Upper)
	{
		SpanCasingPair state = new SpanCasingPair
		{
			Bytes = bytes,
			Casing = casing
		};
		return string.Create(bytes.Length * 2, state, delegate(Span<char> chars, SpanCasingPair args)
		{
			EncodeToUtf16(args.Bytes, chars, args.Casing);
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static char ToCharUpper(int value)
	{
		value &= 0xF;
		value += 48;
		if (value > 57)
		{
			value += 7;
		}
		return (char)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static char ToCharLower(int value)
	{
		value &= 0xF;
		value += 48;
		if (value > 57)
		{
			value += 39;
		}
		return (char)value;
	}

	public static bool TryDecodeFromUtf8(ReadOnlySpan<byte> utf8Source, Span<byte> destination, out int bytesProcessed)
	{
		_ = BitConverter.IsLittleEndian;
		_ = 0;
		if ((AdvSimd.Arm64.IsSupported ? true : false) && utf8Source.Length >= Vector128<byte>.Count)
		{
			return TryDecodeFrom_Vector128(utf8Source, destination, out bytesProcessed);
		}
		return TryDecodeFromUtf8_Scalar(utf8Source, destination, out bytesProcessed);
	}

	public static bool TryDecodeFromUtf16(ReadOnlySpan<char> source, Span<byte> destination, out int charsProcessed)
	{
		_ = BitConverter.IsLittleEndian;
		_ = 0;
		if ((AdvSimd.Arm64.IsSupported ? true : false) && source.Length >= Vector128<ushort>.Count * 2)
		{
			return TryDecodeFrom_Vector128(Unsafe.BitCast<ReadOnlySpan<char>, ReadOnlySpan<ushort>>(source), destination, out charsProcessed);
		}
		return TryDecodeFromUtf16_Scalar(source, destination, out charsProcessed);
	}

	public static bool TryDecodeFrom_Vector128<TChar>(ReadOnlySpan<TChar> source, Span<byte> destination, out int elementsProcessed)
	{
		int num = ((!(typeof(TChar) == typeof(byte))) ? (Vector128<ushort>.Count * 2) : Vector128<byte>.Count);
		nuint num2 = 0u;
		nuint num3 = (nuint)source.Length - (nuint)num;
		ref TChar reference = ref MemoryMarshal.GetReference(source);
		ref byte reference2 = ref MemoryMarshal.GetReference(destination);
		while (true)
		{
			Vector128<byte> vector;
			if (typeof(TChar) == typeof(byte))
			{
				vector = Vector128.LoadUnsafe(in reference, num2).AsByte();
				if (!Utf8Utility.AllBytesInVector128AreAscii(vector))
				{
					break;
				}
			}
			else
			{
				Vector128<ushort> vector2 = Vector128.LoadUnsafe(in reference, num2).AsUInt16();
				Vector128<ushort> vector3 = Vector128.LoadUnsafe(in reference, num2 + (nuint)Vector128<ushort>.Count).AsUInt16();
				vector = Ascii.ExtractAsciiVector(vector2, vector3);
				if (!Utf16Utility.AllCharsInVectorAreAscii(vector2 | vector3))
				{
					break;
				}
			}
			Vector128<byte> vector4 = Vector128.SubtractSaturate(vector + Vector128.Create<byte>((byte)198), Vector128.Create<byte>((byte)6));
			Vector128<byte> right = Vector128.AddSaturate((vector & Vector128.Create<byte>((byte)223)) - Vector128.Create((byte)65), Vector128.Create<byte>((byte)10));
			Vector128<byte> left = Vector128.Min(vector4 - Vector128.Create<byte>((byte)240), right);
			if (Vector128.AddSaturate(left, Vector128.Create<byte>((byte)112)).ExtractMostSignificantBits() != 0)
			{
				break;
			}
			if (false)
			{
			}
			Vector128<byte> vector5;
			if (AdvSimd.Arm64.IsSupported)
			{
				Vector128<short> value = AdvSimd.Arm64.TransposeEven(left, Vector128<byte>.Zero).AsInt16();
				Vector128<short> right2 = AdvSimd.Arm64.TransposeOdd(left, Vector128<byte>.Zero).AsInt16();
				value = AdvSimd.ShiftLeftLogical(value, 4).AsInt16();
				vector5 = AdvSimd.AddSaturate(value, right2).AsByte();
			}
			else
			{
				if (false)
				{
				}
				ThrowHelper.ThrowUnreachableException();
				vector5 = default(Vector128<byte>);
			}
			vector5 = Vector128.Shuffle(vector5, Vector128.Create((byte)0, (byte)2, (byte)4, (byte)6, (byte)8, (byte)10, (byte)12, (byte)14, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0));
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref reference2, num2 / 2), vector5.AsUInt64().ToScalar());
			num2 += (nuint)num;
			if (num2 == (nuint)source.Length)
			{
				elementsProcessed = source.Length;
				return true;
			}
			if (num2 > num3)
			{
				num2 = num3;
			}
		}
		bool result = ((!(typeof(TChar) == typeof(byte))) ? TryDecodeFromUtf16_Scalar(Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(source.Slice((int)num2)), destination.Slice((int)(num2 / 2)), out elementsProcessed) : TryDecodeFromUtf8_Scalar(Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(source.Slice((int)num2)), destination.Slice((int)(num2 / 2)), out elementsProcessed));
		elementsProcessed = (int)num2 + elementsProcessed;
		return result;
	}

	private static bool TryDecodeFromUtf8_Scalar(ReadOnlySpan<byte> utf8Source, Span<byte> destination, out int bytesProcessed)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num2 < destination.Length)
		{
			num3 = FromChar(utf8Source[num + 1]);
			num4 = FromChar(utf8Source[num]);
			if ((num3 | num4) == 255)
			{
				break;
			}
			destination[num2++] = (byte)((num4 << 4) | num3);
			num += 2;
		}
		if (num3 == 255)
		{
			num++;
		}
		bytesProcessed = num;
		return (num3 | num4) != 255;
	}

	private static bool TryDecodeFromUtf16_Scalar(ReadOnlySpan<char> source, Span<byte> destination, out int charsProcessed)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num2 < destination.Length)
		{
			num3 = FromChar(source[num + 1]);
			num4 = FromChar(source[num]);
			if ((num3 | num4) == 255)
			{
				break;
			}
			destination[num2++] = (byte)((num4 << 4) | num3);
			num += 2;
		}
		if (num3 == 255)
		{
			num++;
		}
		charsProcessed = num;
		return (num3 | num4) != 255;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FromChar(int c)
	{
		if (c < CharToHexLookup.Length)
		{
			return CharToHexLookup[c];
		}
		return 255;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsHexChar(int c)
	{
		_ = 8;
		ulong num = (uint)(c - 48);
		long num2 = -17875860044349952L << (int)num;
		ulong num3 = num - 64;
		return (long)((ulong)num2 & num3) < 0L;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsHexUpperChar(int c)
	{
		if ((uint)(c - 48) > 9u)
		{
			return (uint)(c - 65) <= 5u;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsHexLowerChar(int c)
	{
		if ((uint)(c - 48) > 9u)
		{
			return (uint)(c - 97) <= 5u;
		}
		return true;
	}
}
