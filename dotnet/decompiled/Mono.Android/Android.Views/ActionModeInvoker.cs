using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ActionMode", DoNotGenerateAcw = true)]
internal class ActionModeInvoker : ActionMode
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ActionMode", typeof(ActionModeInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ActionModeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
