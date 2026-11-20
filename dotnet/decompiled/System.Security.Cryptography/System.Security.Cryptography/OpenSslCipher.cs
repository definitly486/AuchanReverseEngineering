using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class OpenSslCipher : BasicSymmetricCipher
{
	private readonly OpenSslCipherLite _cipherLite;

	public OpenSslCipher(nint algorithm, CipherMode cipherMode, int blockSizeInBytes, int paddingSizeInBytes, ReadOnlySpan<byte> key, byte[] iv, bool encrypting)
		: base(cipherMode.GetCipherIv(iv), blockSizeInBytes, paddingSizeInBytes)
	{
		_cipherLite = new OpenSslCipherLite(algorithm, blockSizeInBytes, paddingSizeInBytes, key, iv, encrypting);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_cipherLite.Dispose();
		}
		base.Dispose(disposing);
	}

	public override int Transform(ReadOnlySpan<byte> input, Span<byte> output)
	{
		return _cipherLite.Transform(input, output);
	}

	public override int TransformFinal(ReadOnlySpan<byte> input, Span<byte> output)
	{
		int result = _cipherLite.TransformFinal(input, output);
		_cipherLite.Reset(base.IV);
		return result;
	}
}
