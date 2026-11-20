using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/Pair", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "F", "S" })]
public class Pair : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/Pair", typeof(Pair));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Pair(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
