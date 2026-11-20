using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Activity;
using AndroidX.Core.View;
using Auchan.Android.Base;

namespace Auchan.Android.Controls;

internal sealed class BusyPopup : BaseDialogFragment
{
	protected override int LayoutId => 2131492994;

	protected override int InsetsTypeMask => 0;

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		if (Dialog is ComponentDialog componentDialog)
		{
			componentDialog.OnBackPressedDispatcher.AddCallback(new DelegateOnBackPressedCallback(delegate
			{
			}));
		}
	}

	public override Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window? window = dialog.Window;
		window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
		window.DecorView.SystemUiFlags = SystemUiFlags.LayoutFlags | SystemUiFlags.LayoutStable;
		window.SetStatusBarColor(Color.Transparent);
		window.SetNavigationBarColor(Color.Transparent);
		return dialog;
	}

	protected override void OnWindowInsetsChanged(WindowInsetsCompat insets)
	{
	}
}
