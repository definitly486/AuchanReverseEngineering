using System.Buffers;
using System.Security.Cryptography;

namespace System.Net.Security;

internal sealed class RC4 : IDisposable
{
	private byte[] state;

	private byte x;

	private byte y;

	public RC4(ReadOnlySpan<byte> key)
	{
		state = ArrayPool<byte>.Shared.Rent(256);
		byte b = 0;
		byte b2 = 0;
		for (int i = 0; i < 256; i++)
		{
			state[i] = (byte)i;
		}
		for (int j = 0; j < 256; j++)
		{
			b2 = (byte)(key[b] + state[j] + b2);
			ref byte reference = ref state[j];
			ref byte reference2 = ref state[b2];
			byte b3 = state[b2];
			byte b4 = state[j];
			reference = b3;
			reference2 = b4;
			b = (byte)((b + 1) % key.Length);
		}
	}

	public void Dispose()
	{
		if (state != null)
		{
			x = 0;
			y = 0;
			CryptographicOperations.ZeroMemory(state.AsSpan(0, 256));
			ArrayPool<byte>.Shared.Return(state);
			state = null;
		}
	}

	public void Transform(ReadOnlySpan<byte> input, Span<byte> output)
	{
		for (int i = 0; i < input.Length; i++)
		{
			x++;
			y = (byte)(state[x] + y);
			ref byte reference = ref state[x];
			ref byte reference2 = ref state[y];
			byte b = state[y];
			byte b2 = state[x];
			reference = b;
			reference2 = b2;
			byte b3 = (byte)(state[x] + state[y]);
			output[i] = (byte)(input[i] ^ state[b3]);
		}
	}
}
