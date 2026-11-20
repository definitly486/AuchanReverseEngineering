using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.Maintenance;
using Auchan.Android.SafeEntrance;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.SafeEntrance.Managers;
using Auchan.Common.Splash;
using DryIoc;
using IO.Appmetrica.Analytics;
using VisibilitySwitch;

namespace Auchan.Android;

[Activity(Name = "ru.myauchan.droid.StartActivity", Label = "@string/app_name", Theme = "@style/AppTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = false, LaunchMode = LaunchMode.SingleTask, Exported = true)]
[IntentFilter(new string[] { "ACTION_XE_APP_ACTION" }, Categories = new string[] { "android.intent.category.DEFAULT" })]
[IntentFilter(new string[] { "android.intent.action.VIEW" }, AutoVerify = true, Categories = new string[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" }, DataSchemes = new string[] { "https", "http" }, DataHosts = new string[] { "mlink.auchan.ru", "auchan.ru", "www.auchan.ru", "4431094.redirect.appmetrica.yandex.com" })]
[IntentFilter(new string[] { "android.intent.action.VIEW" }, Categories = new string[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" }, DataSchemes = new string[] { "vk54269263" }, DataHosts = new string[] { "vk.com" })]
[IntentFilter(new string[] { "android.intent.action.VIEW" }, Categories = new string[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" }, DataSchemes = new string[] { "auchan" })]
internal class StartActivity : BaseActivity
{
	private sealed class Controls
	{
		public sealed class QrCodeControls(View view)
		{
			public View View => view;

			public LinearLayout LayoutWithCode { get; } = view.RequireViewById<LinearLayout>(2131296909);

			public SkottieAnimationView Animation { get; } = view.RequireViewById<SkottieAnimationView>(2131298408);

			public ImageView Image { get; } = view.RequireViewById<ImageView>(2131298127);

			public TextView Text { get; } = view.RequireViewById<TextView>(2131298620);

			public TextView LoyaltyCardSubText { get; } = view.RequireViewById<TextView>(2131297492);
		}

		public sealed class ErrorControls(View view)
		{
			public View View => view;

			public ImageView Image { get; } = view.RequireViewById<ImageView>(2131297308);

			public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

			public TextView Message { get; } = view.RequireViewById<TextView>(2131297563);

			public Button RetryButton { get; } = view.RequireViewById<Button>(2131296325);

			public Button QrCodeButton { get; } = view.RequireViewById<Button>(2131298126);

			public View CloseButton { get; } = view.RequireViewById<View>(2131296795);
		}

		public QrCodeControls QrCode { get; } = new QrCodeControls(activity.RequireViewById<View>(2131296341));

		public ErrorControls Error { get; } = new ErrorControls(activity.RequireViewById<View>(2131297118));

		public MaintenanceControls Maintenance { get; } = new MaintenanceControls(activity.RequireViewById<View>(2131297510));

		public Controls(Activity activity)
		{
		}
	}

	public static bool WasLaunched { get; private set; }

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		DroidRestartService.CheckBundleAndRestartIfNeed(savedInstanceState);
		SplashViewModel vm = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<SplashViewModel>();
		vm.OpenMainScreenCommand.SafeSubscribe(GoToMainActivity, this);
		vm.OpenQRCodeCommand.SafeSubscribe(OpenQRCode, this);
		vm.OpenSafeEntranceScreenCommand.SafeSubscribe(OpenEnterPinCode, this);
		SaveIntentForHandling((Intent != null) ? new Intent(Intent) : null);
		DoStart(vm).SafeFireAndForget((Action<Exception>)null, false);
		int layoutId = 2131492903;
		SetLayoutId(layoutId);
		base.OnCreate(savedInstanceState);
		if (savedInstanceState == null)
		{
			AppMetrica.ReportAppOpen(this);
		}
		WasLaunched = true;
		Window.AddFlags(WindowManagerFlags.LayoutInScreen | WindowManagerFlags.LayoutNoLimits);
		Controls controls = new Controls(this);
		if (vm.IsCustomSplashAnimationEnabled)
		{
			controls.QrCode.Animation.FromUrl(vm.CustomSplashAnimationUrl);
			controls.QrCode.Animation.Visibility = ViewStates.Visible;
			controls.QrCode.LayoutWithCode.BringToFront();
		}
		controls.Error.QrCodeButton.Text = vm.QRCodeButtonText;
		controls.Error.CloseButton.Visibility = ViewStates.Gone;
		controls.Maintenance.QrCodeButton.Text = vm.QRCodeButtonText;
		VisibilitySwitch<SplashViewModel.VisualState> @switch = new VisibilitySwitch<SplashViewModel.VisualState>(SplashViewModel.VisualState.Default)
		{
			{
				SplashViewModel.VisualState.Default,
				controls.QrCode.View
			},
			{
				SplashViewModel.VisualState.Error,
				controls.Error.View
			},
			{
				SplashViewModel.VisualState.Maintenance,
				controls.Maintenance.View
			}
		};
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[12]
		{
			(delegate
			{
				@switch.State = vm.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetQrCode(vm.QrCode, controls, vm);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QrCode")),
			(delegate
			{
				controls.Error.RetryButton.Text = vm.RetryButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RetryButtonText")),
			(delegate
			{
				controls.Error.QrCodeButton.Visibility = vm.IsQRCodeButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsQRCodeButtonVisible")),
			(delegate
			{
				controls.Error.Title.Text = vm.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				controls.Error.Message.Text = vm.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				controls.Maintenance.RetryButton.Text = vm.RetryButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RetryButtonText")),
			(delegate
			{
				controls.Maintenance.QrCodeButton.Visibility = vm.IsQRCodeButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsQRCodeButtonVisible")),
			(delegate
			{
				controls.Maintenance.Title.Text = vm.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				controls.Maintenance.InfoView.Visibility = vm.IsMaintenanceInfoAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsMaintenanceInfoAvailable")),
			(delegate
			{
				controls.Maintenance.Message.Text = vm.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				OnMaintenanceInfoTextChanged(controls, vm.MaintenanceInfoText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MaintenanceInfoText"))
		})).AutoDisposeOnDestroy(this);
		vm.BindEvents(controls.Error.RetryButton.OnClick(vm.OnRetryClick), controls.Error.QrCodeButton.OnClick(vm.OnQRCodeClick), controls.Maintenance.RetryButton.OnClick(vm.OnRetryClick), controls.Maintenance.QrCodeButton.OnClick(vm.OnQRCodeClick), controls.Maintenance.InfoView.OnClick(vm.OnInformerClick)).AutoDisposeOnDestroy(this);
		Task DoStart(SplashViewModel splashViewModel)
		{
			return Task.WhenAll(splashViewModel.DoStart(this), splashViewModel.DoResume());
		}
	}

	protected override void OnNewIntent(Intent? intent)
	{
		base.OnNewIntent(intent);
		AppMetrica.ReportAppOpen(intent);
	}

	private void OnMaintenanceInfoTextChanged(Controls controls, string maintenanceInfoText)
	{
		controls.Maintenance.InfoTextView.TextFormatted = HtmlCompat.FromHtml(maintenanceInfoText, 0);
	}

	protected override void OnStop()
	{
		base.OnStop();
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ISafeEntranceManager>().MarkBackgroundTransitionForSafeEntrance();
	}

	private void SetQrCode(string qrCode, Controls controls, SplashViewModel vm)
	{
		if (!vm.IsQrCodeEmpty)
		{
			controls.QrCode.LoyaltyCardSubText.Text = ((Converter.PxToDp(Resources?.DisplayMetrics?.HeightPixels ?? int.MaxValue) <= 640) ? vm.LoyaltyCardSubTextForSmallDisplays : vm.LoyaltyCardSubText);
			controls.QrCode.Image.Visibility = ViewStates.Visible;
			controls.QrCode.Text.Visibility = ViewStates.Visible;
			controls.QrCode.LoyaltyCardSubText.Visibility = ViewStates.Visible;
			controls.QrCode.Image.SetPDF417Code(qrCode);
		}
	}

	private void OpenQRCode(Unit unit)
	{
		LoyaltyCardPdf417PortraitFragment loyaltyCardPdf417PortraitFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<LoyaltyCardPdf417PortraitFragment>();
		loyaltyCardPdf417PortraitFragment.Show(SupportFragmentManager, loyaltyCardPdf417PortraitFragment.Tag);
	}

	private void GoToMainActivity(Unit unit)
	{
		Intent intent = new Intent(this, typeof(MainActivity));
		intent.AddFlags(ActivityFlags.ClearTop);
		intent.AddFlags(ActivityFlags.NewTask);
		StartActivity(intent);
		Finish();
	}

	private void OpenEnterPinCode(Unit unit)
	{
		SafeEntranceHelper.OpenEnterPinPageFromSplash(this);
		Finish();
	}
}
