using System.Formats.Asn1;
using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography.X509Certificates.Asn1;

internal struct CertificateAsn
{
	internal TbsCertificateAsn TbsCertificate;

	internal AlgorithmIdentifierAsn SignatureAlgorithm;

	internal ReadOnlyMemory<byte> SignatureValue;

	internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out CertificateAsn decoded)
	{
		Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
	}

	internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out CertificateAsn decoded)
	{
		try
		{
			DecodeCore(ref reader, expectedTag, rebind, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out CertificateAsn decoded)
	{
		decoded = default(CertificateAsn);
		AsnValueReader reader2 = reader.ReadSequence(expectedTag);
		ReadOnlySpan<byte> span = rebind.Span;
		TbsCertificateAsn.Decode(ref reader2, rebind, out decoded.TbsCertificate);
		AlgorithmIdentifierAsn.Decode(ref reader2, rebind, out decoded.SignatureAlgorithm);
		if (reader2.TryReadPrimitiveBitString(out var _, out var value))
		{
			decoded.SignatureValue = (span.Overlaps(value, out var elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
		}
		else
		{
			decoded.SignatureValue = reader2.ReadBitString(out var _);
		}
		reader2.ThrowIfNotEmpty();
	}
}
