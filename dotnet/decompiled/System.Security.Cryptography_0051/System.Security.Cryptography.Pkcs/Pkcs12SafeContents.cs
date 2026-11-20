using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.Asn1.Pkcs7;

namespace System.Security.Cryptography.Pkcs;

internal sealed class Pkcs12SafeContents
{
	private ReadOnlyMemory<byte> _encrypted;

	private List<Pkcs12SafeBag> _bags;

	public Pkcs12ConfidentialityMode ConfidentialityMode { get; private set; }

	public bool IsReadOnly { get; }

	public Pkcs12SafeContents()
	{
		ConfidentialityMode = Pkcs12ConfidentialityMode.None;
	}

	public void AddSafeBag(Pkcs12SafeBag safeBag)
	{
		ArgumentNullException.ThrowIfNull(safeBag, "safeBag");
		if (IsReadOnly)
		{
			throw new InvalidOperationException("Cryptography_Pkcs12_SafeContentsIsReadOnly");
		}
		if (_bags == null)
		{
			_bags = new List<Pkcs12SafeBag>();
		}
		_bags.Add(safeBag);
	}

	internal byte[] Encrypt(ReadOnlySpan<char> password, ReadOnlySpan<byte> passwordBytes, PbeParameters pbeParameters)
	{
		AsnWriter asnWriter = Encode();
		PasswordBasedEncryption.InitiateEncryption(pbeParameters, out var cipher, out var hmacOid, out var encryptionAlgorithmOid, out var isPkcs);
		int num = cipher.BlockSize / 8;
		byte[] array = System.Security.Cryptography.CryptoPool.Rent(asnWriter.GetEncodedLength() + num);
		Span<byte> span = Span<byte>.Empty;
		Span<byte> span2 = stackalloc byte[num];
		Span<byte> span3 = stackalloc byte[16];
		RandomNumberGenerator.Fill(span3);
		try
		{
			int length = PasswordBasedEncryption.Encrypt(password, passwordBytes, cipher, isPkcs, asnWriter, pbeParameters, span3, array, span2);
			span = array.AsSpan(0, length);
			AsnWriter asnWriter2 = new AsnWriter(AsnEncodingRules.DER);
			asnWriter2.PushSequence();
			asnWriter2.WriteInteger(0L);
			asnWriter2.PushSequence();
			asnWriter2.WriteObjectIdentifierForCrypto("1.2.840.113549.1.7.1");
			PasswordBasedEncryption.WritePbeAlgorithmIdentifier(asnWriter2, isPkcs, encryptionAlgorithmOid, span3, pbeParameters.IterationCount, hmacOid, span2);
			asnWriter2.WriteOctetString(span, new Asn1Tag(TagClass.ContextSpecific, 0));
			asnWriter2.PopSequence();
			asnWriter2.PopSequence();
			return asnWriter2.Encode();
		}
		finally
		{
			CryptographicOperations.ZeroMemory(span);
			System.Security.Cryptography.CryptoPool.Return(array, 0);
		}
	}

	internal AsnWriter Encode()
	{
		AsnWriter asnWriter;
		if (ConfidentialityMode == Pkcs12ConfidentialityMode.Password || ConfidentialityMode == Pkcs12ConfidentialityMode.PublicKey)
		{
			asnWriter = new AsnWriter(AsnEncodingRules.BER);
			asnWriter.WriteEncodedValueForCrypto(_encrypted.Span);
			return asnWriter;
		}
		asnWriter = new AsnWriter(AsnEncodingRules.BER);
		asnWriter.PushSequence();
		if (_bags != null)
		{
			foreach (Pkcs12SafeBag bag in _bags)
			{
				bag.EncodeTo(asnWriter);
			}
		}
		asnWriter.PopSequence();
		return asnWriter;
	}

	internal ContentInfoAsn EncodeToContentInfo()
	{
		AsnWriter asnWriter = Encode();
		if (ConfidentialityMode == Pkcs12ConfidentialityMode.None)
		{
			AsnWriter asnWriter2 = new AsnWriter(AsnEncodingRules.DER);
			using (asnWriter2.PushOctetString())
			{
				asnWriter.CopyTo(asnWriter2);
			}
			return new ContentInfoAsn
			{
				ContentType = "1.2.840.113549.1.7.1",
				Content = asnWriter2.Encode()
			};
		}
		if (ConfidentialityMode == Pkcs12ConfidentialityMode.Password)
		{
			return new ContentInfoAsn
			{
				ContentType = "1.2.840.113549.1.7.6",
				Content = asnWriter.Encode()
			};
		}
		if (ConfidentialityMode == Pkcs12ConfidentialityMode.PublicKey)
		{
			return new ContentInfoAsn
			{
				ContentType = "1.2.840.113549.1.7.3",
				Content = asnWriter.Encode()
			};
		}
		throw new CryptographicException();
	}
}
