using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.Asn1;

namespace Internal.Cryptography;

internal static class PkcsHelpers
{
	internal static List<AttributeAsn> BuildAttributes(CryptographicAttributeObjectCollection attributes)
	{
		List<AttributeAsn> list = new List<AttributeAsn>();
		if (attributes == null || attributes.Count == 0)
		{
			return list;
		}
		CryptographicAttributeObjectEnumerator enumerator = attributes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			CryptographicAttributeObject current = enumerator.Current;
			AttributeAsn item = new AttributeAsn
			{
				AttrType = current.Oid.Value,
				AttrValues = new ReadOnlyMemory<byte>[current.Values.Count]
			};
			for (int i = 0; i < current.Values.Count; i++)
			{
				item.AttrValues[i] = current.Values[i].RawData;
			}
			list.Add(item);
		}
		return list;
	}

	public static void EnsureSingleBerValue(ReadOnlySpan<byte> source)
	{
		if (!AsnDecoder.TryReadEncodedValue(source, AsnEncodingRules.BER, out var _, out var _, out var _, out var bytesConsumed) || bytesConsumed != source.Length)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
	}

	public static byte[] EncodeOctetString(byte[] octets)
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.WriteOctetString(octets);
		return asnWriter.Encode();
	}

	internal static string GetOidFromHashAlgorithm(HashAlgorithmName algName)
	{
		if (algName == HashAlgorithmName.MD5)
		{
			return "1.2.840.113549.2.5";
		}
		if (algName == HashAlgorithmName.SHA1)
		{
			return "1.3.14.3.2.26";
		}
		if (algName == HashAlgorithmName.SHA256)
		{
			return "2.16.840.1.101.3.4.2.1";
		}
		if (algName == HashAlgorithmName.SHA384)
		{
			return "2.16.840.1.101.3.4.2.2";
		}
		if (algName == HashAlgorithmName.SHA512)
		{
			return "2.16.840.1.101.3.4.2.3";
		}
		if (algName == HashAlgorithmName.SHA3_256)
		{
			return "2.16.840.1.101.3.4.2.8";
		}
		if (algName == HashAlgorithmName.SHA3_384)
		{
			return "2.16.840.1.101.3.4.2.9";
		}
		if (algName == HashAlgorithmName.SHA3_512)
		{
			return "2.16.840.1.101.3.4.2.10";
		}
		throw new CryptographicException("Cryptography_Cms_UnknownAlgorithm", algName.Name);
	}

	[return: NotNullIfNotNull("oid")]
	public static Oid CopyOid(this Oid oid)
	{
		return oid;
	}
}
