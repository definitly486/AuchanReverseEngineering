using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/FileDescriptorOutputOptions", DoNotGenerateAcw = true)]
public sealed class FileDescriptorOutputOptions : OutputOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/FileDescriptorOutputOptions", typeof(FileDescriptorOutputOptions));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe ParcelFileDescriptor ParcelFileDescriptor
	{
		[Register("getParcelFileDescriptor", "()Landroid/os/ParcelFileDescriptor;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ParcelFileDescriptor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getParcelFileDescriptor.()Landroid/os/ParcelFileDescriptor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal FileDescriptorOutputOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
