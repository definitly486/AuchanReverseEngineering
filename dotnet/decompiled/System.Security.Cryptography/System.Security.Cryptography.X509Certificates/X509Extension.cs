namespace System.Security.Cryptography.X509Certificates;

public class X509Extension : AsnEncodedData
{
	public bool Critical { get; set; }

	public X509Extension(Oid oid, ReadOnlySpan<byte> rawData, bool critical)
		: base(oid, rawData)
	{
		ArgumentException.ThrowIfNullOrEmpty(base.Oid?.Value, "oid.Value");
		Critical = critical;
	}

	public X509Extension(string oid, ReadOnlySpan<byte> rawData, bool critical)
		: this(new Oid(oid), rawData, critical)
	{
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		ArgumentNullException.ThrowIfNull(asnEncodedData, "asnEncodedData");
		if (!(asnEncodedData is X509Extension x509Extension))
		{
			throw new ArgumentException("Cryptography_X509_ExtensionMismatch");
		}
		base.CopyFrom(asnEncodedData);
		Critical = x509Extension.Critical;
	}

	internal X509Extension(Oid oid)
	{
		base.Oid = oid;
	}
}
