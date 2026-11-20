using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class ViewOnLongClickListener : Java.Lang.Object, View.IOnLongClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<View> _action;

	public ViewOnLongClickListener(Action<View> action)
	{
		_action = action;
	}

	public bool OnLongClick(View v)
	{
		_action(v);
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
