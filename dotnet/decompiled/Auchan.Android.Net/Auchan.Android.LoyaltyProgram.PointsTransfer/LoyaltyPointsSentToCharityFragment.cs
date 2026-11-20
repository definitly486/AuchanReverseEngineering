using System;
using System.Reactive;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointsSentToCharityFragment : BaseBottomSheetDialogFragment<LoyaltyPointsSentToCharityViewModel>
{
	protected override int LayoutId => 2131493051;

	public override int Theme => 2131951914;

	public LoyaltyPointsSentToCharityFragment(Func<LoyaltyPointsSentToCharityNavigationParameter, LoyaltyPointsSentToCharityViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyPointsSentToCharityViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyPointsSentToCharityNavigationParameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131297499);
		TextView textView3 = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296846);
		textView.Text = base.ViewModel.TitleLabel;
		textView2.Text = base.ViewModel.OperationTitle;
		textView3.Text = base.ViewModel.Description;
		materialButton.Text = base.ViewModel.ContinueButtonText;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.OnCloseButtonSelected), materialButton.OnClick(base.ViewModel.OnCloseButtonSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(OnClose, ViewLifecycleOwner);
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		base.ViewModel.OnCloseButtonSelected();
	}

	private void OnClose(Unit obj)
	{
		Dismiss();
		this.ReturnResult(0);
	}
}
