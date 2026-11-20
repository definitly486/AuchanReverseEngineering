using System.Formats.Asn1;

namespace System.Security.Cryptography.X509Certificates.Asn1;

internal struct TimeAsn
{
	internal DateTimeOffset? UtcTime;

	internal DateTimeOffset? GeneralTime;

	internal static void Decode(ref AsnValueReader reader, out TimeAsn decoded)
	{
		try
		{
			DecodeCore(ref reader, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void DecodeCore(ref AsnValueReader reader, out TimeAsn decoded)
	{
		decoded = default(TimeAsn);
		Asn1Tag asn1Tag = reader.PeekTag();
		if (asn1Tag.HasSameClassAndValue(Asn1Tag.UtcTime))
		{
			decoded.UtcTime = reader.ReadUtcTime();
			return;
		}
		if (asn1Tag.HasSameClassAndValue(Asn1Tag.GeneralizedTime))
		{
			decoded.GeneralTime = reader.ReadGeneralizedTime();
			if (decoded.GeneralTime.Value.Ticks % 10000000 == 0L)
			{
				return;
			}
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		throw new CryptographicException();
	}

	public DateTimeOffset GetValue()
	{
		return (UtcTime ?? GeneralTime).GetValueOrDefault();
	}
}
