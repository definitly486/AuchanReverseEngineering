using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/OutputStream", DoNotGenerateAcw = true)]
internal class OutputStreamInvoker : OutputStream
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/OutputStream", typeof(OutputStreamInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public OutputStreamInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Write(int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeAbstractVoidMethod("write.(I)V", this, ptr);
	}
}
