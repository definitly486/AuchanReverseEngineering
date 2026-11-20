using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
public abstract class Crc32 : ArmBase
{
	[Intrinsic]
	public new abstract class Arm64 : ArmBase.Arm64
	{
		public new static bool IsSupported => IsSupported;

		public static uint ComputeCrc32(uint crc, ulong data)
		{
			return ComputeCrc32(crc, data);
		}

		public static uint ComputeCrc32C(uint crc, ulong data)
		{
			return ComputeCrc32C(crc, data);
		}
	}

	public new static bool IsSupported => IsSupported;

	public static uint ComputeCrc32(uint crc, byte data)
	{
		return ComputeCrc32(crc, data);
	}

	public static uint ComputeCrc32(uint crc, ushort data)
	{
		return ComputeCrc32(crc, data);
	}

	public static uint ComputeCrc32(uint crc, uint data)
	{
		return ComputeCrc32(crc, data);
	}

	public static uint ComputeCrc32C(uint crc, byte data)
	{
		return ComputeCrc32C(crc, data);
	}

	public static uint ComputeCrc32C(uint crc, ushort data)
	{
		return ComputeCrc32C(crc, data);
	}

	public static uint ComputeCrc32C(uint crc, uint data)
	{
		return ComputeCrc32C(crc, data);
	}
}
