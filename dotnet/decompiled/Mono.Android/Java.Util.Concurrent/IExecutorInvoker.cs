using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Executor", DoNotGenerateAcw = true)]
internal class IExecutorInvoker : Java.Lang.Object, IExecutor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_concurrent_Executor = new XAPeerMembers("java/util/concurrent/Executor", typeof(IExecutorInvoker));

	private static Delegate? cb_execute_Execute_Ljava_lang_Runnable__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_concurrent_Executor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_concurrent_Executor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_concurrent_Executor.ManagedPeerType;

	public IExecutorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetExecute_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_V(n_Execute_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Execute_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_command)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IExecutor? executor = Java.Lang.Object.GetObject<IExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable command = Java.Lang.Object.GetObject<IRunnable>(native_command, JniHandleOwnership.DoNotTransfer);
			executor.Execute(command);
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
