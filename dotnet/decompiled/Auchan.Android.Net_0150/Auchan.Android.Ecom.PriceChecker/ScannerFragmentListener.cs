using System;
using Android.App;
using AndroidX.Fragment.App;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Ecom.PriceChecker;

public class ScannerFragmentListener : FragmentManager.FragmentLifecycleCallbacks
{
	public override void OnFragmentStarted(FragmentManager fm, AndroidX.Fragment.App.Fragment f)
	{
		base.OnFragmentStarted(fm, f);
		if (!(f is BottomSheetDialogFragment) && !(f is DialogFragment))
		{
			Attribute? customAttribute = Attribute.GetCustomAttribute(f.GetType(), typeof(ScannerFragmentAttribute));
			Activity currentActivity = Platform.CurrentActivity;
			if (customAttribute != null)
			{
				Utils.SetFlags(currentActivity);
			}
			else
			{
				Utils.RestoreFlags(currentActivity);
			}
		}
	}
}
