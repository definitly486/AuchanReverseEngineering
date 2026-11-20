using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.X86;

[CLSCompliant(false)]
public abstract class X86Base
{
	public abstract class X64
	{
		public static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
		public static (ulong Quotient, ulong Remainder) DivRem(ulong lower, ulong upper, ulong divisor)
		{
			throw new PlatformNotSupportedException();
		}

		[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
		public static (long Quotient, long Remainder) DivRem(ulong lower, long upper, long divisor)
		{
			throw new PlatformNotSupportedException();
		}
	}

	public static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static (int Eax, int Ebx, int Ecx, int Edx) CpuId(int functionId, int subFunctionId)
	{
		throw new PlatformNotSupportedException();
	}

	[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static (uint Quotient, uint Remainder) DivRem(uint lower, uint upper, uint divisor)
	{
		throw new PlatformNotSupportedException();
	}

	[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static (int Quotient, int Remainder) DivRem(uint lower, int upper, int divisor)
	{
		throw new PlatformNotSupportedException();
	}

	[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static (nuint Quotient, nuint Remainder) DivRem(nuint lower, nuint upper, nuint divisor)
	{
		throw new PlatformNotSupportedException();
	}

	[Experimental("SYSLIB5004", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public static (nint Quotient, nint Remainder) DivRem(nuint lower, nint upper, nint divisor)
	{
		throw new PlatformNotSupportedException();
	}

	public static void Pause()
	{
		throw new PlatformNotSupportedException();
	}
}
