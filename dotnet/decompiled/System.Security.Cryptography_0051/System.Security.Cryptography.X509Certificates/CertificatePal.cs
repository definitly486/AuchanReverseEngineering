namespace System.Security.Cryptography.X509Certificates;

internal static class CertificatePal
{
	internal static ICertificatePal FromHandle(nint handle)
	{
		return AndroidCertificatePal.FromHandle(handle);
	}

	internal static ICertificatePal FromOtherCert(X509Certificate copyFrom)
	{
		return AndroidCertificatePal.FromOtherCert(copyFrom);
	}
}
