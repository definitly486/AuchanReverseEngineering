using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.PriceChecker;

namespace Auchan.Android.Ecom.PriceChecker;

internal class ProductMiniFragment : BaseBottomSheetDialogFragment<ProductMiniViewModel>
{
	protected override int LayoutId => 2131493509;

	public override int Theme => 2131951914;

	public ProductMiniFragment(Func<BrokerToken, ProductMiniViewModel> newViewModel)
		: base((Func<Fragment, ProductMiniViewModel>)((Fragment fragment) => newViewModel(fragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131297981);
		TextView textView3 = view.RequireViewById<TextView>(2131297737);
		TextView textView4 = view.RequireViewById<TextView>(2131298782);
		TextView textView5 = view.RequireViewById<TextView>(2131297149);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Price;
		textView5.Text = base.ViewModel.FeedbackButtonTitle;
		textView3.Text = base.ViewModel.OldPrice;
		textView3.Visibility = base.ViewModel.HasDiscount.ToVisibility();
		textView4.Text = base.ViewModel.UnitTypeText;
		textView4.Visibility = base.ViewModel.IsUnitTypeVisible.ToVisibility();
		base.ViewModel.BindEvents(textView5.OnClick(base.ViewModel.OnFeedbackClicked), imageView.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
