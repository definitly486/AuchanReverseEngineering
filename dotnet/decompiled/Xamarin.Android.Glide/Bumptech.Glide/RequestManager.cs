using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Net;
using Android.Runtime;
using Android.Views;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request;
using Bumptech.Glide.Request.Target;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/RequestManager", DoNotGenerateAcw = true)]
public class RequestManager : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable, ILifecycleListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/RequestManager", typeof(RequestManager));

	private static Delegate? cb_isPaused_IsPaused_Z;

	private static Delegate? cb_addDefaultRequestListener_AddDefaultRequestListener_Lcom_bumptech_glide_request_RequestListener__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_applyDefaultRequestOptions_ApplyDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_as_As_Ljava_lang_Class__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_asBitmap_AsBitmap_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_asDrawable_AsDrawable_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_asFile_AsFile_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_asGif_AsGif_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_clear_Clear_Landroid_view_View__V;

	private static Delegate? cb_clear_Clear_Lcom_bumptech_glide_request_target_Target__V;

	private static Delegate? cb_clearOnStop_ClearOnStop_Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_download_Download_Ljava_lang_Object__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_downloadOnly_DownloadOnly_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_graphics_Bitmap__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_graphics_drawable_Drawable__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Landroid_net_Uri__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_arrayB_Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_io_File__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_Integer__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_Object__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_lang_String__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_load_Load_Ljava_net_URL__Lcom_bumptech_glide_RequestBuilder_;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onLowMemory_OnLowMemory_V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onTrimMemory_OnTrimMemory_I_V;

	private static Delegate? cb_pauseAllRequests_PauseAllRequests_V;

	private static Delegate? cb_pauseAllRequestsRecursive_PauseAllRequestsRecursive_V;

	private static Delegate? cb_pauseRequests_PauseRequests_V;

	private static Delegate? cb_pauseRequestsRecursive_PauseRequestsRecursive_V;

	private static Delegate? cb_resumeRequests_ResumeRequests_V;

	private static Delegate? cb_resumeRequestsRecursive_ResumeRequestsRecursive_V;

	private static Delegate? cb_setDefaultRequestOptions_SetDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions__Lcom_bumptech_glide_RequestManager_;

	private static Delegate? cb_setPauseAllRequestsOnTrimMemoryModerate_SetPauseAllRequestsOnTrimMemoryModerate_Z_V;

	private static Delegate? cb_setRequestOptions_SetRequestOptions_Lcom_bumptech_glide_request_RequestOptions__V;

	[Register("context")]
	protected Context? Context
	{
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("context.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("context.Landroid/content/Context;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("glide")]
	protected Glide? Glide
	{
		get
		{
			return Java.Lang.Object.GetObject<Glide>(_members.InstanceFields.GetObjectValue("glide.Lcom/bumptech/glide/Glide;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("glide.Lcom/bumptech/glide/Glide;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	public unsafe virtual bool IsPaused
	{
		[Register("isPaused", "()Z", "GetIsPausedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPaused.()Z", this, null);
		}
	}

	protected RequestManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/manager/Lifecycle;Lcom/bumptech/glide/manager/RequestManagerTreeNode;Landroid/content/Context;)V", "")]
	public unsafe RequestManager(Glide glide, ILifecycle lifecycle, IRequestManagerTreeNode treeNode, Context context)
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
			ptr[1] = new JniArgumentValue((lifecycle == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycle).Handle);
			ptr[2] = new JniArgumentValue((treeNode == null) ? IntPtr.Zero : ((Java.Lang.Object)treeNode).Handle);
			ptr[3] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/manager/Lifecycle;Lcom/bumptech/glide/manager/RequestManagerTreeNode;Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/Glide;Lcom/bumptech/glide/manager/Lifecycle;Lcom/bumptech/glide/manager/RequestManagerTreeNode;Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(glide);
			GC.KeepAlive(lifecycle);
			GC.KeepAlive(treeNode);
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetIsPausedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsPaused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPaused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPaused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAddDefaultRequestListener_Lcom_bumptech_glide_request_RequestListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddDefaultRequestListener_Lcom_bumptech_glide_request_RequestListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddDefaultRequestListener_Lcom_bumptech_glide_request_RequestListener_(nint jnienv, nint native__this, nint native_requestListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequestListener requestListener = Java.Lang.Object.GetObject<IRequestListener>(native_requestListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.AddDefaultRequestListener(requestListener));
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

	[Register("addDefaultRequestListener", "(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestManager;", "GetAddDefaultRequestListener_Lcom_bumptech_glide_request_RequestListener_Handler")]
	public unsafe virtual RequestManager? AddDefaultRequestListener(IRequestListener? requestListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((requestListener == null) ? IntPtr.Zero : ((Java.Lang.Object)requestListener).Handle);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("addDefaultRequestListener.(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestListener);
		}
	}

	private static Delegate GetApplyDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ApplyDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ApplyDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_(nint jnienv, nint native__this, nint native_requestOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestOptions requestOptions = Java.Lang.Object.GetObject<RequestOptions>(native_requestOptions, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.ApplyDefaultRequestOptions(requestOptions));
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

	[Register("applyDefaultRequestOptions", "(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/RequestManager;", "GetApplyDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler")]
	public unsafe virtual RequestManager ApplyDefaultRequestOptions(RequestOptions requestOptions)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requestOptions?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("applyDefaultRequestOptions.(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestOptions);
		}
	}

	private static Delegate GetAs_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_As_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_As_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_resourceClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class resourceClass = Java.Lang.Object.GetObject<Class>(native_resourceClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.As(resourceClass));
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

	[Register("as", "(Ljava/lang/Class;)Lcom/bumptech/glide/RequestBuilder;", "GetAs_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "ResourceType" })]
	public unsafe virtual RequestBuilder As(Class resourceClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("as.(Ljava/lang/Class;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
		}
	}

	private static Delegate GetAsBitmapHandler()
	{
		return new global::_JniMarshal_PP_L(n_AsBitmap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsBitmap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBitmap());
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

	[Register("asBitmap", "()Lcom/bumptech/glide/RequestBuilder;", "GetAsBitmapHandler")]
	public unsafe virtual RequestBuilder AsBitmap()
	{
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("asBitmap.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAsDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_AsDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsDrawable());
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

	[Register("asDrawable", "()Lcom/bumptech/glide/RequestBuilder;", "GetAsDrawableHandler")]
	public unsafe virtual RequestBuilder AsDrawable()
	{
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("asDrawable.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAsFileHandler()
	{
		return new global::_JniMarshal_PP_L(n_AsFile);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsFile(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsFile());
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

	[Register("asFile", "()Lcom/bumptech/glide/RequestBuilder;", "GetAsFileHandler")]
	public unsafe virtual RequestBuilder AsFile()
	{
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("asFile.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAsGifHandler()
	{
		return new global::_JniMarshal_PP_L(n_AsGif);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsGif(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsGif());
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

	[Register("asGif", "()Lcom/bumptech/glide/RequestBuilder;", "GetAsGifHandler")]
	public unsafe virtual RequestBuilder AsGif()
	{
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("asGif.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetClear_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Clear_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			requestManager.Clear(view);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("clear", "(Landroid/view/View;)V", "GetClear_Landroid_view_View_Handler")]
	public unsafe virtual void Clear(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetClear_Lcom_bumptech_glide_request_target_Target_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Clear_Lcom_bumptech_glide_request_target_Target_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear_Lcom_bumptech_glide_request_target_Target_(nint jnienv, nint native__this, nint native_target)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITarget target = Java.Lang.Object.GetObject<ITarget>(native_target, JniHandleOwnership.DoNotTransfer);
			requestManager.Clear(target);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("clear", "(Lcom/bumptech/glide/request/target/Target;)V", "GetClear_Lcom_bumptech_glide_request_target_Target_Handler")]
	public unsafe virtual void Clear(ITarget? target)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Java.Lang.Object)target).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(Lcom/bumptech/glide/request/target/Target;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetClearOnStopHandler()
	{
		return new global::_JniMarshal_PP_L(n_ClearOnStop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ClearOnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnStop());
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

	[Register("clearOnStop", "()Lcom/bumptech/glide/RequestManager;", "GetClearOnStopHandler")]
	public unsafe virtual RequestManager ClearOnStop()
	{
		return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("clearOnStop.()Lcom/bumptech/glide/RequestManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDownload_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Download_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Download_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_model)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Download(model));
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

	[Register("download", "(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", "GetDownload_Ljava_lang_Object_Handler")]
	public unsafe virtual RequestBuilder Download(Java.Lang.Object? model)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("download.(Ljava/lang/Object;)Lcom/bumptech/glide/RequestBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(model);
		}
	}

	private static Delegate GetDownloadOnlyHandler()
	{
		return new global::_JniMarshal_PP_L(n_DownloadOnly);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DownloadOnly(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DownloadOnly());
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

	[Register("downloadOnly", "()Lcom/bumptech/glide/RequestBuilder;", "GetDownloadOnlyHandler")]
	public unsafe virtual RequestBuilder DownloadOnly()
	{
		return Java.Lang.Object.GetObject<RequestBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("downloadOnly.()Lcom/bumptech/glide/RequestBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(bitmap));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(drawable));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(uri));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_model, JniHandleOwnership.DoNotTransfer, typeof(byte));
			nint result = JNIEnv.ToLocalJniHandle(requestManager.Load(array));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			File file = Java.Lang.Object.GetObject<File>(native_file, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(file));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer resourceId = Java.Lang.Object.GetObject<Integer>(native_resourceId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(resourceId));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(model));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__string, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(text));
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
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URL url = Java.Lang.Object.GetObject<URL>(native_url, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.Load(url));
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

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(nint jnienv, nint native__this, nint native_newConfig)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
			requestManager.OnConfigurationChanged(newConfig);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe virtual void OnConfigurationChanged(Configuration? newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	private static Delegate GetOnDestroyHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDestroy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onDestroy", "()V", "GetOnDestroyHandler")]
	public unsafe virtual void OnDestroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
	}

	private static Delegate GetOnLowMemoryHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnLowMemory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLowMemory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLowMemory();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onLowMemory", "()V", "GetOnLowMemoryHandler")]
	public unsafe virtual void OnLowMemory()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLowMemory.()V", this, null);
	}

	private static Delegate GetOnStartHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onStart", "()V", "GetOnStartHandler")]
	public unsafe virtual void OnStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onStop", "()V", "GetOnStopHandler")]
	public unsafe virtual void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetOnTrimMemory_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnTrimMemory_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTrimMemory_I(nint jnienv, nint native__this, int native_level)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTrimMemory((TrimMemory)native_level);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onTrimMemory", "(I)V", "GetOnTrimMemory_IHandler")]
	public unsafe virtual void OnTrimMemory(TrimMemory level)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)level);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onTrimMemory.(I)V", this, ptr);
	}

	private static Delegate GetPauseAllRequestsHandler()
	{
		return new global::_JniMarshal_PP_V(n_PauseAllRequests);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PauseAllRequests(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseAllRequests();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("pauseAllRequests", "()V", "GetPauseAllRequestsHandler")]
	public unsafe virtual void PauseAllRequests()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("pauseAllRequests.()V", this, null);
	}

	private static Delegate GetPauseAllRequestsRecursiveHandler()
	{
		return new global::_JniMarshal_PP_V(n_PauseAllRequestsRecursive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PauseAllRequestsRecursive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseAllRequestsRecursive();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("pauseAllRequestsRecursive", "()V", "GetPauseAllRequestsRecursiveHandler")]
	public unsafe virtual void PauseAllRequestsRecursive()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("pauseAllRequestsRecursive.()V", this, null);
	}

	private static Delegate GetPauseRequestsHandler()
	{
		return new global::_JniMarshal_PP_V(n_PauseRequests);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PauseRequests(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseRequests();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("pauseRequests", "()V", "GetPauseRequestsHandler")]
	public unsafe virtual void PauseRequests()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("pauseRequests.()V", this, null);
	}

	private static Delegate GetPauseRequestsRecursiveHandler()
	{
		return new global::_JniMarshal_PP_V(n_PauseRequestsRecursive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PauseRequestsRecursive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PauseRequestsRecursive();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("pauseRequestsRecursive", "()V", "GetPauseRequestsRecursiveHandler")]
	public unsafe virtual void PauseRequestsRecursive()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("pauseRequestsRecursive.()V", this, null);
	}

	private static Delegate GetResumeRequestsHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResumeRequests);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResumeRequests(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResumeRequests();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resumeRequests", "()V", "GetResumeRequestsHandler")]
	public unsafe virtual void ResumeRequests()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resumeRequests.()V", this, null);
	}

	private static Delegate GetResumeRequestsRecursiveHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResumeRequestsRecursive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResumeRequestsRecursive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResumeRequestsRecursive();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resumeRequestsRecursive", "()V", "GetResumeRequestsRecursiveHandler")]
	public unsafe virtual void ResumeRequestsRecursive()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resumeRequestsRecursive.()V", this, null);
	}

	private static Delegate GetSetDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_(nint jnienv, nint native__this, nint native_requestOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestOptions defaultRequestOptions = Java.Lang.Object.GetObject<RequestOptions>(native_requestOptions, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(requestManager.SetDefaultRequestOptions(defaultRequestOptions));
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

	[Register("setDefaultRequestOptions", "(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/RequestManager;", "GetSetDefaultRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler")]
	public unsafe virtual RequestManager SetDefaultRequestOptions(RequestOptions requestOptions)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requestOptions?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDefaultRequestOptions.(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/RequestManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestOptions);
		}
	}

	private static Delegate GetSetPauseAllRequestsOnTrimMemoryModerate_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetPauseAllRequestsOnTrimMemoryModerate_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPauseAllRequestsOnTrimMemoryModerate_Z(nint jnienv, nint native__this, sbyte native_pauseAllOnTrim)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool pauseAllRequestsOnTrimMemoryModerate = native_pauseAllOnTrim != 0;
			requestManager.SetPauseAllRequestsOnTrimMemoryModerate(pauseAllRequestsOnTrimMemoryModerate);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setPauseAllRequestsOnTrimMemoryModerate", "(Z)V", "GetSetPauseAllRequestsOnTrimMemoryModerate_ZHandler")]
	public unsafe virtual void SetPauseAllRequestsOnTrimMemoryModerate(bool pauseAllOnTrim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pauseAllOnTrim ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPauseAllRequestsOnTrimMemoryModerate.(Z)V", this, ptr);
	}

	private static Delegate GetSetRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRequestOptions_Lcom_bumptech_glide_request_RequestOptions_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRequestOptions_Lcom_bumptech_glide_request_RequestOptions_(nint jnienv, nint native__this, nint native_toSet)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RequestManager? requestManager = Java.Lang.Object.GetObject<RequestManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestOptions requestOptions = Java.Lang.Object.GetObject<RequestOptions>(native_toSet, JniHandleOwnership.DoNotTransfer);
			requestManager.SetRequestOptions(requestOptions);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setRequestOptions", "(Lcom/bumptech/glide/request/RequestOptions;)V", "GetSetRequestOptions_Lcom_bumptech_glide_request_RequestOptions_Handler")]
	protected unsafe virtual void SetRequestOptions(RequestOptions toSet)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(toSet?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRequestOptions.(Lcom/bumptech/glide/request/RequestOptions;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toSet);
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
