using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ActionProvider", DoNotGenerateAcw = true)]
internal class ActionProviderInvoker : ActionProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ActionProvider", typeof(ActionProviderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ActionProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
