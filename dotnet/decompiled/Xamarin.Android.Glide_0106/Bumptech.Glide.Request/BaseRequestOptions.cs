using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Resource.Bitmap;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/BaseRequestOptions", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T extends com.bumptech.glide.request.BaseRequestOptions<T>" })]
public abstract class BaseRequestOptions : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/BaseRequestOptions", typeof(BaseRequestOptions));

	private static Delegate? cb_apply_Apply_T_Lcom_bumptech_glide_request_BaseRequestOptions__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_autoClone_AutoClone_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_centerCrop_CenterCrop_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_centerInside_CenterInside_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_circleCrop_CircleCrop_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_clone_Clone_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_decode_Decode_T_Ljava_lang_Class__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_disallowHardwareConfig_DisallowHardwareConfig_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_diskCacheStrategy_DiskCacheStrategy_T_Lcom_bumptech_glide_load_engine_DiskCacheStrategy__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_dontAnimate_DontAnimate_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_dontTransform_DontTransform_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_downsample_Downsample_T_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_encodeFormat_EncodeFormat_T_Landroid_graphics_Bitmap_CompressFormat__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_encodeQuality_EncodeQuality_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_error_Error_T_Landroid_graphics_drawable_Drawable__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_error_Error_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_fallback_Fallback_T_Landroid_graphics_drawable_Drawable__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_fallback_Fallback_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_fitCenter_FitCenter_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_format_Format_T_Lcom_bumptech_glide_load_DecodeFormat__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_frame_Frame_T_J_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_lock_Lock_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_onlyRetrieveFromCache_OnlyRetrieveFromCache_T_Z_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalCenterCrop_OptionalCenterCrop_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalCenterInside_OptionalCenterInside_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalCircleCrop_OptionalCircleCrop_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalFitCenter_OptionalFitCenter_T_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalTransform_OptionalTransform_T_Lcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_optionalTransform_OptionalTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_override_Override_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_override_Override_T_II_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_placeholder_Placeholder_T_Landroid_graphics_drawable_Drawable__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_placeholder_Placeholder_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_priority_Priority_T_Lcom_bumptech_glide_Priority__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_set_Set_T_Lcom_bumptech_glide_load_Option_Ljava_lang_Object__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_signature_Signature_T_Lcom_bumptech_glide_load_Key__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_sizeMultiplier_SizeMultiplier_T_F_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_skipMemoryCache_SkipMemoryCache_T_Z_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_theme_Theme_T_Landroid_content_res_Resources_Theme__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_timeout_Timeout_T_I_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_transform_Transform_T_Lcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_transform_Transform_T_arrayLcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_transform_Transform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_transforms_Transforms_arrayLcom_bumptech_glide_load_Transformation__Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_useAnimationPool_UseAnimationPool_T_Z_Lcom_bumptech_glide_request_BaseRequestOptions_;

	private static Delegate? cb_useUnlimitedSourceGeneratorsPool_UseUnlimitedSourceGeneratorsPool_T_Z_Lcom_bumptech_glide_request_BaseRequestOptions_;

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

	public unsafe DiskCacheStrategy DiskCacheStrategy
	{
		[Register("getDiskCacheStrategy", "()Lcom/bumptech/glide/load/engine/DiskCacheStrategy;", "")]
		get
		{
			return Java.Lang.Object.GetObject<DiskCacheStrategy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDiskCacheStrategy.()Lcom/bumptech/glide/load/engine/DiskCacheStrategy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int ErrorId
	{
		[Register("getErrorId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getErrorId.()I", this, null);
		}
	}

	public unsafe Drawable? ErrorPlaceholder
	{
		[Register("getErrorPlaceholder", "()Landroid/graphics/drawable/Drawable;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getErrorPlaceholder.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Drawable? FallbackDrawable
	{
		[Register("getFallbackDrawable", "()Landroid/graphics/drawable/Drawable;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFallbackDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int FallbackId
	{
		[Register("getFallbackId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getFallbackId.()I", this, null);
		}
	}

	protected unsafe bool IsAutoCloneEnabled
	{
		[Register("isAutoCloneEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAutoCloneEnabled.()Z", this, null);
		}
	}

	public unsafe bool IsDiskCacheStrategySet
	{
		[Register("isDiskCacheStrategySet", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDiskCacheStrategySet.()Z", this, null);
		}
	}

	public unsafe bool IsLocked
	{
		[Register("isLocked", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLocked.()Z", this, null);
		}
	}

	public unsafe bool IsMemoryCacheable
	{
		[Register("isMemoryCacheable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isMemoryCacheable.()Z", this, null);
		}
	}

	public unsafe bool IsPrioritySet
	{
		[Register("isPrioritySet", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isPrioritySet.()Z", this, null);
		}
	}

	public unsafe bool IsSkipMemoryCacheSet
	{
		[Register("isSkipMemoryCacheSet", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isSkipMemoryCacheSet.()Z", this, null);
		}
	}

	public unsafe bool IsTransformationAllowed
	{
		[Register("isTransformationAllowed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTransformationAllowed.()Z", this, null);
		}
	}

	public unsafe bool IsTransformationRequired
	{
		[Register("isTransformationRequired", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTransformationRequired.()Z", this, null);
		}
	}

	public unsafe bool IsTransformationSet
	{
		[Register("isTransformationSet", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTransformationSet.()Z", this, null);
		}
	}

	public unsafe bool IsValidOverride
	{
		[Register("isValidOverride", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isValidOverride.()Z", this, null);
		}
	}

	public unsafe bool OnlyRetrieveFromCache
	{
		[Register("getOnlyRetrieveFromCache", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getOnlyRetrieveFromCache.()Z", this, null);
		}
	}

	public unsafe Options Options
	{
		[Register("getOptions", "()Lcom/bumptech/glide/load/Options;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Options>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOptions.()Lcom/bumptech/glide/load/Options;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int OverrideHeight
	{
		[Register("getOverrideHeight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getOverrideHeight.()I", this, null);
		}
	}

	public unsafe int OverrideWidth
	{
		[Register("getOverrideWidth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getOverrideWidth.()I", this, null);
		}
	}

	public unsafe Drawable? PlaceholderDrawable
	{
		[Register("getPlaceholderDrawable", "()Landroid/graphics/drawable/Drawable;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPlaceholderDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int PlaceholderId
	{
		[Register("getPlaceholderId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getPlaceholderId.()I", this, null);
		}
	}

	public unsafe Priority Priority
	{
		[Register("getPriority", "()Lcom/bumptech/glide/Priority;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Priority>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPriority.()Lcom/bumptech/glide/Priority;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Class ResourceClass
	{
		[Register("getResourceClass", "()Ljava/lang/Class;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getResourceClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IKey Signature
	{
		[Register("getSignature", "()Lcom/bumptech/glide/load/Key;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IKey>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSignature.()Lcom/bumptech/glide/load/Key;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe float SizeMultiplier
	{
		[Register("getSizeMultiplier", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getSizeMultiplier.()F", this, null);
		}
	}

	public unsafe Resources.Theme? Theme
	{
		[Register("getTheme", "()Landroid/content/res/Resources$Theme;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Resources.Theme>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTheme.()Landroid/content/res/Resources$Theme;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IDictionary Transformations
	{
		[Register("getTransformations", "()Ljava/util/Map;", "")]
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTransformations.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool UseAnimationPool
	{
		[Register("getUseAnimationPool", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getUseAnimationPool.()Z", this, null);
		}
	}

	public unsafe bool UseUnlimitedSourceGeneratorsPool
	{
		[Register("getUseUnlimitedSourceGeneratorsPool", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getUseUnlimitedSourceGeneratorsPool.()Z", this, null);
		}
	}

	protected BaseRequestOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BaseRequestOptions()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetApply_T_Lcom_bumptech_glide_request_BaseRequestOptions_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Apply_T_Lcom_bumptech_glide_request_BaseRequestOptions_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Apply_T_Lcom_bumptech_glide_request_BaseRequestOptions_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BaseRequestOptions o = Java.Lang.Object.GetObject<BaseRequestOptions>(native_o, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Apply_T(o));
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

	[Register("apply", "(Lcom/bumptech/glide/request/BaseRequestOptions;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetApply_T_Lcom_bumptech_glide_request_BaseRequestOptions_Handler")]
	public unsafe virtual Java.Lang.Object Apply_T(BaseRequestOptions o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("apply.(Lcom/bumptech/glide/request/BaseRequestOptions;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetAutoClone_THandler()
	{
		return new global::_JniMarshal_PP_L(n_AutoClone_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AutoClone_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoClone_T());
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

	[Register("autoClone", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetAutoClone_THandler")]
	public unsafe virtual Java.Lang.Object AutoClone_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("autoClone.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCenterCrop_THandler()
	{
		return new global::_JniMarshal_PP_L(n_CenterCrop_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CenterCrop_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterCrop_T());
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

	[Register("centerCrop", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetCenterCrop_THandler")]
	public unsafe virtual Java.Lang.Object CenterCrop_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("centerCrop.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCenterInside_THandler()
	{
		return new global::_JniMarshal_PP_L(n_CenterInside_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CenterInside_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterInside_T());
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

	[Register("centerInside", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetCenterInside_THandler")]
	public unsafe virtual Java.Lang.Object CenterInside_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("centerInside.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCircleCrop_THandler()
	{
		return new global::_JniMarshal_PP_L(n_CircleCrop_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CircleCrop_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CircleCrop_T());
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

	[Register("circleCrop", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetCircleCrop_THandler")]
	public unsafe virtual Java.Lang.Object CircleCrop_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("circleCrop.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetClone_THandler()
	{
		return new global::_JniMarshal_PP_L(n_Clone_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone_T());
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

	[Register("clone", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetClone_THandler")]
	public unsafe virtual Java.Lang.Object? Clone_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDecode_T_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Decode_T_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Decode_T_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_resourceClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Decode_T(resourceClass));
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

	[Register("decode", "(Ljava/lang/Class;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDecode_T_Ljava_lang_Class_Handler")]
	public unsafe virtual Java.Lang.Object Decode_T(Class resourceClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("decode.(Ljava/lang/Class;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
		}
	}

	private static Delegate GetDisallowHardwareConfig_THandler()
	{
		return new global::_JniMarshal_PP_L(n_DisallowHardwareConfig_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DisallowHardwareConfig_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisallowHardwareConfig_T());
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

	[Register("disallowHardwareConfig", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDisallowHardwareConfig_THandler")]
	public unsafe virtual Java.Lang.Object DisallowHardwareConfig_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("disallowHardwareConfig.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDiskCacheStrategy_T_Lcom_bumptech_glide_load_engine_DiskCacheStrategy_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_DiskCacheStrategy_T_Lcom_bumptech_glide_load_engine_DiskCacheStrategy_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DiskCacheStrategy_T_Lcom_bumptech_glide_load_engine_DiskCacheStrategy_(nint jnienv, nint native__this, nint native_strategy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DiskCacheStrategy strategy = Java.Lang.Object.GetObject<DiskCacheStrategy>(native_strategy, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.DiskCacheStrategy_T(strategy));
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

	[Register("diskCacheStrategy", "(Lcom/bumptech/glide/load/engine/DiskCacheStrategy;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDiskCacheStrategy_T_Lcom_bumptech_glide_load_engine_DiskCacheStrategy_Handler")]
	public unsafe virtual Java.Lang.Object DiskCacheStrategy_T(DiskCacheStrategy strategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("diskCacheStrategy.(Lcom/bumptech/glide/load/engine/DiskCacheStrategy;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(strategy);
		}
	}

	private static Delegate GetDontAnimate_THandler()
	{
		return new global::_JniMarshal_PP_L(n_DontAnimate_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DontAnimate_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DontAnimate_T());
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

	[Register("dontAnimate", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDontAnimate_THandler")]
	public unsafe virtual Java.Lang.Object DontAnimate_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("dontAnimate.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDontTransform_THandler()
	{
		return new global::_JniMarshal_PP_L(n_DontTransform_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DontTransform_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DontTransform_T());
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

	[Register("dontTransform", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDontTransform_THandler")]
	public unsafe virtual Java.Lang.Object DontTransform_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("dontTransform.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDownsample_T_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Downsample_T_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Downsample_T_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy_(nint jnienv, nint native__this, nint native_strategy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DownsampleStrategy strategy = Java.Lang.Object.GetObject<DownsampleStrategy>(native_strategy, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Downsample_T(strategy));
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

	[Register("downsample", "(Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetDownsample_T_Lcom_bumptech_glide_load_resource_bitmap_DownsampleStrategy_Handler")]
	public unsafe virtual Java.Lang.Object Downsample_T(DownsampleStrategy strategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("downsample.(Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(strategy);
		}
	}

	private static Delegate GetEncodeFormat_T_Landroid_graphics_Bitmap_CompressFormat_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_EncodeFormat_T_Landroid_graphics_Bitmap_CompressFormat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EncodeFormat_T_Landroid_graphics_Bitmap_CompressFormat_(nint jnienv, nint native__this, nint native_format)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap.CompressFormat format = Java.Lang.Object.GetObject<Bitmap.CompressFormat>(native_format, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.EncodeFormat_T(format));
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

	[Register("encodeFormat", "(Landroid/graphics/Bitmap$CompressFormat;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetEncodeFormat_T_Landroid_graphics_Bitmap_CompressFormat_Handler")]
	public unsafe virtual Java.Lang.Object EncodeFormat_T(Bitmap.CompressFormat format)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("encodeFormat.(Landroid/graphics/Bitmap$CompressFormat;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(format);
		}
	}

	private static Delegate GetEncodeQuality_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_EncodeQuality_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EncodeQuality_T_I(nint jnienv, nint native__this, int quality)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EncodeQuality_T(quality));
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

	[Register("encodeQuality", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetEncodeQuality_T_IHandler")]
	public unsafe virtual Java.Lang.Object EncodeQuality_T(int quality)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(quality);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("encodeQuality.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetError_T_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Error_T_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Error_T_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Error_T(drawable));
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

	[Register("error", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetError_T_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual Java.Lang.Object Error_T(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("error.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetError_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Error_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Error_T_I(nint jnienv, nint native__this, int resourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Error_T(resourceId));
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

	[Register("error", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetError_T_IHandler")]
	public unsafe virtual Java.Lang.Object Error_T(int resourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resourceId);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("error.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFallback_T_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Fallback_T_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Fallback_T_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Fallback_T(drawable));
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

	[Register("fallback", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetFallback_T_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual Java.Lang.Object Fallback_T(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("fallback.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetFallback_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Fallback_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Fallback_T_I(nint jnienv, nint native__this, int resourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fallback_T(resourceId));
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

	[Register("fallback", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetFallback_T_IHandler")]
	public unsafe virtual Java.Lang.Object Fallback_T(int resourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resourceId);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("fallback.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFitCenter_THandler()
	{
		return new global::_JniMarshal_PP_L(n_FitCenter_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FitCenter_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FitCenter_T());
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

	[Register("fitCenter", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetFitCenter_THandler")]
	public unsafe virtual Java.Lang.Object FitCenter_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("fitCenter.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFormat_T_Lcom_bumptech_glide_load_DecodeFormat_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Format_T_Lcom_bumptech_glide_load_DecodeFormat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Format_T_Lcom_bumptech_glide_load_DecodeFormat_(nint jnienv, nint native__this, nint native_format)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DecodeFormat format = Java.Lang.Object.GetObject<DecodeFormat>(native_format, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Format_T(format));
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

	[Register("format", "(Lcom/bumptech/glide/load/DecodeFormat;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetFormat_T_Lcom_bumptech_glide_load_DecodeFormat_Handler")]
	public unsafe virtual Java.Lang.Object Format_T(DecodeFormat format)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("format.(Lcom/bumptech/glide/load/DecodeFormat;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(format);
		}
	}

	private static Delegate GetFrame_T_JHandler()
	{
		return new global::_JniMarshal_PPJ_L(n_Frame_T_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Frame_T_J(nint jnienv, nint native__this, long frameTimeMicros)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Frame_T(frameTimeMicros));
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

	[Register("frame", "(J)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetFrame_T_JHandler")]
	public unsafe virtual Java.Lang.Object Frame_T(long frameTimeMicros)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(frameTimeMicros);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("frame.(J)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("isEquivalentTo", "(Lcom/bumptech/glide/request/BaseRequestOptions;)Z", "")]
	public unsafe bool IsEquivalentTo(BaseRequestOptions? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isEquivalentTo.(Lcom/bumptech/glide/request/BaseRequestOptions;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	private static Delegate GetLock_THandler()
	{
		return new global::_JniMarshal_PP_L(n_Lock_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Lock_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lock_T());
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

	[Register("lock", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetLock_THandler")]
	public unsafe virtual Java.Lang.Object Lock_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("lock.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnlyRetrieveFromCache_T_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_OnlyRetrieveFromCache_T_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnlyRetrieveFromCache_T_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native_flag != 0;
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.OnlyRetrieveFromCache_T(flag));
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

	[Register("onlyRetrieveFromCache", "(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOnlyRetrieveFromCache_T_ZHandler")]
	public unsafe virtual Java.Lang.Object OnlyRetrieveFromCache_T(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("onlyRetrieveFromCache.(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOptionalCenterCrop_THandler()
	{
		return new global::_JniMarshal_PP_L(n_OptionalCenterCrop_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalCenterCrop_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptionalCenterCrop_T());
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

	[Register("optionalCenterCrop", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalCenterCrop_THandler")]
	public unsafe virtual Java.Lang.Object OptionalCenterCrop_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalCenterCrop.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOptionalCenterInside_THandler()
	{
		return new global::_JniMarshal_PP_L(n_OptionalCenterInside_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalCenterInside_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptionalCenterInside_T());
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

	[Register("optionalCenterInside", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalCenterInside_THandler")]
	public unsafe virtual Java.Lang.Object OptionalCenterInside_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalCenterInside.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOptionalCircleCrop_THandler()
	{
		return new global::_JniMarshal_PP_L(n_OptionalCircleCrop_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalCircleCrop_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptionalCircleCrop_T());
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

	[Register("optionalCircleCrop", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalCircleCrop_THandler")]
	public unsafe virtual Java.Lang.Object OptionalCircleCrop_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalCircleCrop.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOptionalFitCenter_THandler()
	{
		return new global::_JniMarshal_PP_L(n_OptionalFitCenter_T);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalFitCenter_T(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptionalFitCenter_T());
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

	[Register("optionalFitCenter", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalFitCenter_THandler")]
	public unsafe virtual Java.Lang.Object OptionalFitCenter_T()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalFitCenter.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOptionalTransform_T_Lcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OptionalTransform_T_Lcom_bumptech_glide_load_Transformation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalTransform_T_Lcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_transformation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformation transformation = Java.Lang.Object.GetObject<ITransformation>(native_transformation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.OptionalTransform_T(transformation));
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

	[Register("optionalTransform", "(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalTransform_T_Lcom_bumptech_glide_load_Transformation_Handler")]
	public unsafe virtual Java.Lang.Object OptionalTransform_T(ITransformation transformation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((transformation == null) ? IntPtr.Zero : ((Java.Lang.Object)transformation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalTransform.(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(transformation);
		}
	}

	private static Delegate GetOptionalTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_OptionalTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OptionalTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_resourceClass, nint native_transformation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			ITransformation transformation = Java.Lang.Object.GetObject<ITransformation>(native_transformation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.OptionalTransform_T(resourceClass, transformation));
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

	[Register("optionalTransform", "(Ljava/lang/Class;Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOptionalTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_Handler")]
	[JavaTypeParameters(new string[] { "Y" })]
	public unsafe virtual Java.Lang.Object OptionalTransform_T(Class resourceClass, ITransformation transformation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((transformation == null) ? IntPtr.Zero : ((Java.Lang.Object)transformation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("optionalTransform.(Ljava/lang/Class;Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transformation);
		}
	}

	private static Delegate GetOverride_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Override_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Override_T_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Override_T(size));
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

	[Register("override", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOverride_T_IHandler")]
	public unsafe virtual Java.Lang.Object Override_T(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("override.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOverride_T_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_Override_T_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Override_T_II(nint jnienv, nint native__this, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Override_T(width, height));
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

	[Register("override", "(II)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetOverride_T_IIHandler")]
	public unsafe virtual Java.Lang.Object Override_T(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("override.(II)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPlaceholder_T_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Placeholder_T_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Placeholder_T_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Placeholder_T(drawable));
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

	[Register("placeholder", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetPlaceholder_T_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual Java.Lang.Object Placeholder_T(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("placeholder.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetPlaceholder_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Placeholder_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Placeholder_T_I(nint jnienv, nint native__this, int resourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Placeholder_T(resourceId));
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

	[Register("placeholder", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetPlaceholder_T_IHandler")]
	public unsafe virtual Java.Lang.Object Placeholder_T(int resourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resourceId);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("placeholder.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPriority_T_Lcom_bumptech_glide_Priority_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Priority_T_Lcom_bumptech_glide_Priority_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Priority_T_Lcom_bumptech_glide_Priority_(nint jnienv, nint native__this, nint native_priority)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Priority_T(priority));
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

	[Register("priority", "(Lcom/bumptech/glide/Priority;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetPriority_T_Lcom_bumptech_glide_Priority_Handler")]
	public unsafe virtual Java.Lang.Object Priority_T(Priority priority)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("priority.(Lcom/bumptech/glide/Priority;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(priority);
		}
	}

	[Register("selfOrThrowIfLocked", "()Lcom/bumptech/glide/request/BaseRequestOptions;", "")]
	protected unsafe Java.Lang.Object SelfOrThrowIfLocked()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("selfOrThrowIfLocked.()Lcom/bumptech/glide/request/BaseRequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSet_T_Lcom_bumptech_glide_load_Option_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Set_T_Lcom_bumptech_glide_load_Option_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Set_T_Lcom_bumptech_glide_load_Option_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_option, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Option option = Java.Lang.Object.GetObject<Option>(native_option, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Set_T(option, value));
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

	[Register("set", "(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetSet_T_Lcom_bumptech_glide_load_Option_Ljava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "Y" })]
	public unsafe virtual Java.Lang.Object Set_T(Option option, Java.Lang.Object value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("set.(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(option);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSignature_T_Lcom_bumptech_glide_load_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Signature_T_Lcom_bumptech_glide_load_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Signature_T_Lcom_bumptech_glide_load_Key_(nint jnienv, nint native__this, nint native_signature)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey signature = Java.Lang.Object.GetObject<IKey>(native_signature, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Signature_T(signature));
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

	[Register("signature", "(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetSignature_T_Lcom_bumptech_glide_load_Key_Handler")]
	public unsafe virtual Java.Lang.Object Signature_T(IKey signature)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((signature == null) ? IntPtr.Zero : ((Java.Lang.Object)signature).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("signature.(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(signature);
		}
	}

	private static Delegate GetSizeMultiplier_T_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_SizeMultiplier_T_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SizeMultiplier_T_F(nint jnienv, nint native__this, float sizeMultiplier)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SizeMultiplier_T(sizeMultiplier));
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

	[Register("sizeMultiplier", "(F)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetSizeMultiplier_T_FHandler")]
	public unsafe virtual Java.Lang.Object SizeMultiplier_T(float sizeMultiplier)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(sizeMultiplier);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("sizeMultiplier.(F)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSkipMemoryCache_T_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SkipMemoryCache_T_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SkipMemoryCache_T_Z(nint jnienv, nint native__this, sbyte native_skip)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool skip = native_skip != 0;
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.SkipMemoryCache_T(skip));
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

	[Register("skipMemoryCache", "(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetSkipMemoryCache_T_ZHandler")]
	public unsafe virtual Java.Lang.Object SkipMemoryCache_T(bool skip)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(skip ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("skipMemoryCache.(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetTheme_T_Landroid_content_res_Resources_Theme_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Theme_T_Landroid_content_res_Resources_Theme_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Theme_T_Landroid_content_res_Resources_Theme_(nint jnienv, nint native__this, nint native_theme)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Resources.Theme theme = Java.Lang.Object.GetObject<Resources.Theme>(native_theme, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Theme_T(theme));
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

	[Register("theme", "(Landroid/content/res/Resources$Theme;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTheme_T_Landroid_content_res_Resources_Theme_Handler")]
	public unsafe virtual Java.Lang.Object Theme_T(Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("theme.(Landroid/content/res/Resources$Theme;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(theme);
		}
	}

	private static Delegate GetTimeout_T_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Timeout_T_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Timeout_T_I(nint jnienv, nint native__this, int timeoutMs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout_T(timeoutMs));
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

	[Register("timeout", "(I)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTimeout_T_IHandler")]
	public unsafe virtual Java.Lang.Object Timeout_T(int timeoutMs)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(timeoutMs);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("timeout.(I)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetTransform_T_Lcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Transform_T_Lcom_bumptech_glide_load_Transformation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_T_Lcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_transformation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformation transformation = Java.Lang.Object.GetObject<ITransformation>(native_transformation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Transform_T(transformation));
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

	[Register("transform", "(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTransform_T_Lcom_bumptech_glide_load_Transformation_Handler")]
	public unsafe virtual Java.Lang.Object Transform_T(ITransformation transformation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((transformation == null) ? IntPtr.Zero : ((Java.Lang.Object)transformation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("transform.(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(transformation);
		}
	}

	private static Delegate GetTransform_T_arrayLcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Transform_T_arrayLcom_bumptech_glide_load_Transformation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_T_arrayLcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_transformations)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformation[] array = (ITransformation[])JNIEnv.GetArray(native_transformations, JniHandleOwnership.DoNotTransfer, typeof(ITransformation));
			nint result = JNIEnv.ToLocalJniHandle(baseRequestOptions.Transform_T(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_transformations);
			}
			return result;
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

	[Register("transform", "([Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTransform_T_arrayLcom_bumptech_glide_load_Transformation_Handler")]
	public unsafe virtual Java.Lang.Object Transform_T(params ITransformation[] transformations)
	{
		nint num = JNIEnv.NewArray(transformations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("transform.([Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (transformations != null)
			{
				JNIEnv.CopyArray(num, transformations);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(transformations);
		}
	}

	private static Delegate GetTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Transform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_resourceClass, nint native_transformation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			ITransformation transformation = Java.Lang.Object.GetObject<ITransformation>(native_transformation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.Transform_T(resourceClass, transformation));
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

	[Register("transform", "(Ljava/lang/Class;Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTransform_T_Ljava_lang_Class_Lcom_bumptech_glide_load_Transformation_Handler")]
	[JavaTypeParameters(new string[] { "Y" })]
	public unsafe virtual Java.Lang.Object Transform_T(Class resourceClass, ITransformation transformation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((transformation == null) ? IntPtr.Zero : ((Java.Lang.Object)transformation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("transform.(Ljava/lang/Class;Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
			GC.KeepAlive(transformation);
		}
	}

	[Obsolete]
	private static Delegate GetTransforms_arrayLcom_bumptech_glide_load_Transformation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Transforms_arrayLcom_bumptech_glide_load_Transformation_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transforms_arrayLcom_bumptech_glide_load_Transformation_(nint jnienv, nint native__this, nint native_transformations)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformation[] array = (ITransformation[])JNIEnv.GetArray(native_transformations, JniHandleOwnership.DoNotTransfer, typeof(ITransformation));
			nint result = JNIEnv.ToLocalJniHandle(baseRequestOptions.Transforms(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_transformations);
			}
			return result;
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
	[Register("transforms", "([Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetTransforms_arrayLcom_bumptech_glide_load_Transformation_Handler")]
	public unsafe virtual Java.Lang.Object Transforms(params ITransformation[] transformations)
	{
		nint num = JNIEnv.NewArray(transformations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("transforms.([Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (transformations != null)
			{
				JNIEnv.CopyArray(num, transformations);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(transformations);
		}
	}

	private static Delegate GetUseAnimationPool_T_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_UseAnimationPool_T_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_UseAnimationPool_T_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native_flag != 0;
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.UseAnimationPool_T(flag));
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

	[Register("useAnimationPool", "(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetUseAnimationPool_T_ZHandler")]
	public unsafe virtual Java.Lang.Object UseAnimationPool_T(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("useAnimationPool.(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUseUnlimitedSourceGeneratorsPool_T_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_UseUnlimitedSourceGeneratorsPool_T_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_UseUnlimitedSourceGeneratorsPool_T_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseRequestOptions? baseRequestOptions = Java.Lang.Object.GetObject<BaseRequestOptions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native_flag != 0;
			return JNIEnv.ToLocalJniHandle(baseRequestOptions.UseUnlimitedSourceGeneratorsPool_T(flag));
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

	[Register("useUnlimitedSourceGeneratorsPool", "(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", "GetUseUnlimitedSourceGeneratorsPool_T_ZHandler")]
	public unsafe virtual Java.Lang.Object UseUnlimitedSourceGeneratorsPool_T(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("useUnlimitedSourceGeneratorsPool.(Z)Lcom/bumptech/glide/request/BaseRequestOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
