using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointsTransferOptionsFragment : BaseToolbarFragment<LoyaltyPointsTransferOptionsViewModel>
{
	public const string NavTag = "LoyaltyTransferFlowBackstack";

	private ViewGroup _pointsTab;

	private ViewGroup _stampsTab;

	protected override int LayoutId => 2131493053;

	public LoyaltyPointsTransferOptionsFragment(Func<Fragment, LoyaltyPointsTransferOptionsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296911);
		_pointsTab = view.RequireViewById<ViewGroup>(2131297940);
		TextView pointsTitleLabel = view.RequireViewById<TextView>(2131297953);
		TextView pointsIntLabel = view.RequireViewById<TextView>(2131297938);
		TextView pointsFractionLabel = view.RequireViewById<TextView>(2131297933);
		_stampsTab = view.RequireViewById<ViewGroup>(2131298448);
		TextView stampsTitleLabel = view.RequireViewById<TextView>(2131298456);
		TextView stampsIntLabel = view.RequireViewById<TextView>(2131298447);
		ConstraintLayout constraintLayout = linearLayout.RequireViewById<ConstraintLayout>(2131296752);
		ImageView imageView = constraintLayout.RequireViewById<ImageView>(2131296755);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131296757);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131296753);
		TextView textView3 = linearLayout.RequireViewById<TextView>(2131296754);
		ConstraintLayout constraintLayout2 = linearLayout.RequireViewById<ConstraintLayout>(2131297879);
		ImageView imageView2 = constraintLayout2.RequireViewById<ImageView>(2131297882);
		TextView textView4 = constraintLayout2.RequireViewById<TextView>(2131297883);
		TextView textView5 = constraintLayout2.RequireViewById<TextView>(2131297880);
		TextView textView6 = linearLayout.RequireViewById<TextView>(2131297881);
		TextView textView7 = linearLayout.RequireViewById<TextView>(2131298755);
		ConstraintLayout constraintLayout3 = view.RequireViewById<ConstraintLayout>(2131297955);
		TextView textView8 = constraintLayout3.RequireViewById<TextView>(2131297954);
		TextView Title = view.RequireViewById<TextView>(2131298679);
		ConstraintLayout constraintLayout4 = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131297508);
		TextView textView9 = constraintLayout4.RequireViewById<TextView>(2131296808);
		ImageView errorImage = constraintLayout4.RequireViewById<ImageView>(2131296807);
		constraintLayout4.RequireViewById<Group>(2131296569).Visibility = ViewStates.Gone;
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		textView9.AddScrollBehaviour();
		textView.Text = base.ViewModel.CharityOptionTitle;
		textView2.Text = base.ViewModel.CharityOptionDescription;
		textView4.Text = base.ViewModel.PhoneNumberOptionTitle;
		textView5.Text = base.ViewModel.PhoneNumberOptionDescription;
		textView7.Text = base.ViewModel.TransferRulesText;
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout4
			}
		};
		if (base.ViewModel.IsPointsTransferDisabled)
		{
			linearLayout.Visibility = ViewStates.Gone;
			constraintLayout3.Visibility = ViewStates.Visible;
			textView8.SetLinkedHtml(base.ViewModel.PointsTransferDisabledMessage, base.ViewModel.HandleUrl).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		}
		Color color = new Color(ContextCompat.GetColor(Context, 2131099838));
		if (!base.ViewModel.IsPointsTransferDisabled && base.ViewModel.IsPointsTransferToAuchanFundDisabled)
		{
			constraintLayout.Enabled = false;
			imageView.SetColorFilter(color);
			textView.SetTextColor(color);
			textView2.SetTextColor(color);
			textView3.Visibility = ViewStates.Visible;
			textView3.SetLinkedHtml(base.ViewModel.PointsTransferToAuchanFundDisabledMessage, base.ViewModel.HandleUrl).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		}
		if (!base.ViewModel.IsPointsTransferDisabled && base.ViewModel.IsPointsTransferToUserDisabled)
		{
			constraintLayout2.Enabled = false;
			imageView2.SetColorFilter(color);
			textView4.SetTextColor(color);
			textView5.SetTextColor(color);
			textView6.Visibility = ViewStates.Visible;
			textView6.SetLinkedHtml(base.ViewModel.PointsTransferToUserDisabledMessage, base.ViewModel.HandleUrl).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		}
		textView9.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleUrl).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[9]
		{
			(delegate
			{
				UpdateLoyaltyTabs(base.ViewModel.PointsType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsType")),
			(delegate
			{
				pointsTitleLabel.Text = base.ViewModel.PointsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsTitle")),
			(delegate
			{
				pointsIntLabel.Text = base.ViewModel.PointsBalanceIntString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceIntString")),
			(delegate
			{
				pointsFractionLabel.Text = base.ViewModel.PointsBalanceFractionString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceFractionString")),
			(delegate
			{
				stampsTitleLabel.Text = base.ViewModel.StampsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsTitle")),
			(delegate
			{
				stampsIntLabel.Text = base.ViewModel.StampsBalanceString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsBalanceString")),
			(delegate
			{
				errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				Title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_pointsTab.OnClick(base.ViewModel.PointsTabTapped), _stampsTab.OnClick(base.ViewModel.StampsTabTapped), constraintLayout.OnClick(base.ViewModel.OnTransferToCharitySelected), constraintLayout2.OnClick(base.ViewModel.OnTransferToPhoneNumberSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToCharityTransferCommand.SafeSubscribe(OnNavigateToCharityTransfer, ViewLifecycleOwner);
		base.ViewModel.NavigateToPhoneNumberTransferCommand.SafeSubscribe(OnNavigateToPhoneNumberTransfer, ViewLifecycleOwner);
	}

	private void UpdateLoyaltyTabs(LoyaltyPointType pointType)
	{
		_pointsTab.Activated = pointType == LoyaltyPointType.Points;
		_stampsTab.Activated = pointType == LoyaltyPointType.Stamps;
		_stampsTab.Visibility = base.ViewModel.ShowStamps.ToInvisibleVisibility();
	}

	private void OnNavigateToCharityTransfer(LoyaltyPointsTransferNavigationParameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<LoyaltyPointsTransferToCharityFragment>(this, parameter.ToNavBundle())
			.AddToBackStack("LoyaltyTransferFlowBackstack")
			.Commit();
	}

	private void OnNavigateToPhoneNumberTransfer(LoyaltyPointsTransferNavigationParameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<LoyaltyPointsTransferToNumberFragment>(this, parameter.ToNavBundle())
			.AddToBackStack("LoyaltyTransferFlowBackstack")
			.Commit();
	}
}
