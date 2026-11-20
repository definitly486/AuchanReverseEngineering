using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/UseCase", DoNotGenerateAcw = true)]
public abstract class UseCase : Java.Lang.Object
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/camera/core/UseCase$StateChangeCallback", "", "AndroidX.Camera.Core.UseCase/IStateChangeCallbackInvoker")]
	public interface IStateChangeCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onUseCaseActive", "(Landroidx/camera/core/UseCase;)V", "GetOnUseCaseActive_Landroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.UseCase/IStateChangeCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnUseCaseActive(UseCase p0);

		[Register("onUseCaseInactive", "(Landroidx/camera/core/UseCase;)V", "GetOnUseCaseInactive_Landroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.UseCase/IStateChangeCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnUseCaseInactive(UseCase p0);

		[Register("onUseCaseReset", "(Landroidx/camera/core/UseCase;)V", "GetOnUseCaseReset_Landroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.UseCase/IStateChangeCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnUseCaseReset(UseCase p0);

		[Register("onUseCaseUpdated", "(Landroidx/camera/core/UseCase;)V", "GetOnUseCaseUpdated_Landroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.UseCase/IStateChangeCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnUseCaseUpdated(UseCase p0);
	}

	[Register("androidx/camera/core/UseCase$StateChangeCallback", DoNotGenerateAcw = true)]
	internal class IStateChangeCallbackInvoker : Java.Lang.Object, IStateChangeCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/UseCase$StateChangeCallback", typeof(IStateChangeCallbackInvoker));

		private nint class_ref;

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

		public static IStateChangeCallback? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStateChangeCallback>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.UseCase.StateChangeCallback'.");
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

		public IStateChangeCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			IStateChangeCallback? stateChangeCallback = Java.Lang.Object.GetObject<IStateChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
			stateChangeCallback.OnUseCaseActive(p);
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
			IStateChangeCallback? stateChangeCallback = Java.Lang.Object.GetObject<IStateChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
			stateChangeCallback.OnUseCaseInactive(p);
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
			IStateChangeCallback? stateChangeCallback = Java.Lang.Object.GetObject<IStateChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
			stateChangeCallback.OnUseCaseReset(p);
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
			IStateChangeCallback? stateChangeCallback = Java.Lang.Object.GetObject<IStateChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UseCase p = Java.Lang.Object.GetObject<UseCase>(native_p0, JniHandleOwnership.DoNotTransfer);
			stateChangeCallback.OnUseCaseUpdated(p);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/UseCase", typeof(UseCase));

	private static Delegate? cb_getAppConfig;

	private static Delegate? cb_getAppTargetRotation;

	private static Delegate? cb_getAttachedStreamSpec;

	private static Delegate? cb_getAttachedSurfaceResolution;

	private static Delegate? cb_getCamera;

	private static Delegate? cb_getCameraControl;

	private static Delegate? cb_getCameraId;

	private static Delegate? cb_getCurrentConfig;

	private static Delegate? cb_getEffect;

	private static Delegate? cb_setEffect_Landroidx_camera_core_CameraEffect_;

	private static Delegate? cb_getImageFormat;

	private static Delegate? cb_getMirrorModeInternal;

	private static Delegate? cb_getName;

	private static Delegate? cb_getPhysicalCameraId;

	private static Delegate? cb_setPhysicalCameraId_Ljava_lang_String_;

	private static Delegate? cb_getResolutionInfoInternal;

	private static Delegate? cb_getSecondaryCamera;

	private static Delegate? cb_getSecondaryCameraId;

	private static Delegate? cb_getSecondarySessionConfig;

	private static Delegate? cb_getSensorToBufferTransformMatrix;

	private static Delegate? cb_setSensorToBufferTransformMatrix_Landroid_graphics_Matrix_;

	private static Delegate? cb_getSessionConfig;

	private static Delegate? cb_getSupportedEffectTargets;

	private static Delegate? cb_getTargetFrameRateInternal;

	private static Delegate? cb_getTargetRotationInternal;

	private static Delegate? cb_getViewPortCropRect;

	private static Delegate? cb_setViewPortCropRect_Landroid_graphics_Rect_;

	private static Delegate? cb_getDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_;

	private static Delegate? cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_;

	private static Delegate? cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z;

	private static Delegate? cb_getUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_;

	private static Delegate? cb_isCurrentCamera_Ljava_lang_String_;

	private static Delegate? cb_isEffectTargetsSupported_I;

	private static Delegate? cb_isMirroringRequired_Landroidx_camera_core_impl_CameraInternal_;

	private static Delegate? cb_mergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_;

	private static Delegate? cb_onBind;

	private static Delegate? cb_onCameraControlReady;

	private static Delegate? cb_onMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_;

	private static Delegate? cb_onStateAttached;

	private static Delegate? cb_onStateDetached;

	private static Delegate? cb_onSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_;

	private static Delegate? cb_onSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_;

	private static Delegate? cb_onUnbind;

	private static Delegate? cb_setTargetRotationInternal_I;

	private static Delegate? cb_updateSessionConfig_Ljava_util_List_;

	private static Delegate? cb_updateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_;

	private static Delegate? cb_updateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_;

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

	protected unsafe virtual IUseCaseConfig AppConfig
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getAppConfig", "()Landroidx/camera/core/impl/UseCaseConfig;", "GetGetAppConfigHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IUseCaseConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAppConfig.()Landroidx/camera/core/impl/UseCaseConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual int AppTargetRotation
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getAppTargetRotation", "()I", "GetGetAppTargetRotationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAppTargetRotation.()I", this, null);
		}
	}

	public unsafe virtual StreamSpec? AttachedStreamSpec
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getAttachedStreamSpec", "()Landroidx/camera/core/impl/StreamSpec;", "GetGetAttachedStreamSpecHandler")]
		get
		{
			return Java.Lang.Object.GetObject<StreamSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttachedStreamSpec.()Landroidx/camera/core/impl/StreamSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Size? AttachedSurfaceResolution
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getAttachedSurfaceResolution", "()Landroid/util/Size;", "GetGetAttachedSurfaceResolutionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttachedSurfaceResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICameraInternal? Camera
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCamera", "()Landroidx/camera/core/impl/CameraInternal;", "GetGetCameraHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCamera.()Landroidx/camera/core/impl/CameraInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual ICameraControlInternal CameraControl
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCameraControl", "()Landroidx/camera/core/impl/CameraControlInternal;", "GetGetCameraControlHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraControlInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraControl.()Landroidx/camera/core/impl/CameraControlInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual string CameraId
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCameraId", "()Ljava/lang/String;", "GetGetCameraIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCameraId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IUseCaseConfig CurrentConfig
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCurrentConfig", "()Landroidx/camera/core/impl/UseCaseConfig;", "GetGetCurrentConfigHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IUseCaseConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentConfig.()Landroidx/camera/core/impl/UseCaseConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CameraEffect? Effect
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getEffect", "()Landroidx/camera/core/CameraEffect;", "GetGetEffectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CameraEffect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEffect.()Landroidx/camera/core/CameraEffect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setEffect", "(Landroidx/camera/core/CameraEffect;)V", "GetSetEffect_Landroidx_camera_core_CameraEffect_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEffect.(Landroidx/camera/core/CameraEffect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ImageFormat
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getImageFormat", "()I", "GetGetImageFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageFormat.()I", this, null);
		}
	}

	protected unsafe virtual int MirrorModeInternal
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getMirrorModeInternal", "()I", "GetGetMirrorModeInternalHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMirrorModeInternal.()I", this, null);
		}
	}

	public unsafe virtual string Name
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? PhysicalCameraId
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getPhysicalCameraId", "()Ljava/lang/String;", "GetGetPhysicalCameraIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPhysicalCameraId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setPhysicalCameraId", "(Ljava/lang/String;)V", "GetSetPhysicalCameraId_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPhysicalCameraId.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	protected unsafe virtual ResolutionInfo? ResolutionInfoInternal
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getResolutionInfoInternal", "()Landroidx/camera/core/ResolutionInfo;", "GetGetResolutionInfoInternalHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResolutionInfoInternal.()Landroidx/camera/core/ResolutionInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICameraInternal? SecondaryCamera
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSecondaryCamera", "()Landroidx/camera/core/impl/CameraInternal;", "GetGetSecondaryCameraHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSecondaryCamera.()Landroidx/camera/core/impl/CameraInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual string? SecondaryCameraId
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSecondaryCameraId", "()Ljava/lang/String;", "GetGetSecondaryCameraIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSecondaryCameraId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual SessionConfig SecondarySessionConfig
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSecondarySessionConfig", "()Landroidx/camera/core/impl/SessionConfig;", "GetGetSecondarySessionConfigHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SessionConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSecondarySessionConfig.()Landroidx/camera/core/impl/SessionConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Matrix SensorToBufferTransformMatrix
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSensorToBufferTransformMatrix", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformMatrixHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSensorToBufferTransformMatrix.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSensorToBufferTransformMatrix", "(Landroid/graphics/Matrix;)V", "GetSetSensorToBufferTransformMatrix_Landroid_graphics_Matrix_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSensorToBufferTransformMatrix.(Landroid/graphics/Matrix;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual SessionConfig SessionConfig
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSessionConfig", "()Landroidx/camera/core/impl/SessionConfig;", "GetGetSessionConfigHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SessionConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSessionConfig.()Landroidx/camera/core/impl/SessionConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual ICollection<Integer> SupportedEffectTargets
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportedEffectTargets", "()Ljava/util/Set;", "GetGetSupportedEffectTargetsHandler")]
		get
		{
			return JavaSet<Integer>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedEffectTargets.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual Android.Util.Range TargetFrameRateInternal
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getTargetFrameRateInternal", "()Landroid/util/Range;", "GetGetTargetFrameRateInternalHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetFrameRateInternal.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual int TargetRotationInternal
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getTargetRotationInternal", "()I", "GetGetTargetRotationInternalHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetRotationInternal.()I", this, null);
		}
	}

	public unsafe virtual Rect? ViewPortCropRect
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getViewPortCropRect", "()Landroid/graphics/Rect;", "GetGetViewPortCropRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewPortCropRect.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setViewPortCropRect", "(Landroid/graphics/Rect;)V", "GetSetViewPortCropRect_Landroid_graphics_Rect_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setViewPortCropRect.(Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected UseCase(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/core/impl/UseCaseConfig;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected unsafe UseCase(IUseCaseConfig currentConfig)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((currentConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)currentConfig).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/camera/core/impl/UseCaseConfig;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/camera/core/impl/UseCaseConfig;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(currentConfig);
		}
	}

	private static Delegate GetGetAppConfigHandler()
	{
		if ((object)cb_getAppConfig == null)
		{
			cb_getAppConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAppConfig));
		}
		return cb_getAppConfig;
	}

	private static nint n_GetAppConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AppConfig);
	}

	private static Delegate GetGetAppTargetRotationHandler()
	{
		if ((object)cb_getAppTargetRotation == null)
		{
			cb_getAppTargetRotation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAppTargetRotation));
		}
		return cb_getAppTargetRotation;
	}

	private static int n_GetAppTargetRotation(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AppTargetRotation;
	}

	private static Delegate GetGetAttachedStreamSpecHandler()
	{
		if ((object)cb_getAttachedStreamSpec == null)
		{
			cb_getAttachedStreamSpec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAttachedStreamSpec));
		}
		return cb_getAttachedStreamSpec;
	}

	private static nint n_GetAttachedStreamSpec(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AttachedStreamSpec);
	}

	private static Delegate GetGetAttachedSurfaceResolutionHandler()
	{
		if ((object)cb_getAttachedSurfaceResolution == null)
		{
			cb_getAttachedSurfaceResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAttachedSurfaceResolution));
		}
		return cb_getAttachedSurfaceResolution;
	}

	private static nint n_GetAttachedSurfaceResolution(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AttachedSurfaceResolution);
	}

	private static Delegate GetGetCameraHandler()
	{
		if ((object)cb_getCamera == null)
		{
			cb_getCamera = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCamera));
		}
		return cb_getCamera;
	}

	private static nint n_GetCamera(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Camera);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraControl);
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraId);
	}

	private static Delegate GetGetCurrentConfigHandler()
	{
		if ((object)cb_getCurrentConfig == null)
		{
			cb_getCurrentConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCurrentConfig));
		}
		return cb_getCurrentConfig;
	}

	private static nint n_GetCurrentConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentConfig);
	}

	private static Delegate GetGetEffectHandler()
	{
		if ((object)cb_getEffect == null)
		{
			cb_getEffect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEffect));
		}
		return cb_getEffect;
	}

	private static nint n_GetEffect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Effect);
	}

	private static Delegate GetSetEffect_Landroidx_camera_core_CameraEffect_Handler()
	{
		if ((object)cb_setEffect_Landroidx_camera_core_CameraEffect_ == null)
		{
			cb_setEffect_Landroidx_camera_core_CameraEffect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEffect_Landroidx_camera_core_CameraEffect_));
		}
		return cb_setEffect_Landroidx_camera_core_CameraEffect_;
	}

	private static void n_SetEffect_Landroidx_camera_core_CameraEffect_(nint jnienv, nint native__this, nint native_effect)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraEffect effect = Java.Lang.Object.GetObject<CameraEffect>(native_effect, JniHandleOwnership.DoNotTransfer);
		useCase.Effect = effect;
	}

	private static Delegate GetGetImageFormatHandler()
	{
		if ((object)cb_getImageFormat == null)
		{
			cb_getImageFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageFormat));
		}
		return cb_getImageFormat;
	}

	private static int n_GetImageFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageFormat;
	}

	private static Delegate GetGetMirrorModeInternalHandler()
	{
		if ((object)cb_getMirrorModeInternal == null)
		{
			cb_getMirrorModeInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMirrorModeInternal));
		}
		return cb_getMirrorModeInternal;
	}

	private static int n_GetMirrorModeInternal(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MirrorModeInternal;
	}

	private static Delegate GetGetNameHandler()
	{
		if ((object)cb_getName == null)
		{
			cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
		}
		return cb_getName;
	}

	private static nint n_GetName(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
	}

	private static Delegate GetGetPhysicalCameraIdHandler()
	{
		if ((object)cb_getPhysicalCameraId == null)
		{
			cb_getPhysicalCameraId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPhysicalCameraId));
		}
		return cb_getPhysicalCameraId;
	}

	private static nint n_GetPhysicalCameraId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PhysicalCameraId);
	}

	private static Delegate GetSetPhysicalCameraId_Ljava_lang_String_Handler()
	{
		if ((object)cb_setPhysicalCameraId_Ljava_lang_String_ == null)
		{
			cb_setPhysicalCameraId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPhysicalCameraId_Ljava_lang_String_));
		}
		return cb_setPhysicalCameraId_Ljava_lang_String_;
	}

	private static void n_SetPhysicalCameraId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_physicalCameraId)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string physicalCameraId = JNIEnv.GetString(native_physicalCameraId, JniHandleOwnership.DoNotTransfer);
		useCase.PhysicalCameraId = physicalCameraId;
	}

	private static Delegate GetGetResolutionInfoInternalHandler()
	{
		if ((object)cb_getResolutionInfoInternal == null)
		{
			cb_getResolutionInfoInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResolutionInfoInternal));
		}
		return cb_getResolutionInfoInternal;
	}

	private static nint n_GetResolutionInfoInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResolutionInfoInternal);
	}

	private static Delegate GetGetSecondaryCameraHandler()
	{
		if ((object)cb_getSecondaryCamera == null)
		{
			cb_getSecondaryCamera = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSecondaryCamera));
		}
		return cb_getSecondaryCamera;
	}

	private static nint n_GetSecondaryCamera(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SecondaryCamera);
	}

	private static Delegate GetGetSecondaryCameraIdHandler()
	{
		if ((object)cb_getSecondaryCameraId == null)
		{
			cb_getSecondaryCameraId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSecondaryCameraId));
		}
		return cb_getSecondaryCameraId;
	}

	private static nint n_GetSecondaryCameraId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SecondaryCameraId);
	}

	private static Delegate GetGetSecondarySessionConfigHandler()
	{
		if ((object)cb_getSecondarySessionConfig == null)
		{
			cb_getSecondarySessionConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSecondarySessionConfig));
		}
		return cb_getSecondarySessionConfig;
	}

	private static nint n_GetSecondarySessionConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SecondarySessionConfig);
	}

	private static Delegate GetGetSensorToBufferTransformMatrixHandler()
	{
		if ((object)cb_getSensorToBufferTransformMatrix == null)
		{
			cb_getSensorToBufferTransformMatrix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorToBufferTransformMatrix));
		}
		return cb_getSensorToBufferTransformMatrix;
	}

	private static nint n_GetSensorToBufferTransformMatrix(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorToBufferTransformMatrix);
	}

	private static Delegate GetSetSensorToBufferTransformMatrix_Landroid_graphics_Matrix_Handler()
	{
		if ((object)cb_setSensorToBufferTransformMatrix_Landroid_graphics_Matrix_ == null)
		{
			cb_setSensorToBufferTransformMatrix_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSensorToBufferTransformMatrix_Landroid_graphics_Matrix_));
		}
		return cb_setSensorToBufferTransformMatrix_Landroid_graphics_Matrix_;
	}

	private static void n_SetSensorToBufferTransformMatrix_Landroid_graphics_Matrix_(nint jnienv, nint native__this, nint native_sensorToBufferTransformMatrix)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Matrix sensorToBufferTransformMatrix = Java.Lang.Object.GetObject<Matrix>(native_sensorToBufferTransformMatrix, JniHandleOwnership.DoNotTransfer);
		useCase.SensorToBufferTransformMatrix = sensorToBufferTransformMatrix;
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionConfig);
	}

	private static Delegate GetGetSupportedEffectTargetsHandler()
	{
		if ((object)cb_getSupportedEffectTargets == null)
		{
			cb_getSupportedEffectTargets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedEffectTargets));
		}
		return cb_getSupportedEffectTargets;
	}

	private static nint n_GetSupportedEffectTargets(nint jnienv, nint native__this)
	{
		return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedEffectTargets);
	}

	private static Delegate GetGetTargetFrameRateInternalHandler()
	{
		if ((object)cb_getTargetFrameRateInternal == null)
		{
			cb_getTargetFrameRateInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetFrameRateInternal));
		}
		return cb_getTargetFrameRateInternal;
	}

	private static nint n_GetTargetFrameRateInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetFrameRateInternal);
	}

	private static Delegate GetGetTargetRotationInternalHandler()
	{
		if ((object)cb_getTargetRotationInternal == null)
		{
			cb_getTargetRotationInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargetRotationInternal));
		}
		return cb_getTargetRotationInternal;
	}

	private static int n_GetTargetRotationInternal(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetRotationInternal;
	}

	private static Delegate GetGetViewPortCropRectHandler()
	{
		if ((object)cb_getViewPortCropRect == null)
		{
			cb_getViewPortCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetViewPortCropRect));
		}
		return cb_getViewPortCropRect;
	}

	private static nint n_GetViewPortCropRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewPortCropRect);
	}

	private static Delegate GetSetViewPortCropRect_Landroid_graphics_Rect_Handler()
	{
		if ((object)cb_setViewPortCropRect_Landroid_graphics_Rect_ == null)
		{
			cb_setViewPortCropRect_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetViewPortCropRect_Landroid_graphics_Rect_));
		}
		return cb_setViewPortCropRect_Landroid_graphics_Rect_;
	}

	private static void n_SetViewPortCropRect_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_viewPortCropRect)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Rect viewPortCropRect = Java.Lang.Object.GetObject<Rect>(native_viewPortCropRect, JniHandleOwnership.DoNotTransfer);
		useCase.ViewPortCropRect = viewPortCropRect;
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("bindToCamera", "(Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/UseCaseConfig;)V", "")]
	public unsafe void BindToCamera(ICameraInternal camera, ICameraInternal? secondaryCamera, IUseCaseConfig? extendedConfig, IUseCaseConfig? cameraConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			ptr[1] = new JniArgumentValue((secondaryCamera == null) ? IntPtr.Zero : ((Java.Lang.Object)secondaryCamera).Handle);
			ptr[2] = new JniArgumentValue((extendedConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)extendedConfig).Handle);
			ptr[3] = new JniArgumentValue((cameraConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraConfig).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("bindToCamera.(Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/UseCaseConfig;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(camera);
			GC.KeepAlive(secondaryCamera);
			GC.KeepAlive(extendedConfig);
			GC.KeepAlive(cameraConfig);
		}
	}

	private static Delegate GetGetDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_Handler()
	{
		if ((object)cb_getDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_ == null)
		{
			cb_getDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZL_L(n_GetDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_));
		}
		return cb_getDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_;
	}

	private static nint n_GetDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_(nint jnienv, nint native__this, bool p0, nint native_p1)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUseCaseConfigFactory p1 = Java.Lang.Object.GetObject<IUseCaseConfigFactory>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.GetDefaultConfig(p0, p1));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getDefaultConfig", "(ZLandroidx/camera/core/impl/UseCaseConfigFactory;)Landroidx/camera/core/impl/UseCaseConfig;", "GetGetDefaultConfig_ZLandroidx_camera_core_impl_UseCaseConfigFactory_Handler")]
	public abstract IUseCaseConfig? GetDefaultConfig(bool p0, IUseCaseConfigFactory p1);

	private static Delegate GetGetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Handler()
	{
		if ((object)cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_ == null)
		{
			cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_));
		}
		return cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_;
	}

	private static int n_GetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_(nint jnienv, nint native__this, nint native_cameraInternal)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInternal cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(native_cameraInternal, JniHandleOwnership.DoNotTransfer);
		return useCase.GetRelativeRotation(cameraInternal);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getRelativeRotation", "(Landroidx/camera/core/impl/CameraInternal;)I", "GetGetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Handler")]
	protected unsafe virtual int GetRelativeRotation(ICameraInternal cameraInternal)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cameraInternal == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInternal).Handle);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeRotation.(Landroidx/camera/core/impl/CameraInternal;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cameraInternal);
		}
	}

	private static Delegate GetGetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_ZHandler()
	{
		if ((object)cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z == null)
		{
			cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_I(n_GetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z));
		}
		return cb_getRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z;
	}

	private static int n_GetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_Z(nint jnienv, nint native__this, nint native_cameraInternal, bool requireMirroring)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInternal cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(native_cameraInternal, JniHandleOwnership.DoNotTransfer);
		return useCase.GetRelativeRotation(cameraInternal, requireMirroring);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getRelativeRotation", "(Landroidx/camera/core/impl/CameraInternal;Z)I", "GetGetRelativeRotation_Landroidx_camera_core_impl_CameraInternal_ZHandler")]
	protected unsafe virtual int GetRelativeRotation(ICameraInternal cameraInternal, bool requireMirroring)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cameraInternal == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInternal).Handle);
			ptr[1] = new JniArgumentValue(requireMirroring);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeRotation.(Landroidx/camera/core/impl/CameraInternal;Z)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cameraInternal);
		}
	}

	private static Delegate GetGetUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_Handler()
	{
		if ((object)cb_getUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_ == null)
		{
			cb_getUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_));
		}
		return cb_getUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_;
	}

	private static nint n_GetUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_p0)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig p = Java.Lang.Object.GetObject<IConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.GetUseCaseConfigBuilder(p));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getUseCaseConfigBuilder", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/UseCaseConfig$Builder;", "GetGetUseCaseConfigBuilder_Landroidx_camera_core_impl_Config_Handler")]
	public abstract IUseCaseConfigBuilder GetUseCaseConfigBuilder(IConfig p0);

	private static Delegate GetIsCurrentCamera_Ljava_lang_String_Handler()
	{
		if ((object)cb_isCurrentCamera_Ljava_lang_String_ == null)
		{
			cb_isCurrentCamera_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsCurrentCamera_Ljava_lang_String_));
		}
		return cb_isCurrentCamera_Ljava_lang_String_;
	}

	private static bool n_IsCurrentCamera_Ljava_lang_String_(nint jnienv, nint native__this, nint native_cameraId)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string cameraId = JNIEnv.GetString(native_cameraId, JniHandleOwnership.DoNotTransfer);
		return useCase.IsCurrentCamera(cameraId);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isCurrentCamera", "(Ljava/lang/String;)Z", "GetIsCurrentCamera_Ljava_lang_String_Handler")]
	protected unsafe virtual bool IsCurrentCamera(string cameraId)
	{
		nint num = JNIEnv.NewString(cameraId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCurrentCamera.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetIsEffectTargetsSupported_IHandler()
	{
		if ((object)cb_isEffectTargetsSupported_I == null)
		{
			cb_isEffectTargetsSupported_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPI_Z(n_IsEffectTargetsSupported_I));
		}
		return cb_isEffectTargetsSupported_I;
	}

	private static bool n_IsEffectTargetsSupported_I(nint jnienv, nint native__this, int effectTargets)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEffectTargetsSupported(effectTargets);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isEffectTargetsSupported", "(I)Z", "GetIsEffectTargetsSupported_IHandler")]
	public unsafe virtual bool IsEffectTargetsSupported(int effectTargets)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(effectTargets);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEffectTargetsSupported.(I)Z", this, ptr);
	}

	private static Delegate GetIsMirroringRequired_Landroidx_camera_core_impl_CameraInternal_Handler()
	{
		if ((object)cb_isMirroringRequired_Landroidx_camera_core_impl_CameraInternal_ == null)
		{
			cb_isMirroringRequired_Landroidx_camera_core_impl_CameraInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsMirroringRequired_Landroidx_camera_core_impl_CameraInternal_));
		}
		return cb_isMirroringRequired_Landroidx_camera_core_impl_CameraInternal_;
	}

	private static bool n_IsMirroringRequired_Landroidx_camera_core_impl_CameraInternal_(nint jnienv, nint native__this, nint native_camera)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInternal camera = Java.Lang.Object.GetObject<ICameraInternal>(native_camera, JniHandleOwnership.DoNotTransfer);
		return useCase.IsMirroringRequired(camera);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isMirroringRequired", "(Landroidx/camera/core/impl/CameraInternal;)Z", "GetIsMirroringRequired_Landroidx_camera_core_impl_CameraInternal_Handler")]
	public unsafe virtual bool IsMirroringRequired(ICameraInternal camera)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMirroringRequired.(Landroidx/camera/core/impl/CameraInternal;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(camera);
		}
	}

	private static Delegate GetMergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_Handler()
	{
		if ((object)cb_mergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_ == null)
		{
			cb_mergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_MergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_));
		}
		return cb_mergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_;
	}

	private static nint n_MergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_(nint jnienv, nint native__this, nint native_cameraInfo, nint native_extendedConfig, nint native_cameraDefaultConfig)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInfoInternal cameraInfo = Java.Lang.Object.GetObject<ICameraInfoInternal>(native_cameraInfo, JniHandleOwnership.DoNotTransfer);
		IUseCaseConfig extendedConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(native_extendedConfig, JniHandleOwnership.DoNotTransfer);
		IUseCaseConfig cameraDefaultConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(native_cameraDefaultConfig, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.MergeConfigs(cameraInfo, extendedConfig, cameraDefaultConfig));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("mergeConfigs", "(Landroidx/camera/core/impl/CameraInfoInternal;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/UseCaseConfig;)Landroidx/camera/core/impl/UseCaseConfig;", "GetMergeConfigs_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_UseCaseConfig_Handler")]
	public unsafe virtual IUseCaseConfig MergeConfigs(ICameraInfoInternal cameraInfo, IUseCaseConfig? extendedConfig, IUseCaseConfig? cameraDefaultConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			ptr[1] = new JniArgumentValue((extendedConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)extendedConfig).Handle);
			ptr[2] = new JniArgumentValue((cameraDefaultConfig == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraDefaultConfig).Handle);
			return Java.Lang.Object.GetObject<IUseCaseConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("mergeConfigs.(Landroidx/camera/core/impl/CameraInfoInternal;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/UseCaseConfig;)Landroidx/camera/core/impl/UseCaseConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
			GC.KeepAlive(extendedConfig);
			GC.KeepAlive(cameraDefaultConfig);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("notifyActive", "()V", "")]
	protected unsafe void NotifyActive()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyActive.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("notifyInactive", "()V", "")]
	protected unsafe void NotifyInactive()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyInactive.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("notifyReset", "()V", "")]
	protected unsafe void NotifyReset()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyReset.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("notifyState", "()V", "")]
	public unsafe void NotifyState()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyState.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("notifyUpdated", "()V", "")]
	protected unsafe void NotifyUpdated()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyUpdated.()V", this, null);
	}

	private static Delegate GetOnBindHandler()
	{
		if ((object)cb_onBind == null)
		{
			cb_onBind = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBind));
		}
		return cb_onBind;
	}

	private static void n_OnBind(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBind();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onBind", "()V", "GetOnBindHandler")]
	public unsafe virtual void OnBind()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onBind.()V", this, null);
	}

	private static Delegate GetOnCameraControlReadyHandler()
	{
		if ((object)cb_onCameraControlReady == null)
		{
			cb_onCameraControlReady = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCameraControlReady));
		}
		return cb_onCameraControlReady;
	}

	private static void n_OnCameraControlReady(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCameraControlReady();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onCameraControlReady", "()V", "GetOnCameraControlReadyHandler")]
	public unsafe virtual void OnCameraControlReady()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCameraControlReady.()V", this, null);
	}

	private static Delegate GetOnMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_Handler()
	{
		if ((object)cb_onMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_ == null)
		{
			cb_onMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_OnMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_));
		}
		return cb_onMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_;
	}

	private static nint n_OnMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_(nint jnienv, nint native__this, nint native_cameraInfo, nint native_builder)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInfoInternal cameraInfo = Java.Lang.Object.GetObject<ICameraInfoInternal>(native_cameraInfo, JniHandleOwnership.DoNotTransfer);
		IUseCaseConfigBuilder builder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(native_builder, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.OnMergeConfig(cameraInfo, builder));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onMergeConfig", "(Landroidx/camera/core/impl/CameraInfoInternal;Landroidx/camera/core/impl/UseCaseConfig$Builder;)Landroidx/camera/core/impl/UseCaseConfig;", "GetOnMergeConfig_Landroidx_camera_core_impl_CameraInfoInternal_Landroidx_camera_core_impl_UseCaseConfig_Builder_Handler")]
	protected unsafe virtual IUseCaseConfig OnMergeConfig(ICameraInfoInternal cameraInfo, IUseCaseConfigBuilder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			ptr[1] = new JniArgumentValue((builder == null) ? IntPtr.Zero : ((Java.Lang.Object)builder).Handle);
			return Java.Lang.Object.GetObject<IUseCaseConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("onMergeConfig.(Landroidx/camera/core/impl/CameraInfoInternal;Landroidx/camera/core/impl/UseCaseConfig$Builder;)Landroidx/camera/core/impl/UseCaseConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
			GC.KeepAlive(builder);
		}
	}

	private static Delegate GetOnStateAttachedHandler()
	{
		if ((object)cb_onStateAttached == null)
		{
			cb_onStateAttached = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStateAttached));
		}
		return cb_onStateAttached;
	}

	private static void n_OnStateAttached(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStateAttached();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onStateAttached", "()V", "GetOnStateAttachedHandler")]
	public unsafe virtual void OnStateAttached()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStateAttached.()V", this, null);
	}

	private static Delegate GetOnStateDetachedHandler()
	{
		if ((object)cb_onStateDetached == null)
		{
			cb_onStateDetached = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStateDetached));
		}
		return cb_onStateDetached;
	}

	private static void n_OnStateDetached(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStateDetached();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onStateDetached", "()V", "GetOnStateDetachedHandler")]
	public unsafe virtual void OnStateDetached()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStateDetached.()V", this, null);
	}

	private static Delegate GetOnSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_Handler()
	{
		if ((object)cb_onSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_ == null)
		{
			cb_onSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_));
		}
		return cb_onSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_;
	}

	private static nint n_OnSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_config)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig config = Java.Lang.Object.GetObject<IConfig>(native_config, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.OnSuggestedStreamSpecImplementationOptionsUpdated(config));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onSuggestedStreamSpecImplementationOptionsUpdated", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/StreamSpec;", "GetOnSuggestedStreamSpecImplementationOptionsUpdated_Landroidx_camera_core_impl_Config_Handler")]
	protected unsafe virtual StreamSpec OnSuggestedStreamSpecImplementationOptionsUpdated(IConfig config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
			return Java.Lang.Object.GetObject<StreamSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuggestedStreamSpecImplementationOptionsUpdated.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/StreamSpec;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}

	private static Delegate GetOnSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_Handler()
	{
		if ((object)cb_onSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_ == null)
		{
			cb_onSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_OnSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_));
		}
		return cb_onSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_;
	}

	private static nint n_OnSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_(nint jnienv, nint native__this, nint native_primaryStreamSpec, nint native_secondaryStreamSpec)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		StreamSpec primaryStreamSpec = Java.Lang.Object.GetObject<StreamSpec>(native_primaryStreamSpec, JniHandleOwnership.DoNotTransfer);
		StreamSpec secondaryStreamSpec = Java.Lang.Object.GetObject<StreamSpec>(native_secondaryStreamSpec, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCase.OnSuggestedStreamSpecUpdated(primaryStreamSpec, secondaryStreamSpec));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onSuggestedStreamSpecUpdated", "(Landroidx/camera/core/impl/StreamSpec;Landroidx/camera/core/impl/StreamSpec;)Landroidx/camera/core/impl/StreamSpec;", "GetOnSuggestedStreamSpecUpdated_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_Handler")]
	protected unsafe virtual StreamSpec OnSuggestedStreamSpecUpdated(StreamSpec primaryStreamSpec, StreamSpec? secondaryStreamSpec)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(primaryStreamSpec?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(secondaryStreamSpec?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<StreamSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuggestedStreamSpecUpdated.(Landroidx/camera/core/impl/StreamSpec;Landroidx/camera/core/impl/StreamSpec;)Landroidx/camera/core/impl/StreamSpec;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(primaryStreamSpec);
			GC.KeepAlive(secondaryStreamSpec);
		}
	}

	private static Delegate GetOnUnbindHandler()
	{
		if ((object)cb_onUnbind == null)
		{
			cb_onUnbind = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnUnbind));
		}
		return cb_onUnbind;
	}

	private static void n_OnUnbind(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnUnbind();
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("onUnbind", "()V", "GetOnUnbindHandler")]
	public unsafe virtual void OnUnbind()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onUnbind.()V", this, null);
	}

	private static Delegate GetSetTargetRotationInternal_IHandler()
	{
		if ((object)cb_setTargetRotationInternal_I == null)
		{
			cb_setTargetRotationInternal_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPI_Z(n_SetTargetRotationInternal_I));
		}
		return cb_setTargetRotationInternal_I;
	}

	private static bool n_SetTargetRotationInternal_I(nint jnienv, nint native__this, int targetRotation)
	{
		return Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTargetRotationInternal(targetRotation);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setTargetRotationInternal", "(I)Z", "GetSetTargetRotationInternal_IHandler")]
	protected unsafe virtual bool SetTargetRotationInternal(int targetRotation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(targetRotation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setTargetRotationInternal.(I)Z", this, ptr);
	}

	[Register("snapToSurfaceRotation", "(I)I", "")]
	public unsafe static int SnapToSurfaceRotation(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.StaticMethods.InvokeInt32Method("snapToSurfaceRotation.(I)I", ptr);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("unbindFromCamera", "(Landroidx/camera/core/impl/CameraInternal;)V", "")]
	public unsafe void UnbindFromCamera(ICameraInternal camera)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("unbindFromCamera.(Landroidx/camera/core/impl/CameraInternal;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(camera);
		}
	}

	private static Delegate GetUpdateSessionConfig_Ljava_util_List_Handler()
	{
		if ((object)cb_updateSessionConfig_Ljava_util_List_ == null)
		{
			cb_updateSessionConfig_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateSessionConfig_Ljava_util_List_));
		}
		return cb_updateSessionConfig_Ljava_util_List_;
	}

	private static void n_UpdateSessionConfig_Ljava_util_List_(nint jnienv, nint native__this, nint native_sessionConfigs)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<SessionConfig> sessionConfigs = JavaList<AndroidX.Camera.Core.Impl.SessionConfig>.FromJniHandle(native_sessionConfigs, JniHandleOwnership.DoNotTransfer);
		useCase.UpdateSessionConfig(sessionConfigs);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateSessionConfig", "(Ljava/util/List;)V", "GetUpdateSessionConfig_Ljava_util_List_Handler")]
	protected unsafe virtual void UpdateSessionConfig(IList<SessionConfig> sessionConfigs)
	{
		nint num = JavaList<AndroidX.Camera.Core.Impl.SessionConfig>.ToLocalJniHandle(sessionConfigs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateSessionConfig.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(sessionConfigs);
		}
	}

	private static Delegate GetUpdateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_Handler()
	{
		if ((object)cb_updateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_ == null)
		{
			cb_updateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UpdateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_));
		}
		return cb_updateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_;
	}

	private static void n_UpdateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_(nint jnienv, nint native__this, nint native_primaryStreamSpec, nint native_secondaryStreamSpec)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		StreamSpec primaryStreamSpec = Java.Lang.Object.GetObject<StreamSpec>(native_primaryStreamSpec, JniHandleOwnership.DoNotTransfer);
		StreamSpec secondaryStreamSpec = Java.Lang.Object.GetObject<StreamSpec>(native_secondaryStreamSpec, JniHandleOwnership.DoNotTransfer);
		useCase.UpdateSuggestedStreamSpec(primaryStreamSpec, secondaryStreamSpec);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateSuggestedStreamSpec", "(Landroidx/camera/core/impl/StreamSpec;Landroidx/camera/core/impl/StreamSpec;)V", "GetUpdateSuggestedStreamSpec_Landroidx_camera_core_impl_StreamSpec_Landroidx_camera_core_impl_StreamSpec_Handler")]
	public unsafe virtual void UpdateSuggestedStreamSpec(StreamSpec primaryStreamSpec, StreamSpec? secondaryStreamSpec)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(primaryStreamSpec?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(secondaryStreamSpec?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateSuggestedStreamSpec.(Landroidx/camera/core/impl/StreamSpec;Landroidx/camera/core/impl/StreamSpec;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(primaryStreamSpec);
			GC.KeepAlive(secondaryStreamSpec);
		}
	}

	private static Delegate GetUpdateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_Handler()
	{
		if ((object)cb_updateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_ == null)
		{
			cb_updateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_));
		}
		return cb_updateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_;
	}

	private static void n_UpdateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_config)
	{
		UseCase? useCase = Java.Lang.Object.GetObject<UseCase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig config = Java.Lang.Object.GetObject<IConfig>(native_config, JniHandleOwnership.DoNotTransfer);
		useCase.UpdateSuggestedStreamSpecImplementationOptions(config);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateSuggestedStreamSpecImplementationOptions", "(Landroidx/camera/core/impl/Config;)V", "GetUpdateSuggestedStreamSpecImplementationOptions_Landroidx_camera_core_impl_Config_Handler")]
	public unsafe virtual void UpdateSuggestedStreamSpecImplementationOptions(IConfig config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateSuggestedStreamSpecImplementationOptions.(Landroidx/camera/core/impl/Config;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}
}
