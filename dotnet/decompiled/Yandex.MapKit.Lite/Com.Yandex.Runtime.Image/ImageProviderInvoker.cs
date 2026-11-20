using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/ImageProvider", DoNotGenerateAcw = true)]
internal class ImageProviderInvoker : ImageProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/ImageProvider", typeof(ImageProviderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Bitmap? Image
	{
		[Register("getImage", "()Landroid/graphics/Bitmap;", "GetGetImageHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImage.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public ImageProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
