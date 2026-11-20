using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Data;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Model;
using Bumptech.Glide.Load.Resource.Transcode;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/Registry", DoNotGenerateAcw = true)]
public class Registry : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/Registry", typeof(Registry));

	private static Delegate? cb_getImageHeaderParsers_GetImageHeaderParsers_Ljava_util_List_;

	private static Delegate? cb_append_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_append_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_append_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_append_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_append_Append_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_getLoadPath_GetLoadPath_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class__Lcom_bumptech_glide_load_engine_LoadPath_;

	private static Delegate? cb_getModelLoaders_GetModelLoaders_Ljava_lang_Object__Ljava_util_List_;

	private static Delegate? cb_getRegisteredResourceClasses_GetRegisteredResourceClasses_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class__Ljava_util_List_;

	private static Delegate? cb_getResultEncoder_GetResultEncoder_Lcom_bumptech_glide_load_engine_Resource__Lcom_bumptech_glide_load_ResourceEncoder_;

	private static Delegate? cb_getRewinder_GetRewinder_Ljava_lang_Object__Lcom_bumptech_glide_load_data_DataRewinder_;

	private static Delegate? cb_getSourceEncoder_GetSourceEncoder_Ljava_lang_Object__Lcom_bumptech_glide_load_Encoder_;

	private static Delegate? cb_isResourceEncoderAvailable_IsResourceEncoderAvailable_Lcom_bumptech_glide_load_engine_Resource__Z;

	private static Delegate? cb_prepend_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_prepend_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_prepend_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_prepend_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_prepend_Prepend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_register_Register_Lcom_bumptech_glide_load_data_DataRewinder_Factory__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_register_Register_Lcom_bumptech_glide_load_ImageHeaderParser__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_register_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_register_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_register_Register_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_resource_transcode_ResourceTranscoder__Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_replace_Replace_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory__Lcom_bumptech_glide_Registry_;

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

	public unsafe virtual IList<IImageHeaderParser> ImageHeaderParsers
	{
		[Register("getImageHeaderParsers", "()Ljava/util/List;", "GetGetImageHeaderParsersHandler")]
		get
		{
			return JavaList<IImageHeaderParser>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageHeaderParsers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Registry(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Registry()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetImageHeaderParsersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetImageHeaderParsers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetImageHeaderParsers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IImageHeaderParser>.ToLocalJniHandle(Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageHeaderParsers);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetAppend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_(nint jnienv, nint native__this, nint native_dataClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IEncoder encoder = Java.Lang.Object.GetObject<IEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Append(dataClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("append", "(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", "GetAppend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler")]
	[JavaTypeParameters(new string[] { "Data" })]
	public unsafe virtual Registry Append(Class dataClass, IEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(encoder);
		}
	}

	private static Delegate GetAppend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_(nint jnienv, nint native__this, nint native_resourceClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceEncoder encoder = Java.Lang.Object.GetObject<IResourceEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Append(resourceClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("append", "(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", "GetAppend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler")]
	[JavaTypeParameters(new string[] { "TResource" })]
	public unsafe virtual Registry Append(Class resourceClass, IResourceEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(encoder);
		}
	}

	private static Delegate GetAppend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_(nint jnienv, nint native__this, nint native_modelClass, nint native_dataClass, nint native_factory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IModelLoaderFactory factory = Java.Lang.Object.GetObject<IModelLoaderFactory>(native_factory, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Append(modelClass, dataClass, factory));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("append", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", "GetAppend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler")]
	[JavaTypeParameters(new string[] { "Model", "Data" })]
	public unsafe virtual Registry Append(Class modelClass, Class dataClass, IModelLoaderFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(factory);
		}
	}

	private static Delegate GetAppend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_(nint jnienv, nint native__this, nint native_dataClass, nint native_resourceClass, nint native_decoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceDecoder decoder = Java.Lang.Object.GetObject<IResourceDecoder>(native_decoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Append(dataClass, resourceClass, decoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("append", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", "GetAppend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler")]
	[JavaTypeParameters(new string[] { "Data", "TResource" })]
	public unsafe virtual Registry Append(Class dataClass, Class resourceClass, IResourceDecoder decoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((decoder == null) ? IntPtr.Zero : ((Java.Lang.Object)decoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(decoder);
		}
	}

	private static Delegate GetAppend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler()
	{
		return new global::_JniMarshal_PPLLLL_L(n_Append_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_(nint jnienv, nint native__this, nint native_bucket, nint native_dataClass, nint native_resourceClass, nint native_decoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string bucket = JNIEnv.GetString(native_bucket, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceDecoder decoder = Java.Lang.Object.GetObject<IResourceDecoder>(native_decoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Append(bucket, dataClass, resourceClass, decoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("append", "(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", "GetAppend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler")]
	[JavaTypeParameters(new string[] { "Data", "TResource" })]
	public unsafe virtual Registry Append(string bucket, Class dataClass, Class resourceClass, IResourceDecoder decoder)
	{
		nint num = JNIEnv.NewString(bucket);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((decoder == null) ? IntPtr.Zero : ((Java.Lang.Object)decoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(decoder);
		}
	}

	private static Delegate GetGetLoadPath_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_GetLoadPath_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLoadPath_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_dataClass, nint native_resourceClass, nint native_transcodeClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			Class transcodeClass = Java.Lang.Object.GetObject<Class>(native_transcodeClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.GetLoadPath(dataClass, resourceClass, transcodeClass));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getLoadPath", "(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;)Lcom/bumptech/glide/load/engine/LoadPath;", "GetGetLoadPath_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "Data", "TResource", "Transcode" })]
	public unsafe virtual LoadPath? GetLoadPath(Class dataClass, Class resourceClass, Class transcodeClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LoadPath>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoadPath.(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;)Lcom/bumptech/glide/load/engine/LoadPath;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transcodeClass);
		}
	}

	private static Delegate GetGetModelLoaders_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetModelLoaders_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetModelLoaders_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_model)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JavaList.ToLocalJniHandle(registry.GetModelLoaders(model));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getModelLoaders", "(Ljava/lang/Object;)Ljava/util/List;", "GetGetModelLoaders_Ljava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "Model" })]
	public unsafe virtual IList GetModelLoaders(Java.Lang.Object model)
	{
		nint num = JNIEnv.ToLocalJniHandle(model);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getModelLoaders.(Ljava/lang/Object;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(model);
		}
	}

	private static Delegate GetGetRegisteredResourceClasses_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_GetRegisteredResourceClasses_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRegisteredResourceClasses_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_modelClass, nint native_resourceClass, nint native_transcodeClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			Class transcodeClass = Java.Lang.Object.GetObject<Class>(native_transcodeClass, JniHandleOwnership.DoNotTransfer);
			return JavaList<Java.Lang.Class>.ToLocalJniHandle(registry.GetRegisteredResourceClasses(modelClass, resourceClass, transcodeClass));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getRegisteredResourceClasses", "(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;)Ljava/util/List;", "GetGetRegisteredResourceClasses_Ljava_lang_Class_Ljava_lang_Class_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "Model", "TResource", "Transcode" })]
	public unsafe virtual IList<Class> GetRegisteredResourceClasses(Class modelClass, Class resourceClass, Class transcodeClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			return JavaList<Java.Lang.Class>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getRegisteredResourceClasses.(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/Class;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transcodeClass);
		}
	}

	private static Delegate GetGetResultEncoder_Lcom_bumptech_glide_load_engine_Resource_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetResultEncoder_Lcom_bumptech_glide_load_engine_Resource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResultEncoder_Lcom_bumptech_glide_load_engine_Resource_(nint jnienv, nint native__this, nint native_resource)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResource resource = Java.Lang.Object.GetObject<IResource>(native_resource, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.GetResultEncoder(resource));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getResultEncoder", "(Lcom/bumptech/glide/load/engine/Resource;)Lcom/bumptech/glide/load/ResourceEncoder;", "GetGetResultEncoder_Lcom_bumptech_glide_load_engine_Resource_Handler")]
	[JavaTypeParameters(new string[] { "X" })]
	public unsafe virtual IResourceEncoder GetResultEncoder(IResource resource)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((resource == null) ? IntPtr.Zero : ((Java.Lang.Object)resource).Handle);
			return Java.Lang.Object.GetObject<IResourceEncoder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResultEncoder.(Lcom/bumptech/glide/load/engine/Resource;)Lcom/bumptech/glide/load/ResourceEncoder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resource);
		}
	}

	private static Delegate GetGetRewinder_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetRewinder_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRewinder_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.GetRewinder(data));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getRewinder", "(Ljava/lang/Object;)Lcom/bumptech/glide/load/data/DataRewinder;", "GetGetRewinder_Ljava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "X" })]
	public unsafe virtual IDataRewinder GetRewinder(Java.Lang.Object data)
	{
		nint num = JNIEnv.ToLocalJniHandle(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IDataRewinder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRewinder.(Ljava/lang/Object;)Lcom/bumptech/glide/load/data/DataRewinder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetGetSourceEncoder_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetSourceEncoder_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSourceEncoder_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.GetSourceEncoder(data));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSourceEncoder", "(Ljava/lang/Object;)Lcom/bumptech/glide/load/Encoder;", "GetGetSourceEncoder_Ljava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "X" })]
	public unsafe virtual IEncoder GetSourceEncoder(Java.Lang.Object data)
	{
		nint num = JNIEnv.ToLocalJniHandle(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IEncoder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSourceEncoder.(Ljava/lang/Object;)Lcom/bumptech/glide/load/Encoder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetIsResourceEncoderAvailable_Lcom_bumptech_glide_load_engine_Resource_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsResourceEncoderAvailable_Lcom_bumptech_glide_load_engine_Resource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsResourceEncoderAvailable_Lcom_bumptech_glide_load_engine_Resource_(nint jnienv, nint native__this, nint native_resource)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResource resource = Java.Lang.Object.GetObject<IResource>(native_resource, JniHandleOwnership.DoNotTransfer);
			return registry.IsResourceEncoderAvailable(resource) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("isResourceEncoderAvailable", "(Lcom/bumptech/glide/load/engine/Resource;)Z", "GetIsResourceEncoderAvailable_Lcom_bumptech_glide_load_engine_Resource_Handler")]
	public unsafe virtual bool IsResourceEncoderAvailable(IResource resource)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((resource == null) ? IntPtr.Zero : ((Java.Lang.Object)resource).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResourceEncoderAvailable.(Lcom/bumptech/glide/load/engine/Resource;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(resource);
		}
	}

	private static Delegate GetPrepend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_(nint jnienv, nint native__this, nint native_dataClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IEncoder encoder = Java.Lang.Object.GetObject<IEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Prepend(dataClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("prepend", "(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", "GetPrepend_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler")]
	[JavaTypeParameters(new string[] { "Data" })]
	public unsafe virtual Registry Prepend(Class dataClass, IEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("prepend.(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(encoder);
		}
	}

	private static Delegate GetPrepend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Prepend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_(nint jnienv, nint native__this, nint native_resourceClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceEncoder encoder = Java.Lang.Object.GetObject<IResourceEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Prepend(resourceClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("prepend", "(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", "GetPrepend_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler")]
	[JavaTypeParameters(new string[] { "TResource" })]
	public unsafe virtual Registry Prepend(Class resourceClass, IResourceEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("prepend.(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(encoder);
		}
	}

	private static Delegate GetPrepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_(nint jnienv, nint native__this, nint native_modelClass, nint native_dataClass, nint native_factory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IModelLoaderFactory factory = Java.Lang.Object.GetObject<IModelLoaderFactory>(native_factory, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Prepend(modelClass, dataClass, factory));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("prepend", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", "GetPrepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler")]
	[JavaTypeParameters(new string[] { "Model", "Data" })]
	public unsafe virtual Registry Prepend(Class modelClass, Class dataClass, IModelLoaderFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("prepend.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(factory);
		}
	}

	private static Delegate GetPrepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Prepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_(nint jnienv, nint native__this, nint native_dataClass, nint native_resourceClass, nint native_decoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceDecoder decoder = Java.Lang.Object.GetObject<IResourceDecoder>(native_decoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Prepend(dataClass, resourceClass, decoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("prepend", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", "GetPrepend_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler")]
	[JavaTypeParameters(new string[] { "Data", "TResource" })]
	public unsafe virtual Registry Prepend(Class dataClass, Class resourceClass, IResourceDecoder decoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((decoder == null) ? IntPtr.Zero : ((Java.Lang.Object)decoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("prepend.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(decoder);
		}
	}

	private static Delegate GetPrepend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler()
	{
		return new global::_JniMarshal_PPLLLL_L(n_Prepend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Prepend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_(nint jnienv, nint native__this, nint native_bucket, nint native_dataClass, nint native_resourceClass, nint native_decoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string bucket = JNIEnv.GetString(native_bucket, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceDecoder decoder = Java.Lang.Object.GetObject<IResourceDecoder>(native_decoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Prepend(bucket, dataClass, resourceClass, decoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("prepend", "(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", "GetPrepend_Ljava_lang_String_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceDecoder_Handler")]
	[JavaTypeParameters(new string[] { "Data", "TResource" })]
	public unsafe virtual Registry Prepend(string bucket, Class dataClass, Class resourceClass, IResourceDecoder decoder)
	{
		nint num = JNIEnv.NewString(bucket);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((decoder == null) ? IntPtr.Zero : ((Java.Lang.Object)decoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("prepend.(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceDecoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(decoder);
		}
	}

	private static Delegate GetRegister_Lcom_bumptech_glide_load_data_DataRewinder_Factory_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Register_Lcom_bumptech_glide_load_data_DataRewinder_Factory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Register_Lcom_bumptech_glide_load_data_DataRewinder_Factory_(nint jnienv, nint native__this, nint native_factory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDataRewinderFactory factory = Java.Lang.Object.GetObject<IDataRewinderFactory>(native_factory, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Register(factory));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("register", "(Lcom/bumptech/glide/load/data/DataRewinder$Factory;)Lcom/bumptech/glide/Registry;", "GetRegister_Lcom_bumptech_glide_load_data_DataRewinder_Factory_Handler")]
	public unsafe virtual Registry Register(IDataRewinderFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Lcom/bumptech/glide/load/data/DataRewinder$Factory;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(factory);
		}
	}

	private static Delegate GetRegister_Lcom_bumptech_glide_load_ImageHeaderParser_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Register_Lcom_bumptech_glide_load_ImageHeaderParser_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Register_Lcom_bumptech_glide_load_ImageHeaderParser_(nint jnienv, nint native__this, nint native_parser)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IImageHeaderParser parser = Java.Lang.Object.GetObject<IImageHeaderParser>(native_parser, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Register(parser));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("register", "(Lcom/bumptech/glide/load/ImageHeaderParser;)Lcom/bumptech/glide/Registry;", "GetRegister_Lcom_bumptech_glide_load_ImageHeaderParser_Handler")]
	public unsafe virtual Registry Register(IImageHeaderParser parser)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((parser == null) ? IntPtr.Zero : ((Java.Lang.Object)parser).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Lcom/bumptech/glide/load/ImageHeaderParser;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(parser);
		}
	}

	[Obsolete]
	private static Delegate GetRegister_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_(nint jnienv, nint native__this, nint native_dataClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IEncoder encoder = Java.Lang.Object.GetObject<IEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Register(dataClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("register", "(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", "GetRegister_Ljava_lang_Class_Lcom_bumptech_glide_load_Encoder_Handler")]
	[JavaTypeParameters(new string[] { "Data" })]
	public unsafe virtual Registry Register(Class dataClass, IEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Ljava/lang/Class;Lcom/bumptech/glide/load/Encoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dataClass);
			GC.KeepAlive(encoder);
		}
	}

	[Obsolete]
	private static Delegate GetRegister_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Register_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_(nint jnienv, nint native__this, nint native_resourceClass, nint native_encoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			IResourceEncoder encoder = Java.Lang.Object.GetObject<IResourceEncoder>(native_encoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Register(resourceClass, encoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("register", "(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", "GetRegister_Ljava_lang_Class_Lcom_bumptech_glide_load_ResourceEncoder_Handler")]
	[JavaTypeParameters(new string[] { "TResource" })]
	public unsafe virtual Registry Register(Class resourceClass, IResourceEncoder encoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((encoder == null) ? IntPtr.Zero : ((Java.Lang.Object)encoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Ljava/lang/Class;Lcom/bumptech/glide/load/ResourceEncoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(encoder);
		}
	}

	private static Delegate GetRegister_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_resource_transcode_ResourceTranscoder_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Register_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_resource_transcode_ResourceTranscoder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Register_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_resource_transcode_ResourceTranscoder_(nint jnienv, nint native__this, nint native_resourceClass, nint native_transcodeClass, nint native_transcoder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			Class transcodeClass = Java.Lang.Object.GetObject<Class>(native_transcodeClass, JniHandleOwnership.DoNotTransfer);
			IResourceTranscoder transcoder = Java.Lang.Object.GetObject<IResourceTranscoder>(native_transcoder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Register(resourceClass, transcodeClass, transcoder));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("register", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/resource/transcode/ResourceTranscoder;)Lcom/bumptech/glide/Registry;", "GetRegister_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_resource_transcode_ResourceTranscoder_Handler")]
	[JavaTypeParameters(new string[] { "TResource", "Transcode" })]
	public unsafe virtual Registry Register(Class resourceClass, Class transcodeClass, IResourceTranscoder transcoder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((transcoder == null) ? IntPtr.Zero : ((Java.Lang.Object)transcoder).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/resource/transcode/ResourceTranscoder;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transcodeClass);
			GC.KeepAlive(transcoder);
		}
	}

	private static Delegate GetReplace_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_Replace_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_(nint jnienv, nint native__this, nint native_modelClass, nint native_dataClass, nint native_factory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Registry? registry = Java.Lang.Object.GetObject<Registry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			IModelLoaderFactory factory = Java.Lang.Object.GetObject<IModelLoaderFactory>(native_factory, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(registry.Replace(modelClass, dataClass, factory));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("replace", "(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", "GetReplace_Ljava_lang_Class_Ljava_lang_Class_Lcom_bumptech_glide_load_model_ModelLoaderFactory_Handler")]
	[JavaTypeParameters(new string[] { "Model", "Data" })]
	public unsafe virtual Registry Replace(Class modelClass, Class dataClass, IModelLoaderFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(Ljava/lang/Class;Ljava/lang/Class;Lcom/bumptech/glide/load/model/ModelLoaderFactory;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
			GC.KeepAlive(dataClass);
			GC.KeepAlive(factory);
		}
	}

	[Register("setResourceDecoderBucketPriorityList", "(Ljava/util/List;)Lcom/bumptech/glide/Registry;", "")]
	public unsafe Registry SetResourceDecoderBucketPriorityList(IList<string> buckets)
	{
		nint num = JavaList<string>.ToLocalJniHandle(buckets);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setResourceDecoderBucketPriorityList.(Ljava/util/List;)Lcom/bumptech/glide/Registry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(buckets);
		}
	}
}
