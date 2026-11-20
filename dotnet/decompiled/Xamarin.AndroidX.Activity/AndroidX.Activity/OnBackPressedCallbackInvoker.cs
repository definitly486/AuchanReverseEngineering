using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Activity;

[Register("androidx/activity/OnBackPressedCallback", DoNotGenerateAcw = true)]
internal class OnBackPressedCallbackInvoker : OnBackPressedCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedCallback", typeof(OnBackPressedCallbackInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public OnBackPressedCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("handleOnBackPressed", "()V", "GetHandleOnBackPressedHandler")]
	public unsafe override void HandleOnBackPressed()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("handleOnBackPressed.()V", this, null);
	}
}
