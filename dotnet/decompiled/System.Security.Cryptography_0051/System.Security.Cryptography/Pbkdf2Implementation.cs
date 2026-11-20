namespace System.Security.Cryptography;

internal static class Pbkdf2Implementation
{
	public static void Fill(ReadOnlySpan<byte> password, ReadOnlySpan<byte> salt, int iterations, HashAlgorithmName hashAlgorithmName, Span<byte> destination)
	{
		global::Interop.Crypto.Pbkdf2(hashAlgorithmName.Name, password, salt, iterations, destination);
	}
}
