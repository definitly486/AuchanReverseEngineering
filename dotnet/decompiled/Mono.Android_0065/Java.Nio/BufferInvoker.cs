using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Nio;

[Register("java/nio/Buffer", DoNotGenerateAcw = true)]
internal class BufferInvoker : Buffer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/Buffer", typeof(BufferInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public BufferInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
