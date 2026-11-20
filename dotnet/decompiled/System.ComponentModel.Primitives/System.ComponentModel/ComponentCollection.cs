using System.Collections;
using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class ComponentCollection : ReadOnlyCollectionBase
{
	public virtual IComponent? this[string? name]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public virtual IComponent? this[int index]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
