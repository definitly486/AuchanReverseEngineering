namespace System.Security.Cryptography.X509Certificates;

public sealed class X509BasicConstraintsExtension : X509Extension
{
	private bool _decoded;

	public X509BasicConstraintsExtension()
		: base(Oids.BasicConstraints2Oid)
	{
		_decoded = true;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}
}
