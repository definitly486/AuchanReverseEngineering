using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/Continuation", DoNotGenerateAcw = true)]
internal class IContinuationInvoker : Java.Lang.Object, IContinuation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_Continuation = new XAPeerMembers("com/google/android/gms/tasks/Continuation", typeof(IContinuationInvoker));

	private static Delegate? cb_then_Then_Lcom_google_android_gms_tasks_Task__Ljava_lang_Object_;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_Continuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_Continuation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_Continuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_Continuation.ManagedPeerType;

	public IContinuationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetThen_Lcom_google_android_gms_tasks_Task_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Then_Lcom_google_android_gms_tasks_Task_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Then_Lcom_google_android_gms_tasks_Task_(nint jnienv, nint native__this, nint native_task)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IContinuation? continuation = Java.Lang.Object.GetObject<IContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Task task = Java.Lang.Object.GetObject<Task>(native_task, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(continuation.Then(task));
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

	public unsafe Java.Lang.Object? Then(Task task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(task?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_google_android_gms_tasks_Continuation.InstanceMethods.InvokeAbstractObjectMethod("then.(Lcom/google/android/gms/tasks/Task;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(task);
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
