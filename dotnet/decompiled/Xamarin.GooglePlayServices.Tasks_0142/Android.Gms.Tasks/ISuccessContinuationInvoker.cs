using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/SuccessContinuation", DoNotGenerateAcw = true)]
internal class ISuccessContinuationInvoker : Java.Lang.Object, ISuccessContinuation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_SuccessContinuation = new XAPeerMembers("com/google/android/gms/tasks/SuccessContinuation", typeof(ISuccessContinuationInvoker));

	private static Delegate? cb_then_Then_Ljava_lang_Object__Lcom_google_android_gms_tasks_Task_;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_SuccessContinuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_SuccessContinuation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_SuccessContinuation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_SuccessContinuation.ManagedPeerType;

	public ISuccessContinuationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetThen_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Then_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Then_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISuccessContinuation? successContinuation = Java.Lang.Object.GetObject<ISuccessContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(successContinuation.Then(result));
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

	public unsafe Task Then(Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Task>(_members_com_google_android_gms_tasks_SuccessContinuation.InstanceMethods.InvokeAbstractObjectMethod("then.(Ljava/lang/Object;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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
