using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

internal class ViewOnTouchListener : Java.Lang.Object, View.IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
{
	private Func<View, MotionEvent, bool> _callback;

	public ViewOnTouchListener(Func<View, MotionEvent, bool> callback)
	{
		_callback = callback;
	}

	public bool OnTouch(View v, MotionEvent e)
	{
		return _callback(v, e);
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
