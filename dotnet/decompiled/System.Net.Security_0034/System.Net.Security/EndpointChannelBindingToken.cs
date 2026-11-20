using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace System.Net.Security;

internal static class EndpointChannelBindingToken
{
	internal static ChannelBinding Build(SafeDeleteContext securityContext)
	{
		using X509Certificate2 x509Certificate = CertificateValidationPal.GetRemoteCertificate(securityContext);
		if (x509Certificate == null)
		{
			return null;
		}
		SafeChannelBindingHandle safeChannelBindingHandle = new SafeChannelBindingHandle(ChannelBindingKind.Endpoint);
		byte[] hashForChannelBinding = GetHashForChannelBinding(x509Certificate);
		safeChannelBindingHandle.SetCertHash(hashForChannelBinding);
		return safeChannelBindingHandle;
	}

	private static byte[] GetHashForChannelBinding(X509Certificate2 cert)
	{
		Oid signatureAlgorithm = cert.SignatureAlgorithm;
		switch (signatureAlgorithm.Value)
		{
		case "1.2.840.113549.1.1.4":
		case "1.2.840.113549.1.1.5":
		case "1.2.840.10040.4.3":
		case "1.2.840.10045.4.1":
		case "2.16.840.1.101.3.4.2.1":
		case "1.2.840.10045.4.3.2":
		case "1.2.840.113549.1.1.11":
		case "1.2.840.113549.2.5":
		case "1.3.14.3.2.26":
			return SHA256.HashData(cert.RawDataMemory.Span);
		case "2.16.840.1.101.3.4.2.2":
		case "1.2.840.10045.4.3.3":
		case "1.2.840.113549.1.1.12":
			return SHA384.HashData(cert.RawDataMemory.Span);
		case "2.16.840.1.101.3.4.2.3":
		case "1.2.840.10045.4.3.4":
		case "1.2.840.113549.1.1.13":
			return SHA512.HashData(cert.RawDataMemory.Span);
		default:
			throw new ArgumentException(signatureAlgorithm.Value);
		}
	}
}
