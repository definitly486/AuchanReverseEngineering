using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Obsolete("This class is obsoleted in this android platform")]
[Register("android/text/ClipboardManager", DoNotGenerateAcw = true)]
public abstract class ClipboardManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/ClipboardManager", typeof(ClipboardManager));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ClipboardManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
