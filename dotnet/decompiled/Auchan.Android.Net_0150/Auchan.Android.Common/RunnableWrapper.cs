using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common;

public class RunnableWrapper : Java.Lang.Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action _callback;

	public RunnableWrapper(Action callback)
	{
		_callback = callback;
	}

	public void Run()
	{
		_callback();
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
