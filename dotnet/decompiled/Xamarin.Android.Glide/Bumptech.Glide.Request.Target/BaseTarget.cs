using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request.Transition;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Target;

[Obsolete("This class is obsoleted in this android platform")]
[Register("com/bumptech/glide/request/target/BaseTarget", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "Z" })]
public abstract class BaseTarget : Java.Lang.Object, ITarget, ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/target/BaseTarget", typeof(BaseTarget));

	private static Delegate? cb_getRequest_GetRequest_Lcom_bumptech_glide_request_Request_;

	private static Delegate? cb_setRequest_SetRequest_Lcom_bumptech_glide_request_Request__V;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onLoadCleared_OnLoadCleared_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onLoadFailed_OnLoadFailed_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onLoadStarted_OnLoadStarted_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onResourceReady_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition__V;

	private static Delegate? cb_getSize_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

	private static Delegate? cb_removeCallback_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

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

	public unsafe virtual IRequest? Request
	{
		[Register("getRequest", "()Lcom/bumptech/glide/request/Request;", "GetGetRequestHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IRequest>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRequest.()Lcom/bumptech/glide/request/Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setRequest", "(Lcom/bumptech/glide/request/Request;)V", "GetSetRequest_Lcom_bumptech_glide_request_Request_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRequest.(Lcom/bumptech/glide/request/Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected BaseTarget(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BaseTarget()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetRequestHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRequest);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRequest(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request);
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

	private static Delegate GetSetRequest_Lcom_bumptech_glide_request_Request_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRequest_Lcom_bumptech_glide_request_Request_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRequest_Lcom_bumptech_glide_request_Request_(nint jnienv, nint native__this, nint native_request)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequest request = Java.Lang.Object.GetObject<IRequest>(native_request, JniHandleOwnership.DoNotTransfer);
			baseTarget.Request = request;
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
			Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	private static Delegate GetOnLoadCleared_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadCleared_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadCleared_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_placeholder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable placeholder = Java.Lang.Object.GetObject<Drawable>(native_placeholder, JniHandleOwnership.DoNotTransfer);
			baseTarget.OnLoadCleared(placeholder);
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

	[Register("onLoadCleared", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadCleared_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void OnLoadCleared(Drawable? placeholder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(placeholder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLoadCleared.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(placeholder);
		}
	}

	private static Delegate GetOnLoadFailed_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadFailed_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadFailed_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_errorDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable errorDrawable = Java.Lang.Object.GetObject<Drawable>(native_errorDrawable, JniHandleOwnership.DoNotTransfer);
			baseTarget.OnLoadFailed(errorDrawable);
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

	[Register("onLoadFailed", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadFailed_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void OnLoadFailed(Drawable? errorDrawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorDrawable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLoadFailed.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorDrawable);
		}
	}

	private static Delegate GetOnLoadStarted_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadStarted_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadStarted_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_placeholder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable placeholder = Java.Lang.Object.GetObject<Drawable>(native_placeholder, JniHandleOwnership.DoNotTransfer);
			baseTarget.OnLoadStarted(placeholder);
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

	[Register("onLoadStarted", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadStarted_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void OnLoadStarted(Drawable? placeholder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(placeholder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLoadStarted.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(placeholder);
		}
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
			Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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
			Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	private static Delegate GetOnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_(nint jnienv, nint native__this, nint native_resource, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object resource = Java.Lang.Object.GetObject<Java.Lang.Object>(native_resource, JniHandleOwnership.DoNotTransfer);
			ITransition transition2 = Java.Lang.Object.GetObject<ITransition>(native_transition, JniHandleOwnership.DoNotTransfer);
			baseTarget.OnResourceReady(resource, transition2);
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

	[Register("onResourceReady", "(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition;)V", "GetOnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_Handler")]
	public abstract void OnResourceReady(Java.Lang.Object? resource, ITransition? transition);

	private static Delegate GetGetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			baseTarget.GetSize(p);
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

	[Register("getSize", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetGetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler")]
	public abstract void GetSize(ISizeReadyCallback p0);

	private static Delegate GetRemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseTarget? baseTarget = Java.Lang.Object.GetObject<BaseTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			baseTarget.RemoveCallback(p);
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

	[Register("removeCallback", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetRemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler")]
	public abstract void RemoveCallback(ISizeReadyCallback p0);

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
