using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
public abstract class Sha256 : ArmBase
{
	[Intrinsic]
	public new abstract class Arm64 : ArmBase.Arm64
	{
		public new static bool IsSupported => IsSupported;
	}

	public new static bool IsSupported => IsSupported;

	public static Vector128<uint> HashUpdate1(Vector128<uint> hash_abcd, Vector128<uint> hash_efgh, Vector128<uint> wk)
	{
		return HashUpdate1(hash_abcd, hash_efgh, wk);
	}

	public static Vector128<uint> HashUpdate2(Vector128<uint> hash_efgh, Vector128<uint> hash_abcd, Vector128<uint> wk)
	{
		return HashUpdate2(hash_efgh, hash_abcd, wk);
	}

	public static Vector128<uint> ScheduleUpdate0(Vector128<uint> w0_3, Vector128<uint> w4_7)
	{
		return ScheduleUpdate0(w0_3, w4_7);
	}

	public static Vector128<uint> ScheduleUpdate1(Vector128<uint> w0_3, Vector128<uint> w8_11, Vector128<uint> w12_15)
	{
		return ScheduleUpdate1(w0_3, w8_11, w12_15);
	}
}
