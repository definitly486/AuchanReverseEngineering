using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core;
using AndroidX.Camera.Core.ResolutionSelector;
using AndroidX.Camera.Video;
using AndroidX.Camera.View.Internal;
using AndroidX.Camera.View.Video;
using AndroidX.Core.Util;
using AndroidX.Lifecycle;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.View;

[Register("androidx/camera/view/CameraController", DoNotGenerateAcw = true)]
public abstract class CameraController : Java.Lang.Object
{
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("androidx/camera/view/CameraController$OutputSize", DoNotGenerateAcw = true)]
	public sealed class OutputSize : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/CameraController$OutputSize", typeof(OutputSize));

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int AspectRatio
		{
			[Register("getAspectRatio", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getAspectRatio.()I", this, null);
			}
		}

		public unsafe Size? Resolution
		{
			[Register("getResolution", "()Landroid/util/Size;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal OutputSize(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/util/Size;)V", "")]
		public unsafe OutputSize(Size resolution)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(resolution);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe OutputSize(int aspectRatio)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(aspectRatio);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/CameraController", typeof(CameraController));

	private static Delegate? cb_getCameraControl;

	private static Delegate? cb_getCameraInfo;

	private static Delegate? cb_getCameraSelector;

	private static Delegate? cb_setCameraSelector_Landroidx_camera_core_CameraSelector_;

	private static Delegate? cb_getImageAnalysisBackgroundExecutor;

	private static Delegate? cb_setImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_;

	private static Delegate? cb_getImageAnalysisBackpressureStrategy;

	private static Delegate? cb_setImageAnalysisBackpressureStrategy_I;

	private static Delegate? cb_getImageAnalysisImageQueueDepth;

	private static Delegate? cb_setImageAnalysisImageQueueDepth_I;

	private static Delegate? cb_getImageAnalysisOutputImageFormat;

	private static Delegate? cb_setImageAnalysisOutputImageFormat_I;

	private static Delegate? cb_getImageAnalysisResolutionSelector;

	private static Delegate? cb_setImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;

	private static Delegate? cb_getImageAnalysisTargetSize;

	private static Delegate? cb_setImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_;

	private static Delegate? cb_getImageCaptureFlashMode;

	private static Delegate? cb_setImageCaptureFlashMode_I;

	private static Delegate? cb_getImageCaptureIoExecutor;

	private static Delegate? cb_setImageCaptureIoExecutor_Ljava_util_concurrent_Executor_;

	private static Delegate? cb_getImageCaptureMode;

	private static Delegate? cb_setImageCaptureMode_I;

	private static Delegate? cb_getImageCaptureResolutionSelector;

	private static Delegate? cb_setImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;

	private static Delegate? cb_getImageCaptureTargetSize;

	private static Delegate? cb_setImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_;

	private static Delegate? cb_getInitializationFuture;

	private static Delegate? cb_isImageAnalysisEnabled;

	private static Delegate? cb_isImageCaptureEnabled;

	private static Delegate? cb_isRecording;

	private static Delegate? cb_isVideoCaptureEnabled;

	private static Delegate? cb_isPinchToZoomEnabled;

	private static Delegate? cb_setPinchToZoomEnabled_Z;

	private static Delegate? cb_getPreviewDynamicRange;

	private static Delegate? cb_setPreviewDynamicRange_Landroidx_camera_core_DynamicRange_;

	private static Delegate? cb_getPreviewResolutionSelector;

	private static Delegate? cb_setPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;

	private static Delegate? cb_getPreviewTargetSize;

	private static Delegate? cb_setPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_;

	private static Delegate? cb_getScreenFlashUiInfoByPriority;

	private static Delegate? cb_isTapToFocusEnabled;

	private static Delegate? cb_setTapToFocusEnabled_Z;

	private static Delegate? cb_getTapToFocusState;

	private static Delegate? cb_getTorchState;

	private static Delegate? cb_getVideoCaptureDynamicRange;

	private static Delegate? cb_setVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_;

	private static Delegate? cb_getVideoCaptureMirrorMode;

	private static Delegate? cb_setVideoCaptureMirrorMode_I;

	private static Delegate? cb_getVideoCaptureQualitySelector;

	private static Delegate? cb_setVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_;

	private static Delegate? cb_getVideoCaptureTargetFrameRate;

	private static Delegate? cb_setVideoCaptureTargetFrameRate_Landroid_util_Range_;

	private static Delegate? cb_getZoomState;

	private static Delegate? cb_clearEffects;

	private static Delegate? cb_clearImageAnalysisAnalyzer;

	private static Delegate? cb_createUseCaseGroup;

	private static Delegate? cb_enableTorch_Z;

	private static Delegate? cb_hasCamera_Landroidx_camera_core_CameraSelector_;

	private static Delegate? cb_setEffects_Ljava_util_Set_;

	private static Delegate? cb_setEnabledUseCases_I;

	private static Delegate? cb_setImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_;

	private static Delegate? cb_setLinearZoom_F;

	private static Delegate? cb_setScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_;

	private static Delegate? cb_setZoomRatio_F;

	private static Delegate? cb_startRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;

	private static Delegate? cb_startRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;

	private static Delegate? cb_startRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;

	private static Delegate? cb_takePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_;

	private static Delegate? cb_takePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_;

	private static Delegate? cb_updateScreenFlashToImageCapture;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual ICameraControl? CameraControl
	{
		[Register("getCameraControl", "()Landroidx/camera/core/CameraControl;", "GetGetCameraControlHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraControl>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraControl.()Landroidx/camera/core/CameraControl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICameraInfo? CameraInfo
	{
		[Register("getCameraInfo", "()Landroidx/camera/core/CameraInfo;", "GetGetCameraInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraInfo.()Landroidx/camera/core/CameraInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CameraSelector CameraSelector
	{
		[Register("getCameraSelector", "()Landroidx/camera/core/CameraSelector;", "GetGetCameraSelectorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CameraSelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraSelector.()Landroidx/camera/core/CameraSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCameraSelector", "(Landroidx/camera/core/CameraSelector;)V", "GetSetCameraSelector_Landroidx_camera_core_CameraSelector_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCameraSelector.(Landroidx/camera/core/CameraSelector;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual IExecutor? ImageAnalysisBackgroundExecutor
	{
		[Register("getImageAnalysisBackgroundExecutor", "()Ljava/util/concurrent/Executor;", "GetGetImageAnalysisBackgroundExecutorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageAnalysisBackgroundExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageAnalysisBackgroundExecutor", "(Ljava/util/concurrent/Executor;)V", "GetSetImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisBackgroundExecutor.(Ljava/util/concurrent/Executor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ImageAnalysisBackpressureStrategy
	{
		[Register("getImageAnalysisBackpressureStrategy", "()I", "GetGetImageAnalysisBackpressureStrategyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageAnalysisBackpressureStrategy.()I", this, null);
		}
		[Register("setImageAnalysisBackpressureStrategy", "(I)V", "GetSetImageAnalysisBackpressureStrategy_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisBackpressureStrategy.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ImageAnalysisImageQueueDepth
	{
		[Register("getImageAnalysisImageQueueDepth", "()I", "GetGetImageAnalysisImageQueueDepthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageAnalysisImageQueueDepth.()I", this, null);
		}
		[Register("setImageAnalysisImageQueueDepth", "(I)V", "GetSetImageAnalysisImageQueueDepth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisImageQueueDepth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ImageAnalysisOutputImageFormat
	{
		[Register("getImageAnalysisOutputImageFormat", "()I", "GetGetImageAnalysisOutputImageFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageAnalysisOutputImageFormat.()I", this, null);
		}
		[Register("setImageAnalysisOutputImageFormat", "(I)V", "GetSetImageAnalysisOutputImageFormat_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisOutputImageFormat.(I)V", this, ptr);
		}
	}

	public unsafe virtual ResolutionSelector? ImageAnalysisResolutionSelector
	{
		[Register("getImageAnalysisResolutionSelector", "()Landroidx/camera/core/resolutionselector/ResolutionSelector;", "GetGetImageAnalysisResolutionSelectorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionSelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageAnalysisResolutionSelector.()Landroidx/camera/core/resolutionselector/ResolutionSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageAnalysisResolutionSelector", "(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", "GetSetImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisResolutionSelector.(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual OutputSize? ImageAnalysisTargetSize
	{
		[Register("getImageAnalysisTargetSize", "()Landroidx/camera/view/CameraController$OutputSize;", "GetGetImageAnalysisTargetSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageAnalysisTargetSize.()Landroidx/camera/view/CameraController$OutputSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageAnalysisTargetSize", "(Landroidx/camera/view/CameraController$OutputSize;)V", "GetSetImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisTargetSize.(Landroidx/camera/view/CameraController$OutputSize;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ImageCaptureFlashMode
	{
		[Register("getImageCaptureFlashMode", "()I", "GetGetImageCaptureFlashModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageCaptureFlashMode.()I", this, null);
		}
		[Register("setImageCaptureFlashMode", "(I)V", "GetSetImageCaptureFlashMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageCaptureFlashMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual IExecutor? ImageCaptureIoExecutor
	{
		[Register("getImageCaptureIoExecutor", "()Ljava/util/concurrent/Executor;", "GetGetImageCaptureIoExecutorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageCaptureIoExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageCaptureIoExecutor", "(Ljava/util/concurrent/Executor;)V", "GetSetImageCaptureIoExecutor_Ljava_util_concurrent_Executor_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageCaptureIoExecutor.(Ljava/util/concurrent/Executor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ImageCaptureMode
	{
		[Register("getImageCaptureMode", "()I", "GetGetImageCaptureModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageCaptureMode.()I", this, null);
		}
		[Register("setImageCaptureMode", "(I)V", "GetSetImageCaptureMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageCaptureMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual ResolutionSelector? ImageCaptureResolutionSelector
	{
		[Register("getImageCaptureResolutionSelector", "()Landroidx/camera/core/resolutionselector/ResolutionSelector;", "GetGetImageCaptureResolutionSelectorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionSelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageCaptureResolutionSelector.()Landroidx/camera/core/resolutionselector/ResolutionSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageCaptureResolutionSelector", "(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", "GetSetImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageCaptureResolutionSelector.(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual OutputSize? ImageCaptureTargetSize
	{
		[Register("getImageCaptureTargetSize", "()Landroidx/camera/view/CameraController$OutputSize;", "GetGetImageCaptureTargetSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageCaptureTargetSize.()Landroidx/camera/view/CameraController$OutputSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setImageCaptureTargetSize", "(Landroidx/camera/view/CameraController$OutputSize;)V", "GetSetImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageCaptureTargetSize.(Landroidx/camera/view/CameraController$OutputSize;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual IListenableFuture InitializationFuture
	{
		[Register("getInitializationFuture", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetInitializationFutureHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInitializationFuture.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsImageAnalysisEnabled
	{
		[Register("isImageAnalysisEnabled", "()Z", "GetIsImageAnalysisEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isImageAnalysisEnabled.()Z", this, null);
		}
	}

	public unsafe virtual bool IsImageCaptureEnabled
	{
		[Register("isImageCaptureEnabled", "()Z", "GetIsImageCaptureEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isImageCaptureEnabled.()Z", this, null);
		}
	}

	public unsafe virtual bool IsRecording
	{
		[Register("isRecording", "()Z", "GetIsRecordingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRecording.()Z", this, null);
		}
	}

	public unsafe virtual bool IsVideoCaptureEnabled
	{
		[Register("isVideoCaptureEnabled", "()Z", "GetIsVideoCaptureEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVideoCaptureEnabled.()Z", this, null);
		}
	}

	public unsafe virtual bool PinchToZoomEnabled
	{
		[Register("isPinchToZoomEnabled", "()Z", "GetIsPinchToZoomEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPinchToZoomEnabled.()Z", this, null);
		}
		[Register("setPinchToZoomEnabled", "(Z)V", "GetSetPinchToZoomEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPinchToZoomEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual DynamicRange PreviewDynamicRange
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getPreviewDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetPreviewDynamicRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviewDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setPreviewDynamicRange", "(Landroidx/camera/core/DynamicRange;)V", "GetSetPreviewDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewDynamicRange.(Landroidx/camera/core/DynamicRange;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ResolutionSelector? PreviewResolutionSelector
	{
		[Register("getPreviewResolutionSelector", "()Landroidx/camera/core/resolutionselector/ResolutionSelector;", "GetGetPreviewResolutionSelectorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionSelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviewResolutionSelector.()Landroidx/camera/core/resolutionselector/ResolutionSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPreviewResolutionSelector", "(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", "GetSetPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewResolutionSelector.(Landroidx/camera/core/resolutionselector/ResolutionSelector;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual OutputSize? PreviewTargetSize
	{
		[Register("getPreviewTargetSize", "()Landroidx/camera/view/CameraController$OutputSize;", "GetGetPreviewTargetSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviewTargetSize.()Landroidx/camera/view/CameraController$OutputSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPreviewTargetSize", "(Landroidx/camera/view/CameraController$OutputSize;)V", "GetSetPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPreviewTargetSize.(Landroidx/camera/view/CameraController$OutputSize;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ScreenFlashUiInfo? ScreenFlashUiInfoByPriority
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getScreenFlashUiInfoByPriority", "()Landroidx/camera/view/internal/ScreenFlashUiInfo;", "GetGetScreenFlashUiInfoByPriorityHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ScreenFlashUiInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScreenFlashUiInfoByPriority.()Landroidx/camera/view/internal/ScreenFlashUiInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool TapToFocusEnabled
	{
		[Register("isTapToFocusEnabled", "()Z", "GetIsTapToFocusEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTapToFocusEnabled.()Z", this, null);
		}
		[Register("setTapToFocusEnabled", "(Z)V", "GetSetTapToFocusEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTapToFocusEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual LiveData TapToFocusState
	{
		[Register("getTapToFocusState", "()Landroidx/lifecycle/LiveData;", "GetGetTapToFocusStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTapToFocusState.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LiveData TorchState
	{
		[Register("getTorchState", "()Landroidx/lifecycle/LiveData;", "GetGetTorchStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTorchState.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual DynamicRange VideoCaptureDynamicRange
	{
		[Register("getVideoCaptureDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetVideoCaptureDynamicRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVideoCaptureDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setVideoCaptureDynamicRange", "(Landroidx/camera/core/DynamicRange;)V", "GetSetVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVideoCaptureDynamicRange.(Landroidx/camera/core/DynamicRange;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int VideoCaptureMirrorMode
	{
		[Register("getVideoCaptureMirrorMode", "()I", "GetGetVideoCaptureMirrorModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVideoCaptureMirrorMode.()I", this, null);
		}
		[Register("setVideoCaptureMirrorMode", "(I)V", "GetSetVideoCaptureMirrorMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVideoCaptureMirrorMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual QualitySelector VideoCaptureQualitySelector
	{
		[Register("getVideoCaptureQualitySelector", "()Landroidx/camera/video/QualitySelector;", "GetGetVideoCaptureQualitySelectorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<QualitySelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVideoCaptureQualitySelector.()Landroidx/camera/video/QualitySelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setVideoCaptureQualitySelector", "(Landroidx/camera/video/QualitySelector;)V", "GetSetVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVideoCaptureQualitySelector.(Landroidx/camera/video/QualitySelector;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Android.Util.Range VideoCaptureTargetFrameRate
	{
		[Register("getVideoCaptureTargetFrameRate", "()Landroid/util/Range;", "GetGetVideoCaptureTargetFrameRateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVideoCaptureTargetFrameRate.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setVideoCaptureTargetFrameRate", "(Landroid/util/Range;)V", "GetSetVideoCaptureTargetFrameRate_Landroid_util_Range_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVideoCaptureTargetFrameRate.(Landroid/util/Range;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual LiveData ZoomState
	{
		[Register("getZoomState", "()Landroidx/lifecycle/LiveData;", "GetGetZoomStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getZoomState.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected CameraController(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetCameraControlHandler()
	{
		if ((object)cb_getCameraControl == null)
		{
			cb_getCameraControl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraControl));
		}
		return cb_getCameraControl;
	}

	private static nint n_GetCameraControl(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraControl);
	}

	private static Delegate GetGetCameraInfoHandler()
	{
		if ((object)cb_getCameraInfo == null)
		{
			cb_getCameraInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraInfo));
		}
		return cb_getCameraInfo;
	}

	private static nint n_GetCameraInfo(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraInfo);
	}

	private static Delegate GetGetCameraSelectorHandler()
	{
		if ((object)cb_getCameraSelector == null)
		{
			cb_getCameraSelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraSelector));
		}
		return cb_getCameraSelector;
	}

	private static nint n_GetCameraSelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraSelector);
	}

	private static Delegate GetSetCameraSelector_Landroidx_camera_core_CameraSelector_Handler()
	{
		if ((object)cb_setCameraSelector_Landroidx_camera_core_CameraSelector_ == null)
		{
			cb_setCameraSelector_Landroidx_camera_core_CameraSelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetCameraSelector_Landroidx_camera_core_CameraSelector_));
		}
		return cb_setCameraSelector_Landroidx_camera_core_CameraSelector_;
	}

	private static void n_SetCameraSelector_Landroidx_camera_core_CameraSelector_(nint jnienv, nint native__this, nint native_cameraSelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraSelector cameraSelector = Java.Lang.Object.GetObject<CameraSelector>(native_cameraSelector, JniHandleOwnership.DoNotTransfer);
		cameraController.CameraSelector = cameraSelector;
	}

	private static Delegate GetGetImageAnalysisBackgroundExecutorHandler()
	{
		if ((object)cb_getImageAnalysisBackgroundExecutor == null)
		{
			cb_getImageAnalysisBackgroundExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageAnalysisBackgroundExecutor));
		}
		return cb_getImageAnalysisBackgroundExecutor;
	}

	private static nint n_GetImageAnalysisBackgroundExecutor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisBackgroundExecutor);
	}

	private static Delegate GetSetImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_Handler()
	{
		if ((object)cb_setImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_ == null)
		{
			cb_setImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_));
		}
		return cb_setImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_;
	}

	private static void n_SetImageAnalysisBackgroundExecutor_Ljava_util_concurrent_Executor_(nint jnienv, nint native__this, nint native_executor)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor imageAnalysisBackgroundExecutor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageAnalysisBackgroundExecutor = imageAnalysisBackgroundExecutor;
	}

	private static Delegate GetGetImageAnalysisBackpressureStrategyHandler()
	{
		if ((object)cb_getImageAnalysisBackpressureStrategy == null)
		{
			cb_getImageAnalysisBackpressureStrategy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageAnalysisBackpressureStrategy));
		}
		return cb_getImageAnalysisBackpressureStrategy;
	}

	private static int n_GetImageAnalysisBackpressureStrategy(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisBackpressureStrategy;
	}

	private static Delegate GetSetImageAnalysisBackpressureStrategy_IHandler()
	{
		if ((object)cb_setImageAnalysisBackpressureStrategy_I == null)
		{
			cb_setImageAnalysisBackpressureStrategy_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetImageAnalysisBackpressureStrategy_I));
		}
		return cb_setImageAnalysisBackpressureStrategy_I;
	}

	private static void n_SetImageAnalysisBackpressureStrategy_I(nint jnienv, nint native__this, int strategy)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisBackpressureStrategy = strategy;
	}

	private static Delegate GetGetImageAnalysisImageQueueDepthHandler()
	{
		if ((object)cb_getImageAnalysisImageQueueDepth == null)
		{
			cb_getImageAnalysisImageQueueDepth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageAnalysisImageQueueDepth));
		}
		return cb_getImageAnalysisImageQueueDepth;
	}

	private static int n_GetImageAnalysisImageQueueDepth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisImageQueueDepth;
	}

	private static Delegate GetSetImageAnalysisImageQueueDepth_IHandler()
	{
		if ((object)cb_setImageAnalysisImageQueueDepth_I == null)
		{
			cb_setImageAnalysisImageQueueDepth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetImageAnalysisImageQueueDepth_I));
		}
		return cb_setImageAnalysisImageQueueDepth_I;
	}

	private static void n_SetImageAnalysisImageQueueDepth_I(nint jnienv, nint native__this, int depth)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisImageQueueDepth = depth;
	}

	private static Delegate GetGetImageAnalysisOutputImageFormatHandler()
	{
		if ((object)cb_getImageAnalysisOutputImageFormat == null)
		{
			cb_getImageAnalysisOutputImageFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageAnalysisOutputImageFormat));
		}
		return cb_getImageAnalysisOutputImageFormat;
	}

	private static int n_GetImageAnalysisOutputImageFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisOutputImageFormat;
	}

	private static Delegate GetSetImageAnalysisOutputImageFormat_IHandler()
	{
		if ((object)cb_setImageAnalysisOutputImageFormat_I == null)
		{
			cb_setImageAnalysisOutputImageFormat_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetImageAnalysisOutputImageFormat_I));
		}
		return cb_setImageAnalysisOutputImageFormat_I;
	}

	private static void n_SetImageAnalysisOutputImageFormat_I(nint jnienv, nint native__this, int imageAnalysisOutputImageFormat)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisOutputImageFormat = imageAnalysisOutputImageFormat;
	}

	private static Delegate GetGetImageAnalysisResolutionSelectorHandler()
	{
		if ((object)cb_getImageAnalysisResolutionSelector == null)
		{
			cb_getImageAnalysisResolutionSelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageAnalysisResolutionSelector));
		}
		return cb_getImageAnalysisResolutionSelector;
	}

	private static nint n_GetImageAnalysisResolutionSelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisResolutionSelector);
	}

	private static Delegate GetSetImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler()
	{
		if ((object)cb_setImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ == null)
		{
			cb_setImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_));
		}
		return cb_setImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;
	}

	private static void n_SetImageAnalysisResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_(nint jnienv, nint native__this, nint native_resolutionSelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ResolutionSelector imageAnalysisResolutionSelector = Java.Lang.Object.GetObject<ResolutionSelector>(native_resolutionSelector, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageAnalysisResolutionSelector = imageAnalysisResolutionSelector;
	}

	[Obsolete]
	private static Delegate GetGetImageAnalysisTargetSizeHandler()
	{
		if ((object)cb_getImageAnalysisTargetSize == null)
		{
			cb_getImageAnalysisTargetSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageAnalysisTargetSize));
		}
		return cb_getImageAnalysisTargetSize;
	}

	[Obsolete]
	private static nint n_GetImageAnalysisTargetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisTargetSize);
	}

	[Obsolete]
	private static Delegate GetSetImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler()
	{
		if ((object)cb_setImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_ == null)
		{
			cb_setImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_));
		}
		return cb_setImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_;
	}

	[Obsolete]
	private static void n_SetImageAnalysisTargetSize_Landroidx_camera_view_CameraController_OutputSize_(nint jnienv, nint native__this, nint native_targetSize)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OutputSize imageAnalysisTargetSize = Java.Lang.Object.GetObject<OutputSize>(native_targetSize, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageAnalysisTargetSize = imageAnalysisTargetSize;
	}

	private static Delegate GetGetImageCaptureFlashModeHandler()
	{
		if ((object)cb_getImageCaptureFlashMode == null)
		{
			cb_getImageCaptureFlashMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageCaptureFlashMode));
		}
		return cb_getImageCaptureFlashMode;
	}

	private static int n_GetImageCaptureFlashMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureFlashMode;
	}

	private static Delegate GetSetImageCaptureFlashMode_IHandler()
	{
		if ((object)cb_setImageCaptureFlashMode_I == null)
		{
			cb_setImageCaptureFlashMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetImageCaptureFlashMode_I));
		}
		return cb_setImageCaptureFlashMode_I;
	}

	private static void n_SetImageCaptureFlashMode_I(nint jnienv, nint native__this, int flashMode)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureFlashMode = flashMode;
	}

	private static Delegate GetGetImageCaptureIoExecutorHandler()
	{
		if ((object)cb_getImageCaptureIoExecutor == null)
		{
			cb_getImageCaptureIoExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageCaptureIoExecutor));
		}
		return cb_getImageCaptureIoExecutor;
	}

	private static nint n_GetImageCaptureIoExecutor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureIoExecutor);
	}

	private static Delegate GetSetImageCaptureIoExecutor_Ljava_util_concurrent_Executor_Handler()
	{
		if ((object)cb_setImageCaptureIoExecutor_Ljava_util_concurrent_Executor_ == null)
		{
			cb_setImageCaptureIoExecutor_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageCaptureIoExecutor_Ljava_util_concurrent_Executor_));
		}
		return cb_setImageCaptureIoExecutor_Ljava_util_concurrent_Executor_;
	}

	private static void n_SetImageCaptureIoExecutor_Ljava_util_concurrent_Executor_(nint jnienv, nint native__this, nint native_executor)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor imageCaptureIoExecutor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageCaptureIoExecutor = imageCaptureIoExecutor;
	}

	private static Delegate GetGetImageCaptureModeHandler()
	{
		if ((object)cb_getImageCaptureMode == null)
		{
			cb_getImageCaptureMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageCaptureMode));
		}
		return cb_getImageCaptureMode;
	}

	private static int n_GetImageCaptureMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureMode;
	}

	private static Delegate GetSetImageCaptureMode_IHandler()
	{
		if ((object)cb_setImageCaptureMode_I == null)
		{
			cb_setImageCaptureMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetImageCaptureMode_I));
		}
		return cb_setImageCaptureMode_I;
	}

	private static void n_SetImageCaptureMode_I(nint jnienv, nint native__this, int captureMode)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureMode = captureMode;
	}

	private static Delegate GetGetImageCaptureResolutionSelectorHandler()
	{
		if ((object)cb_getImageCaptureResolutionSelector == null)
		{
			cb_getImageCaptureResolutionSelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageCaptureResolutionSelector));
		}
		return cb_getImageCaptureResolutionSelector;
	}

	private static nint n_GetImageCaptureResolutionSelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureResolutionSelector);
	}

	private static Delegate GetSetImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler()
	{
		if ((object)cb_setImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ == null)
		{
			cb_setImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_));
		}
		return cb_setImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;
	}

	private static void n_SetImageCaptureResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_(nint jnienv, nint native__this, nint native_resolutionSelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ResolutionSelector imageCaptureResolutionSelector = Java.Lang.Object.GetObject<ResolutionSelector>(native_resolutionSelector, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageCaptureResolutionSelector = imageCaptureResolutionSelector;
	}

	[Obsolete]
	private static Delegate GetGetImageCaptureTargetSizeHandler()
	{
		if ((object)cb_getImageCaptureTargetSize == null)
		{
			cb_getImageCaptureTargetSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageCaptureTargetSize));
		}
		return cb_getImageCaptureTargetSize;
	}

	[Obsolete]
	private static nint n_GetImageCaptureTargetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureTargetSize);
	}

	[Obsolete]
	private static Delegate GetSetImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler()
	{
		if ((object)cb_setImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_ == null)
		{
			cb_setImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_));
		}
		return cb_setImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_;
	}

	[Obsolete]
	private static void n_SetImageCaptureTargetSize_Landroidx_camera_view_CameraController_OutputSize_(nint jnienv, nint native__this, nint native_targetSize)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OutputSize imageCaptureTargetSize = Java.Lang.Object.GetObject<OutputSize>(native_targetSize, JniHandleOwnership.DoNotTransfer);
		cameraController.ImageCaptureTargetSize = imageCaptureTargetSize;
	}

	private static Delegate GetGetInitializationFutureHandler()
	{
		if ((object)cb_getInitializationFuture == null)
		{
			cb_getInitializationFuture = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInitializationFuture));
		}
		return cb_getInitializationFuture;
	}

	private static nint n_GetInitializationFuture(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitializationFuture);
	}

	private static Delegate GetIsImageAnalysisEnabledHandler()
	{
		if ((object)cb_isImageAnalysisEnabled == null)
		{
			cb_isImageAnalysisEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsImageAnalysisEnabled));
		}
		return cb_isImageAnalysisEnabled;
	}

	private static bool n_IsImageAnalysisEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsImageAnalysisEnabled;
	}

	private static Delegate GetIsImageCaptureEnabledHandler()
	{
		if ((object)cb_isImageCaptureEnabled == null)
		{
			cb_isImageCaptureEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsImageCaptureEnabled));
		}
		return cb_isImageCaptureEnabled;
	}

	private static bool n_IsImageCaptureEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsImageCaptureEnabled;
	}

	private static Delegate GetIsRecordingHandler()
	{
		if ((object)cb_isRecording == null)
		{
			cb_isRecording = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRecording));
		}
		return cb_isRecording;
	}

	private static bool n_IsRecording(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRecording;
	}

	private static Delegate GetIsVideoCaptureEnabledHandler()
	{
		if ((object)cb_isVideoCaptureEnabled == null)
		{
			cb_isVideoCaptureEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVideoCaptureEnabled));
		}
		return cb_isVideoCaptureEnabled;
	}

	private static bool n_IsVideoCaptureEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVideoCaptureEnabled;
	}

	private static Delegate GetIsPinchToZoomEnabledHandler()
	{
		if ((object)cb_isPinchToZoomEnabled == null)
		{
			cb_isPinchToZoomEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPinchToZoomEnabled));
		}
		return cb_isPinchToZoomEnabled;
	}

	private static bool n_IsPinchToZoomEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PinchToZoomEnabled;
	}

	private static Delegate GetSetPinchToZoomEnabled_ZHandler()
	{
		if ((object)cb_setPinchToZoomEnabled_Z == null)
		{
			cb_setPinchToZoomEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetPinchToZoomEnabled_Z));
		}
		return cb_setPinchToZoomEnabled_Z;
	}

	private static void n_SetPinchToZoomEnabled_Z(nint jnienv, nint native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PinchToZoomEnabled = enabled;
	}

	private static Delegate GetGetPreviewDynamicRangeHandler()
	{
		if ((object)cb_getPreviewDynamicRange == null)
		{
			cb_getPreviewDynamicRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreviewDynamicRange));
		}
		return cb_getPreviewDynamicRange;
	}

	private static nint n_GetPreviewDynamicRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewDynamicRange);
	}

	private static Delegate GetSetPreviewDynamicRange_Landroidx_camera_core_DynamicRange_Handler()
	{
		if ((object)cb_setPreviewDynamicRange_Landroidx_camera_core_DynamicRange_ == null)
		{
			cb_setPreviewDynamicRange_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPreviewDynamicRange_Landroidx_camera_core_DynamicRange_));
		}
		return cb_setPreviewDynamicRange_Landroidx_camera_core_DynamicRange_;
	}

	private static void n_SetPreviewDynamicRange_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_dynamicRange)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		DynamicRange previewDynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_dynamicRange, JniHandleOwnership.DoNotTransfer);
		cameraController.PreviewDynamicRange = previewDynamicRange;
	}

	private static Delegate GetGetPreviewResolutionSelectorHandler()
	{
		if ((object)cb_getPreviewResolutionSelector == null)
		{
			cb_getPreviewResolutionSelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreviewResolutionSelector));
		}
		return cb_getPreviewResolutionSelector;
	}

	private static nint n_GetPreviewResolutionSelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewResolutionSelector);
	}

	private static Delegate GetSetPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_Handler()
	{
		if ((object)cb_setPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ == null)
		{
			cb_setPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_));
		}
		return cb_setPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_;
	}

	private static void n_SetPreviewResolutionSelector_Landroidx_camera_core_resolutionselector_ResolutionSelector_(nint jnienv, nint native__this, nint native_resolutionSelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ResolutionSelector previewResolutionSelector = Java.Lang.Object.GetObject<ResolutionSelector>(native_resolutionSelector, JniHandleOwnership.DoNotTransfer);
		cameraController.PreviewResolutionSelector = previewResolutionSelector;
	}

	[Obsolete]
	private static Delegate GetGetPreviewTargetSizeHandler()
	{
		if ((object)cb_getPreviewTargetSize == null)
		{
			cb_getPreviewTargetSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreviewTargetSize));
		}
		return cb_getPreviewTargetSize;
	}

	[Obsolete]
	private static nint n_GetPreviewTargetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewTargetSize);
	}

	[Obsolete]
	private static Delegate GetSetPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_Handler()
	{
		if ((object)cb_setPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_ == null)
		{
			cb_setPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_));
		}
		return cb_setPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_;
	}

	[Obsolete]
	private static void n_SetPreviewTargetSize_Landroidx_camera_view_CameraController_OutputSize_(nint jnienv, nint native__this, nint native_targetSize)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OutputSize previewTargetSize = Java.Lang.Object.GetObject<OutputSize>(native_targetSize, JniHandleOwnership.DoNotTransfer);
		cameraController.PreviewTargetSize = previewTargetSize;
	}

	private static Delegate GetGetScreenFlashUiInfoByPriorityHandler()
	{
		if ((object)cb_getScreenFlashUiInfoByPriority == null)
		{
			cb_getScreenFlashUiInfoByPriority = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetScreenFlashUiInfoByPriority));
		}
		return cb_getScreenFlashUiInfoByPriority;
	}

	private static nint n_GetScreenFlashUiInfoByPriority(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScreenFlashUiInfoByPriority);
	}

	private static Delegate GetIsTapToFocusEnabledHandler()
	{
		if ((object)cb_isTapToFocusEnabled == null)
		{
			cb_isTapToFocusEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsTapToFocusEnabled));
		}
		return cb_isTapToFocusEnabled;
	}

	private static bool n_IsTapToFocusEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TapToFocusEnabled;
	}

	private static Delegate GetSetTapToFocusEnabled_ZHandler()
	{
		if ((object)cb_setTapToFocusEnabled_Z == null)
		{
			cb_setTapToFocusEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetTapToFocusEnabled_Z));
		}
		return cb_setTapToFocusEnabled_Z;
	}

	private static void n_SetTapToFocusEnabled_Z(nint jnienv, nint native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TapToFocusEnabled = enabled;
	}

	private static Delegate GetGetTapToFocusStateHandler()
	{
		if ((object)cb_getTapToFocusState == null)
		{
			cb_getTapToFocusState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTapToFocusState));
		}
		return cb_getTapToFocusState;
	}

	private static nint n_GetTapToFocusState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TapToFocusState);
	}

	private static Delegate GetGetTorchStateHandler()
	{
		if ((object)cb_getTorchState == null)
		{
			cb_getTorchState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTorchState));
		}
		return cb_getTorchState;
	}

	private static nint n_GetTorchState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TorchState);
	}

	private static Delegate GetGetVideoCaptureDynamicRangeHandler()
	{
		if ((object)cb_getVideoCaptureDynamicRange == null)
		{
			cb_getVideoCaptureDynamicRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVideoCaptureDynamicRange));
		}
		return cb_getVideoCaptureDynamicRange;
	}

	private static nint n_GetVideoCaptureDynamicRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoCaptureDynamicRange);
	}

	private static Delegate GetSetVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_Handler()
	{
		if ((object)cb_setVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_ == null)
		{
			cb_setVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_));
		}
		return cb_setVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_;
	}

	private static void n_SetVideoCaptureDynamicRange_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_dynamicRange)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		DynamicRange videoCaptureDynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_dynamicRange, JniHandleOwnership.DoNotTransfer);
		cameraController.VideoCaptureDynamicRange = videoCaptureDynamicRange;
	}

	private static Delegate GetGetVideoCaptureMirrorModeHandler()
	{
		if ((object)cb_getVideoCaptureMirrorMode == null)
		{
			cb_getVideoCaptureMirrorMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVideoCaptureMirrorMode));
		}
		return cb_getVideoCaptureMirrorMode;
	}

	private static int n_GetVideoCaptureMirrorMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoCaptureMirrorMode;
	}

	private static Delegate GetSetVideoCaptureMirrorMode_IHandler()
	{
		if ((object)cb_setVideoCaptureMirrorMode_I == null)
		{
			cb_setVideoCaptureMirrorMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetVideoCaptureMirrorMode_I));
		}
		return cb_setVideoCaptureMirrorMode_I;
	}

	private static void n_SetVideoCaptureMirrorMode_I(nint jnienv, nint native__this, int mirrorMode)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoCaptureMirrorMode = mirrorMode;
	}

	private static Delegate GetGetVideoCaptureQualitySelectorHandler()
	{
		if ((object)cb_getVideoCaptureQualitySelector == null)
		{
			cb_getVideoCaptureQualitySelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVideoCaptureQualitySelector));
		}
		return cb_getVideoCaptureQualitySelector;
	}

	private static nint n_GetVideoCaptureQualitySelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoCaptureQualitySelector);
	}

	private static Delegate GetSetVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_Handler()
	{
		if ((object)cb_setVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_ == null)
		{
			cb_setVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_));
		}
		return cb_setVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_;
	}

	private static void n_SetVideoCaptureQualitySelector_Landroidx_camera_video_QualitySelector_(nint jnienv, nint native__this, nint native_qualitySelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		QualitySelector videoCaptureQualitySelector = Java.Lang.Object.GetObject<QualitySelector>(native_qualitySelector, JniHandleOwnership.DoNotTransfer);
		cameraController.VideoCaptureQualitySelector = videoCaptureQualitySelector;
	}

	private static Delegate GetGetVideoCaptureTargetFrameRateHandler()
	{
		if ((object)cb_getVideoCaptureTargetFrameRate == null)
		{
			cb_getVideoCaptureTargetFrameRate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVideoCaptureTargetFrameRate));
		}
		return cb_getVideoCaptureTargetFrameRate;
	}

	private static nint n_GetVideoCaptureTargetFrameRate(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoCaptureTargetFrameRate);
	}

	private static Delegate GetSetVideoCaptureTargetFrameRate_Landroid_util_Range_Handler()
	{
		if ((object)cb_setVideoCaptureTargetFrameRate_Landroid_util_Range_ == null)
		{
			cb_setVideoCaptureTargetFrameRate_Landroid_util_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetVideoCaptureTargetFrameRate_Landroid_util_Range_));
		}
		return cb_setVideoCaptureTargetFrameRate_Landroid_util_Range_;
	}

	private static void n_SetVideoCaptureTargetFrameRate_Landroid_util_Range_(nint jnienv, nint native__this, nint native_targetFrameRate)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.Util.Range videoCaptureTargetFrameRate = Java.Lang.Object.GetObject<Android.Util.Range>(native_targetFrameRate, JniHandleOwnership.DoNotTransfer);
		cameraController.VideoCaptureTargetFrameRate = videoCaptureTargetFrameRate;
	}

	private static Delegate GetGetZoomStateHandler()
	{
		if ((object)cb_getZoomState == null)
		{
			cb_getZoomState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetZoomState));
		}
		return cb_getZoomState;
	}

	private static nint n_GetZoomState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomState);
	}

	private static Delegate GetClearEffectsHandler()
	{
		if ((object)cb_clearEffects == null)
		{
			cb_clearEffects = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearEffects));
		}
		return cb_clearEffects;
	}

	private static void n_ClearEffects(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearEffects();
	}

	[Register("clearEffects", "()V", "GetClearEffectsHandler")]
	public unsafe virtual void ClearEffects()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearEffects.()V", this, null);
	}

	private static Delegate GetClearImageAnalysisAnalyzerHandler()
	{
		if ((object)cb_clearImageAnalysisAnalyzer == null)
		{
			cb_clearImageAnalysisAnalyzer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearImageAnalysisAnalyzer));
		}
		return cb_clearImageAnalysisAnalyzer;
	}

	private static void n_ClearImageAnalysisAnalyzer(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearImageAnalysisAnalyzer();
	}

	[Register("clearImageAnalysisAnalyzer", "()V", "GetClearImageAnalysisAnalyzerHandler")]
	public unsafe virtual void ClearImageAnalysisAnalyzer()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearImageAnalysisAnalyzer.()V", this, null);
	}

	private static Delegate GetCreateUseCaseGroupHandler()
	{
		if ((object)cb_createUseCaseGroup == null)
		{
			cb_createUseCaseGroup = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateUseCaseGroup));
		}
		return cb_createUseCaseGroup;
	}

	private static nint n_CreateUseCaseGroup(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateUseCaseGroup());
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("createUseCaseGroup", "()Landroidx/camera/core/UseCaseGroup;", "GetCreateUseCaseGroupHandler")]
	protected unsafe virtual UseCaseGroup? CreateUseCaseGroup()
	{
		return Java.Lang.Object.GetObject<UseCaseGroup>(_members.InstanceMethods.InvokeVirtualObjectMethod("createUseCaseGroup.()Landroidx/camera/core/UseCaseGroup;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEnableTorch_ZHandler()
	{
		if ((object)cb_enableTorch_Z == null)
		{
			cb_enableTorch_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableTorch_Z));
		}
		return cb_enableTorch_Z;
	}

	private static nint n_EnableTorch_Z(nint jnienv, nint native__this, bool torchEnabled)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTorch(torchEnabled));
	}

	[Register("enableTorch", "(Z)Lcom/google/common/util/concurrent/ListenableFuture;", "GetEnableTorch_ZHandler")]
	public unsafe virtual IListenableFuture EnableTorch(bool torchEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(torchEnabled);
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableTorch.(Z)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetHasCamera_Landroidx_camera_core_CameraSelector_Handler()
	{
		if ((object)cb_hasCamera_Landroidx_camera_core_CameraSelector_ == null)
		{
			cb_hasCamera_Landroidx_camera_core_CameraSelector_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HasCamera_Landroidx_camera_core_CameraSelector_));
		}
		return cb_hasCamera_Landroidx_camera_core_CameraSelector_;
	}

	private static bool n_HasCamera_Landroidx_camera_core_CameraSelector_(nint jnienv, nint native__this, nint native_cameraSelector)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraSelector cameraSelector = Java.Lang.Object.GetObject<CameraSelector>(native_cameraSelector, JniHandleOwnership.DoNotTransfer);
		return cameraController.HasCamera(cameraSelector);
	}

	[Register("hasCamera", "(Landroidx/camera/core/CameraSelector;)Z", "GetHasCamera_Landroidx_camera_core_CameraSelector_Handler")]
	public unsafe virtual bool HasCamera(CameraSelector cameraSelector)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cameraSelector?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasCamera.(Landroidx/camera/core/CameraSelector;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cameraSelector);
		}
	}

	private static Delegate GetSetEffects_Ljava_util_Set_Handler()
	{
		if ((object)cb_setEffects_Ljava_util_Set_ == null)
		{
			cb_setEffects_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEffects_Ljava_util_Set_));
		}
		return cb_setEffects_Ljava_util_Set_;
	}

	private static void n_SetEffects_Ljava_util_Set_(nint jnienv, nint native__this, nint native_effects)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICollection<CameraEffect> effects = JavaSet<CameraEffect>.FromJniHandle(native_effects, JniHandleOwnership.DoNotTransfer);
		cameraController.SetEffects(effects);
	}

	[Register("setEffects", "(Ljava/util/Set;)V", "GetSetEffects_Ljava_util_Set_Handler")]
	public unsafe virtual void SetEffects(ICollection<CameraEffect> effects)
	{
		nint num = JavaSet<CameraEffect>.ToLocalJniHandle(effects);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEffects.(Ljava/util/Set;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(effects);
		}
	}

	private static Delegate GetSetEnabledUseCases_IHandler()
	{
		if ((object)cb_setEnabledUseCases_I == null)
		{
			cb_setEnabledUseCases_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetEnabledUseCases_I));
		}
		return cb_setEnabledUseCases_I;
	}

	private static void n_SetEnabledUseCases_I(nint jnienv, nint native__this, int enabledUseCases)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnabledUseCases(enabledUseCases);
	}

	[Register("setEnabledUseCases", "(I)V", "GetSetEnabledUseCases_IHandler")]
	public unsafe virtual void SetEnabledUseCases(int enabledUseCases)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabledUseCases);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEnabledUseCases.(I)V", this, ptr);
	}

	private static Delegate GetSetImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_Handler()
	{
		if ((object)cb_setImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_ == null)
		{
			cb_setImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_));
		}
		return cb_setImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_;
	}

	private static void n_SetImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_(nint jnienv, nint native__this, nint native_executor, nint native_analyzer)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		ImageAnalysis.IAnalyzer analyzer = Java.Lang.Object.GetObject<ImageAnalysis.IAnalyzer>(native_analyzer, JniHandleOwnership.DoNotTransfer);
		cameraController.SetImageAnalysisAnalyzer(executor, analyzer);
	}

	[Register("setImageAnalysisAnalyzer", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageAnalysis$Analyzer;)V", "GetSetImageAnalysisAnalyzer_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageAnalysis_Analyzer_Handler")]
	public unsafe virtual void SetImageAnalysisAnalyzer(IExecutor executor, ImageAnalysis.IAnalyzer analyzer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((analyzer == null) ? IntPtr.Zero : ((Java.Lang.Object)analyzer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAnalysisAnalyzer.(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageAnalysis$Analyzer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(analyzer);
		}
	}

	private static Delegate GetSetLinearZoom_FHandler()
	{
		if ((object)cb_setLinearZoom_F == null)
		{
			cb_setLinearZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetLinearZoom_F));
		}
		return cb_setLinearZoom_F;
	}

	private static nint n_SetLinearZoom_F(nint jnienv, nint native__this, float linearZoom)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLinearZoom(linearZoom));
	}

	[Register("setLinearZoom", "(F)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetLinearZoom_FHandler")]
	public unsafe virtual IListenableFuture SetLinearZoom(float linearZoom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(linearZoom);
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLinearZoom.(F)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_Handler()
	{
		if ((object)cb_setScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_ == null)
		{
			cb_setScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_));
		}
		return cb_setScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_;
	}

	private static void n_SetScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_(nint jnienv, nint native__this, nint native_screenFlashUiInfo)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ScreenFlashUiInfo screenFlashUiInfo = Java.Lang.Object.GetObject<ScreenFlashUiInfo>(native_screenFlashUiInfo, JniHandleOwnership.DoNotTransfer);
		cameraController.SetScreenFlashUiInfo(screenFlashUiInfo);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setScreenFlashUiInfo", "(Landroidx/camera/view/internal/ScreenFlashUiInfo;)V", "GetSetScreenFlashUiInfo_Landroidx_camera_view_internal_ScreenFlashUiInfo_Handler")]
	public unsafe virtual void SetScreenFlashUiInfo(ScreenFlashUiInfo screenFlashUiInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(screenFlashUiInfo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScreenFlashUiInfo.(Landroidx/camera/view/internal/ScreenFlashUiInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(screenFlashUiInfo);
		}
	}

	private static Delegate GetSetZoomRatio_FHandler()
	{
		if ((object)cb_setZoomRatio_F == null)
		{
			cb_setZoomRatio_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetZoomRatio_F));
		}
		return cb_setZoomRatio_F;
	}

	private static nint n_SetZoomRatio_F(nint jnienv, nint native__this, float zoomRatio)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZoomRatio(zoomRatio));
	}

	[Register("setZoomRatio", "(F)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetZoomRatio_FHandler")]
	public unsafe virtual IListenableFuture SetZoomRatio(float zoomRatio)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(zoomRatio);
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("setZoomRatio.(F)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStartRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_startRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ == null)
		{
			cb_startRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_StartRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_));
		}
		return cb_startRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;
	}

	private static nint n_StartRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_outputOptions, nint native_audioConfig, nint native_executor, nint native_listener)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FileDescriptorOutputOptions outputOptions = Java.Lang.Object.GetObject<FileDescriptorOutputOptions>(native_outputOptions, JniHandleOwnership.DoNotTransfer);
		AudioConfig audioConfig = Java.Lang.Object.GetObject<AudioConfig>(native_audioConfig, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraController.StartRecording(outputOptions, audioConfig, executor, listener));
	}

	[Register("startRecording", "(Landroidx/camera/video/FileDescriptorOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", "GetStartRecording_Landroidx_camera_video_FileDescriptorOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler")]
	public unsafe virtual Recording StartRecording(FileDescriptorOutputOptions outputOptions, AudioConfig audioConfig, IExecutor executor, IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(outputOptions?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(audioConfig?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<Recording>(_members.InstanceMethods.InvokeVirtualObjectMethod("startRecording.(Landroidx/camera/video/FileDescriptorOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(outputOptions);
			GC.KeepAlive(audioConfig);
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetStartRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_startRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ == null)
		{
			cb_startRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_StartRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_));
		}
		return cb_startRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;
	}

	private static nint n_StartRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_outputOptions, nint native_audioConfig, nint native_executor, nint native_listener)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FileOutputOptions outputOptions = Java.Lang.Object.GetObject<FileOutputOptions>(native_outputOptions, JniHandleOwnership.DoNotTransfer);
		AudioConfig audioConfig = Java.Lang.Object.GetObject<AudioConfig>(native_audioConfig, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraController.StartRecording(outputOptions, audioConfig, executor, listener));
	}

	[Register("startRecording", "(Landroidx/camera/video/FileOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", "GetStartRecording_Landroidx_camera_video_FileOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler")]
	public unsafe virtual Recording StartRecording(FileOutputOptions outputOptions, AudioConfig audioConfig, IExecutor executor, IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(outputOptions?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(audioConfig?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<Recording>(_members.InstanceMethods.InvokeVirtualObjectMethod("startRecording.(Landroidx/camera/video/FileOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(outputOptions);
			GC.KeepAlive(audioConfig);
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetStartRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_startRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ == null)
		{
			cb_startRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_StartRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_));
		}
		return cb_startRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;
	}

	private static nint n_StartRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_outputOptions, nint native_audioConfig, nint native_executor, nint native_listener)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MediaStoreOutputOptions outputOptions = Java.Lang.Object.GetObject<MediaStoreOutputOptions>(native_outputOptions, JniHandleOwnership.DoNotTransfer);
		AudioConfig audioConfig = Java.Lang.Object.GetObject<AudioConfig>(native_audioConfig, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraController.StartRecording(outputOptions, audioConfig, executor, listener));
	}

	[Register("startRecording", "(Landroidx/camera/video/MediaStoreOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", "GetStartRecording_Landroidx_camera_video_MediaStoreOutputOptions_Landroidx_camera_view_video_AudioConfig_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler")]
	public unsafe virtual Recording StartRecording(MediaStoreOutputOptions outputOptions, AudioConfig audioConfig, IExecutor executor, IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(outputOptions?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(audioConfig?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<Recording>(_members.InstanceMethods.InvokeVirtualObjectMethod("startRecording.(Landroidx/camera/video/MediaStoreOutputOptions;Landroidx/camera/view/video/AudioConfig;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroidx/camera/video/Recording;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(outputOptions);
			GC.KeepAlive(audioConfig);
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetTakePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_Handler()
	{
		if ((object)cb_takePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_ == null)
		{
			cb_takePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_TakePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_));
		}
		return cb_takePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_;
	}

	private static void n_TakePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_(nint jnienv, nint native__this, nint native_outputFileOptions, nint native_executor, nint native_imageSavedCallback)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageCapture.OutputFileOptions outputFileOptions = Java.Lang.Object.GetObject<ImageCapture.OutputFileOptions>(native_outputFileOptions, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		ImageCapture.IOnImageSavedCallback imageSavedCallback = Java.Lang.Object.GetObject<ImageCapture.IOnImageSavedCallback>(native_imageSavedCallback, JniHandleOwnership.DoNotTransfer);
		cameraController.TakePicture(outputFileOptions, executor, imageSavedCallback);
	}

	[Register("takePicture", "(Landroidx/camera/core/ImageCapture$OutputFileOptions;Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageSavedCallback;)V", "GetTakePicture_Landroidx_camera_core_ImageCapture_OutputFileOptions_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageSavedCallback_Handler")]
	public unsafe virtual void TakePicture(ImageCapture.OutputFileOptions outputFileOptions, IExecutor executor, ImageCapture.IOnImageSavedCallback imageSavedCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(outputFileOptions?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue((imageSavedCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)imageSavedCallback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("takePicture.(Landroidx/camera/core/ImageCapture$OutputFileOptions;Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageSavedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outputFileOptions);
			GC.KeepAlive(executor);
			GC.KeepAlive(imageSavedCallback);
		}
	}

	private static Delegate GetTakePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_Handler()
	{
		if ((object)cb_takePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_ == null)
		{
			cb_takePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_TakePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_));
		}
		return cb_takePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_;
	}

	private static void n_TakePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_(nint jnienv, nint native__this, nint native_executor, nint native__callback)
	{
		CameraController? cameraController = Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
		ImageCapture.OnImageCapturedCallback callback = Java.Lang.Object.GetObject<ImageCapture.OnImageCapturedCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		cameraController.TakePicture(executor, callback);
	}

	[Register("takePicture", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageCapturedCallback;)V", "GetTakePicture_Ljava_util_concurrent_Executor_Landroidx_camera_core_ImageCapture_OnImageCapturedCallback_Handler")]
	public unsafe virtual void TakePicture(IExecutor executor, ImageCapture.OnImageCapturedCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("takePicture.(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageCapturedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetUpdateScreenFlashToImageCaptureHandler()
	{
		if ((object)cb_updateScreenFlashToImageCapture == null)
		{
			cb_updateScreenFlashToImageCapture = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_UpdateScreenFlashToImageCapture));
		}
		return cb_updateScreenFlashToImageCapture;
	}

	private static void n_UpdateScreenFlashToImageCapture(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<CameraController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateScreenFlashToImageCapture();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateScreenFlashToImageCapture", "()V", "GetUpdateScreenFlashToImageCaptureHandler")]
	public unsafe virtual void UpdateScreenFlashToImageCapture()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateScreenFlashToImageCapture.()V", this, null);
	}
}
