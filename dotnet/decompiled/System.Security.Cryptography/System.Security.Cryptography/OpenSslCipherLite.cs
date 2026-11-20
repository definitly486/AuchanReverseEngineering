using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography;

internal sealed class OpenSslCipherLite : IDisposable
{
	private readonly SafeEvpCipherCtxHandle _ctx;

	[CompilerGenerated]
	private readonly int _003CBlockSizeInBytes_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPaddingSizeInBytes_003Ek__BackingField;

	public OpenSslCipherLite(nint algorithm, int blockSizeInBytes, int paddingSizeInBytes, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting)
	{
		_003CBlockSizeInBytes_003Ek__BackingField = blockSizeInBytes;
		_003CPaddingSizeInBytes_003Ek__BackingField = paddingSizeInBytes;
		_ctx = global::Interop.Crypto.EvpCipherCreate(algorithm, ref MemoryMarshal.GetReference(key), key.Length * 8, ref MemoryMarshal.GetReference(iv), encrypting ? 1 : 0);
		global::Interop.Crypto.CheckValidOpenSslHandle(_ctx);
		CheckBoolReturn(global::Interop.Crypto.EvpCipherCtxSetPadding(_ctx, 0));
	}

	public int TransformFinal(ReadOnlySpan<byte> input, Span<byte> output)
	{
		if (input.Overlaps(output, out var elementOffset) && elementOffset != 0)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(input.Length);
			int num = 0;
			try
			{
				num = CipherUpdate(input, array);
				Span<byte> output2 = array.AsSpan(num);
				CheckBoolReturn(global::Interop.Crypto.EvpCipherFinalEx(_ctx, output2, out var bytesWritten));
				num += bytesWritten;
				array.AsSpan(0, num).CopyTo(output);
				return num;
			}
			finally
			{
				System.Security.Cryptography.CryptoPool.Return(array, num);
			}
		}
		int num2 = CipherUpdate(input, output);
		Span<byte> output3 = output.Slice(num2);
		CheckBoolReturn(global::Interop.Crypto.EvpCipherFinalEx(_ctx, output3, out var bytesWritten2));
		return num2 + bytesWritten2;
	}

	public int Transform(ReadOnlySpan<byte> input, Span<byte> output)
	{
		if (input.Overlaps(output, out var elementOffset) && elementOffset != 0)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(input.Length);
			Span<byte> output2 = array;
			int num = 0;
			try
			{
				num = CipherUpdate(input, output2);
				output2.Slice(0, num).CopyTo(output);
				return num;
			}
			finally
			{
				System.Security.Cryptography.CryptoPool.Return(array, num);
			}
		}
		return CipherUpdate(input, output);
	}

	public void Reset(ReadOnlySpan<byte> iv)
	{
		CheckBoolReturn(global::Interop.Crypto.EvpCipherReset(_ctx, iv));
	}

	public void Dispose()
	{
		_ctx.Dispose();
	}

	private int CipherUpdate(ReadOnlySpan<byte> input, Span<byte> output)
	{
		CheckBoolReturn(global::Interop.Crypto.EvpCipherUpdate(_ctx, output, out var bytesWritten, input));
		return bytesWritten;
	}

	private static void CheckBoolReturn(bool returnValue)
	{
		if (!returnValue)
		{
			throw global::Interop.Crypto.CreateOpenSslCryptographicException();
		}
	}
}
