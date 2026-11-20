using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/CompoundButton", DoNotGenerateAcw = true)]
internal class CompoundButtonInvoker : CompoundButton
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/CompoundButton", typeof(CompoundButtonInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CompoundButtonInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
