using System.Formats.Asn1;

namespace System.Security.Cryptography.X509Certificates.Asn1;

internal struct ValidityAsn
{
	internal TimeAsn NotBefore;

	internal TimeAsn NotAfter;

	internal static void Decode(ref AsnValueReader reader, out ValidityAsn decoded)
	{
		Decode(ref reader, Asn1Tag.Sequence, out decoded);
	}

	internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, out ValidityAsn decoded)
	{
		try
		{
			DecodeCore(ref reader, expectedTag, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, out ValidityAsn decoded)
	{
		decoded = default(ValidityAsn);
		AsnValueReader reader2 = reader.ReadSequence(expectedTag);
		TimeAsn.Decode(ref reader2, out decoded.NotBefore);
		TimeAsn.Decode(ref reader2, out decoded.NotAfter);
		reader2.ThrowIfNotEmpty();
	}
}
