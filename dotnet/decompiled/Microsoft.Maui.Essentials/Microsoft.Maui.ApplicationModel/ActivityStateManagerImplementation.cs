using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;

namespace Microsoft.Maui.ApplicationModel;

internal class ActivityStateManagerImplementation : IActivityStateManager
{
	private ActivityLifecycleContextListener? lifecycleListener;

	public event EventHandler<ActivityStateChangedEventArgs>? ActivityStateChanged;

	public Activity? GetCurrentActivity()
	{
		return lifecycleListener?.Activity;
	}

	public void Init(Application application)
	{
		lifecycleListener = new ActivityLifecycleContextListener(OnActivityStateChanged);
		application.RegisterActivityLifecycleCallbacks(lifecycleListener);
	}

	public async Task<Activity> WaitForActivityAsync(CancellationToken cancelToken = default(CancellationToken))
	{
		Activity currentActivity = GetCurrentActivity();
		if (currentActivity != null)
		{
			return currentActivity;
		}
		TaskCompletionSource<Activity> tcs = new TaskCompletionSource<Activity>();
		try
		{
			using (cancelToken.Register(delegate
			{
				tcs.TrySetCanceled();
			}))
			{
				ActivityStateChanged += handler;
				return await tcs.Task.ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		finally
		{
			ActivityStateChanged -= handler;
		}
		void handler(object? sender, ActivityStateChangedEventArgs e)
		{
			if (e.State == ActivityState.Created || e.State == ActivityState.Resumed)
			{
				tcs.TrySetResult(e.Activity);
			}
		}
	}

	private void OnActivityStateChanged(Activity activity, ActivityState ev)
	{
		this.ActivityStateChanged?.Invoke(null, new ActivityStateChangedEventArgs(activity, ev));
	}
}
