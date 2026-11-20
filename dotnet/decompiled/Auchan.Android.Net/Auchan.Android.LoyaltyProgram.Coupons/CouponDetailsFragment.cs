using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Coupons;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram.Coupons;

internal class CouponDetailsFragment : BaseBottomSheetDialogFragment<CouponDetailsViewModel>
{
	private int CodeWidthPX = Converter.DpToPx(240f);

	private int CodeHeightPX = Converter.DpToPx(173f);

	protected override int LayoutId => 2131493015;

	public override int Theme => 2131951914;

	protected override bool FullScreen => true;

	public CouponDetailsFragment(Func<BrokerToken, CouponDetailsViewModel> newViewModel)
		: base((Func<Fragment, CouponDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296909);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131298079);
		ViewGroup viewGroup3 = view.RequireViewById<ViewGroup>(2131297111);
		TextView textView = viewGroup3.RequireViewById<TextView>(2131298646);
		TextView textView2 = viewGroup3.RequireViewById<TextView>(2131297563);
		Button button = viewGroup3.RequireViewById<Button>(2131296325);
		View view2 = viewGroup3.RequireViewById<View>(2131296795);
		viewGroup3.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		View view3 = viewGroup.RequireViewById<View>(2131296795);
		ViewGroup viewGroup4 = viewGroup.RequireViewById<ViewGroup>(2131296893);
		TextView dateText = viewGroup4.RequireViewById<TextView>(2131296895);
		TextView titleText = viewGroup.RequireViewById<TextView>(2131298659);
		TextView descriptionText = viewGroup.RequireViewById<TextView>(2131296964);
		ImageView codeImage = viewGroup.RequireViewById<ImageView>(2131296800);
		TextView infoText = viewGroup.RequireViewById<TextView>(2131297364);
		TextView textView3 = viewGroup.RequireViewById<TextView>(2131298105);
		TextView promocodeButton = viewGroup.RequireViewById<TextView>(2131298099);
		NavigationCellView navigationCellView = viewGroup.RequireViewById<NavigationCellView>(2131296271);
		navigationCellView.Text = base.ViewModel.CouponFullDescriptionText;
		textView3.Text = base.ViewModel.PromocodeTitle;
		view2.Visibility = ViewStates.Visible;
		button.Text = base.ViewModel.RetryText;
		textView.Text = base.ViewModel.ErrorTitle;
		textView2.Text = base.ViewModel.ErrorDescription;
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				viewGroup
			},
			{
				VisualState.InProgress,
				viewGroup2
			},
			{
				VisualState.Error,
				viewGroup3
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				titleText.Text = base.ViewModel.CouponTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponTitle")),
			(delegate
			{
				promocodeButton.Text = base.ViewModel.CouponValue;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponValue")),
			(delegate
			{
				descriptionText.Text = base.ViewModel.CouponDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponDescription")),
			(delegate
			{
				dateText.Text = base.ViewModel.CouponUsageTime;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponUsageTime")),
			(delegate
			{
				infoText.Text = base.ViewModel.CouponUsageDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponUsageDescription")),
			(delegate
			{
				codeImage.SetEAN13Code(base.ViewModel.CouponValue, CodeWidthPX, CodeHeightPX);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CouponValue"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.RetryCommand.Trigger), view2.OnClick(base.ViewModel.CloseCommand.Trigger), view3.OnClick(base.ViewModel.CloseCommand.Trigger), promocodeButton.OnClick(base.ViewModel.CopyPromocodeCommand.Trigger), navigationCellView.OnClick(base.ViewModel.OpenCouponDetails)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
