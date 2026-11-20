using System.Diagnostics.Tracing;

namespace System.Runtime;

public static class JitInfo
{
	public static long GetCompiledILBytes(bool currentThread = false)
	{
		if (!currentThread)
		{
			return (long)EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.JIT_IL_BYTES_JITTED);
		}
		return 0L;
	}

	public static long GetCompiledMethodCount(bool currentThread = false)
	{
		if (!currentThread)
		{
			return (long)EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.JIT_METHODS_JITTED);
		}
		return 0L;
	}

	private static long GetCompilationTimeInTicks(bool currentThread = false)
	{
		if (!currentThread)
		{
			return (long)EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.JIT_TICKS_IN_JIT);
		}
		return 0L;
	}

	public static TimeSpan GetCompilationTime(bool currentThread = false)
	{
		return TimeSpan.FromTicks(GetCompilationTimeInTicks(currentThread));
	}
}
