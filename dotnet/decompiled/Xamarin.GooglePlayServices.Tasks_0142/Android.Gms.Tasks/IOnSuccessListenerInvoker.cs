using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnSuccessListener", DoNotGenerateAcw = true)]
internal class IOnSuccessListenerInvoker : Java.Lang.Object, IOnSuccessListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_OnSuccessListener = new XAPeerMembers("com/google/android/gms/tasks/OnSuccessListener", typeof(IOnSuccessListenerInvoker));

	private static Delegate? cb_onSuccess_OnSuccess_Ljava_lang_Object__V;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_OnSuccessListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_OnSuccessListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_OnSuccessListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_OnSuccessListener.ManagedPeerType;

	public IOnSuccessListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnSuccess_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSuccess_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnSuccessListener? onSuccessListener = Java.Lang.Object.GetObject<IOnSuccessListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			onSuccessListener.OnSuccess(result);
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

	public unsafe void OnSuccess(Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_google_android_gms_tasks_OnSuccessListener.InstanceMethods.InvokeAbstractVoidMethod("onSuccess.(Ljava/lang/Object;)V", this, ptr);
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
