using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/Reader", DoNotGenerateAcw = true)]
internal class ReaderInvoker : Reader
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/Reader", typeof(ReaderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ReaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Close()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}
}
