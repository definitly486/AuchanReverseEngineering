using Android.App;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.LoyaltyProgram;

public static class LoyaltyHelper
{
	public static void GoToProfile(Activity activity)
	{
		GoToTab(activity, 2131297644);
	}

	public static void GoToHome(Activity activity)
	{
		GoToTab(activity, 2131297642);
	}

	private static void GoToTab(Activity activity, int tab)
	{
		Platform.ActivityStateChanged += activityAppearanceCallback;
		activity.Finish();
		void activityAppearanceCallback(object? o, ActivityStateChangedEventArgs e)
		{
			if (e.Activity is MainActivity activity2 && e.State == ActivityState.Resumed)
			{
				GoToProfile(activity2, tab);
				Platform.ActivityStateChanged -= activityAppearanceCallback;
			}
		}
	}

	private static void GoToProfile(MainActivity activity, int tab)
	{
		BottomNavigationView bottomNavigationView = activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = tab;
			bottomNavigationView.SelectedItemId = tab;
		}
	}
}
