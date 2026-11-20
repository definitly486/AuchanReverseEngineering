using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProcessor", "", "AndroidX.Camera.Core.IImageProcessorInvoker")]
public interface IImageProcessor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("process", "(Landroidx/camera/core/ImageProcessor$Request;)Landroidx/camera/core/ImageProcessor$Response;", "GetProcess_Landroidx_camera_core_ImageProcessor_Request_Handler:AndroidX.Camera.Core.IImageProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	IImageProcessorResponse Process(IImageProcessorRequest p0);
}
