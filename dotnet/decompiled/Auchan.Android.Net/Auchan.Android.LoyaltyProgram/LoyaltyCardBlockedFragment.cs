using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardBlockedFragment : BaseToolbarFragment<LoyaltyCardBlockedViewModel>
{
	protected override int LayoutId => 2131493038;

	public LoyaltyCardBlockedFragment(Func<Fragment, LoyaltyCardBlockedViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		IToolbarContainer obj = (IToolbarContainer)RequireParentFragment();
		obj.Title = string.Empty;
		obj.CloseButtonText = base.ViewModel.CloseString;
		view.RequireViewById<ImageView>(2131297308);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		TextView messageText = view.RequireViewById<TextView>(2131297571);
		textView.Text = base.ViewModel.Title;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateMessage(messageText, base.ViewModel.BoldMessageStartEnd);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BoldMessageStartEnd")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			OnClose();
		}, ViewLifecycleOwner);
	}

	private void OnClose()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<AuthOrRegisterFragment>();
	}

	private void UpdateMessage(TextView messageText, (int Start, int End) startEndBold)
	{
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(base.ViewModel.Message);
		spannableStringBuilder.SetSpan(new StyleSpan(TypefaceStyle.Bold), base.ViewModel.BoldMessageStartEnd.Item1, base.ViewModel.BoldMessageStartEnd.Item1 + base.ViewModel.BoldMessageStartEnd.Item2, SpanTypes.ExclusiveExclusive);
		messageText.TextFormatted = spannableStringBuilder;
	}
}
