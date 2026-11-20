using System;
using Android.Runtime;
using Java.Interop;
using Java.Nio;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProxy$PlaneProxy", "", "AndroidX.Camera.Core.IImageProxyPlaneProxyInvoker")]
public interface IImageProxyPlaneProxy : IJavaObject, IDisposable, IJavaPeerable
{
	ByteBuffer Buffer
	{
		[Register("getBuffer", "()Ljava/nio/ByteBuffer;", "GetGetBufferHandler:AndroidX.Camera.Core.IImageProxyPlaneProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int PixelStride
	{
		[Register("getPixelStride", "()I", "GetGetPixelStrideHandler:AndroidX.Camera.Core.IImageProxyPlaneProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int RowStride
	{
		[Register("getRowStride", "()I", "GetGetRowStrideHandler:AndroidX.Camera.Core.IImageProxyPlaneProxyInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
