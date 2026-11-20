using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnFailureListener", DoNotGenerateAcw = true)]
internal class IOnFailureListenerInvoker : Java.Lang.Object, IOnFailureListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_OnFailureListener = new XAPeerMembers("com/google/android/gms/tasks/OnFailureListener", typeof(IOnFailureListenerInvoker));

	private static Delegate? cb_onFailure_OnFailure_Ljava_lang_Exception__V;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_OnFailureListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_OnFailureListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_OnFailureListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_OnFailureListener.ManagedPeerType;

	public IOnFailureListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnFailure_Ljava_lang_Exception_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnFailure_Ljava_lang_Exception_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFailure_Ljava_lang_Exception_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnFailureListener? onFailureListener = Java.Lang.Object.GetObject<IOnFailureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			onFailureListener.OnFailure(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void OnFailure(Java.Lang.Exception e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members_com_google_android_gms_tasks_OnFailureListener.InstanceMethods.InvokeAbstractVoidMethod("onFailure.(Ljava/lang/Exception;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
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
