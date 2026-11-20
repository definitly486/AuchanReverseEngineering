using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor$Response", DoNotGenerateAcw = true)]
internal class IImageProcessorResponseInvoker : Java.Lang.Object, IImageProcessorResponse, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProcessor$Response", typeof(IImageProcessorResponseInvoker));

	private nint class_ref;

	private static Delegate? cb_getOutputImage;

	private nint id_getOutputImage;

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

	public IImageProxy OutputImage
	{
		get
		{
			if (id_getOutputImage == IntPtr.Zero)
			{
				id_getOutputImage = JNIEnv.GetMethodID(class_ref, "getOutputImage", "()Landroidx/camera/core/ImageProxy;");
			}
			return Java.Lang.Object.GetObject<IImageProxy>(JNIEnv.CallObjectMethod(base.Handle, id_getOutputImage), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IImageProcessorResponse? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageProcessorResponse>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageProcessor.Response'.");
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

	public IImageProcessorResponseInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetOutputImageHandler()
	{
		if ((object)cb_getOutputImage == null)
		{
			cb_getOutputImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOutputImage));
		}
		return cb_getOutputImage;
	}

	private static nint n_GetOutputImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProcessorResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputImage);
	}
}
