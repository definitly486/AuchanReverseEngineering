using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraConfig", "", "AndroidX.Camera.Core.Impl.ICameraConfigInvoker")]
public interface ICameraConfig : IReadableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraConfig", typeof(ICameraConfig), isInterface: true);

	private static Delegate? cb_isCaptureProcessProgressSupported;

	private static Delegate? cb_isPostviewSupported;

	private static Delegate? cb_getSessionProcessor;

	private static Delegate? cb_getUseCaseCombinationRequiredRule;

	private static Delegate? cb_getUseCaseConfigFactory;

	private static Delegate? cb_getSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_;

	[Register("OPTION_CAPTURE_PROCESS_PROGRESS_SUPPORTED")]
	static ConfigOption? OptionCaptureProcessProgressSupported => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_CAPTURE_PROCESS_PROGRESS_SUPPORTED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_COMPATIBILITY_ID")]
	static ConfigOption? OptionCompatibilityId => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_COMPATIBILITY_ID.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_POSTVIEW_SUPPORTED")]
	static ConfigOption? OptionPostviewSupported => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_POSTVIEW_SUPPORTED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_SESSION_PROCESSOR")]
	static ConfigOption? OptionSessionProcessor => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_SESSION_PROCESSOR.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_USECASE_CONFIG_FACTORY")]
	static ConfigOption? OptionUsecaseConfigFactory => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_USECASE_CONFIG_FACTORY.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_USE_CASE_COMBINATION_REQUIRED_RULE")]
	static ConfigOption? OptionUseCaseCombinationRequiredRule => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_USE_CASE_COMBINATION_REQUIRED_RULE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_ZSL_DISABLED")]
	static ConfigOption? OptionZslDisabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_ZSL_DISABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	Identifier CompatibilityId
	{
		[Register("getCompatibilityId", "()Landroidx/camera/core/impl/Identifier;", "GetGetCompatibilityIdHandler:AndroidX.Camera.Core.Impl.ICameraConfigInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe bool IsCaptureProcessProgressSupported
	{
		[Register("isCaptureProcessProgressSupported", "()Z", "GetIsCaptureProcessProgressSupportedHandler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCaptureProcessProgressSupported.()Z", this, null);
		}
	}

	unsafe bool IsPostviewSupported
	{
		[Register("isPostviewSupported", "()Z", "GetIsPostviewSupportedHandler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPostviewSupported.()Z", this, null);
		}
	}

	unsafe ISessionProcessor SessionProcessor
	{
		[Register("getSessionProcessor", "()Landroidx/camera/core/impl/SessionProcessor;", "GetGetSessionProcessorHandler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<ISessionProcessor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSessionProcessor.()Landroidx/camera/core/impl/SessionProcessor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe int UseCaseCombinationRequiredRule
	{
		[Register("getUseCaseCombinationRequiredRule", "()I", "GetGetUseCaseCombinationRequiredRuleHandler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getUseCaseCombinationRequiredRule.()I", this, null);
		}
	}

	unsafe IUseCaseConfigFactory UseCaseConfigFactory
	{
		[Register("getUseCaseConfigFactory", "()Landroidx/camera/core/impl/UseCaseConfigFactory;", "GetGetUseCaseConfigFactoryHandler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<IUseCaseConfigFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUseCaseConfigFactory.()Landroidx/camera/core/impl/UseCaseConfigFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
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
		return Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCaptureProcessProgressSupported;
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
		return Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPostviewSupported;
	}

	private static Delegate GetGetSessionProcessorHandler()
	{
		if ((object)cb_getSessionProcessor == null)
		{
			cb_getSessionProcessor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSessionProcessor));
		}
		return cb_getSessionProcessor;
	}

	private static nint n_GetSessionProcessor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionProcessor);
	}

	private static Delegate GetGetUseCaseCombinationRequiredRuleHandler()
	{
		if ((object)cb_getUseCaseCombinationRequiredRule == null)
		{
			cb_getUseCaseCombinationRequiredRule = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetUseCaseCombinationRequiredRule));
		}
		return cb_getUseCaseCombinationRequiredRule;
	}

	private static int n_GetUseCaseCombinationRequiredRule(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCaseCombinationRequiredRule;
	}

	private static Delegate GetGetUseCaseConfigFactoryHandler()
	{
		if ((object)cb_getUseCaseConfigFactory == null)
		{
			cb_getUseCaseConfigFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUseCaseConfigFactory));
		}
		return cb_getUseCaseConfigFactory;
	}

	private static nint n_GetUseCaseConfigFactory(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCaseConfigFactory);
	}

	private static Delegate GetGetSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_Handler()
	{
		if ((object)cb_getSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_ == null)
		{
			cb_getSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_));
		}
		return cb_getSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_;
	}

	private static nint n_GetSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_(nint jnienv, nint native__this, nint native_valueIfMissing)
	{
		ICameraConfig? cameraConfig = Java.Lang.Object.GetObject<ICameraConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISessionProcessor valueIfMissing = Java.Lang.Object.GetObject<ISessionProcessor>(native_valueIfMissing, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraConfig.GetSessionProcessor(valueIfMissing));
	}

	[Register("getSessionProcessor", "(Landroidx/camera/core/impl/SessionProcessor;)Landroidx/camera/core/impl/SessionProcessor;", "GetGetSessionProcessor_Landroidx_camera_core_impl_SessionProcessor_Handler:AndroidX.Camera.Core.Impl.ICameraConfig, Xamarin.AndroidX.Camera.Core")]
	unsafe ISessionProcessor? GetSessionProcessor(ISessionProcessor? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((valueIfMissing == null) ? IntPtr.Zero : ((Java.Lang.Object)valueIfMissing).Handle);
			return Java.Lang.Object.GetObject<ISessionProcessor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSessionProcessor.(Landroidx/camera/core/impl/SessionProcessor;)Landroidx/camera/core/impl/SessionProcessor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}
}
