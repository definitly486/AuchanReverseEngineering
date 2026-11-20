using Android.Content;
using Android.Net;

namespace Auchan.Android.Helpers;

public static class IntentHelper
{
	public static Intent GetBuildRouteIntent(double latitude, double longitude)
	{
		return new Intent("android.intent.action.VIEW", Uri.Parse($"geo:0,0?q={latitude},{longitude}"));
	}
}
