using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Numerics;

public static class BitOperations
{
	private static class Crc32Fallback
	{
		private static readonly uint[] s_crcTable = Crc32ReflectedTable.Generate(2197175160u);

		internal static uint Crc32C(uint crc, byte data)
		{
			crc = Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(s_crcTable), (nint)(byte)(crc ^ data)) ^ (crc >> 8);
			return crc;
		}

		internal static uint Crc32C(uint crc, ushort data)
		{
			ref uint arrayDataReference = ref MemoryMarshal.GetArrayDataReference(s_crcTable);
			crc = Unsafe.Add(ref arrayDataReference, (nint)(byte)(crc ^ (byte)data)) ^ (crc >> 8);
			data >>= 8;
			crc = Unsafe.Add(ref arrayDataReference, (nint)(byte)(crc ^ data)) ^ (crc >> 8);
			return crc;
		}

		internal static uint Crc32C(uint crc, uint data)
		{
			return Crc32CCore(ref MemoryMarshal.GetArrayDataReference(s_crcTable), crc, data);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint Crc32CCore(ref uint lookupTable, uint crc, uint data)
		{
			crc = Unsafe.Add(ref lookupTable, (nint)(byte)(crc ^ (byte)data)) ^ (crc >> 8);
			data >>= 8;
			crc = Unsafe.Add(ref lookupTable, (nint)(byte)(crc ^ (byte)data)) ^ (crc >> 8);
			data >>= 8;
			crc = Unsafe.Add(ref lookupTable, (nint)(byte)(crc ^ (byte)data)) ^ (crc >> 8);
			data >>= 8;
			crc = Unsafe.Add(ref lookupTable, (nint)(byte)(crc ^ data)) ^ (crc >> 8);
			return crc;
		}
	}

	private static ReadOnlySpan<byte> TrailingZeroCountDeBruijn => new byte[32]
	{
		0, 1, 28, 2, 29, 14, 24, 3, 30, 22,
		20, 15, 25, 17, 4, 8, 31, 27, 13, 23,
		21, 19, 16, 7, 26, 12, 18, 6, 11, 5,
		10, 9
	};

	private static ReadOnlySpan<byte> Log2DeBruijn => new byte[32]
	{
		0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
		16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
		15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
		4, 31
	};

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPow2(int value)
	{
		if ((value & (value - 1)) == 0)
		{
			return value > 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static bool IsPow2(uint value)
	{
		if ((value & (value - 1)) == 0)
		{
			return value != 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPow2(long value)
	{
		if ((value & (value - 1)) == 0L)
		{
			return value > 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static bool IsPow2(ulong value)
	{
		if ((value & (value - 1)) == 0L)
		{
			return value != 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPow2(nint value)
	{
		if ((value & (value - 1)) == 0)
		{
			return value > 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static bool IsPow2(nuint value)
	{
		if ((value & (value - 1)) == 0)
		{
			return value != 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static uint RoundUpToPowerOf2(uint value)
	{
		_ = 0;
		_ = 0;
		if (false)
		{
		}
		value--;
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		return value + 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static ulong RoundUpToPowerOf2(ulong value)
	{
		_ = 0;
		_ = 0;
		if (false)
		{
		}
		value--;
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		value |= value >> 32;
		return value + 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static nuint RoundUpToPowerOf2(nuint value)
	{
		return RoundUpToPowerOf2((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int LeadingZeroCount(uint value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (value == 0)
		{
			return 32;
		}
		if (false)
		{
		}
		return 0x1F ^ Log2SoftwareFallback(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int LeadingZeroCount(ulong value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		uint num = (uint)(value >> 32);
		if (num == 0)
		{
			return 32 + LeadingZeroCount((uint)value);
		}
		return LeadingZeroCount(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int LeadingZeroCount(nuint value)
	{
		return LeadingZeroCount((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int Log2(uint value)
	{
		value |= 1;
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		return Log2SoftwareFallback(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int Log2(ulong value)
	{
		value |= 1;
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		uint num = (uint)(value >> 32);
		if (num == 0)
		{
			return Log2((uint)value);
		}
		return 32 + Log2(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int Log2(nuint value)
	{
		return Log2((uint)value);
	}

	private static int Log2SoftwareFallback(uint value)
	{
		value |= value >> 1;
		value |= value >> 2;
		value |= value >> 4;
		value |= value >> 8;
		value |= value >> 16;
		return Log2DeBruijn[(int)(value * 130329821 >> 27)];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int Log2Ceiling(ulong value)
	{
		int num = Log2(value);
		if (PopCount(value) != 1)
		{
			num++;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int PopCount(uint value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return SoftwareFallback(value);
		static int SoftwareFallback(uint num)
		{
			num -= (num >> 1) & 0x55555555;
			num = (num & 0x33333333) + ((num >> 2) & 0x33333333);
			num = ((num + (num >> 4)) & 0xF0F0F0F) * 16843009 >> 24;
			return (int)num;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int PopCount(ulong value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return PopCount((uint)value) + PopCount((uint)(value >> 32));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int PopCount(nuint value)
	{
		return PopCount((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int TrailingZeroCount(int value)
	{
		return TrailingZeroCount((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int TrailingZeroCount(uint value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (value == 0)
		{
			return 32;
		}
		if (false)
		{
		}
		return Unsafe.AddByteOffset(ref MemoryMarshal.GetReference(TrailingZeroCountDeBruijn), (int)((value & (0 - value)) * 125613361 >> 27));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static int TrailingZeroCount(long value)
	{
		return TrailingZeroCount((ulong)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int TrailingZeroCount(ulong value)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		uint num = (uint)value;
		if (num == 0)
		{
			return 32 + TrailingZeroCount((uint)(value >> 32));
		}
		return TrailingZeroCount(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static int TrailingZeroCount(nint value)
	{
		return TrailingZeroCount((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static int TrailingZeroCount(nuint value)
	{
		return TrailingZeroCount((uint)value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint RotateLeft(uint value, int offset)
	{
		return (value << offset) | (value >> 32 - offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static ulong RotateLeft(ulong value, int offset)
	{
		return (value << offset) | (value >> 64 - offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static nuint RotateLeft(nuint value, int offset)
	{
		return RotateLeft((uint)value, offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint RotateRight(uint value, int offset)
	{
		return (value >> offset) | (value << 32 - offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static ulong RotateRight(ulong value, int offset)
	{
		return (value >> offset) | (value << 64 - offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static nuint RotateRight(nuint value, int offset)
	{
		return RotateRight((uint)value, offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint Crc32C(uint crc, byte data)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return Crc32Fallback.Crc32C(crc, data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint Crc32C(uint crc, ushort data)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return Crc32Fallback.Crc32C(crc, data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint Crc32C(uint crc, uint data)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return Crc32Fallback.Crc32C(crc, data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[CLSCompliant(false)]
	public static uint Crc32C(uint crc, ulong data)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return Crc32C(Crc32C(crc, (uint)data), (uint)(data >> 32));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint ResetLowestSetBit(uint value)
	{
		return value & (value - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint FlipBit(uint value, int index)
	{
		return value ^ (uint)(1 << index);
	}
}
