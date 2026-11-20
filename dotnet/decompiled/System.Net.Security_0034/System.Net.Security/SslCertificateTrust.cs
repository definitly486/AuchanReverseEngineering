using System.Security.Cryptography.X509Certificates;

namespace System.Net.Security;

public sealed class SslCertificateTrust
{
	internal X509Store _store;

	internal X509Certificate2Collection _trustList;

	internal bool _sendTrustInHandshake;
}
