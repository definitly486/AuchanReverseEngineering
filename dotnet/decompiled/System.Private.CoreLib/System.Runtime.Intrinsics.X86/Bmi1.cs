using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Bmi1 : X86Base
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

		public static ulong AndNot(ulong left, ulong right)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong BitFieldExtract(ulong value, byte start, byte length)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong BitFieldExtract(ulong value, ushort control)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ExtractLowestSetBit(ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong GetMaskUpToLowestSetBit(ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong ResetLowestSetBit(ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static ulong TrailingZeroCount(ulong value)
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

	public static uint AndNot(uint left, uint right)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint BitFieldExtract(uint value, byte start, byte length)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint BitFieldExtract(uint value, ushort control)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ExtractLowestSetBit(uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint GetMaskUpToLowestSetBit(uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint ResetLowestSetBit(uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint TrailingZeroCount(uint value)
	{
		throw new PlatformNotSupportedException();
	}
}
