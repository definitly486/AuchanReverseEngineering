using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
public abstract class Aes : ArmBase
{
	[Intrinsic]
	public new abstract class Arm64 : ArmBase.Arm64
	{
		public new static bool IsSupported => IsSupported;
	}

	public new static bool IsSupported => IsSupported;

	public static Vector128<byte> Decrypt(Vector128<byte> value, Vector128<byte> roundKey)
	{
		return Decrypt(value, roundKey);
	}

	public static Vector128<byte> Encrypt(Vector128<byte> value, Vector128<byte> roundKey)
	{
		return Encrypt(value, roundKey);
	}

	public static Vector128<byte> InverseMixColumns(Vector128<byte> value)
	{
		return InverseMixColumns(value);
	}

	public static Vector128<byte> MixColumns(Vector128<byte> value)
	{
		return MixColumns(value);
	}

	public static Vector128<long> PolynomialMultiplyWideningLower(Vector64<long> left, Vector64<long> right)
	{
		return PolynomialMultiplyWideningLower(left, right);
	}

	public static Vector128<ulong> PolynomialMultiplyWideningLower(Vector64<ulong> left, Vector64<ulong> right)
	{
		return PolynomialMultiplyWideningLower(left, right);
	}

	public static Vector128<long> PolynomialMultiplyWideningUpper(Vector128<long> left, Vector128<long> right)
	{
		return PolynomialMultiplyWideningUpper(left, right);
	}

	public static Vector128<ulong> PolynomialMultiplyWideningUpper(Vector128<ulong> left, Vector128<ulong> right)
	{
		return PolynomialMultiplyWideningUpper(left, right);
	}
}
