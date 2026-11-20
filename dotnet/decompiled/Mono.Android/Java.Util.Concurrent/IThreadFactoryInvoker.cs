using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/ThreadFactory", DoNotGenerateAcw = true)]
internal class IThreadFactoryInvoker : Java.Lang.Object, IThreadFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_concurrent_ThreadFactory = new XAPeerMembers("java/util/concurrent/ThreadFactory", typeof(IThreadFactoryInvoker));

	private static Delegate? cb_newThread_NewThread_Ljava_lang_Runnable__Ljava_lang_Thread_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_concurrent_ThreadFactory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_concurrent_ThreadFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_concurrent_ThreadFactory.ManagedPeerType;

	public IThreadFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetNewThread_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_L(n_NewThread_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewThread_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_r)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IThreadFactory? threadFactory = Java.Lang.Object.GetObject<IThreadFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable r = Java.Lang.Object.GetObject<IRunnable>(native_r, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadFactory.NewThread(r));
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

	public unsafe Thread? NewThread(IRunnable? r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((r == null) ? IntPtr.Zero : ((Java.Lang.Object)r).Handle);
			return Java.Lang.Object.GetObject<Thread>(_members_java_util_concurrent_ThreadFactory.InstanceMethods.InvokeAbstractObjectMethod("newThread.(Ljava/lang/Runnable;)Ljava/lang/Thread;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(r);
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
