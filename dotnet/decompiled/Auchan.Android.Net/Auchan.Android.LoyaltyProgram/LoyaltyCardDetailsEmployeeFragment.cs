using System;
using System.Reactive;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.ViewModels;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardDetailsEmployeeFragment : BaseToolbarFragment<LoyaltyCardDetailsEmployeeViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493041;

	public LoyaltyCardDetailsEmployeeFragment(Func<Fragment, LoyaltyCardDetailsEmployeeViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131296973);
		HighlightedTextView highlightedTextView = view.RequireViewById<HighlightedTextView>(2131296972);
		NavigationCellView navigationCellView = view.RequireViewById<NavigationCellView>(2131297497);
		NavigationCellView navigationCellView2 = view.RequireViewById<NavigationCellView>(2131297996);
		Button button = view.RequireViewById<Button>(2131296540);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		textView.Text = base.ViewModel.InfoTitle;
		highlightedTextView.AttributedText = base.ViewModel.InfoText;
		navigationCellView.Text = base.ViewModel.LoyaltyRulesText;
		navigationCellView2.Text = base.ViewModel.PrivilegesClubText;
		navigationCellView.Visibility = ViewStates.Gone;
		navigationCellView2.Visibility = ViewStates.Gone;
		button.Text = base.ViewModel.BlockCardButtonText;
		base.ViewModel.BindEvents(navigationCellView.OnClick(base.ViewModel.OnOpenLoyaltyRules), navigationCellView2.OnClick(base.ViewModel.OnOpenPrivilegesClub), button.OnClick(base.ViewModel.OnBlockCardSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToInfoPageCommand.SafeSubscribe(OnNavigateToInfoPage, ViewLifecycleOwner);
		base.ViewModel.NavigateToCardBlockOptionsCommand.SafeSubscribe(OnNavigateToCardBlockOptions, ViewLifecycleOwner);
	}

	private void OnNavigateToInfoPage(InfoPageViewModel.Parameter parameter)
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
