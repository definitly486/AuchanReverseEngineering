using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.BarcodeScanner;
using Auchan.Common.Base;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Com.Scanflow.Datacapture.Barcode;
using Com.Scanflow.Datacapture.Barcode.Config;
using Com.Scanflow.Datacapture.Core.Camera;
using Com.Scanflow.Datacapture.Model;
using Com.Scanflow.Datacapture.Sfbarcode;
using Java.Interop;
using Java.Util;

namespace Auchan.Android.Ecom.PriceChecker;

internal abstract class BaseScannerFragment<T> : BaseFragment<T>, ScanflowReader.IOnBarcodeScanResultCallback, IJavaObject, IDisposable, IJavaPeerable, ScanflowReader.IOnLicenseValidationCallback where T : ScreenViewModel, IScannerViewModel
{
	private const string LogcatTag = "ScannerFragment";

	private const string FILE_NAME = "0d655abdbfa48a625dce13fe37b7b681c043e10f";

	private ImageView _cancelButton;

	protected TextView HeaderTextView { get; private set; }

	protected TextView SubHeaderTextView { get; private set; }

	protected SFCameraView? CameraView { get; private set; }

	protected ScanflowReader? BarcodeReader { get; private set; }

	protected BaseScannerFragment(Func<Fragment, T> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		RequireActivity().OnBackPressedDispatcher.AddCallback(this, OnBack);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		CameraView = view.RequireViewById<SFCameraView>(2131296611);
		HeaderTextView = view.RequireViewById<TextView>(2131297269);
		SubHeaderTextView = view.RequireViewById<TextView>(2131298545);
		_cancelButton = view.RequireViewById<ImageView>(2131296791);
		base.ViewModel.BindEvents(_cancelButton.OnClick(OnClose)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		BarcodeReader = CreateScanner();
		base.ViewModel.OnPropertyChanges((T p) => p.ScannerState).StartWith(base.ViewModel.ScannerState).ObserveOn(MainThread.Scheduler)
			.Subscribe(SetScannerState)
			.AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		if (BarcodeReader == null)
		{
			ShowAlert(new UserMessage
			{
				Title = "Ошибка",
				Message = "Не получается запустить сканер"
			});
		}
	}

	private ScanflowReader? CreateScanner()
	{
		try
		{
			return DoCreateScanner();
		}
		catch (Exception ex)
		{
			base.ViewModel.OnPlatformError("create scanner first attempt", ex);
			TryToMitigateScanflowInitializationIssue();
			try
			{
				return DoCreateScanner();
			}
			catch (Exception ex2)
			{
				base.ViewModel.OnPlatformError("create scanner second attempt", ex2);
				return null;
			}
		}
		ScanflowReader DoCreateScanner()
		{
			ScanflowReader scanflowReader = SFBarcodeCaptureSession.Instance.CreateScanSession(RequireActivity(), "0d655abdbfa48a625dce13fe37b7b681c043e10f", CameraView, BarcodeTypeToConfig(base.ViewModel.BarcodeType), 0.4f);
			scanflowReader.SetOnLicenseValidationCallback(this);
			scanflowReader.SetOnBarcodeScanResultCallback(this);
			scanflowReader.SetEnableLocationTracking(enableLocationTracking: false);
			scanflowReader.SetPlayBeep(playBeep: false);
			scanflowReader.SetVibrate(vibrate: false);
			scanflowReader.SetIsBatchScanning(isBatchScanning: false);
			scanflowReader.SetAutoFlashlight(autoFlash: false);
			return scanflowReader;
		}
		void TryToMitigateScanflowInitializationIssue()
		{
			try
			{
				Context.DeleteSharedPreferences("0d655abdbfa48a625dce13fe37b7b681c043e10f");
			}
			catch (Exception ex3)
			{
				base.ViewModel.OnPlatformError("mitigate scanflow exception error", ex3);
			}
		}
	}

	protected virtual void OnBack()
	{
		OnClose();
	}

	public override void OnStart()
	{
		base.OnStart();
		FragmentActivity activity = base.Activity;
		if (activity is AppCompatActivity appCompatActivity && activity.Window != null)
		{
			appCompatActivity.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
		}
	}

	public override void OnStop()
	{
		base.OnStop();
		if (base.Activity is AppCompatActivity appCompatActivity)
		{
			appCompatActivity.Window?.ClearFlags(WindowManagerFlags.KeepScreenOn);
		}
	}

	protected virtual void OnTorch()
	{
		BarcodeReader?.EnableTorch(!BarcodeReader.IsTorchEnabled);
	}

	protected virtual void OnClose()
	{
		if (base.IsAdded)
		{
			base.ParentFragmentManager.PopBackStack(null, 1);
		}
	}

	protected virtual void ShowAlert(UserMessage message)
	{
		new AlertDialog.Builder(Context)?.SetTitle(message.Title)?.SetMessage(message.Message)?.SetPositiveButton("OK", delegate
		{
			base.ViewModel.OnDialogErrorOkClicked();
		})?.SetCancelable(cancelable: false)?.Create().SetCanceledOnTouchOutsideBuilder(cancel: false).ShowCentered();
	}

	protected void SetScannerState(ScannerState scannerState)
	{
		if (scannerState == ScannerState.Enabled)
		{
			BarcodeReader?.StartCamera();
		}
		else
		{
			BarcodeReader?.StopCamera();
		}
	}

	private DecodeConfig BarcodeTypeToConfig(BarcodeType barcodeType)
	{
		switch (barcodeType)
		{
		case BarcodeType.Ean8:
		case BarcodeType.Ean13:
			return DecodeConfig.Barcode;
		case BarcodeType.Qr:
			return DecodeConfig.Qrcode;
		default:
			return DecodeConfig.Any;
		}
	}

	public void OnScanResultSuccess(ScanResultSuccess result)
	{
		base.ViewModel.BarcodeResultCommand.Trigger(result.Text);
	}

	public void OnBatchScanResultSuccess(IList<ScanResultSuccess> result)
	{
	}

	public void OnOneOfManyCodeResult(HashSet results)
	{
	}

	public void OnOneofManyCodeRemoved(OneOFManyCodesScanResults result)
	{
	}

	public void OnOneofManyCodeSelected(OneOFManyCodesScanResults result)
	{
	}

	public void OnScanBarcodeDetection(bool isDetected)
	{
	}

	public void OnScanResultFailure(string error)
	{
	}

	public void OnLicenseFailure(string error)
	{
		BarcodeReader?.DoValidateLicenseWithRetry();
	}

	public void OnLicenseSuccess(string result)
	{
	}
}
