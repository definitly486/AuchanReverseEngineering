using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("mono/android/content/DialogInterface_OnClickListenerImplementor")]
internal sealed class IDialogInterfaceOnClickListenerImplementor : Java.Lang.Object, IDialogInterfaceOnClickListener, IJavaObject, IDisposable, IJavaPeerable
{
	public EventHandler<DialogClickEventArgs>? Handler;

	public unsafe IDialogInterfaceOnClickListenerImplementor()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public void OnClick(IDialogInterface? dialog, int which)
	{
		Handler?.Invoke(dialog, new DialogClickEventArgs(which));
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
