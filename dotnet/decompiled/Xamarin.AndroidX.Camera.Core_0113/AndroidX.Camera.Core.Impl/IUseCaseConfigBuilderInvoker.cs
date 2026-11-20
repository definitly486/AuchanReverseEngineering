using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Internal;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfig$Builder", DoNotGenerateAcw = true)]
internal class IUseCaseConfigBuilderInvoker : Java.Lang.Object, IUseCaseConfigBuilder, IExtendableBuilder, IJavaObject, IDisposable, IJavaPeerable, ITargetConfigBuilder
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfig$Builder", typeof(IUseCaseConfigBuilderInvoker));

	private nint class_ref;

	private static Delegate? cb_getUseCaseConfig;

	private nint id_getUseCaseConfig;

	private static Delegate? cb_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_;

	private nint id_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_;

	private static Delegate? cb_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_;

	private nint id_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_;

	private static Delegate? cb_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_;

	private nint id_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_;

	private static Delegate? cb_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_;

	private nint id_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_;

	private static Delegate? cb_setHighResolutionDisabled_Z;

	private nint id_setHighResolutionDisabled_Z;

	private static Delegate? cb_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_;

	private nint id_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_;

	private static Delegate? cb_setSurfaceOccupancyPriority_I;

	private nint id_setSurfaceOccupancyPriority_I;

	private static Delegate? cb_setZslDisabled_Z;

	private nint id_setZslDisabled_Z;

	private static Delegate? cb_getMutableConfig;

	private nint id_getMutableConfig;

	private static Delegate? cb_build;

	private nint id_build;

	private static Delegate? cb_setTargetClass_Ljava_lang_Class_;

	private nint id_setTargetClass_Ljava_lang_Class_;

	private static Delegate? cb_setTargetName_Ljava_lang_String_;

	private nint id_setTargetName_Ljava_lang_String_;

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

	public Java.Lang.Object UseCaseConfig
	{
		get
		{
			if (id_getUseCaseConfig == IntPtr.Zero)
			{
				id_getUseCaseConfig = JNIEnv.GetMethodID(class_ref, "getUseCaseConfig", "()Landroidx/camera/core/impl/UseCaseConfig;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getUseCaseConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IMutableConfig MutableConfig
	{
		get
		{
			if (id_getMutableConfig == IntPtr.Zero)
			{
				id_getMutableConfig = JNIEnv.GetMethodID(class_ref, "getMutableConfig", "()Landroidx/camera/core/impl/MutableConfig;");
			}
			return Java.Lang.Object.GetObject<IMutableConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getMutableConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IUseCaseConfigBuilder? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.UseCaseConfig.Builder'.");
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

	public IUseCaseConfigBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetUseCaseConfigHandler()
	{
		if ((object)cb_getUseCaseConfig == null)
		{
			cb_getUseCaseConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUseCaseConfig));
		}
		return cb_getUseCaseConfig;
	}

	private static nint n_GetUseCaseConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCaseConfig);
	}

	private static Delegate GetSetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_Handler()
	{
		if ((object)cb_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ == null)
		{
			cb_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_));
		}
		return cb_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_;
	}

	private static nint n_SetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaptureConfig.IOptionUnpacker captureOptionUnpacker = Java.Lang.Object.GetObject<CaptureConfig.IOptionUnpacker>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetCaptureOptionUnpacker(captureOptionUnpacker));
	}

	public unsafe Java.Lang.Object SetCaptureOptionUnpacker(CaptureConfig.IOptionUnpacker p0)
	{
		if (id_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ == IntPtr.Zero)
		{
			id_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_ = JNIEnv.GetMethodID(class_ref, "setCaptureOptionUnpacker", "(Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_Handler()
	{
		if ((object)cb_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_ == null)
		{
			cb_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_));
		}
		return cb_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_;
	}

	private static nint n_SetCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCaseConfigFactoryCaptureType captureType = Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetCaptureType(captureType));
	}

	public unsafe Java.Lang.Object SetCaptureType(UseCaseConfigFactoryCaptureType p0)
	{
		if (id_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_ == IntPtr.Zero)
		{
			id_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_ = JNIEnv.GetMethodID(class_ref, "setCaptureType", "(Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_Handler()
	{
		if ((object)cb_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ == null)
		{
			cb_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_));
		}
		return cb_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_;
	}

	private static nint n_SetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CaptureConfig defaultCaptureConfig = Java.Lang.Object.GetObject<CaptureConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetDefaultCaptureConfig(defaultCaptureConfig));
	}

	public unsafe Java.Lang.Object SetDefaultCaptureConfig(CaptureConfig p0)
	{
		if (id_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ == IntPtr.Zero)
		{
			id_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_ = JNIEnv.GetMethodID(class_ref, "setDefaultCaptureConfig", "(Landroidx/camera/core/impl/CaptureConfig;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_Handler()
	{
		if ((object)cb_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ == null)
		{
			cb_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_));
		}
		return cb_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_;
	}

	private static nint n_SetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SessionConfig defaultSessionConfig = Java.Lang.Object.GetObject<SessionConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetDefaultSessionConfig(defaultSessionConfig));
	}

	public unsafe Java.Lang.Object SetDefaultSessionConfig(SessionConfig p0)
	{
		if (id_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ == IntPtr.Zero)
		{
			id_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_ = JNIEnv.GetMethodID(class_ref, "setDefaultSessionConfig", "(Landroidx/camera/core/impl/SessionConfig;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHighResolutionDisabled_ZHandler()
	{
		if ((object)cb_setHighResolutionDisabled_Z == null)
		{
			cb_setHighResolutionDisabled_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_SetHighResolutionDisabled_Z));
		}
		return cb_setHighResolutionDisabled_Z;
	}

	private static nint n_SetHighResolutionDisabled_Z(nint jnienv, nint native__this, bool p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHighResolutionDisabled(p0));
	}

	public unsafe Java.Lang.Object SetHighResolutionDisabled(bool p0)
	{
		if (id_setHighResolutionDisabled_Z == IntPtr.Zero)
		{
			id_setHighResolutionDisabled_Z = JNIEnv.GetMethodID(class_ref, "setHighResolutionDisabled", "(Z)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setHighResolutionDisabled_Z, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_Handler()
	{
		if ((object)cb_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ == null)
		{
			cb_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_));
		}
		return cb_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_;
	}

	private static nint n_SetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SessionConfig.IOptionUnpacker sessionOptionUnpacker = Java.Lang.Object.GetObject<SessionConfig.IOptionUnpacker>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetSessionOptionUnpacker(sessionOptionUnpacker));
	}

	public unsafe Java.Lang.Object SetSessionOptionUnpacker(SessionConfig.IOptionUnpacker p0)
	{
		if (id_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ == IntPtr.Zero)
		{
			id_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_ = JNIEnv.GetMethodID(class_ref, "setSessionOptionUnpacker", "(Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSurfaceOccupancyPriority_IHandler()
	{
		if ((object)cb_setSurfaceOccupancyPriority_I == null)
		{
			cb_setSurfaceOccupancyPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetSurfaceOccupancyPriority_I));
		}
		return cb_setSurfaceOccupancyPriority_I;
	}

	private static nint n_SetSurfaceOccupancyPriority_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSurfaceOccupancyPriority(p0));
	}

	public unsafe Java.Lang.Object SetSurfaceOccupancyPriority(int p0)
	{
		if (id_setSurfaceOccupancyPriority_I == IntPtr.Zero)
		{
			id_setSurfaceOccupancyPriority_I = JNIEnv.GetMethodID(class_ref, "setSurfaceOccupancyPriority", "(I)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setSurfaceOccupancyPriority_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetZslDisabled_ZHandler()
	{
		if ((object)cb_setZslDisabled_Z == null)
		{
			cb_setZslDisabled_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_SetZslDisabled_Z));
		}
		return cb_setZslDisabled_Z;
	}

	private static nint n_SetZslDisabled_Z(nint jnienv, nint native__this, bool p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZslDisabled(p0));
	}

	public unsafe Java.Lang.Object SetZslDisabled(bool p0)
	{
		if (id_setZslDisabled_Z == IntPtr.Zero)
		{
			id_setZslDisabled_Z = JNIEnv.GetMethodID(class_ref, "setZslDisabled", "(Z)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setZslDisabled_Z, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetMutableConfigHandler()
	{
		if ((object)cb_getMutableConfig == null)
		{
			cb_getMutableConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMutableConfig));
		}
		return cb_getMutableConfig;
	}

	private static nint n_GetMutableConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MutableConfig);
	}

	private static Delegate GetBuildHandler()
	{
		if ((object)cb_build == null)
		{
			cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
		}
		return cb_build;
	}

	private static nint n_Build(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
	}

	public Java.Lang.Object Build()
	{
		if (id_build == IntPtr.Zero)
		{
			id_build = JNIEnv.GetMethodID(class_ref, "build", "()Ljava/lang/Object;");
		}
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTargetClass_Ljava_lang_Class_Handler()
	{
		if ((object)cb_setTargetClass_Ljava_lang_Class_ == null)
		{
			cb_setTargetClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTargetClass_Ljava_lang_Class_));
		}
		return cb_setTargetClass_Ljava_lang_Class_;
	}

	private static nint n_SetTargetClass_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class targetClass = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetTargetClass(targetClass));
	}

	public unsafe Java.Lang.Object SetTargetClass(Class p0)
	{
		if (id_setTargetClass_Ljava_lang_Class_ == IntPtr.Zero)
		{
			id_setTargetClass_Ljava_lang_Class_ = JNIEnv.GetMethodID(class_ref, "setTargetClass", "(Ljava/lang/Class;)Ljava/lang/Object;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setTargetClass_Ljava_lang_Class_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTargetName_Ljava_lang_String_Handler()
	{
		if ((object)cb_setTargetName_Ljava_lang_String_ == null)
		{
			cb_setTargetName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTargetName_Ljava_lang_String_));
		}
		return cb_setTargetName_Ljava_lang_String_;
	}

	private static nint n_SetTargetName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IUseCaseConfigBuilder? useCaseConfigBuilder = Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string targetName = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigBuilder.SetTargetName(targetName));
	}

	public unsafe Java.Lang.Object SetTargetName(string p0)
	{
		if (id_setTargetName_Ljava_lang_String_ == IntPtr.Zero)
		{
			id_setTargetName_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "setTargetName", "(Ljava/lang/String;)Ljava/lang/Object;");
		}
		nint num = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		Java.Lang.Object? result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_setTargetName_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}
}
