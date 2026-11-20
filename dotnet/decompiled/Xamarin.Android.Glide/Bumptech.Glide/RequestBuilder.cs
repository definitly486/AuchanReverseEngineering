using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Net;
using Android.Runtime;
using Android.Widget;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Resource.Bitmap;
using Bumptech.Glide.Request;
using Bumptech.Glide.Request.Target;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/RequestBuilder", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "TranscodeType" })]
public class RequestBuilder : BaseRequestOptions, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/RequestBuilder", typeof(RequestBuilder));

	private static Delegate? cb_getDownloadOnlyRequest_GetDownloadOnlyRequest_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_addListener_AddListener_Lcom_bumptech_glide_request_RequestListener__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_downloadOnly_DownloadOnly_II_Lcom_bumptech_glide_request_FutureTarget_;

	private static Delegate? cb_downloadOnly_DownloadOnly_Lcom_bumptech_glide_request_target_Target__Lcom_bumptech_glide_request_target_Target_;

	private static Delegate? cb_error_Error_Lcom_bumptech_glide_RequestBuilder__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_error_Error_Ljava_lang_Object__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_into_Into_Landroid_widget_ImageView__Lcom_bumptech_glide_request_target_ViewTarget_;

	private static Delegate? cb_into_Into_II_Lcom_bumptech_glide_request_FutureTarget_;

	private static Delegate? cb_into_Into_Lcom_bumptech_glide_request_target_Target__Lcom_bumptech_glide_request_target_Target_;

	private static Delegate? cb_listener_Listener_Lcom_bumptech_glide_request_RequestListener__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_graphics_Bitmap__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_graphics_drawable_Drawable__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_net_Uri__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_arrayB_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_io_File__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_Integer__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_Object__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_String__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_net_URL__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_preload_Preload_Lcom_bumptech_glide_request_target_Target_;

	private static Delegate? cb_preload_Preload_II_Lcom_bumptech_glide_request_target_Target_;

	private static Delegate? cb_submit_Submit_Lcom_bumptech_glide_request_FutureTarget_;

	private static Delegate? cb_submit_Submit_II_Lcom_bumptech_glide_request_FutureTarget_;

	private static Delegate? cb_thumbnail_Thumbnail_Lcom_bumptech_glide_RequestBuilder__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_thumbnail_Thumbnail_arrayLcom_bumptech_glide_RequestBuilder__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_thumbnail_Thumbnail_F_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_thumbnail_Thumbnail_Ljava_util_List__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_transition_Transition_Lcom_bumptech_glide_TransitionOptions__Lcom_bumptech_glide_RequestBuilder_;

	[Register("DOWNLOAD_ONLY_OPTIONS")]
	protected static RequestOptions? DownloadOnlyOptions => Java.Lang.Object.GetObject<RequestOptions>(_members.StaticFields.GetObjectValue("DOWNLOAD_ONLY_OPTIONS.Lcom/bumptech/glide/request/RequestOptions;").Handle, JniHandleOwnership.TransferLocalRef);

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe virtual RequestBuilder DownloadOnlyRequest
	{
		[Register("getDownloadOnlyRequest", "()Lcom/bumptech/glide/RequestBuilder;", "GetGetDownloadOnlyRequestHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDownloadOnlyRequest.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public virtual RequestBuilder Apply(BaseRequestOptions o)
	{
		return (RequestBuilder)Apply_T(o);
	}

	public virtual RequestBuilder AutoClone()
	{
		return (RequestBuilder)AutoClone_T();
	}

	public virtual RequestBuilder CenterCrop()
	{
		return (RequestBuilder)CenterCrop_T();
	}

	public virtual RequestBuilder CenterInside()
	{
		return (RequestBuilder)CenterInside_T();
	}

	public virtual RequestBuilder CircleCrop()
	{
		return (RequestBuilder)CircleCrop_T();
	}

	public new virtual RequestBuilder Clone()
	{
		return (RequestBuilder)Clone_T();
	}

	public virtual RequestBuilder Decode(Class resourceClass)
	{
		return (RequestBuilder)Decode_T(resourceClass);
	}

	public virtual RequestBuilder DisallowHardwareConfig()
	{
		return (RequestBuilder)DisallowHardwareConfig_T();
	}

	public virtual RequestBuilder Downsample(DownsampleStrategy strategy)
	{
		return (RequestBuilder)Downsample_T(strategy);
	}

	public virtual RequestBuilder DontAnimate()
	{
		return (RequestBuilder)DontAnimate_T();
	}

	public virtual RequestBuilder DontTransform()
	{
		return (RequestBuilder)DontTransform_T();
	}

	public virtual RequestBuilder EncodeFormat(Bitmap.CompressFormat format)
	{
		return (RequestBuilder)EncodeFormat_T(format);
	}

	public virtual RequestBuilder EncodeQuality(int quality)
	{
		return (RequestBuilder)EncodeQuality_T(quality);
	}

	public virtual RequestBuilder Error(Drawable drawable)
	{
		return (RequestBuilder)Error_T(drawable);
	}

	public virtual RequestBuilder Error(int resourceId)
	{
		return (RequestBuilder)Error_T(resourceId);
	}

	public virtual RequestBuilder Fallback(Drawable drawable)
	{
		return (RequestBuilder)Fallback_T(drawable);
	}

	public virtual RequestBuilder Fallback(int resourceId)
	{
		return (RequestBuilder)Fallback_T(resourceId);
	}

	public virtual RequestBuilder FitCenter()
	{
		return (RequestBuilder)FitCenter_T();
	}

	public virtual RequestBuilder Format(DecodeFormat format)
	{
		return (RequestBuilder)Format_T(format);
	}

	public virtual RequestBuilder Frame(long frameTimeMicros)
	{
		return (RequestBuilder)Frame_T(frameTimeMicros);
	}

	public virtual RequestBuilder Lock()
	{
		return (RequestBuilder)Lock_T();
	}

	public virtual RequestBuilder OptionalCenterCrop()
	{
		return (RequestBuilder)OptionalCenterCrop_T();
	}

	public virtual RequestBuilder OptionalCenterInside()
	{
		return (RequestBuilder)OptionalCenterInside_T();
	}

	public virtual RequestBuilder OptionalCircleCrop()
	{
		return (RequestBuilder)OptionalCircleCrop_T();
	}

	public virtual RequestBuilder OptionalFitCenter()
	{
		return (RequestBuilder)OptionalFitCenter_T();
	}

	public virtual RequestBuilder OptionalTransform(Class resourceClass, ITransformation transformation)
	{
		return (RequestBuilder)OptionalTransform_T(resourceClass, transformation);
	}

	public virtual RequestBuilder OptionalTransform(ITransformation transformation)
	{
		return (RequestBuilder)OptionalTransform_T(transformation);
	}

	public virtual RequestBuilder Override(int width, int height)
	{
		return (RequestBuilder)Override_T(width, height);
	}

	public virtual RequestBuilder Override(int size)
	{
		return (RequestBuilder)Override_T(size);
	}

	public virtual RequestBuilder Placeholder(Drawable drawable)
	{
		return (RequestBuilder)Placeholder_T(drawable);
	}

	public virtual RequestBuilder Placeholder(int resourceId)
	{
		return (RequestBuilder)Placeholder_T(resourceId);
	}

	public virtual RequestBuilder Set(Option option, Java.Lang.Object value)
	{
		return (RequestBuilder)Set_T(option, value);
	}

	public virtual RequestBuilder SetDiskCacheStrategy(DiskCacheStrategy strategy)
	{
		return (RequestBuilder)DiskCacheStrategy_T(strategy);
	}

	public virtual RequestBuilder SetOnlyRetrieveFromCache(bool flag)
	{
		return (RequestBuilder)OnlyRetrieveFromCache_T(flag);
	}

	public virtual RequestBuilder SetPriority(Priority priority)
	{
		return (RequestBuilder)Priority_T(priority);
	}

	public virtual RequestBuilder SetSignature(IKey signature)
	{
		return (RequestBuilder)Signature_T(signature);
	}

	public virtual RequestBuilder SetSizeMultiplier(float sizeMultiplier)
	{
		return (RequestBuilder)SizeMultiplier_T(sizeMultiplier);
	}

	public virtual RequestBuilder SetTheme(Resources.Theme theme)
	{
		return (RequestBuilder)Theme_T(theme);
	}

	public virtual RequestBuilder SetUseAnimationPool(bool flag)
	{
		return (RequestBuilder)UseAnimationPool_T(flag);
	}

	public virtual RequestBuilder SetUseUnlimitedSourceGeneratorsPool(bool flag)
	{
		return (RequestBuilder)UseUnlimitedSourceGeneratorsPool_T(flag);
	}

	public virtual RequestBuilder SkipMemoryCache(bool skip)
	{
		return (RequestBuilder)SkipMemoryCache_T(skip);
	}

	public virtual RequestBuilder Timeout(int timeoutMs)
	{
		return (RequestBuilder)Timeout_T(timeoutMs);
	}

	public virtual RequestBuilder Transform(Class resourceClass, ITransformation transformation)
	{
		return (RequestBuilder)Transform_T(resourceClass, transformation);
	}

	public virtual RequestBuilder Transform(params ITransformation[] transformations)
	{
		return (RequestBuilder)Transform_T(transformations);
	}

	public virtual RequestBuilder Transform(ITransformation transformation)
	{
		return (RequestBuilder)Transform_T(transformation);
	}

	protected RequestBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/RequestManager;Ljava/lang/Class;Landroid/content/Context;)V", "")]
	protected unsafe RequestBuilder(Glide glide, RequestManager? requestManager, Class? transcodeClass, Context? context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(glide?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestManager?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/RequestManager;Ljava/lang/Class;Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/RequestManager;Ljava/lang/Class;Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(glide);
			GC.KeepAlive(requestManager);
			GC.KeepAlive(transcodeClass);
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Ljava/lang/Class;Lcom/bumptech/glide/RequestBuilder;)V", "")]
	protected unsafe RequestBuilder(Class? transcodeClass, RequestBuilder? other)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transcodeClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Class;Lcom/bumptech/glide/RequestBuilder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Class;Lcom/bumptech/glide/RequestBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transcodeClass);
			GC.KeepAlive(other);
		}
	}

	private static Delegate GetGetDownloadOnlyRequestHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDownloadOnlyRequest);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDownloadOnlyRequest(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DownloadOnlyRequest);
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

	private static Delegate GetAddListener_Lcom_bumptech_glide_request_RequestListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddListener_Lcom_bumptech_glide_request_RequestListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddListener_Lcom_bumptech_glide_request_RequestListener_(nint jnienv, nint native__this, nint native_requestListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequestListener requestListener = Java.Lang.Object.GetObject<IRequestListener>(native_requestListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.AddListener(requestListener));
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

	[Register("addListener", "(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestBuilder;", "GetAddListener_Lcom_bumptech_glide_request_RequestListener_Handler")]
	public unsafe virtual RequestBuilder AddListener(IRequestListener? requestListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((requestListener == null) ? IntPtr.Zero : ((Java.Lang.Object)requestListener).Handle);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addListener.(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestListener);
		}
	}

	[Obsolete]
	private static Delegate GetDownloadOnly_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_DownloadOnly_II);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DownloadOnly_II(nint jnienv, nint native__this, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DownloadOnly(width, height));
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
	[Register("downloadOnly", "(II)Lcom/bumptech/glide/request/FutureTarget;", "GetDownloadOnly_IIHandler")]
	public unsafe virtual IFutureTarget? DownloadOnly(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<IFutureTarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("downloadOnly.(II)Lcom/bumptech/glide/request/FutureTarget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetDownloadOnly_Lcom_bumptech_glide_request_target_Target_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_DownloadOnly_Lcom_bumptech_glide_request_target_Target_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DownloadOnly_Lcom_bumptech_glide_request_target_Target_(nint jnienv, nint native__this, nint native_target)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object target = Java.Lang.Object.GetObject<Java.Lang.Object>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.DownloadOnly(target));
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
	[Register("downloadOnly", "(Lcom/bumptech/glide/request/target/Target;)Lcom/bumptech/glide/request/target/Target;", "GetDownloadOnly_Lcom_bumptech_glide_request_target_Target_Handler")]
	[JavaTypeParameters(new string[] { "Y extends com.bumptech.glide.request.target.Target<java.io.File>" })]
	public unsafe virtual Java.Lang.Object? DownloadOnly(Java.Lang.Object target)
	{
		nint num = JNIEnv.ToLocalJniHandle(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("downloadOnly.(Lcom/bumptech/glide/request/target/Target;)Lcom/bumptech/glide/request/target/Target;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetError_Lcom_bumptech_glide_RequestBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Error_Lcom_bumptech_glide_RequestBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Error_Lcom_bumptech_glide_RequestBuilder_(nint jnienv, nint native__this, nint native_errorBuilder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestBuilder errorBuilder = Java.Lang.Object.GetObject<RequestBuilder>(native_errorBuilder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Error(errorBuilder));
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

	[Register("error", "(Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", "GetError_Lcom_bumptech_glide_RequestBuilder_Handler")]
	public unsafe virtual RequestBuilder Error(RequestBuilder? errorBuilder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorBuilder?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("error.(Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(errorBuilder);
		}
	}

	private static Delegate GetError_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Error_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Error_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_model)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Error(model));
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

	[Register("error", "(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", "GetError_Ljava_lang_Object_Handler")]
	public unsafe virtual RequestBuilder Error(Java.Lang.Object? model)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("error.(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(model);
		}
	}

	private static Delegate GetInto_Landroid_widget_ImageView_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Into_Landroid_widget_ImageView_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Into_Landroid_widget_ImageView_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ImageView view = Java.Lang.Object.GetObject<ImageView>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Into(view));
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

	[Register("into", "(Landroid/widget/ImageView;)Lcom/bumptech/glide/request/target/ViewTarget;", "GetInto_Landroid_widget_ImageView_Handler")]
	public unsafe virtual ViewTarget Into(ImageView view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewTarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("into.(Landroid/widget/ImageView;)Lcom/bumptech/glide/request/target/ViewTarget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete]
	private static Delegate GetInto_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_Into_II);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Into_II(nint jnienv, nint native__this, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Into(width, height));
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
	[Register("into", "(II)Lcom/bumptech/glide/request/FutureTarget;", "GetInto_IIHandler")]
	public unsafe virtual IFutureTarget? Into(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<IFutureTarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("into.(II)Lcom/bumptech/glide/request/FutureTarget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInto_Lcom_bumptech_glide_request_target_Target_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Into_Lcom_bumptech_glide_request_target_Target_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Into_Lcom_bumptech_glide_request_target_Target_(nint jnienv, nint native__this, nint native_target)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object target = Java.Lang.Object.GetObject<Java.Lang.Object>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Into(target));
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

	[Register("into", "(Lcom/bumptech/glide/request/target/Target;)Lcom/bumptech/glide/request/target/Target;", "GetInto_Lcom_bumptech_glide_request_target_Target_Handler")]
	[JavaTypeParameters(new string[] { "Y extends com.bumptech.glide.request.target.Target<TranscodeType>" })]
	public unsafe virtual Java.Lang.Object Into(Java.Lang.Object target)
	{
		nint num = JNIEnv.ToLocalJniHandle(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("into.(Lcom/bumptech/glide/request/target/Target;)Lcom/bumptech/glide/request/target/Target;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetListener_Lcom_bumptech_glide_request_RequestListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Listener_Lcom_bumptech_glide_request_RequestListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Listener_Lcom_bumptech_glide_request_RequestListener_(nint jnienv, nint native__this, nint native_requestListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequestListener requestListener = Java.Lang.Object.GetObject<IRequestListener>(native_requestListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Listener(requestListener));
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

	[Register("listener", "(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestBuilder;", "GetListener_Lcom_bumptech_glide_request_RequestListener_Handler")]
	public unsafe virtual RequestBuilder Listener(IRequestListener? requestListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((requestListener == null) ? IntPtr.Zero : ((Java.Lang.Object)requestListener).Handle);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("listener.(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestListener);
		}
	}

	private static Delegate GetLoad_Landroid_graphics_Bitmap_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Landroid_graphics_Bitmap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bitmap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(bitmap));
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

	[Register("load", "(Landroid/graphics/Bitmap;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Landroid_graphics_Bitmap_Handler")]
	public unsafe virtual RequestBuilder Load(Bitmap? bitmap)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Landroid/graphics/Bitmap;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(bitmap);
		}
	}

	private static Delegate GetLoad_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(drawable));
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

	[Register("load", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual RequestBuilder Load(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetLoad_Landroid_net_Uri_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Landroid_net_Uri_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Landroid_net_Uri_(nint jnienv, nint native__this, nint native_uri)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(uri));
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

	[Register("load", "(Landroid/net/Uri;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Landroid_net_Uri_Handler")]
	public unsafe virtual RequestBuilder Load(Uri? uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Landroid/net/Uri;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
		}
	}

	private static Delegate GetLoad_arrayBHandler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_arrayB);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_arrayB(nint jnienv, nint native__this, nint native_model)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_model, JniHandleOwnership.DoNotTransfer, typeof(byte));
			nint result = JNIEnv.ToLocalJniHandle(requestBuilder.Load(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_model);
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

	[Register("load", "([B)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_arrayBHandler")]
	public unsafe virtual RequestBuilder Load(byte[]? model)
	{
		nint num = JNIEnv.NewArray(model);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.([B)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (model != null)
			{
				JNIEnv.CopyArray(num, model);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(model);
		}
	}

	private static Delegate GetLoad_Ljava_io_File_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Ljava_io_File_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Ljava_io_File_(nint jnienv, nint native__this, nint native_file)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			File file = Java.Lang.Object.GetObject<File>(native_file, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(file));
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

	[Register("load", "(Ljava/io/File;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Ljava_io_File_Handler")]
	public unsafe virtual RequestBuilder Load(File? file)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Ljava/io/File;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(file);
		}
	}

	private static Delegate GetLoad_Ljava_lang_Integer_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Ljava_lang_Integer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Ljava_lang_Integer_(nint jnienv, nint native__this, nint native_resourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer resourceId = Java.Lang.Object.GetObject<Integer>(native_resourceId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(resourceId));
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

	[Register("load", "(Ljava/lang/Integer;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Ljava_lang_Integer_Handler")]
	public unsafe virtual RequestBuilder Load(Integer? resourceId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Ljava/lang/Integer;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceId);
		}
	}

	private static Delegate GetLoad_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_model)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(model));
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

	[Register("load", "(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Ljava_lang_Object_Handler")]
	public unsafe virtual RequestBuilder Load(Java.Lang.Object? model)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(model);
		}
	}

	private static Delegate GetLoad_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Ljava_lang_String_(nint jnienv, nint native__this, nint native__string)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__string, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(text));
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

	[Register("load", "(Ljava/lang/String;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Ljava_lang_String_Handler")]
	public unsafe virtual RequestBuilder Load(string? @string)
	{
		nint num = JNIEnv.NewString(@string);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Ljava/lang/String;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Obsolete]
	private static Delegate GetLoad_Ljava_net_URL_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Load_Ljava_net_URL_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Load_Ljava_net_URL_(nint jnienv, nint native__this, nint native_url)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URL url = Java.Lang.Object.GetObject<URL>(native_url, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Load(url));
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
	[Register("load", "(Ljava/net/URL;)Lcom/bumptech/glide/RequestBuilder;", "GetLoad_Ljava_net_URL_Handler")]
	public unsafe virtual RequestBuilder? Load(URL? url)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("load.(Ljava/net/URL;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(url);
		}
	}

	private static Delegate GetPreloadHandler()
	{
		return new global::_JniMarshal_PP_L(n_Preload);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Preload(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Preload());
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

	[Register("preload", "()Lcom/bumptech/glide/request/target/Target;", "GetPreloadHandler")]
	public unsafe virtual ITarget Preload()
	{
		return Java.Lang.Object.GetObject<ITarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("preload.()Lcom/bumptech/glide/request/target/Target;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPreload_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_Preload_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Preload_II(nint jnienv, nint native__this, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Preload(width, height));
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

	[Register("preload", "(II)Lcom/bumptech/glide/request/target/Target;", "GetPreload_IIHandler")]
	public unsafe virtual ITarget Preload(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<ITarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("preload.(II)Lcom/bumptech/glide/request/target/Target;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSubmitHandler()
	{
		return new global::_JniMarshal_PP_L(n_Submit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Submit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Submit());
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

	[Register("submit", "()Lcom/bumptech/glide/request/FutureTarget;", "GetSubmitHandler")]
	public unsafe virtual IFutureTarget Submit()
	{
		return Java.Lang.Object.GetObject<IFutureTarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("submit.()Lcom/bumptech/glide/request/FutureTarget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSubmit_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_Submit_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Submit_II(nint jnienv, nint native__this, int width, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Submit(width, height));
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

	[Register("submit", "(II)Lcom/bumptech/glide/request/FutureTarget;", "GetSubmit_IIHandler")]
	public unsafe virtual IFutureTarget Submit(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<IFutureTarget>(_members.InstanceMethods.InvokeVirtualObjectMethod("submit.(II)Lcom/bumptech/glide/request/FutureTarget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetThumbnail_Lcom_bumptech_glide_RequestBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Thumbnail_Lcom_bumptech_glide_RequestBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Thumbnail_Lcom_bumptech_glide_RequestBuilder_(nint jnienv, nint native__this, nint native_thumbnailRequest)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestBuilder thumbnailRequest = Java.Lang.Object.GetObject<RequestBuilder>(native_thumbnailRequest, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Thumbnail(thumbnailRequest));
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

	[Register("thumbnail", "(Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", "GetThumbnail_Lcom_bumptech_glide_RequestBuilder_Handler")]
	public unsafe virtual RequestBuilder Thumbnail(RequestBuilder? thumbnailRequest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(thumbnailRequest?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("thumbnail.(Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(thumbnailRequest);
		}
	}

	private static Delegate GetThumbnail_arrayLcom_bumptech_glide_RequestBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Thumbnail_arrayLcom_bumptech_glide_RequestBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Thumbnail_arrayLcom_bumptech_glide_RequestBuilder_(nint jnienv, nint native__this, nint native_thumbnails)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestBuilder[] array = (RequestBuilder[])JNIEnv.GetArray(native_thumbnails, JniHandleOwnership.DoNotTransfer, typeof(RequestBuilder));
			nint result = JNIEnv.ToLocalJniHandle(requestBuilder.Thumbnail(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_thumbnails);
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

	[Register("thumbnail", "([Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", "GetThumbnail_arrayLcom_bumptech_glide_RequestBuilder_Handler")]
	public unsafe virtual RequestBuilder Thumbnail(params RequestBuilder[]? thumbnails)
	{
		nint num = JNIEnv.NewArray(thumbnails);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("thumbnail.([Lcom/bumptech/glide/RequestBuilder;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (thumbnails != null)
			{
				JNIEnv.CopyArray(num, thumbnails);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(thumbnails);
		}
	}

	[Obsolete]
	private static Delegate GetThumbnail_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_Thumbnail_F);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Thumbnail_F(nint jnienv, nint native__this, float sizeMultiplier)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Thumbnail(sizeMultiplier));
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
	[Register("thumbnail", "(F)Lcom/bumptech/glide/RequestBuilder;", "GetThumbnail_FHandler")]
	public unsafe virtual RequestBuilder Thumbnail(float sizeMultiplier)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(sizeMultiplier);
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("thumbnail.(F)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetThumbnail_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Thumbnail_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Thumbnail_Ljava_util_List_(nint jnienv, nint native__this, nint native_thumbnails)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList thumbnails = JavaList.FromJniHandle(native_thumbnails, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Thumbnail(thumbnails));
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

	[Register("thumbnail", "(Ljava/util/List;)Lcom/bumptech/glide/RequestBuilder;", "GetThumbnail_Ljava_util_List_Handler")]
	public unsafe virtual RequestBuilder Thumbnail(IList? thumbnails)
	{
		nint num = JavaList.ToLocalJniHandle(thumbnails);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("thumbnail.(Ljava/util/List;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(thumbnails);
		}
	}

	private static Delegate GetTransition_Lcom_bumptech_glide_TransitionOptions_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Transition_Lcom_bumptech_glide_TransitionOptions_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transition_Lcom_bumptech_glide_TransitionOptions_(nint jnienv, nint native__this, nint native_transitionOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestBuilder? requestBuilder = Java.Lang.Object.GetObject<RequestBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionOptions transitionOptions = Java.Lang.Object.GetObject<TransitionOptions>(native_transitionOptions, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestBuilder.Transition(transitionOptions));
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

	[Register("transition", "(Lcom/bumptech/glide/TransitionOptions;)Lcom/bumptech/glide/RequestBuilder;", "GetTransition_Lcom_bumptech_glide_TransitionOptions_Handler")]
	public unsafe virtual RequestBuilder Transition(TransitionOptions transitionOptions)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transitionOptions?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("transition.(Lcom/bumptech/glide/TransitionOptions;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(transitionOptions);
		}
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
