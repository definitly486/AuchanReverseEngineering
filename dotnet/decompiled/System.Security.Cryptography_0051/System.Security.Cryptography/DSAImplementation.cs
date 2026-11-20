using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

internal static class DSAImplementation
{
	public sealed class DSAAndroid : DSA
	{
		private Lazy<SafeDsaHandle> _key;

		private static readonly KeySizes[] s_legalKeySizes = new KeySizes[1]
		{
			new KeySizes(1024, 3072, 1024)
		};

		public override int KeySize
		{
			set
			{
				if (KeySize != value)
				{
					ThrowIfDisposed();
					base.KeySize = value;
					FreeKey();
					_key = new Lazy<SafeDsaHandle>(GenerateKey);
				}
			}
		}

		public override KeySizes[] LegalKeySizes => base.LegalKeySizes;

		public DSAAndroid()
			: this(2048)
		{
		}

		public DSAAndroid(int keySize)
		{
			LegalKeySizesValue = s_legalKeySizes;
			base.KeySize = keySize;
			_key = new Lazy<SafeDsaHandle>(GenerateKey);
		}

		internal DSAAndroid(SafeDsaHandle key)
		{
			SetKey(key.DuplicateHandle());
		}

		private void ForceSetKeySize(int newKeySize)
		{
			KeySizeValue = newKeySize;
		}

		public override DSAParameters ExportParameters(bool includePrivateParameters)
		{
			DSAParameters result = global::Interop.AndroidCrypto.ExportDsaParameters(GetKey(), includePrivateParameters);
			if (result.X != null != includePrivateParameters)
			{
				throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
			}
			return result;
		}

		public override void ImportParameters(DSAParameters parameters)
		{
			if (parameters.P == null || parameters.Q == null || parameters.G == null || parameters.Y == null)
			{
				throw new ArgumentException("Cryptography_InvalidDsaParameters_MissingFields");
			}
			if (parameters.J != null && parameters.J.Length >= parameters.P.Length)
			{
				throw new ArgumentException("Cryptography_InvalidDsaParameters_MismatchedPJ");
			}
			bool num = parameters.X != null;
			int num2 = parameters.P.Length;
			if (parameters.G.Length != num2 || parameters.Y.Length != num2)
			{
				throw new ArgumentException("Cryptography_InvalidDsaParameters_MismatchedPGY");
			}
			if (num && parameters.X.Length != parameters.Q.Length)
			{
				throw new ArgumentException("Cryptography_InvalidDsaParameters_MismatchedQX");
			}
			ThrowIfDisposed();
			if (!global::Interop.AndroidCrypto.DsaKeyCreateByExplicitParameters(out var dsa, parameters.P, parameters.P.Length, parameters.Q, parameters.Q.Length, parameters.G, parameters.G.Length, parameters.Y, parameters.Y.Length, parameters.X, (parameters.X != null) ? parameters.X.Length : 0))
			{
				throw new CryptographicException();
			}
			SetKey(dsa);
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

		private static void CheckInvalidKey([NotNull] SafeDsaHandle key)
		{
			if (key == null || key.IsInvalid)
			{
				throw new CryptographicException("Cryptography_OpenInvalidHandle");
			}
		}

		private SafeDsaHandle GenerateKey()
		{
			if (!global::Interop.AndroidCrypto.DsaGenerateKey(out var dsa, KeySize))
			{
				throw new CryptographicException();
			}
			return dsa;
		}

		[MemberNotNull("_key")]
		private void ThrowIfDisposed()
		{
			ObjectDisposedException.ThrowIf(_key == null, this);
		}

		private SafeDsaHandle GetKey()
		{
			ThrowIfDisposed();
			SafeDsaHandle value = _key.Value;
			CheckInvalidKey(value);
			return value;
		}

		[MemberNotNull("_key")]
		private void SetKey(SafeDsaHandle newKey)
		{
			ForceSetKeySize(8 * global::Interop.AndroidCrypto.DsaKeySize(newKey));
			FreeKey();
			_key = new Lazy<SafeDsaHandle>(newKey);
		}

		internal SafeDsaHandle DuplicateKeyHandle()
		{
			return GetKey().DuplicateHandle();
		}
	}
}
