namespace SkiaSharp;

public abstract class SKAbstractManagedWStream : SKWStream
{
	private static readonly SKManagedWStreamDelegates delegates;

	internal int fromNative;

	unsafe static SKAbstractManagedWStream()
	{
		delegates = new SKManagedWStreamDelegates
		{
			fWrite = DelegateProxies.SKManagedWStreamWriteProxy,
			fFlush = DelegateProxies.SKManagedWStreamFlushProxy,
			fBytesWritten = DelegateProxies.SKManagedWStreamBytesWrittenProxy,
			fDestroy = DelegateProxies.SKManagedWStreamDestroyProxy
		};
		SkiaApi.sk_managedwstream_set_procs(delegates);
	}

	protected internal abstract bool OnWrite(nint buffer, nint size);

	protected internal abstract void OnFlush();

	protected internal abstract nint OnBytesWritten();
}
