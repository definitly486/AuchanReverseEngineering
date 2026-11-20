using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraInternal", DoNotGenerateAcw = true)]
internal class ICameraInternalInvoker : Java.Lang.Object, ICameraInternal, ICamera, IJavaObject, IDisposable, IJavaPeerable, UseCase.IStateChangeCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraInternal", typeof(ICameraInternalInvoker));

	private nint class_ref;

	private static Delegate? cb_getCameraControlInternal;

	private nint id_getCameraControlInternal;

	private static Delegate? cb_getCameraInfoInternal;

	private nint id_getCameraInfoInternal;

	private static Delegate? cb_getCameraState;

	private nint id_getCameraState;

	private static Delegate? cb_attachUseCases_Ljava_util_Collection_;

	private nint id_attachUseCases_Ljava_util_Collection_;

	private static Delegate? cb_close;

	private nint id_close;

	private static Delegate? cb_detachUseCases_Ljava_util_Collection_;

	private nint id_detachUseCases_Ljava_util_Collection_;

	private static Delegate? cb_open;

	private nint id_open;

	private static Delegate? cb_release;

	private nint id_release;

	private static Delegate? cb_getCameraControl;

	private nint id_getCameraControl;

	private static Delegate? cb_getCameraInfo;

	private nint id_getCameraInfo;

	private static Delegate? cb_getExtendedConfig;

	private nint id_getExtendedConfig;

	private static Delegate? cb_onUseCaseActive_Landroidx_camera_core_UseCase_;

	private nint id_onUseCaseActive_Landroidx_camera_core_UseCase_;

	private static Delegate? cb_onUseCaseInactive_Landroidx_camera_core_UseCase_;

	private nint id_onUseCaseInactive_Landroidx_camera_core_UseCase_;

	private static Delegate? cb_onUseCaseReset_Landroidx_camera_core_UseCase_;

	private nint id_onUseCaseReset_Landroidx_camera_core_UseCase_;

	private static Delegate? cb_onUseCaseUpdated_Landroidx_camera_core_UseCase_;

	private nint id_onUseCaseUpdated_Landroidx_camera_core_UseCase_;

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

	public ICameraControlInternal CameraControlInternal
	{
		get
		{
			if (id_getCameraControlInternal == IntPtr.Zero)
			{
				id_getCameraControlInternal = JNIEnv.GetMethodID(class_ref, "getCameraControlInternal", "()Landroidx/camera/core/impl/CameraControlInternal;");
			}
			return Java.Lang.Object.GetObject<ICameraControlInternal>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraControlInternal), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraInfoInternal CameraInfoInternal
	{
		get
		{
			if (id_getCameraInfoInternal == IntPtr.Zero)
			{
				id_getCameraInfoInternal = JNIEnv.GetMethodID(class_ref, "getCameraInfoInternal", "()Landroidx/camera/core/impl/CameraInfoInternal;");
			}
			return Java.Lang.Object.GetObject<ICameraInfoInternal>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraInfoInternal), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IObservable CameraState
	{
		get
		{
			if (id_getCameraState == IntPtr.Zero)
			{
				id_getCameraState = JNIEnv.GetMethodID(class_ref, "getCameraState", "()Landroidx/camera/core/impl/Observable;");
			}
			return Java.Lang.Object.GetObject<IObservable>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraControl CameraControl
	{
		get
		{
			if (id_getCameraControl == IntPtr.Zero)
			{
				id_getCameraControl = JNIEnv.GetMethodID(class_ref, "getCameraControl", "()Landroidx/camera/core/CameraControl;");
			}
			return Java.Lang.Object.GetObject<ICameraControl>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraControl), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraInfo CameraInfo
	{
		get
		{
			if (id_getCameraInfo == IntPtr.Zero)
			{
				id_getCameraInfo = JNIEnv.GetMethodID(class_ref, "getCameraInfo", "()Landroidx/camera/core/CameraInfo;");
			}
			return Java.Lang.Object.GetObject<ICameraInfo>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraInfo), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraConfig ExtendedConfig
	{
		get
		{
			if (id_getExtendedConfig == IntPtr.Zero)
			{
				id_getExtendedConfig = JNIEnv.GetMethodID(class_ref, "getExtendedConfig", "()Landroidx/camera/core/impl/CameraConfig;");
			}
			return Java.Lang.Object.GetObject<ICameraConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getExtendedConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICameraInternal? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraInternal>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CameraInternal'.");
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

	public ICameraInternalInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCameraControlInternalHandler()
	{
		if ((object)cb_getCameraControlInternal == null)
		{
			cb_getCameraControlInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraControlInternal));
		}
		return cb_getCameraControlInternal;
	}

	private static nint n_GetCameraControlInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraControlInternal);
	}

	private static Delegate GetGetCameraInfoInternalHandler()
	{
		if ((object)cb_getCameraInfoInternal == null)
		{
			cb_getCameraInfoInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraInfoInternal));
		}
		return cb_getCameraInfoInternal;
	}

	private static nint n_GetCameraInfoInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraInfoInternal);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraState);
	}

	private static Delegate GetAttachUseCases_Ljava_util_Collection_Handler()
	{
		if ((object)cb_attachUseCases_Ljava_util_Collection_ == null)
		{
			cb_attachUseCases_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AttachUseCases_Ljava_util_Collection_));
		}
		return cb_attachUseCases_Ljava_util_Collection_;
	}

	private static void n_AttachUseCases_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICollection<UseCase> p = JavaCollection<UseCase>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.AttachUseCases(p);
	}

	public unsafe void AttachUseCases(ICollection<UseCase> p0)
	{
		if (id_attachUseCases_Ljava_util_Collection_ == IntPtr.Zero)
		{
			id_attachUseCases_Ljava_util_Collection_ = JNIEnv.GetMethodID(class_ref, "attachUseCases", "(Ljava/util/Collection;)V");
		}
		nint num = JavaCollection<UseCase>.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		JNIEnv.CallVoidMethod(base.Handle, id_attachUseCases_Ljava_util_Collection_, ptr);
		JNIEnv.DeleteLocalRef(num);
	}

	private static Delegate GetCloseHandler()
	{
		if ((object)cb_close == null)
		{
			cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
		}
		return cb_close;
	}

	private static void n_Close(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
	}

	public void Close()
	{
		if (id_close == IntPtr.Zero)
		{
			id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_close);
	}

	private static Delegate GetDetachUseCases_Ljava_util_Collection_Handler()
	{
		if ((object)cb_detachUseCases_Ljava_util_Collection_ == null)
		{
			cb_detachUseCases_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DetachUseCases_Ljava_util_Collection_));
		}
		return cb_detachUseCases_Ljava_util_Collection_;
	}

	private static void n_DetachUseCases_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICollection<UseCase> p = JavaCollection<UseCase>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.DetachUseCases(p);
	}

	public unsafe void DetachUseCases(ICollection<UseCase> p0)
	{
		if (id_detachUseCases_Ljava_util_Collection_ == IntPtr.Zero)
		{
			id_detachUseCases_Ljava_util_Collection_ = JNIEnv.GetMethodID(class_ref, "detachUseCases", "(Ljava/util/Collection;)V");
		}
		nint num = JavaCollection<UseCase>.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		JNIEnv.CallVoidMethod(base.Handle, id_detachUseCases_Ljava_util_Collection_, ptr);
		JNIEnv.DeleteLocalRef(num);
	}

	private static Delegate GetOpenHandler()
	{
		if ((object)cb_open == null)
		{
			cb_open = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Open));
		}
		return cb_open;
	}

	private static void n_Open(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Open();
	}

	public void Open()
	{
		if (id_open == IntPtr.Zero)
		{
			id_open = JNIEnv.GetMethodID(class_ref, "open", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_open);
	}

	private static Delegate GetReleaseHandler()
	{
		if ((object)cb_release == null)
		{
			cb_release = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Release));
		}
		return cb_release;
	}

	private static nint n_Release(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Release());
	}

	public IListenableFuture Release()
	{
		if (id_release == IntPtr.Zero)
		{
			id_release = JNIEnv.GetMethodID(class_ref, "release", "()Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_release), JniHandleOwnership.TransferLocalRef);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraControl);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraInfo);
	}

	private static Delegate GetGetExtendedConfigHandler()
	{
		if ((object)cb_getExtendedConfig == null)
		{
			cb_getExtendedConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtendedConfig));
		}
		return cb_getExtendedConfig;
	}

	private static nint n_GetExtendedConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExtendedConfig);
	}

	private static Delegate GetOnUseCaseActive_Landroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_onUseCaseActive_Landroidx_camera_core_UseCase_ == null)
		{
			cb_onUseCaseActive_Landroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUseCaseActive_Landroidx_camera_core_UseCase_));
		}
		return cb_onUseCaseActive_Landroidx_camera_core_UseCase_;
	}

	private static void n_OnUseCaseActive_Landroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.OnUseCaseActive(p);
	}

	public unsafe void OnUseCaseActive(UseCase p0)
	{
		if (id_onUseCaseActive_Landroidx_camera_core_UseCase_ == IntPtr.Zero)
		{
			id_onUseCaseActive_Landroidx_camera_core_UseCase_ = JNIEnv.GetMethodID(class_ref, "onUseCaseActive", "(Landroidx/camera/core/UseCase;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onUseCaseActive_Landroidx_camera_core_UseCase_, ptr);
	}

	private static Delegate GetOnUseCaseInactive_Landroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_onUseCaseInactive_Landroidx_camera_core_UseCase_ == null)
		{
			cb_onUseCaseInactive_Landroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUseCaseInactive_Landroidx_camera_core_UseCase_));
		}
		return cb_onUseCaseInactive_Landroidx_camera_core_UseCase_;
	}

	private static void n_OnUseCaseInactive_Landroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.OnUseCaseInactive(p);
	}

	public unsafe void OnUseCaseInactive(UseCase p0)
	{
		if (id_onUseCaseInactive_Landroidx_camera_core_UseCase_ == IntPtr.Zero)
		{
			id_onUseCaseInactive_Landroidx_camera_core_UseCase_ = JNIEnv.GetMethodID(class_ref, "onUseCaseInactive", "(Landroidx/camera/core/UseCase;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onUseCaseInactive_Landroidx_camera_core_UseCase_, ptr);
	}

	private static Delegate GetOnUseCaseReset_Landroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_onUseCaseReset_Landroidx_camera_core_UseCase_ == null)
		{
			cb_onUseCaseReset_Landroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUseCaseReset_Landroidx_camera_core_UseCase_));
		}
		return cb_onUseCaseReset_Landroidx_camera_core_UseCase_;
	}

	private static void n_OnUseCaseReset_Landroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.OnUseCaseReset(p);
	}

	public unsafe void OnUseCaseReset(UseCase p0)
	{
		if (id_onUseCaseReset_Landroidx_camera_core_UseCase_ == IntPtr.Zero)
		{
			id_onUseCaseReset_Landroidx_camera_core_UseCase_ = JNIEnv.GetMethodID(class_ref, "onUseCaseReset", "(Landroidx/camera/core/UseCase;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onUseCaseReset_Landroidx_camera_core_UseCase_, ptr);
	}

	private static Delegate GetOnUseCaseUpdated_Landroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_onUseCaseUpdated_Landroidx_camera_core_UseCase_ == null)
		{
			cb_onUseCaseUpdated_Landroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUseCaseUpdated_Landroidx_camera_core_UseCase_));
		}
		return cb_onUseCaseUpdated_Landroidx_camera_core_UseCase_;
	}

	private static void n_OnUseCaseUpdated_Landroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraInternal.OnUseCaseUpdated(p);
	}

	public unsafe void OnUseCaseUpdated(UseCase p0)
	{
		if (id_onUseCaseUpdated_Landroidx_camera_core_UseCase_ == IntPtr.Zero)
		{
			id_onUseCaseUpdated_Landroidx_camera_core_UseCase_ = JNIEnv.GetMethodID(class_ref, "onUseCaseUpdated", "(Landroidx/camera/core/UseCase;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onUseCaseUpdated_Landroidx_camera_core_UseCase_, ptr);
	}
}
