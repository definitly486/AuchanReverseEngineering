using Android.App;
using Android.Content;

namespace Auchan.Android.SafeEntrance;

public static class SafeEntranceHelper
{
	public static void OpenEnterPinPageFromSplash(Activity context)
	{
		GetIntentAndRun(context, SafeEntranceParameter.EnterPinCodePage, isTransient: true);
	}

	public static void OpenEnterPinPageWhenEnterForeground(Activity context)
	{
		GetIntentAndRun(context, SafeEntranceParameter.EnterPinCodePage, isTransient: false);
	}

	private static void GetIntentAndRun(Context context, SafeEntranceParameter safeEntranceParameter, bool isTransient)
	{
		Intent startSafeEntranceIntet = SafeEntranceContainerActivity.GetStartSafeEntranceIntet(context, safeEntranceParameter, isTransient);
		context.StartActivity(startSafeEntranceIntet);
	}
}
