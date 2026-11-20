using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/IInterface", DoNotGenerateAcw = true)]
internal class IInterfaceInvoker : Java.Lang.Object, IInterface, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_os_IInterface = new XAPeerMembers("android/os/IInterface", typeof(IInterfaceInvoker));

	private static Delegate? cb_asBinder_AsBinder_Landroid_os_IBinder_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_os_IInterface;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_os_IInterface.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_os_IInterface.ManagedPeerType;

	public IInterfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAsBinderHandler()
	{
		return new _JniMarshal_PP_L(n_AsBinder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AsBinder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBinder());
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

	public unsafe IBinder? AsBinder()
	{
		return Java.Lang.Object.GetObject<IBinder>(_members_android_os_IInterface.InstanceMethods.InvokeAbstractObjectMethod("asBinder.()Landroid/os/IBinder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
