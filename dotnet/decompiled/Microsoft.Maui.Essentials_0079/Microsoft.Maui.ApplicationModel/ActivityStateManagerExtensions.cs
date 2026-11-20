using System;
using Android.App;

namespace Microsoft.Maui.ApplicationModel;

internal static class ActivityStateManagerExtensions
{
	public static Activity? GetCurrentActivity(this IActivityStateManager manager, bool throwOnNull)
	{
		Activity currentActivity = manager.GetCurrentActivity();
		if (throwOnNull && currentActivity == null)
		{
			throw new NullReferenceException("The current Activity cannot be detected. Ensure that you have called Init in your Activity or Application class.");
		}
		return currentActivity;
	}
}
