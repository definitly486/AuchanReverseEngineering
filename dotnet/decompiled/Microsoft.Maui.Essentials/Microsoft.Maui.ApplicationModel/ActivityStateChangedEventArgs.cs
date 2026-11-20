using System;
using Android.App;

namespace Microsoft.Maui.ApplicationModel;

public class ActivityStateChangedEventArgs : EventArgs
{
	public ActivityState State { get; }

	public Activity Activity { get; }

	internal ActivityStateChangedEventArgs(Activity activity, ActivityState ev)
	{
		State = ev;
		Activity = activity;
	}
}
