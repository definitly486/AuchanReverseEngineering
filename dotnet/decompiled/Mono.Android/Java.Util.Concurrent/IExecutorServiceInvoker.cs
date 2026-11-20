using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/ExecutorService", DoNotGenerateAcw = true)]
internal class IExecutorServiceInvoker : Java.Lang.Object, IExecutorService, IExecutor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_concurrent_Executor = new XAPeerMembers("java/util/concurrent/Executor", typeof(IExecutorServiceInvoker));

	private static readonly JniPeerMembers _members_java_util_concurrent_ExecutorService = new XAPeerMembers("java/util/concurrent/ExecutorService", typeof(IExecutorServiceInvoker));

	private static Delegate? cb_isShutdown_IsShutdown_Z;

	private static Delegate? cb_isTerminated_IsTerminated_Z;

	private static Delegate? cb_awaitTermination_AwaitTermination_JLjava_util_concurrent_TimeUnit__Z;

	private static Delegate? cb_invokeAll_InvokeAll_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit__Ljava_util_List_;

	private static Delegate? cb_invokeAll_InvokeAll_Ljava_util_Collection__Ljava_util_List_;

	private static Delegate? cb_invokeAny_InvokeAny_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit__Ljava_lang_Object_;

	private static Delegate? cb_invokeAny_InvokeAny_Ljava_util_Collection__Ljava_lang_Object_;

	private static Delegate? cb_shutdown_Shutdown_V;

	private static Delegate? cb_shutdownNow_ShutdownNow_Ljava_util_List_;

	private static Delegate? cb_submit_Submit_Ljava_lang_Runnable_Ljava_lang_Object__Ljava_util_concurrent_Future_;

	private static Delegate? cb_submit_Submit_Ljava_lang_Runnable__Ljava_util_concurrent_Future_;

	private static Delegate? cb_submit_Submit_Ljava_util_concurrent_Callable__Ljava_util_concurrent_Future_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_concurrent_ExecutorService;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_concurrent_ExecutorService.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_concurrent_ExecutorService.ManagedPeerType;

	public unsafe bool IsShutdown => _members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractBooleanMethod("isShutdown.()Z", this, null);

	public unsafe bool IsTerminated => _members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractBooleanMethod("isTerminated.()Z", this, null);

	public IExecutorServiceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsShutdownHandler()
	{
		return new _JniMarshal_PP_B(n_IsShutdown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShutdown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShutdown ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTerminatedHandler()
	{
		return new _JniMarshal_PP_B(n_IsTerminated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTerminated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTerminated ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAwaitTermination_JLjava_util_concurrent_TimeUnit_Handler()
	{
		return new _JniMarshal_PPJL_B(n_AwaitTermination_JLjava_util_concurrent_TimeUnit_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AwaitTermination_JLjava_util_concurrent_TimeUnit_(nint jnienv, nint native__this, long timeout, nint native_unit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return executorService.AwaitTermination(timeout, unit) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool AwaitTermination(long timeout, TimeUnit? unit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(timeout);
			ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return _members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractBooleanMethod("awaitTermination.(JLjava/util/concurrent/TimeUnit;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(unit);
		}
	}

	private static Delegate GetInvokeAll_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_Handler()
	{
		return new _JniMarshal_PPLJL_L(n_InvokeAll_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvokeAll_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_(nint jnienv, nint native__this, nint native_tasks, long timeout, nint native_unit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection tasks = JavaCollection.FromJniHandle(native_tasks, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JavaList.ToLocalJniHandle(executorService.InvokeAll(tasks, timeout, unit));
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

	public unsafe System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit)
	{
		nint num = JavaCollection.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(timeout);
			ptr[2] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return JavaList.FromJniHandle(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("invokeAll.(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
			GC.KeepAlive(unit);
		}
	}

	private static Delegate GetInvokeAll_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_L(n_InvokeAll_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvokeAll_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_tasks)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection tasks = JavaCollection.FromJniHandle(native_tasks, JniHandleOwnership.DoNotTransfer);
			return JavaList.ToLocalJniHandle(executorService.InvokeAll(tasks));
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

	public unsafe System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks)
	{
		nint num = JavaCollection.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList.FromJniHandle(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("invokeAll.(Ljava/util/Collection;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
		}
	}

	private static Delegate GetInvokeAny_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_Handler()
	{
		return new _JniMarshal_PPLJL_L(n_InvokeAny_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvokeAny_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_(nint jnienv, nint native__this, nint native_tasks, long timeout, nint native_unit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection tasks = JavaCollection.FromJniHandle(native_tasks, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(executorService.InvokeAny(tasks, timeout, unit));
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

	public unsafe Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit)
	{
		nint num = JavaCollection.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(timeout);
			ptr[2] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("invokeAny.(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
			GC.KeepAlive(unit);
		}
	}

	private static Delegate GetInvokeAny_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_L(n_InvokeAny_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvokeAny_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_tasks)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection tasks = JavaCollection.FromJniHandle(native_tasks, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(executorService.InvokeAny(tasks));
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

	public unsafe Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks)
	{
		nint num = JavaCollection.ToLocalJniHandle(tasks);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("invokeAny.(Ljava/util/Collection;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tasks);
		}
	}

	private static Delegate GetShutdownHandler()
	{
		return new _JniMarshal_PP_V(n_Shutdown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Shutdown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Shutdown();
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

	public unsafe void Shutdown()
	{
		_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractVoidMethod("shutdown.()V", this, null);
	}

	private static Delegate GetShutdownNowHandler()
	{
		return new _JniMarshal_PP_L(n_ShutdownNow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ShutdownNow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IRunnable>.ToLocalJniHandle(Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShutdownNow());
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

	public unsafe IList<IRunnable>? ShutdownNow()
	{
		return JavaList<IRunnable>.FromJniHandle(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("shutdownNow.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSubmit_Ljava_lang_Runnable_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLL_L(n_Submit_Ljava_lang_Runnable_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Submit_Ljava_lang_Runnable_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_task, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable task = Java.Lang.Object.GetObject<IRunnable>(native_task, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(executorService.Submit(task, result));
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

	public unsafe IFuture? Submit(IRunnable? task, Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IFuture>(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/lang/Runnable;Ljava/lang/Object;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(task);
			GC.KeepAlive(result);
		}
	}

	private static Delegate GetSubmit_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_L(n_Submit_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Submit_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_task)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable task = Java.Lang.Object.GetObject<IRunnable>(native_task, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(executorService.Submit(task));
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

	public unsafe IFuture? Submit(IRunnable? task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			return Java.Lang.Object.GetObject<IFuture>(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(task);
		}
	}

	private static Delegate GetSubmit_Ljava_util_concurrent_Callable_Handler()
	{
		return new _JniMarshal_PPL_L(n_Submit_Ljava_util_concurrent_Callable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Submit_Ljava_util_concurrent_Callable_(nint jnienv, nint native__this, nint native_task)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IExecutorService? executorService = Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallable task = Java.Lang.Object.GetObject<ICallable>(native_task, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(executorService.Submit(task));
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

	public unsafe IFuture? Submit(ICallable? task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((task == null) ? IntPtr.Zero : ((Java.Lang.Object)task).Handle);
			return Java.Lang.Object.GetObject<IFuture>(_members_java_util_concurrent_ExecutorService.InstanceMethods.InvokeAbstractObjectMethod("submit.(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(task);
		}
	}

	public unsafe void Execute(IRunnable? command)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
			_members_java_util_concurrent_Executor.InstanceMethods.InvokeAbstractVoidMethod("execute.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(command);
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
