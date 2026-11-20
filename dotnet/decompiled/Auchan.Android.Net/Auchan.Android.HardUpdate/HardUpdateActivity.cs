using System;
using System.Reactive.Linq;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.HardUpdate;
using Auchan.Common.Helpers;
using DryIoc;

namespace Auchan.Android.HardUpdate;

[Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, WindowSoftInputMode = SoftInput.AdjustPan)]
internal class HardUpdateActivity : BaseActivity
{
	public const string BundleKey = "bundle";

	public const string MessageKey = "message";

	protected override int? LayoutId => 2131493127;

	protected override bool ShouldProcessIntent => false;

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Func<HardUpdateViewModel.Parameter, HardUpdateViewModel> func = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Func<HardUpdateViewModel.Parameter, HardUpdateViewModel>>();
		string message = Intent?.GetBundleExtra("bundle")?.GetString("message") ?? "";
		HardUpdateViewModel hardUpdateViewModel = func(new HardUpdateViewModel.Parameter(message));
		TextView textView = RequireViewById<TextView>(2131297259);
		TextView textView2 = RequireViewById<TextView>(2131297257);
		AppCompatButton appCompatButton = RequireViewById<AppCompatButton>(2131297261);
		AppCompatButton appCompatButton2 = RequireViewById<AppCompatButton>(2131297260);
		textView.Text = hardUpdateViewModel.HardUpdateMessageText;
		textView.SetTypeface(null, TypefaceStyle.Bold);
		textView2.Text = hardUpdateViewModel.HardUpdateHintText;
		appCompatButton2.Visibility = hardUpdateViewModel.IsShowQrCodeVisible.ToVisibility();
		hardUpdateViewModel.ShowQrCodeClickCommand.ObserveOn(MainThread.Scheduler).Subscribe(OpenQrCode).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		hardUpdateViewModel.BindEvents(appCompatButton.OnClick(hardUpdateViewModel.UpdateClick), appCompatButton2.OnClick(hardUpdateViewModel.ShowQrCodeClick)).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void OpenQrCode(string qrCode)
	{
		LoyaltyCardPdf417PortraitFragment loyaltyCardPdf417PortraitFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<LoyaltyCardPdf417PortraitFragment>();
		loyaltyCardPdf417PortraitFragment.Show(SupportFragmentManager, loyaltyCardPdf417PortraitFragment.Tag);
	}
}
