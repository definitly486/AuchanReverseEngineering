using System.Runtime.CompilerServices;

namespace System;

internal static class HexConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsHexChar(int c)
	{
		_ = 8;
		ulong num = (uint)(c - 48);
		long num2 = -17875860044349952L << (int)num;
		ulong num3 = num - 64;
		return (long)((ulong)num2 & num3) < 0L;
	}
}
