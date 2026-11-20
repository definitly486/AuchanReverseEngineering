using Android.Content;

namespace Auchan.Android.Helpers;

public static class GooglePlayHelper
{
	public static bool PlayServicesAvailable(Context context, out string errorMessage)
	{
		errorMessage = "Not available";
		return false;
	}
}
