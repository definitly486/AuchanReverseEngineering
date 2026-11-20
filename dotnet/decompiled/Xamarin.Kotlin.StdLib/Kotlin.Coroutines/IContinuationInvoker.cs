using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Coroutines;

[Register("kotlin/coroutines/Continuation", DoNotGenerateAcw = true)]
internal class IContinuationInvoker : Java.Lang.Object, IContinuation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_coroutines_Continuation = new XAPeerMembers("kotlin/coroutines/Continuation", typeof(IContinuationInvoker));

	private static Delegate? cb_getContext_GetContext_Lkotlin_coroutines_CoroutineContext_;

	private static Delegate? cb_resumeWith_ResumeWith_Ljava_lang_Object__V;

	private static nint java_class_ref => _members_kotlin_coroutines_Continuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_coroutines_Continuation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_coroutines_Continuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_coroutines_Continuation.ManagedPeerType;

	public unsafe ICoroutineContext Context => Java.Lang.Object.GetObject<ICoroutineContext>(_members_kotlin_coroutines_Continuation.InstanceMethods.InvokeAbstractObjectMethod("getContext.()Lkotlin/coroutines/CoroutineContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IContinuationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetResumeWith_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ResumeWith_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResumeWith_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContinuation? continuation = Java.Lang.Object.GetObject<IContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			continuation.ResumeWith(result);
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

	public unsafe void ResumeWith(Java.Lang.Object result)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			_members_kotlin_coroutines_Continuation.InstanceMethods.InvokeAbstractVoidMethod("resumeWith.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(result);
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
