using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Asn1.Pkcs12;
using Internal.Cryptography;

namespace System.Security.Cryptography.Pkcs;

internal sealed class Pkcs12CertBag : Pkcs12SafeBag
{
	private Oid _certTypeOid;

	private readonly CertBagAsn _decoded;

	[CompilerGenerated]
	private readonly bool _003CIsX509Certificate_003Ek__BackingField;

	public Pkcs12CertBag(Oid certificateType, ReadOnlyMemory<byte> encodedCertificate)
		: base("1.2.840.113549.1.12.10.1.3", EncodeBagValue(certificateType, encodedCertificate), skipCopy: true)
	{
		_certTypeOid = certificateType.CopyOid();
		_decoded = CertBagAsn.Decode(base.EncodedBagValue, AsnEncodingRules.BER);
		_003CIsX509Certificate_003Ek__BackingField = _decoded.CertId == "1.2.840.113549.1.9.22.1";
	}

	private static byte[] EncodeBagValue(Oid certificateType, ReadOnlyMemory<byte> encodedCertificate)
	{
		ArgumentNullException.ThrowIfNull(certificateType, "certificateType");
		if (certificateType.Value == null)
		{
			throw new CryptographicException("Argument_InvalidOidValue");
		}
		return EncodeBagValue(certificateType.Value, encodedCertificate);
	}

	private static byte[] EncodeBagValue(string certificateType, ReadOnlyMemory<byte> encodedCertificate)
	{
		if (!AsnDecoder.TryReadEncodedValue(encodedCertificate.Span, AsnEncodingRules.BER, out var _, out var _, out var _, out var bytesConsumed) || bytesConsumed != encodedCertificate.Length)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		CertBagAsn certBagAsn = new CertBagAsn
		{
			CertId = certificateType,
			CertValue = encodedCertificate
		};
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.BER);
		certBagAsn.Encode(asnWriter);
		return asnWriter.Encode();
	}
}
