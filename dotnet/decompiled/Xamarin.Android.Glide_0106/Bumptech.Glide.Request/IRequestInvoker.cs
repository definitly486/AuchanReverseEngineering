using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/Request", DoNotGenerateAcw = true)]
internal class IRequestInvoker : Java.Lang.Object, IRequest, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_Request = new XAPeerMembers("com/bumptech/glide/request/Request", typeof(IRequestInvoker));

	private static Delegate? cb_isAnyResourceSet_IsAnyResourceSet_Z;

	private static Delegate? cb_isCleared_IsCleared_Z;

	private static Delegate? cb_isComplete_IsComplete_Z;

	private static Delegate? cb_isRunning_IsRunning_Z;

	private static Delegate? cb_begin_Begin_V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_isEquivalentTo_IsEquivalentTo_Lcom_bumptech_glide_request_Request__Z;

	private static Delegate? cb_pause_Pause_V;

	private static nint java_class_ref => _members_com_bumptech_glide_request_Request.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_Request;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_Request.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_Request.ManagedPeerType;

	public unsafe bool IsAnyResourceSet => _members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractBooleanMethod("isAnyResourceSet.()Z", this, null);

	public unsafe bool IsCleared => _members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractBooleanMethod("isCleared.()Z", this, null);

	public unsafe bool IsComplete => _members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractBooleanMethod("isComplete.()Z", this, null);

	public unsafe bool IsRunning => _members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractBooleanMethod("isRunning.()Z", this, null);

	public IRequestInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsAnyResourceSetHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAnyResourceSet);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAnyResourceSet(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAnyResourceSet ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsClearedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCleared);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCleared(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCleared ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsCompleteHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsComplete);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsComplete(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsComplete ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsRunningHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRunning);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRunning(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRunning ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetBeginHandler()
	{
		return new global::_JniMarshal_PP_V(n_Begin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Begin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Begin();
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

	public unsafe void Begin()
	{
		_members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractVoidMethod("begin.()V", this, null);
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	public unsafe void Clear()
	{
		_members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetIsEquivalentTo_Lcom_bumptech_glide_request_Request_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsEquivalentTo_Lcom_bumptech_glide_request_Request_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEquivalentTo_Lcom_bumptech_glide_request_Request_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IRequest? request = Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRequest p = Java.Lang.Object.GetObject<IRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
			return request.IsEquivalentTo(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool IsEquivalentTo(IRequest? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractBooleanMethod("isEquivalentTo.(Lcom/bumptech/glide/request/Request;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetPauseHandler()
	{
		return new global::_JniMarshal_PP_V(n_Pause);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Pause(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Pause();
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

	public unsafe void Pause()
	{
		_members_com_bumptech_glide_request_Request.InstanceMethods.InvokeAbstractVoidMethod("pause.()V", this, null);
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
