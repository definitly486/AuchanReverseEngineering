using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageReaderProxy", DoNotGenerateAcw = true)]
internal class IImageReaderProxyInvoker : Java.Lang.Object, IImageReaderProxy, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ImageReaderProxy", typeof(IImageReaderProxyInvoker));

	private nint class_ref;

	private static Delegate? cb_getHeight;

	private nint id_getHeight;

	private static Delegate? cb_getImageFormat;

	private nint id_getImageFormat;

	private static Delegate? cb_getMaxImages;

	private nint id_getMaxImages;

	private static Delegate? cb_getSurface;

	private nint id_getSurface;

	private static Delegate? cb_getWidth;

	private nint id_getWidth;

	private static Delegate? cb_acquireLatestImage;

	private nint id_acquireLatestImage;

	private static Delegate? cb_acquireNextImage;

	private nint id_acquireNextImage;

	private static Delegate? cb_clearOnImageAvailableListener;

	private nint id_clearOnImageAvailableListener;

	private static Delegate? cb_close;

	private nint id_close;

	private static Delegate? cb_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_;

	private nint id_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_;

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

	public int Height
	{
		get
		{
			if (id_getHeight == IntPtr.Zero)
			{
				id_getHeight = JNIEnv.GetMethodID(class_ref, "getHeight", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getHeight);
		}
	}

	public int ImageFormat
	{
		get
		{
			if (id_getImageFormat == IntPtr.Zero)
			{
				id_getImageFormat = JNIEnv.GetMethodID(class_ref, "getImageFormat", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getImageFormat);
		}
	}

	public int MaxImages
	{
		get
		{
			if (id_getMaxImages == IntPtr.Zero)
			{
				id_getMaxImages = JNIEnv.GetMethodID(class_ref, "getMaxImages", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getMaxImages);
		}
	}

	public Surface? Surface
	{
		get
		{
			if (id_getSurface == IntPtr.Zero)
			{
				id_getSurface = JNIEnv.GetMethodID(class_ref, "getSurface", "()Landroid/view/Surface;");
			}
			return Java.Lang.Object.GetObject<Surface>(JNIEnv.CallObjectMethod(base.Handle, id_getSurface), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int Width
	{
		get
		{
			if (id_getWidth == IntPtr.Zero)
			{
				id_getWidth = JNIEnv.GetMethodID(class_ref, "getWidth", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getWidth);
		}
	}

	public static IImageReaderProxy? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxy>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.ImageReaderProxy'.");
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

	public IImageReaderProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetHeightHandler()
	{
		if ((object)cb_getHeight == null)
		{
			cb_getHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHeight));
		}
		return cb_getHeight;
	}

	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
	}

	private static Delegate GetGetImageFormatHandler()
	{
		if ((object)cb_getImageFormat == null)
		{
			cb_getImageFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageFormat));
		}
		return cb_getImageFormat;
	}

	private static int n_GetImageFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageFormat;
	}

	private static Delegate GetGetMaxImagesHandler()
	{
		if ((object)cb_getMaxImages == null)
		{
			cb_getMaxImages = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxImages));
		}
		return cb_getMaxImages;
	}

	private static int n_GetMaxImages(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxImages;
	}

	private static Delegate GetGetSurfaceHandler()
	{
		if ((object)cb_getSurface == null)
		{
			cb_getSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurface));
		}
		return cb_getSurface;
	}

	private static nint n_GetSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Surface);
	}

	private static Delegate GetGetWidthHandler()
	{
		if ((object)cb_getWidth == null)
		{
			cb_getWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetWidth));
		}
		return cb_getWidth;
	}

	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
	}

	private static Delegate GetAcquireLatestImageHandler()
	{
		if ((object)cb_acquireLatestImage == null)
		{
			cb_acquireLatestImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AcquireLatestImage));
		}
		return cb_acquireLatestImage;
	}

	private static nint n_AcquireLatestImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AcquireLatestImage());
	}

	public IImageProxy? AcquireLatestImage()
	{
		if (id_acquireLatestImage == IntPtr.Zero)
		{
			id_acquireLatestImage = JNIEnv.GetMethodID(class_ref, "acquireLatestImage", "()Landroidx/camera/core/ImageProxy;");
		}
		return Java.Lang.Object.GetObject<IImageProxy>(JNIEnv.CallObjectMethod(base.Handle, id_acquireLatestImage), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAcquireNextImageHandler()
	{
		if ((object)cb_acquireNextImage == null)
		{
			cb_acquireNextImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AcquireNextImage));
		}
		return cb_acquireNextImage;
	}

	private static nint n_AcquireNextImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AcquireNextImage());
	}

	public IImageProxy? AcquireNextImage()
	{
		if (id_acquireNextImage == IntPtr.Zero)
		{
			id_acquireNextImage = JNIEnv.GetMethodID(class_ref, "acquireNextImage", "()Landroidx/camera/core/ImageProxy;");
		}
		return Java.Lang.Object.GetObject<IImageProxy>(JNIEnv.CallObjectMethod(base.Handle, id_acquireNextImage), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetClearOnImageAvailableListenerHandler()
	{
		if ((object)cb_clearOnImageAvailableListener == null)
		{
			cb_clearOnImageAvailableListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearOnImageAvailableListener));
		}
		return cb_clearOnImageAvailableListener;
	}

	private static void n_ClearOnImageAvailableListener(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnImageAvailableListener();
	}

	public void ClearOnImageAvailableListener()
	{
		if (id_clearOnImageAvailableListener == IntPtr.Zero)
		{
			id_clearOnImageAvailableListener = JNIEnv.GetMethodID(class_ref, "clearOnImageAvailableListener", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_clearOnImageAvailableListener);
	}

	private static Delegate GetCloseHandler()
	{
		if ((object)cb_close == null)
		{
			cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
		}
		return cb_close;
	}

	private static void n_Close(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
	}

	public void Close()
	{
		if (id_close == IntPtr.Zero)
		{
			id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_close);
	}

	private static Delegate GetSetOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_Handler()
	{
		if ((object)cb_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_ == null)
		{
			cb_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_));
		}
		return cb_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_;
	}

	private static void n_SetOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IImageReaderProxy? imageReaderProxy = Java.Lang.Object.GetObject<IImageReaderProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IImageReaderProxyOnImageAvailableListener p = Java.Lang.Object.GetObject<IImageReaderProxyOnImageAvailableListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		IExecutor p2 = Java.Lang.Object.GetObject<IExecutor>(native_p1, JniHandleOwnership.DoNotTransfer);
		imageReaderProxy.SetOnImageAvailableListener(p, p2);
	}

	public unsafe void SetOnImageAvailableListener(IImageReaderProxyOnImageAvailableListener p0, IExecutor p1)
	{
		if (id_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
		{
			id_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID(class_ref, "setOnImageAvailableListener", "(Landroidx/camera/core/impl/ImageReaderProxy$OnImageAvailableListener;Ljava/util/concurrent/Executor;)V");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_setOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_, ptr);
	}
}
