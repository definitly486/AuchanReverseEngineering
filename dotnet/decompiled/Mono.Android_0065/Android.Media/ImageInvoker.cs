using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Media;

[Register("android/media/Image", DoNotGenerateAcw = true)]
internal class ImageInvoker : Image
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/media/Image", typeof(ImageInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ImageInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void Close()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}
}
