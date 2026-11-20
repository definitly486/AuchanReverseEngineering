using System.Runtime.CompilerServices;

namespace System.Security.Cryptography.X509Certificates;

public class X509ChainElement
{
	[CompilerGenerated]
	private readonly string _003CInformation_003Ek__BackingField;

	public X509Certificate2 Certificate { get; }

	public X509ChainStatus[] ChainElementStatus { get; }

	internal X509ChainElement(X509Certificate2 certificate, X509ChainStatus[] chainElementStatus, string information)
	{
		Certificate = certificate;
		ChainElementStatus = chainElementStatus;
		_003CInformation_003Ek__BackingField = information;
	}
}
