using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ContextThemeWrapper", DoNotGenerateAcw = true)]
public class ContextThemeWrapper : ContextWrapper
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ContextThemeWrapper", typeof(ContextThemeWrapper));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ContextThemeWrapper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
