using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography;

internal readonly struct LiteHmac : IDisposable
{
	private readonly SafeHmacCtxHandle _ctx;

	private readonly int _hashSizeInBytes;

	public int HashSizeInBytes => _hashSizeInBytes;

	internal LiteHmac(nint algorithm, ReadOnlySpan<byte> key)
	{
		_hashSizeInBytes = global::Interop.Crypto.EvpMdSize(algorithm);
		if (_hashSizeInBytes <= 0 || _hashSizeInBytes > global::Interop.Crypto.EVP_MAX_MD_SIZE)
		{
			throw new CryptographicException();
		}
		_ctx = global::Interop.Crypto.HmacCreate(ref MemoryMarshal.GetReference(key), key.Length, algorithm);
		global::Interop.Crypto.CheckValidOpenSslHandle(_ctx);
	}

	public void Append(ReadOnlySpan<byte> data)
	{
		if (!data.IsEmpty)
		{
			Check(global::Interop.Crypto.HmacUpdate(_ctx, data, data.Length));
		}
	}

	public int Finalize(Span<byte> destination)
	{
		int len = destination.Length;
		Check(global::Interop.Crypto.HmacFinal(_ctx, ref MemoryMarshal.GetReference(destination), ref len));
		return _hashSizeInBytes;
	}

	public void Reset()
	{
		Check(global::Interop.Crypto.HmacReset(_ctx));
	}

	public void Dispose()
	{
		_ctx.Dispose();
	}

	private static void Check(int result)
	{
		if (result != 1)
		{
			throw global::Interop.Crypto.CreateOpenSslCryptographicException();
		}
	}
}
