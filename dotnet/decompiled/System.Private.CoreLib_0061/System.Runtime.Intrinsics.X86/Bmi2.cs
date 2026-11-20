using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Bmi2 : X86Base
{
	public new abstract class X64 : X86Base.X64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static ulong ZeroHighBits(ulong value, ulong index)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong MultiplyNoFlags(ulong left, ulong right)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static ulong MultiplyNoFlags(ulong left, ulong right, ulong* low)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ParallelBitDeposit(ulong value, ulong mask)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ParallelBitExtract(ulong value, ulong mask)
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

	public static uint ZeroHighBits(uint value, uint index)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint MultiplyNoFlags(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static uint MultiplyNoFlags(uint left, uint right, uint* low)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ParallelBitDeposit(uint value, uint mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ParallelBitExtract(uint value, uint mask)
	{
		throw new PlatformNotSupportedException();
	}
}
