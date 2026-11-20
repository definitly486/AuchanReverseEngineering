using System;
using Android.Hardware.Camera2;
using Android.Runtime;
using AndroidX.Camera.Core.Impl.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraCaptureResult", "", "AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker")]
public interface ICameraCaptureResult : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureResult", typeof(ICameraCaptureResult), isInterface: true);

	private static Delegate? cb_getCaptureResult;

	private static Delegate? cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_;

	CameraCaptureMetaData.AeMode AeMode
	{
		[Register("getAeMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;", "GetGetAeModeHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.AeState AeState
	{
		[Register("getAeState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;", "GetGetAeStateHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.AfMode AfMode
	{
		[Register("getAfMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;", "GetGetAfModeHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.AfState AfState
	{
		[Register("getAfState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;", "GetGetAfStateHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.AwbMode AwbMode
	{
		[Register("getAwbMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;", "GetGetAwbModeHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.AwbState AwbState
	{
		[Register("getAwbState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;", "GetGetAwbStateHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	CameraCaptureMetaData.FlashState FlashState
	{
		[Register("getFlashState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;", "GetGetFlashStateHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	TagBundle TagBundle
	{
		[Register("getTagBundle", "()Landroidx/camera/core/impl/TagBundle;", "GetGetTagBundleHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	long Timestamp
	{
		[Register("getTimestamp", "()J", "GetGetTimestampHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResultInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe CaptureResult? CaptureResult
	{
		[Register("getCaptureResult", "()Landroid/hardware/camera2/CaptureResult;", "GetGetCaptureResultHandler:AndroidX.Camera.Core.Impl.ICameraCaptureResult, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<CaptureResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCaptureResult.()Landroid/hardware/camera2/CaptureResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetCaptureResultHandler()
	{
		if ((object)cb_getCaptureResult == null)
		{
			cb_getCaptureResult = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureResult));
		}
		return cb_getCaptureResult;
	}

	private static nint n_GetCaptureResult(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureResult);
	}

	private static Delegate GetPopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_Handler()
	{
		if ((object)cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ == null)
		{
			cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_));
		}
		return cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_;
	}

	private static void n_PopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_(nint jnienv, nint native__this, nint native_exifBuilder)
	{
		ICameraCaptureResult? cameraCaptureResult = Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ExifData.Builder exifBuilder = Java.Lang.Object.GetObject<ExifData.Builder>(native_exifBuilder, JniHandleOwnership.DoNotTransfer);
		cameraCaptureResult.PopulateExifData(exifBuilder);
	}

	[Register("populateExifData", "(Landroidx/camera/core/impl/utils/ExifData$Builder;)V", "GetPopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_Handler:AndroidX.Camera.Core.Impl.ICameraCaptureResult, Xamarin.AndroidX.Camera.Core")]
	unsafe void PopulateExifData(ExifData.Builder exifBuilder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(exifBuilder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("populateExifData.(Landroidx/camera/core/impl/utils/ExifData$Builder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(exifBuilder);
		}
	}
}
