using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("mono/androidx/fragment/app/FragmentOnAttachListenerImplementor")]
internal sealed class IFragmentOnAttachListenerImplementor : Java.Lang.Object, IFragmentOnAttachListener, IJavaObject, IDisposable, IJavaPeerable
{
	private object? sender;

	public EventHandler<FragmentOnAttachEventArgs>? Handler;

	public unsafe IFragmentOnAttachListenerImplementor(object sender)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			this.sender = sender;
		}
	}

	public void OnAttachFragment(FragmentManager p0, Fragment p1)
	{
		Handler?.Invoke(sender, new FragmentOnAttachEventArgs(p0, p1));
	}

	internal static bool __IsEmpty(IFragmentOnAttachListenerImplementor value)
	{
		return value.Handler == null;
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
