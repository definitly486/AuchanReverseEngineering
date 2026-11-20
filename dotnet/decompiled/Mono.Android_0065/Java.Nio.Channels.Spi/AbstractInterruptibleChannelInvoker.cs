using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Nio.Channels.Spi;

[Register("java/nio/channels/spi/AbstractInterruptibleChannel", DoNotGenerateAcw = true)]
internal class AbstractInterruptibleChannelInvoker : AbstractInterruptibleChannel
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/channels/spi/AbstractInterruptibleChannel", typeof(AbstractInterruptibleChannelInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AbstractInterruptibleChannelInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
