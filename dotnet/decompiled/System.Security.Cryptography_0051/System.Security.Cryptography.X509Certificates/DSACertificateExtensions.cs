using System.Runtime.Versioning;

namespace System.Security.Cryptography.X509Certificates;

[UnsupportedOSPlatform("ios")]
[UnsupportedOSPlatform("tvos")]
public static class DSACertificateExtensions
{
	public static DSA? GetDSAPrivateKey(this X509Certificate2 certificate)
	{
		return certificate.GetPrivateKey<DSA>();
	}
}
