using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/DialogInterface", DoNotGenerateAcw = true)]
internal class IDialogInterfaceInvoker : Java.Lang.Object, IDialogInterface, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_DialogInterface = new XAPeerMembers("android/content/DialogInterface", typeof(IDialogInterfaceInvoker));

	private static Delegate? cb_cancel_Cancel_V;

	private static Delegate? cb_dismiss_Dismiss_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_DialogInterface;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_DialogInterface.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_DialogInterface.ManagedPeerType;

	public IDialogInterfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCancelHandler()
	{
		return new _JniMarshal_PP_V(n_Cancel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cancel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDialogInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
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

	public unsafe void Cancel()
	{
		_members_android_content_DialogInterface.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
	}

	private static Delegate GetDismissHandler()
	{
		return new _JniMarshal_PP_V(n_Dismiss);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dismiss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDialogInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
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

	public unsafe void Dismiss()
	{
		_members_android_content_DialogInterface.InstanceMethods.InvokeAbstractVoidMethod("dismiss.()V", this, null);
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
