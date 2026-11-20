using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/InputStream", DoNotGenerateAcw = true)]
internal class InputStreamInvoker : InputStream
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/InputStream", typeof(InputStreamInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public InputStreamInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("read", "()I", "GetReadHandler")]
	public unsafe override int Read()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("read.()I", this, null);
	}
}
