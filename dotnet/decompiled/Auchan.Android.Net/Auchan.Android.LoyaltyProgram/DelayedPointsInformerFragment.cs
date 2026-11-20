using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

namespace Auchan.Android.LoyaltyProgram;

internal class DelayedPointsInformerFragment : BaseBottomSheetDialogFragment<DelayedPointsInformerViewModel>
{
	protected override int LayoutId => 2131493462;

	public override int Theme => 2131951914;

	public DelayedPointsInformerFragment(Func<Fragment, DelayedPointsInformerViewModel> newViewModel)
		: base(newViewModel)
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
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
