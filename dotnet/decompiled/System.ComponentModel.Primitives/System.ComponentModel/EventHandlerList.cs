using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public sealed class EventHandlerList
{
	public Delegate? this[object key]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
