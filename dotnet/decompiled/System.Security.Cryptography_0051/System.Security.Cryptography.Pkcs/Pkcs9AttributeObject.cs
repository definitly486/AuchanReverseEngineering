namespace System.Security.Cryptography.Pkcs;

internal class Pkcs9AttributeObject : AsnEncodedData
{
	internal Pkcs9AttributeObject(Oid oid)
	{
		base.Oid = oid;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		ArgumentNullException.ThrowIfNull(asnEncodedData, "asnEncodedData");
		if (!(asnEncodedData is Pkcs9AttributeObject))
		{
			throw new ArgumentException("Cryptography_Pkcs9_AttributeMismatch");
		}
		base.CopyFrom(asnEncodedData);
	}
}
