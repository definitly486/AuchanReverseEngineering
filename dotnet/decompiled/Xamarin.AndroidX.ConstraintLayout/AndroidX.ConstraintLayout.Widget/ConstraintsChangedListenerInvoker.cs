using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintsChangedListener", DoNotGenerateAcw = true)]
internal class ConstraintsChangedListenerInvoker : ConstraintsChangedListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintsChangedListener", typeof(ConstraintsChangedListenerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ConstraintsChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
