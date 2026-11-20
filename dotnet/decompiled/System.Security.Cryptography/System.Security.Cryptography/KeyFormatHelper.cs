using System.Buffers;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Asn1;
using Internal.Cryptography;

namespace System.Security.Cryptography;

internal static class KeyFormatHelper
{
	internal delegate void KeyReader<TRet>(ReadOnlyMemory<byte> key, in AlgorithmIdentifierAsn algId, out TRet ret);

	internal unsafe static void ReadSubjectPublicKeyInfo<TRet>(string[] validOids, ReadOnlySpan<byte> source, KeyReader<TRet> keyReader, out int bytesRead, out TRet ret)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, source.Length);
			ReadSubjectPublicKeyInfo(validOids, memoryManager.Memory, keyReader, out bytesRead, out ret);
		}
	}

	internal static ReadOnlyMemory<byte> ReadSubjectPublicKeyInfo(string[] validOids, ReadOnlyMemory<byte> source, out int bytesRead)
	{
		int length;
		SubjectPublicKeyInfoAsn decoded;
		try
		{
			AsnValueReader reader = new AsnValueReader(source.Span, AsnEncodingRules.DER);
			length = reader.PeekEncodedValue().Length;
			SubjectPublicKeyInfoAsn.Decode(ref reader, source, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		if (Array.IndexOf(validOids, decoded.Algorithm.Algorithm) < 0)
		{
			throw new CryptographicException("Cryptography_NotValidPublicOrPrivateKey");
		}
		bytesRead = length;
		return decoded.SubjectPublicKey;
	}

	private static void ReadSubjectPublicKeyInfo<TRet>(string[] validOids, ReadOnlyMemory<byte> source, KeyReader<TRet> keyReader, out int bytesRead, out TRet ret)
	{
		int length;
		SubjectPublicKeyInfoAsn decoded;
		try
		{
			AsnValueReader reader = new AsnValueReader(source.Span, AsnEncodingRules.DER);
			length = reader.PeekEncodedValue().Length;
			SubjectPublicKeyInfoAsn.Decode(ref reader, source, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		if (Array.IndexOf(validOids, decoded.Algorithm.Algorithm) < 0)
		{
			throw new CryptographicException("Cryptography_NotValidPublicOrPrivateKey");
		}
		keyReader(decoded.SubjectPublicKey, in decoded.Algorithm, out ret);
		bytesRead = length;
	}

	internal unsafe static void ReadPkcs8<TRet>(string[] validOids, ReadOnlySpan<byte> source, KeyReader<TRet> keyReader, out int bytesRead, out TRet ret)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, source.Length);
			ReadPkcs8(validOids, memoryManager.Memory, keyReader, out bytesRead, out ret);
		}
	}

	internal static ReadOnlyMemory<byte> ReadPkcs8(string[] validOids, ReadOnlyMemory<byte> source, out int bytesRead)
	{
		try
		{
			AsnValueReader reader = new AsnValueReader(source.Span, AsnEncodingRules.BER);
			int length = reader.PeekEncodedValue().Length;
			PrivateKeyInfoAsn.Decode(ref reader, source, out var decoded);
			if (Array.IndexOf(validOids, decoded.PrivateKeyAlgorithm.Algorithm) < 0)
			{
				throw new CryptographicException("Cryptography_NotValidPublicOrPrivateKey");
			}
			bytesRead = length;
			return decoded.PrivateKey;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static void ReadPkcs8<TRet>(string[] validOids, ReadOnlyMemory<byte> source, KeyReader<TRet> keyReader, out int bytesRead, out TRet ret)
	{
		try
		{
			AsnValueReader reader = new AsnValueReader(source.Span, AsnEncodingRules.BER);
			int length = reader.PeekEncodedValue().Length;
			PrivateKeyInfoAsn.Decode(ref reader, source, out var decoded);
			if (Array.IndexOf(validOids, decoded.PrivateKeyAlgorithm.Algorithm) < 0)
			{
				throw new CryptographicException("Cryptography_NotValidPublicOrPrivateKey");
			}
			keyReader(decoded.PrivateKey, in decoded.PrivateKeyAlgorithm, out ret);
			bytesRead = length;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	internal static AsnWriter WritePkcs8(AsnWriter algorithmIdentifierWriter, AsnWriter privateKeyWriter, AsnWriter attributesWriter = null)
	{
		algorithmIdentifierWriter.GetEncodedLength();
		privateKeyWriter.GetEncodedLength();
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.PushSequence();
		asnWriter.WriteInteger(0L);
		algorithmIdentifierWriter.CopyTo(asnWriter);
		using (asnWriter.PushOctetString())
		{
			privateKeyWriter.CopyTo(asnWriter);
		}
		attributesWriter?.CopyTo(asnWriter);
		asnWriter.PopSequence();
		return asnWriter;
	}

	internal static AsnWriter WriteEncryptedPkcs8(ReadOnlySpan<char> password, AsnWriter pkcs8Writer, PbeParameters pbeParameters)
	{
		return WriteEncryptedPkcs8(password, ReadOnlySpan<byte>.Empty, pkcs8Writer, pbeParameters);
	}

	private static AsnWriter WriteEncryptedPkcs8(ReadOnlySpan<char> password, ReadOnlySpan<byte> passwordBytes, AsnWriter pkcs8Writer, PbeParameters pbeParameters)
	{
		PasswordBasedEncryption.InitiateEncryption(pbeParameters, out var cipher, out var hmacOid, out var encryptionAlgorithmOid, out var isPkcs);
		Span<byte> span = default(Span<byte>);
		Span<byte> span2 = stackalloc byte[cipher.BlockSize / 8];
		Span<byte> span3 = stackalloc byte[16];
		checked
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(pkcs8Writer.GetEncodedLength() + unchecked(cipher.BlockSize / 8));
			try
			{
				Helpers.RngFill(span3);
				int length = PasswordBasedEncryption.Encrypt(password, passwordBytes, cipher, isPkcs, pkcs8Writer, pbeParameters, span3, array, span2);
				span = array.AsSpan(0, length);
				AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
				asnWriter.PushSequence();
				PasswordBasedEncryption.WritePbeAlgorithmIdentifier(asnWriter, isPkcs, encryptionAlgorithmOid, span3, pbeParameters.IterationCount, hmacOid, span2);
				asnWriter.WriteOctetString(span);
				asnWriter.PopSequence();
				return asnWriter;
			}
			finally
			{
				CryptographicOperations.ZeroMemory(span);
				System.Security.Cryptography.CryptoPool.Return(array, 0);
				cipher.Dispose();
			}
		}
	}

	internal static ArraySegment<byte> DecryptPkcs8(ReadOnlySpan<char> inputPassword, ReadOnlyMemory<byte> source, out int bytesRead)
	{
		return DecryptPkcs8(inputPassword, ReadOnlySpan<byte>.Empty, source, out bytesRead);
	}

	private static ArraySegment<byte> DecryptPkcs8(ReadOnlySpan<char> inputPassword, ReadOnlySpan<byte> inputPasswordBytes, ReadOnlyMemory<byte> source, out int bytesRead)
	{
		int length;
		EncryptedPrivateKeyInfoAsn decoded;
		try
		{
			AsnValueReader reader = new AsnValueReader(source.Span, AsnEncodingRules.BER);
			length = reader.PeekEncodedValue().Length;
			EncryptedPrivateKeyInfoAsn.Decode(ref reader, source, out decoded);
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		byte[] array = System.Security.Cryptography.CryptoPool.Rent(decoded.EncryptedData.Length);
		try
		{
			int count = PasswordBasedEncryption.Decrypt(in decoded.EncryptionAlgorithm, inputPassword, inputPasswordBytes, decoded.EncryptedData.Span, array);
			bytesRead = length;
			return new ArraySegment<byte>(array, 0, count);
		}
		catch (CryptographicException inner2)
		{
			System.Security.Cryptography.CryptoPool.Return(array);
			throw new CryptographicException("Cryptography_Pkcs8_EncryptedReadFailed", inner2);
		}
	}
}
