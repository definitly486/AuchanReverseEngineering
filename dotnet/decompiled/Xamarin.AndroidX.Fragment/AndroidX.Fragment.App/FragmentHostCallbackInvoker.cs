using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentHostCallback", DoNotGenerateAcw = true)]
internal class FragmentHostCallbackInvoker : FragmentHostCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentHostCallback", typeof(FragmentHostCallbackInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentHostCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onGetHost", "()Ljava/lang/Object;", "GetOnGetHostHandler")]
	public unsafe override Java.Lang.Object? OnGetHost()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("onGetHost.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
