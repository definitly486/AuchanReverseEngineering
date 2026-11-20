using System.Diagnostics.CodeAnalysis;
using Internal.Cryptography;

namespace System.Security.Cryptography;

public abstract class SymmetricAlgorithm : IDisposable
{
	protected CipherMode ModeValue;

	protected PaddingMode PaddingValue;

	protected byte[]? KeyValue;

	protected byte[]? IVValue;

	protected int BlockSizeValue;

	protected int FeedbackSizeValue;

	protected int KeySizeValue;

	[MaybeNull]
	protected KeySizes[] LegalBlockSizesValue;

	[MaybeNull]
	protected KeySizes[] LegalKeySizesValue;

	public virtual int FeedbackSize => FeedbackSizeValue;

	public virtual int BlockSize => BlockSizeValue;

	public virtual byte[] IV
	{
		get
		{
			if (IVValue == null)
			{
				GenerateIV();
			}
			return IVValue.CloneByteArray();
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			if (value.Length != BlockSize / 8)
			{
				throw new CryptographicException("Cryptography_InvalidIVSize");
			}
			IVValue = value.CloneByteArray();
		}
	}

	public virtual int KeySize
	{
		get
		{
			return KeySizeValue;
		}
		set
		{
			if (!ValidKeySize(value))
			{
				throw new CryptographicException("Cryptography_InvalidKeySize");
			}
			KeySizeValue = value;
			KeyValue = null;
		}
	}

	public virtual KeySizes[] LegalKeySizes => (KeySizes[])LegalKeySizesValue.Clone();

	public virtual CipherMode Mode => ModeValue;

	public virtual PaddingMode Padding => PaddingValue;

	protected SymmetricAlgorithm()
	{
		ModeValue = CipherMode.CBC;
		PaddingValue = PaddingMode.PKCS7;
	}

	public abstract ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[]? rgbIV);

	public abstract ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[]? rgbIV);

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (KeyValue != null)
			{
				Array.Clear(KeyValue);
				KeyValue = null;
			}
			if (IVValue != null)
			{
				Array.Clear(IVValue);
				IVValue = null;
			}
		}
	}

	public abstract void GenerateIV();

	public bool ValidKeySize(int bitLength)
	{
		KeySizes[] legalKeySizes = LegalKeySizes;
		if (legalKeySizes == null)
		{
			return false;
		}
		return bitLength.IsLegalSize(legalKeySizes);
	}
}
