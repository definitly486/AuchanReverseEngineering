using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Pclmulqdq : Sse2
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

	public abstract class V256
	{
		public static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector256<long> CarrylessMultiply(Vector256<long> left, Vector256<long> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector256<ulong> CarrylessMultiply(Vector256<ulong> left, Vector256<ulong> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}
	}

	public abstract class V512
	{
		public static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector512<long> CarrylessMultiply(Vector512<long> left, Vector512<long> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector512<ulong> CarrylessMultiply(Vector512<ulong> left, Vector512<ulong> right, [ConstantExpected] byte control)
		{
			throw new PlatformNotSupportedException();
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

	public static Vector128<long> CarrylessMultiply(Vector128<long> left, Vector128<long> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> CarrylessMultiply(Vector128<ulong> left, Vector128<ulong> right, [ConstantExpected] byte control)
	{
		throw new PlatformNotSupportedException();
	}
}
