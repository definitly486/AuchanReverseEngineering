using System.Formats.Asn1;
using Internal.Cryptography;

namespace System.Security.Cryptography.Pkcs;

internal sealed class Pkcs9LocalKeyId : Pkcs9AttributeObject
{
	private byte[] _lazyKeyId;

	public Pkcs9LocalKeyId()
		: base(Oids.LocalKeyIdOid.CopyOid())
	{
	}

	public Pkcs9LocalKeyId(ReadOnlySpan<byte> keyId)
		: this()
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.WriteOctetString(keyId);
		base.RawData = asnWriter.Encode();
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_lazyKeyId = null;
	}
}
