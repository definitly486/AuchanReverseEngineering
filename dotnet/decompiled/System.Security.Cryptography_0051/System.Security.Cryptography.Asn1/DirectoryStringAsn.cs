using System.Formats.Asn1;

namespace System.Security.Cryptography.Asn1;

internal struct DirectoryStringAsn
{
	internal string TeletexString;

	internal string PrintableString;

	internal ReadOnlyMemory<byte>? UniversalString;

	internal string Utf8String;

	internal string BmpString;

	internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out DirectoryStringAsn decoded)
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

	private static void DecodeCore(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out DirectoryStringAsn decoded)
	{
		decoded = default(DirectoryStringAsn);
		Asn1Tag asn1Tag = reader.PeekTag();
		ReadOnlySpan<byte> span = rebind.Span;
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.TeletexString)))
		{
			decoded.TeletexString = reader.ReadCharacterString(UniversalTagNumber.TeletexString);
			return;
		}
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.PrintableString)))
		{
			decoded.PrintableString = reader.ReadCharacterString(UniversalTagNumber.PrintableString);
			return;
		}
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.UniversalString)))
		{
			ReadOnlySpan<byte> other = reader.ReadEncodedValue();
			decoded.UniversalString = (span.Overlaps(other, out var elementOffset) ? rebind.Slice(elementOffset, other.Length) : ((ReadOnlyMemory<byte>)other.ToArray()));
			return;
		}
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.UTF8String)))
		{
			decoded.Utf8String = reader.ReadCharacterString(UniversalTagNumber.UTF8String);
			return;
		}
		if (asn1Tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.BMPString)))
		{
			decoded.BmpString = reader.ReadCharacterString(UniversalTagNumber.BMPString);
			return;
		}
		throw new CryptographicException();
	}
}
