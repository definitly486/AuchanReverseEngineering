using System;
using Android.Runtime;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common;

public class LifecycleCallback : Java.Lang.Object, ILifecycleEventObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private Action _callback;

	private Lifecycle.Event _targetEvent;

	public LifecycleCallback(Action callback, Lifecycle.Event targetEvent)
	{
		_callback = callback;
		_targetEvent = targetEvent;
	}

	public void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e)
	{
		if (e == _targetEvent)
		{
			_callback();
			Cleanup(source);
		}
		else if (e == Lifecycle.Event.OnDestroy)
		{
			Cleanup(source);
		}
	}

	private void Cleanup(ILifecycleOwner owner)
	{
		owner.Lifecycle.RemoveObserver(this);
		_callback = null;
		_targetEvent = null;
		Dispose();
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
