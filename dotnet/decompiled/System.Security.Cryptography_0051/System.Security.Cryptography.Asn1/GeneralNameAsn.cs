using System.Formats.Asn1;

namespace System.Security.Cryptography.Asn1;

internal struct GeneralNameAsn
{
	internal OtherNameAsn? OtherName;

	internal string Rfc822Name;

	internal string DnsName;

	internal ReadOnlyMemory<byte>? X400Address;

	internal ReadOnlyMemory<byte>? DirectoryName;

	internal EdiPartyNameAsn? EdiPartyName;

	internal string Uri;

	internal ReadOnlyMemory<byte>? IPAddress;

	internal string RegisteredId;

	internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out GeneralNameAsn decoded)
	{
		try
		{
			DecodeCore(ref reader, rebind, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void DecodeCore(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out GeneralNameAsn decoded)
	{
		decoded = default(GeneralNameAsn);
		Asn1Tag asn1Tag = reader.PeekTag();
		ReadOnlySpan<byte> span = rebind.Span;
		ReadOnlySpan<byte> value;
		int elementOffset;
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0)))
		{
			OtherNameAsn.Decode(ref reader, new Asn1Tag(TagClass.ContextSpecific, 0), rebind, out var decoded2);
			decoded.OtherName = decoded2;
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 1)))
		{
			decoded.Rfc822Name = reader.ReadCharacterString(UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 1));
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 2)))
		{
			decoded.DnsName = reader.ReadCharacterString(UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 2));
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 3)))
		{
			value = reader.ReadEncodedValue();
			decoded.X400Address = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 4)))
		{
			AsnValueReader asnValueReader = reader.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 4));
			value = asnValueReader.ReadEncodedValue();
			decoded.DirectoryName = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
			asnValueReader.ThrowIfNotEmpty();
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 5)))
		{
			EdiPartyNameAsn.Decode(ref reader, new Asn1Tag(TagClass.ContextSpecific, 5), rebind, out var decoded3);
			decoded.EdiPartyName = decoded3;
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 6)))
		{
			decoded.Uri = reader.ReadCharacterString(UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 6));
		}
		else if (asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 7)))
		{
			if (reader.TryReadPrimitiveOctetString(out value, new Asn1Tag(TagClass.ContextSpecific, 7)))
			{
				decoded.IPAddress = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
			}
			else
			{
				decoded.IPAddress = reader.ReadOctetString(new Asn1Tag(TagClass.ContextSpecific, 7));
			}
		}
		else
		{
			if (!asn1Tag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 8)))
			{
				throw new CryptographicException();
			}
			decoded.RegisteredId = reader.ReadObjectIdentifier(new Asn1Tag(TagClass.ContextSpecific, 8));
		}
	}
}
