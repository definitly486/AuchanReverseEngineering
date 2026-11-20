using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageCaptureException", DoNotGenerateAcw = true)]
public class ImageCaptureException : Java.Lang.Exception
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCaptureException", typeof(ImageCaptureException));

	private static Delegate? cb_getImageCaptureError;

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

	public unsafe virtual int ImageCaptureError
	{
		[Register("getImageCaptureError", "()I", "GetGetImageCaptureErrorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getImageCaptureError.()I", this, null);
		}
	}

	protected ImageCaptureException(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(ILjava/lang/String;Ljava/lang/Throwable;)V", "")]
	public unsafe ImageCaptureException(int imageCaptureError, string message, Throwable? cause)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(imageCaptureError);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cause);
		}
	}

	private static Delegate GetGetImageCaptureErrorHandler()
	{
		if ((object)cb_getImageCaptureError == null)
		{
			cb_getImageCaptureError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageCaptureError));
		}
		return cb_getImageCaptureError;
	}

	private static int n_GetImageCaptureError(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ImageCaptureException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureError;
	}
}
