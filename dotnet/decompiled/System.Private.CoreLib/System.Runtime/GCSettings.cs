namespace System.Runtime;

public static class GCSettings
{
	private enum SetLatencyModeStatus
	{
		Succeeded,
		NoGCInProgress
	}

	public static bool IsServerGC => false;

	public static GCLatencyMode LatencyMode
	{
		get
		{
			return GCLatencyMode.Batch;
		}
		set
		{
			if (value < GCLatencyMode.Batch || value > GCLatencyMode.SustainedLowLatency)
			{
				ThrowHelper.ArgumentOutOfRangeException_Enum_Value();
			}
			if (SetGCLatencyMode(value) == SetLatencyModeStatus.NoGCInProgress)
			{
				throw new InvalidOperationException("InvalidOperation_SetLatencyModeNoGC");
			}
		}
	}

	public static GCLargeObjectHeapCompactionMode LargeObjectHeapCompactionMode
	{
		get
		{
			return GCLargeObjectHeapCompactionMode.Default;
		}
		set
		{
			if (value < GCLargeObjectHeapCompactionMode.Default || value > GCLargeObjectHeapCompactionMode.CompactOnce)
			{
				ThrowHelper.ArgumentOutOfRangeException_Enum_Value();
			}
			SetLOHCompactionMode(value);
		}
	}

	private static SetLatencyModeStatus SetGCLatencyMode(GCLatencyMode newLatencyMode)
	{
		if (newLatencyMode != GCLatencyMode.Batch)
		{
			throw new PlatformNotSupportedException();
		}
		return SetLatencyModeStatus.Succeeded;
	}

	private static void SetLOHCompactionMode(GCLargeObjectHeapCompactionMode newLOHCompactionMode)
	{
		if (newLOHCompactionMode != GCLargeObjectHeapCompactionMode.Default)
		{
			throw new PlatformNotSupportedException();
		}
	}
}
