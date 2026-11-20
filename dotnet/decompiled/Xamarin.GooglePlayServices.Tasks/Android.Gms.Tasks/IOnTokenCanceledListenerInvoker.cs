using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnTokenCanceledListener", DoNotGenerateAcw = true)]
internal class IOnTokenCanceledListenerInvoker : Java.Lang.Object, IOnTokenCanceledListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_gms_tasks_OnTokenCanceledListener = new XAPeerMembers("com/google/android/gms/tasks/OnTokenCanceledListener", typeof(IOnTokenCanceledListenerInvoker));

	private static Delegate? cb_onCanceled_OnCanceled_V;

	private static nint java_class_ref => _members_com_google_android_gms_tasks_OnTokenCanceledListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_gms_tasks_OnTokenCanceledListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_gms_tasks_OnTokenCanceledListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_gms_tasks_OnTokenCanceledListener.ManagedPeerType;

	public IOnTokenCanceledListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnCanceledHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnCanceled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCanceled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IOnTokenCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCanceled();
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

	public unsafe void OnCanceled()
	{
		_members_com_google_android_gms_tasks_OnTokenCanceledListener.InstanceMethods.InvokeAbstractVoidMethod("onCanceled.()V", this, null);
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
