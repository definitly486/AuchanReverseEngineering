using System;
using Android.Runtime;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Common.Common;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common;

public class ProcessLifecycleObserver : Java.Lang.Object, IDefaultLifecycleObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly IApplicationStateManager _applicationStateManager;

	public ProcessLifecycleObserver(IApplicationStateManager applicationStateManager)
	{
		_applicationStateManager = applicationStateManager;
	}

	public void OnStart(ILifecycleOwner owner)
	{
		_applicationStateManager.OnResumedAsync().SafeFireAndForget((Action<System.Exception>)null, false);
	}

	public void OnStop(ILifecycleOwner owner)
	{
		_applicationStateManager.OnPausedAsync().SafeFireAndForget((Action<System.Exception>)null, false);
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
