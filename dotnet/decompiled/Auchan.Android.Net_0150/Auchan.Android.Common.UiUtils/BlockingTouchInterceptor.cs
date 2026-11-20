using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class BlockingTouchInterceptor : Java.Lang.Object, View.IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
{
	public bool OnTouch(View? v, MotionEvent? e)
	{
		v.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
		v.OnTouchEvent(e);
		return true;
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
