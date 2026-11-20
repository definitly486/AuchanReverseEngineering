using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Database;

[Register("android/database/CharArrayBuffer", DoNotGenerateAcw = true)]
public sealed class CharArrayBuffer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/database/CharArrayBuffer", typeof(CharArrayBuffer));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal CharArrayBuffer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
