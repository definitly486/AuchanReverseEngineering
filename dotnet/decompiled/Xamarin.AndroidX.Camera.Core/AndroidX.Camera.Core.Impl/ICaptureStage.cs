using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CaptureStage", "", "AndroidX.Camera.Core.Impl.ICaptureStageInvoker")]
public interface ICaptureStage : IJavaObject, IDisposable, IJavaPeerable
{
	CaptureConfig CaptureConfig
	{
		[Register("getCaptureConfig", "()Landroidx/camera/core/impl/CaptureConfig;", "GetGetCaptureConfigHandler:AndroidX.Camera.Core.Impl.ICaptureStageInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int Id
	{
		[Register("getId", "()I", "GetGetIdHandler:AndroidX.Camera.Core.Impl.ICaptureStageInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
