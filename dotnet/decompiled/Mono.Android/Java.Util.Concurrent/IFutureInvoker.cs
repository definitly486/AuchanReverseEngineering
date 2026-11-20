using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Future", DoNotGenerateAcw = true)]
internal class IFutureInvoker : Java.Lang.Object, IFuture, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_concurrent_Future = new XAPeerMembers("java/util/concurrent/Future", typeof(IFutureInvoker));

	private static Delegate? cb_isCancelled_IsCancelled_Z;

	private static Delegate? cb_isDone_IsDone_Z;

	private static Delegate? cb_cancel_Cancel_Z_Z;

	private static Delegate? cb_get_Get_Ljava_lang_Object_;

	private static Delegate? cb_get_Get_JLjava_util_concurrent_TimeUnit__Ljava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_concurrent_Future;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_concurrent_Future.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_concurrent_Future.ManagedPeerType;

	public unsafe bool IsCancelled => _members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractBooleanMethod("isCancelled.()Z", this, null);

	public unsafe bool IsDone => _members_java_util_concurrent_Future.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);

	public IFutureInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsCancelledHandler()
	{
		return new _JniMarshal_PP_B(n_IsCancelled);
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
			return Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancelled ? ((sbyte)1) : ((sbyte)0);
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
		return new _JniMarshal_PP_B(n_IsDone);
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
			return Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone ? ((sbyte)1) : ((sbyte)0);
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
		return new _JniMarshal_PPB_B(n_Cancel_Z);
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
			IFuture? future = Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool mayInterruptIfRunning = native_mayInterruptIfRunning != 0;
			return future.Cancel(mayInterruptIfRunning) ? ((sbyte)1) : ((sbyte)0);
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
		return new _JniMarshal_PP_L(n_Get);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
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
		return new _JniMarshal_PPJL_L(n_Get_JLjava_util_concurrent_TimeUnit_);
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
			IFuture? future = Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(future.Get(timeout, unit));
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
