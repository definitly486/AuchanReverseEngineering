using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/Filter", DoNotGenerateAcw = true)]
internal class FilterInvoker : Filter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/Filter", typeof(FilterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FilterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
