using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart;

internal class CheckoutPointsPaymentInformerFragment : BaseBottomSheetDialogFragment<CheckoutPointsPaymentInformerViewModel>
{
	public override int Theme => 2131951916;

	protected override int LayoutId => 2131493009;

	protected override bool FullScreen => false;

	public CheckoutPointsPaymentInformerFragment(Func<CheckoutPointsPaymentInformerViewModel.Parameter, CheckoutPointsPaymentInformerViewModel> newViewModel)
		: base((Func<Fragment, CheckoutPointsPaymentInformerViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CheckoutPointsPaymentInformerViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		textView.Text = base.ViewModel.Title;
		textView2.AddLinkedText(base.ViewModel.Description);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		imageView.OnClick(base.ViewModel.OnCloseClick).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
