using Android.Views;
using Google.Android.Material.BottomSheet;

namespace Auchan.Android.Base;

public class BottomSheetBehaviorCallback : BottomSheetBehavior.BottomSheetCallback
{
	public override void OnSlide(View bottomSheetView, float newState)
	{
	}

	public override void OnStateChanged(View bottomSheet, int newState)
	{
		if (newState == 1)
		{
			BottomSheetBehavior.From(bottomSheet).State = 3;
		}
	}
}
