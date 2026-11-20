namespace System.Security.Cryptography.X509Certificates;

public sealed class X509AuthorityKeyIdentifierExtension : X509Extension
{
	private bool _decoded;

	public X509AuthorityKeyIdentifierExtension()
		: base(Oids.AuthorityKeyIdentifierOid)
	{
		_decoded = true;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}
}
