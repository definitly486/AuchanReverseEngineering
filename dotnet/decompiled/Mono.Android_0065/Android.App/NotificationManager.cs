using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/NotificationManager", DoNotGenerateAcw = true)]
public class NotificationManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/NotificationManager", typeof(NotificationManager));

	private static Delegate? cb_cancelAll_CancelAll_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected NotificationManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetCancelAllHandler()
	{
		return new _JniMarshal_PP_V(n_CancelAll);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CancelAll(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NotificationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelAll();
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

	public unsafe virtual void CancelAll()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cancelAll.()V", this, null);
	}
}
