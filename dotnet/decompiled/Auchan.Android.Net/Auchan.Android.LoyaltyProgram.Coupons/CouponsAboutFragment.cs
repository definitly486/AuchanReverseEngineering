using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons;

namespace Auchan.Android.LoyaltyProgram.Coupons;

internal class CouponsAboutFragment : BaseBottomSheetDialogFragment<CouponsAboutViewModel>
{
	private OnBackPressedCallback? _backPressCallback;

	protected override int LayoutId => 2131493017;

	public override int Theme => 2131951914;

	protected override bool FullScreen => true;

	public CouponsAboutFragment(Func<Fragment, CouponsAboutViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, base.ViewModel.CloseCommand.Trigger);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296795);
		view.RequireViewById<TextView>(2131298659).Text = base.ViewModel.Title;
		view.RequireViewById<TextView>(2131296964).Text = base.ViewModel.Description;
		view.RequireViewById<TextView>(2131297304).Text = base.ViewModel.HowToObtainTitle;
		view.RequireViewById<TextView>(2131297301).Text = base.ViewModel.HowToObtainDescriptionBuy;
		view.RequireViewById<TextView>(2131297302).Text = base.ViewModel.HowToObtainDescriptionLook;
		view.RequireViewById<TextView>(2131297303).Text = base.ViewModel.HowToObtainDescriptionUse;
		view.RequireViewById<TextView>(2131297307).Text = base.ViewModel.HowToUseTitle;
		view.RequireViewById<TextView>(2131297306).Text = base.ViewModel.HowToUseDescriptionTitle;
		view.RequireViewById<TextView>(2131297305).Text = base.ViewModel.HowToUseDescriptionDescription;
		view2.OnClick(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (_backPressCallback != null)
		{
			_backPressCallback.Enabled = !hidden;
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		if (_backPressCallback != null)
		{
			_backPressCallback.Remove();
			_backPressCallback.Dispose();
		}
	}
}
