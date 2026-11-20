using System;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraControl", "", "AndroidX.Camera.Core.ICameraControlInvoker")]
public interface ICameraControl : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("cancelFocusAndMetering", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetCancelFocusAndMeteringHandler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture CancelFocusAndMetering();

	[Register("enableTorch", "(Z)Lcom/google/common/util/concurrent/ListenableFuture;", "GetEnableTorch_ZHandler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture EnableTorch(bool p0);

	[Register("setExposureCompensationIndex", "(I)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetExposureCompensationIndex_IHandler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture SetExposureCompensationIndex(int p0);

	[Register("setLinearZoom", "(F)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetLinearZoom_FHandler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture SetLinearZoom(float p0);

	[Register("setZoomRatio", "(F)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetZoomRatio_FHandler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture SetZoomRatio(float p0);

	[Register("startFocusAndMetering", "(Landroidx/camera/core/FocusMeteringAction;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetStartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_Handler:AndroidX.Camera.Core.ICameraControlInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture StartFocusAndMetering(FocusMeteringAction p0);
}
