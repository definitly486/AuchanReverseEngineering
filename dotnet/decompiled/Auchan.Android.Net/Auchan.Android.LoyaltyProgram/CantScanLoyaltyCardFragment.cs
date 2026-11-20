using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram;

internal class CantScanLoyaltyCardFragment : BaseBottomSheetDialogFragment<CantScanLoyaltyCardViewModel>
{
	public override int Theme => 2131951916;

	protected override int LayoutId => 2131493039;

	public CantScanLoyaltyCardFragment(Func<Fragment, CantScanLoyaltyCardViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView title = view.RequireViewById<TextView>(2131298659);
		View view2 = view.RequireViewById<View>(2131296795);
		TextView descriptionText = view.RequireViewById<TextView>(2131296964);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298847);
		MaterialButton materialButton2 = view.RequireViewById<MaterialButton>(2131296605);
		title.Text = base.ViewModel.ScreenTitle;
		descriptionText.Text = base.ViewModel.MessageText;
		materialButton.Text = base.ViewModel.WriteMessageButtonLabel;
		materialButton2.Text = base.ViewModel.CallButtonLabel;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				title.Text = base.ViewModel.ScreenTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ScreenTitle")),
			(delegate
			{
				descriptionText.Text = base.ViewModel.MessageText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MessageText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(Dismiss), materialButton.OnClick(base.ViewModel.WriteMessage), ((View)materialButton2).OnClick((Action)delegate
		{
			base.ViewModel.DoPhoneCallAsync().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
