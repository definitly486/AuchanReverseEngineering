using System;
using System.Collections.Generic;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraInternal", "", "AndroidX.Camera.Core.Impl.ICameraInternalInvoker")]
public interface ICameraInternal : ICamera, IJavaObject, IDisposable, IJavaPeerable, UseCase.IStateChangeCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraInternal", typeof(ICameraInternal), isInterface: true);

	private static Delegate? cb_getCameraControl;

	private static Delegate? cb_getCameraInfo;

	private static Delegate? cb_getExtendedConfig;

	private static Delegate? cb_setExtendedConfig_Landroidx_camera_core_impl_CameraConfig_;

	private static Delegate? cb_getHasTransform;

	private static Delegate? cb_isFrontFacing;

	private static Delegate? cb_setActiveResumingMode_Z;

	private static Delegate? cb_setPrimary_Z;

	ICameraControlInternal CameraControlInternal
	{
		[Register("getCameraControlInternal", "()Landroidx/camera/core/impl/CameraControlInternal;", "GetGetCameraControlInternalHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICameraInfoInternal CameraInfoInternal
	{
		[Register("getCameraInfoInternal", "()Landroidx/camera/core/impl/CameraInfoInternal;", "GetGetCameraInfoInternalHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IObservable CameraState
	{
		[Register("getCameraState", "()Landroidx/camera/core/impl/Observable;", "GetGetCameraStateHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	new unsafe ICameraControl CameraControl
	{
		[Register("getCameraControl", "()Landroidx/camera/core/CameraControl;", "GetGetCameraControlHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraControl>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraControl.()Landroidx/camera/core/CameraControl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	new unsafe ICameraInfo CameraInfo
	{
		[Register("getCameraInfo", "()Landroidx/camera/core/CameraInfo;", "GetGetCameraInfoHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraInfo.()Landroidx/camera/core/CameraInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	new unsafe ICameraConfig ExtendedConfig
	{
		[Register("getExtendedConfig", "()Landroidx/camera/core/impl/CameraConfig;", "GetGetExtendedConfigHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtendedConfig.()Landroidx/camera/core/impl/CameraConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setExtendedConfig", "(Landroidx/camera/core/impl/CameraConfig;)V", "GetSetExtendedConfig_Landroidx_camera_core_impl_CameraConfig_Handler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExtendedConfig.(Landroidx/camera/core/impl/CameraConfig;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	unsafe bool HasTransform
	{
		[Register("getHasTransform", "()Z", "GetGetHasTransformHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getHasTransform.()Z", this, null);
		}
	}

	unsafe bool IsFrontFacing
	{
		[Register("isFrontFacing", "()Z", "GetIsFrontFacingHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFrontFacing.()Z", this, null);
		}
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

	private static Delegate GetSetExtendedConfig_Landroidx_camera_core_impl_CameraConfig_Handler()
	{
		if ((object)cb_setExtendedConfig_Landroidx_camera_core_impl_CameraConfig_ == null)
		{
			cb_setExtendedConfig_Landroidx_camera_core_impl_CameraConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExtendedConfig_Landroidx_camera_core_impl_CameraConfig_));
		}
		return cb_setExtendedConfig_Landroidx_camera_core_impl_CameraConfig_;
	}

	private static void n_SetExtendedConfig_Landroidx_camera_core_impl_CameraConfig_(nint jnienv, nint native__this, nint native_cameraConfig)
	{
		ICameraInternal? cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraConfig extendedConfig = Java.Lang.Object.GetObject<ICameraConfig>(native_cameraConfig, JniHandleOwnership.DoNotTransfer);
		cameraInternal.ExtendedConfig = extendedConfig;
	}

	private static Delegate GetGetHasTransformHandler()
	{
		if ((object)cb_getHasTransform == null)
		{
			cb_getHasTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetHasTransform));
		}
		return cb_getHasTransform;
	}

	private static bool n_GetHasTransform(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasTransform;
	}

	private static Delegate GetIsFrontFacingHandler()
	{
		if ((object)cb_isFrontFacing == null)
		{
			cb_isFrontFacing = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFrontFacing));
		}
		return cb_isFrontFacing;
	}

	private static bool n_IsFrontFacing(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFrontFacing;
	}

	[Register("attachUseCases", "(Ljava/util/Collection;)V", "GetAttachUseCases_Ljava_util_Collection_Handler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void AttachUseCases(ICollection<UseCase> p0);

	[Register("close", "()V", "GetCloseHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void Close();

	[Register("detachUseCases", "(Ljava/util/Collection;)V", "GetDetachUseCases_Ljava_util_Collection_Handler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void DetachUseCases(ICollection<UseCase> p0);

	[Register("open", "()V", "GetOpenHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	void Open();

	[Register("release", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetReleaseHandler:AndroidX.Camera.Core.Impl.ICameraInternalInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture Release();

	private static Delegate GetSetActiveResumingMode_ZHandler()
	{
		if ((object)cb_setActiveResumingMode_Z == null)
		{
			cb_setActiveResumingMode_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetActiveResumingMode_Z));
		}
		return cb_setActiveResumingMode_Z;
	}

	private static void n_SetActiveResumingMode_Z(nint jnienv, nint native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveResumingMode(enabled);
	}

	[Register("setActiveResumingMode", "(Z)V", "GetSetActiveResumingMode_ZHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe void SetActiveResumingMode(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveResumingMode.(Z)V", this, ptr);
	}

	private static Delegate GetSetPrimary_ZHandler()
	{
		if ((object)cb_setPrimary_Z == null)
		{
			cb_setPrimary_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetPrimary_Z));
		}
		return cb_setPrimary_Z;
	}

	private static void n_SetPrimary_Z(nint jnienv, nint native__this, bool isPrimary)
	{
		Java.Lang.Object.GetObject<ICameraInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPrimary(isPrimary);
	}

	[Register("setPrimary", "(Z)V", "GetSetPrimary_ZHandler:AndroidX.Camera.Core.Impl.ICameraInternal, Xamarin.AndroidX.Camera.Core")]
	unsafe void SetPrimary(bool isPrimary)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isPrimary);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimary.(Z)V", this, ptr);
	}
}
