using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class SuccessAdditionalOrderPopupFragment : BaseBottomSheetDialogFragment<SuccessAdditionalOrderPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493500;

	public SuccessAdditionalOrderPopupFragment(Func<BrokerToken, SuccessAdditionalOrderPopupViewModel> newViewModel)
		: base((Func<Fragment, SuccessAdditionalOrderPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296789);
		TextView textView2 = view.RequireViewById<TextView>(2131298559);
		TextView textView3 = view.RequireViewById<TextView>(2131297363);
		TextView textView4 = view.RequireViewById<TextView>(2131297289);
		TextView textView5 = view.RequireViewById<TextView>(2131297800);
		OrderListCellControls orderListCellControls = new OrderListCellControls(view.RequireViewById<View>(2131297767));
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		}), ((View)textView4).OnClick((Action)delegate
		{
			base.ViewModel.NavigateToHome();
		}), ((View)textView5).OnClick((Action)delegate
		{
			base.ViewModel.NavigateToOrderDetails();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Subtitle;
		textView3.Text = base.ViewModel.InfoText;
		textView4.Text = base.ViewModel.HomeButtonText;
		textView5.Text = base.ViewModel.OrderDetailsButtonText;
		orderListCellControls.Setup(base.ViewModel.Order);
	}
}
