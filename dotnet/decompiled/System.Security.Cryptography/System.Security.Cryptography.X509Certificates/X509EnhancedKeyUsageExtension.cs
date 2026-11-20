using System.Formats.Asn1;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509EnhancedKeyUsageExtension : X509Extension
{
	private OidCollection _enhancedKeyUsages;

	private bool _decoded;

	public OidCollection EnhancedKeyUsages
	{
		get
		{
			if (!_decoded)
			{
				DecodeX509EnhancedKeyUsageExtension(base.RawData, out _enhancedKeyUsages);
				_decoded = true;
			}
			OidCollection oidCollection = new OidCollection(_enhancedKeyUsages.Count);
			OidEnumerator enumerator = _enhancedKeyUsages.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Oid current = enumerator.Current;
				oidCollection.Add(current);
			}
			return oidCollection;
		}
	}

	public X509EnhancedKeyUsageExtension()
		: base(Oids.EnhancedKeyUsageOid)
	{
		_enhancedKeyUsages = new OidCollection();
		_decoded = true;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}

	private static void DecodeX509EnhancedKeyUsageExtension(byte[] encoded, out OidCollection usages)
	{
		try
		{
			AsnReader asnReader = new AsnReader(encoded, AsnEncodingRules.BER);
			AsnReader asnReader2 = asnReader.ReadSequence();
			asnReader.ThrowIfNotEmpty();
			usages = new OidCollection();
			while (asnReader2.HasData)
			{
				usages.Add(new Oid(asnReader2.ReadObjectIdentifier(), null));
			}
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}
}
