using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common;

public class OnGlobalLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly View _view;

	private readonly Action<View> _onGlobalLayoutHandler;

	public OnGlobalLayoutListener(View view, Action<View> onGlobalLayoutHandler)
	{
		_view = view;
		_onGlobalLayoutHandler = onGlobalLayoutHandler;
	}

	public void OnGlobalLayout()
	{
		_onGlobalLayoutHandler?.Invoke(_view);
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
