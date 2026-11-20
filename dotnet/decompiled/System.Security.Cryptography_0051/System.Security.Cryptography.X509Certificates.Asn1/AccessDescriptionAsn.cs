using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography.X509Certificates.Asn1;

internal struct AccessDescriptionAsn
{
	internal string AccessMethod;

	internal GeneralNameAsn AccessLocation;
}
