using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnCompleteListener", DoNotGenerateAcw = true)]
internal class IOnCompleteListenerInvoker : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_OnCompleteListener = new XAPeerMembers("com/google/android/gms/tasks/OnCompleteListener", typeof(IOnCompleteListenerInvoker));

	private static Delegate? cb_onComplete_OnComplete_Lcom_google_android_gms_tasks_Task__V;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_OnCompleteListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_OnCompleteListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_OnCompleteListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_OnCompleteListener.ManagedPeerType;

	public IOnCompleteListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnComplete_Lcom_google_android_gms_tasks_Task_(nint jnienv, nint native__this, nint native_task)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnCompleteListener? onCompleteListener = Java.Lang.Object.GetObject<IOnCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Task task = Java.Lang.Object.GetObject<Task>(native_task, JniHandleOwnership.DoNotTransfer);
			onCompleteListener.OnComplete(task);
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

	public unsafe void OnComplete(Task task)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(task?.Handle ?? IntPtr.Zero);
			_members_com_google_android_gms_tasks_OnCompleteListener.InstanceMethods.InvokeAbstractVoidMethod("onComplete.(Lcom/google/android/gms/tasks/Task;)V", this, ptr);
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

	[UnmanagedCallersOnly]
	private static void n_OnComplete_Lcom_google_android_gms_tasks_Task__mm_wrapper(nint jnienv, nint native__this, nint native_task)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnComplete_Lcom_google_android_gms_tasks_Task_(jnienv, native__this, native_task);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
