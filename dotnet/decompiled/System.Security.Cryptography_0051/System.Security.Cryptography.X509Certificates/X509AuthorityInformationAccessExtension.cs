using System.Security.Cryptography.X509Certificates.Asn1;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509AuthorityInformationAccessExtension : X509Extension
{
	private AccessDescriptionAsn[] _decoded;

	public X509AuthorityInformationAccessExtension()
		: base(Oids.AuthorityInformationAccessOid)
	{
		_decoded = Array.Empty<AccessDescriptionAsn>();
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = null;
	}
}
