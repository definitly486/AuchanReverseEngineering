using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class Sse42 : Sse41
{
	public new abstract class X64 : Sse41.X64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static ulong Crc32(ulong crc, ulong data)
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

	public static Vector128<long> CompareGreaterThan(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint Crc32(uint crc, byte data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint Crc32(uint crc, ushort data)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint Crc32(uint crc, uint data)
	{
		throw new PlatformNotSupportedException();
	}
}
