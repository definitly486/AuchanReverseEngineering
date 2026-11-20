using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("mono/java/lang/Runnable")]
public sealed class Runnable : Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
{
	private Action handler;

	public Runnable(Action handler)
		: base(JNIEnv.StartCreateInstance("mono/java/lang/Runnable", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		if (handler == null)
		{
			Dispose();
			throw new ArgumentNullException("handler");
		}
		this.handler = handler;
	}

	public void Run()
	{
		handler();
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
