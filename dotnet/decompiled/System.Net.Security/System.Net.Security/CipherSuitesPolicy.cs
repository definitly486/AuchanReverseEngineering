using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Net.Security;

[UnsupportedOSPlatform("windows")]
[UnsupportedOSPlatform("android")]
public sealed class CipherSuitesPolicy
{
	[CompilerGenerated]
	private sealed class _003Cget_AllowedCipherSuites_003Ed__5
	{
	}

	[CLSCompliant(false)]
	public IEnumerable<TlsCipherSuite> AllowedCipherSuites
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_AllowedCipherSuites_003Ed__5))]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
