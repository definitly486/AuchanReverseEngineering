using System;
using System.Threading;

namespace SkiaSharp;

public abstract class SKAbstractManagedStream : SKStreamAsset
{
	private static readonly SKManagedStreamDelegates delegates;

	internal int fromNative;

	unsafe static SKAbstractManagedStream()
	{
		delegates = new SKManagedStreamDelegates
		{
			fRead = DelegateProxies.SKManagedStreamReadProxy,
			fPeek = DelegateProxies.SKManagedStreamPeekProxy,
			fIsAtEnd = DelegateProxies.SKManagedStreamIsAtEndProxy,
			fHasPosition = DelegateProxies.SKManagedStreamHasPositionProxy,
			fHasLength = DelegateProxies.SKManagedStreamHasLengthProxy,
			fRewind = DelegateProxies.SKManagedStreamRewindProxy,
			fGetPosition = DelegateProxies.SKManagedStreamGetPositionProxy,
			fSeek = DelegateProxies.SKManagedStreamSeekProxy,
			fMove = DelegateProxies.SKManagedStreamMoveProxy,
			fGetLength = DelegateProxies.SKManagedStreamGetLengthProxy,
			fDuplicate = DelegateProxies.SKManagedStreamDuplicateProxy,
			fFork = DelegateProxies.SKManagedStreamForkProxy,
			fDestroy = DelegateProxies.SKManagedStreamDestroyProxy
		};
		SkiaApi.sk_managedstream_set_procs(delegates);
	}

	protected unsafe SKAbstractManagedStream(bool owns)
		: base(IntPtr.Zero, owns)
	{
		nint context = DelegateProxies.CreateUserData(this, makeWeak: true);
		Handle = SkiaApi.sk_managedstream_new((void*)context);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		if (Interlocked.CompareExchange(ref fromNative, 0, 0) == 0)
		{
			SkiaApi.sk_managedstream_destroy(Handle);
		}
	}

	protected internal abstract nint OnRead(nint buffer, nint size);

	protected internal abstract nint OnPeek(nint buffer, nint size);

	protected internal abstract bool OnIsAtEnd();

	protected internal abstract bool OnHasPosition();

	protected internal abstract bool OnHasLength();

	protected internal abstract bool OnRewind();

	protected internal abstract nint OnGetPosition();

	protected internal abstract nint OnGetLength();

	protected internal abstract bool OnSeek(nint position);

	protected internal abstract bool OnMove(int offset);

	protected internal abstract nint OnCreateNew();

	protected internal virtual nint OnFork()
	{
		nint num = OnCreateNew();
		SkiaApi.sk_stream_seek(num, SkiaApi.sk_stream_get_position(Handle));
		return num;
	}

	protected internal virtual nint OnDuplicate()
	{
		return OnCreateNew();
	}
}
