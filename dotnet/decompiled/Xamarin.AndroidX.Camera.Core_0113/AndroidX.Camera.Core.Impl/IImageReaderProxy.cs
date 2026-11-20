using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageReaderProxy", "", "AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker")]
public interface IImageReaderProxy : IJavaObject, IDisposable, IJavaPeerable
{
	int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int ImageFormat
	{
		[Register("getImageFormat", "()I", "GetGetImageFormatHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int MaxImages
	{
		[Register("getMaxImages", "()I", "GetGetMaxImagesHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Surface? Surface
	{
		[Register("getSurface", "()Landroid/view/Surface;", "GetGetSurfaceHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	[Register("acquireLatestImage", "()Landroidx/camera/core/ImageProxy;", "GetAcquireLatestImageHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	IImageProxy? AcquireLatestImage();

	[Register("acquireNextImage", "()Landroidx/camera/core/ImageProxy;", "GetAcquireNextImageHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	IImageProxy? AcquireNextImage();

	[Register("clearOnImageAvailableListener", "()V", "GetClearOnImageAvailableListenerHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	void ClearOnImageAvailableListener();

	[Register("close", "()V", "GetCloseHandler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	void Close();

	[Register("setOnImageAvailableListener", "(Landroidx/camera/core/impl/ImageReaderProxy$OnImageAvailableListener;Ljava/util/concurrent/Executor;)V", "GetSetOnImageAvailableListener_Landroidx_camera_core_impl_ImageReaderProxy_OnImageAvailableListener_Ljava_util_concurrent_Executor_Handler:AndroidX.Camera.Core.Impl.IImageReaderProxyInvoker, Xamarin.AndroidX.Camera.Core")]
	void SetOnImageAvailableListener(IImageReaderProxyOnImageAvailableListener p0, IExecutor p1);
}
