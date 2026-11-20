using System.Runtime.CompilerServices;

namespace System.Security.Authentication.ExtendedProtection;

public class ExtendedProtectionPolicy
{
	public ServiceNameCollection? CustomServiceNames
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public PolicyEnforcement PolicyEnforcement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public ProtectionScenario ProtectionScenario
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
