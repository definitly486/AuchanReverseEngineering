using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor$Request", "", "AndroidX.Camera.Core.IImageProcessorRequestInvoker")]
public interface IImageProcessorRequest : IJavaObject, IDisposable, IJavaPeerable
{
	IImageProxy InputImage
	{
		[Register("getInputImage", "()Landroidx/camera/core/ImageProxy;", "GetGetInputImageHandler:AndroidX.Camera.Core.IImageProcessorRequestInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int OutputFormat
	{
		[Register("getOutputFormat", "()I", "GetGetOutputFormatHandler:AndroidX.Camera.Core.IImageProcessorRequestInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
