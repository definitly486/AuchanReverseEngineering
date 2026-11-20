using System;
using Android.Content;
using Auchan.Android.Helpers;

namespace Auchan.Android.PushNotifications;

[BroadcastReceiver(Enabled = true, Exported = false)]
public class NotificationIntentReceiver : BroadcastReceiver
{
	public override void OnReceive(Context context, Intent intent)
	{
		if (!OperatingSystem.IsAndroidVersionAtLeast(31))
		{
			context.SendBroadcast(new Intent("android.intent.action.CLOSE_SYSTEM_DIALOGS"));
		}
		Type activeOrLaunchActivity = ActivityHelper.GetActiveOrLaunchActivity();
		intent.SetClass(context, activeOrLaunchActivity);
		intent.SetFlags(ActivityFlags.NewTask);
		context.StartActivity(intent);
	}
}
