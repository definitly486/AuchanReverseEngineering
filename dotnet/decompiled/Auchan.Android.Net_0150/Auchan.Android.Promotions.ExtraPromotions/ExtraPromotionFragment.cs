using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Promotions.ExtraPromotions;

namespace Auchan.Android.Promotions.ExtraPromotions;

internal class ExtraPromotionFragment : BaseDialogFragment<ExtraPromotionViewModel>
{
	protected override int LayoutId => 2131493482;

	public override int Theme => 2131951957;

	public ExtraPromotionFragment(Func<ExtraPromotionViewModel.Parameter, ExtraPromotionViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, ExtraPromotionViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ExtraPromotionViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131298095);
		ImageView imageView2 = view.RequireViewById<ImageView>(2131298094);
		imageView.FromUrlDownsample(base.ViewModel.ImageUrl);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.OpenPromo), imageView2.OnClick(base.ViewModel.Close)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnClosePromoScreenCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window? window = dialog.Window;
		if (window != null)
		{
			window.AddFlags(WindowManagerFlags.LayoutNoLimits);
			return dialog;
		}
		return dialog;
	}
}
