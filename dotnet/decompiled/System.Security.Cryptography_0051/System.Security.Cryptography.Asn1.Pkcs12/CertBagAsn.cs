using System.Formats.Asn1;

namespace System.Security.Cryptography.Asn1.Pkcs12;

internal struct CertBagAsn
{
	internal string CertId;

	internal ReadOnlyMemory<byte> CertValue;

	internal readonly void Encode(AsnWriter writer)
	{
		Encode(writer, Asn1Tag.Sequence);
	}

	internal readonly void Encode(AsnWriter writer, Asn1Tag tag)
	{
		writer.PushSequence(tag);
		try
		{
			writer.WriteObjectIdentifier(CertId);
		}
		catch (ArgumentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
		try
		{
			writer.WriteEncodedValue(CertValue.Span);
		}
		catch (ArgumentException inner2)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner2);
		}
		writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
		writer.PopSequence(tag);
	}

	internal static CertBagAsn Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
	{
		return Decode(Asn1Tag.Sequence, encoded, ruleSet);
	}

	internal static CertBagAsn Decode(Asn1Tag expectedTag, ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
	{
		try
		{
			AsnValueReader reader = new AsnValueReader(encoded.Span, ruleSet);
			DecodeCore(ref reader, expectedTag, encoded, out var decoded);
			reader.ThrowIfNotEmpty();
			return decoded;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out CertBagAsn decoded)
	{
		decoded = default(CertBagAsn);
		AsnValueReader asnValueReader = reader.ReadSequence(expectedTag);
		ReadOnlySpan<byte> span = rebind.Span;
		decoded.CertId = asnValueReader.ReadObjectIdentifier();
		AsnValueReader asnValueReader2 = asnValueReader.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
		ReadOnlySpan<byte> other = asnValueReader2.ReadEncodedValue();
		decoded.CertValue = (span.Overlaps(other, out var elementOffset) ? rebind.Slice(elementOffset, other.Length) : ((ReadOnlyMemory<byte>)other.ToArray()));
		asnValueReader2.ThrowIfNotEmpty();
		asnValueReader.ThrowIfNotEmpty();
	}
}
