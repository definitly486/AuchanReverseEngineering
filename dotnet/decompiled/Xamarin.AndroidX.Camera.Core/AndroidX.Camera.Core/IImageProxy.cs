using System;
using Android.Graphics;
using Android.Media;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProxy", "", "AndroidX.Camera.Core.IImageProxyInvoker")]
public interface IImageProxy : IAutoCloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProxy", typeof(IImageProxy), isInterface: true);

	private static Delegate? cb_toBitmap;

	Rect CropRect
	{
		[Register("getCropRect", "()Landroid/graphics/Rect;", "GetGetCropRectHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
		[Register("setCropRect", "(Landroid/graphics/Rect;)V", "GetSetCropRect_Landroid_graphics_Rect_Handler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		set;
	}

	int Format
	{
		[Register("getFormat", "()I", "GetGetFormatHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Image? Image
	{
		[Register("getImage", "()Landroid/media/Image;", "GetGetImageHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IImageInfo ImageInfo
	{
		[Register("getImageInfo", "()Landroidx/camera/core/ImageInfo;", "GetGetImageInfoHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	[Register("close", "()V", "GetCloseHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	new void Close();

	[Register("getPlanes", "()[Landroidx/camera/core/ImageProxy$PlaneProxy;", "GetGetPlanesHandler:AndroidX.Camera.Core.IImageProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	IImageProxyPlaneProxy[] GetPlanes();

	private static Delegate GetToBitmapHandler()
	{
		if ((object)cb_toBitmap == null)
		{
			cb_toBitmap = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToBitmap));
		}
		return cb_toBitmap;
	}

	private static nint n_ToBitmap(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBitmap());
	}

	[Register("toBitmap", "()Landroid/graphics/Bitmap;", "GetToBitmapHandler:AndroidX.Camera.Core.IImageProxy, Xamarin.AndroidX.Camera.Core")]
	unsafe Bitmap ToBitmap()
	{
		return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBitmap.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
