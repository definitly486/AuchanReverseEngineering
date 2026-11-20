using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintHelper", DoNotGenerateAcw = true)]
internal class ConstraintHelperInvoker : ConstraintHelper
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintHelper", typeof(ConstraintHelperInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ConstraintHelperInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
