using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text.Style;

[Register("android/text/style/DynamicDrawableSpan", DoNotGenerateAcw = true)]
public abstract class DynamicDrawableSpan : ReplacementSpan
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/DynamicDrawableSpan", typeof(DynamicDrawableSpan));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected DynamicDrawableSpan(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
