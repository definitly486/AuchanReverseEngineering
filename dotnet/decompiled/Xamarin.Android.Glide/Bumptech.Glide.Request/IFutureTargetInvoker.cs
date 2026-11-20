using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request.Target;
using Bumptech.Glide.Request.Transition;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/FutureTarget", DoNotGenerateAcw = true)]
internal class IFutureTargetInvoker : Java.Lang.Object, IFutureTarget, ITarget, ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable, IFuture
{
	private static readonly JniPeerMembers _members_Android_Runtime_IJavaObject = new XAPeerMembers("Android/Runtime/IJavaObject", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_LifecycleListener = new XAPeerMembers("com/bumptech/glide/manager/LifecycleListener", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_request_FutureTarget = new XAPeerMembers("com/bumptech/glide/request/FutureTarget", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_request_target_Target = new XAPeerMembers("com/bumptech/glide/request/target/Target", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_Java_Interop_IJavaPeerable = new XAPeerMembers("Java/Interop/IJavaPeerable", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_java_util_concurrent_Future = new XAPeerMembers("java/util/concurrent/Future", typeof(IFutureTargetInvoker));

	private static readonly JniPeerMembers _members_System_IDisposable = new XAPeerMembers("System/IDisposable", typeof(IFutureTargetInvoker));

	private static Delegate? cb_getRequest_GetRequest_Lcom_bumptech_glide_request_Request_;

	private static Delegate? cb_setRequest_SetRequest_Lcom_bumptech_glide_request_Request__V;

	private static Delegate? cb_getSize_GetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

	private static Delegate? cb_onLoadCleared_OnLoadCleared_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onLoadFailed_OnLoadFailed_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onLoadStarted_OnLoadStarted_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onResourceReady_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition__V;

	private static Delegate? cb_removeCallback_RemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback__V;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_isCancelled_IsCancelled_Z;

	private static Delegate? cb_isDone_IsDone_Z;

	private static Delegate? cb_cancel_Cancel_Z_Z;

	private static Delegate? cb_get_Get_Ljava_lang_Object_;

	private static Delegate? cb_get_Get_JLjava_util_concurrent_TimeUnit__Ljava_lang_Object_;

	private static nint java_class_ref => _members_com_bumptech_glide_request_FutureTarget.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_FutureTarget;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_FutureTarget.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_FutureTarget.ManagedPeerType;

	public unsafe IRequest? Request
	{
		get
		{
			return Java.Lang.Object.GetObject<IRequest>(_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractObjectMethod("getRequest.()Lcom/bumptech/glide/request/Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("setRequest.(Lcom/bumptech/glide/request/Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool IsCancelled => _members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractBooleanMethod("isCancelled.()Z", this, null);

	public unsafe bool IsDone => _members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);

	public IFutureTargetInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request);
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
	private static void n_SetRequest_Lcom_bumptech_glide_request_Request_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequest request = Java.Lang.Object.GetObject<IRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.Request = request;
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
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.GetSize(p);
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

	public unsafe void GetSize(ISizeReadyCallback p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("getSize.(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLoadCleared_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadCleared_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadCleared_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable p = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.OnLoadCleared(p);
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

	public unsafe void OnLoadCleared(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("onLoadCleared.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLoadFailed_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadFailed_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadFailed_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable p = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.OnLoadFailed(p);
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

	public unsafe void OnLoadFailed(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("onLoadFailed.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLoadStarted_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadStarted_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadStarted_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable p = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.OnLoadStarted(p);
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

	public unsafe void OnLoadStarted(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("onLoadStarted.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			ITransition p2 = Java.Lang.Object.GetObject<ITransition>(native_p1, JniHandleOwnership.DoNotTransfer);
			futureTarget.OnResourceReady(p, p2);
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

	public unsafe void OnResourceReady(Java.Lang.Object p0, ITransition? p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("onResourceReady.(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

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
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISizeReadyCallback p = Java.Lang.Object.GetObject<ISizeReadyCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			futureTarget.RemoveCallback(p);
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

	public unsafe void RemoveCallback(ISizeReadyCallback p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_request_target_Target.InstanceMethods.InvokeAbstractVoidMethod("removeCallback.(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
			Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	public unsafe void OnDestroy()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onDestroy.()V", this, null);
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
			Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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

	public unsafe void OnStart()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
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
			Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	public unsafe void OnStop()
	{
		_members_com_bumptech_glide_manager_LifecycleListener.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetIsCancelledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCancelled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCancelled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancelled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsDoneHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetCancel_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_Cancel_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Cancel_Z(nint jnienv, nint native__this, sbyte native_mayInterruptIfRunning)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool mayInterruptIfRunning = native_mayInterruptIfRunning != 0;
			return futureTarget.Cancel(mayInterruptIfRunning) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Cancel(bool mayInterruptIfRunning)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mayInterruptIfRunning ? ((sbyte)1) : ((sbyte)0));
		return _members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractBooleanMethod("cancel.(Z)Z", this, ptr);
	}

	private static Delegate GetGetHandler()
	{
		return new global::_JniMarshal_PP_L(n_Get);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
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

	public unsafe Java.Lang.Object? Get()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractObjectMethod("get.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGet_JLjava_util_concurrent_TimeUnit_Handler()
	{
		return new global::_JniMarshal_PPJL_L(n_Get_JLjava_util_concurrent_TimeUnit_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_JLjava_util_concurrent_TimeUnit_(nint jnienv, nint native__this, long timeout, nint native_unit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFutureTarget? futureTarget = Java.Lang.Object.GetObject<IFutureTarget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(futureTarget.Get(timeout, unit));
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

	public unsafe Java.Lang.Object? Get(long timeout, TimeUnit? unit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(timeout);
			ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractObjectMethod("get.(JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(unit);
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
