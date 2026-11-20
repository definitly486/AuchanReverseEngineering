using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraInfoInternal", DoNotGenerateAcw = true)]
internal class ICameraInfoInternalInvoker : Java.Lang.Object, ICameraInfoInternal, ICameraInfo, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraInfoInternal", typeof(ICameraInfoInternalInvoker));

	private nint class_ref;

	private static Delegate? cb_getCameraCharacteristics;

	private nint id_getCameraCharacteristics;

	private static Delegate? cb_getCameraId;

	private nint id_getCameraId;

	private static Delegate? cb_getCameraQuirks;

	private nint id_getCameraQuirks;

	private static Delegate? cb_getEncoderProfilesProvider;

	private nint id_getEncoderProfilesProvider;

	private static Delegate? cb_isPreviewStabilizationSupported;

	private nint id_isPreviewStabilizationSupported;

	private static Delegate? cb_isVideoStabilizationSupported;

	private nint id_isVideoStabilizationSupported;

	private static Delegate? cb_getSupportedDynamicRanges;

	private nint id_getSupportedDynamicRanges;

	private static Delegate? cb_getSupportedOutputFormats;

	private nint id_getSupportedOutputFormats;

	private static Delegate? cb_getTimebase;

	private nint id_getTimebase;

	private static Delegate? cb_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_;

	private nint id_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_;

	private static Delegate? cb_getPhysicalCameraCharacteristics_Ljava_lang_String_;

	private nint id_getPhysicalCameraCharacteristics_Ljava_lang_String_;

	private static Delegate? cb_getSupportedHighResolutions_I;

	private nint id_getSupportedHighResolutions_I;

	private static Delegate? cb_getSupportedResolutions_I;

	private nint id_getSupportedResolutions_I;

	private static Delegate? cb_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;

	private nint id_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;

	private static Delegate? cb_getCameraSelector;

	private nint id_getCameraSelector;

	private static Delegate? cb_getCameraState;

	private nint id_getCameraState;

	private static Delegate? cb_getExposureState;

	private nint id_getExposureState;

	private static Delegate? cb_hasFlashUnit;

	private nint id_hasFlashUnit;

	private static Delegate? cb_getImplementationType;

	private nint id_getImplementationType;

	private static Delegate? cb_getSensorRotationDegrees;

	private nint id_getSensorRotationDegrees;

	private static Delegate? cb_getTorchState;

	private nint id_getTorchState;

	private static Delegate? cb_getZoomState;

	private nint id_getZoomState;

	private static Delegate? cb_getSensorRotationDegrees_I;

	private nint id_getSensorRotationDegrees_I;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public Java.Lang.Object CameraCharacteristics
	{
		get
		{
			if (id_getCameraCharacteristics == IntPtr.Zero)
			{
				id_getCameraCharacteristics = JNIEnv.GetMethodID(class_ref, "getCameraCharacteristics", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraCharacteristics), JniHandleOwnership.TransferLocalRef);
		}
	}

	public string CameraId
	{
		get
		{
			if (id_getCameraId == IntPtr.Zero)
			{
				id_getCameraId = JNIEnv.GetMethodID(class_ref, "getCameraId", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getCameraId), JniHandleOwnership.TransferLocalRef);
		}
	}

	public Quirks CameraQuirks
	{
		get
		{
			if (id_getCameraQuirks == IntPtr.Zero)
			{
				id_getCameraQuirks = JNIEnv.GetMethodID(class_ref, "getCameraQuirks", "()Landroidx/camera/core/impl/Quirks;");
			}
			return Java.Lang.Object.GetObject<Quirks>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraQuirks), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IEncoderProfilesProvider EncoderProfilesProvider
	{
		get
		{
			if (id_getEncoderProfilesProvider == IntPtr.Zero)
			{
				id_getEncoderProfilesProvider = JNIEnv.GetMethodID(class_ref, "getEncoderProfilesProvider", "()Landroidx/camera/core/impl/EncoderProfilesProvider;");
			}
			return Java.Lang.Object.GetObject<IEncoderProfilesProvider>(JNIEnv.CallObjectMethod(base.Handle, id_getEncoderProfilesProvider), JniHandleOwnership.TransferLocalRef);
		}
	}

	public bool IsPreviewStabilizationSupported
	{
		get
		{
			if (id_isPreviewStabilizationSupported == IntPtr.Zero)
			{
				id_isPreviewStabilizationSupported = JNIEnv.GetMethodID(class_ref, "isPreviewStabilizationSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isPreviewStabilizationSupported);
		}
	}

	public bool IsVideoStabilizationSupported
	{
		get
		{
			if (id_isVideoStabilizationSupported == IntPtr.Zero)
			{
				id_isVideoStabilizationSupported = JNIEnv.GetMethodID(class_ref, "isVideoStabilizationSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isVideoStabilizationSupported);
		}
	}

	public ICollection<DynamicRange> SupportedDynamicRanges
	{
		get
		{
			if (id_getSupportedDynamicRanges == IntPtr.Zero)
			{
				id_getSupportedDynamicRanges = JNIEnv.GetMethodID(class_ref, "getSupportedDynamicRanges", "()Ljava/util/Set;");
			}
			return JavaSet<DynamicRange>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedDynamicRanges), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICollection<Integer> SupportedOutputFormats
	{
		get
		{
			if (id_getSupportedOutputFormats == IntPtr.Zero)
			{
				id_getSupportedOutputFormats = JNIEnv.GetMethodID(class_ref, "getSupportedOutputFormats", "()Ljava/util/Set;");
			}
			return JavaSet<Integer>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedOutputFormats), JniHandleOwnership.TransferLocalRef);
		}
	}

	public Timebase Timebase
	{
		get
		{
			if (id_getTimebase == IntPtr.Zero)
			{
				id_getTimebase = JNIEnv.GetMethodID(class_ref, "getTimebase", "()Landroidx/camera/core/impl/Timebase;");
			}
			return Java.Lang.Object.GetObject<Timebase>(JNIEnv.CallObjectMethod(base.Handle, id_getTimebase), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraSelector CameraSelector
	{
		get
		{
			if (id_getCameraSelector == IntPtr.Zero)
			{
				id_getCameraSelector = JNIEnv.GetMethodID(class_ref, "getCameraSelector", "()Landroidx/camera/core/CameraSelector;");
			}
			return Java.Lang.Object.GetObject<CameraSelector>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraSelector), JniHandleOwnership.TransferLocalRef);
		}
	}

	public LiveData CameraState
	{
		get
		{
			if (id_getCameraState == IntPtr.Zero)
			{
				id_getCameraState = JNIEnv.GetMethodID(class_ref, "getCameraState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IExposureState ExposureState
	{
		get
		{
			if (id_getExposureState == IntPtr.Zero)
			{
				id_getExposureState = JNIEnv.GetMethodID(class_ref, "getExposureState", "()Landroidx/camera/core/ExposureState;");
			}
			return Java.Lang.Object.GetObject<IExposureState>(JNIEnv.CallObjectMethod(base.Handle, id_getExposureState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public bool HasFlashUnit
	{
		get
		{
			if (id_hasFlashUnit == IntPtr.Zero)
			{
				id_hasFlashUnit = JNIEnv.GetMethodID(class_ref, "hasFlashUnit", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_hasFlashUnit);
		}
	}

	public string ImplementationType
	{
		get
		{
			if (id_getImplementationType == IntPtr.Zero)
			{
				id_getImplementationType = JNIEnv.GetMethodID(class_ref, "getImplementationType", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getImplementationType), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int SensorRotationDegrees
	{
		get
		{
			if (id_getSensorRotationDegrees == IntPtr.Zero)
			{
				id_getSensorRotationDegrees = JNIEnv.GetMethodID(class_ref, "getSensorRotationDegrees", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getSensorRotationDegrees);
		}
	}

	public LiveData TorchState
	{
		get
		{
			if (id_getTorchState == IntPtr.Zero)
			{
				id_getTorchState = JNIEnv.GetMethodID(class_ref, "getTorchState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getTorchState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public LiveData ZoomState
	{
		get
		{
			if (id_getZoomState == IntPtr.Zero)
			{
				id_getZoomState = JNIEnv.GetMethodID(class_ref, "getZoomState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getZoomState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICameraInfoInternal? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CameraInfoInternal'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public ICameraInfoInternalInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCameraCharacteristicsHandler()
	{
		if ((object)cb_getCameraCharacteristics == null)
		{
			cb_getCameraCharacteristics = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraCharacteristics));
		}
		return cb_getCameraCharacteristics;
	}

	private static nint n_GetCameraCharacteristics(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraCharacteristics);
	}

	private static Delegate GetGetCameraIdHandler()
	{
		if ((object)cb_getCameraId == null)
		{
			cb_getCameraId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraId));
		}
		return cb_getCameraId;
	}

	private static nint n_GetCameraId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraId);
	}

	private static Delegate GetGetCameraQuirksHandler()
	{
		if ((object)cb_getCameraQuirks == null)
		{
			cb_getCameraQuirks = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraQuirks));
		}
		return cb_getCameraQuirks;
	}

	private static nint n_GetCameraQuirks(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraQuirks);
	}

	private static Delegate GetGetEncoderProfilesProviderHandler()
	{
		if ((object)cb_getEncoderProfilesProvider == null)
		{
			cb_getEncoderProfilesProvider = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEncoderProfilesProvider));
		}
		return cb_getEncoderProfilesProvider;
	}

	private static nint n_GetEncoderProfilesProvider(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EncoderProfilesProvider);
	}

	private static Delegate GetIsPreviewStabilizationSupportedHandler()
	{
		if ((object)cb_isPreviewStabilizationSupported == null)
		{
			cb_isPreviewStabilizationSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPreviewStabilizationSupported));
		}
		return cb_isPreviewStabilizationSupported;
	}

	private static bool n_IsPreviewStabilizationSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPreviewStabilizationSupported;
	}

	private static Delegate GetIsVideoStabilizationSupportedHandler()
	{
		if ((object)cb_isVideoStabilizationSupported == null)
		{
			cb_isVideoStabilizationSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVideoStabilizationSupported));
		}
		return cb_isVideoStabilizationSupported;
	}

	private static bool n_IsVideoStabilizationSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVideoStabilizationSupported;
	}

	private static Delegate GetGetSupportedDynamicRangesHandler()
	{
		if ((object)cb_getSupportedDynamicRanges == null)
		{
			cb_getSupportedDynamicRanges = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedDynamicRanges));
		}
		return cb_getSupportedDynamicRanges;
	}

	private static nint n_GetSupportedDynamicRanges(nint jnienv, nint native__this)
	{
		return JavaSet<DynamicRange>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedDynamicRanges);
	}

	private static Delegate GetGetSupportedOutputFormatsHandler()
	{
		if ((object)cb_getSupportedOutputFormats == null)
		{
			cb_getSupportedOutputFormats = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedOutputFormats));
		}
		return cb_getSupportedOutputFormats;
	}

	private static nint n_GetSupportedOutputFormats(nint jnienv, nint native__this)
	{
		return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedOutputFormats);
	}

	private static Delegate GetGetTimebaseHandler()
	{
		if ((object)cb_getTimebase == null)
		{
			cb_getTimebase = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTimebase));
		}
		return cb_getTimebase;
	}

	private static nint n_GetTimebase(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timebase);
	}

	private static Delegate GetAddSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_Handler()
	{
		if ((object)cb_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_ == null)
		{
			cb_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_));
		}
		return cb_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_;
	}

	private static void n_AddSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ICameraInfoInternal? cameraInfoInternal = Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
		CameraCaptureCallback p2 = Java.Lang.Object.GetObject<CameraCaptureCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		cameraInfoInternal.AddSessionCaptureCallback(p, p2);
	}

	public unsafe void AddSessionCaptureCallback(IExecutor p0, CameraCaptureCallback p1)
	{
		if (id_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_ == IntPtr.Zero)
		{
			id_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNIEnv.GetMethodID(class_ref, "addSessionCaptureCallback", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/CameraCaptureCallback;)V");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_addSessionCaptureCallback_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_CameraCaptureCallback_, ptr);
	}

	private static Delegate GetGetPhysicalCameraCharacteristics_Ljava_lang_String_Handler()
	{
		if ((object)cb_getPhysicalCameraCharacteristics_Ljava_lang_String_ == null)
		{
			cb_getPhysicalCameraCharacteristics_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPhysicalCameraCharacteristics_Ljava_lang_String_));
		}
		return cb_getPhysicalCameraCharacteristics_Ljava_lang_String_;
	}

	private static nint n_GetPhysicalCameraCharacteristics_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInfoInternal? cameraInfoInternal = Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraInfoInternal.GetPhysicalCameraCharacteristics(p));
	}

	public unsafe Java.Lang.Object? GetPhysicalCameraCharacteristics(string p0)
	{
		if (id_getPhysicalCameraCharacteristics_Ljava_lang_String_ == IntPtr.Zero)
		{
			id_getPhysicalCameraCharacteristics_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getPhysicalCameraCharacteristics", "(Ljava/lang/String;)Ljava/lang/Object;");
		}
		nint num = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		Java.Lang.Object? result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getPhysicalCameraCharacteristics_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}

	private static Delegate GetGetSupportedHighResolutions_IHandler()
	{
		if ((object)cb_getSupportedHighResolutions_I == null)
		{
			cb_getSupportedHighResolutions_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetSupportedHighResolutions_I));
		}
		return cb_getSupportedHighResolutions_I;
	}

	private static nint n_GetSupportedHighResolutions_I(nint jnienv, nint native__this, int p0)
	{
		return JavaList<Size>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSupportedHighResolutions(p0));
	}

	public unsafe IList<Size> GetSupportedHighResolutions(int p0)
	{
		if (id_getSupportedHighResolutions_I == IntPtr.Zero)
		{
			id_getSupportedHighResolutions_I = JNIEnv.GetMethodID(class_ref, "getSupportedHighResolutions", "(I)Ljava/util/List;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return JavaList<Size>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedHighResolutions_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetSupportedResolutions_IHandler()
	{
		if ((object)cb_getSupportedResolutions_I == null)
		{
			cb_getSupportedResolutions_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetSupportedResolutions_I));
		}
		return cb_getSupportedResolutions_I;
	}

	private static nint n_GetSupportedResolutions_I(nint jnienv, nint native__this, int p0)
	{
		return JavaList<Size>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSupportedResolutions(p0));
	}

	public unsafe IList<Size> GetSupportedResolutions(int p0)
	{
		if (id_getSupportedResolutions_I == IntPtr.Zero)
		{
			id_getSupportedResolutions_I = JNIEnv.GetMethodID(class_ref, "getSupportedResolutions", "(I)Ljava/util/List;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return JavaList<Size>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedResolutions_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler()
	{
		if ((object)cb_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ == null)
		{
			cb_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_));
		}
		return cb_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;
	}

	private static void n_RemoveSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInfoInternal? cameraInfoInternal = Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraCaptureCallback p = Java.Lang.Object.GetObject<CameraCaptureCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInfoInternal.RemoveSessionCaptureCallback(p);
	}

	public unsafe void RemoveSessionCaptureCallback(CameraCaptureCallback p0)
	{
		if (id_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ == IntPtr.Zero)
		{
			id_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNIEnv.GetMethodID(class_ref, "removeSessionCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_removeSessionCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_, ptr);
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

	private static Delegate GetGetCameraStateHandler()
	{
		if ((object)cb_getCameraState == null)
		{
			cb_getCameraState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraState));
		}
		return cb_getCameraState;
	}

	private static nint n_GetCameraState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraState);
	}

	private static Delegate GetGetExposureStateHandler()
	{
		if ((object)cb_getExposureState == null)
		{
			cb_getExposureState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExposureState));
		}
		return cb_getExposureState;
	}

	private static nint n_GetExposureState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExposureState);
	}

	private static Delegate GetHasFlashUnitHandler()
	{
		if ((object)cb_hasFlashUnit == null)
		{
			cb_hasFlashUnit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFlashUnit));
		}
		return cb_hasFlashUnit;
	}

	private static bool n_HasFlashUnit(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFlashUnit;
	}

	private static Delegate GetGetImplementationTypeHandler()
	{
		if ((object)cb_getImplementationType == null)
		{
			cb_getImplementationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImplementationType));
		}
		return cb_getImplementationType;
	}

	private static nint n_GetImplementationType(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImplementationType);
	}

	private static Delegate GetGetSensorRotationDegreesHandler()
	{
		if ((object)cb_getSensorRotationDegrees == null)
		{
			cb_getSensorRotationDegrees = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSensorRotationDegrees));
		}
		return cb_getSensorRotationDegrees;
	}

	private static int n_GetSensorRotationDegrees(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorRotationDegrees;
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TorchState);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomState);
	}

	private static Delegate GetGetSensorRotationDegrees_IHandler()
	{
		if ((object)cb_getSensorRotationDegrees_I == null)
		{
			cb_getSensorRotationDegrees_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetSensorRotationDegrees_I));
		}
		return cb_getSensorRotationDegrees_I;
	}

	private static int n_GetSensorRotationDegrees_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<ICameraInfoInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSensorRotationDegrees(p0);
	}

	public unsafe int GetSensorRotationDegrees(int p0)
	{
		if (id_getSensorRotationDegrees_I == IntPtr.Zero)
		{
			id_getSensorRotationDegrees_I = JNIEnv.GetMethodID(class_ref, "getSensorRotationDegrees", "(I)I");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return JNIEnv.CallIntMethod(base.Handle, id_getSensorRotationDegrees_I, ptr);
	}
}
