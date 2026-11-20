using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Request;
using Bumptech.Glide.Request.Target;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class GlideLoadingListener : Java.Lang.Object, IRequestListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<BitmapDrawable> _onSuccess;

	private readonly Action<GlideException> _onFail;

	public GlideLoadingListener(Action<BitmapDrawable> onSuccess, Action<GlideException>? onFail = null)
	{
		_onSuccess = onSuccess;
		_onFail = onFail;
	}

	public bool OnLoadFailed(GlideException p0, Java.Lang.Object p1, ITarget p2, bool p3)
	{
		_onFail?.Invoke(p0);
		return false;
	}

	public bool OnResourceReady(Java.Lang.Object p0, Java.Lang.Object p1, ITarget p2, DataSource p3, bool p4)
	{
		_onSuccess?.Invoke(p0 as BitmapDrawable);
		return false;
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
