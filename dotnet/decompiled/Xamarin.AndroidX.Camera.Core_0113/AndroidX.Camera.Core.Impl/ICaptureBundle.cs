using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CaptureBundle", "", "AndroidX.Camera.Core.Impl.ICaptureBundleInvoker")]
public interface ICaptureBundle : IJavaObject, IDisposable, IJavaPeerable
{
	IList<ICaptureStage>? CaptureStages
	{
		[Register("getCaptureStages", "()Ljava/util/List;", "GetGetCaptureStagesHandler:AndroidX.Camera.Core.Impl.ICaptureBundleInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
