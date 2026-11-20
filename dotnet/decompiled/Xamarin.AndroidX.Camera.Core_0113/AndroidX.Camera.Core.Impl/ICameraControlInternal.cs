using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraControlInternal", "", "AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker")]
public interface ICameraControlInternal : ICameraControl, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraControlInternal", typeof(ICameraControlInternal), isInterface: true);

	private static Delegate? cb_getImplementation;

	private static Delegate? cb_isInVideoUsage;

	private static Delegate? cb_decrementVideoUsage;

	private static Delegate? cb_getCameraCapturePipelineAsync_II;

	private static Delegate? cb_incrementVideoUsage;

	private static Delegate? cb_setScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_;

	[Register("DEFAULT_EMPTY_INSTANCE")]
	static ICameraControlInternal DefaultEmptyInstance => Java.Lang.Object.GetObject<ICameraControlInternal>(_members.StaticFields.GetObjectValue("DEFAULT_EMPTY_INSTANCE.Landroidx/camera/core/impl/CameraControlInternal;").Handle, JniHandleOwnership.TransferLocalRef);

	int FlashMode
	{
		[Register("getFlashMode", "()I", "GetGetFlashModeHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
		[Register("setFlashMode", "(I)V", "GetSetFlashMode_IHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		set;
	}

	IConfig InteropConfig
	{
		[Register("getInteropConfig", "()Landroidx/camera/core/impl/Config;", "GetGetInteropConfigHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool IsZslDisabledByByUserCaseConfig
	{
		[Register("isZslDisabledByByUserCaseConfig", "()Z", "GetIsZslDisabledByByUserCaseConfigHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Rect SensorRect
	{
		[Register("getSensorRect", "()Landroid/graphics/Rect;", "GetGetSensorRectHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	SessionConfig SessionConfig
	{
		[Register("getSessionConfig", "()Landroidx/camera/core/impl/SessionConfig;", "GetGetSessionConfigHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe ICameraControlInternal Implementation
	{
		[Register("getImplementation", "()Landroidx/camera/core/impl/CameraControlInternal;", "GetGetImplementationHandler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraControlInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImplementation.()Landroidx/camera/core/impl/CameraControlInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe bool IsInVideoUsage
	{
		[Register("isInVideoUsage", "()Z", "GetIsInVideoUsageHandler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInVideoUsage.()Z", this, null);
		}
	}

	private static Delegate GetGetImplementationHandler()
	{
		if ((object)cb_getImplementation == null)
		{
			cb_getImplementation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImplementation));
		}
		return cb_getImplementation;
	}

	private static nint n_GetImplementation(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Implementation);
	}

	private static Delegate GetIsInVideoUsageHandler()
	{
		if ((object)cb_isInVideoUsage == null)
		{
			cb_isInVideoUsage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInVideoUsage));
		}
		return cb_isInVideoUsage;
	}

	private static bool n_IsInVideoUsage(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInVideoUsage;
	}

	[Register("addInteropConfig", "(Landroidx/camera/core/impl/Config;)V", "GetAddInteropConfig_Landroidx_camera_core_impl_Config_Handler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void AddInteropConfig(IConfig p0);

	[Register("addZslConfig", "(Landroidx/camera/core/impl/SessionConfig$Builder;)V", "GetAddZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_Handler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void AddZslConfig(SessionConfig.Builder p0);

	[Register("clearInteropConfig", "()V", "GetClearInteropConfigHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void ClearInteropConfig();

	[Register("setZslDisabledByUserCaseConfig", "(Z)V", "GetSetZslDisabledByUserCaseConfig_ZHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void SetZslDisabledByUserCaseConfig(bool p0);

	[Register("submitStillCaptureRequests", "(Ljava/util/List;II)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSubmitStillCaptureRequests_Ljava_util_List_IIHandler:AndroidX.Camera.Core.Impl.ICameraControlInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture SubmitStillCaptureRequests(IList<CaptureConfig> p0, int p1, int p2);

	private static Delegate GetDecrementVideoUsageHandler()
	{
		if ((object)cb_decrementVideoUsage == null)
		{
			cb_decrementVideoUsage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DecrementVideoUsage));
		}
		return cb_decrementVideoUsage;
	}

	private static void n_DecrementVideoUsage(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DecrementVideoUsage();
	}

	[Register("decrementVideoUsage", "()V", "GetDecrementVideoUsageHandler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe void DecrementVideoUsage()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("decrementVideoUsage.()V", this, null);
	}

	private static Delegate GetGetCameraCapturePipelineAsync_IIHandler()
	{
		if ((object)cb_getCameraCapturePipelineAsync_II == null)
		{
			cb_getCameraCapturePipelineAsync_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_GetCameraCapturePipelineAsync_II));
		}
		return cb_getCameraCapturePipelineAsync_II;
	}

	private static nint n_GetCameraCapturePipelineAsync_II(nint jnienv, nint native__this, int captureMode, int flashType)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetCameraCapturePipelineAsync(captureMode, flashType));
	}

	[Register("getCameraCapturePipelineAsync", "(II)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetCameraCapturePipelineAsync_IIHandler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe IListenableFuture GetCameraCapturePipelineAsync(int captureMode, int flashType)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(captureMode);
		ptr[1] = new JniArgumentValue(flashType);
		return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraCapturePipelineAsync.(II)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIncrementVideoUsageHandler()
	{
		if ((object)cb_incrementVideoUsage == null)
		{
			cb_incrementVideoUsage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_IncrementVideoUsage));
		}
		return cb_incrementVideoUsage;
	}

	private static void n_IncrementVideoUsage(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IncrementVideoUsage();
	}

	[Register("incrementVideoUsage", "()V", "GetIncrementVideoUsageHandler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe void IncrementVideoUsage()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("incrementVideoUsage.()V", this, null);
	}

	private static Delegate GetSetScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_Handler()
	{
		if ((object)cb_setScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_ == null)
		{
			cb_setScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_));
		}
		return cb_setScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_;
	}

	private static void n_SetScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_(nint jnienv, nint native__this, nint native_screenFlash)
	{
		ICameraControlInternal? cameraControlInternal = Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageCapture.IScreenFlash screenFlash = Java.Lang.Object.GetObject<ImageCapture.IScreenFlash>(native_screenFlash, JniHandleOwnership.DoNotTransfer);
		cameraControlInternal.SetScreenFlash(screenFlash);
	}

	[Register("setScreenFlash", "(Landroidx/camera/core/ImageCapture$ScreenFlash;)V", "GetSetScreenFlash_Landroidx_camera_core_ImageCapture_ScreenFlash_Handler:AndroidX.Camera.Core.Impl.ICameraControlInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe void SetScreenFlash(ImageCapture.IScreenFlash? screenFlash)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((screenFlash == null) ? IntPtr.Zero : ((Java.Lang.Object)screenFlash).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScreenFlash.(Landroidx/camera/core/ImageCapture$ScreenFlash;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(screenFlash);
		}
	}
}
