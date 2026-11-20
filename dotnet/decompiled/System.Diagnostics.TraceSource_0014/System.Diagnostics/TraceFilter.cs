using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public abstract class TraceFilter
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool ShouldTrace(TraceEventCache cache, string source, TraceEventType eventType, int id, string formatOrMessage)
	{
		throw new NotSupportedException("Linked away");
	}
}
