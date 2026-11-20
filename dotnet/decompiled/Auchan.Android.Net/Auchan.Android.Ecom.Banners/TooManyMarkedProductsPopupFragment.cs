using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart;

namespace Auchan.Android.Ecom.Banners;

internal class TooManyMarkedProductsPopupFragment : BaseBottomSheetDialogFragment<TooManyMarkedProductsPopupViewModel>
{
	protected override int LayoutId => 2131493501;

	public override int Theme => 2131951914;

	public TooManyMarkedProductsPopupFragment(Func<TooManyMarkedProductsPopupViewModel.Parameter, TooManyMarkedProductsPopupViewModel> newViewModel)
		: base((Func<Fragment, TooManyMarkedProductsPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<TooManyMarkedProductsPopupViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131297563);
		TextView textView3 = view.RequireViewById<TextView>(2131297013);
		View view2 = view.RequireViewById<View>(2131296789);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		textView3.Text = base.ViewModel.ButtonText;
		base.ViewModel.BindEvents(((View)textView3).OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		}), view2.OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}
}
