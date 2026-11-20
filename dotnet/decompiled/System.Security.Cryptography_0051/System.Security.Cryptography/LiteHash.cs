using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography;

internal readonly struct LiteHash : IDisposable
{
	private readonly SafeEvpMdCtxHandle _ctx;

	private readonly nint _algorithm;

	private readonly int _hashSizeInBytes;

	public int HashSizeInBytes => _hashSizeInBytes;

	internal LiteHash(nint algorithm)
	{
		_algorithm = algorithm;
		_hashSizeInBytes = global::Interop.Crypto.EvpMdSize(algorithm);
		if (_hashSizeInBytes <= 0 || _hashSizeInBytes > global::Interop.Crypto.EVP_MAX_MD_SIZE)
		{
			throw new CryptographicException();
		}
		_ctx = global::Interop.Crypto.EvpMdCtxCreate(algorithm);
		global::Interop.Crypto.CheckValidOpenSslHandle(_ctx);
	}

	public void Append(ReadOnlySpan<byte> data)
	{
		if (!data.IsEmpty)
		{
			Check(global::Interop.Crypto.EvpDigestUpdate(_ctx, data, data.Length));
		}
	}

	public int Finalize(Span<byte> destination)
	{
		uint s = (uint)destination.Length;
		Check(global::Interop.Crypto.EvpDigestFinalEx(_ctx, ref MemoryMarshal.GetReference(destination), ref s));
		return _hashSizeInBytes;
	}

	public void Reset()
	{
		Check(global::Interop.Crypto.EvpDigestReset(_ctx, _algorithm));
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
