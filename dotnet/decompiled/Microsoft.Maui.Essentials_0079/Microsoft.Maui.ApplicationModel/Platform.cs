using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;

namespace Microsoft.Maui.ApplicationModel;

public static class Platform
{
	public static Context AppContext => Application.Context;

	public static Activity? CurrentActivity => ActivityStateManager.Default.GetCurrentActivity();

	public static event EventHandler<ActivityStateChangedEventArgs>? ActivityStateChanged
	{
		add
		{
			ActivityStateManager.Default.ActivityStateChanged += value;
		}
		remove
		{
			ActivityStateManager.Default.ActivityStateChanged -= value;
		}
	}

	public static Task<Activity> WaitForActivityAsync(CancellationToken cancelToken = default(CancellationToken))
	{
		return ActivityStateManager.Default.WaitForActivityAsync(cancelToken);
	}

	public static void Init(Application application)
	{
		ActivityStateManager.Default.Init(application);
	}

	public static void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		Permissions.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	}

	public static void OnResume(Activity? activity = null)
	{
		AppActions.Current.OnResume(activity?.Intent);
	}
}
