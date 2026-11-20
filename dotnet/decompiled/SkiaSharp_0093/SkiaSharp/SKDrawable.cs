using System;
using System.Runtime.CompilerServices;

namespace SkiaSharp;

public class SKDrawable : SKObject, ISKReferenceCounted
{
	private static readonly SKManagedDrawableDelegates delegates;

	internal int fromNative;

	unsafe static SKDrawable()
	{
		delegates = new SKManagedDrawableDelegates
		{
			fDraw = DelegateProxies.SKManagedDrawableDrawProxy,
			fGetBounds = DelegateProxies.SKManagedDrawableGetBoundsProxy,
			fApproximateBytesUsed = DelegateProxies.SKManagedDrawableApproximateBytesUsedProxy,
			fMakePictureSnapshot = DelegateProxies.SKManagedDrawableMakePictureSnapshotProxy,
			fDestroy = DelegateProxies.SKManagedDrawableDestroyProxy
		};
		SkiaApi.sk_manageddrawable_set_procs(delegates);
	}

	protected internal virtual void OnDraw(SKCanvas canvas)
	{
	}

	protected internal virtual int OnGetApproximateBytesUsed()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual SKRect OnGetBounds()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual SKPicture OnSnapshot()
	{
		throw new NotSupportedException("Linked away");
	}
}
