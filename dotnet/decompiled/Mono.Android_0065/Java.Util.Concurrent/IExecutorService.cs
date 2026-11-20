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

	bool IsShutdown { get; }

	bool IsTerminated { get; }

	bool AwaitTermination(long timeout, TimeUnit? unit);

	[JavaTypeParameters(new string[] { "T" })]
	System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit);

	[JavaTypeParameters(new string[] { "T" })]
	System.Collections.IList? InvokeAll(System.Collections.ICollection? tasks);

	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks, long timeout, TimeUnit? unit);

	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? InvokeAny(System.Collections.ICollection? tasks);

	void Shutdown();

	IList<IRunnable>? ShutdownNow();

	[JavaTypeParameters(new string[] { "T" })]
	IFuture? Submit(IRunnable? task, Java.Lang.Object? result);

	IFuture? Submit(IRunnable? task);

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
	unsafe void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}
}
