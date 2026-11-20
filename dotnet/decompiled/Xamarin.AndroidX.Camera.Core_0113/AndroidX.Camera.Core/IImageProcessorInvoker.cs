using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor", DoNotGenerateAcw = true)]
internal class IImageProcessorInvoker : Java.Lang.Object, IImageProcessor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProcessor", typeof(IImageProcessorInvoker));

	private nint class_ref;

	private static Delegate? cb_process_Landroidx_camera_core_ImageProcessor_Request_;

	private nint id_process_Landroidx_camera_core_ImageProcessor_Request_;

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

	public static IImageProcessor? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageProcessor>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageProcessor'.");
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

	public IImageProcessorInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetProcess_Landroidx_camera_core_ImageProcessor_Request_Handler()
	{
		if ((object)cb_process_Landroidx_camera_core_ImageProcessor_Request_ == null)
		{
			cb_process_Landroidx_camera_core_ImageProcessor_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Process_Landroidx_camera_core_ImageProcessor_Request_));
		}
		return cb_process_Landroidx_camera_core_ImageProcessor_Request_;
	}

	private static nint n_Process_Landroidx_camera_core_ImageProcessor_Request_(nint jnienv, nint native__this, nint native_p0)
	{
		IImageProcessor? imageProcessor = Java.Lang.Object.GetObject<IImageProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IImageProcessorRequest p = Java.Lang.Object.GetObject<IImageProcessorRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(imageProcessor.Process(p));
	}

	public unsafe IImageProcessorResponse Process(IImageProcessorRequest p0)
	{
		if (id_process_Landroidx_camera_core_ImageProcessor_Request_ == IntPtr.Zero)
		{
			id_process_Landroidx_camera_core_ImageProcessor_Request_ = JNIEnv.GetMethodID(class_ref, "process", "(Landroidx/camera/core/ImageProcessor$Request;)Landroidx/camera/core/ImageProcessor$Response;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		return Java.Lang.Object.GetObject<IImageProcessorResponse>(JNIEnv.CallObjectMethod(base.Handle, id_process_Landroidx_camera_core_ImageProcessor_Request_, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
