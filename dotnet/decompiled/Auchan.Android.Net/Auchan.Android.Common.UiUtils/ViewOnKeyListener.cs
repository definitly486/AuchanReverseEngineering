using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class ViewOnKeyListener : Java.Lang.Object, View.IOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Func<View, Keycode, KeyEvent, bool> _action;

	public ViewOnKeyListener(Func<View, Keycode, KeyEvent, bool> action)
	{
		_action = action;
	}

	public bool OnKey(View? v, Keycode keyCode, KeyEvent? e)
	{
		return _action?.Invoke(v, keyCode, e) ?? false;
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
