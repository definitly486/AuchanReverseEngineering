using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Aes : Sse2
{
	public new abstract class X64 : Sse2.X64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}
	}

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static Vector128<byte> Decrypt(Vector128<byte> value, Vector128<byte> roundKey)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> DecryptLast(Vector128<byte> value, Vector128<byte> roundKey)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Encrypt(Vector128<byte> value, Vector128<byte> roundKey)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> EncryptLast(Vector128<byte> value, Vector128<byte> roundKey)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> InverseMixColumns(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> KeygenAssist(Vector128<byte> value, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}
}
