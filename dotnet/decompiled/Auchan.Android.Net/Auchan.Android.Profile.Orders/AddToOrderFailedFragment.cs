using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class AddToOrderFailedFragment : BaseBottomSheetDialogFragment<AddToOrderFailedViewModel>
{
	protected override bool FullScreen => true;

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131492979;

	public AddToOrderFailedFragment(Func<AddToOrderFailedViewModel.Parameter, AddToOrderFailedViewModel> newViewModel)
		: base((Func<Fragment, AddToOrderFailedViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<AddToOrderFailedViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		TextView textView3 = view.RequireViewById<TextView>(2131297013);
		View view2 = view.RequireViewById<View>(2131296791);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		textView3.Text = base.ViewModel.DoneButtonText;
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
		}, ViewLifecycleOwner);
	}
}
