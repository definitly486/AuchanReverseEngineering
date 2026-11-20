using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Util;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraInfo", "", "AndroidX.Camera.Core.ICameraInfoInvoker")]
public interface ICameraInfo : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraInfo", typeof(ICameraInfo), isInterface: true);

	private static Delegate? cb_getIntrinsicZoomRatio;

	private static Delegate? cb_isLogicalMultiCameraSupported;

	private static Delegate? cb_isPrivateReprocessingSupported;

	private static Delegate? cb_isZslSupported;

	private static Delegate? cb_getLensFacing;

	private static Delegate? cb_getPhysicalCameraInfos;

	private static Delegate? cb_getSupportedFrameRateRanges;

	private static Delegate? cb_isFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_;

	private static Delegate? cb_querySupportedDynamicRanges_Ljava_util_Set_;

	CameraSelector CameraSelector
	{
		[Register("getCameraSelector", "()Landroidx/camera/core/CameraSelector;", "GetGetCameraSelectorHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	LiveData CameraState
	{
		[Register("getCameraState", "()Landroidx/lifecycle/LiveData;", "GetGetCameraStateHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IExposureState ExposureState
	{
		[Register("getExposureState", "()Landroidx/camera/core/ExposureState;", "GetGetExposureStateHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool HasFlashUnit
	{
		[Register("hasFlashUnit", "()Z", "GetHasFlashUnitHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	string ImplementationType
	{
		[Register("getImplementationType", "()Ljava/lang/String;", "GetGetImplementationTypeHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int SensorRotationDegrees
	{
		[Register("getSensorRotationDegrees", "()I", "GetGetSensorRotationDegreesHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	LiveData TorchState
	{
		[Register("getTorchState", "()Landroidx/lifecycle/LiveData;", "GetGetTorchStateHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	LiveData ZoomState
	{
		[Register("getZoomState", "()Landroidx/lifecycle/LiveData;", "GetGetZoomStateHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe float IntrinsicZoomRatio
	{
		[Register("getIntrinsicZoomRatio", "()F", "GetGetIntrinsicZoomRatioHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getIntrinsicZoomRatio.()F", this, null);
		}
	}

	unsafe bool IsLogicalMultiCameraSupported
	{
		[Register("isLogicalMultiCameraSupported", "()Z", "GetIsLogicalMultiCameraSupportedHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLogicalMultiCameraSupported.()Z", this, null);
		}
	}

	unsafe bool IsPrivateReprocessingSupported
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isPrivateReprocessingSupported", "()Z", "GetIsPrivateReprocessingSupportedHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPrivateReprocessingSupported.()Z", this, null);
		}
	}

	unsafe bool IsZslSupported
	{
		[Register("isZslSupported", "()Z", "GetIsZslSupportedHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isZslSupported.()Z", this, null);
		}
	}

	unsafe int LensFacing
	{
		[Register("getLensFacing", "()I", "GetGetLensFacingHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLensFacing.()I", this, null);
		}
	}

	unsafe ICollection<ICameraInfo> PhysicalCameraInfos
	{
		[Register("getPhysicalCameraInfos", "()Ljava/util/Set;", "GetGetPhysicalCameraInfosHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return JavaSet<ICameraInfo>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPhysicalCameraInfos.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe ICollection<Android.Util.Range> SupportedFrameRateRanges
	{
		[Register("getSupportedFrameRateRanges", "()Ljava/util/Set;", "GetGetSupportedFrameRateRangesHandler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return JavaSet<Android.Util.Range>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedFrameRateRanges.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetIntrinsicZoomRatioHandler()
	{
		if ((object)cb_getIntrinsicZoomRatio == null)
		{
			cb_getIntrinsicZoomRatio = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetIntrinsicZoomRatio));
		}
		return cb_getIntrinsicZoomRatio;
	}

	private static float n_GetIntrinsicZoomRatio(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntrinsicZoomRatio;
	}

	private static Delegate GetIsLogicalMultiCameraSupportedHandler()
	{
		if ((object)cb_isLogicalMultiCameraSupported == null)
		{
			cb_isLogicalMultiCameraSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsLogicalMultiCameraSupported));
		}
		return cb_isLogicalMultiCameraSupported;
	}

	private static bool n_IsLogicalMultiCameraSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLogicalMultiCameraSupported;
	}

	private static Delegate GetIsPrivateReprocessingSupportedHandler()
	{
		if ((object)cb_isPrivateReprocessingSupported == null)
		{
			cb_isPrivateReprocessingSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPrivateReprocessingSupported));
		}
		return cb_isPrivateReprocessingSupported;
	}

	private static bool n_IsPrivateReprocessingSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPrivateReprocessingSupported;
	}

	private static Delegate GetIsZslSupportedHandler()
	{
		if ((object)cb_isZslSupported == null)
		{
			cb_isZslSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsZslSupported));
		}
		return cb_isZslSupported;
	}

	private static bool n_IsZslSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsZslSupported;
	}

	private static Delegate GetGetLensFacingHandler()
	{
		if ((object)cb_getLensFacing == null)
		{
			cb_getLensFacing = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLensFacing));
		}
		return cb_getLensFacing;
	}

	private static int n_GetLensFacing(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LensFacing;
	}

	private static Delegate GetGetPhysicalCameraInfosHandler()
	{
		if ((object)cb_getPhysicalCameraInfos == null)
		{
			cb_getPhysicalCameraInfos = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPhysicalCameraInfos));
		}
		return cb_getPhysicalCameraInfos;
	}

	private static nint n_GetPhysicalCameraInfos(nint jnienv, nint native__this)
	{
		return JavaSet<ICameraInfo>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PhysicalCameraInfos);
	}

	private static Delegate GetGetSupportedFrameRateRangesHandler()
	{
		if ((object)cb_getSupportedFrameRateRanges == null)
		{
			cb_getSupportedFrameRateRanges = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedFrameRateRanges));
		}
		return cb_getSupportedFrameRateRanges;
	}

	private static nint n_GetSupportedFrameRateRanges(nint jnienv, nint native__this)
	{
		return JavaSet<Android.Util.Range>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedFrameRateRanges);
	}

	[Register("getSensorRotationDegrees", "(I)I", "GetGetSensorRotationDegrees_IHandler:AndroidX.Camera.Core.ICameraInfoInvoker, Xamarin.AndroidX.Camera.Core")]
	int GetSensorRotationDegrees(int p0);

	private static Delegate GetIsFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_Handler()
	{
		if ((object)cb_isFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_ == null)
		{
			cb_isFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_));
		}
		return cb_isFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_;
	}

	private static bool n_IsFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_(nint jnienv, nint native__this, nint native_action)
	{
		ICameraInfo? cameraInfo = Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FocusMeteringAction action = Java.Lang.Object.GetObject<FocusMeteringAction>(native_action, JniHandleOwnership.DoNotTransfer);
		return cameraInfo.IsFocusMeteringSupported(action);
	}

	[Register("isFocusMeteringSupported", "(Landroidx/camera/core/FocusMeteringAction;)Z", "GetIsFocusMeteringSupported_Landroidx_camera_core_FocusMeteringAction_Handler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsFocusMeteringSupported(FocusMeteringAction action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocusMeteringSupported.(Landroidx/camera/core/FocusMeteringAction;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	[Register("mustPlayShutterSound", "()Z", "")]
	static unsafe bool MustPlayShutterSound()
	{
		return _members.StaticMethods.InvokeBooleanMethod("mustPlayShutterSound.()Z", null);
	}

	private static Delegate GetQuerySupportedDynamicRanges_Ljava_util_Set_Handler()
	{
		if ((object)cb_querySupportedDynamicRanges_Ljava_util_Set_ == null)
		{
			cb_querySupportedDynamicRanges_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_QuerySupportedDynamicRanges_Ljava_util_Set_));
		}
		return cb_querySupportedDynamicRanges_Ljava_util_Set_;
	}

	private static nint n_QuerySupportedDynamicRanges_Ljava_util_Set_(nint jnienv, nint native__this, nint native_candidateDynamicRanges)
	{
		ICameraInfo? cameraInfo = Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICollection<DynamicRange> candidateDynamicRanges = JavaSet<DynamicRange>.FromJniHandle(native_candidateDynamicRanges, JniHandleOwnership.DoNotTransfer);
		return JavaSet<DynamicRange>.ToLocalJniHandle(cameraInfo.QuerySupportedDynamicRanges(candidateDynamicRanges));
	}

	[Register("querySupportedDynamicRanges", "(Ljava/util/Set;)Ljava/util/Set;", "GetQuerySupportedDynamicRanges_Ljava_util_Set_Handler:AndroidX.Camera.Core.ICameraInfo, Xamarin.AndroidX.Camera.Core")]
	unsafe ICollection<DynamicRange> QuerySupportedDynamicRanges(ICollection<DynamicRange> candidateDynamicRanges)
	{
		nint num = JavaSet<DynamicRange>.ToLocalJniHandle(candidateDynamicRanges);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaSet<DynamicRange>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("querySupportedDynamicRanges.(Ljava/util/Set;)Ljava/util/Set;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(candidateDynamicRanges);
		}
	}
}
