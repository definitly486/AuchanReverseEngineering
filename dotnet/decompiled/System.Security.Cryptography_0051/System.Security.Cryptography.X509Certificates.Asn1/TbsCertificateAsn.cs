using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography.X509Certificates.Asn1;

internal struct TbsCertificateAsn
{
	internal int Version;

	internal ReadOnlyMemory<byte> SerialNumber;

	internal AlgorithmIdentifierAsn SignatureAlgorithm;

	internal ReadOnlyMemory<byte> Issuer;

	internal ValidityAsn Validity;

	internal ReadOnlyMemory<byte> Subject;

	internal SubjectPublicKeyInfoAsn SubjectPublicKeyInfo;

	internal ReadOnlyMemory<byte>? IssuerUniqueId;

	internal ReadOnlyMemory<byte>? SubjectUniqueId;

	internal X509ExtensionAsn[] Extensions;

	private static ReadOnlySpan<byte> DefaultVersion => new byte[3] { 2, 1, 0 };

	internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out TbsCertificateAsn decoded)
	{
		Decode(ref reader, Asn1Tag.Sequence, rebind, out decoded);
	}

	internal static void Decode(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out TbsCertificateAsn decoded)
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

	private static void DecodeCore(ref AsnValueReader reader, Asn1Tag expectedTag, ReadOnlyMemory<byte> rebind, out TbsCertificateAsn decoded)
	{
		decoded = default(TbsCertificateAsn);
		AsnValueReader reader2 = reader.ReadSequence(expectedTag);
		ReadOnlySpan<byte> span = rebind.Span;
		AsnValueReader asnValueReader;
		if (reader2.HasData && reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0)))
		{
			asnValueReader = reader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
			if (!asnValueReader.TryReadInt32(out decoded.Version))
			{
				asnValueReader.ThrowIfNotEmpty();
			}
			asnValueReader.ThrowIfNotEmpty();
		}
		else
		{
			AsnValueReader asnValueReader2 = new AsnValueReader(DefaultVersion, AsnEncodingRules.DER);
			if (!asnValueReader2.TryReadInt32(out decoded.Version))
			{
				asnValueReader2.ThrowIfNotEmpty();
			}
		}
		ReadOnlySpan<byte> value = reader2.ReadIntegerBytes();
		decoded.SerialNumber = (span.Overlaps(value, out var elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
		AlgorithmIdentifierAsn.Decode(ref reader2, rebind, out decoded.SignatureAlgorithm);
		if (!reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.Sequence)))
		{
			throw new CryptographicException();
		}
		value = reader2.ReadEncodedValue();
		decoded.Issuer = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
		ValidityAsn.Decode(ref reader2, out decoded.Validity);
		if (!reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.Sequence)))
		{
			throw new CryptographicException();
		}
		value = reader2.ReadEncodedValue();
		decoded.Subject = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
		SubjectPublicKeyInfoAsn.Decode(ref reader2, rebind, out decoded.SubjectPublicKeyInfo);
		if (reader2.HasData && reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 1)))
		{
			if (reader2.TryReadPrimitiveBitString(out var _, out value, new Asn1Tag(TagClass.ContextSpecific, 1)))
			{
				decoded.IssuerUniqueId = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
			}
			else
			{
				decoded.IssuerUniqueId = reader2.ReadBitString(out var _, new Asn1Tag(TagClass.ContextSpecific, 1));
			}
		}
		if (reader2.HasData && reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 2)))
		{
			if (reader2.TryReadPrimitiveBitString(out var _, out value, new Asn1Tag(TagClass.ContextSpecific, 2)))
			{
				decoded.SubjectUniqueId = (span.Overlaps(value, out elementOffset) ? rebind.Slice(elementOffset, value.Length) : ((ReadOnlyMemory<byte>)value.ToArray()));
			}
			else
			{
				decoded.SubjectUniqueId = reader2.ReadBitString(out var _, new Asn1Tag(TagClass.ContextSpecific, 2));
			}
		}
		if (reader2.HasData && reader2.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 3)))
		{
			asnValueReader = reader2.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 3));
			AsnValueReader reader3 = asnValueReader.ReadSequence();
			List<X509ExtensionAsn> list = new List<X509ExtensionAsn>();
			while (reader3.HasData)
			{
				X509ExtensionAsn.Decode(ref reader3, rebind, out var decoded2);
				list.Add(decoded2);
			}
			decoded.Extensions = list.ToArray();
			asnValueReader.ThrowIfNotEmpty();
		}
		reader2.ThrowIfNotEmpty();
	}

	public void ValidateVersion()
	{
		if (Version < 0 || Version > 2)
		{
			throw new CryptographicException();
		}
		if (Version < 1 && (IssuerUniqueId.HasValue || SubjectUniqueId.HasValue))
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		if (Version < 2 && Extensions != null)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
	}
}
