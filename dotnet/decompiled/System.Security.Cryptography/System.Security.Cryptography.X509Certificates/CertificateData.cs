using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.Asn1;
using System.Security.Cryptography.X509Certificates.Asn1;

namespace System.Security.Cryptography.X509Certificates;

internal struct CertificateData
{
	internal struct AlgorithmIdentifier
	{
		internal string AlgorithmId;

		internal byte[] Parameters;

		public AlgorithmIdentifier(AlgorithmIdentifierAsn algorithmIdentifier)
		{
			AlgorithmId = algorithmIdentifier.Algorithm;
			Parameters = algorithmIdentifier.Parameters?.ToArray();
		}
	}

	private CertificateAsn certificate;

	internal byte[] RawData;

	internal byte[] SubjectPublicKeyInfo;

	internal X500DistinguishedName Issuer;

	internal X500DistinguishedName Subject;

	internal List<X509Extension> Extensions;

	internal string IssuerName;

	internal string SubjectName;

	internal int Version => certificate.TbsCertificate.Version;

	internal byte[] SerialNumber => certificate.TbsCertificate.SerialNumber.ToArray();

	internal DateTime NotBefore => certificate.TbsCertificate.Validity.NotBefore.GetValue().UtcDateTime;

	internal DateTime NotAfter => certificate.TbsCertificate.Validity.NotAfter.GetValue().UtcDateTime;

	internal AlgorithmIdentifier PublicKeyAlgorithm => new AlgorithmIdentifier(certificate.TbsCertificate.SubjectPublicKeyInfo.Algorithm);

	internal byte[] PublicKey => certificate.TbsCertificate.SubjectPublicKeyInfo.SubjectPublicKey.ToArray();

	internal AlgorithmIdentifier SignatureAlgorithm => new AlgorithmIdentifier(certificate.SignatureAlgorithm);

	internal CertificateData(byte[] rawData)
	{
		AsnValueReader reader = new AsnValueReader(rawData, AsnEncodingRules.DER);
		ReadOnlySpan<byte> readOnlySpan = reader.PeekEncodedValue();
		CertificateAsn.Decode(ref reader, rawData, out certificate);
		certificate.TbsCertificate.ValidateVersion();
		RawData = ((readOnlySpan == rawData) ? rawData : readOnlySpan.ToArray());
		Issuer = new X500DistinguishedName(certificate.TbsCertificate.Issuer.Span);
		Subject = new X500DistinguishedName(certificate.TbsCertificate.Subject.Span);
		IssuerName = Issuer.Name;
		SubjectName = Subject.Name;
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		certificate.TbsCertificate.SubjectPublicKeyInfo.Encode(asnWriter);
		SubjectPublicKeyInfo = asnWriter.Encode();
		Extensions = new List<X509Extension>((certificate.TbsCertificate.Extensions?.Length).GetValueOrDefault());
		if (certificate.TbsCertificate.Extensions != null)
		{
			X509ExtensionAsn[] extensions = certificate.TbsCertificate.Extensions;
			for (int i = 0; i < extensions.Length; i++)
			{
				X509ExtensionAsn x509ExtensionAsn = extensions[i];
				X509Extension item = new X509Extension(x509ExtensionAsn.ExtnId, x509ExtensionAsn.ExtnValue.Span, x509ExtensionAsn.Critical);
				Extensions.Add(item);
			}
		}
	}

	public string GetNameInfo(X509NameType nameType, bool forIssuer)
	{
		if (nameType == X509NameType.SimpleName)
		{
			string simpleNameInfo = GetSimpleNameInfo(forIssuer ? Issuer : Subject);
			if (simpleNameInfo != null)
			{
				return simpleNameInfo;
			}
		}
		string text = (forIssuer ? "2.5.29.18" : "2.5.29.17");
		GeneralNameType? generalNameType = null;
		string otherOid = null;
		switch (nameType)
		{
		case X509NameType.DnsName:
		case X509NameType.DnsFromAlternativeName:
			generalNameType = GeneralNameType.DnsName;
			break;
		case X509NameType.SimpleName:
		case X509NameType.EmailName:
			generalNameType = GeneralNameType.Rfc822Name;
			break;
		case X509NameType.UpnName:
			generalNameType = GeneralNameType.OtherName;
			otherOid = "1.3.6.1.4.1.311.20.2.3";
			break;
		case X509NameType.UrlName:
			generalNameType = GeneralNameType.UniformResourceIdentifier;
			break;
		}
		if (generalNameType.HasValue)
		{
			foreach (X509Extension extension in Extensions)
			{
				if (extension.Oid.Value == text)
				{
					string text2 = FindAltNameMatch(extension.RawData, generalNameType.Value, otherOid);
					if (text2 != null)
					{
						return text2;
					}
				}
			}
		}
		string text3 = null;
		switch (nameType)
		{
		case X509NameType.EmailName:
			text3 = "1.2.840.113549.1.9.1";
			break;
		case X509NameType.DnsName:
			text3 = "2.5.4.3";
			break;
		}
		if (text3 != null)
		{
			foreach (KeyValuePair<string, string> item in ReadReverseRdns(forIssuer ? Issuer : Subject))
			{
				if (item.Key == text3)
				{
					return item.Value;
				}
			}
		}
		return "";
	}

	private static string GetSimpleNameInfo(X500DistinguishedName name)
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		foreach (KeyValuePair<string, string> item in ReadReverseRdns(name))
		{
			string key = item.Key;
			string value = item.Value;
			switch (key)
			{
			case "2.5.4.3":
				return value;
			case "2.5.4.11":
				text = value;
				continue;
			case "2.5.4.10":
				text2 = value;
				continue;
			case "1.2.840.113549.1.9.1":
				text3 = value;
				continue;
			}
			if (text4 == null)
			{
				text4 = value;
			}
		}
		return text ?? text2 ?? text3 ?? text4;
	}

	private static string FindAltNameMatch(byte[] extensionBytes, GeneralNameType matchType, string otherOid)
	{
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(extensionBytes, AsnEncodingRules.DER);
			AsnValueReader reader = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			while (reader.HasData)
			{
				GeneralNameAsn.Decode(ref reader, extensionBytes, out var decoded);
				switch (matchType)
				{
				case GeneralNameType.OtherName:
					if (decoded.OtherName.HasValue && decoded.OtherName.Value.TypeId == otherOid)
					{
						AsnValueReader asnValueReader2 = new AsnValueReader(decoded.OtherName.Value.Value.Span, AsnEncodingRules.DER);
						string result = asnValueReader2.ReadCharacterString(UniversalTagNumber.UTF8String);
						asnValueReader2.ThrowIfNotEmpty();
						return result;
					}
					break;
				case GeneralNameType.Rfc822Name:
					if (decoded.Rfc822Name != null)
					{
						return decoded.Rfc822Name;
					}
					break;
				case GeneralNameType.DnsName:
					if (decoded.DnsName != null)
					{
						return decoded.DnsName;
					}
					break;
				case GeneralNameType.UniformResourceIdentifier:
					if (decoded.Uri != null)
					{
						return decoded.Uri;
					}
					break;
				}
			}
		}
		catch (AsnContentException)
		{
		}
		catch (CryptographicException)
		{
		}
		return null;
	}

	private static IEnumerable<KeyValuePair<string, string>> ReadReverseRdns(X500DistinguishedName name)
	{
		Stack<AsnReader> rdnReaders;
		try
		{
			AsnReader asnReader = new AsnReader(name.RawData, AsnEncodingRules.DER);
			AsnReader asnReader2 = asnReader.ReadSequence();
			asnReader.ThrowIfNotEmpty();
			rdnReaders = new Stack<AsnReader>();
			while (asnReader2.HasData)
			{
				rdnReaders.Push(asnReader2.ReadSetOf());
			}
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		while (rdnReaders.Count > 0)
		{
			AsnReader rdnReader = rdnReaders.Pop();
			while (rdnReader.HasData)
			{
				string key;
				string value;
				try
				{
					AsnReader asnReader3 = rdnReader.ReadSequence();
					key = asnReader3.ReadObjectIdentifier();
					value = asnReader3.ReadAnyAsnString();
					asnReader3.ThrowIfNotEmpty();
				}
				catch (AsnContentException inner2)
				{
					throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner2);
				}
				yield return new KeyValuePair<string, string>(key, value);
			}
		}
	}
}
