namespace System.Security.Cryptography;

public class HMACSHA3_256 : HMAC
{
	public static bool IsSupported { get; } = HashProviderDispenser.MacSupported("SHA3-256");
}
