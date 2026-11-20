using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class X86Serialize : X86Base
{
	[Intrinsic]
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
	}

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static void Serialize()
	{
		throw new PlatformNotSupportedException();
	}
}
