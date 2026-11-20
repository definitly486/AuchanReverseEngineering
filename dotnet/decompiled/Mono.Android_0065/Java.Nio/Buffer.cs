using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Nio;

[Register("java/nio/Buffer", DoNotGenerateAcw = true)]
public abstract class Buffer : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/Buffer", typeof(Buffer));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Buffer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
