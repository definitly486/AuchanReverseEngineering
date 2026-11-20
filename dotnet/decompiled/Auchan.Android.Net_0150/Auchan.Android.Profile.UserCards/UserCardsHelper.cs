using System.Threading.Tasks;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Profile.UserCards;

public static class UserCardsHelper
{
	public static async Task ShowRemoveLabel(FrameLayout? deleteView = null, ConstraintLayout? contentView = null)
	{
		if (deleteView != null && contentView != null)
		{
			contentView.Visibility = ViewStates.Invisible;
			deleteView.Visibility = ViewStates.Invisible;
			await Task.Delay(1000);
			contentView.Visibility = ViewStates.Visible;
			deleteView.Visibility = ViewStates.Visible;
		}
	}
}
