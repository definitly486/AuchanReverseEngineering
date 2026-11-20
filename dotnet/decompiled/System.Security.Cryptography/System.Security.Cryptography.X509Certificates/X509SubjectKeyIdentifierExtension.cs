namespace System.Security.Cryptography.X509Certificates;

public sealed class X509SubjectKeyIdentifierExtension : X509Extension
{
	private bool _decoded;

	public X509SubjectKeyIdentifierExtension()
		: base(Oids.SubjectKeyIdentifierOid)
	{
		_decoded = true;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}
}
