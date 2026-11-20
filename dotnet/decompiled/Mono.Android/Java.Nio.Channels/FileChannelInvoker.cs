using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Nio.Channels;

[Register("java/nio/channels/FileChannel", DoNotGenerateAcw = true)]
internal class FileChannelInvoker : FileChannel
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/channels/FileChannel", typeof(FileChannelInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FileChannelInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("position", "()J", "GetPositionHandler")]
	public unsafe override long Position()
	{
		return _members.InstanceMethods.InvokeAbstractInt64Method("position.()J", this, null);
	}

	[Register("position", "(J)Ljava/nio/channels/FileChannel;", "GetPosition_JHandler")]
	public unsafe override FileChannel? Position(long newPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(newPosition);
		return Java.Lang.Object.GetObject<FileChannel>(_members.InstanceMethods.InvokeAbstractObjectMethod("position.(J)Ljava/nio/channels/FileChannel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("size", "()J", "GetSizeHandler")]
	public unsafe override long Size()
	{
		return _members.InstanceMethods.InvokeAbstractInt64Method("size.()J", this, null);
	}
}
