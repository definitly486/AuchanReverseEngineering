using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/ClassLoader", DoNotGenerateAcw = true)]
public abstract class ClassLoader : Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/ClassLoader", typeof(ClassLoader));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ClassLoader(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
