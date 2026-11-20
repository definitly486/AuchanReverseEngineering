using Android.Content;

namespace Auchan.Android.AppLinks;

public static class AppLinksHelper
{
	public static bool IsAppLinkIntent(Intent? intent)
	{
		if (intent == null)
		{
			return false;
		}
		if (intent.Action == "android.intent.action.VIEW")
		{
			return true;
		}
		return false;
	}
}
