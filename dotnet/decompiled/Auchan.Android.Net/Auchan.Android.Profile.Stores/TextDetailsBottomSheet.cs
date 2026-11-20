using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Stores;

namespace Auchan.Android.Profile.Stores;

internal class TextDetailsBottomSheet : BaseBottomSheetDialogFragment<TextDetailsViewModel>
{
	public override int Theme => 2131951914;

	protected override bool FullScreen => true;

	protected override int LayoutId => 2131493484;

	public TextDetailsBottomSheet(Func<TextDetailsViewModel.Parameter, TextDetailsViewModel> newViewModel)
		: base((Func<Fragment, TextDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<TextDetailsViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296795);
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.Close)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		TextView textView = view.RequireViewById<TextView>(2131298659);
		view.RequireViewById<TextView>(2131297961).Text = base.ViewModel.Description;
		textView.Text = base.ViewModel.Title;
	}

	public override void OnPause()
	{
		base.OnPause();
		Dismiss();
	}
}
