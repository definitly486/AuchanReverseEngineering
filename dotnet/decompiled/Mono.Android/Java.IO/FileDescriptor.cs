using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/FileDescriptor", DoNotGenerateAcw = true)]
public sealed class FileDescriptor : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/FileDescriptor", typeof(FileDescriptor));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal FileDescriptor(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
