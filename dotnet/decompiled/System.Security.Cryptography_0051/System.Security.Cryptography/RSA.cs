using System.Buffers;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography;

public abstract class RSA : AsymmetricAlgorithm
{
	[UnsupportedOSPlatform("browser")]
	public static RSA Create()
	{
		return new RSAImplementation.RSAAndroid();
	}

	public abstract RSAParameters ExportParameters(bool includePrivateParameters);

	public abstract void ImportParameters(RSAParameters parameters);

	public virtual bool TryExportRSAPrivateKey(Span<byte> destination, out int bytesWritten)
	{
		return WritePkcs1PrivateKey().TryEncode(destination, out bytesWritten);
	}

	public virtual bool TryExportRSAPublicKey(Span<byte> destination, out int bytesWritten)
	{
		return WritePkcs1PublicKey().TryEncode(destination, out bytesWritten);
	}

	public unsafe override bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
	{
		int num = KeySize / 4;
		while (true)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(num);
			num = array.Length;
			int bytesWritten2 = 0;
			fixed (byte* ptr = array)
			{
				try
				{
					if (!TryExportRSAPublicKey(array, out bytesWritten2))
					{
						num = checked(num * 2);
						continue;
					}
					return RSAKeyFormatHelper.WriteSubjectPublicKeyInfo(array.AsSpan(0, bytesWritten2)).TryEncode(destination, out bytesWritten);
				}
				finally
				{
					System.Security.Cryptography.CryptoPool.Return(array, bytesWritten2);
				}
			}
		}
	}

	public override bool TryExportPkcs8PrivateKey(Span<byte> destination, out int bytesWritten)
	{
		return WritePkcs8PrivateKey().TryEncode(destination, out bytesWritten);
	}

	private unsafe AsnWriter WritePkcs8PrivateKey()
	{
		int num = checked(5 * KeySize) / 8;
		while (true)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(num);
			num = array.Length;
			int bytesWritten = 0;
			fixed (byte* ptr = array)
			{
				try
				{
					if (!TryExportRSAPrivateKey(array, out bytesWritten))
					{
						num = checked(num * 2);
						continue;
					}
					return RSAKeyFormatHelper.WritePkcs8PrivateKey(new ReadOnlySpan<byte>(array, 0, bytesWritten));
				}
				finally
				{
					System.Security.Cryptography.CryptoPool.Return(array, bytesWritten);
				}
			}
		}
	}

	public override bool TryExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char> password, PbeParameters pbeParameters, Span<byte> destination, out int bytesWritten)
	{
		ArgumentNullException.ThrowIfNull(pbeParameters, "pbeParameters");
		PasswordBasedEncryption.ValidatePbeParameters(pbeParameters, password, ReadOnlySpan<byte>.Empty);
		AsnWriter pkcs8Writer = WritePkcs8PrivateKey();
		return KeyFormatHelper.WriteEncryptedPkcs8(password, pkcs8Writer, pbeParameters).TryEncode(destination, out bytesWritten);
	}

	private AsnWriter WritePkcs1PublicKey()
	{
		return RSAKeyFormatHelper.WritePkcs1PublicKey(ExportParameters(includePrivateParameters: false));
	}

	private unsafe AsnWriter WritePkcs1PrivateKey()
	{
		RSAParameters rsaParameters = ExportParameters(includePrivateParameters: true);
		fixed (byte* d = rsaParameters.D)
		{
			fixed (byte* p = rsaParameters.P)
			{
				fixed (byte* q = rsaParameters.Q)
				{
					fixed (byte* dP = rsaParameters.DP)
					{
						fixed (byte* dQ = rsaParameters.DQ)
						{
							fixed (byte* inverseQ = rsaParameters.InverseQ)
							{
								try
								{
									return RSAKeyFormatHelper.WritePkcs1PrivateKey(in rsaParameters);
								}
								finally
								{
									ClearPrivateParameters(in rsaParameters);
								}
							}
						}
					}
				}
			}
		}
	}

	public unsafe override void ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source, out int bytesRead)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, source.Length);
			ImportRSAPublicKey(RSAKeyFormatHelper.ReadSubjectPublicKeyInfo(memoryManager.Memory, out var bytesRead2).Span, out var _);
			bytesRead = bytesRead2;
		}
	}

	public unsafe virtual void ImportRSAPublicKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		try
		{
			AsnDecoder.ReadEncodedValue(source, AsnEncodingRules.BER, out var _, out var _, out var bytesConsumed);
			fixed (byte* reference = &MemoryMarshal.GetReference(source))
			{
				using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, bytesConsumed);
				RSAKeyFormatHelper.ReadRsaPublicKey(memoryManager.Memory, default(AlgorithmIdentifierAsn), out var ret);
				ImportParameters(ret);
				bytesRead = bytesConsumed;
			}
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	public virtual void ImportRSAPrivateKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		try
		{
			AsnDecoder.ReadEncodedValue(source, AsnEncodingRules.BER, out var _, out var _, out var bytesConsumed);
			RSAKeyFormatHelper.FromPkcs1PrivateKey(source.Slice(0, bytesConsumed), delegate(RSAParameters rsaParameters)
			{
				ImportParameters(rsaParameters);
				return true;
			});
			bytesRead = bytesConsumed;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	public unsafe override void ImportPkcs8PrivateKey(ReadOnlySpan<byte> source, out int bytesRead)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, source.Length);
			ImportRSAPrivateKey(RSAKeyFormatHelper.ReadPkcs8(memoryManager.Memory, out var bytesRead2).Span, out var _);
			bytesRead = bytesRead2;
		}
	}

	private static void ClearPrivateParameters(in RSAParameters rsaParameters)
	{
		CryptographicOperations.ZeroMemory(rsaParameters.D);
		CryptographicOperations.ZeroMemory(rsaParameters.P);
		CryptographicOperations.ZeroMemory(rsaParameters.Q);
		CryptographicOperations.ZeroMemory(rsaParameters.DP);
		CryptographicOperations.ZeroMemory(rsaParameters.DQ);
		CryptographicOperations.ZeroMemory(rsaParameters.InverseQ);
	}
}
