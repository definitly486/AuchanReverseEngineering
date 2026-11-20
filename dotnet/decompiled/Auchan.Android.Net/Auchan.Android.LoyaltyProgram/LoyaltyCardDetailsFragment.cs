using System;
using System.Collections.Generic;
using System.Reactive;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardDetailsFragment : BaseToolbarFragment<LoyaltyCardDetailsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493040;

	public LoyaltyCardDetailsFragment(Func<Fragment, LoyaltyCardDetailsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnAttach(Context context)
	{
		base.OnAttach(context);
		RequireActivity().OnBackPressedDispatcher.AddCallback(this, OnBackPressed);
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		View view2 = view.RequireViewById<View>(2131296490);
		NestedScrollView nestedScrollView = view.RequireViewById<NestedScrollView>(2131298303);
		View scrolledLineView = view.RequireViewById<View>(2131298305);
		LoyaltyQrCardView loyaltyQrCardView = nestedScrollView.RequireViewById<LoyaltyQrCardView>(2131297495);
		LoyaltyInfoBoxView loyaltyInfoBoxView = nestedScrollView.RequireViewById<LoyaltyInfoBoxView>(2131297487);
		LoyaltyInfoBoxView loyaltyInfoBoxView2 = nestedScrollView.RequireViewById<LoyaltyInfoBoxView>(2131297488);
		CardView incomeRulesCard = nestedScrollView.RequireViewById<CardView>(2131297333);
		TextView textView = incomeRulesCard.RequireViewById<TextView>(2131297334);
		TextView textView2 = incomeRulesCard.RequireViewById<TextView>(2131297332);
		TextView textView3 = incomeRulesCard.RequireViewById<TextView>(2131297949);
		TextView textView4 = incomeRulesCard.RequireViewById<TextView>(2131297948);
		View view3 = nestedScrollView.RequireViewById<View>(2131297497);
		TextView textView5 = view3.RequireViewById<TextView>(2131297498);
		MaterialButton blockCardButton = nestedScrollView.RequireViewById<MaterialButton>(2131296540);
		blockCardButton.Text = base.ViewModel.BlockCardLabel;
		loyaltyInfoBoxView.TitleLabel.Text = base.ViewModel.CallCenterPhone;
		loyaltyInfoBoxView.DescriptionLabel.Text = base.ViewModel.CallCenterDescription;
		loyaltyInfoBoxView2.TitleLabel.Text = base.ViewModel.CantScanQrTitle;
		loyaltyInfoBoxView2.DescriptionLabel.Text = base.ViewModel.CantScanQrDescription;
		textView.Text = base.ViewModel.PointsIncomeRulesTitle;
		textView2.Text = base.ViewModel.PointsIncomeRules;
		textView3.Text = base.ViewModel.PointsSpendingRulesTitle;
		textView4.Text = base.ViewModel.PointsSpendingRules;
		textView5.Text = base.ViewModel.LoyaltyProgramRulesLabel;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				loyaltyQrCardView.IsBlocked = base.ViewModel.IsCardBlocked;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				incomeRulesCard.SetCardBackgroundColor(ContextCompat.GetColor(Context, base.ViewModel.IsCardBlocked ? 2131099698 : 2131100610));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				ToggleCardStatus(base.ViewModel.IsCardBlocked, loyaltyQrCardView);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				blockCardButton.Visibility = (!base.ViewModel.IsCardBlocked).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardBlocked")),
			(delegate
			{
				loyaltyQrCardView.CardNumberLabel.Text = base.ViewModel.CardNumber;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardNumber")),
			(delegate
			{
				loyaltyQrCardView.AddToGooglePayButton.Visibility = base.ViewModel.SaveToWalletEnabled.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveToWalletEnabled"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)loyaltyQrCardView.AddToGooglePayButton).OnClick((Action)delegate
		{
			base.ViewModel.OnSaveToWalletClick().SafeFireAndForget((Action<Exception>)null, false);
		}), blockCardButton.OnClick(base.ViewModel.OnBlockCardSelected), loyaltyInfoBoxView.OnClick(base.ViewModel.OnCallCenterButtonClick), loyaltyInfoBoxView2.OnClick(base.ViewModel.OnCantScanQrButtonClick), view3.OnClick(base.ViewModel.OnLoyaltyProgramRulesClickAsync), view2.OnClick(OnBackPressed), nestedScrollView.OnScrollChange(delegate(object? o, NestedScrollView.ScrollChangeEventArgs e)
		{
			scrolledLineView.Visibility = (e.ScrollY != 0).ToVisibility();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToCantScanCommand.SafeSubscribe(OnNavigateToCannotScan, ViewLifecycleOwner);
		base.ViewModel.NavigateToLoyaltyRulesCommand.SafeSubscribe(OnNavigateToLoyaltyRules, ViewLifecycleOwner);
		base.ViewModel.NavigateToCardBlockOptionsCommand.SafeSubscribe(OnNavigateToCardBlockOptions, ViewLifecycleOwner);
	}

	private void ToggleCardStatus(bool isCardBlocked, LoyaltyQrCardView loyaltyQrCardView)
	{
		loyaltyQrCardView.TitleLabel.Text = (isCardBlocked ? base.ViewModel.CardIsBlockedLabel : base.ViewModel.CardNumberLabel);
	}

	private void OnBackPressed()
	{
		base.ViewModel.OnClose();
		base.ParentFragmentManager.PopBackStack();
	}

	private void OnNavigateToCannotScan(Unit unit)
	{
		_fragmentFactory.Instantiate<CantScanLoyaltyCardFragment>().Show(base.ParentFragmentManager, null);
	}

	private void OnNavigateToLoyaltyRules(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void OnNavigateToCardBlockOptions(Unit parameter)
	{
		_fragmentFactory.Instantiate<LoyaltyCardBlockOptionsFragment>().Show(RequireActivity().SupportFragmentManager, null);
	}
}
