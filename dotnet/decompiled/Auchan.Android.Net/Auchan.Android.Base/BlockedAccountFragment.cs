using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Common.Base;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Button;
using Java.Interop;

namespace Auchan.Android.Base;

internal class BlockedAccountFragment : BaseDialogFragment<BlockedAccountViewModel>, View.IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	protected override int LayoutId => 2131492991;

	public BlockedAccountFragment(Func<Fragment, BlockedAccountViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		TextView textView3 = view.RequireViewById<TextView>(2131296959);
		TextView textView4 = view.RequireViewById<TextView>(2131297874);
		TextView textView5 = view.RequireViewById<TextView>(2131297223);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131297245);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.DescriptionString;
		textView3.Text = base.ViewModel.ContactWithUsString;
		textView4.Text = base.ViewModel.PhoneString;
		textView5.Text = base.ViewModel.FreeString;
		materialButton.Text = base.ViewModel.GoHomeButtonTitle;
		materialButton.SetOnClickListener(this);
	}

	public void OnClick(View v)
	{
		Dismiss();
		ShowHomePage();
	}

	private void ShowHomePage()
	{
		BottomNavigationView bottomNavigationView = base.Activity.FindViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = 2131297642;
			bottomNavigationView.SelectedItemId = 2131297642;
		}
	}
}
