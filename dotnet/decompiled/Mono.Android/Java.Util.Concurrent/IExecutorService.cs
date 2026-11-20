using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/ExecutorService", "", "Java.Util.Concurrent.IExecutorServiceInvoker")]
public interface IExecutorService : IExecutor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/concurrent/ExecutorService", typeof(IExecutorService), isInterface: true);

	private static Delegate? cb_close_Close_V;

	bool IsShutdown
	{
		[Register("isShutdown", "()Z", "GetIsShutdownHandler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsTerminated
	{
		[Register("isTerminated", "()Z", "GetIsTerminatedHandler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("awaitTermination", "(JLjava/util/concurrent/TimeUnit;)Z", "GetAwaitTermination_JLjava_util_concurrent_TimeUnit_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool AwaitTermination(long timeout, TimeUnit? unit);

	[Register("invokeAll", "(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/util/List;", "GetInvokeAll_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit);

	[Register("invokeAll", "(Ljava/util/Collection;)Ljava/util/List;", "GetInvokeAll_Ljava_util_Collection_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks);

	[Register("invokeAny", "(Ljava/util/Collection;JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", "GetInvokeAny_Ljava_util_Collection_JLjava_util_concurrent_TimeUnit_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit);

	[Register("invokeAny", "(Ljava/util/Collection;)Ljava/lang/Object;", "GetInvokeAny_Ljava_util_Collection_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks);

	[Register("shutdown", "()V", "GetShutdownHandler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Shutdown();

	[Register("shutdownNow", "()Ljava/util/List;", "GetShutdownNowHandler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IList<IRunnable>? ShutdownNow();

	[Register("submit", "(Ljava/lang/Runnable;Ljava/lang/Object;)Ljava/util/concurrent/Future;", "GetSubmit_Ljava_lang_Runnable_Ljava_lang_Object_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	IFuture? Submit(IRunnable? task, Java.Lang.Object? result);

	[Register("submit", "(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;", "GetSubmit_Ljava_lang_Runnable_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IFuture? Submit(IRunnable? task);

	[Register("submit", "(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;", "GetSubmit_Ljava_util_concurrent_Callable_Handler:Java.Util.Concurrent.IExecutorServiceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	IFuture? Submit(ICallable? task);

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IExecutorService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[SupportedOSPlatform("android36.0")]
	[Register("close", "()V", "GetCloseHandler:Java.Util.Concurrent.IExecutorService, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}
}
