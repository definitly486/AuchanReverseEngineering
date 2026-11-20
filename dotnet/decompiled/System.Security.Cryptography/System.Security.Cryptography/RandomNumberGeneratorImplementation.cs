namespace System.Security.Cryptography;

internal sealed class RandomNumberGeneratorImplementation : RandomNumberGenerator
{
	internal static readonly RandomNumberGeneratorImplementation s_singleton = new RandomNumberGeneratorImplementation();

	private RandomNumberGeneratorImplementation()
	{
	}

	internal unsafe static void FillSpan(Span<byte> data)
	{
		if (data.Length > 0)
		{
			fixed (byte* pbBuffer = data)
			{
				GetBytes(pbBuffer, data.Length);
			}
		}
	}

	public override void GetBytes(byte[] data)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		GetBytes(new Span<byte>(data));
	}

	public override void GetBytes(byte[] data, int offset, int count)
	{
		RandomNumberGenerator.VerifyGetBytes(data, offset, count);
		GetBytes(new Span<byte>(data, offset, count));
	}

	public unsafe override void GetBytes(Span<byte> data)
	{
		if (data.Length > 0)
		{
			fixed (byte* pbBuffer = data)
			{
				GetBytes(pbBuffer, data.Length);
			}
		}
	}

	private unsafe static void GetBytes(byte* pbBuffer, int count)
	{
		if (!global::Interop.Crypto.GetRandomBytes(pbBuffer, count))
		{
			throw global::Interop.Crypto.CreateOpenSslCryptographicException();
		}
	}
}
