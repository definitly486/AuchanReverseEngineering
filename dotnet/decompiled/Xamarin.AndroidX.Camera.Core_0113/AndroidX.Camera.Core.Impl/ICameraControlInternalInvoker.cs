using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraControlInternal", DoNotGenerateAcw = true)]
internal class ICameraControlInternalInvoker : Java.Lang.Object, ICameraControlInternal, ICameraControl, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraControlInternal", typeof(ICameraControlInternalInvoker));

	private nint class_ref;

	private static Delegate? cb_getFlashMode;

	private static Delegate? cb_setFlashMode_I;

	private nint id_getFlashMode;

	private nint id_setFlashMode_I;

	private static Delegate? cb_getInteropConfig;

	private nint id_getInteropConfig;

	private static Delegate? cb_isZslDisabledByByUserCaseConfig;

	private nint id_isZslDisabledByByUserCaseConfig;

	private static Delegate? cb_getSensorRect;

	private nint id_getSensorRect;

	private static Delegate? cb_getSessionConfig;

	private nint id_getSessionConfig;

	private static Delegate? cb_addInteropConfig_Landroidx_camera_core_impl_Config_;

	private nint id_addInteropConfig_Landroidx_camera_core_impl_Config_;

	private static Delegate? cb_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;

	private nint id_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;

	private static Delegate? cb_clearInteropConfig;

	private nint id_clearInteropConfig;

	private static Delegate? cb_setZslDisabledByUserCaseConfig_Z;

	private nint id_setZslDisabledByUserCaseConfig_Z;

	private static Delegate? cb_submitStillCaptureRequests_Ljava_util_List_II;

	private nint id_submitStillCaptureRequests_Ljava_util_List_II;

	private static Delegate? cb_cancelFocusAndMetering;

	private nint id_cancelFocusAndMetering;

	private static Delegate? cb_enableTorch_Z;

	private nint id_enableTorch_Z;

	private static Delegate? cb_setExposureCompensationIndex_I;

	private nint id_setExposureCompensationIndex_I;

	private static Delegate? cb_setLinearZoom_F;

	private nint id_setLinearZoom_F;

	private static Delegate? cb_setZoomRatio_F;

	private nint id_setZoomRatio_F;

	private static Delegate? cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;

	private nint id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;

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

	public unsafe int FlashMode
	{
		get
		{
			if (id_getFlashMode == IntPtr.Zero)
			{
				id_getFlashMode = JNIEnv.GetMethodID(class_ref, "getFlashMode", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getFlashMode);
		}
		set
		{
			if (id_setFlashMode_I == IntPtr.Zero)
			{
				id_setFlashMode_I = JNIEnv.GetMethodID(class_ref, "setFlashMode", "(I)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(value);
			JNIEnv.CallVoidMethod(base.Handle, id_setFlashMode_I, ptr);
		}
	}

	public IConfig InteropConfig
	{
		get
		{
			if (id_getInteropConfig == IntPtr.Zero)
			{
				id_getInteropConfig = JNIEnv.GetMethodID(class_ref, "getInteropConfig", "()Landroidx/camera/core/impl/Config;");
			}
			return Java.Lang.Object.GetObject<IConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getInteropConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public bool IsZslDisabledByByUserCaseConfig
	{
		get
		{
			if (id_isZslDisabledByByUserCaseConfig == IntPtr.Zero)
			{
				id_isZslDisabledByByUserCaseConfig = JNIEnv.GetMethodID(class_ref, "isZslDisabledByByUserCaseConfig", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isZslDisabledByByUserCaseConfig);
		}
	}

	public Rect SensorRect
	{
		get
		{
			if (id_getSensorRect == IntPtr.Zero)
			{
				id_getSensorRect = JNIEnv.GetMethodID(class_ref, "getSensorRect", "()Landroid/graphics/Rect;");
			}
			return Java.Lang.Object.GetObject<Rect>(JNIEnv.CallObjectMethod(base.Handle, id_getSensorRect), JniHandleOwnership.TransferLocalRef);
		}
	}

	public SessionConfig SessionConfig
	{
		get
		{
			if (id_getSessionConfig == IntPtr.Zero)
			{
				id_getSessionConfig = JNIEnv.GetMethodID(class_ref, "getSessionConfig", "()Landroidx/camera/core/impl/SessionConfig;");
			}
			return Java.Lang.Object.GetObject<SessionConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getSessionConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICameraControlInternal? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraControlInternal>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CameraControlInternal'.");
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

	public ICameraControlInternalInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetFlashModeHandler()
	{
		if ((object)cb_getFlashMode == null)
		{
			cb_getFlashMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFlashMode));
		}
		return cb_getFlashMode;
	}

	private static int n_GetFlashMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlashMode;
	}

	private static Delegate GetSetFlashMode_IHandler()
	{
		if ((object)cb_setFlashMode_I == null)
		{
			cb_setFlashMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFlashMode_I));
		}
		return cb_setFlashMode_I;
	}

	private static void n_SetFlashMode_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlashMode = p0;
	}

	private static Delegate GetGetInteropConfigHandler()
	{
		if ((object)cb_getInteropConfig == null)
		{
			cb_getInteropConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInteropConfig));
		}
		return cb_getInteropConfig;
	}

	private static nint n_GetInteropConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InteropConfig);
	}

	private static Delegate GetIsZslDisabledByByUserCaseConfigHandler()
	{
		if ((object)cb_isZslDisabledByByUserCaseConfig == null)
		{
			cb_isZslDisabledByByUserCaseConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsZslDisabledByByUserCaseConfig));
		}
		return cb_isZslDisabledByByUserCaseConfig;
	}

	private static bool n_IsZslDisabledByByUserCaseConfig(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsZslDisabledByByUserCaseConfig;
	}

	private static Delegate GetGetSensorRectHandler()
	{
		if ((object)cb_getSensorRect == null)
		{
			cb_getSensorRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorRect));
		}
		return cb_getSensorRect;
	}

	private static nint n_GetSensorRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorRect);
	}

	private static Delegate GetGetSessionConfigHandler()
	{
		if ((object)cb_getSessionConfig == null)
		{
			cb_getSessionConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSessionConfig));
		}
		return cb_getSessionConfig;
	}

	private static nint n_GetSessionConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionConfig);
	}

	private static Delegate GetAddInteropConfig_Landroidx_camera_core_impl_Config_Handler()
	{
		if ((object)cb_addInteropConfig_Landroidx_camera_core_impl_Config_ == null)
		{
			cb_addInteropConfig_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddInteropConfig_Landroidx_camera_core_impl_Config_));
		}
		return cb_addInteropConfig_Landroidx_camera_core_impl_Config_;
	}

	private static void n_AddInteropConfig_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraControlInternal? cameraControlInternal = Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig p = Java.Lang.Object.GetObject<IConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraControlInternal.AddInteropConfig(p);
	}

	public unsafe void AddInteropConfig(IConfig p0)
	{
		if (id_addInteropConfig_Landroidx_camera_core_impl_Config_ == IntPtr.Zero)
		{
			id_addInteropConfig_Landroidx_camera_core_impl_Config_ = JNIEnv.GetMethodID(class_ref, "addInteropConfig", "(Landroidx/camera/core/impl/Config;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_addInteropConfig_Landroidx_camera_core_impl_Config_, ptr);
	}

	private static Delegate GetAddZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_Handler()
	{
		if ((object)cb_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ == null)
		{
			cb_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_));
		}
		return cb_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;
	}

	private static void n_AddZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraControlInternal? cameraControlInternal = Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SessionConfig.Builder p = Java.Lang.Object.GetObject<SessionConfig.Builder>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraControlInternal.AddZslConfig(p);
	}

	public unsafe void AddZslConfig(SessionConfig.Builder p0)
	{
		if (id_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ == IntPtr.Zero)
		{
			id_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ = JNIEnv.GetMethodID(class_ref, "addZslConfig", "(Landroidx/camera/core/impl/SessionConfig$Builder;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_addZslConfig_Landroidx_camera_core_impl_SessionConfig_Builder_, ptr);
	}

	private static Delegate GetClearInteropConfigHandler()
	{
		if ((object)cb_clearInteropConfig == null)
		{
			cb_clearInteropConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearInteropConfig));
		}
		return cb_clearInteropConfig;
	}

	private static void n_ClearInteropConfig(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearInteropConfig();
	}

	public void ClearInteropConfig()
	{
		if (id_clearInteropConfig == IntPtr.Zero)
		{
			id_clearInteropConfig = JNIEnv.GetMethodID(class_ref, "clearInteropConfig", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_clearInteropConfig);
	}

	private static Delegate GetSetZslDisabledByUserCaseConfig_ZHandler()
	{
		if ((object)cb_setZslDisabledByUserCaseConfig_Z == null)
		{
			cb_setZslDisabledByUserCaseConfig_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetZslDisabledByUserCaseConfig_Z));
		}
		return cb_setZslDisabledByUserCaseConfig_Z;
	}

	private static void n_SetZslDisabledByUserCaseConfig_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZslDisabledByUserCaseConfig(p0);
	}

	public unsafe void SetZslDisabledByUserCaseConfig(bool p0)
	{
		if (id_setZslDisabledByUserCaseConfig_Z == IntPtr.Zero)
		{
			id_setZslDisabledByUserCaseConfig_Z = JNIEnv.GetMethodID(class_ref, "setZslDisabledByUserCaseConfig", "(Z)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		JNIEnv.CallVoidMethod(base.Handle, id_setZslDisabledByUserCaseConfig_Z, ptr);
	}

	private static Delegate GetSubmitStillCaptureRequests_Ljava_util_List_IIHandler()
	{
		if ((object)cb_submitStillCaptureRequests_Ljava_util_List_II == null)
		{
			cb_submitStillCaptureRequests_Ljava_util_List_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_SubmitStillCaptureRequests_Ljava_util_List_II));
		}
		return cb_submitStillCaptureRequests_Ljava_util_List_II;
	}

	private static nint n_SubmitStillCaptureRequests_Ljava_util_List_II(nint jnienv, nint native__this, nint native_p0, int p1, int p2)
	{
		ICameraControlInternal? cameraControlInternal = Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<CaptureConfig> p3 = JavaList<CaptureConfig>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraControlInternal.SubmitStillCaptureRequests(p3, p1, p2));
	}

	public unsafe IListenableFuture SubmitStillCaptureRequests(IList<CaptureConfig> p0, int p1, int p2)
	{
		if (id_submitStillCaptureRequests_Ljava_util_List_II == IntPtr.Zero)
		{
			id_submitStillCaptureRequests_Ljava_util_List_II = JNIEnv.GetMethodID(class_ref, "submitStillCaptureRequests", "(Ljava/util/List;II)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		nint num = JavaList<CaptureConfig>.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(num);
		ptr[1] = new JValue(p1);
		ptr[2] = new JValue(p2);
		IListenableFuture? result = Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_submitStillCaptureRequests_Ljava_util_List_II, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}

	private static Delegate GetCancelFocusAndMeteringHandler()
	{
		if ((object)cb_cancelFocusAndMetering == null)
		{
			cb_cancelFocusAndMetering = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CancelFocusAndMetering));
		}
		return cb_cancelFocusAndMetering;
	}

	private static nint n_CancelFocusAndMetering(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelFocusAndMetering());
	}

	public IListenableFuture CancelFocusAndMetering()
	{
		if (id_cancelFocusAndMetering == IntPtr.Zero)
		{
			id_cancelFocusAndMetering = JNIEnv.GetMethodID(class_ref, "cancelFocusAndMetering", "()Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_cancelFocusAndMetering), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEnableTorch_ZHandler()
	{
		if ((object)cb_enableTorch_Z == null)
		{
			cb_enableTorch_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_EnableTorch_Z));
		}
		return cb_enableTorch_Z;
	}

	private static nint n_EnableTorch_Z(nint jnienv, nint native__this, bool p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTorch(p0));
	}

	public unsafe IListenableFuture EnableTorch(bool p0)
	{
		if (id_enableTorch_Z == IntPtr.Zero)
		{
			id_enableTorch_Z = JNIEnv.GetMethodID(class_ref, "enableTorch", "(Z)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_enableTorch_Z, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetExposureCompensationIndex_IHandler()
	{
		if ((object)cb_setExposureCompensationIndex_I == null)
		{
			cb_setExposureCompensationIndex_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetExposureCompensationIndex_I));
		}
		return cb_setExposureCompensationIndex_I;
	}

	private static nint n_SetExposureCompensationIndex_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExposureCompensationIndex(p0));
	}

	public unsafe IListenableFuture SetExposureCompensationIndex(int p0)
	{
		if (id_setExposureCompensationIndex_I == IntPtr.Zero)
		{
			id_setExposureCompensationIndex_I = JNIEnv.GetMethodID(class_ref, "setExposureCompensationIndex", "(I)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setExposureCompensationIndex_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetLinearZoom_FHandler()
	{
		if ((object)cb_setLinearZoom_F == null)
		{
			cb_setLinearZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetLinearZoom_F));
		}
		return cb_setLinearZoom_F;
	}

	private static nint n_SetLinearZoom_F(nint jnienv, nint native__this, float p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLinearZoom(p0));
	}

	public unsafe IListenableFuture SetLinearZoom(float p0)
	{
		if (id_setLinearZoom_F == IntPtr.Zero)
		{
			id_setLinearZoom_F = JNIEnv.GetMethodID(class_ref, "setLinearZoom", "(F)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setLinearZoom_F, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetZoomRatio_FHandler()
	{
		if ((object)cb_setZoomRatio_F == null)
		{
			cb_setZoomRatio_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetZoomRatio_F));
		}
		return cb_setZoomRatio_F;
	}

	private static nint n_SetZoomRatio_F(nint jnienv, nint native__this, float p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZoomRatio(p0));
	}

	public unsafe IListenableFuture SetZoomRatio(float p0)
	{
		if (id_setZoomRatio_F == IntPtr.Zero)
		{
			id_setZoomRatio_F = JNIEnv.GetMethodID(class_ref, "setZoomRatio", "(F)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setZoomRatio_F, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_Handler()
	{
		if ((object)cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ == null)
		{
			cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_StartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_));
		}
		return cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;
	}

	private static nint n_StartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraControlInternal? cameraControlInternal = Java.Lang.Object.GetObject<ICameraControlInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FocusMeteringAction p = Java.Lang.Object.GetObject<FocusMeteringAction>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraControlInternal.StartFocusAndMetering(p));
	}

	public unsafe IListenableFuture StartFocusAndMetering(FocusMeteringAction p0)
	{
		if (id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ == IntPtr.Zero)
		{
			id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ = JNIEnv.GetMethodID(class_ref, "startFocusAndMetering", "(Landroidx/camera/core/FocusMeteringAction;)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
