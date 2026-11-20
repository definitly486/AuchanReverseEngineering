using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraInfoInternal", "", "AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker")]
public interface ICameraInfoInternal : ICameraInfo, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraInfoInternal", typeof(ICameraInfoInternal), isInterface: true);

	private static Delegate? cb_getCameraSelector;

	private static Delegate? cb_getImplementation;

	private static Delegate? cb_isCaptureProcessProgressSupported;

	private static Delegate? cb_isPostviewSupported;

	Java.Lang.Object CameraCharacteristics
	{
		[Register("getCameraCharacteristics", "()Ljava/lang/Object;", "GetGetCameraCharacteristicsHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	string CameraId
	{
		[Register("getCameraId", "()Ljava/lang/String;", "GetGetCameraIdHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Quirks CameraQuirks
	{
		[Register("getCameraQuirks", "()Landroidx/camera/core/impl/Quirks;", "GetGetCameraQuirksHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IEncoderProfilesProvider EncoderProfilesProvider
	{
		[Register("getEncoderProfilesProvider", "()Landroidx/camera/core/impl/EncoderProfilesProvider;", "GetGetEncoderProfilesProviderHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool IsPreviewStabilizationSupported
	{
		[Register("isPreviewStabilizationSupported", "()Z", "GetIsPreviewStabilizationSupportedHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool IsVideoStabilizationSupported
	{
		[Register("isVideoStabilizationSupported", "()Z", "GetIsVideoStabilizationSupportedHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICollection<DynamicRange> SupportedDynamicRanges
	{
		[Register("getSupportedDynamicRanges", "()Ljava/util/Set;", "GetGetSupportedDynamicRangesHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICollection<Integer> SupportedOutputFormats
	{
		[Register("getSupportedOutputFormats", "()Ljava/util/Set;", "GetGetSupportedOutputFormatsHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Timebase Timebase
	{
		[Register("getTimebase", "()Landroidx/camera/core/impl/Timebase;", "GetGetTimebaseHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	new unsafe CameraSelector CameraSelector
	{
		[Register("getCameraSelector", "()Landroidx/camera/core/CameraSelector;", "GetGetCameraSelectorHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<CameraSelector>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraSelector.()Landroidx/camera/core/CameraSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe ICameraInfoInternal Implementation
	{
		[Register("getImplementation", "()Landroidx/camera/core/impl/CameraInfoInternal;", "GetGetImplementationHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInfoInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImplementation.()Landroidx/camera/core/impl/CameraInfoInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe bool IsCaptureProcessProgressSupported
	{
		[Register("isCaptureProcessProgressSupported", "()Z", "GetIsCaptureProcessProgressSupportedHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCaptureProcessProgressSupported.()Z", this, null);
		}
	}

	unsafe bool IsPostviewSupported
	{
		[Register("isPostviewSupported", "()Z", "GetIsPostviewSupportedHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPostviewSupported.()Z", this, null);
		}
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraSelector);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Implementation);
	}

	private static Delegate GetIsCaptureProcessProgressSupportedHandler()
	{
		if ((object)cb_isCaptureProcessProgressSupported == null)
		{
			cb_isCaptureProcessProgressSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCaptureProcessProgressSupported));
		}
		return cb_isCaptureProcessProgressSupported;
	}

	private static bool n_IsCaptureProcessProgressSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCaptureProcessProgressSupported;
	}

	private static Delegate GetIsPostviewSupportedHandler()
	{
		if ((object)cb_isPostviewSupported == null)
		{
			cb_isPostviewSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPostviewSupported));
		}
		return cb_isPostviewSupported;
	}

	private static bool n_IsPostviewSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPostviewSupported;
	}

	[Register("addSessionCaptureCallback", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/CameraCaptureCallback;)V", "GetAddSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_Handler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void AddSessionCaptureCallback(IExecutor p0, CameraCaptureCallback p1);

	[Register("getPhysicalCameraCharacteristics", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetPhysicalCameraCharacteristics_Ljava_lang_String_Handler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object? GetPhysicalCameraCharacteristics(string p0);

	[Register("getSupportedHighResolutions", "(I)Ljava/util/List;", "GetGetSupportedHighResolutions_IHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	IList<Size> GetSupportedHighResolutions(int p0);

	[Register("getSupportedResolutions", "(I)Ljava/util/List;", "GetGetSupportedResolutions_IHandler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	IList<Size> GetSupportedResolutions(int p0);

	[Register("removeSessionCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)V", "GetRemoveSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler:AndroidX.Camera.Core.Impl.ICameraInfoInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void RemoveSessionCaptureCallback(CameraCaptureCallback p0);
}
