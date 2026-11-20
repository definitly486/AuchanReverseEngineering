using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views.Accessibility;

[Register("android/view/accessibility/AccessibilityRecord", DoNotGenerateAcw = true)]
public class AccessibilityRecord : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/accessibility/AccessibilityRecord", typeof(AccessibilityRecord));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AccessibilityRecord(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
