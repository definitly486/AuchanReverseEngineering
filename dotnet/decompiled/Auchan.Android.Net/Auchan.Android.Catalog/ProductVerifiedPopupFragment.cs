using System;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Catalog;

internal sealed class ProductVerifiedPopupFragment : BaseBottomSheetDialogFragment<ProductVerifiedPopupViewModel>
{
	protected override int LayoutId => 2131493481;

	public override int Theme => 2131951914;

	public ProductVerifiedPopupFragment(Func<ProductVerifiedPopupViewModel.Parameter, ProductVerifiedPopupViewModel> newViewModel)
		: base((Func<Fragment, ProductVerifiedPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ProductVerifiedPopupViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131298023);
		TextView textView = view.RequireViewById<TextView>(2131298028);
		TextView textView2 = view.RequireViewById<TextView>(2131298024);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131298026);
		TextView textView3 = view.RequireViewById<TextView>(2131298021);
		Color value = new Color(ContextCompat.GetColor(RequireContext(), 2131099856));
		textView.Text = base.ViewModel.Title;
		textView2.AddLinkedText(base.ViewModel.IntroText, value, underlineLinks: true);
		textView3.Text = base.ViewModel.ButtonText;
		if (base.ViewModel.IsListVisible)
		{
			linearLayout.Visibility = ViewStates.Visible;
			foreach (ProductVerifiedLinkItemViewModel item in base.ViewModel.Items)
			{
				TextView textView4 = (TextView)base.LayoutInflater.Inflate(2131493305, linearLayout, attachToRoot: false);
				textView4.AddLinkedText(item.Description, value, underlineLinks: true);
				linearLayout.AddView(textView4);
			}
		}
		else
		{
			linearLayout.Visibility = ViewStates.Gone;
		}
		textView3.OnClick(Dismiss).AutoDisposeOnDestroy(ViewLifecycleOwner);
		imageView.OnClick(Dismiss).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
