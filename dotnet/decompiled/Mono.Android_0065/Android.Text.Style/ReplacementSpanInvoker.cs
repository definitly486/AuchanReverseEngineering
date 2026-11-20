using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text.Style;

[Register("android/text/style/ReplacementSpan", DoNotGenerateAcw = true)]
internal class ReplacementSpanInvoker : ReplacementSpan
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/ReplacementSpan", typeof(ReplacementSpanInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ReplacementSpanInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
