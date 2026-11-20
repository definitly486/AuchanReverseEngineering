using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor$Response", "", "AndroidX.Camera.Core.IImageProcessorResponseInvoker")]
public interface IImageProcessorResponse : IJavaObject, IDisposable, IJavaPeerable
{
	IImageProxy OutputImage
	{
		[Register("getOutputImage", "()Landroidx/camera/core/ImageProxy;", "GetGetOutputImageHandler:AndroidX.Camera.Core.IImageProcessorResponseInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
