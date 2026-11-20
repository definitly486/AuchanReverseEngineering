using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography.Asn1;
using System.Security.Cryptography.Asn1.Pkcs12;
using System.Security.Cryptography.Asn1.Pkcs7;
using Internal.Cryptography;

namespace System.Security.Cryptography.X509Certificates;

[UnsupportedOSPlatform("browser")]
public static class X509CertificateLoader
{
	private readonly struct Pkcs12Return
	{
		private readonly ICertificatePal _pal;

		internal X509Certificate2 ToCertificate()
		{
			return new X509Certificate2(_pal);
		}

		internal Pkcs12Return(ICertificatePal pal)
		{
			_pal = pal;
		}
	}

	private enum CngMachineKeyState
	{
		Unknown,
		Permitted,
		Denied
	}

	private struct BagState
	{
		private SafeBagAsn[] _certBags;

		private SafeBagAsn[] _keyBags;

		private byte[] _decryptBuffer;

		private byte[] _keyDecryptBuffer;

		private int _certCount;

		private int _keyCount;

		private int _decryptBufferOffset;

		private int _keyDecryptBufferOffset;

		private byte _passwordState;

		private X509KeyStorageFlags _storageFlags;

		public readonly int CertCount => _certCount;

		public readonly int KeyCount => _keyCount;

		internal bool LockedPassword => (_passwordState & 1) != 0;

		internal bool ConfirmedPassword => (_passwordState & 2) != 0;

		internal void Init(Pkcs12LoaderLimits loaderLimits)
		{
			_certBags = ArrayPool<SafeBagAsn>.Shared.Rent(loaderLimits.MaxCertificates ?? 10);
			_keyBags = ArrayPool<SafeBagAsn>.Shared.Rent(loaderLimits.MaxKeys ?? 10);
			_certCount = 0;
			_keyCount = 0;
			_decryptBufferOffset = 0;
		}

		public void Dispose()
		{
			if (_certBags != null)
			{
				ArrayPool<SafeBagAsn>.Shared.Return(_certBags, clearArray: true);
			}
			if (_keyBags != null)
			{
				ArrayPool<SafeBagAsn>.Shared.Return(_keyBags, clearArray: true);
			}
			if (_decryptBuffer != null)
			{
				System.Security.Cryptography.CryptoPool.Return(_decryptBuffer, _decryptBufferOffset);
			}
			if (_keyDecryptBuffer != null)
			{
				System.Security.Cryptography.CryptoPool.Return(_keyDecryptBuffer, _keyDecryptBufferOffset);
			}
			this = default(BagState);
		}

		internal void LockPassword()
		{
			_passwordState |= 1;
		}

		internal void ConfirmPassword()
		{
			_passwordState |= 3;
		}

		internal void PrepareDecryptBuffer(int upperBound)
		{
			if (_decryptBuffer == null)
			{
				_decryptBuffer = System.Security.Cryptography.CryptoPool.Rent(upperBound);
			}
		}

		internal ReadOnlyMemory<byte> DecryptSafeContents(in AlgorithmIdentifierAsn algorithmIdentifier, ReadOnlySpan<char> passwordSpan, ReadOnlySpan<byte> encryptedContent)
		{
			int decryptBufferOffset = _decryptBufferOffset;
			_decryptBufferOffset = _decryptBuffer.Length;
			try
			{
				int num = PasswordBasedEncryption.Decrypt(in algorithmIdentifier, passwordSpan, default(ReadOnlySpan<byte>), encryptedContent, _decryptBuffer.AsSpan(decryptBufferOffset));
				_decryptBufferOffset = decryptBufferOffset + num;
				try
				{
					AsnValueReader asnValueReader = new AsnValueReader(_decryptBuffer.AsSpan(decryptBufferOffset, num), AsnEncodingRules.BER);
					asnValueReader.ReadSequence();
					asnValueReader.ThrowIfNotEmpty();
				}
				catch (AsnContentException)
				{
					ThrowWithHResult("Cryptography_Der_Invalid_Encoding", -2146885630);
				}
				ConfirmPassword();
				return new ReadOnlyMemory<byte>(_decryptBuffer, decryptBufferOffset, num);
			}
			catch (PlatformNotSupportedException innerException)
			{
				ThrowWithHResult("Cryptography_Pfx_BadPassword", -2147024810, innerException);
				throw;
			}
			catch (CryptographicException ex2)
			{
				CryptographicOperations.ZeroMemory(_decryptBuffer.AsSpan(decryptBufferOffset, _decryptBufferOffset - decryptBufferOffset));
				_decryptBufferOffset = decryptBufferOffset;
				if (ex2.HResult != -2146885630)
				{
					ex2.HResult = (ConfirmedPassword ? (-2146893792) : (-2147024810));
				}
				throw;
			}
		}

		internal void AddCert(SafeBagAsn bag)
		{
			GrowIfNeeded(ref _certBags, _certCount);
			_certBags[_certCount] = bag;
			_certCount++;
		}

		internal void AddKey(SafeBagAsn bag)
		{
			GrowIfNeeded(ref _keyBags, _keyCount);
			_keyBags[_keyCount] = bag;
			_keyCount++;
		}

		private static void GrowIfNeeded(ref SafeBagAsn[] array, int index)
		{
			if (array.Length <= index)
			{
				SafeBagAsn[] array2 = ArrayPool<SafeBagAsn>.Shared.Rent(checked(index + 1));
				array.AsSpan().CopyTo(array2);
				ArrayPool<SafeBagAsn>.Shared.Return(array, clearArray: true);
				array = array2;
			}
		}

		internal void UnshroudKeys(ref ReadOnlySpan<char> password)
		{
			int num = 0;
			for (int i = 0; i < _keyCount; i++)
			{
				SafeBagAsn safeBagAsn = _keyBags[i];
				if (safeBagAsn.BagId == "1.2.840.113549.1.12.10.1.2")
				{
					num += safeBagAsn.BagValue.Length;
				}
			}
			_keyDecryptBuffer = System.Security.Cryptography.CryptoPool.Rent(num);
			for (int j = 0; j < _keyCount; j++)
			{
				ref SafeBagAsn reference = ref _keyBags[j];
				if (!(reference.BagId == "1.2.840.113549.1.12.10.1.2"))
				{
					continue;
				}
				ArraySegment<byte> arraySegment = default(ArraySegment<byte>);
				int bytesRead = 0;
				if (!LockedPassword)
				{
					try
					{
						arraySegment = KeyFormatHelper.DecryptPkcs8(password, reference.BagValue, out bytesRead);
						try
						{
							AsnValueReader asnValueReader = new AsnValueReader(arraySegment, AsnEncodingRules.BER);
							asnValueReader.ReadSequence();
							asnValueReader.ThrowIfNotEmpty();
						}
						catch (AsnContentException)
						{
							System.Security.Cryptography.CryptoPool.Return(arraySegment);
							arraySegment = default(ArraySegment<byte>);
							throw new CryptographicException();
						}
					}
					catch (CryptographicException)
					{
						password = (password.ContainsNull() ? "".AsSpan() : default(ReadOnlySpan<char>));
					}
				}
				if (arraySegment.Array == null)
				{
					try
					{
						arraySegment = KeyFormatHelper.DecryptPkcs8(password, reference.BagValue, out bytesRead);
						try
						{
							AsnValueReader asnValueReader2 = new AsnValueReader(arraySegment, AsnEncodingRules.BER);
							asnValueReader2.ReadSequence();
							asnValueReader2.ThrowIfNotEmpty();
						}
						catch (AsnContentException)
						{
							System.Security.Cryptography.CryptoPool.Return(arraySegment);
							arraySegment = default(ArraySegment<byte>);
							throw new CryptographicException();
						}
					}
					catch (CryptographicException)
					{
						continue;
					}
				}
				ConfirmPassword();
				arraySegment.AsSpan().CopyTo(_keyDecryptBuffer.AsSpan(_keyDecryptBufferOffset));
				ReadOnlyMemory<byte> bagValue = new ReadOnlyMemory<byte>(_keyDecryptBuffer, _keyDecryptBufferOffset, arraySegment.Count);
				System.Security.Cryptography.CryptoPool.Return(arraySegment);
				_keyDecryptBufferOffset += bagValue.Length;
				if (bytesRead != reference.BagValue.Length)
				{
					throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
				}
				reference.BagValue = bagValue;
				reference.BagId = "1.2.840.113549.1.12.10.1.1";
			}
		}

		internal ReadOnlySpan<SafeBagAsn> GetCertsSpan()
		{
			return new ReadOnlySpan<SafeBagAsn>(_certBags, 0, _certCount);
		}

		internal ReadOnlySpan<SafeBagAsn> GetKeysSpan()
		{
			return new ReadOnlySpan<SafeBagAsn>(_keyBags, 0, _keyCount);
		}
	}

	private struct CertAndKey
	{
		internal ICertificatePalCore Cert;

		internal Pkcs12Key Key;

		internal void Dispose()
		{
			Cert?.Dispose();
			Key?.Dispose();
		}
	}

	private struct CertKeyMatcher
	{
		private CertAndKey[] _certAndKeys;

		private int _certCount;

		private Pkcs12Key[] _keys;

		private RentedSubjectPublicKeyInfo[] _rentedSpki;

		private int _keyCount;

		internal void LoadCerts(ref BagState bagState)
		{
			if (bagState.CertCount != 0)
			{
				_certAndKeys = ArrayPool<CertAndKey>.Shared.Rent(bagState.CertCount);
				ReadOnlySpan<SafeBagAsn> certsSpan = bagState.GetCertsSpan();
				for (int i = 0; i < certsSpan.Length; i++)
				{
					ICertificatePalCore cert = LoadX509Der(Helpers.DecodeOctetStringAsMemory(CertBagAsn.Decode(certsSpan[i].BagValue, AsnEncodingRules.BER).CertValue));
					_certAndKeys[_certCount].Cert = cert;
					_certCount++;
				}
			}
		}

		internal void LoadKeys(ref BagState bagState)
		{
			if (bagState.KeyCount == 0)
			{
				return;
			}
			_keys = ArrayPool<Pkcs12Key>.Shared.Rent(bagState.KeyCount);
			ReadOnlySpan<SafeBagAsn> keysSpan = bagState.GetKeysSpan();
			for (int i = 0; i < keysSpan.Length; i++)
			{
				SafeBagAsn safeBagAsn = keysSpan[i];
				Pkcs12Key pkcs12Key = null;
				try
				{
					if (safeBagAsn.BagId == "1.2.840.113549.1.12.10.1.1")
					{
						pkcs12Key = CreateKey(PrivateKeyInfoAsn.Decode(safeBagAsn.BagValue, AsnEncodingRules.BER).PrivateKeyAlgorithm.Algorithm, safeBagAsn.BagValue.Span);
						if (pkcs12Key != null)
						{
							if (_rentedSpki == null)
							{
								_rentedSpki = ArrayPool<RentedSubjectPublicKeyInfo>.Shared.Rent(bagState.KeyCount);
								_rentedSpki.AsSpan().Clear();
							}
							ExtractPublicKey(ref _rentedSpki[_keyCount], pkcs12Key, safeBagAsn.BagValue.Length);
						}
					}
				}
				catch (AsnContentException)
				{
					pkcs12Key?.Dispose();
					pkcs12Key = null;
				}
				catch (CryptographicException)
				{
					pkcs12Key?.Dispose();
					pkcs12Key = null;
				}
				if (pkcs12Key != null)
				{
					_keys[_keyCount] = pkcs12Key;
				}
				_keyCount++;
			}
		}

		internal CertAndKey[] MatchCertAndKeys(ref BagState bagState, bool allowDoubleBind)
		{
			ReadOnlySpan<SafeBagAsn> certsSpan = bagState.GetCertsSpan();
			ReadOnlySpan<SafeBagAsn> keysSpan = bagState.GetKeysSpan();
			for (int num = certsSpan.Length - 1; num >= 0; num--)
			{
				int num2 = -1;
				AttributeAsn[] array = certsSpan[num].BagAttributes ?? Array.Empty<AttributeAsn>();
				for (int i = 0; i < array.Length; i++)
				{
					AttributeAsn attributeAsn = array[i];
					if (attributeAsn.AttrType == "1.2.840.113549.1.9.21" && attributeAsn.AttrValues.Length != 0)
					{
						num2 = FindMatchingKey(keysSpan, Helpers.DecodeOctetStringAsMemory(attributeAsn.AttrValues[0]).Span);
						break;
					}
				}
				ICertificatePalCore cert = _certAndKeys[num].Cert;
				if (num2 == -1 && _rentedSpki != null)
				{
					for (int j = 0; j < keysSpan.Length; j++)
					{
						if (PublicKeyMatches(cert, ref _rentedSpki[j].Value))
						{
							num2 = j;
							break;
						}
					}
				}
				if (num2 != -1)
				{
					if (_keys[num2] == null)
					{
						SafeBagAsn safeBagAsn = keysSpan[num2];
						if (safeBagAsn.BagId != "1.2.840.113549.1.12.10.1.1")
						{
							if (bagState.ConfirmedPassword)
							{
								throw new CryptographicException("Cryptography_Pfx_BadKeyReference");
							}
							throw new CryptographicException("Cryptography_Pfx_BadPassword")
							{
								HResult = -2147024810
							};
						}
						if (!allowDoubleBind)
						{
							throw new CryptographicException("Cryptography_Pfx_BadKeyReference");
						}
						Pkcs12Key pkcs12Key = CreateKey(cert.KeyAlgorithm, safeBagAsn.BagValue.Span);
						if (pkcs12Key == null)
						{
							throw new CryptographicException("Cryptography_UnknownAlgorithmIdentifier", cert.KeyAlgorithm);
						}
						_certAndKeys[num].Key = pkcs12Key;
					}
					else
					{
						_certAndKeys[num].Key = _keys[num2];
						_keys[num2] = null;
					}
				}
			}
			CertAndKey[] certAndKeys = _certAndKeys;
			_certAndKeys = null;
			return certAndKeys;
		}

		private static int FindMatchingKey(ReadOnlySpan<SafeBagAsn> keyBags, ReadOnlySpan<byte> localKeyId)
		{
			for (int i = 0; i < keyBags.Length; i++)
			{
				AttributeAsn[] array = keyBags[i].BagAttributes ?? Array.Empty<AttributeAsn>();
				for (int j = 0; j < array.Length; j++)
				{
					AttributeAsn attributeAsn = array[j];
					if (attributeAsn.AttrType == "1.2.840.113549.1.9.21" && attributeAsn.AttrValues.Length != 0)
					{
						if (!Helpers.DecodeOctetStringAsMemory(attributeAsn.AttrValues[0]).Span.SequenceEqual(localKeyId))
						{
							break;
						}
						return i;
					}
				}
			}
			return -1;
		}

		private static bool PublicKeyMatches(ICertificatePalCore cert, ref SubjectPublicKeyInfoAsn publicKeyInfo)
		{
			string keyAlgorithm = cert.KeyAlgorithm;
			string algorithm = publicKeyInfo.Algorithm.Algorithm;
			bool flag;
			switch (keyAlgorithm)
			{
			case "1.2.840.113549.1.1.1":
			{
				bool flag2 = ((algorithm == "1.2.840.113549.1.1.1" || algorithm == "1.2.840.113549.1.1.10") ? true : false);
				flag = flag2;
				break;
			}
			case "1.2.840.10045.2.1":
			case "1.3.132.1.12":
			{
				bool flag2 = ((algorithm == "1.2.840.10045.2.1" || algorithm == "1.3.132.1.12") ? true : false);
				flag = flag2;
				break;
			}
			default:
				flag = keyAlgorithm.Equals(algorithm, StringComparison.Ordinal);
				break;
			}
			if (!flag)
			{
				return false;
			}
			byte[] publicKeyValue = cert.PublicKeyValue;
			if (!publicKeyInfo.SubjectPublicKey.Span.SequenceEqual(publicKeyValue))
			{
				return false;
			}
			byte[] keyAlgorithmParameters = cert.KeyAlgorithmParameters;
			switch (keyAlgorithm)
			{
			case "1.2.840.113549.1.1.1":
			case "1.2.840.113549.1.1.10":
				if (publicKeyInfo.Algorithm.HasNullEquivalentParameters())
				{
					return AlgorithmIdentifierAsn.RepresentsNull(keyAlgorithmParameters);
				}
				return false;
			case "1.2.840.10045.2.1":
			case "1.3.132.1.12":
				if (publicKeyInfo.Algorithm.Parameters.HasValue && keyAlgorithmParameters != null)
				{
					return publicKeyInfo.Algorithm.Parameters.Value.Span.SequenceEqual(keyAlgorithmParameters);
				}
				return false;
			default:
				if (!publicKeyInfo.Algorithm.Parameters.HasValue)
				{
					return keyAlgorithmParameters == null || keyAlgorithmParameters.Length == 0;
				}
				if (keyAlgorithmParameters != null)
				{
					return publicKeyInfo.Algorithm.Parameters.Value.Span.SequenceEqual(keyAlgorithmParameters);
				}
				return false;
			}
		}

		private static void ExtractPublicKey(ref RentedSubjectPublicKeyInfo spki, Pkcs12Key key, int sizeHint)
		{
			byte[] array = System.Security.Cryptography.CryptoPool.Rent(sizeHint);
			int bytesWritten;
			while (!key.TryExportSubjectPublicKeyInfo(array, out bytesWritten))
			{
				sizeHint = checked(array.Length * 2);
				System.Security.Cryptography.CryptoPool.Return(array);
				array = System.Security.Cryptography.CryptoPool.Rent(sizeHint);
			}
			spki.TrackArray(array, bytesWritten);
			spki.Value = SubjectPublicKeyInfoAsn.Decode(array.AsMemory(0, bytesWritten), AsnEncodingRules.BER);
		}

		internal static void Free(CertAndKey[] certAndKeys, int count)
		{
			for (int num = count - 1; num >= 0; num--)
			{
				certAndKeys[num].Dispose();
			}
			ArrayPool<CertAndKey>.Shared.Return(certAndKeys, clearArray: true);
		}

		internal void Dispose()
		{
			if (_certAndKeys != null)
			{
				Free(_certAndKeys, _certCount);
			}
			if (_keys != null)
			{
				for (int num = _keyCount - 1; num >= 0; num--)
				{
					_keys[num]?.Dispose();
				}
				ArrayPool<Pkcs12Key>.Shared.Return(_keys, clearArray: true);
			}
			if (_rentedSpki != null)
			{
				for (int num2 = _keyCount - 1; num2 >= 0; num2--)
				{
					_rentedSpki[num2].Dispose();
				}
			}
			this = default(CertKeyMatcher);
		}
	}

	private struct RentedSubjectPublicKeyInfo
	{
		private byte[] _rented;

		private int _clearSize;

		internal SubjectPublicKeyInfoAsn Value;

		internal void TrackArray(byte[] rented, int clearSize = -1)
		{
			_rented = rented;
			_clearSize = clearSize;
		}

		internal void Dispose()
		{
			byte[] rented = _rented;
			_rented = null;
			if (rented != null)
			{
				System.Security.Cryptography.CryptoPool.Return(rented, _clearSize);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct ImportState
	{
		internal void Dispose()
		{
		}
	}

	public static X509Certificate2 LoadCertificate(ReadOnlySpan<byte> data)
	{
		if (data.IsEmpty)
		{
			ThrowWithHResult("Cryptography_Der_Invalid_Encoding", -2146885630);
		}
		return new X509Certificate2(LoadCertificatePal(data));
	}

	public static X509Certificate2 LoadCertificate(byte[] data)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		return LoadCertificate(new ReadOnlySpan<byte>(data));
	}

	public unsafe static X509Certificate2Collection LoadPkcs12Collection(ReadOnlySpan<byte> data, ReadOnlySpan<char> password, X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.DefaultKeySet, Pkcs12LoaderLimits? loaderLimits = null)
	{
		ValidateKeyStorageFlagsCore(keyStorageFlags);
		fixed (byte* pointer = data)
		{
			using PointerMemoryManager<byte> pointerMemoryManager = new PointerMemoryManager<byte>(pointer, data.Length);
			return LoadPkcs12Collection(pointerMemoryManager.Memory, password, keyStorageFlags, loaderLimits ?? Pkcs12LoaderLimits.Defaults);
		}
	}

	[DoesNotReturn]
	private static void ThrowWithHResult(string message, int hResult)
	{
		throw new CryptographicException(message)
		{
			HResult = hResult
		};
	}

	private static void ValidateKeyStorageFlagsCore(X509KeyStorageFlags keyStorageFlags)
	{
		if ((keyStorageFlags & ~(X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.UserProtected | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet)) != X509KeyStorageFlags.DefaultKeySet)
		{
			throw new ArgumentException("Argument_InvalidFlag", "keyStorageFlags");
		}
		X509KeyStorageFlags x509KeyStorageFlags = keyStorageFlags & (X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet);
		if (x509KeyStorageFlags == (X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet))
		{
			throw new ArgumentException(System.SR.Format("Cryptography_X509_InvalidFlagCombination", x509KeyStorageFlags), "keyStorageFlags");
		}
		ValidatePlatformKeyStorageFlags(keyStorageFlags);
	}

	[DoesNotReturn]
	private static void ThrowWithHResult(string message, int hResult, Exception innerException)
	{
		throw new CryptographicException(message, innerException)
		{
			HResult = hResult
		};
	}

	private static X509Certificate2Collection LoadPkcs12Collection(ref BagState bagState, ReadOnlySpan<char> password, X509KeyStorageFlags keyStorageFlags)
	{
		bool flag = (keyStorageFlags & X509KeyStorageFlags.EphemeralKeySet) != 0;
		CertKeyMatcher certKeyMatcher = default(CertKeyMatcher);
		CertAndKey[] array = null;
		ImportState importState = default(ImportState);
		try
		{
			certKeyMatcher.LoadCerts(ref bagState);
			certKeyMatcher.LoadKeys(ref bagState);
			array = certKeyMatcher.MatchCertAndKeys(ref bagState, !flag);
			X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
			for (int num = bagState.CertCount - 1; num >= 0; num--)
			{
				x509Certificate2Collection.Add(FromCertAndKey(array[num], importState).ToCertificate());
				array[num] = default(CertAndKey);
			}
			return x509Certificate2Collection;
		}
		finally
		{
			if (array != null)
			{
				CertKeyMatcher.Free(array, bagState.CertCount);
			}
			importState.Dispose();
			certKeyMatcher.Dispose();
		}
	}

	private static X509Certificate2Collection LoadPkcs12Collection(ReadOnlyMemory<byte> data, ReadOnlySpan<char> password, X509KeyStorageFlags keyStorageFlags, Pkcs12LoaderLimits loaderLimits)
	{
		if (loaderLimits == Pkcs12LoaderLimits.DangerousNoLimits)
		{
			X509Certificate2Collection x509Certificate2Collection = null;
			if (x509Certificate2Collection != null)
			{
				return x509Certificate2Collection;
			}
		}
		BagState bagState = default(BagState);
		try
		{
			ReadCertsAndKeys(ref bagState, data, ref password, loaderLimits);
			if (bagState.CertCount == 0)
			{
				return new X509Certificate2Collection();
			}
			bagState.UnshroudKeys(ref password);
			return LoadPkcs12Collection(ref bagState, password, keyStorageFlags);
		}
		finally
		{
			bagState.Dispose();
		}
	}

	private static void ReadCertsAndKeys(ref BagState bagState, ReadOnlyMemory<byte> data, ref ReadOnlySpan<char> password, Pkcs12LoaderLimits loaderLimits)
	{
		try
		{
			AsnDecoder.ReadSequence(data.Span, AsnEncodingRules.BER, out var _, out var _, out var bytesConsumed);
			data = data.Slice(0, bytesConsumed);
			PfxAsn pfxAsn = PfxAsn.Decode(data, AsnEncodingRules.BER);
			if (pfxAsn.AuthSafe.ContentType != "1.2.840.113549.1.7.1")
			{
				throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
			}
			ReadOnlySpan<byte> span = Helpers.DecodeOctetStringAsMemory(pfxAsn.AuthSafe.Content).Span;
			if (!password.IsEmpty)
			{
				bagState.LockPassword();
			}
			if (pfxAsn.MacData.HasValue)
			{
				if (pfxAsn.MacData.Value.IterationCount > loaderLimits.MacIterationLimit)
				{
					throw new Pkcs12LoadLimitExceededException("MacIterationLimit");
				}
				bool flag = false;
				if (!bagState.LockedPassword)
				{
					if (!pfxAsn.VerifyMac(password, span))
					{
						password = (password.ContainsNull() ? "".AsSpan() : default(ReadOnlySpan<char>));
					}
					else
					{
						flag = true;
					}
				}
				if (!flag && !pfxAsn.VerifyMac(password, span))
				{
					ThrowWithHResult("Cryptography_Pfx_BadPassword", -2147024810);
				}
				bagState.ConfirmPassword();
			}
			AsnValueReader asnValueReader = new AsnValueReader(span, AsnEncodingRules.BER);
			AsnValueReader reader = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			ReadOnlyMemory<byte> content = pfxAsn.AuthSafe.Content;
			bagState.Init(loaderLimits);
			int? workRemaining = loaderLimits.TotalKdfIterationLimit;
			while (reader.HasData)
			{
				ContentInfoAsn.Decode(ref reader, content, out var decoded);
				ReadOnlyMemory<byte> contentData;
				if (decoded.ContentType == "1.2.840.113549.1.7.1")
				{
					contentData = Helpers.DecodeOctetStringAsMemory(decoded.Content);
				}
				else
				{
					if (!(decoded.ContentType == "1.2.840.113549.1.7.6"))
					{
						throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
					}
					if (loaderLimits.IgnoreEncryptedAuthSafes)
					{
						continue;
					}
					bagState.PrepareDecryptBuffer(span.Length);
					if (!bagState.LockedPassword)
					{
						bagState.LockPassword();
						int? num = workRemaining;
						try
						{
							contentData = DecryptSafeContents(decoded, loaderLimits, password, ref bagState, ref workRemaining);
						}
						catch (CryptographicException)
						{
							password = (password.ContainsNull() ? "".AsSpan() : default(ReadOnlySpan<char>));
							workRemaining = num;
							contentData = DecryptSafeContents(decoded, loaderLimits, password, ref bagState, ref workRemaining);
						}
					}
					else
					{
						contentData = DecryptSafeContents(decoded, loaderLimits, password, ref bagState, ref workRemaining);
					}
				}
				ProcessSafeContents(contentData, loaderLimits, ref workRemaining, ref bagState);
			}
		}
		catch (AsnContentException innerException)
		{
			ThrowWithHResult("Cryptography_Der_Invalid_Encoding", -2146885630, innerException);
		}
	}

	private static void ProcessSafeContents(ReadOnlyMemory<byte> contentData, Pkcs12LoaderLimits loaderLimits, ref int? workRemaining, ref BagState bagState)
	{
		AsnValueReader asnValueReader = new AsnValueReader(contentData.Span, AsnEncodingRules.BER);
		AsnValueReader reader = asnValueReader.ReadSequence();
		asnValueReader.ThrowIfNotEmpty();
		HashSet<string> duplicateAttributeCheck = new HashSet<string>();
		CngMachineKeyState cngMachineKeyState = CngMachineKeyState.Unknown;
		checked
		{
			while (reader.HasData)
			{
				SafeBagAsn.Decode(ref reader, contentData, out var bag);
				if (bag.BagId == "1.2.840.113549.1.12.10.1.3")
				{
					if (bag.BagAttributes != null && !loaderLimits.AllowDuplicateAttributes)
					{
						RejectDuplicateAttributes(bag.BagAttributes, duplicateAttributeCheck);
					}
					if (!(CertBagAsn.Decode(bag.BagValue, AsnEncodingRules.BER).CertId == "1.2.840.113549.1.9.22.1"))
					{
						continue;
					}
					if (bagState.CertCount >= loaderLimits.MaxCertificates)
					{
						throw new Pkcs12LoadLimitExceededException("MaxCertificates");
					}
					if (bag.BagAttributes != null)
					{
						FilterAttributes(loaderLimits, ref bag, delegate(Pkcs12LoaderLimits limits, string oid)
						{
							if (oid == "1.2.840.113549.1.9.21")
							{
								return true;
							}
							return (oid == "1.2.840.113549.1.9.20") ? limits.PreserveCertificateAlias : limits.PreserveUnknownAttributes;
						});
					}
					bagState.AddCert(bag);
					continue;
				}
				string bagId = bag.BagId;
				if ((!(bagId == "1.2.840.113549.1.12.10.1.1") && !(bagId == "1.2.840.113549.1.12.10.1.2")) || 1 == 0)
				{
					continue;
				}
				if (bag.BagAttributes != null && !loaderLimits.AllowDuplicateAttributes)
				{
					RejectDuplicateAttributes(bag.BagAttributes, duplicateAttributeCheck);
				}
				if (loaderLimits.IgnorePrivateKeys)
				{
					continue;
				}
				if (bagState.KeyCount >= loaderLimits.MaxKeys)
				{
					throw new Pkcs12LoadLimitExceededException("MaxKeys");
				}
				if (bag.BagId == "1.2.840.113549.1.12.10.1.2")
				{
					EncryptedPrivateKeyInfoAsn encryptedPrivateKeyInfoAsn = EncryptedPrivateKeyInfoAsn.Decode(bag.BagValue, AsnEncodingRules.BER);
					int kdfCount = GetKdfCount(in encryptedPrivateKeyInfoAsn.EncryptionAlgorithm);
					if (kdfCount > loaderLimits.IndividualKdfIterationLimit || kdfCount > workRemaining)
					{
						throw new Pkcs12LoadLimitExceededException((kdfCount > loaderLimits.IndividualKdfIterationLimit) ? "IndividualKdfIterationLimit" : "TotalKdfIterationLimit");
					}
					if (workRemaining.HasValue)
					{
						workRemaining -= kdfCount;
					}
				}
				if (bag.BagAttributes != null)
				{
					FilterAttributes(loaderLimits, ref bag, (Pkcs12LoaderLimits limits, string attrType) => attrType switch
					{
						"1.2.840.113549.1.9.21" => true, 
						"1.3.6.1.4.1.311.17.2" => true, 
						"1.2.840.113549.1.9.20" => limits.PreserveKeyName, 
						"1.3.6.1.4.1.311.17.1" => false, 
						_ => limits.PreserveUnknownAttributes, 
					});
				}
				AttributeAsn? attributeAsn = null;
				if (false)
				{
				}
				bagState.AddKey(bag);
			}
		}
	}

	private static void RejectDuplicateAttributes(AttributeAsn[] bagAttributes, HashSet<string> duplicateAttributeCheck)
	{
		duplicateAttributeCheck.Clear();
		for (int i = 0; i < bagAttributes.Length; i++)
		{
			AttributeAsn attributeAsn = bagAttributes[i];
			if (!duplicateAttributeCheck.Add(attributeAsn.AttrType) || attributeAsn.AttrValues.Length > 1)
			{
				throw new Pkcs12LoadLimitExceededException("AllowDuplicateAttributes");
			}
		}
	}

	private static void FilterAttributes(Pkcs12LoaderLimits loaderLimits, ref SafeBagAsn bag, Func<Pkcs12LoaderLimits, string, bool> filter)
	{
		if (bag.BagAttributes == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < bag.BagAttributes.Length; i++)
		{
			string attrType = bag.BagAttributes[i].AttrType;
			if (filter(loaderLimits, attrType))
			{
				num++;
				if (num != i)
				{
					AttributeAsn attributeAsn = bag.BagAttributes[i];
					bag.BagAttributes[num] = attributeAsn;
				}
			}
		}
		int num2 = num + 1;
		if (num2 < bag.BagAttributes.Length)
		{
			if (num2 == 0)
			{
				bag.BagAttributes = null;
			}
			else
			{
				Array.Resize(ref bag.BagAttributes, num2);
			}
		}
	}

	private static ReadOnlyMemory<byte> DecryptSafeContents(ContentInfoAsn safeContentsAsn, Pkcs12LoaderLimits loaderLimits, ReadOnlySpan<char> passwordSpan, ref BagState bagState, ref int? workRemaining)
	{
		EncryptedDataAsn encryptedDataAsn = EncryptedDataAsn.Decode(safeContentsAsn.Content, AsnEncodingRules.BER);
		if (encryptedDataAsn.Version != 0 && encryptedDataAsn.Version != 2)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		if (encryptedDataAsn.EncryptedContentInfo.ContentType != "1.2.840.113549.1.7.1")
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		if (!encryptedDataAsn.EncryptedContentInfo.EncryptedContent.HasValue)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		ReadOnlyMemory<byte> value = encryptedDataAsn.EncryptedContentInfo.EncryptedContent.Value;
		int kdfCount = GetKdfCount(in encryptedDataAsn.EncryptedContentInfo.ContentEncryptionAlgorithm);
		if (kdfCount > loaderLimits.IndividualKdfIterationLimit || kdfCount > workRemaining)
		{
			throw new Pkcs12LoadLimitExceededException((kdfCount > loaderLimits.IndividualKdfIterationLimit) ? "IndividualKdfIterationLimit" : "TotalKdfIterationLimit");
		}
		checked
		{
			if (workRemaining.HasValue)
			{
				workRemaining -= kdfCount;
			}
			return bagState.DecryptSafeContents(in encryptedDataAsn.EncryptedContentInfo.ContentEncryptionAlgorithm, passwordSpan, value.Span);
		}
	}

	private static int GetKdfCount(in AlgorithmIdentifierAsn algorithmIdentifier)
	{
		int num = GetRawKdfCount(in algorithmIdentifier);
		if (num < 0)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		return num;
		static int GetRawKdfCount(in AlgorithmIdentifierAsn reference)
		{
			if (!reference.Parameters.HasValue)
			{
				throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
			}
			switch (reference.Algorithm)
			{
			case "1.2.840.113549.1.5.3":
			case "1.2.840.113549.1.5.6":
			case "1.2.840.113549.1.5.10":
			case "1.2.840.113549.1.5.11":
			case "1.2.840.113549.1.12.1.3":
			case "1.2.840.113549.1.12.1.4":
			case "1.2.840.113549.1.12.1.5":
			case "1.2.840.113549.1.12.1.6":
				return PBEParameter.Decode(reference.Parameters.Value, AsnEncodingRules.BER).IterationCount;
			case "1.2.840.113549.1.5.13":
			{
				PBES2Params pBES2Params = PBES2Params.Decode(reference.Parameters.Value, AsnEncodingRules.BER);
				if (pBES2Params.KeyDerivationFunc.Algorithm != "1.2.840.113549.1.5.12")
				{
					throw new CryptographicException(System.SR.Format("Cryptography_UnknownAlgorithmIdentifier", pBES2Params.EncryptionScheme.Algorithm));
				}
				if (!pBES2Params.KeyDerivationFunc.Parameters.HasValue)
				{
					throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
				}
				return Pbkdf2Params.Decode(pBES2Params.KeyDerivationFunc.Parameters.Value, AsnEncodingRules.BER).IterationCount;
			}
			default:
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownAlgorithmIdentifier", reference.Algorithm));
			}
		}
	}

	private static ICertificatePal LoadCertificatePal(ReadOnlySpan<byte> data)
	{
		if (!AndroidCertificatePal.TryReadX509(data, out var handle))
		{
			handle?.Dispose();
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		return handle;
	}

	private static void ValidatePlatformKeyStorageFlags(X509KeyStorageFlags keyStorageFlags)
	{
		if ((keyStorageFlags & X509KeyStorageFlags.PersistKeySet) == X509KeyStorageFlags.PersistKeySet)
		{
			throw new PlatformNotSupportedException("Cryptography_X509_PKCS12_PersistKeySetNotSupported");
		}
	}

	internal static SafeKeyHandle GetPrivateKey(AsymmetricAlgorithm key)
	{
		if (key is ECDsaImplementation.ECDsaAndroid eCDsaAndroid)
		{
			return eCDsaAndroid.DuplicateKeyHandle();
		}
		if (key is RSAImplementation.RSAAndroid rSAAndroid)
		{
			return rSAAndroid.DuplicateKeyHandle();
		}
		if (key is DSAImplementation.DSAAndroid dSAAndroid)
		{
			return dSAAndroid.DuplicateKeyHandle();
		}
		throw new NotImplementedException($"{"GetPrivateKey"} ({key.GetType()})");
	}

	private static Pkcs12Return FromCertAndKey(CertAndKey certAndKey, ImportState importState)
	{
		AndroidCertificatePal androidCertificatePal = (AndroidCertificatePal)certAndKey.Cert;
		if (certAndKey.Key != null)
		{
			Pkcs12Key key = certAndKey.Key;
			if (key == null || !(key.Key is AsymmetricAlgorithm key2))
			{
				throw new CryptographicException();
			}
			androidCertificatePal.SetPrivateKey(GetPrivateKey(key2));
			certAndKey.Key.Dispose();
		}
		return new Pkcs12Return(androidCertificatePal);
	}

	private static Pkcs12Key CreateKey(string algorithm, ReadOnlySpan<byte> pkcs8)
	{
		switch (algorithm)
		{
		case "1.2.840.113549.1.1.1":
		case "1.2.840.113549.1.1.10":
			return new AsymmetricAlgorithmPkcs12PrivateKey(pkcs8, () => new RSAImplementation.RSAAndroid());
		case "1.2.840.10045.2.1":
		case "1.3.132.1.12":
			return new AsymmetricAlgorithmPkcs12PrivateKey(pkcs8, () => new ECDsaImplementation.ECDsaAndroid());
		case "1.2.840.10040.4.1":
			return new AsymmetricAlgorithmPkcs12PrivateKey(pkcs8, () => new DSAImplementation.DSAAndroid());
		default:
			return null;
		}
	}

	private static ICertificatePalCore LoadX509Der(ReadOnlyMemory<byte> data)
	{
		ReadOnlySpan<byte> span = data.Span;
		AsnValueReader asnValueReader = new AsnValueReader(span, AsnEncodingRules.DER);
		asnValueReader.ReadSequence();
		asnValueReader.ThrowIfNotEmpty();
		if (!AndroidCertificatePal.TryReadX509(span, out var handle))
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		return handle;
	}

	internal unsafe static bool IsPkcs12(ReadOnlySpan<byte> data)
	{
		if (data.IsEmpty)
		{
			return false;
		}
		fixed (byte* pointer = data)
		{
			using PointerMemoryManager<byte> pointerMemoryManager = new PointerMemoryManager<byte>(pointer, data.Length);
			try
			{
				ReadOnlyMemory<byte> rebind = pointerMemoryManager.Memory;
				AsnValueReader reader = new AsnValueReader(rebind.Span, AsnEncodingRules.BER);
				PfxAsn.Decode(ref reader, rebind, out var _);
				return true;
			}
			catch (AsnContentException)
			{
			}
			catch (CryptographicException)
			{
			}
			return false;
		}
	}
}
