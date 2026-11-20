using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Asn1;

namespace System.Security.Cryptography;

internal static class RSAImplementation
{
	public sealed class RSAAndroid : RSA
	{
		private Lazy<SafeRsaHandle> _key;

		public override int KeySize
		{
			set
			{
				if (KeySize != value)
				{
					base.KeySize = value;
					ThrowIfDisposed();
					FreeKey();
					_key = new Lazy<SafeRsaHandle>(GenerateKey);
				}
			}
		}

		public override KeySizes[] LegalKeySizes => new KeySizes[1]
		{
			new KeySizes(512, 16384, 8)
		};

		public RSAAndroid()
			: this(2048)
		{
		}

		public RSAAndroid(int keySize)
		{
			base.KeySize = keySize;
			_key = new Lazy<SafeRsaHandle>(GenerateKey);
		}

		internal RSAAndroid(SafeRsaHandle key)
		{
			_key = new Lazy<SafeRsaHandle>(key.DuplicateHandle());
			SetKeySizeFromHandle(key);
		}

		private void SetKeySizeFromHandle(SafeRsaHandle key)
		{
			int keySizeValue = 8 * global::Interop.AndroidCrypto.RsaSize(key);
			KeySizeValue = keySizeValue;
		}

		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			RSAParameters parameters = global::Interop.AndroidCrypto.ExportRsaParameters(GetKey(), includePrivateParameters);
			if (parameters.D != null != includePrivateParameters || !HasConsistentPrivateKey(ref parameters))
			{
				throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
			}
			return parameters;
		}

		public override void ImportParameters(RSAParameters parameters)
		{
			ValidateParameters(ref parameters);
			ThrowIfDisposed();
			if (parameters.Exponent == null || !((ReadOnlySpan<byte>)parameters.Modulus.AsSpan()).ContainsAnyExcept((byte)0))
			{
				throw new CryptographicException("Cryptography_InvalidRsaParameters");
			}
			if (parameters.D == null)
			{
				if (parameters.P != null || parameters.DP != null || parameters.Q != null || parameters.DQ != null || parameters.InverseQ != null)
				{
					throw new CryptographicException("Cryptography_InvalidRsaParameters");
				}
			}
			else
			{
				if (parameters.P == null || parameters.DP == null || parameters.Q == null || parameters.DQ == null || parameters.InverseQ == null)
				{
					throw new CryptographicException("Cryptography_InvalidRsaParameters");
				}
				int num = (parameters.Modulus.Length + 1) / 2;
				if (parameters.D.Length != parameters.Modulus.Length || parameters.P.Length != num || parameters.Q.Length != num || parameters.DP.Length != num || parameters.DQ.Length != num || parameters.InverseQ.Length != num)
				{
					throw new CryptographicException("Cryptography_InvalidRsaParameters");
				}
			}
			SafeRsaHandle safeRsaHandle = global::Interop.AndroidCrypto.RsaCreate();
			bool flag = false;
			if (safeRsaHandle == null || safeRsaHandle.IsInvalid)
			{
				safeRsaHandle?.Dispose();
				throw new CryptographicException();
			}
			try
			{
				if (!global::Interop.AndroidCrypto.SetRsaParameters(safeRsaHandle, parameters.Modulus, (parameters.Modulus != null) ? parameters.Modulus.Length : 0, parameters.Exponent, (parameters.Exponent != null) ? parameters.Exponent.Length : 0, parameters.D, (parameters.D != null) ? parameters.D.Length : 0, parameters.P, (parameters.P != null) ? parameters.P.Length : 0, parameters.DP, (parameters.DP != null) ? parameters.DP.Length : 0, parameters.Q, (parameters.Q != null) ? parameters.Q.Length : 0, parameters.DQ, (parameters.DQ != null) ? parameters.DQ.Length : 0, parameters.InverseQ, (parameters.InverseQ != null) ? parameters.InverseQ.Length : 0))
				{
					throw new CryptographicException();
				}
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					safeRsaHandle.Dispose();
				}
			}
			FreeKey();
			_key = new Lazy<SafeRsaHandle>(safeRsaHandle);
			SetKeySizeFromHandle(safeRsaHandle);
		}

		public unsafe override void ImportRSAPublicKey(ReadOnlySpan<byte> source, out int bytesRead)
		{
			ThrowIfDisposed();
			fixed (byte* reference = &MemoryMarshal.GetReference(source))
			{
				using MemoryManager<byte> memoryManager = new PointerMemoryManager<byte>(reference, source.Length);
				ReadOnlyMemory<byte> subjectPublicKey;
				try
				{
					subjectPublicKey = new AsnReader(memoryManager.Memory, AsnEncodingRules.BER).PeekEncodedValue();
				}
				catch (AsnContentException inner)
				{
					throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
				}
				SubjectPublicKeyInfoAsn subjectPublicKeyInfoAsn = new SubjectPublicKeyInfoAsn
				{
					Algorithm = new AlgorithmIdentifierAsn
					{
						Algorithm = "1.2.840.113549.1.1.1",
						Parameters = AlgorithmIdentifierAsn.ExplicitDerNull
					},
					SubjectPublicKey = subjectPublicKey
				};
				AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
				subjectPublicKeyInfoAsn.Encode(asnWriter);
				SafeRsaHandle safeRsaHandle = asnWriter.Encode((ReadOnlySpan<byte> encoded) => global::Interop.AndroidCrypto.DecodeRsaSubjectPublicKeyInfo(encoded));
				if (safeRsaHandle == null || safeRsaHandle.IsInvalid)
				{
					safeRsaHandle?.Dispose();
					throw new CryptographicException();
				}
				FreeKey();
				_key = new Lazy<SafeRsaHandle>(safeRsaHandle);
				SetKeySizeFromHandle(safeRsaHandle);
				bytesRead = subjectPublicKey.Length;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				FreeKey();
				_key = null;
			}
			base.Dispose(disposing);
		}

		private void FreeKey()
		{
			if (_key != null && _key.IsValueCreated)
			{
				_key.Value?.Dispose();
			}
		}

		private static void ValidateParameters(ref RSAParameters parameters)
		{
			if (parameters.Modulus == null || parameters.Exponent == null)
			{
				throw new CryptographicException("Argument_InvalidValue");
			}
			if (!HasConsistentPrivateKey(ref parameters))
			{
				throw new CryptographicException("Argument_InvalidValue");
			}
		}

		private static bool HasConsistentPrivateKey(ref RSAParameters parameters)
		{
			if (parameters.D == null)
			{
				if (parameters.P != null || parameters.DP != null || parameters.Q != null || parameters.DQ != null || parameters.InverseQ != null)
				{
					return false;
				}
			}
			else if (parameters.P == null || parameters.DP == null || parameters.Q == null || parameters.DQ == null || parameters.InverseQ == null)
			{
				return false;
			}
			return true;
		}

		[MemberNotNull("_key")]
		private void ThrowIfDisposed()
		{
			ObjectDisposedException.ThrowIf(_key == null, this);
		}

		private SafeRsaHandle GetKey()
		{
			ThrowIfDisposed();
			SafeRsaHandle value = _key.Value;
			if (value == null || value.IsInvalid)
			{
				throw new CryptographicException("Cryptography_OpenInvalidHandle");
			}
			return value;
		}

		private static void CheckBoolReturn(int returnValue)
		{
			if (returnValue != 1)
			{
				throw new CryptographicException();
			}
		}

		private SafeRsaHandle GenerateKey()
		{
			SafeRsaHandle safeRsaHandle = global::Interop.AndroidCrypto.RsaCreate();
			bool flag = false;
			if (safeRsaHandle == null || safeRsaHandle.IsInvalid)
			{
				safeRsaHandle?.Dispose();
				throw new CryptographicException();
			}
			try
			{
				CheckBoolReturn(global::Interop.AndroidCrypto.RsaGenerateKeyEx(safeRsaHandle, KeySize));
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					safeRsaHandle.Dispose();
				}
			}
			return safeRsaHandle;
		}

		internal SafeRsaHandle DuplicateKeyHandle()
		{
			ThrowIfDisposed();
			return _key.Value.DuplicateHandle();
		}
	}
}
