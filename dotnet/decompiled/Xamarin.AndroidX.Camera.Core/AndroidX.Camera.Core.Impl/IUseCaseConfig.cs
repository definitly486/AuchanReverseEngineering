using System;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Internal;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfig", "", "AndroidX.Camera.Core.Impl.IUseCaseConfigInvoker")]
[JavaTypeParameters(new string[] { "T extends androidx.camera.core.UseCase" })]
public interface IUseCaseConfig : IImageInputConfig, IReadableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable, ITargetConfig
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfig", typeof(IUseCaseConfig), isInterface: true);

	private static Delegate? cb_getCaptureOptionUnpacker;

	private static Delegate? cb_getCaptureType;

	private static Delegate? cb_getDefaultCaptureConfig;

	private static Delegate? cb_getDefaultSessionConfig;

	private static Delegate? cb_getPreviewStabilizationMode;

	private static Delegate? cb_getSessionOptionUnpacker;

	private static Delegate? cb_getSurfaceOccupancyPriority;

	private static Delegate? cb_getTargetFrameRate;

	private static Delegate? cb_getVideoStabilizationMode;

	private static Delegate? cb_getCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_;

	private static Delegate? cb_getDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_;

	private static Delegate? cb_getDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_;

	private static Delegate? cb_getSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_;

	private static Delegate? cb_getSurfaceOccupancyPriority_I;

	private static Delegate? cb_getTargetFrameRate_Landroid_util_Range_;

	private static Delegate? cb_isHighResolutionDisabled_Z;

	private static Delegate? cb_isZslDisabled_Z;

	[Register("OPTION_CAPTURE_CONFIG_UNPACKER")]
	static ConfigOption? OptionCaptureConfigUnpacker => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_CAPTURE_CONFIG_UNPACKER.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_CAPTURE_TYPE")]
	static ConfigOption? OptionCaptureType => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_CAPTURE_TYPE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_DEFAULT_CAPTURE_CONFIG")]
	static ConfigOption? OptionDefaultCaptureConfig => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_DEFAULT_CAPTURE_CONFIG.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_DEFAULT_SESSION_CONFIG")]
	static ConfigOption? OptionDefaultSessionConfig => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_DEFAULT_SESSION_CONFIG.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_HIGH_RESOLUTION_DISABLED")]
	static ConfigOption? OptionHighResolutionDisabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_HIGH_RESOLUTION_DISABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_PREVIEW_STABILIZATION_MODE")]
	static ConfigOption? OptionPreviewStabilizationMode => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_PREVIEW_STABILIZATION_MODE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_SESSION_CONFIG_UNPACKER")]
	static ConfigOption? OptionSessionConfigUnpacker => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_SESSION_CONFIG_UNPACKER.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_SURFACE_OCCUPANCY_PRIORITY")]
	static ConfigOption? OptionSurfaceOccupancyPriority => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_SURFACE_OCCUPANCY_PRIORITY.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_TARGET_FRAME_RATE")]
	static ConfigOption? OptionTargetFrameRate => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_TARGET_FRAME_RATE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_VIDEO_STABILIZATION_MODE")]
	static ConfigOption? OptionVideoStabilizationMode => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_VIDEO_STABILIZATION_MODE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_ZSL_DISABLED")]
	static ConfigOption? OptionZslDisabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_ZSL_DISABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	unsafe CaptureConfig.IOptionUnpacker CaptureOptionUnpacker
	{
		[Register("getCaptureOptionUnpacker", "()Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;", "GetGetCaptureOptionUnpackerHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<CaptureConfig.IOptionUnpacker>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCaptureOptionUnpacker.()Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe UseCaseConfigFactoryCaptureType CaptureType
	{
		[Register("getCaptureType", "()Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", "GetGetCaptureTypeHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCaptureType.()Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe CaptureConfig DefaultCaptureConfig
	{
		[Register("getDefaultCaptureConfig", "()Landroidx/camera/core/impl/CaptureConfig;", "GetGetDefaultCaptureConfigHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<CaptureConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultCaptureConfig.()Landroidx/camera/core/impl/CaptureConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe SessionConfig DefaultSessionConfig
	{
		[Register("getDefaultSessionConfig", "()Landroidx/camera/core/impl/SessionConfig;", "GetGetDefaultSessionConfigHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<SessionConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultSessionConfig.()Landroidx/camera/core/impl/SessionConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe int PreviewStabilizationMode
	{
		[Register("getPreviewStabilizationMode", "()I", "GetGetPreviewStabilizationModeHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPreviewStabilizationMode.()I", this, null);
		}
	}

	unsafe SessionConfig.IOptionUnpacker SessionOptionUnpacker
	{
		[Register("getSessionOptionUnpacker", "()Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;", "GetGetSessionOptionUnpackerHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<SessionConfig.IOptionUnpacker>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSessionOptionUnpacker.()Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe int SurfaceOccupancyPriority
	{
		[Register("getSurfaceOccupancyPriority", "()I", "GetGetSurfaceOccupancyPriorityHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSurfaceOccupancyPriority.()I", this, null);
		}
	}

	unsafe Android.Util.Range TargetFrameRate
	{
		[Register("getTargetFrameRate", "()Landroid/util/Range;", "GetGetTargetFrameRateHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetFrameRate.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe int VideoStabilizationMode
	{
		[Register("getVideoStabilizationMode", "()I", "GetGetVideoStabilizationModeHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVideoStabilizationMode.()I", this, null);
		}
	}

	private static Delegate GetGetCaptureOptionUnpackerHandler()
	{
		if ((object)cb_getCaptureOptionUnpacker == null)
		{
			cb_getCaptureOptionUnpacker = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureOptionUnpacker));
		}
		return cb_getCaptureOptionUnpacker;
	}

	private static nint n_GetCaptureOptionUnpacker(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureOptionUnpacker);
	}

	private static Delegate GetGetCaptureTypeHandler()
	{
		if ((object)cb_getCaptureType == null)
		{
			cb_getCaptureType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureType));
		}
		return cb_getCaptureType;
	}

	private static nint n_GetCaptureType(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureType);
	}

	private static Delegate GetGetDefaultCaptureConfigHandler()
	{
		if ((object)cb_getDefaultCaptureConfig == null)
		{
			cb_getDefaultCaptureConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultCaptureConfig));
		}
		return cb_getDefaultCaptureConfig;
	}

	private static nint n_GetDefaultCaptureConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultCaptureConfig);
	}

	private static Delegate GetGetDefaultSessionConfigHandler()
	{
		if ((object)cb_getDefaultSessionConfig == null)
		{
			cb_getDefaultSessionConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultSessionConfig));
		}
		return cb_getDefaultSessionConfig;
	}

	private static nint n_GetDefaultSessionConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultSessionConfig);
	}

	private static Delegate GetGetPreviewStabilizationModeHandler()
	{
		if ((object)cb_getPreviewStabilizationMode == null)
		{
			cb_getPreviewStabilizationMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPreviewStabilizationMode));
		}
		return cb_getPreviewStabilizationMode;
	}

	private static int n_GetPreviewStabilizationMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewStabilizationMode;
	}

	private static Delegate GetGetSessionOptionUnpackerHandler()
	{
		if ((object)cb_getSessionOptionUnpacker == null)
		{
			cb_getSessionOptionUnpacker = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSessionOptionUnpacker));
		}
		return cb_getSessionOptionUnpacker;
	}

	private static nint n_GetSessionOptionUnpacker(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionOptionUnpacker);
	}

	private static Delegate GetGetSurfaceOccupancyPriorityHandler()
	{
		if ((object)cb_getSurfaceOccupancyPriority == null)
		{
			cb_getSurfaceOccupancyPriority = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSurfaceOccupancyPriority));
		}
		return cb_getSurfaceOccupancyPriority;
	}

	private static int n_GetSurfaceOccupancyPriority(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceOccupancyPriority;
	}

	private static Delegate GetGetTargetFrameRateHandler()
	{
		if ((object)cb_getTargetFrameRate == null)
		{
			cb_getTargetFrameRate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetFrameRate));
		}
		return cb_getTargetFrameRate;
	}

	private static nint n_GetTargetFrameRate(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetFrameRate);
	}

	private static Delegate GetGetVideoStabilizationModeHandler()
	{
		if ((object)cb_getVideoStabilizationMode == null)
		{
			cb_getVideoStabilizationMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVideoStabilizationMode));
		}
		return cb_getVideoStabilizationMode;
	}

	private static int n_GetVideoStabilizationMode(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoStabilizationMode;
	}

	private static Delegate GetGetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_Handler()
	{
		if ((object)cb_getCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ == null)
		{
			cb_getCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_));
		}
		return cb_getCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_;
	}

	private static nint n_GetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaptureConfig.IOptionUnpacker valueIfMissing = Java.Lang.Object.GetObject<CaptureConfig.IOptionUnpacker>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetCaptureOptionUnpacker(valueIfMissing));
	}

	[Register("getCaptureOptionUnpacker", "(Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;)Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;", "GetGetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe CaptureConfig.IOptionUnpacker? GetCaptureOptionUnpacker(CaptureConfig.IOptionUnpacker? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((valueIfMissing == null) ? IntPtr.Zero : ((Java.Lang.Object)valueIfMissing).Handle);
			return Java.Lang.Object.GetObject<CaptureConfig.IOptionUnpacker>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCaptureOptionUnpacker.(Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;)Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetGetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_Handler()
	{
		if ((object)cb_getDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ == null)
		{
			cb_getDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_));
		}
		return cb_getDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_;
	}

	private static nint n_GetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaptureConfig valueIfMissing = Java.Lang.Object.GetObject<CaptureConfig>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetDefaultCaptureConfig(valueIfMissing));
	}

	[Register("getDefaultCaptureConfig", "(Landroidx/camera/core/impl/CaptureConfig;)Landroidx/camera/core/impl/CaptureConfig;", "GetGetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe CaptureConfig? GetDefaultCaptureConfig(CaptureConfig? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<CaptureConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultCaptureConfig.(Landroidx/camera/core/impl/CaptureConfig;)Landroidx/camera/core/impl/CaptureConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetGetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_Handler()
	{
		if ((object)cb_getDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ == null)
		{
			cb_getDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_));
		}
		return cb_getDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_;
	}

	private static nint n_GetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SessionConfig valueIfMissing = Java.Lang.Object.GetObject<SessionConfig>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetDefaultSessionConfig(valueIfMissing));
	}

	[Register("getDefaultSessionConfig", "(Landroidx/camera/core/impl/SessionConfig;)Landroidx/camera/core/impl/SessionConfig;", "GetGetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe SessionConfig? GetDefaultSessionConfig(SessionConfig? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SessionConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultSessionConfig.(Landroidx/camera/core/impl/SessionConfig;)Landroidx/camera/core/impl/SessionConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetGetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_Handler()
	{
		if ((object)cb_getSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ == null)
		{
			cb_getSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_));
		}
		return cb_getSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_;
	}

	private static nint n_GetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SessionConfig.IOptionUnpacker valueIfMissing = Java.Lang.Object.GetObject<SessionConfig.IOptionUnpacker>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetSessionOptionUnpacker(valueIfMissing));
	}

	[Register("getSessionOptionUnpacker", "(Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;)Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;", "GetGetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe SessionConfig.IOptionUnpacker? GetSessionOptionUnpacker(SessionConfig.IOptionUnpacker? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((valueIfMissing == null) ? IntPtr.Zero : ((Java.Lang.Object)valueIfMissing).Handle);
			return Java.Lang.Object.GetObject<SessionConfig.IOptionUnpacker>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSessionOptionUnpacker.(Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;)Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetGetSurfaceOccupancyPriority_IHandler()
	{
		if ((object)cb_getSurfaceOccupancyPriority_I == null)
		{
			cb_getSurfaceOccupancyPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetSurfaceOccupancyPriority_I));
		}
		return cb_getSurfaceOccupancyPriority_I;
	}

	private static int n_GetSurfaceOccupancyPriority_I(nint jnienv, nint native__this, int valueIfMissing)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSurfaceOccupancyPriority(valueIfMissing);
	}

	[Register("getSurfaceOccupancyPriority", "(I)I", "GetGetSurfaceOccupancyPriority_IHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe int GetSurfaceOccupancyPriority(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getSurfaceOccupancyPriority.(I)I", this, ptr);
	}

	private static Delegate GetGetTargetFrameRate_Landroid_util_Range_Handler()
	{
		if ((object)cb_getTargetFrameRate_Landroid_util_Range_ == null)
		{
			cb_getTargetFrameRate_Landroid_util_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetTargetFrameRate_Landroid_util_Range_));
		}
		return cb_getTargetFrameRate_Landroid_util_Range_;
	}

	private static nint n_GetTargetFrameRate_Landroid_util_Range_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		IUseCaseConfig? useCaseConfig = Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.Util.Range valueIfMissing = Java.Lang.Object.GetObject<Android.Util.Range>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfig.GetTargetFrameRate(valueIfMissing));
	}

	[Register("getTargetFrameRate", "(Landroid/util/Range;)Landroid/util/Range;", "GetGetTargetFrameRate_Landroid_util_Range_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe Android.Util.Range? GetTargetFrameRate(Android.Util.Range? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetFrameRate.(Landroid/util/Range;)Landroid/util/Range;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	private static Delegate GetIsHighResolutionDisabled_ZHandler()
	{
		if ((object)cb_isHighResolutionDisabled_Z == null)
		{
			cb_isHighResolutionDisabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_IsHighResolutionDisabled_Z));
		}
		return cb_isHighResolutionDisabled_Z;
	}

	private static bool n_IsHighResolutionDisabled_Z(nint jnienv, nint native__this, bool valueIfMissing)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHighResolutionDisabled(valueIfMissing);
	}

	[Register("isHighResolutionDisabled", "(Z)Z", "GetIsHighResolutionDisabled_ZHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsHighResolutionDisabled(bool valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHighResolutionDisabled.(Z)Z", this, ptr);
	}

	private static Delegate GetIsZslDisabled_ZHandler()
	{
		if ((object)cb_isZslDisabled_Z == null)
		{
			cb_isZslDisabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_IsZslDisabled_Z));
		}
		return cb_isZslDisabled_Z;
	}

	private static bool n_IsZslDisabled_Z(nint jnienv, nint native__this, bool valueIfMissing)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsZslDisabled(valueIfMissing);
	}

	[Register("isZslDisabled", "(Z)Z", "GetIsZslDisabled_ZHandler:AndroidX.Camera.Core.Impl.IUseCaseConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsZslDisabled(bool valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isZslDisabled.(Z)Z", this, ptr);
	}
}
