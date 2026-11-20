using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Microsoft.Maui.ApplicationModel;

internal class ActivityLifecycleContextListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<Activity, ActivityState> _onActivityStateChanged;

	private readonly WeakReference<Activity?> _currentActivity = new WeakReference<Activity>(null);

	public Context Context => Activity ?? Application.Context;

	public Activity? Activity
	{
		get
		{
			if (!_currentActivity.TryGetTarget(out Activity target))
			{
				return null;
			}
			return target;
		}
		set
		{
			_currentActivity.SetTarget(value);
		}
	}

	public ActivityLifecycleContextListener(Action<Activity, ActivityState> onActivityStateChanged)
	{
		_onActivityStateChanged = onActivityStateChanged;
	}

	void Application.IActivityLifecycleCallbacks.OnActivityCreated(Activity activity, Bundle? savedInstanceState)
	{
		Activity = activity;
		_onActivityStateChanged(activity, ActivityState.Created);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityDestroyed(Activity activity)
	{
		_onActivityStateChanged(activity, ActivityState.Destroyed);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityPaused(Activity activity)
	{
		Activity = activity;
		_onActivityStateChanged(activity, ActivityState.Paused);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityResumed(Activity activity)
	{
		Activity = activity;
		_onActivityStateChanged(activity, ActivityState.Resumed);
	}

	void Application.IActivityLifecycleCallbacks.OnActivitySaveInstanceState(Activity activity, Bundle outState)
	{
		_onActivityStateChanged(activity, ActivityState.SaveInstanceState);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityStarted(Activity activity)
	{
		_onActivityStateChanged(activity, ActivityState.Started);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityStopped(Activity activity)
	{
		_onActivityStateChanged(activity, ActivityState.Stopped);
	}
}
