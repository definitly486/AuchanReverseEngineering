using System.Runtime.Versioning;

namespace System.Security.Cryptography;

public abstract class Aes : SymmetricAlgorithm
{
	private static readonly KeySizes[] s_legalBlockSizes = new KeySizes[1]
	{
		new KeySizes(128, 128, 0)
	};

	private static readonly KeySizes[] s_legalKeySizes = new KeySizes[1]
	{
		new KeySizes(128, 256, 64)
	};

	protected Aes()
	{
		LegalBlockSizesValue = s_legalBlockSizes.CloneKeySizesArray();
		LegalKeySizesValue = s_legalKeySizes.CloneKeySizesArray();
		BlockSizeValue = 128;
		FeedbackSizeValue = 8;
		KeySizeValue = 256;
		ModeValue = CipherMode.CBC;
	}

	[UnsupportedOSPlatform("browser")]
	public static Aes Create()
	{
		return new AesImplementation();
	}
}
