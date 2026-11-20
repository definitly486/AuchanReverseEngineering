using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointTransferErrorFragment : BaseBottomSheetDialogFragment<LoyaltyTransferErrorViewModel>
{
	protected override int LayoutId => 2131493050;

	public override int Theme => 2131951914;

	public LoyaltyPointTransferErrorFragment(Func<LoyaltyTransferErrorViewModel.Parameter, LoyaltyTransferErrorViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyTransferErrorViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyTransferErrorViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297499);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296846);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		materialButton.Text = base.ViewModel.ContinueButtonText;
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.OnCloseButtonSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
