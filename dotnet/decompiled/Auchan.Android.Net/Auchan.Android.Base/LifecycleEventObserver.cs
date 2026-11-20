using System;
using Android.Runtime;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Base;

public class LifecycleEventObserver : Java.Lang.Object, ILifecycleEventObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	public event Action<ILifecycleOwner, Lifecycle.Event> StateChanged = delegate
	{
	};

	public void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e)
	{
		this.StateChanged(source, e);
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
