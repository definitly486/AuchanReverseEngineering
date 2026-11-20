namespace System.Security.Cryptography.X509Certificates;

public static class ECDsaCertificateExtensions
{
	public static ECDsa? GetECDsaPrivateKey(this X509Certificate2 certificate)
	{
		return certificate.GetPrivateKey<ECDsa>(HasECDsaKeyUsage);
	}

	private static bool HasECDsaKeyUsage(X509Certificate2 certificate)
	{
		foreach (X509Extension extension in certificate.Extensions)
		{
			if (extension.Oid.Value == "2.5.29.15")
			{
				X509KeyUsageExtension x509KeyUsageExtension = (X509KeyUsageExtension)extension;
				if ((x509KeyUsageExtension.KeyUsages & X509KeyUsageFlags.KeyAgreement) == 0)
				{
					return true;
				}
				return (x509KeyUsageExtension.KeyUsages & (X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature)) != 0;
			}
		}
		return true;
	}
}
