using System;
using Android.App;
using Android.Content;
using Android.Content.PM;

namespace Microsoft.Maui.ApplicationModel;

internal static class PlatformUtils
{
	private static int requestCode = 12000;

	internal static int NextRequestCode()
	{
		if (++requestCode >= 12999)
		{
			requestCode = 12000;
		}
		return requestCode;
	}

	internal static Intent? RegisterBroadcastReceiver(BroadcastReceiver? receiver, IntentFilter filter)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(34))
		{
			return Application.Context.RegisterReceiver(receiver, filter, ReceiverFlags.NotExported);
		}
		return Application.Context.RegisterReceiver(receiver, filter);
	}

	internal static bool IsIntentSupported(Intent intent)
	{
		Context context = Application.Context;
		if (context != null)
		{
			PackageManager packageManager = context.PackageManager;
			if (packageManager != null)
			{
				return intent.ResolveActivity(packageManager) != null;
			}
		}
		return false;
	}
}
