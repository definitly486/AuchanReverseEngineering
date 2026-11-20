using System.Buffers.Binary;
using System.Numerics;

namespace System.Net.Security;

internal sealed class MD4
{
	internal static void HashData(ReadOnlySpan<byte> source, Span<byte> destination)
	{
		Span<byte> buffer = stackalloc byte[64];
		buffer.Clear();
		global::_003C_003Ey__InlineArray4<uint> buffer2 = default(global::_003C_003Ey__InlineArray4<uint>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<uint>, uint>(ref buffer2, 0) = 1732584193u;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<uint>, uint>(ref buffer2, 1) = 4023233417u;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<uint>, uint>(ref buffer2, 2) = 2562383102u;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<uint>, uint>(ref buffer2, 3) = 271733878u;
		Span<uint> span = global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<global::_003C_003Ey__InlineArray4<uint>, uint>(ref buffer2, 4);
		global::_003C_003Ey__InlineArray2<uint> buffer3 = default(global::_003C_003Ey__InlineArray2<uint>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<uint>, uint>(ref buffer3, 0) = 0u;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<uint>, uint>(ref buffer3, 1) = 0u;
		Span<uint> span2 = global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<global::_003C_003Ey__InlineArray2<uint>, uint>(ref buffer3, 2);
		HashCore(source, span, span2, buffer);
		Span<byte> span3 = stackalloc byte[8];
		Encode(span3, span2);
		uint num = (span2[0] >> 3) & 0x3F;
		Span<byte> span4 = stackalloc byte[(int)((num < 56) ? (56 - num) : (120 - num))];
		span4.Clear();
		span4[0] = 128;
		HashCore(span4, span, span2, buffer);
		HashCore(span3, span, span2, buffer);
		Encode(destination, span);
	}

	private static void HashCore(ReadOnlySpan<byte> input, Span<uint> state, Span<uint> count, Span<byte> buffer)
	{
		int num = (int)((count[0] >> 3) & 0x3F);
		count[0] += (uint)(input.Length << 3);
		if (count[0] < input.Length << 3)
		{
			count[1]++;
		}
		count[1] += (uint)(input.Length >> 29);
		int num2 = 64 - num;
		int i = 0;
		if (input.Length >= num2)
		{
			if (num != 0)
			{
				input.Slice(0, num2).CopyTo(buffer.Slice(num));
				MD4Transform(state, buffer);
				num = 0;
			}
			else
			{
				num2 = 0;
			}
			for (i = num2; i + 63 < input.Length; i += 64)
			{
				MD4Transform(state, input.Slice(i));
			}
		}
		input.Slice(i).CopyTo(buffer.Slice(num));
	}

	private static uint F(uint x, uint y, uint z)
	{
		return (x & y) | (~x & z);
	}

	private static uint G(uint x, uint y, uint z)
	{
		return (x & y) | (x & z) | (y & z);
	}

	private static uint H(uint x, uint y, uint z)
	{
		return x ^ y ^ z;
	}

	private static void FF(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += F(b, c, d) + x;
		a = BitOperations.RotateLeft(a, s);
	}

	private static void GG(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += G(b, c, d) + x + 1518500249;
		a = BitOperations.RotateLeft(a, s);
	}

	private static void HH(ref uint a, uint b, uint c, uint d, uint x, byte s)
	{
		a += H(b, c, d) + x + 1859775393;
		a = BitOperations.RotateLeft(a, s);
	}

	private static void Encode(Span<byte> output, ReadOnlySpan<uint> input)
	{
		int num = 0;
		for (int i = 0; i < output.Length; i += 4)
		{
			BinaryPrimitives.WriteUInt32LittleEndian(output.Slice(i), input[num]);
			num++;
		}
	}

	private static void Decode(Span<uint> output, ReadOnlySpan<byte> input)
	{
		int num = 0;
		int num2 = 0;
		while (num < output.Length)
		{
			output[num] = BinaryPrimitives.ReadUInt32LittleEndian(input.Slice(num2));
			num++;
			num2 += 4;
		}
	}

	private static void MD4Transform(Span<uint> state, ReadOnlySpan<byte> block)
	{
		uint a = state[0];
		uint a2 = state[1];
		uint a3 = state[2];
		uint a4 = state[3];
		Span<uint> output = stackalloc uint[16];
		Decode(output, block);
		FF(ref a, a2, a3, a4, output[0], 3);
		FF(ref a4, a, a2, a3, output[1], 7);
		FF(ref a3, a4, a, a2, output[2], 11);
		FF(ref a2, a3, a4, a, output[3], 19);
		FF(ref a, a2, a3, a4, output[4], 3);
		FF(ref a4, a, a2, a3, output[5], 7);
		FF(ref a3, a4, a, a2, output[6], 11);
		FF(ref a2, a3, a4, a, output[7], 19);
		FF(ref a, a2, a3, a4, output[8], 3);
		FF(ref a4, a, a2, a3, output[9], 7);
		FF(ref a3, a4, a, a2, output[10], 11);
		FF(ref a2, a3, a4, a, output[11], 19);
		FF(ref a, a2, a3, a4, output[12], 3);
		FF(ref a4, a, a2, a3, output[13], 7);
		FF(ref a3, a4, a, a2, output[14], 11);
		FF(ref a2, a3, a4, a, output[15], 19);
		GG(ref a, a2, a3, a4, output[0], 3);
		GG(ref a4, a, a2, a3, output[4], 5);
		GG(ref a3, a4, a, a2, output[8], 9);
		GG(ref a2, a3, a4, a, output[12], 13);
		GG(ref a, a2, a3, a4, output[1], 3);
		GG(ref a4, a, a2, a3, output[5], 5);
		GG(ref a3, a4, a, a2, output[9], 9);
		GG(ref a2, a3, a4, a, output[13], 13);
		GG(ref a, a2, a3, a4, output[2], 3);
		GG(ref a4, a, a2, a3, output[6], 5);
		GG(ref a3, a4, a, a2, output[10], 9);
		GG(ref a2, a3, a4, a, output[14], 13);
		GG(ref a, a2, a3, a4, output[3], 3);
		GG(ref a4, a, a2, a3, output[7], 5);
		GG(ref a3, a4, a, a2, output[11], 9);
		GG(ref a2, a3, a4, a, output[15], 13);
		HH(ref a, a2, a3, a4, output[0], 3);
		HH(ref a4, a, a2, a3, output[8], 9);
		HH(ref a3, a4, a, a2, output[4], 11);
		HH(ref a2, a3, a4, a, output[12], 15);
		HH(ref a, a2, a3, a4, output[2], 3);
		HH(ref a4, a, a2, a3, output[10], 9);
		HH(ref a3, a4, a, a2, output[6], 11);
		HH(ref a2, a3, a4, a, output[14], 15);
		HH(ref a, a2, a3, a4, output[1], 3);
		HH(ref a4, a, a2, a3, output[9], 9);
		HH(ref a3, a4, a, a2, output[5], 11);
		HH(ref a2, a3, a4, a, output[13], 15);
		HH(ref a, a2, a3, a4, output[3], 3);
		HH(ref a4, a, a2, a3, output[11], 9);
		HH(ref a3, a4, a, a2, output[7], 11);
		HH(ref a2, a3, a4, a, output[15], 15);
		state[0] += a;
		state[1] += a2;
		state[2] += a3;
		state[3] += a4;
	}
}
