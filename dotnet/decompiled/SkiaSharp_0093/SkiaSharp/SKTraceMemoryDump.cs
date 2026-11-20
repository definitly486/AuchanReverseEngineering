namespace SkiaSharp;

public class SKTraceMemoryDump : SKObject, ISKSkipObjectRegistration
{
	private static readonly SKManagedTraceMemoryDumpDelegates delegates;

	unsafe static SKTraceMemoryDump()
	{
		delegates = new SKManagedTraceMemoryDumpDelegates
		{
			fDumpNumericValue = DelegateProxies.SKManagedTraceMemoryDumpDumpNumericValueProxy,
			fDumpStringValue = DelegateProxies.SKManagedTraceMemoryDumpDumpStringValueProxy
		};
		SkiaApi.sk_managedtracememorydump_set_procs(delegates);
	}

	protected internal virtual void OnDumpNumericValue(string dumpName, string valueName, string units, ulong value)
	{
	}

	protected internal virtual void OnDumpStringValue(string dumpName, string valueName, string value)
	{
	}
}
