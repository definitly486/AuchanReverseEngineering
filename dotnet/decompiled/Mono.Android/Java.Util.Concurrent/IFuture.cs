using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Future", "", "Java.Util.Concurrent.IFutureInvoker")]
[JavaTypeParameters(new string[] { "V" })]
public interface IFuture : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android36.0")]
	[Register("java/util/concurrent/Future$State", DoNotGenerateAcw = true, ApiSince = 36)]
	public sealed class State : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/concurrent/Future$State", typeof(State));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal State(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/concurrent/Future", typeof(IFuture), isInterface: true);

	private static Delegate? cb_exceptionNow_ExceptionNow_Ljava_lang_Throwable_;

	private static Delegate? cb_resultNow_ResultNow_Ljava_lang_Object_;

	private static Delegate? cb_state_InvokeState_Ljava_util_concurrent_Future_State_;

	bool IsCancelled
	{
		[Register("isCancelled", "()Z", "GetIsCancelledHandler:Java.Util.Concurrent.IFutureInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsDone
	{
		[Register("isDone", "()Z", "GetIsDoneHandler:Java.Util.Concurrent.IFutureInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("cancel", "(Z)Z", "GetCancel_ZHandler:Java.Util.Concurrent.IFutureInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Cancel(bool mayInterruptIfRunning);

	[Register("get", "()Ljava/lang/Object;", "GetGetHandler:Java.Util.Concurrent.IFutureInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? Get();

	[Register("get", "(JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;", "GetGet_JLjava_util_concurrent_TimeUnit_Handler:Java.Util.Concurrent.IFutureInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? Get(long timeout, TimeUnit? unit);

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetExceptionNowHandler()
	{
		return new _JniMarshal_PP_L(n_ExceptionNow);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ExceptionNow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExceptionNow());
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

	[SupportedOSPlatform("android36.0")]
	[Register("exceptionNow", "()Ljava/lang/Throwable;", "GetExceptionNowHandler:Java.Util.Concurrent.IFuture, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe Throwable? ExceptionNow()
	{
		return Java.Lang.Object.GetObject<Throwable>(_members.InstanceMethods.InvokeVirtualObjectMethod("exceptionNow.()Ljava/lang/Throwable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetResultNowHandler()
	{
		return new _JniMarshal_PP_L(n_ResultNow);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ResultNow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResultNow());
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

	[SupportedOSPlatform("android36.0")]
	[Register("resultNow", "()Ljava/lang/Object;", "GetResultNowHandler:Java.Util.Concurrent.IFuture, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe Java.Lang.Object? ResultNow()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("resultNow.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android36.0")]
	private static Delegate GetInvokeStateHandler()
	{
		return new _JniMarshal_PP_L(n_InvokeState);
	}

	[SupportedOSPlatform("android36.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InvokeState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeState());
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

	[SupportedOSPlatform("android36.0")]
	[Register("state", "()Ljava/util/concurrent/Future$State;", "GetInvokeStateHandler:Java.Util.Concurrent.IFuture, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 36)]
	unsafe State? InvokeState()
	{
		return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeVirtualObjectMethod("state.()Ljava/util/concurrent/Future$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
