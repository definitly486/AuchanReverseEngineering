using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/SurfaceProcessor", "", "AndroidX.Camera.Core.ISurfaceProcessorInvoker")]
public interface ISurfaceProcessor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onInputSurface", "(Landroidx/camera/core/SurfaceRequest;)V", "GetOnInputSurface_Landroidx_camera_core_SurfaceRequest_Handler:AndroidX.Camera.Core.ISurfaceProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnInputSurface(SurfaceRequest p0);

	[Register("onOutputSurface", "(Landroidx/camera/core/SurfaceOutput;)V", "GetOnOutputSurface_Landroidx_camera_core_SurfaceOutput_Handler:AndroidX.Camera.Core.ISurfaceProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnOutputSurface(ISurfaceOutput p0);
}
