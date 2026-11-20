using System;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.ContextAware;

[Register("mono/androidx/activity/contextaware/OnContextAvailableListenerImplementor")]
internal sealed class IOnContextAvailableListenerImplementor : Java.Lang.Object, IOnContextAvailableListener, IJavaObject, IDisposable, IJavaPeerable
{
	private object? sender;

	public EventHandler<ContextAvailableEventArgs>? Handler;

	public unsafe IOnContextAvailableListenerImplementor(object sender)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			this.sender = sender;
		}
	}

	public void OnContextAvailable(Context context)
	{
		Handler?.Invoke(sender, new ContextAvailableEventArgs(context));
	}

	internal static bool __IsEmpty(IOnContextAvailableListenerImplementor value)
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
