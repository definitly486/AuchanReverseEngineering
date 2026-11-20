using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Media;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProxy", DoNotGenerateAcw = true)]
internal class IImageProxyInvoker : Java.Lang.Object, IImageProxy, IAutoCloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProxy", typeof(IImageProxyInvoker));

	private nint class_ref;

	private static Delegate? cb_getCropRect;

	private static Delegate? cb_setCropRect_Landroid_graphics_Rect_;

	private nint id_getCropRect;

	private nint id_setCropRect_Landroid_graphics_Rect_;

	private static Delegate? cb_getFormat;

	private nint id_getFormat;

	private static Delegate? cb_getHeight;

	private nint id_getHeight;

	private static Delegate? cb_getImage;

	private nint id_getImage;

	private static Delegate? cb_getImageInfo;

	private nint id_getImageInfo;

	private static Delegate? cb_getWidth;

	private nint id_getWidth;

	private static Delegate? cb_close;

	private nint id_close;

	private static Delegate? cb_getPlanes;

	private nint id_getPlanes;

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

	public unsafe Rect CropRect
	{
		get
		{
			if (id_getCropRect == IntPtr.Zero)
			{
				id_getCropRect = JNIEnv.GetMethodID(class_ref, "getCropRect", "()Landroid/graphics/Rect;");
			}
			return Java.Lang.Object.GetObject<Rect>(JNIEnv.CallObjectMethod(base.Handle, id_getCropRect), JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			if (id_setCropRect_Landroid_graphics_Rect_ == IntPtr.Zero)
			{
				id_setCropRect_Landroid_graphics_Rect_ = JNIEnv.GetMethodID(class_ref, "setCropRect", "(Landroid/graphics/Rect;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(value?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_setCropRect_Landroid_graphics_Rect_, ptr);
		}
	}

	public int Format
	{
		get
		{
			if (id_getFormat == IntPtr.Zero)
			{
				id_getFormat = JNIEnv.GetMethodID(class_ref, "getFormat", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getFormat);
		}
	}

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

	public Image? Image
	{
		get
		{
			if (id_getImage == IntPtr.Zero)
			{
				id_getImage = JNIEnv.GetMethodID(class_ref, "getImage", "()Landroid/media/Image;");
			}
			return Java.Lang.Object.GetObject<Image>(JNIEnv.CallObjectMethod(base.Handle, id_getImage), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IImageInfo ImageInfo
	{
		get
		{
			if (id_getImageInfo == IntPtr.Zero)
			{
				id_getImageInfo = JNIEnv.GetMethodID(class_ref, "getImageInfo", "()Landroidx/camera/core/ImageInfo;");
			}
			return Java.Lang.Object.GetObject<IImageInfo>(JNIEnv.CallObjectMethod(base.Handle, id_getImageInfo), JniHandleOwnership.TransferLocalRef);
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

	public static IImageProxy? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageProxy>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageProxy'.");
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

	public IImageProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCropRectHandler()
	{
		if ((object)cb_getCropRect == null)
		{
			cb_getCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCropRect));
		}
		return cb_getCropRect;
	}

	private static nint n_GetCropRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CropRect);
	}

	private static Delegate GetSetCropRect_Landroid_graphics_Rect_Handler()
	{
		if ((object)cb_setCropRect_Landroid_graphics_Rect_ == null)
		{
			cb_setCropRect_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetCropRect_Landroid_graphics_Rect_));
		}
		return cb_setCropRect_Landroid_graphics_Rect_;
	}

	private static void n_SetCropRect_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_p0)
	{
		IImageProxy? imageProxy = Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Rect cropRect = Java.Lang.Object.GetObject<Rect>(native_p0, JniHandleOwnership.DoNotTransfer);
		imageProxy.CropRect = cropRect;
	}

	private static Delegate GetGetFormatHandler()
	{
		if ((object)cb_getFormat == null)
		{
			cb_getFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFormat));
		}
		return cb_getFormat;
	}

	private static int n_GetFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Format;
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
		return Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
	}

	private static Delegate GetGetImageHandler()
	{
		if ((object)cb_getImage == null)
		{
			cb_getImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImage));
		}
		return cb_getImage;
	}

	private static nint n_GetImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Image);
	}

	private static Delegate GetGetImageInfoHandler()
	{
		if ((object)cb_getImageInfo == null)
		{
			cb_getImageInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageInfo));
		}
		return cb_getImageInfo;
	}

	private static nint n_GetImageInfo(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageInfo);
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
		return Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
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
		Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
	}

	public void Close()
	{
		if (id_close == IntPtr.Zero)
		{
			id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_close);
	}

	private static Delegate GetGetPlanesHandler()
	{
		if ((object)cb_getPlanes == null)
		{
			cb_getPlanes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlanes));
		}
		return cb_getPlanes;
	}

	private static nint n_GetPlanes(nint jnienv, nint native__this)
	{
		return JNIEnv.NewArray(Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPlanes());
	}

	public IImageProxyPlaneProxy[] GetPlanes()
	{
		if (id_getPlanes == IntPtr.Zero)
		{
			id_getPlanes = JNIEnv.GetMethodID(class_ref, "getPlanes", "()[Landroidx/camera/core/ImageProxy$PlaneProxy;");
		}
		return (IImageProxyPlaneProxy[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_getPlanes), JniHandleOwnership.TransferLocalRef, typeof(IImageProxyPlaneProxy));
	}
}
