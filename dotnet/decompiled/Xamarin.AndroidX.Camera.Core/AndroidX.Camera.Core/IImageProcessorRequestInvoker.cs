using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor$Request", DoNotGenerateAcw = true)]
internal class IImageProcessorRequestInvoker : Java.Lang.Object, IImageProcessorRequest, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProcessor$Request", typeof(IImageProcessorRequestInvoker));

	private nint class_ref;

	private static Delegate? cb_getInputImage;

	private nint id_getInputImage;

	private static Delegate? cb_getOutputFormat;

	private nint id_getOutputFormat;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public IImageProxy InputImage
	{
		get
		{
			if (id_getInputImage == IntPtr.Zero)
			{
				id_getInputImage = JNIEnv.GetMethodID(class_ref, "getInputImage", "()Landroidx/camera/core/ImageProxy;");
			}
			return Java.Lang.Object.GetObject<IImageProxy>(JNIEnv.CallObjectMethod(base.Handle, id_getInputImage), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int OutputFormat
	{
		get
		{
			if (id_getOutputFormat == IntPtr.Zero)
			{
				id_getOutputFormat = JNIEnv.GetMethodID(class_ref, "getOutputFormat", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getOutputFormat);
		}
	}

	public static IImageProcessorRequest? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageProcessorRequest>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageProcessor.Request'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public IImageProcessorRequestInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetInputImageHandler()
	{
		if ((object)cb_getInputImage == null)
		{
			cb_getInputImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInputImage));
		}
		return cb_getInputImage;
	}

	private static nint n_GetInputImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProcessorRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputImage);
	}

	private static Delegate GetGetOutputFormatHandler()
	{
		if ((object)cb_getOutputFormat == null)
		{
			cb_getOutputFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOutputFormat));
		}
		return cb_getOutputFormat;
	}

	private static int n_GetOutputFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageProcessorRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputFormat;
	}
}
