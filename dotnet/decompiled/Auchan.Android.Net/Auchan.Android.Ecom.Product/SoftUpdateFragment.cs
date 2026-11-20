using System;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Product;

internal class SoftUpdateFragment : BaseBottomSheetDialogFragment<SoftUpdateViewModel>
{
	protected override int LayoutId => 2131493494;

	public override int Theme => 2131951914;

	public SoftUpdateFragment(Func<Fragment, SoftUpdateViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131298413);
		TextView textView3 = view.RequireViewById<TextView>(2131298412);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298788);
		textView.Text = base.ViewModel.PopupTitle;
		textView2.Text = base.ViewModel.SoftUpdateTitle;
		textView3.Text = base.ViewModel.SoftUpdateMessage;
		materialButton.Text = base.ViewModel.UpdateButtonText;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.CancelClicked), materialButton.OnClick(base.ViewModel.UpdateClicked)).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.CancelClickedCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			Dismiss();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}
}
