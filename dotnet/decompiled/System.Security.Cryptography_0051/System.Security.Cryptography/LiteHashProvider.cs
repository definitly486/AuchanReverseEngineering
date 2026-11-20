namespace System.Security.Cryptography;

internal static class LiteHashProvider
{
	internal static LiteHash CreateHash(string hashAlgorithmId)
	{
		return new LiteHash(global::Interop.Crypto.HashAlgorithmToEvp(hashAlgorithmId));
	}

	internal static LiteHmac CreateHmac(string hashAlgorithmId, ReadOnlySpan<byte> key)
	{
		return new LiteHmac(global::Interop.Crypto.HashAlgorithmToEvp(hashAlgorithmId), key);
	}
}
