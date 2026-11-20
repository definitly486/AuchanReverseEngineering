namespace System.Security.Cryptography.X509Certificates;

public static class RSACertificateExtensions
{
	public static RSA? GetRSAPublicKey(this X509Certificate2 certificate)
	{
		return certificate.GetPublicKey<RSA>();
	}

	public static RSA? GetRSAPrivateKey(this X509Certificate2 certificate)
	{
		return certificate.GetPrivateKey<RSA>();
	}
}
