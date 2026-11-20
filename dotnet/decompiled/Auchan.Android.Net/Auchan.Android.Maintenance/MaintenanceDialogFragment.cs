using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using AndroidX.Core.Text;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.AppConfigError;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Helpers;
using DryIoc;

namespace Auchan.Android.Maintenance;

internal class MaintenanceDialogFragment : BaseDialogFragment<MaintenanceViewModel>
{
	protected override int LayoutId => 2131493021;

	public MaintenanceDialogFragment(Func<MaintenanceViewModel.Parameter?, MaintenanceViewModel> newViewModel)
		: base((Func<Fragment, MaintenanceViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.NavParam<MaintenanceViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		MaintenanceControls controls = new MaintenanceControls(view);
		controls.Title.Text = base.ViewModel.Title;
		controls.Message.Text = base.ViewModel.Message;
		controls.RetryButton.Text = base.ViewModel.ButtonText;
		controls.QrCodeButton.Text = base.ViewModel.QRCodeButtonText;
		controls.InfoTextView.TextFormatted = HtmlCompat.FromHtml(base.ViewModel.MaintenanceInfoText, 0);
		controls.QrCodeButton.Visibility = base.ViewModel.IsQRCodeButtonVisible.ToVisibility();
		Cancelable = false;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			controls.InfoView.Visibility = base.ViewModel.IsMaintenanceInfoAvailable.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsMaintenanceInfoAvailable")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.RetryButton.OnClick(base.ViewModel.OnActionClick), controls.QrCodeButton.OnClick(base.ViewModel.OnQRCodeClick), controls.InfoView.OnClick(base.ViewModel.OnInformerClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnCloseCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			OnClose();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OnQRCodeCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			OnQRCode();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void OnClose()
	{
		Dismiss();
	}

	private void OnQRCode()
	{
		LoyaltyCardPdf417PortraitFragment loyaltyCardPdf417PortraitFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<LoyaltyCardPdf417PortraitFragment>();
		loyaltyCardPdf417PortraitFragment.Show(base.ParentFragmentManager, loyaltyCardPdf417PortraitFragment.Tag);
	}
}
