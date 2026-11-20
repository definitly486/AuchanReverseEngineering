using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class ViewOnClickListener : Java.Lang.Object, View.IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<View> _action;

	public ViewOnClickListener(Action<View> action)
	{
		_action = action;
	}

	public ViewOnClickListener(Action action)
	{
		_action = delegate
		{
			action();
		};
	}

	public void OnClick(View v)
	{
		_action(v);
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
