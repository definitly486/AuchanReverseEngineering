using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Vpn;
using VisibilitySwitch;

namespace Auchan.Android.Vpn;

internal class VpnDialogFragment : BaseDialogFragment<VpnViewModel>
{
	protected override int LayoutId => 2131493022;

	public VpnDialogFragment(Func<VpnViewModel.Parameter, VpnViewModel> newViewModel)
		: base((Func<Fragment, VpnViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.NavParam<VpnViewModel.Parameter>() ?? throw new ArgumentNullException())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		View qrCodeLayout = constraintLayout.RequireViewById<View>(2131298123);
		ImageView qrCodeImage = constraintLayout.RequireViewById<ImageView>(2131298122);
		TextView textView3 = constraintLayout.RequireViewById<TextView>(2131298124);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		button.Text = base.ViewModel.ButtonText;
		textView3.Text = base.ViewModel.QrCodeText;
		Cancelable = false;
		VisibilitySwitch<VpnViewModel.VisualState> viewSwitch = new VisibilitySwitch<VpnViewModel.VisualState>(base.ViewModel.State)
		{
			{
				VpnViewModel.VisualState.Default,
				constraintLayout
			},
			{
				VpnViewModel.VisualState.InProgress,
				frameLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				qrCodeLayout.Visibility = base.ViewModel.IsQrCodeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsQrCodeVisible")),
			(delegate
			{
				qrCodeImage.SetPDF417Code(base.ViewModel.QrCode);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QrCode"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnActionClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			this.DismissAsync().SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
	}
}
