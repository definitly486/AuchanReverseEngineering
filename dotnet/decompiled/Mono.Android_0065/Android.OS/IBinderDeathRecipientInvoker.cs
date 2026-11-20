using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/IBinder$DeathRecipient", DoNotGenerateAcw = true)]
internal class IBinderDeathRecipientInvoker : Java.Lang.Object, IBinderDeathRecipient, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_os_IBinder_DeathRecipient = new XAPeerMembers("android/os/IBinder$DeathRecipient", typeof(IBinderDeathRecipientInvoker));

	private static Delegate? cb_binderDied_BinderDied_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_os_IBinder_DeathRecipient;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_os_IBinder_DeathRecipient.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_os_IBinder_DeathRecipient.ManagedPeerType;

	public IBinderDeathRecipientInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBinderDiedHandler()
	{
		return new _JniMarshal_PP_V(n_BinderDied);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BinderDied(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IBinderDeathRecipient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BinderDied();
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

	public unsafe void BinderDied()
	{
		_members_android_os_IBinder_DeathRecipient.InstanceMethods.InvokeAbstractVoidMethod("binderDied.()V", this, null);
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
