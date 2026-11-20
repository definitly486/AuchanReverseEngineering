using System.Runtime.Versioning;

namespace System.Security.Cryptography;

public abstract class TripleDES : SymmetricAlgorithm
{
	private static readonly KeySizes[] s_legalBlockSizes = new KeySizes[1]
	{
		new KeySizes(64, 64, 0)
	};

	private static readonly KeySizes[] s_legalKeySizes = new KeySizes[1]
	{
		new KeySizes(128, 192, 64)
	};

	protected TripleDES()
	{
		KeySizeValue = 192;
		BlockSizeValue = 64;
		FeedbackSizeValue = BlockSizeValue;
		LegalBlockSizesValue = s_legalBlockSizes.CloneKeySizesArray();
		LegalKeySizesValue = s_legalKeySizes.CloneKeySizesArray();
	}

	[UnsupportedOSPlatform("browser")]
	public static TripleDES Create()
	{
		return new TripleDesImplementation();
	}
}
