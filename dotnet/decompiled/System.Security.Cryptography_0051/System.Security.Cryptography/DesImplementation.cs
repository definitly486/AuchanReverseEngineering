using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class DesImplementation : DES
{
	public DesImplementation()
	{
		FeedbackSizeValue = 8;
	}

	public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
	{
		return CreateTransform(rgbKey, rgbIV.CloneByteArray(), encrypting: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
	{
		return CreateTransform(rgbKey, rgbIV.CloneByteArray(), encrypting: true);
	}

	public override void GenerateIV()
	{
		IV = RandomNumberGenerator.GetBytes(BlockSize / 8);
	}

	private UniversalCryptoTransform CreateTransform(byte[] rgbKey, byte[] rgbIV, bool encrypting)
	{
		ArgumentNullException.ThrowIfNull(rgbKey, "rgbKey");
		long num = (long)rgbKey.Length * 8L;
		if (num > int.MaxValue || !((int)num).IsLegalSize(LegalKeySizes))
		{
			throw new ArgumentException("Cryptography_InvalidKeySize", "rgbKey");
		}
		if (DES.IsWeakKey(rgbKey))
		{
			throw new CryptographicException("Cryptography_InvalidKey_Weak", "DES");
		}
		if (DES.IsSemiWeakKey(rgbKey))
		{
			throw new CryptographicException("Cryptography_InvalidKey_SemiWeak", "DES");
		}
		if (rgbIV != null && (long)rgbIV.Length * 8L != BlockSize)
		{
			throw new ArgumentException("Cryptography_InvalidIVSize", "rgbIV");
		}
		if (Mode == CipherMode.CFB)
		{
			ValidateCFBFeedbackSize(FeedbackSize);
		}
		return CreateTransformCore(Mode, Padding, rgbKey, rgbIV, BlockSize / 8, FeedbackSize / 8, this.GetPaddingSize(Mode, FeedbackSize), encrypting);
	}

	private static void ValidateCFBFeedbackSize(int feedback)
	{
		if (feedback != 8)
		{
			throw new CryptographicException(System.SR.Format("Cryptography_CipherModeFeedbackNotSupported", feedback, CipherMode.CFB));
		}
	}

	private static UniversalCryptoTransform CreateTransformCore(CipherMode cipherMode, PaddingMode paddingMode, byte[] key, byte[] iv, int blockSize, int feedbackSize, int paddingSize, bool encrypting)
	{
		BasicSymmetricCipher cipher = new OpenSslCipher(GetAlgorithm(cipherMode, feedbackSize), cipherMode, blockSize, paddingSize, key, iv, encrypting);
		return UniversalCryptoTransform.Create(paddingMode, cipher, encrypting);
	}

	private static nint GetAlgorithm(CipherMode cipherMode, int feedbackSize)
	{
		switch (cipherMode)
		{
		case CipherMode.CBC:
			return global::Interop.Crypto.EvpDesCbc();
		case CipherMode.ECB:
			return global::Interop.Crypto.EvpDesEcb();
		case CipherMode.CFB:
			if (feedbackSize == 1)
			{
				return global::Interop.Crypto.EvpDesCfb8();
			}
			break;
		}
		throw new NotSupportedException();
	}
}
