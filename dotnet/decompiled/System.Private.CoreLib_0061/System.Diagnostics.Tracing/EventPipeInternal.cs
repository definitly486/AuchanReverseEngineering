using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics.Tracing;

internal static class EventPipeInternal
{
	internal enum RuntimeCounters
	{
		ASSEMBLY_COUNT,
		EXCEPTION_COUNT,
		GC_NURSERY_SIZE_BYTES,
		GC_MAJOR_SIZE_BYTES,
		GC_LARGE_OBJECT_SIZE_BYTES,
		GC_LAST_PERCENT_TIME_IN_GC,
		JIT_IL_BYTES_JITTED,
		JIT_METHODS_JITTED,
		JIT_TICKS_IN_JIT
	}

	private struct EventPipeProviderConfigurationNative
	{
		private unsafe char* m_pProviderName;

		private ulong m_keywords;

		private uint m_loggingLevel;

		private unsafe char* m_pFilterData;

		internal unsafe static void MarshalToNative(EventPipeProviderConfiguration managed, ref EventPipeProviderConfigurationNative native)
		{
			native.m_pProviderName = (char*)Marshal.StringToCoTaskMemUni(managed.ProviderName);
			native.m_keywords = managed.Keywords;
			native.m_loggingLevel = managed.LoggingLevel;
			native.m_pFilterData = (char*)Marshal.StringToCoTaskMemUni(managed.FilterData);
		}

		internal unsafe void Release()
		{
			if (m_pProviderName != null)
			{
				Marshal.FreeCoTaskMem((nint)m_pProviderName);
			}
			if (m_pFilterData != null)
			{
				Marshal.FreeCoTaskMem((nint)m_pFilterData);
			}
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern ulong Enable(char* outputFile, EventPipeSerializationFormat format, uint circularBufferSizeInMB, EventPipeProviderConfigurationNative* providers, uint numProviders);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void Disable(ulong sessionID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint CreateProvider(string providerName, nint callbackFunc, nint callbackContext);

	internal unsafe static nint CreateProvider(string providerName, delegate* unmanaged<byte*, int, byte, long, long, Interop.Advapi32.EVENT_FILTER_DESCRIPTOR*, void*, void> callbackFunc, void* callbackContext)
	{
		return CreateProvider(providerName, (nint)callbackFunc, (nint)callbackContext);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern nint DefineEvent(nint provHandle, uint eventID, long keywords, uint eventVersion, uint level, byte* pMetadata, uint metadataLength);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern nint GetProvider(char* providerName);

	internal unsafe static nint GetProvider(string providerName)
	{
		fixed (char* providerName2 = providerName)
		{
			return GetProvider(providerName2);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void DeleteProvider(nint provHandle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int EventActivityIdControl(uint controlCode, ref Guid activityId);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern void WriteEventData(nint eventHandle, EventProvider.EventData* pEventData, uint dataCount, Guid* activityId, Guid* relatedActivityId);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern bool GetSessionInfo(ulong sessionID, EventPipeSessionInfo* pSessionInfo);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern bool GetNextEvent(ulong sessionID, EventPipeEventInstanceData* pInstance);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool SignalSession(ulong sessionID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool WaitForSessionSignal(ulong sessionID, int timeoutMs);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern ulong GetRuntimeCounterValue(RuntimeCounters counterID);

	internal unsafe static ulong Enable(string outputFile, EventPipeSerializationFormat format, uint circularBufferSizeInMB, EventPipeProviderConfiguration[] providers)
	{
		Span<EventPipeProviderConfigurationNative> span = new Span<EventPipeProviderConfigurationNative>((void*)Marshal.AllocCoTaskMem(sizeof(EventPipeProviderConfigurationNative) * providers.Length), providers.Length);
		span.Clear();
		try
		{
			for (int i = 0; i < providers.Length; i++)
			{
				EventPipeProviderConfigurationNative.MarshalToNative(providers[i], ref span[i]);
			}
			fixed (char* outputFile2 = outputFile)
			{
				fixed (EventPipeProviderConfigurationNative* providers2 = span)
				{
					return Enable(outputFile2, format, circularBufferSizeInMB, providers2, (uint)span.Length);
				}
			}
		}
		finally
		{
			for (int j = 0; j < providers.Length; j++)
			{
				span[j].Release();
			}
			fixed (EventPipeProviderConfigurationNative* ptr = span)
			{
				Marshal.FreeCoTaskMem((nint)ptr);
			}
		}
	}
}
