using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Net.Security;

internal abstract class SafeFreeCredentials : SafeHandle
{
	internal DateTime _expiry;

	public DateTime Expiry
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
