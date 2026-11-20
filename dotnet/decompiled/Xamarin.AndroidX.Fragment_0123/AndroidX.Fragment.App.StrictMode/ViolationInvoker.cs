using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Fragment.App.StrictMode;

[Register("androidx/fragment/app/strictmode/Violation", DoNotGenerateAcw = true)]
internal class ViolationInvoker : Violation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/strictmode/Violation", typeof(ViolationInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViolationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
