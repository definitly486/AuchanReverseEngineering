using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

namespace System.Net.Security;

internal static class CertificateValidation
{
	private static readonly IdnMapping s_idnMapping = new IdnMapping();

	internal static SslPolicyErrors BuildChainAndVerifyProperties(X509Chain chain, X509Certificate2 remoteCertificate, bool checkCertName, bool isServer, string hostName, Span<byte> certificateBuffer)
	{
		return BuildChainAndVerifyProperties(chain, remoteCertificate, checkCertName, isServer, hostName);
	}

	internal static SslPolicyErrors BuildChainAndVerifyProperties(X509Chain chain, X509Certificate2 remoteCertificate, bool checkCertName, bool _, string hostName)
	{
		SslPolicyErrors sslPolicyErrors = ((!chain.Build(remoteCertificate)) ? SslPolicyErrors.RemoteCertificateChainErrors : SslPolicyErrors.None);
		if (!checkCertName)
		{
			return sslPolicyErrors;
		}
		if (string.IsNullOrEmpty(hostName))
		{
			return sslPolicyErrors | SslPolicyErrors.RemoteCertificateNameMismatch;
		}
		int num;
		using (SafeX509Handle x = global::Interop.Crypto.X509UpRef(remoteCertificate.Handle))
		{
			if (IPAddress.TryParse(hostName, out IPAddress address))
			{
				byte[] addressBytes = address.GetAddressBytes();
				num = global::Interop.Crypto.CheckX509IpAddress(x, addressBytes, addressBytes.Length, hostName, hostName.Length);
			}
			else
			{
				string ascii = s_idnMapping.GetAscii(hostName);
				num = global::Interop.Crypto.CheckX509Hostname(x, ascii, ascii.Length);
				if (num < 0)
				{
					throw global::Interop.Crypto.CreateOpenSslCryptographicException();
				}
			}
		}
		if (num != 1)
		{
			return sslPolicyErrors | SslPolicyErrors.RemoteCertificateNameMismatch;
		}
		return sslPolicyErrors;
	}
}
