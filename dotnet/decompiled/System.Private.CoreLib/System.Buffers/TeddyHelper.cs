using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace System.Buffers;

internal static class TeddyHelper
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (Vector128<byte> Result, Vector128<byte> Prev0) ProcessInputN2(Vector128<byte> input, Vector128<byte> prev0, Vector128<byte> n0Low, Vector128<byte> n0High, Vector128<byte> n1Low, Vector128<byte> n1High)
	{
		(Vector128<byte> Low, Vector128<byte> High) nibbles = GetNibbles(input);
		Vector128<byte> item = nibbles.Low;
		Vector128<byte> item2 = nibbles.High;
		Vector128<byte> vector = Shuffle(n0Low, n0High, item, item2);
		Vector128<byte> vector2 = Shuffle(n1Low, n1High, item, item2);
		return (Result: RightShift1(prev0, vector) & vector2, Prev0: vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (Vector128<byte> Result, Vector128<byte> Prev0, Vector128<byte> Prev1) ProcessInputN3(Vector128<byte> input, Vector128<byte> prev0, Vector128<byte> prev1, Vector128<byte> n0Low, Vector128<byte> n0High, Vector128<byte> n1Low, Vector128<byte> n1High, Vector128<byte> n2Low, Vector128<byte> n2High)
	{
		(Vector128<byte> Low, Vector128<byte> High) nibbles = GetNibbles(input);
		Vector128<byte> item = nibbles.Low;
		Vector128<byte> item2 = nibbles.High;
		Vector128<byte> vector = Shuffle(n0Low, n0High, item, item2);
		Vector128<byte> vector2 = Shuffle(n1Low, n1High, item, item2);
		Vector128<byte> vector3 = Shuffle(n2Low, n2High, item, item2);
		Vector128<byte> vector4 = RightShift2(prev0, vector);
		Vector128<byte> vector5 = RightShift1(prev1, vector2);
		return (Result: vector4 & vector5 & vector3, Prev0: vector, Prev1: vector2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector128<byte> LoadAndPack16AsciiChars(ref char source)
	{
		Vector128<ushort> vector = Vector128.LoadUnsafe(ref source);
		Vector128<ushort> vector2 = Vector128.LoadUnsafe(ref source, (nuint)Vector128<ushort>.Count);
		if (false)
		{
		}
		if (AdvSimd.Arm64.IsSupported)
		{
			return AdvSimd.Arm64.UnzipEven(vector.AsByte(), vector2.AsByte());
		}
		ThrowHelper.ThrowUnreachableException();
		return default(Vector128<byte>);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static (Vector128<byte> Low, Vector128<byte> High) GetNibbles(Vector128<byte> input)
	{
		_ = 0;
		Vector128<byte> item = input & Vector128.Create((byte)15);
		Vector128<byte> item2 = input >>> 4;
		return (Low: item, High: item2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> Shuffle(Vector128<byte> maskLow, Vector128<byte> maskHigh, Vector128<byte> low, Vector128<byte> high)
	{
		return SearchValues.ShuffleNativeModified(maskLow, low) & Vector128.ShuffleNative(maskHigh, high);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> RightShift1(Vector128<byte> left, Vector128<byte> right)
	{
		if (false)
		{
		}
		if (AdvSimd.IsSupported)
		{
			return AdvSimd.ExtractVector128(left, right, 15);
		}
		ThrowHelper.ThrowUnreachableException();
		return default(Vector128<byte>);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector128<byte> RightShift2(Vector128<byte> left, Vector128<byte> right)
	{
		if (false)
		{
		}
		if (AdvSimd.IsSupported)
		{
			return AdvSimd.ExtractVector128(left, right, 14);
		}
		ThrowHelper.ThrowUnreachableException();
		return default(Vector128<byte>);
	}
}
