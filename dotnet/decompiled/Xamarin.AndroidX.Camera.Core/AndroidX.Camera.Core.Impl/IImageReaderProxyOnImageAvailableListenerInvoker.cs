using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageReaderProxy$OnImageAvailableListener", DoNotGenerateAcw = true)]
internal class IImageReaderProxyOnImageAvailableListenerInvoker : Java.Lang.Object, IImageReaderProxyOnImageAvailableListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ImageReaderProxy$OnImageAvailableListener", typeof(IImageReaderProxyOnImageAvailableListenerInvoker));

	private nint class_ref;

	private static Delegate? cb_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_;

	private nint id_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_;

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

	public static IImageReaderProxyOnImageAvailableListener? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxyOnImageAvailableListener>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.ImageReaderProxy.OnImageAvailableListener'.");
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

	public IImageReaderProxyOnImageAvailableListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_Handler()
	{
		if ((object)cb_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_ == null)
		{
			cb_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_));
		}
		return cb_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_;
	}

	private static void n_OnImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_(nint jnienv, nint native__this, nint native_p0)
	{
		IImageReaderProxyOnImageAvailableListener? imageReaderProxyOnImageAvailableListener = Java.Lang.Object.GetObject<IImageReaderProxyOnImageAvailableListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IImageReaderProxy p = Java.Lang.Object.GetObject<IImageReaderProxy>(native_p0, JniHandleOwnership.DoNotTransfer);
		imageReaderProxyOnImageAvailableListener.OnImageAvailable(p);
	}

	public unsafe void OnImageAvailable(IImageReaderProxy p0)
	{
		if (id_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_ == IntPtr.Zero)
		{
			id_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_ = JNIEnv.GetMethodID(class_ref, "onImageAvailable", "(Landroidx/camera/core/impl/ImageReaderProxy;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_onImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_, ptr);
	}
}
