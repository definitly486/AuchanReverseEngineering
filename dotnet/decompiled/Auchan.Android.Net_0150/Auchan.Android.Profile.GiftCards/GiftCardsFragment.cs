using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Controls;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.InfoPages;
using Auchan.Common.Profile.GiftCards;

namespace Auchan.Android.Profile.GiftCards;

internal class GiftCardsFragment : BaseToolbarFragment<GiftCardsViewModel>
{
	protected override int LayoutId => 2131493029;

	public GiftCardsFragment(Func<Fragment, GiftCardsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297240);
		TextView textView2 = view.RequireViewById<TextView>(2131297237);
		Button button = view.RequireViewById<Button>(2131296599);
		Button button2 = view.RequireViewById<Button>(2131296507);
		TextView textView3 = view.RequireViewById<TextView>(2131297239);
		TextView textView4 = view.RequireViewById<TextView>(2131297238);
		NavigationCellView navigationCellView = view.RequireViewById<NavigationCellView>(2131298266);
		NavigationCellView navigationCellView2 = view.RequireViewById<NavigationCellView>(2131297141);
		NavigationCellView navigationCellView3 = view.RequireViewById<NavigationCellView>(2131297151);
		base.ToolbarTitle = base.ViewModel.Title;
		textView.Text = base.ViewModel.GiftCardTitle;
		textView2.Text = base.ViewModel.GiftCardDescription;
		button.Text = base.ViewModel.BuyButtonText;
		button2.Text = base.ViewModel.CheckBalanceButtonText;
		textView3.Text = base.ViewModel.GiftCardSumRangeText;
		textView4.Text = base.ViewModel.GiftCardPlasticDescription;
		navigationCellView.Text = base.ViewModel.GiftCardRulesText;
		navigationCellView2.Text = base.ViewModel.FAQText;
		navigationCellView3.Text = base.ViewModel.FeedbackText;
		base.ViewModel.OpenDynamicFeedbackCommand.SafeSubscribe(delegate(DynamicFeedbackViewModel.Parameter p)
		{
			NavigateTo<DynamicFeedbackFragment, DynamicFeedbackViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenGiftCardFAQCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter p)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenGiftCardBalanceCommand.SafeSubscribe(delegate
		{
			Show<GiftCardBalanceFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenGiftCardRulesCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter p)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenGiftCardShopCommand.SafeSubscribe(delegate(WebViewModel.Parameter p)
		{
			NavigateTo<WebFragment, WebViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OpenGiftCardShopCommand.Trigger), button2.OnClick(base.ViewModel.OpenGiftCardBalanceCommand.Trigger), navigationCellView3.OnClick(base.ViewModel.OpenDynamicFeedbackCommand.Trigger), navigationCellView2.OnClick(base.ViewModel.OpenGiftCardFAQCommand.Trigger), navigationCellView.OnClick(base.ViewModel.OpenGiftCardRulesCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
