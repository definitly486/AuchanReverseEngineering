using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using AndroidX.Camera.Core;
using Com.Scanflow.Datacapture.Config;
using Google.Android.Material.Slider;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Core.Camera;

[Register("com/scanflow/datacapture/core/camera/ScanflowReader", DoNotGenerateAcw = true)]
internal class ScanflowReaderInvoker : ScanflowReader
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/core/camera/ScanflowReader", typeof(ScanflowReaderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override ICamera Camera
	{
		[Register("getCamera", "()Landroidx/camera/core/Camera;", "GetGetCameraHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICamera>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCamera.()Landroidx/camera/core/Camera;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override bool HasFlashUnit
	{
		[Register("hasFlashUnit", "()Z", "GetHasFlashUnitHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasFlashUnit.()Z", this, null);
		}
	}

	public unsafe override bool IsTorchEnabled
	{
		[Register("isTorchEnabled", "()Z", "GetIsTorchEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isTorchEnabled.()Z", this, null);
		}
	}

	public ScanflowReaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("bindFlashlightView", "(Landroid/view/View;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetBindFlashlightView_Landroid_view_View_Handler")]
	public unsafe override ScanflowReader BindFlashlightView(View v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("bindFlashlightView.(Landroid/view/View;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("bindSliderView", "(Lcom/google/android/material/slider/Slider;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetBindSliderView_Lcom_google_android_material_slider_Slider_Handler")]
	public unsafe override ScanflowReader BindSliderView(Slider v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("bindSliderView.(Lcom/google/android/material/slider/Slider;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("captureBatchInventory", "()V", "GetCaptureBatchInventoryHandler")]
	public unsafe override void CaptureBatchInventory()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("captureBatchInventory.()V", this, null);
	}

	[Register("captureToScan", "()V", "GetCaptureToScanHandler")]
	public unsafe override void CaptureToScan()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("captureToScan.()V", this, null);
	}

	[Register("doValidateLicense", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetDoValidateLicenseHandler")]
	public unsafe override ScanflowReader DoValidateLicense()
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("doValidateLicense.()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("doValidateLicenseWithRetry", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetDoValidateLicenseWithRetryHandler")]
	public unsafe override ScanflowReader DoValidateLicenseWithRetry()
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("doValidateLicenseWithRetry.()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("enableSplitView", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetEnableSplitView_ZHandler")]
	public unsafe override ScanflowReader EnableSplitView(bool enableSplitView)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableSplitView);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableSplitView.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("enableTouchZoom", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetEnableTouchZoom_ZHandler")]
	public unsafe override ScanflowReader EnableTouchZoom(bool enableTouchZoom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableTouchZoom);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableTouchZoom.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("performOneTouchClick", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetPerformOneTouchClickHandler")]
	public unsafe override ScanflowReader PerformOneTouchClick()
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("performOneTouchClick.()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("resetOneToManyCodes", "()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetResetOneToManyCodesHandler")]
	public unsafe override ScanflowReader ResetOneToManyCodes()
	{
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("resetOneToManyCodes.()Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setAutoExposure", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoExposure_ZHandler")]
	public unsafe override ScanflowReader SetAutoExposure(bool autoExposure)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(autoExposure);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAutoExposure.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setAutoFlashlight", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoFlashlight_ZHandler")]
	public unsafe override ScanflowReader SetAutoFlashlight(bool autoFlash)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(autoFlash);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAutoFlashlight.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setAutoZoom", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetAutoZoom_ZHandler")]
	public unsafe override ScanflowReader SetAutoZoom(bool autoZoom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(autoZoom);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAutoZoom.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setBeepSoundResource", "(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetBeepSoundResource_IHandler")]
	public unsafe override ScanflowReader SetBeepSoundResource(int beepSoundResource)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(beepSoundResource);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBeepSoundResource.(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setCameraResolution", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetCameraResolution_Lcom_scanflow_datacapture_core_camera_ScanflowReader_CameraResolutionConfig_Handler")]
	public unsafe override ScanflowReader SetCameraResolution(CameraResolutionConfig size)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(size?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCameraResolution.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(size);
		}
	}

	[Register("setEchanceTextCount", "(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEchanceTextCount_IHandler")]
	public unsafe override ScanflowReader SetEchanceTextCount(int echanceTextCount)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(echanceTextCount);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEchanceTextCount.(I)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setEnableDataTracking", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableDataTracking_ZHandler")]
	public unsafe override ScanflowReader SetEnableDataTracking(bool isDataTracking)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isDataTracking);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnableDataTracking.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setEnableLocationTracking", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableLocationTracking_ZHandler")]
	public unsafe override ScanflowReader SetEnableLocationTracking(bool enableLocationTracking)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableLocationTracking);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnableLocationTracking.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setEnableTireAngleDetection", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableTireAngleDetection_ZHandler")]
	public unsafe override ScanflowReader SetEnableTireAngleDetection(bool enableTireAngleDetection)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableTireAngleDetection);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnableTireAngleDetection.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setEnableTirePreProcessing", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnableTirePreProcessing_ZHandler")]
	public unsafe override ScanflowReader SetEnableTirePreProcessing(bool enableTirePreProcessing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableTirePreProcessing);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnableTirePreProcessing.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setEnhanceTextResult", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetEnhanceTextResult_ZHandler")]
	public unsafe override ScanflowReader SetEnhanceTextResult(bool isEnhanceTextResult)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isEnhanceTextResult);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnhanceTextResult.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setIsBatchScanning", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetIsBatchScanning_ZHandler")]
	public unsafe override ScanflowReader SetIsBatchScanning(bool isBatchScanning)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isBatchScanning);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIsBatchScanning.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setIsContinuousScan", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetIsContinuousScan_ZHandler")]
	public unsafe override ScanflowReader SetIsContinuousScan(bool isContinuousScan)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isContinuousScan);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIsContinuousScan.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOnBarcodeScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnBarcodeScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnBarcodeScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnBarcodeScanResultCallback(IOnBarcodeScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnBarcodeScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnBarcodeScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnCameraResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnCameraResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnCameraResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnCameraResultCallback(IOnCameraResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnCameraResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnCameraResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnIDCardScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnIDCardScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnIDCardScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnIDCardScanResultCallback(IOnIDCardScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnIDCardScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnIDCardScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnLicenseValidationCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnLicenseValidationCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnLicenseValidationCallback_Handler")]
	public unsafe override ScanflowReader SetOnLicenseValidationCallback(IOnLicenseValidationCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnLicenseValidationCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnLicenseValidationCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnOneTouchCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnOneTouchCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnOneTouchCallback_Handler")]
	public unsafe override ScanflowReader SetOnOneTouchCallback(IOnOneTouchCallback onOneTouchCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onOneTouchCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)onOneTouchCallback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnOneTouchCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(onOneTouchCallback);
		}
	}

	[Register("setOnTextComponentScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnTextComponentScanResultCallback(IOnTextComponentScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnTextComponentScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnTextComponentVinPlateScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentVinPlateScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinPlateScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnTextComponentVinPlateScanResultCallback(IOnTextComponentVinPlateScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnTextComponentVinPlateScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinPlateScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnTextComponentVinStickerScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextComponentVinStickerScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextComponentVinStickerScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnTextComponentVinStickerScanResultCallback(IOnTextComponentVinStickerScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnTextComponentVinStickerScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextComponentVinStickerScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnTextScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnTextScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnTextScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnTextScanResultCallback(IOnTextScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnTextScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnTextScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOnWebServiceScanResultCallback", "(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOnWebServiceScanResultCallback_Lcom_scanflow_datacapture_core_camera_ScanflowReader_OnWebServiceScanResultCallback_Handler")]
	public unsafe override ScanflowReader SetOnWebServiceScanResultCallback(IOnWebServiceScanResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnWebServiceScanResultCallback.(Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnWebServiceScanResultCallback;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setOneToManyCodes", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOneToManyCodes_ZHandler")]
	public unsafe override ScanflowReader SetOneToManyCodes(bool enableOnetoManyCodes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enableOnetoManyCodes);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOneToManyCodes.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOneToManyCodesKeepCurrent", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetOneToManyCodesKeepCurrent_ZHandler")]
	public unsafe override ScanflowReader SetOneToManyCodesKeepCurrent(bool oneOfManyKeepCurrent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(oneOfManyKeepCurrent);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOneToManyCodesKeepCurrent.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setPlayBeep", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetPlayBeep_ZHandler")]
	public unsafe override ScanflowReader SetPlayBeep(bool playBeep)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(playBeep);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPlayBeep.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setQrBarcodeDetection", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetQrBarcodeDetection_ZHandler")]
	public unsafe override ScanflowReader SetQrBarcodeDetection(bool isQrBarcodeDetection)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isQrBarcodeDetection);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setQrBarcodeDetection.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setSwitchCategory", "(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetSwitchCategory_Ljava_lang_String_Handler")]
	public unsafe override ScanflowReader SetSwitchCategory(string switchCategory)
	{
		nint num = JNIEnv.NewString(switchCategory);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSwitchCategory.(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("setVibrate", "(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetVibrate_ZHandler")]
	public unsafe override ScanflowReader SetVibrate(bool vibrate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(vibrate);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVibrate.(Z)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setVinNumberColor", "(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetSetVinNumberColor_Lcom_scanflow_datacapture_config_VinNumberColorConfig_Handler")]
	public unsafe override ScanflowReader SetVinNumberColor(VinNumberColorConfig selectedVinNumberColorConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(selectedVinNumberColorConfig?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVinNumberColor.(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(selectedVinNumberColorConfig);
		}
	}

	[Register("updateConfidenceValue", "(F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", "GetUpdateConfidenceValue_FHandler")]
	public unsafe override ScanflowReader UpdateConfidenceValue(float confidence)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(confidence);
		return Java.Lang.Object.GetObject<ScanflowReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("updateConfidenceValue.(F)Lcom/scanflow/datacapture/core/camera/ScanflowReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("release", "()V", "GetReleaseHandler")]
	public unsafe override void Release()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("release.()V", this, null);
	}

	[Register("startCamera", "()V", "GetStartCameraHandler")]
	public unsafe override void StartCamera()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("startCamera.()V", this, null);
	}

	[Register("stopCamera", "()V", "GetStopCameraHandler")]
	public unsafe override void StopCamera()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("stopCamera.()V", this, null);
	}

	[Register("enableTorch", "(Z)V", "GetEnableTorch_ZHandler")]
	public unsafe override void EnableTorch(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeAbstractVoidMethod("enableTorch.(Z)V", this, ptr);
	}

	[Register("lineZoomIn", "()V", "GetLineZoomInHandler")]
	public unsafe override void LineZoomIn()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("lineZoomIn.()V", this, null);
	}

	[Register("lineZoomOut", "()V", "GetLineZoomOutHandler")]
	public unsafe override void LineZoomOut()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("lineZoomOut.()V", this, null);
	}

	[Register("lineZoomTo", "(F)V", "GetLineZoomTo_FHandler")]
	public unsafe override void LineZoomTo(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeAbstractVoidMethod("lineZoomTo.(F)V", this, ptr);
	}

	[Register("zoomIn", "()V", "GetZoomInHandler")]
	public unsafe override void ZoomIn()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("zoomIn.()V", this, null);
	}

	[Register("zoomOut", "()V", "GetZoomOutHandler")]
	public unsafe override void ZoomOut()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("zoomOut.()V", this, null);
	}

	[Register("zoomTo", "(F)V", "GetZoomTo_FHandler")]
	public unsafe override void ZoomTo(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeAbstractVoidMethod("zoomTo.(F)V", this, ptr);
	}
}
