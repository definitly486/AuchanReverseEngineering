using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Drive;

namespace Auchan.Android.Drive;

internal class AlreadyBringingPopupFragment : BaseBottomSheetDialogFragment<AlreadyBringingPopupViewModel>
{
	public Action? NavigateToOrders;

	protected override int LayoutId => 2131493444;

	public override int Theme => 2131951914;

	public AlreadyBringingPopupFragment(Func<Fragment, AlreadyBringingPopupViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131296434);
		TextView textView2 = view.RequireViewById<TextView>(2131296433);
		TextView textView3 = view.RequireViewById<TextView>(2131296432);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		textView3.Text = base.ViewModel.ButtonText;
		((View)textView3).OnClick((Action)delegate
		{
			NavigateToOrders?.Invoke();
			Dismiss();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_ = base.ParentFragmentManager.BackStackEntryCount;
	}
}
