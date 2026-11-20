using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Security.Authentication.ExtendedProtection;

public class ServiceNameCollection : ReadOnlyCollectionBase
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(string? searchServiceName)
	{
		throw new NotSupportedException("Linked away");
	}
}
