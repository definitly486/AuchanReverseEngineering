using Android.Views;
using Google.Android.Material.BottomSheet;

namespace Auchan.Android.Common;

public class LockableBottomSheetCallback : BottomSheetBehavior.BottomSheetCallback
{
	private readonly BottomSheetBehavior _behavior;

	public LockableBottomSheetCallback(BottomSheetBehavior behavior)
	{
		_behavior = behavior;
	}

	public override void OnSlide(View bottomSheet, float newState)
	{
	}

	public override void OnStateChanged(View bottomSheet, int state)
	{
		if (state == 6 || state == 4)
		{
			_behavior.State = 3;
		}
	}
}
