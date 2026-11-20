using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Diagnostics;

public sealed class Trace
{
	[CompilerGenerated]
	private static CorrelationManager _003CCorrelationManager_003Ek__BackingField;

	public static CorrelationManager CorrelationManager => _003CCorrelationManager_003Ek__BackingField ?? Interlocked.CompareExchange(ref _003CCorrelationManager_003Ek__BackingField, new CorrelationManager(), null) ?? _003CCorrelationManager_003Ek__BackingField;

	public static TraceListenerCollection Listeners => TraceInternal.Listeners;

	public static bool AutoFlush => TraceInternal.AutoFlush;
}
