using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/Frame", DoNotGenerateAcw = true)]
public class Frame : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/Frame", typeof(Frame));

	private static Delegate? cb_getDuration_GetDuration_J;

	private static Delegate? cb_getImage_GetImage_Lcom_yandex_runtime_image_ImageProvider_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual long Duration
	{
		[Register("getDuration", "()J", "GetGetDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getDuration.()J", this, null);
		}
	}

	public unsafe virtual ImageProvider? Image
	{
		[Register("getImage", "()Lcom/yandex/runtime/image/ImageProvider;", "GetGetImageHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ImageProvider>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImage.()Lcom/yandex/runtime/image/ImageProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Frame(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/yandex/runtime/image/ImageProvider;J)V", "")]
	public unsafe Frame(ImageProvider? image, long duration)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(duration);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/runtime/image/ImageProvider;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/runtime/image/ImageProvider;J)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(image);
		}
	}

	private static Delegate GetGetDurationHandler()
	{
		if ((object)cb_getDuration_GetDuration_J == null)
		{
			cb_getDuration_GetDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetDuration));
		}
		return cb_getDuration_GetDuration_J;
	}

	private static long n_GetDuration(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Frame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
	}

	private static Delegate GetGetImageHandler()
	{
		if ((object)cb_getImage_GetImage_Lcom_yandex_runtime_image_ImageProvider_ == null)
		{
			cb_getImage_GetImage_Lcom_yandex_runtime_image_ImageProvider_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImage));
		}
		return cb_getImage_GetImage_Lcom_yandex_runtime_image_ImageProvider_;
	}

	private static nint n_GetImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Frame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Image);
	}
}
