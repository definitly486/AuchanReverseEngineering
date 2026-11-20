using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class TripleDesImplementation : TripleDES
{
	public TripleDesImplementation()
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
		if (rgbIV != null && (long)rgbIV.Length * 8L != BlockSize)
		{
			throw new ArgumentException("Cryptography_InvalidIVSize", "rgbIV");
		}
		if (rgbKey.Length == 16)
		{
			byte[] array = new byte[24];
			Array.Copy(rgbKey, array, 16);
			Array.Copy(rgbKey, 0, array, 16, 8);
			rgbKey = array;
		}
		if (Mode == CipherMode.CFB)
		{
			ValidateCFBFeedbackSize(FeedbackSize);
		}
		return CreateTransformCore(Mode, Padding, rgbKey, rgbIV, BlockSize / 8, this.GetPaddingSize(Mode, FeedbackSize), FeedbackSize / 8, encrypting);
	}

	private static void ValidateCFBFeedbackSize(int feedback)
	{
		if (feedback != 8 && feedback != 64)
		{
			throw new CryptographicException(System.SR.Format("Cryptography_CipherModeFeedbackNotSupported", feedback, CipherMode.CFB));
		}
	}

	private static UniversalCryptoTransform CreateTransformCore(CipherMode cipherMode, PaddingMode paddingMode, byte[] key, byte[] iv, int blockSize, int paddingSize, int feedbackSize, bool encrypting)
	{
		BasicSymmetricCipher cipher = new OpenSslCipher(GetAlgorithm(cipherMode, feedbackSize), cipherMode, blockSize, paddingSize, key, iv, encrypting);
		return UniversalCryptoTransform.Create(paddingMode, cipher, encrypting);
	}

	private static nint GetAlgorithm(CipherMode cipherMode, int feedbackSizeInBytes)
	{
		switch (cipherMode)
		{
		case CipherMode.CBC:
			return global::Interop.Crypto.EvpDes3Cbc();
		case CipherMode.ECB:
			return global::Interop.Crypto.EvpDes3Ecb();
		case CipherMode.CFB:
			switch (feedbackSizeInBytes)
			{
			case 1:
				return global::Interop.Crypto.EvpDes3Cfb8();
			case 8:
				return global::Interop.Crypto.EvpDes3Cfb64();
			}
			break;
		}
		throw new NotSupportedException();
	}
}
