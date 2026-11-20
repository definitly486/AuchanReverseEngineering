using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class AesImplementation : Aes
{
	private FixedMemoryKeyBox _keyBox;

	public override int KeySize
	{
		get
		{
			return base.KeySize;
		}
		set
		{
			base.KeySize = value;
			_keyBox?.Dispose();
			_keyBox = null;
		}
	}

	public sealed override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
	{
		return CreateTransform(rgbKey, rgbIV.CloneByteArray(), encrypting: false);
	}

	public sealed override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
	{
		return CreateTransform(rgbKey, rgbIV.CloneByteArray(), encrypting: true);
	}

	public sealed override void GenerateIV()
	{
		IV = RandomNumberGenerator.GetBytes(BlockSize / 8);
	}

	protected sealed override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_keyBox?.Dispose();
			_keyBox = null;
		}
		base.Dispose(disposing);
	}

	private UniversalCryptoTransform CreateTransform(byte[] rgbKey, byte[] rgbIV, bool encrypting)
	{
		ArgumentNullException.ThrowIfNull(rgbKey, "rgbKey");
		return CreateTransform(new ReadOnlySpan<byte>(rgbKey), rgbIV, encrypting);
	}

	private UniversalCryptoTransform CreateTransform(ReadOnlySpan<byte> rgbKey, byte[] rgbIV, bool encrypting)
	{
		long num = (long)rgbKey.Length * 8L;
		if (num > int.MaxValue || !((int)num).IsLegalSize(LegalKeySizes))
		{
			throw new ArgumentException("Cryptography_InvalidKeySize", "rgbKey");
		}
		if (rgbIV != null && (long)rgbIV.Length * 8L != BlockSize)
		{
			throw new ArgumentException("Cryptography_InvalidIVSize", "rgbIV");
		}
		if (Mode == CipherMode.CFB)
		{
			ValidateCFBFeedbackSize(FeedbackSize);
		}
		return CreateTransformCore(Mode, Padding, rgbKey, rgbIV, BlockSize / 8, this.GetPaddingSize(Mode, FeedbackSize), FeedbackSize / 8, encrypting);
	}

	private static void ValidateCFBFeedbackSize(int feedback)
	{
		if (feedback != 8 && feedback != 128)
		{
			throw new CryptographicException(System.SR.Format("Cryptography_CipherModeFeedbackNotSupported", feedback, CipherMode.CFB));
		}
	}

	private static UniversalCryptoTransform CreateTransformCore(CipherMode cipherMode, PaddingMode paddingMode, ReadOnlySpan<byte> key, byte[] iv, int blockSize, int paddingSize, int feedback, bool encrypting)
	{
		BasicSymmetricCipher cipher = new OpenSslCipher(GetAlgorithm(key.Length * 8, feedback * 8, cipherMode), cipherMode, blockSize, paddingSize, key, iv, encrypting);
		return UniversalCryptoTransform.Create(paddingMode, cipher, encrypting);
	}

	private static nint GetAlgorithm(int keySize, int feedback, CipherMode cipherMode)
	{
		switch (keySize)
		{
		case 128:
			switch (cipherMode)
			{
			case CipherMode.CBC:
				return global::Interop.Crypto.EvpAes128Cbc();
			case CipherMode.ECB:
				return global::Interop.Crypto.EvpAes128Ecb();
			case CipherMode.CFB:
				switch (feedback)
				{
				case 8:
					return global::Interop.Crypto.EvpAes128Cfb8();
				case 128:
					return global::Interop.Crypto.EvpAes128Cfb128();
				}
				break;
			}
			break;
		case 192:
			switch (cipherMode)
			{
			case CipherMode.CBC:
				return global::Interop.Crypto.EvpAes192Cbc();
			case CipherMode.ECB:
				return global::Interop.Crypto.EvpAes192Ecb();
			case CipherMode.CFB:
				switch (feedback)
				{
				case 8:
					return global::Interop.Crypto.EvpAes192Cfb8();
				case 128:
					return global::Interop.Crypto.EvpAes192Cfb128();
				}
				break;
			}
			break;
		case 256:
			switch (cipherMode)
			{
			case CipherMode.CBC:
				return global::Interop.Crypto.EvpAes256Cbc();
			case CipherMode.ECB:
				return global::Interop.Crypto.EvpAes256Ecb();
			case CipherMode.CFB:
				switch (feedback)
				{
				case 8:
					return global::Interop.Crypto.EvpAes256Cfb8();
				case 128:
					return global::Interop.Crypto.EvpAes256Cfb128();
				}
				break;
			}
			break;
		}
		throw (keySize == 128 || keySize == 192 || keySize == 256) ? ((SystemException)new NotSupportedException()) : ((SystemException)new CryptographicException("Cryptography_InvalidKeySize"));
	}
}
