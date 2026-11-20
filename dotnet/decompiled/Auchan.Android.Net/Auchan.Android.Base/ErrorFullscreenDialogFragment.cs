using System;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Helpers;
using DryIoc;

namespace Auchan.Android.Base;

internal class ErrorFullscreenDialogFragment : BaseDialogFragment<ErrorFullscreenViewModel>
{
	protected override int LayoutId => 2131492975;

	public ErrorFullscreenDialogFragment(Func<ErrorFullscreenViewModel.Parameter, ErrorFullscreenViewModel> newViewModel)
		: base((Func<Fragment, ErrorFullscreenViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ErrorFullscreenViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131297563);
		Button button = view.RequireViewById<Button>(2131296325);
		Button button2 = view.RequireViewById<Button>(2131298126);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		button.Text = base.ViewModel.ButtonText;
		button2.Text = base.ViewModel.QRCodeButtonText;
		button.Visibility = base.ViewModel.IsActionButtonVisible.ToVisibility();
		imageView.Visibility = base.ViewModel.IsCloseButtonVisible.ToVisibility();
		button2.Visibility = base.ViewModel.IsQRCodeButtonVisible.ToVisibility();
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnNextCommand.Trigger), button2.OnClick(base.ViewModel.OnQRCodeCommand.Trigger), imageView.OnClick(base.ViewModel.OnCloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnCloseCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			OnClose();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OnNextCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			OnNext();
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

	private void OnNext()
	{
		Dismiss();
	}

	private void OnQRCode()
	{
		LoyaltyCardPdf417PortraitFragment loyaltyCardPdf417PortraitFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<LoyaltyCardPdf417PortraitFragment>();
		loyaltyCardPdf417PortraitFragment.Show(base.ParentFragmentManager, loyaltyCardPdf417PortraitFragment.Tag);
	}
}
