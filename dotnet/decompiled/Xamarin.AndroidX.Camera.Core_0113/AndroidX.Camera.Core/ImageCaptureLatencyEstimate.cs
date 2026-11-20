using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageCaptureLatencyEstimate", DoNotGenerateAcw = true)]
public class ImageCaptureLatencyEstimate : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCaptureLatencyEstimate", typeof(ImageCaptureLatencyEstimate));

	private static Delegate? cb_getCaptureLatencyMillis;

	private static Delegate? cb_getProcessingLatencyMillis;

	private static Delegate? cb_getTotalCaptureLatencyMillis;

	[Register("UNDEFINED_IMAGE_CAPTURE_LATENCY")]
	public static ImageCaptureLatencyEstimate UndefinedImageCaptureLatency => Java.Lang.Object.GetObject<ImageCaptureLatencyEstimate>(_members.StaticFields.GetObjectValue("UNDEFINED_IMAGE_CAPTURE_LATENCY.Landroidx/camera/core/ImageCaptureLatencyEstimate;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe virtual long CaptureLatencyMillis
	{
		[Register("getCaptureLatencyMillis", "()J", "GetGetCaptureLatencyMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getCaptureLatencyMillis.()J", this, null);
		}
	}

	public unsafe virtual long ProcessingLatencyMillis
	{
		[Register("getProcessingLatencyMillis", "()J", "GetGetProcessingLatencyMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getProcessingLatencyMillis.()J", this, null);
		}
	}

	public unsafe virtual long TotalCaptureLatencyMillis
	{
		[Register("getTotalCaptureLatencyMillis", "()J", "GetGetTotalCaptureLatencyMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTotalCaptureLatencyMillis.()J", this, null);
		}
	}

	protected ImageCaptureLatencyEstimate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(JJ)V", "")]
	public unsafe ImageCaptureLatencyEstimate(long captureLatencyMillis, long processingLatencyMillis)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(captureLatencyMillis);
			ptr[1] = new JniArgumentValue(processingLatencyMillis);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JJ)V", this, ptr);
		}
	}

	private static Delegate GetGetCaptureLatencyMillisHandler()
	{
		if ((object)cb_getCaptureLatencyMillis == null)
		{
			cb_getCaptureLatencyMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCaptureLatencyMillis));
		}
		return cb_getCaptureLatencyMillis;
	}

	private static long n_GetCaptureLatencyMillis(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ImageCaptureLatencyEstimate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureLatencyMillis;
	}

	private static Delegate GetGetProcessingLatencyMillisHandler()
	{
		if ((object)cb_getProcessingLatencyMillis == null)
		{
			cb_getProcessingLatencyMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetProcessingLatencyMillis));
		}
		return cb_getProcessingLatencyMillis;
	}

	private static long n_GetProcessingLatencyMillis(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ImageCaptureLatencyEstimate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProcessingLatencyMillis;
	}

	private static Delegate GetGetTotalCaptureLatencyMillisHandler()
	{
		if ((object)cb_getTotalCaptureLatencyMillis == null)
		{
			cb_getTotalCaptureLatencyMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTotalCaptureLatencyMillis));
		}
		return cb_getTotalCaptureLatencyMillis;
	}

	private static long n_GetTotalCaptureLatencyMillis(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ImageCaptureLatencyEstimate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalCaptureLatencyMillis;
	}
}
