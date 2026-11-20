using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/AnimatedImageProvider", DoNotGenerateAcw = true)]
internal class AnimatedImageProviderInvoker : AnimatedImageProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/AnimatedImageProvider", typeof(AnimatedImageProviderInvoker));

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

	public unsafe override Java.Lang.Object? Image
	{
		[Register("getImage", "()Ljava/lang/Object;", "GetGetImageHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImage.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public AnimatedImageProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
