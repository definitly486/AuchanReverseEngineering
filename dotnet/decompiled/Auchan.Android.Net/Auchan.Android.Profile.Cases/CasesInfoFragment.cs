using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Cases;

namespace Auchan.Android.Profile.Cases;

internal sealed class CasesInfoFragment : BaseBottomSheetDialogFragment<CasesInfoViewModel>
{
	protected override int LayoutId => 2131493455;

	public override int Theme => 2131951914;

	public CasesInfoFragment(Func<Fragment, CasesInfoViewModel> newViewModel)
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
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131296794);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		appCompatButton.Text = base.ViewModel.CloseButtonText;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.CloseCommand.Trigger), appCompatButton.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
